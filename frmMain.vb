Imports System.Reflection

Public Class frmMain

    Public Event StartupNextInstance As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventHandler

    Private ToldUserRunningInNotificationTray As Boolean
    Private iRefresh As Integer
    Private dNextBlockchainInfoRefresh, dNextEligiusBlockInfoRefresh As Date
    Private bStarted As Boolean
    Private bRunning As Boolean
    Private iRefreshRate As Integer
    Private cnDB As OleDb.OleDbConnection
    Private cmWorkHashRates, cmShareCounts, cmHashRates, cmBlocks, cmPayout, cmP2Pool, cmLuck As OleDb.OleDbCommand

    Private Const csRegKey As String = "Software\MMiningMonitor"

    Private dictRegkeyNames As Dictionary(Of String, String)

    'who has the DB open
    Shared colDBOpenList As System.Collections.Generic.List(Of String)

    Private Class clsWorkerData
        Public WorkerName As String
        Public NonIdleTimeStamp As DateTime
        Public IdleWorkTimeStamp As DateTime
        Public IsActive As Boolean
        Public HashRate As Double
        Public HashRates As List(Of Double)
        Public AvgHashRate As Double
        Public IdleAlertSent As Boolean
    End Class

    Private Class clsPoolData
        Public Sub New()
            WorkerData = New List(Of clsWorkerData)
        End Sub

        Public iYourTotalShares As Integer
        Public dLastShareTime As Date
        Public bNewBlockFound As Boolean
        Public dLastBlockTime As Date
        Public dRoundShares As Double
        Public ds As DataSet
        Public dSHA256TotalHashRate As Double
        Public dScryptTotalHashRate As Double
        Public oData1, oData2, oData3 As Object
        Public WorkerData As List(Of clsWorkerData)
        Public sPoolName As String
        Public sTabName As String
        Public sTabLabel As String
        Public chkEnabled As CheckBox
    End Class

    Private PoolData(0 To 26) As clsPoolData

    Private Enum enPool
        f50btc = 0
        ozcoin = 1
        p2pool1 = 2
        eclipse1 = 3
        eclipse2 = 4
        p2pool2 = 5
        p2pool3 = 6
        p2pool4 = 7
        bitminter1 = 8
        bitminter2 = 9
        btcguild = 10
        slush = 11
        multipool1 = 12
        multipool2 = 13
        blockchaininfo = 14
        scryptguild1 = 15
        scryptguild2 = 16
        eligius1 = 17
        eligius2 = 18
        eligius3 = 19
        eligius4 = 20
        eligius5 = 21
        eligius6 = 22
        ltcrabbit1 = 23
        ltcrabbit2 = 24
        ltcrabbit3 = 25
        blockchaininfo2 = 26
        blockchaininfo3 = 27
    End Enum

#If DEBUG Then
    Private Const bErrorHandle As Boolean = False
#Else
    Private Const bErrorHandle As Boolean = True
#End If

    Private Sub frmMain_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Me.NotifyIcon1.Visible = False
        My.Application.DoEvents()

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Hide()
        e.Cancel = True

        If ToldUserRunningInNotificationTray = False Then
            Me.NotifyIcon1.ShowBalloonTip(30000, "Still running!", "Still running in notification tray!  If you want to close me, right click me and click Exit.", ToolTipIcon.Info)
            ToldUserRunningInNotificationTray = True

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & csRegKey, "ToldUserAboutNotification", "Y", Microsoft.Win32.RegistryValueKind.String)
        End If

    End Sub

    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim bOnePoolSet As Boolean

        bStarted = True

        cnDB = New OleDb.OleDbConnection
        cnDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & My.Application.Info.DirectoryPath & "\MPoolMonitor.accdb;Persist Security Info=False;"

        cmWorkHashRates = New OleDb.OleDbCommand
        cmWorkHashRates.CommandText = "insert into WorkerHashRates (Pool, Worker, Hashrate, CurrentTimeStamp) values(?, ?, ?, Now());"
        cmWorkHashRates.Parameters.Add("@Pool", OleDb.OleDbType.VarWChar, 255)
        cmWorkHashRates.Parameters.Add("@Worker", OleDb.OleDbType.VarWChar, 255)
        cmWorkHashRates.Parameters.Add("@Hashrate", OleDb.OleDbType.Double)
        cmWorkHashRates.Connection = cnDB

        cmShareCounts = New OleDb.OleDbCommand
        cmShareCounts.CommandText = "insert into ShareCounts (Pool, Shares, DurationInSeconds, CurrentTimestamp) values(?, ?, ?, Now());"
        cmShareCounts.Parameters.Add("@Pool", OleDb.OleDbType.VarWChar, 255)
        cmShareCounts.Parameters.Add("@Shares", OleDb.OleDbType.Integer)
        cmShareCounts.Parameters.Add("@DurationInSeconds", OleDb.OleDbType.VarWChar, 8)
        cmShareCounts.Connection = cnDB

        cmHashRates = New OleDb.OleDbCommand
        cmHashRates.CommandText = "insert into HashRates (Pool, HashType, HashTotal, CurrentTimestamp) values(?, ?, ?, Now());"
        cmHashRates.Parameters.Add("@Pool", OleDb.OleDbType.VarWChar, 255)
        cmHashRates.Parameters.Add("@HashType", OleDb.OleDbType.VarWChar, 255)
        cmHashRates.Parameters.Add("@HashTotal", OleDb.OleDbType.Double)
        cmHashRates.Connection = cnDB

        cmBlocks = New OleDb.OleDbCommand
        cmBlocks.CommandText = "insert into BlockHistory (Pool, CurrentTimeStamp) values(?, Now());"
        cmBlocks.Parameters.Add("@Pool", OleDb.OleDbType.VarWChar, 255)
        cmBlocks.Connection = cnDB

        cmPayout = New OleDb.OleDbCommand
        cmPayout.CommandText = "insert into PayoutInfo (Pool, ConfirmedBTC, UnconfirmedBTC, EstimatedBTC, PaidBTC, CurrentTimeStamp) values(?, ?, ?, ?, ?, Now());"
        cmPayout.Parameters.Add("@Pool", OleDb.OleDbType.VarWChar, 255)
        cmPayout.Parameters.Add("@ConfirmedBTC", OleDb.OleDbType.Double)
        cmPayout.Parameters.Add("@UnconfirmedBTC", OleDb.OleDbType.Double)
        cmPayout.Parameters.Add("@EstimatedBTC", OleDb.OleDbType.Double)
        cmPayout.Parameters.Add("@PaidBTC", OleDb.OleDbType.Double)
        cmPayout.Connection = cnDB

        cmP2Pool = New OleDb.OleDbCommand
        With cmP2Pool
            .CommandText = "insert into P2PoolInfo (PeersIn, PeersOut, BlockValue, PoolDifficulty, PoolStaleRate, CurrentTimeStamp) values(?, ?, ?, ?, ?, Now());"
            .Parameters.Add("@PeersIn", OleDb.OleDbType.Integer)
            .Parameters.Add("@PeersOut", OleDb.OleDbType.Integer)
            .Parameters.Add("@BlockValue", OleDb.OleDbType.Double)
            .Parameters.Add("@PoolDifficulty", OleDb.OleDbType.Double)
            .Parameters.Add("@PoolStaleRate", OleDb.OleDbType.Double)
            .Connection = cnDB
        End With

        cmLuck = New OleDb.OleDbCommand
        With cmLuck
            .CommandText = "Insert into Luck (Pool, Luck, Height, AvgSolveTime, ActualSolveTime, BlockTimeStamp) values(?, ?, ?, ?, ?, ?);"
            .Parameters.Add("@Pool", OleDb.OleDbType.VarWChar, 255)
            .Parameters.Add("@Luck", OleDb.OleDbType.Double)
            .Parameters.Add("@Height", OleDb.OleDbType.Integer)
            .Parameters.Add("@AvgSolveTime", OleDb.OleDbType.Integer)
            .Parameters.Add("@ActualSolveTime", OleDb.OleDbType.Integer)
            .Parameters.Add("@BlockTimeStamp", OleDb.OleDbType.Date)
            .Connection = cnDB
        End With

        Call InitializePoolData()

        Me.NotifyIcon1.Icon = Me.Icon

        colDBOpenList = New System.Collections.Generic.List(Of String)

        'dictionary of reg key names by control name
        'saves from typos and case sensitivity issues
        dictRegkeyNames = New Dictionary(Of String, String)

        With dictRegkeyNames
            'options
            .Add(Me.chkConfigStoreDBStatistics.Name, "DBStatistics")
            .Add(Me.cmbConfigRefreshRate.Name, "RefreshRate")

            'idle alerts
            .Add(Me.chkIdleEMailAlerts.Name, "IdleAlerts")
            .Add(Me.chkIdlePopup.Name, "IdlePopup")
            .Add(Me.chkIdleWorkPopUpWithBeeps.Name, "IdlePopupWithBeeps")
            .Add(Me.chkIdleStartApp.Name, "IdleStartapp")
            .Add(Me.txtIdleStartAppName.Name, "IdleStartappName")
            .Add(Me.txtIdleStartParms.Name, "IdleStartappParms")

            'email settings
            .Add(Me.txtSMTPServer.Name, "SMTPServerName")
            .Add(Me.txtSMTPPort.Name, "SMTPServerPort")
            .Add(Me.txtSMTPUserName.Name, "SMTPUserName")
            .Add(Me.txtSMTPPassword.Name, "SMTPUserPassword")
            .Add(Me.txtSMTPAlertName.Name, "SMTPAlertName")
            .Add(Me.txtSMTPAlertAddress.Name, "SMTPAlertAddress")
            .Add(Me.txtSMTPAlertSubject.Name, "SMTPAlertSubject")
            .Add(Me.txtSMTPFromName.Name, "SMTPFromName")
            .Add(Me.txtSMTPFromAddress.Name, "SMTPFromAddress")
            .Add(Me.chkSMTPSSL.Name, "SMTPUseSSL")

            '50btc
            .Add(Me.chk50BTCEnabled.Name, "50BTCEnabled")
            .Add(Me.txt50BTCAPIKey.Name, "50BTCBTCAddy")    'not sure why I set it to this... but can't change it now

            'eclipse
            .Add(Me.chkEclipseEnabled.Name, "EclipseEnabled")
            .Add(Me.txtEclipseAPIKey.Name, "EclipseAPIKey")

            'ozcoin
            .Add(Me.chkOzcoinEnabled.Name, "OzcoinEnabled")
            .Add(Me.txtOzcoinAPIKey.Name, "OzcoinAPIKey")

            'p2pool
            .Add(Me.chkP2PoolEnabled.Name, "P2PoolEnabled")
            .Add(Me.txtP2PoolURL.Name, "P2PoolURL")
            .Add(Me.txtP2PoolBTCAddy.Name, "P2PoolBTCAddy")
            .Add(Me.chkP2PoolScrypt.Name, "P2PoolScryptPool")
            .Add(Me.chkP2PPublicPool.Name, "P2PoolPublicPool")

            'bitminter
            .Add(Me.chkBitMinterEnabled.Name, "BitMinterEnabled")
            .Add(Me.txtBitMinterAPIKey.Name, "BitMinterAPIKey")
            .Add(Me.chkBitMinterShowWorkerCheckPoint.Name, "BitMinterShowWorkerCheckPointData")
            .Add(Me.chkBitMinterShowWorkerTotals.Name, "BitMinterShowWorkerTotalData")

            'btcguild
            .Add(Me.chkBTCGuildEnabled.Name, "BTCGuildEnabled")
            .Add(Me.txtBTCGuildAPIKey.Name, "BTCGuildAPIKey")

            'slush
            .Add(Me.chkSlushEnabled.Name, "SlushEnabled")
            .Add(Me.txtSlushAPIKey.Name, "SlushAPIKey")

            'multipool
            .Add(Me.chkMultipoolEnabled.Name, "MultipoolEnabled")
            .Add(Me.txtMultipoolAPIKey.Name, "MultipoolAPIKey")

            'blockchain info
            .Add(Me.chkBlockChainInfoEnabled.Name, "Blockchain.infoEnabled")
            .Add(Me.cmbBlockChainInfoRefreshRate.Name, "Blockchain.InfoRefreshRate")
            .Add(Me.txtBCIc_Blocksize.Name, "Blockchain.infoCalcBlockSize")
            .Add(Me.txtBCIc_PeriodInDays.Name, "Blockchain.infoCalcPeriodInDays")
            .Add(Me.txtBCIc_FeeDonation.Name, "Blockchain.infoCalcFeeDonation")

            'scryptguild
            .Add(Me.chkScryptGuildEnabled.Name, "ScryptGuildEnabled")
            .Add(Me.chkScryptGuildShowBalanceData.Name, "ScryptGuildShowBalanceData")
            .Add(Me.chkScryptGuildShowWorkerData.Name, "ScryptGuildShowWorkerData")
            .Add(Me.txtScryptGuildAPIKey.Name, "ScryptGuildAPIKey")
            .Add(Me.chkScryptGuildOmitTinyBalances.Name, "ScryptGuildOmitTinyBalances")

            'eligius
            .Add(Me.chkEligiusEnabled.Name, "EligiusEnabled")
            .Add(Me.txtEligiusBTCAddress.Name, "EligiusBTCAddress")
            .Add(Me.txtEligiusBTCAddy2.Name, "EligiusBTCAddy2")
            .Add(Me.txtEligiusBTCAddy3.Name, "EligiusBTCAddy3")

            'ltcrabbit
            .Add(Me.chkLTCRabbitEnabled.Name, "LTCRabbitEnabled")
            .Add(Me.txtLTCRabbitAPIKey.Name, "LTCRabbitAPIKey")
        End With

        'set the configuration options stored in the registry 
        Using key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(csRegKey)
            If key Is Nothing Then
                My.Computer.Registry.CurrentUser.CreateSubKey(csRegKey)
            End If
        End Using

        Using key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(csRegKey)
            Call SetControlByRegKey(key, Me.chkConfigStoreDBStatistics)
            Call SetControlByRegKey(key, Me.cmbConfigRefreshRate, "5 minutes")
            Call SetControlByRegKey(key, Me.chkIdlePopup, True)

            If key.GetValue("Width") > 100 Then
                Me.Width = key.GetValue("Width")
            End If

            If key.GetValue("Height") > 100 Then
                Me.Height = key.GetValue("Height")
            End If

            If key.GetValue("ToldUserAboutNotification") = "Y" Then
                ToldUserRunningInNotificationTray = True
            End If

            'idle alerts
            Call SetControlByRegKey(key, Me.chkIdleEMailAlerts)
            Call SetControlByRegKey(key, Me.chkIdlePopup, True)
            Call SetControlByRegKey(key, Me.chkIdleWorkPopUpWithBeeps, True)
            Call SetControlByRegKey(key, Me.chkIdleStartApp)
            Call SetControlByRegKey(key, Me.txtIdleStartAppName)
            Call SetControlByRegKey(key, Me.txtIdleStartParms)

            'email settings
            Call SetControlByRegKey(key, Me.txtSMTPServer)
            Call SetControlByRegKey(key, Me.txtSMTPPort)
            Call SetControlByRegKey(key, Me.txtSMTPUserName)
            Call SetControlByRegKey(key, Me.txtSMTPPassword)
            Call SetControlByRegKey(key, Me.txtSMTPAlertName)
            Call SetControlByRegKey(key, Me.txtSMTPAlertAddress)
            Call SetControlByRegKey(key, Me.txtSMTPAlertSubject)
            Call SetControlByRegKey(key, Me.txtSMTPFromName)
            Call SetControlByRegKey(key, Me.txtSMTPFromAddress)
            Call SetControlByRegKey(key, Me.chkSMTPSSL)

            '50btc
            Call SetControlByRegKey(key, Me.chk50BTCEnabled)
            Call SetControlByRegKey(key, Me.txt50BTCAPIKey)

            'eclipse
            Call SetControlByRegKey(key, Me.chkEclipseEnabled)
            Call SetControlByRegKey(key, Me.txtEclipseAPIKey)

            'ozcoin
            Call SetControlByRegKey(key, Me.chkOzcoinEnabled)
            Call SetControlByRegKey(key, Me.txtOzcoinAPIKey)

            'p2pool
            Call SetControlByRegKey(key, Me.chkP2PoolEnabled)
            Call SetControlByRegKey(key, Me.txtP2PoolURL)
            Call SetControlByRegKey(key, Me.txtP2PoolBTCAddy)
            Call SetControlByRegKey(key, Me.chkP2PoolScrypt)
            Call SetControlByRegKey(key, Me.chkP2PPublicPool)

            'bitminter
            Call SetControlByRegKey(key, Me.chkBitMinterEnabled)
            Call SetControlByRegKey(key, Me.txtBitMinterAPIKey)
            Call SetControlByRegKey(key, Me.chkBitMinterShowWorkerCheckPoint)
            Call SetControlByRegKey(key, Me.chkBitMinterShowWorkerTotals)

            'btcguild
            Call SetControlByRegKey(key, Me.chkBTCGuildEnabled)
            Call SetControlByRegKey(key, Me.txtBTCGuildAPIKey)

            'slush
            Call SetControlByRegKey(key, Me.chkSlushEnabled)
            Call SetControlByRegKey(key, Me.txtSlushAPIKey)

            'multipool
            Call SetControlByRegKey(key, Me.chkMultipoolEnabled)
            Call SetControlByRegKey(key, Me.txtMultipoolAPIKey)

            'blockchain.info
            Call SetControlByRegKey(key, Me.chkBlockChainInfoEnabled)
            Call SetControlByRegKey(key, Me.cmbBlockChainInfoRefreshRate)
            Call SetControlByRegKey(key, Me.txtBCIc_Blocksize)
            Call SetControlByRegKey(key, Me.txtBCIc_PeriodInDays)
            Call SetControlByRegKey(key, Me.txtBCIc_FeeDonation)

            'scryptguild
            Call SetControlByRegKey(key, Me.chkScryptGuildEnabled)
            Call SetControlByRegKey(key, Me.chkScryptGuildShowBalanceData, True)
            Call SetControlByRegKey(key, Me.chkScryptGuildShowWorkerData, True)
            Call SetControlByRegKey(key, Me.txtScryptGuildAPIKey)
            Call SetControlByRegKey(key, Me.chkScryptGuildOmitTinyBalances, True)

            'eligius
            Call SetControlByRegKey(key, Me.chkEligiusEnabled)
            Call SetControlByRegKey(key, Me.txtEligiusBTCAddress)
            Call SetControlByRegKey(key, Me.txtEligiusBTCAddy2)
            Call SetControlByRegKey(key, Me.txtEligiusBTCAddy3)

            'ltcrabbit
            Call SetControlByRegKey(key, Me.chkLTCRabbitEnabled)
            Call SetControlByRegKey(key, Me.txtLTCRabbitAPIKey)

            key.Close()
        End Using

        'do table checks to upgrade prior versions as needed
        Call TableUpgradeChecks()

        Select Case Me.cmbConfigRefreshRate.Text
            Case "5 minutes"
                iRefreshRate = 300

            Case "10 minutes"
                iRefreshRate = 600

            Case "15 minutes"
                iRefreshRate = 900

            Case "30 minutes"
                iRefreshRate = 1800

            Case "60 minutes"
                iRefreshRate = 3600

            Case Else
                iRefresh = 300

        End Select

        If ValidatePool(enPool.f50btc) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.eclipse1) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.ozcoin) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.p2pool1) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.bitminter1) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.slush) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.btcguild) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.multipool1) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.blockchaininfo) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.scryptguild1) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.eligius1) = True Then
            bOnePoolSet = True
        ElseIf ValidatePool(enPool.ltcrabbit1) = True Then
            bOnePoolSet = True
        End If

        If bOnePoolSet = True Then
            Me.tabsShown.SelectTab(0)

            Me.timer_start.Enabled = True
        Else
            Me.tabsShown.SelectTab(Me.tabsShown.TabPages.Count - 1)
        End If

    End Sub

    Private Sub TableUpgradeChecks()

        Dim cmAny As OleDb.OleDbCommand

        If Me.chkConfigStoreDBStatistics.Checked = True Then
            Try
                cnDB.Open()

                Try
                    cmAny = New OleDb.OleDbCommand

                    cmAny.Connection = cnDB
                    cmAny.CommandType = CommandType.Text
                    cmAny.CommandText = "select top 1 * from Luck;"

                    cmAny.ExecuteNonQuery()
                Catch ex As Exception
                    'table doesn't exist, create it
                    cmAny = New OleDb.OleDbCommand

                    cmAny.Connection = cnDB
                    cmAny.CommandType = CommandType.Text
                    cmAny.CommandText = "CREATE TABLE Luck (Pool char (255), Luck double, Height Integer, AvgSolveTime Integer, ActualSolveTime Integer, BlockTimeStamp Date);"
                    cmAny.ExecuteNonQuery()

                    cmAny.CommandText = "CREATE INDEX iTS on Luck (BlockTimeStamp desc);"
                    cmAny.ExecuteNonQuery()

                    cmAny.CommandText = "CREATE INDEX iHeight on Luck (Height desc);"
                    cmAny.ExecuteNonQuery()
                Finally
                    If cnDB.State <> ConnectionState.Closed Then
                        cnDB.Close()
                    End If
                End Try
            Catch ex As Exception When bErrorHandle = True
                Me.NotifyIcon1.ShowBalloonTip(10000, "Database error!", ex.Message & vbCrLf & vbCrLf & "Disabling DB stats.", ToolTipIcon.Error)

                Me.chkConfigStoreDBStatistics.Checked = False
            End Try
        End If

    End Sub

    Private Sub InitializePoolData()

        Dim pd As clsPoolData

        For x As enPool = 0 To PoolData.GetUpperBound(0)
            PoolData(x) = New clsPoolData
            pd = PoolData(x)

            With pd
                .ds = New DataSet
                .ds.Tables.Add()

                Select Case x
                    Case enPool.bitminter1
                        .sPoolName = "Bitminter"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Shares/Rejected/Last")
                        End With

                        Me.dataBitMinter.DataSource = .ds.Tables(0)

                        With Me.dataBitMinter
                            .Columns(0).Width = 131
                            .Columns(1).Width = 191
                            .Columns(2).Width = 224
                        End With

                        Call SetGridSizes("\Columns\dataBitMinter", Me.dataBitMinter)

                        AddHandler Me.dataBitMinter.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabBitMinter"
                        .sTabLabel = "BitMinter"
                        'hide pool tab, will show later once we know what's enabled
                        Call HideTab(x)

                        .chkEnabled = Me.chkBitMinterEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.bitminter2
                        .sPoolName = "Bitminter"

                    Case enPool.blockchaininfo
                        .sTabName = "tabBlockchainInfo"
                        .sTabLabel = "BlockchainInfo"
                        Call HideTab(x)

                        .chkEnabled = Me.chkBlockChainInfoEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.blockchaininfo2, enPool.blockchaininfo3
                        'do nothing

                    Case enPool.btcguild
                        .sPoolName = "BTC Guild"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Shares/Stales/Dupe/Unknown")
                            .Columns.Add("Bad")
                        End With

                        Me.dataBTCGuild.DataSource = .ds.Tables(0)

                        With Me.dataBTCGuild
                            .Columns(0).Width = 158
                            .Columns(1).Width = 209
                            .Columns(2).Width = 261
                            .Columns(3).Width = 68
                        End With

                        Call SetGridSizes("\Columns\dataBTCGuild", Me.dataBTCGuild)

                        AddHandler Me.dataBTCGuild.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabBTCGuild"
                        .sTabLabel = "BTC Guild"
                        Call HideTab(x)

                        .chkEnabled = Me.chkBTCGuildEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.eclipse1
                        .sPoolName = "Eclipse"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("RShares/TShares/LShare")
                        End With

                        Me.dataEclipse.DataSource = .ds.Tables(0)

                        With Me.dataEclipse
                            .Columns(0).Width = 180
                            .Columns(1).Width = 198
                            .Columns(2).Width = 251
                        End With

                        Call SetGridSizes("\Columns\dataEclipse", Me.dataEclipse)

                        AddHandler Me.dataEclipse.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabEclipse"
                        .sTabLabel = "Eclipse"
                        Call HideTab(x)

                        .chkEnabled = Me.chkEclipseEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.eclipse2
                        .sPoolName = "Eclipse"

                    Case enPool.eligius1
                        .sPoolName = "Eligius"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Sharecount")
                            .Columns.Add("Period")
                        End With

                        Me.dataEligius.DataSource = .ds.Tables(0)

                        With Me.dataEligius
                            .Columns(1).Width = 237
                            .Columns(2).Width = 111
                            .Columns(3).Width = 128
                        End With

                        Call SetGridSizes("\Columns\dataEligius", Me.dataEligius)

                        AddHandler Me.dataEligius.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabEligius"
                        .sTabLabel = "Eligius"
                        Call HideTab(x)

                        .chkEnabled = Me.chkEligiusEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.eligius2, enPool.eligius3, enPool.eligius4, enPool.eligius5, enPool.eligius6
                        .sPoolName = "Eligius"

                    Case enPool.f50btc
                        .sPoolName = "50BTC"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Total Shares")
                            .Columns.Add("Last Share")
                        End With

                        Me.data50btc.DataSource = .ds.Tables(0)

                        With Me.data50btc
                            .Columns(0).Width = 249
                            .Columns(1).Width = 209
                            .Columns(2).Width = 209
                        End With

                        Call SetGridSizes("\Columns\data50btc", Me.data50btc)

                        AddHandler Me.data50btc.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tab50BTC"
                        .sTabLabel = "50BTC"
                        Call HideTab(x)

                        .chkEnabled = Me.chk50BTCEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.ltcrabbit1
                        .sPoolName = "LTC Rabbit"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Active")
                        End With

                        Me.dataLTCRabbit.DataSource = .ds.Tables(0)

                        With Me.dataLTCRabbit
                            .Columns(0).Width = 108
                            .Columns(1).Width = 204
                        End With

                        Call SetGridSizes("\Columns\dataLTCRabbit", Me.dataLTCRabbit)

                        AddHandler Me.dataLTCRabbit.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabLTCRabbit"
                        .sTabLabel = "LTC Rabbit"
                        Call HideTab(x)

                        .chkEnabled = Me.chkLTCRabbitEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.ltcrabbit2, enPool.ltcrabbit3
                        .sPoolName = "LTC Rabbit"

                    Case enPool.multipool1  'coin data
                        .sPoolName = "Multipool"

                        With .ds.Tables(0)
                            .Columns.Add("Coin")
                            .Columns.Add("Balance")
                            .Columns.Add("UserHashrate")
                            .Columns.Add("Pending")
                            .Columns.Add("PoolHashrate")
                        End With

                        Me.dataMultiCoinData.DataSource = .ds.Tables(0)

                        With Me.dataMultiCoinData
                            .Columns(0).Width = 63
                            .Columns(1).Width = 145
                            .Columns(2).Width = 145
                            .Columns(3).Width = 145
                            .Columns(4).Width = 145
                        End With

                        Call SetGridSizes("\Columns\dataMultipoolCoinData", Me.dataMultiCoinData)

                        AddHandler Me.dataMultiCoinData.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabMultipool"
                        .sTabLabel = "Multipool"
                        Call HideTab(x)

                        .chkEnabled = Me.chkMultipoolEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.multipool2   'worker data
                        .sPoolName = "Multipool"

                        With .ds.Tables(0)
                            .Columns.Add("Coin")
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate")
                        End With

                        Me.dataMultiWorkerData.DataSource = .ds.Tables(0)

                        With Me.dataMultiWorkerData
                            .Columns(0).Width = 63
                            .Columns(1).Width = 117
                            .Columns(2).Width = 145
                        End With

                        Call SetGridSizes("\Columns\dataMultipoolWorkerData", Me.dataMultiWorkerData)

                        AddHandler Me.dataMultiWorkerData.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                    Case enPool.ozcoin
                        .sPoolName = "Ozcoin"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Shares/Stales/Efficiency")
                        End With

                        Me.dataOz.DataSource = .ds.Tables(0)

                        With Me.dataOz
                            .Columns(0).Width = 203
                            .Columns(1).Width = 176
                            .Columns(2).Width = 206
                        End With

                        Call SetGridSizes("\Columns\dataOzcoin", Me.dataOz)

                        AddHandler Me.dataOz.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabOzcoin"
                        .sTabLabel = "OzCoin"
                        Call HideTab(x)

                        .chkEnabled = Me.chkOzcoinEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.p2pool1
                        .sPoolName = "p2pool"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                        End With

                        Me.dataP2pool.DataSource = .ds.Tables(0)

                        With Me.dataP2pool
                            .Columns(0).Width = 131
                            .Columns(1).Width = 231
                        End With

                        Call SetGridSizes("\Columns\dataP2pool", Me.dataP2pool)

                        AddHandler Me.dataP2pool.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabP2pool"
                        .sTabLabel = "P2Pool"
                        Call HideTab(x)

                        .chkEnabled = Me.chkP2PoolEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.p2pool2, enPool.p2pool3, enPool.p2pool4
                        .sPoolName = "p2pool"

                    Case enPool.scryptguild1 'balance data
                        .sPoolName = "ScryptGuild"

                        With .ds.Tables(0)
                            .Columns.Add("Coin")
                            .Columns.Add("Balance")
                        End With

                        With Me.dataMultiCoinData
                            .Columns(0).Width = 63
                            .Columns(1).Width = 145
                        End With

                        Me.dataScryptGuildBalanceData.DataSource = .ds.Tables(0)

                        Call SetGridSizes("\Columns\dataScryptGuildBalanceData", Me.dataScryptGuildBalanceData)

                        AddHandler Me.dataScryptGuildBalanceData.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabScryptGuild"
                        .sTabLabel = "ScryptGuild"
                        Call HideTab(x)

                        .chkEnabled = Me.chkScryptGuildEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case enPool.scryptguild2 'worker data
                        .sPoolName = "ScryptGuild"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Shares/Stales/Dupe/Unknown")
                            .Columns.Add("Bad")
                        End With

                        Me.dataScryptGuildWorkerData.DataSource = .ds.Tables(0)

                        With Me.dataBTCGuild
                            .Columns(0).Width = 158
                            .Columns(1).Width = 209
                            .Columns(2).Width = 261
                            .Columns(3).Width = 68
                        End With

                        Call SetGridSizes("\Columns\dataScryptGuildWorkerData", Me.dataScryptGuildWorkerData)

                        AddHandler Me.dataScryptGuildWorkerData.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                    Case enPool.slush
                        .sPoolName = "Slush's Pool"

                        With .ds.Tables(0)
                            .Columns.Add("Worker")
                            .Columns.Add("Hashrate/Avg")
                            .Columns.Add("Shares/Score/Last")
                        End With

                        Me.dataSlush.DataSource = .ds.Tables(0)

                        With Me.dataSlush
                            .Columns(0).Width = 158
                            .Columns(1).Width = 161
                            .Columns(2).Width = 324
                        End With

                        Call SetGridSizes("\Columns\dataSlush", Me.dataSlush)

                        AddHandler Me.dataSlush.ColumnWidthChanged, AddressOf Me.dataGrid_ColumnWidthChanged

                        .sTabName = "tabSlush"
                        .sTabLabel = "Slush's Pool"
                        Call HideTab(x)

                        .chkEnabled = Me.chkSlushEnabled
                        AddHandler .chkEnabled.CheckedChanged, AddressOf Me.TabEnabled_CheckedChanged

                    Case Else
                        Throw New Exception("Internal error: Pool not found in InitializePoolData.")

                End Select
            End With
        Next

    End Sub

    Private Sub SetControlByRegKey(ByRef regKey As Microsoft.Win32.RegistryKey, ByRef chkAny As CheckBox, Optional bDefault As Boolean = False)

        Dim sKey As String
        Dim sTemp As String

        If dictRegkeyNames.TryGetValue(chkAny.Name, sKey) = True Then
            sTemp = regKey.GetValue(sKey)

            If sTemp = "Y" Then
                chkAny.Checked = True
            Else
                If String.IsNullOrEmpty(sTemp) = True Then
                    chkAny.Checked = bDefault
                Else
                    chkAny.Checked = False
                End If
            End If
        Else
            Throw New Exception("Internal error: " & chkAny.Name & " not found in regKey dictionary.")
        End If

    End Sub

    Private Sub SetControlByRegKey(ByRef regKey As Microsoft.Win32.RegistryKey, ByRef txtAny As TextBox, Optional ByVal sDefault As String = "")

        Call _SetControlByRegKey(regKey, txtAny, sDefault)

    End Sub

    Private Sub SetControlByRegKey(ByRef regKey As Microsoft.Win32.RegistryKey, ByRef cmbAny As ComboBox, Optional ByVal sDefault As String = "")

        Call _SetControlByRegKey(regKey, cmbAny, sDefault)

    End Sub

    Private Sub _SetControlByRegKey(ByRef regKey As Microsoft.Win32.RegistryKey, ByRef ctlAny As Control, Optional ByVal sDefault As String = "")

        Dim sKey As String
        Dim sReturn As String

        If dictRegkeyNames.TryGetValue(ctlAny.Name, sKey) = True Then
            sReturn = regKey.GetValue(sKey)

            If String.IsNullOrEmpty(sReturn) = True Then
                ctlAny.Text = sDefault
            Else
                ctlAny.Text = sReturn
            End If
        Else
            Throw New Exception("Internal error: " & ctlAny.Name & " not found in regKey dictionary.")
        End If

    End Sub

    Private Sub SetGridSizes(ByVal sKey As String, ByRef dataGrid As DataGridView)

        Using key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(csRegKey & sKey)
            If key IsNot Nothing Then
                For Each colAny As DataGridViewColumn In dataGrid.Columns
                    If key.GetValue(colAny.Name) <> 0 Then
                        colAny.Width = key.GetValue(colAny.Name)
                    End If
                Next

                key.Close()
            End If
        End Using

    End Sub

    Private Sub CheckForIdleWorkers(pd As clsPoolData)

        Dim frmAP As frmAnnoyingPopup

        For Each WorkerData As clsWorkerData In pd.WorkerData
            If WorkerData.IdleAlertSent = False AndAlso WorkerData.IsActive = False AndAlso WorkerData.NonIdleTimeStamp <> #12:00:00 AM# AndAlso WorkerData.NonIdleTimeStamp.AddMinutes(5) < Now Then
                'worker is deemed idle

                'annoying popup
                If chkIdlePopup.Checked = True Then
                    frmAP = New frmAnnoyingPopup

                    frmAP.lblIdleWorker.Text = "Worker '" & WorkerData.WorkerName & "' on pool '" & pd.sPoolName & "' has been idle for 5+ minutes!!"
                    frmAP.Text = "Idle worker alert!  (" & Now.ToString & ")"

                    frmAP.Show()
                    frmAP.Focus()

                    frmAP.timer_beep.Enabled = Me.chkIdleWorkPopUpWithBeeps.Checked

                    Me.NotifyIcon1.ShowBalloonTip(0, "Idle worker alert!", "Worker '" & WorkerData.WorkerName & "' on pool '" & pd.sPoolName & "' has been idle for 5+ minutes!!", ToolTipIcon.Warning)
                End If

                'launch process
                If chkIdleStartApp.Checked = True Then
                    If String.IsNullOrEmpty(Me.txtIdleStartAppName.Text) = False Then
                        Try
                            If My.Computer.FileSystem.FileExists(Me.txtIdleStartAppName.Text) = False Then
                                Me.NotifyIcon1.ShowBalloonTip(30000, "Error starting idle worker process!", "Error starting idle worker process!  The specified application to start does not seem to exist.", ToolTipIcon.Error)
                            Else
                                Process.Start(Me.txtIdleStartAppName.Text, Replace(Me.txtIdleStartParms.Text, "%W", WorkerData.WorkerName).Replace("%P", pd.sPoolName))
                            End If
                        Catch ex As Exception
                            Me.NotifyIcon1.ShowBalloonTip(30000, "Error starting idle worker process!", "Error starting idle worker process!" & vbCrLf & vbCrLf & ex.Message, ToolTipIcon.Error)
                        End Try
                    End If
                End If

                'email alert if enabled
                If chkIdleEMailAlerts.Checked = True Then
                    If String.IsNullOrEmpty(Me.txtSMTPServer.Text) = True OrElse String.IsNullOrEmpty(Me.txtSMTPPort.Text) = True OrElse String.IsNullOrEmpty(Me.txtSMTPUserName.Text) = True _
                                OrElse String.IsNullOrEmpty(Me.txtSMTPPassword.Text) = True OrElse String.IsNullOrEmpty(Me.txtSMTPAlertAddress.Text) = True _
                                OrElse String.IsNullOrEmpty(Me.txtSMTPFromAddress.Text) = True Then Exit Sub

                    If String.IsNullOrEmpty(Me.txtSMTPAlertSubject.Text) = True Then
                        Call SendEMail("Worker '" & WorkerData.WorkerName & "' on pool '" & pd.sPoolName & "' has been idle for 5+ minutes.", "Worker '" & WorkerData.WorkerName & "' on pool '" & pd.sPoolName & "' has been idle for 5+ minutes.")
                    Else
                        Call SendEMail("Worker '" & WorkerData.WorkerName & "' on pool '" & pd.sPoolName & "' has been idle for 5+ minutes.", Me.txtSMTPAlertSubject.Text)
                    End If
                End If

                WorkerData.IdleAlertSent = True
            End If
        Next

    End Sub

    Private Sub HandleEMailResponse(ByVal Sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)

        If e.Error Is Nothing Then
            Me.NotifyIcon1.ShowBalloonTip(5000, "Idle email sent", "Idle email sent", ToolTipIcon.Info)
        Else
            Me.NotifyIcon1.ShowBalloonTip(5000, "Idle email failed", "Idle email failed", ToolTipIcon.Warning)
        End If

        With DirectCast(e.UserState, System.Net.Mail.SmtpClient)
            RemoveHandler .SendCompleted, AddressOf HandleEMailResponse
            .Dispose()
        End With

    End Sub

    Private Function ProcessWorkerData(ByRef pd As clsPoolData, ByVal sWorkerName As String, ByVal dbHashRate As Double) As Double

        Dim bWorkerFound As Boolean
        Dim WorkerData As clsWorkerData

        For Each WorkerData In pd.WorkerData
            If WorkerData.WorkerName = sWorkerName Then
                WorkerData.HashRate = dbHashRate
                WorkerData.HashRates.Add(WorkerData.HashRate)

                'keep the last 60 entries only
                If WorkerData.HashRates.Count = 61 Then
                    WorkerData.HashRates.RemoveAt(0)
                End If

                bWorkerFound = True

                Exit For
            End If
        Next

        If bWorkerFound = False Then
            WorkerData = New clsWorkerData
            WorkerData.HashRate = dbHashRate
            WorkerData.WorkerName = sWorkerName
            WorkerData.HashRates = New List(Of Double)
            WorkerData.HashRates.Add(WorkerData.HashRate)

            pd.WorkerData.Add(WorkerData)
        End If

        'calculate average
        WorkerData.AvgHashRate = 0

        For Each db As Double In WorkerData.HashRates
            WorkerData.AvgHashRate += db
        Next

        WorkerData.AvgHashRate /= WorkerData.HashRates.Count

        If dbHashRate <> 0 AndAlso WorkerData.IsActive = False Then
            WorkerData.IsActive = True
            WorkerData.NonIdleTimeStamp = Now
            WorkerData.IdleAlertSent = False
        End If

        If dbHashRate = 0 AndAlso WorkerData.IsActive = True Then
            WorkerData.IsActive = False
            WorkerData.IdleWorkTimeStamp = Now
        End If

        Return WorkerData.AvgHashRate

    End Function

    'this is what does all the work
    'it's called asyncronously when the web call finishes
    Private Sub HandlePoolResponse(ByVal sJSONText As String, ByVal CurrentPool As enPool)

        Try
            If Me.chkConfigStoreDBStatistics.Checked = True Then
                Try
                    If colDBOpenList.Count = 0 Then
                        cnDB.Open()
                    End If

                    colDBOpenList.Add(CurrentPool.ToString)
                    Debug.Print(Now.ToString & ": Added " & CurrentPool.ToString & " (count = " & colDBOpenList.Count & ")")
                Catch ex As Exception When bErrorHandle = True
                    Me.NotifyIcon1.ShowBalloonTip(10000, "Database error!", ex.Message & vbCrLf & vbCrLf & "Disabling DB stats.", ToolTipIcon.Error)

                    Me.chkConfigStoreDBStatistics.Checked = False
                End Try
            End If

            Select Case CurrentPool
                Case enPool.f50btc
                    Call Handle50BTC(sJSONText)

                Case enPool.eclipse1, enPool.eclipse2
                    Call HandleEclipse(sJSONText, CurrentPool)

                Case enPool.ozcoin
                    Call HandleOzCoin(sJSONText)

                Case enPool.p2pool1, enPool.p2pool2, enPool.p2pool3, enPool.p2pool4
                    Call HandleP2Pool(sJSONText, CurrentPool)

                Case enPool.bitminter1, enPool.bitminter2
                    Call HandleBitMinter(sJSONText, CurrentPool)

                Case enPool.btcguild
                    Call HandleBTCGuild(sJSONText)

                Case enPool.slush
                    Call HandleSlush(sJSONText)

                Case enPool.multipool1
                    Call HandleMultipool(sJSONText)

                Case enPool.blockchaininfo, enPool.blockchaininfo2, enPool.blockchaininfo3
                    Call HandleBlockChainInfo(sJSONText, CurrentPool)

                Case enPool.scryptguild1
                    Call HandleScryptGuild(sJSONText)

                Case enPool.eligius1, enPool.eligius2, enPool.eligius3, enPool.eligius4, enPool.eligius5, enPool.eligius6
                    Call HandleEligius(sJSONText, CurrentPool)

                Case enPool.ltcrabbit1, enPool.ltcrabbit2, enPool.ltcrabbit3
                    Call HandleLTCRabbit(sJSONText, CurrentPool)

                Case Else
                    Throw New Exception("Internal error: ProcessJSON called with unspecified parm.")

            End Select
        Catch ex As Exception When bErrorHandle = True
            'nothing, all handled elsewhere
        Finally
            colDBOpenList.Remove(CurrentPool.ToString)

            Debug.Print(Now.ToString & ": Removed " & CurrentPool.ToString & " (count = " & colDBOpenList.Count & ")")

            If colDBOpenList.Count = 0 Then
                If cnDB.State <> ConnectionState.Closed Then
                    cnDB.Close()
                End If
            End If

            My.Application.DoEvents()
        End Try

    End Sub

    Private Sub HandleLTCRabbit(ByVal sJSONText As String, ByVal pool As enPool)

        Dim j, jp1 As Newtonsoft.Json.Linq.JObject
        Dim ja As Newtonsoft.Json.Linq.JArray
        Dim dr As DataRow
        Dim pd As clsPoolData
        Dim dHashRate As Double
        Dim bDebugPoint As Byte
        Dim wc As System.Net.WebClient
        Dim x As Integer

        Try
            Select Case pool
                Case enPool.ltcrabbit1  'user stats
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("LTCRabbit1: " & sJSONText)

                        bDebugPoint = 1

                        pd = PoolData(enPool.ltcrabbit1)

                        For Each jp1 In j.Property("getuserstatus").ToList
                            dHashRate = jp1.Value(Of Double)("hashrate") / 1000

                            Me.txtLTCRabbitUserHash.Text = FormatHashRate(dHashRate)

                            If String.IsNullOrEmpty(jp1.Value(Of String)("balance")) = False Then
                                Me.txtLTCRabbitConfirmedLTC.Text = Format(jp1.Value(Of Double)("balance"), "###,###,##0.##########")
                            Else
                                Me.txtLTCRabbitConfirmedLTC.Text = "0.0"
                            End If

                            If Me.chkConfigStoreDBStatistics.Checked = True Then
                                cmPayout.Parameters("@pool").Value = pd.sPoolName
                                cmPayout.Parameters("@ConfirmedBTC").Value = Double.Parse(Me.txtLTCRabbitConfirmedLTC.Text)
                                cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                                cmPayout.Parameters("@EstimatedBTC").Value = DBNull.Value
                                cmPayout.Parameters("@PaidBTC").Value = DBNull.Value
                                cmPayout.ExecuteNonQuery()
                            End If
                        Next

                        pd.dScryptTotalHashRate = dHashRate

                        Call ShowTotalHashRate(False)
                    Catch ex As Exception When bErrorHandle = True
                        Me.txtLTCRabbitUserHash.Text = "PJ:API ERROR1"

                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri("https://www.ltcrabbit.com/index.php?page=api&action=public"), enPool.ltcrabbit2)

                Case enPool.ltcrabbit2  'pool stats
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("LTCRabbit2: " & sJSONText)

                        bDebugPoint = 1

                        pd = PoolData(enPool.ltcrabbit1)

                        Me.txtLTCRabbitPoolhash.Text = FormatHashRate(j.Value(Of Double)("hashrate") / 1000)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                            cmHashRates.Parameters("@HashType").Value = "Pool"
                            cmHashRates.Parameters("@HashTotal").Value = j.Value(Of Double)("hashrate") / 1000
                            cmHashRates.ExecuteNonQuery()
                        End If

                    Catch ex As Exception When bErrorHandle = True
                        Me.txtLTCRabbitUserHash.Text = "PJ:API ERROR2"

                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri("https://www.ltcrabbit.com/index.php?page=api&action=getuserworkers&api_key=" & Me.txtLTCRabbitAPIKey.Text), enPool.ltcrabbit3)

                Case enPool.ltcrabbit3  'worker stats                 
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("LTCRabbit3: " & sJSONText)

                        bDebugPoint = 1

                        pd = PoolData(enPool.ltcrabbit1)

                        pd.ds.Tables(0).Clear()

                        For Each ja In j.Property("getuserworkers").ToList
                            For Each jp2 In ja
                                dr = pd.ds.Tables(0).NewRow

                                dr.Item("Worker") = jp2.Value(Of String)("username")
                                dr.Item("Hashrate/Avg") = FormatHashRate(jp2.Value(Of Double)("hashrate") / 1000) & " / " & FormatHashRate(ProcessWorkerData(pd, jp2.Value(Of String)("username"), jp2.Value(Of Double)("hashrate") / 1000))

                                If jp2.Value(Of Integer)("active") = 0 Then
                                    dr.Item("Active") = "No"
                                Else
                                    dr.Item("Active") = "Yes"
                                End If

                                pd.ds.Tables(0).Rows.Add(dr)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName
                                    cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                    cmWorkHashRates.Parameters("@Hashrate").Value = jp2.Value(Of Double)("hashrate")
                                    cmWorkHashRates.ExecuteNonQuery()
                                End If
                            Next
                        Next

                        Call CheckForIdleWorkers(pd)

                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, "As of " & Now.ToString)

                    Catch ex As Exception When bErrorHandle = True
                        Me.txtLTCRabbitUserHash.Text = "PJ:API ERROR3"

                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

            End Select
        Catch ex As Exception When bErrorHandle = True
            Select Case pool
                Case enPool.ltcrabbit1    'user hashrate
                    Me.txtLTCRabbitUserHash.Text = "PJ:API ERROR1"

                Case enPool.ltcrabbit2    'pool hashrate
                    Me.txtltcrabbituserhash.Text = "PJ:API ERROR2"

                Case enPool.ltcrabbit3    'user payout info
                    Me.txtltcrabbituserhash.Text = "PJ:API ERROR3"

            End Select

            Me.ToolTip1.SetToolTip(Me.txtltcrabbituserhash, "An error occurred when processing the output from this pool.  DBPx=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try

    End Sub

    Private Sub HandleEligius(ByVal sJSONText As String, ByVal pool As enPool)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim ja As Newtonsoft.Json.Linq.JArray
        Dim dr As DataRow
        Dim iShares As UInt64
        Dim pd As clsPoolData
        Dim dTemp, dHashTemp, dHashTotal As Double
        Dim bDebugPoint As Byte
        Dim wc As System.Net.WebClient
        Dim PayoutQueue() As String
        Dim x As Integer
        Dim sbTemp As System.Text.StringBuilder
        Dim cmAny As OleDb.OleDbCommand
        Dim iAverage, iActual As UInt32
        Dim bRound1, bRound2, bRound3 As Boolean
        Dim sTemp As String

        Try
            pd = PoolData(enPool.eligius1)

            If pd.oData1 Is Nothing Then
                bRound1 = True
            ElseIf pd.oData1 = Me.txtEligiusBTCAddy2.Text Then
                bRound2 = True
            ElseIf pd.oData1 = Me.txtEligiusBTCAddy3.Text Then
                bRound3 = True
            End If

            Select Case pool
                Case enPool.eligius1    'user hashrate
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Eligius1: " & sJSONText)

                        bDebugPoint = 1

                        If bRound1 = True Then
                            pd.ds.Tables(0).Clear()
                        Else
                            'add blank line
                            dr = pd.ds.Tables(0).NewRow
                            pd.ds.Tables(0).Rows.Add(dr)
                        End If

                        For Each jp1 In j.Property("output").ToList
                            dr = pd.ds.Tables(0).NewRow

                            For Each jp2 In jp1.Property("av43200").ToList    '12 hours
                                If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True Then
                                    dr.Item("Worker") = jp1.Value(Of String)("username").Replace(Me.txtEligiusBTCAddress.Text, "default")
                                Else
                                    dr.Item("Worker") = jp1.Value(Of String)("username")
                                End If

                                dHashTemp = Double.Parse(jp2.Value(Of String)("numeric")) / 1000000    'uses raw hashrate, not in MH/s or KH/s

                                dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp)
                                dr.Item("Sharecount") = jp2.Value(Of String)("share_count")
                                dr.Item("Period") = jp2.Value(Of String)("name")

                                pd.ds.Tables(0).Rows.Add(dr)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName & ": " & jp2.Value(Of String)("name")
                                    cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                    cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                    cmWorkHashRates.ExecuteNonQuery()
                                End If
                            Next

                            dr = pd.ds.Tables(0).NewRow

                            For Each jp2 In jp1.Property("av10800").ToList    '3 hours
                                If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True Then
                                    dr.Item("Worker") = jp1.Value(Of String)("username").Replace(Me.txtEligiusBTCAddress.Text, "default")
                                Else
                                    dr.Item("Worker") = jp1.Value(Of String)("username")
                                End If

                                dHashTemp = Double.Parse(jp2.Value(Of String)("numeric")) / 1000000    'uses raw hashrate, not in MH/s or KH/s

                                dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp)
                                dr.Item("Sharecount") = jp2.Value(Of String)("share_count")

                                'count 3 hour period only (that's what's used on the website)
                                iShares += UInt64.Parse(jp2.Value(Of String)("share_count"))
                                dHashTotal += dHashTemp

                                dr.Item("Period") = jp2.Value(Of String)("name")

                                pd.ds.Tables(0).Rows.Add(dr)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName & ": " & jp2.Value(Of String)("name")
                                    cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                    cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                    cmWorkHashRates.ExecuteNonQuery()
                                End If
                            Next

                            dr = pd.ds.Tables(0).NewRow

                            For Each jp2 In jp1.Property("av1350").ToList    '22.5 minutes
                                If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True Then
                                    dr.Item("Worker") = jp1.Value(Of String)("username").Replace(Me.txtEligiusBTCAddress.Text, "default")
                                Else
                                    dr.Item("Worker") = jp1.Value(Of String)("username")
                                End If

                                dHashTemp = Double.Parse(jp2.Value(Of String)("numeric")) / 1000000    'uses raw hashrate, not in MH/s or KH/s

                                dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp)
                                dr.Item("Sharecount") = jp2.Value(Of String)("share_count")
                                dr.Item("Period") = jp2.Value(Of String)("name")

                                pd.ds.Tables(0).Rows.Add(dr)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName & ": " & jp2.Value(Of String)("name")
                                    cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                    cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                    cmWorkHashRates.ExecuteNonQuery()
                                End If
                            Next

                            dr = pd.ds.Tables(0).NewRow

                            For Each jp2 In jp1.Property("av256").ToList    '256 seconds
                                If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True Then
                                    dr.Item("Worker") = jp1.Value(Of String)("username").Replace(Me.txtEligiusBTCAddress.Text, "default")
                                Else
                                    dr.Item("Worker") = jp1.Value(Of String)("username")
                                End If

                                dHashTemp = Double.Parse(jp2.Value(Of String)("numeric")) / 1000000    'uses raw hashrate, not in MH/s or KH/s

                                dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp) & " / " & FormatHashRate(ProcessWorkerData(pd, jp1.Value(Of String)("username"), dHashTemp))
                                dr.Item("Sharecount") = jp2.Value(Of String)("share_count")
                                dr.Item("Period") = jp2.Value(Of String)("name")

                                pd.ds.Tables(0).Rows.Add(dr)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName & ": " & jp2.Value(Of String)("name")
                                    cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                    cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                    cmWorkHashRates.ExecuteNonQuery()
                                End If
                            Next

                            dr = pd.ds.Tables(0).NewRow

                            For Each jp2 In jp1.Property("av128").ToList    '128 seconds
                                If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True Then
                                    dr.Item("Worker") = jp1.Value(Of String)("username").Replace(Me.txtEligiusBTCAddress.Text, "default")
                                Else
                                    dr.Item("Worker") = jp1.Value(Of String)("username")
                                End If

                                dHashTemp = Double.Parse(jp2.Value(Of String)("numeric")) / 1000000    'uses raw hashrate, not in MH/s or KH/s

                                dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp)
                                dr.Item("Sharecount") = jp2.Value(Of String)("share_count")
                                dr.Item("Period") = jp2.Value(Of String)("name")

                                pd.ds.Tables(0).Rows.Add(dr)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName & ": " & jp2.Value(Of String)("name")
                                    cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                    cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                    cmWorkHashRates.ExecuteNonQuery()
                                End If
                            Next
                        Next

                        If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# AndAlso iShares <> pd.iYourTotalShares Then
                            If bRound1 = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True OrElse _
                                bRound2 = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True OrElse bRound3 = True Then

                                cmShareCounts.Parameters("@pool").Value = pd.sPoolName & ": " & "3 hours"
                                cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                                cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                                cmShareCounts.ExecuteNonQuery()
                            End If
                        End If

                        If bRound1 = True Then
                            pd.iYourTotalShares = iShares
                        Else
                            pd.iYourTotalShares += iShares
                        End If

                        pd.dLastShareTime = Now

                        If bRound1 = True Then
                            pd.dSHA256TotalHashRate = dHashTotal
                        Else
                            pd.dSHA256TotalHashRate += dHashTotal
                        End If

                        Me.txtEligiusUserHash.Text = FormatHashRate(pd.dSHA256TotalHashRate)

                        Call ShowTotalHashRate(False)
                        Call CheckForIdleWorkers(pd)

                    Catch ex As Exception When bErrorHandle = True
                        Me.txtEligiusUserHash.Text = "PJ:API ERROR1"

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                    'this way if pt1 errors out, we can try another part anyhow
                    If bRound1 = True Then
                        'pool hashrate -- only necessary on round1
                        wc = New System.Net.WebClient
                        AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                        wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=gethashrate"), enPool.eligius2)
                    Else
                        If bRound2 = True Then
                            wc = New System.Net.WebClient
                            AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                            wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=getuserstat&username=" & Me.txtEligiusBTCAddy2.Text), enPool.eligius3)
                        End If

                        If bRound3 = True Then
                            wc = New System.Net.WebClient
                            AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                            wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=getuserstat&username=" & Me.txtEligiusBTCAddy3.Text), enPool.eligius3)
                        End If
                    End If

                Case enPool.eligius2    'pool hashrate
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Eligius2: " & sJSONText)

                        bDebugPoint = 1

                        For Each jp1 In j.Property("output").ToList
                            For Each jp2 In jp1.Property("av256").ToList    '256 seconds
                                dHashTemp = Double.Parse(jp2.Value(Of String)("numeric")) / 1000000    'uses raw hashrate, not in MH/s or KH/s

                                Me.txtEligiusPoolHash256.Text = FormatHashRate(dHashTemp)

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                                    cmHashRates.Parameters("@HashType").Value = "Pool"
                                    cmHashRates.Parameters("@HashTotal").Value = dHashTemp
                                    cmHashRates.ExecuteNonQuery()
                                End If
                            Next
                        Next
                    Catch ex As Exception When bErrorHandle = True
                        Me.txtEligiusUserHash.Text = "PJ:API ERROR2"

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=getuserstat&username=" & Me.txtEligiusBTCAddress.Text), enPool.eligius3)

                Case enPool.eligius3    'user payout info
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Eligius3: " & sJSONText)

                        bDebugPoint = 1

                        For Each jp1 In j.Property("output").ToList
                            If jp1.Value(Of String)("lbal") <> "N/A" Then
                                dTemp = jp1.Value(Of Double)("lbal") / 100000000

                                If bRound1 = True Then
                                    Me.txtEligiusBalanceLastBlock.Text = Format(dTemp, "###,##0.##########")

                                    pd.oData2 = dTemp

                                    Me.ToolTip1.SetToolTip(Me.txtEligiusBalanceLastBlock, "1: " & Me.txtEligiusBalanceLastBlock.Text)
                                Else
                                    Me.txtEligiusBalanceLastBlock.Text = Format(dTemp + pd.oData2, "###,##0.##########")

                                    pd.oData2 += dTemp

                                    sTemp = Me.ToolTip1.GetToolTip(Me.txtEligiusBalanceLastBlock)

                                    If bRound2 = True Then
                                        Me.ToolTip1.SetToolTip(Me.txtEligiusBalanceLastBlock, sTemp & vbCrLf & "2: " & Format(dTemp, "###,##0.##########"))
                                    Else
                                        Me.ToolTip1.SetToolTip(Me.txtEligiusBalanceLastBlock, sTemp & vbCrLf & "3: " & Format(dTemp, "###,##0.##########"))
                                    End If
                                End If
                            Else
                                Me.txtEligiusBalanceLastBlock.Text = "N/A"
                            End If

                            dTemp = jp1.Value(Of Double)("bal") / 100000000

                            If bRound1 = True Then
                                Me.txtEligiusEstimatedBalance.Text = Format(dTemp, "###,##0.##########")

                                pd.oData3 = dTemp

                                Me.ToolTip1.SetToolTip(Me.txtEligiusEstimatedBalance, "1: " & Me.txtEligiusEstimatedBalance.Text)
                            Else
                                Me.txtEligiusEstimatedBalance.Text = Format(dTemp + pd.oData3, "###,##0.##########")

                                pd.oData3 += dTemp

                                sTemp = Me.ToolTip1.GetToolTip(Me.txtEligiusEstimatedBalance)

                                If bRound2 = True Then
                                    Me.ToolTip1.SetToolTip(Me.txtEligiusEstimatedBalance, sTemp & vbCrLf & "2: " & Format(dTemp, "###,##0.##########"))
                                Else
                                    Me.ToolTip1.SetToolTip(Me.txtEligiusEstimatedBalance, sTemp & vbCrLf & "3: " & Format(dTemp, "###,##0.##########"))
                                End If
                            End If

                            If Me.chkConfigStoreDBStatistics.Checked = True Then
                                If bRound1 = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = True Or _
                                    bRound2 = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = True OrElse bRound3 = True Then

                                    cmPayout.Parameters("@pool").Value = pd.sPoolName

                                    If jp1.Value(Of String)("lbal") <> "N/A" Then
                                        cmPayout.Parameters("@ConfirmedBTC").Value = pd.oData2
                                    Else
                                        cmPayout.Parameters("@ConfirmedBTC").Value = DBNull.Value
                                    End If

                                    cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                                    cmPayout.Parameters("@EstimatedBTC").Value = pd.oData3
                                    cmPayout.Parameters("@PaidBTC").Value = jp1.Value(Of Double)("everpaid") / 100000000
                                    cmPayout.ExecuteNonQuery()
                                End If
                            End If
                        Next
                    Catch ex As Exception When bErrorHandle = True
                        Me.txtEligiusUserHash.Text = "PJ:API ERROR3"

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                    If bRound1 = True Then
                        wc = New System.Net.WebClient
                        AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                        wc.DownloadStringAsync(New System.Uri("http://eligius.st/~luke-jr/raw/7/payout_queue.txt"), enPool.eligius4)
                    End If

                    If bRound1 = True Then
                        If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = False Then
                            'start round2
                            pd.oData1 = Me.txtEligiusBTCAddy2.Text

                            wc = New System.Net.WebClient
                            AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                            wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=gethashrate&username=" & Me.txtEligiusBTCAddy2.Text), enPool.eligius1)
                        Else
                            pd.oData1 = Nothing
                        End If
                    End If

                    If bRound2 = True Then
                        If String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = False Then
                            'start round3
                            pd.oData1 = Me.txtEligiusBTCAddy3.Text

                            wc = New System.Net.WebClient
                            AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                            wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=gethashrate&username=" & Me.txtEligiusBTCAddy3.Text), enPool.eligius1)
                        Else
                            pd.oData1 = Nothing
                        End If
                    End If

                    If bRound3 = True Then
                        pd.oData1 = Nothing
                    End If

                Case enPool.eligius4    'payout queue
                    Try
                        'Debug.Print("Eligius4: " & sJSONText)

                        bDebugPoint = 1

                        If sJSONText.Length = 0 Then
                            Me.txtEligiusPayoutQueuePositions.Text = "not currently avail"
                        Else
                            PayoutQueue = sJSONText.Split(vbLf)

                            sbTemp = New System.Text.StringBuilder

                            For x = 0 To PayoutQueue.Count - 1
                                If PayoutQueue(x) = Me.txtEligiusBTCAddress.Text Then
                                    If sbTemp.Length <> 0 Then
                                        sbTemp.Append(", ")
                                    Else
                                        sbTemp.Append("1: ")
                                    End If

                                    sbTemp.Append(x + 1)
                                End If
                            Next

                            If String.IsNullOrEmpty(Me.txtEligiusBTCAddy2.Text) = False Then
                                For x = 0 To PayoutQueue.Count - 1
                                    If PayoutQueue(x) = Me.txtEligiusBTCAddy2.Text Then
                                        If sbTemp.Length <> 0 Then
                                            sbTemp.Append(", ")
                                        Else
                                            sbTemp.Append("/2: ")
                                        End If

                                        sbTemp.Append(x + 1)
                                    End If
                                Next
                            End If



                            If String.IsNullOrEmpty(Me.txtEligiusBTCAddy3.Text) = False Then
                                For x = 0 To PayoutQueue.Count - 1
                                    If PayoutQueue(x) = Me.txtEligiusBTCAddy3.Text Then
                                        If sbTemp.Length <> 0 Then
                                            sbTemp.Append(", ")
                                        Else
                                            sbTemp.Append("/3: ")
                                        End If

                                        sbTemp.Append(x + 1)
                                    End If
                                Next
                            End If

                            If sbTemp.Length = 0 Then
                                Me.txtEligiusPayoutQueuePositions.Text = "not found"
                            Else
                                Me.txtEligiusPayoutQueuePositions.Text = sbTemp.ToString
                            End If
                        End If

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "As of " & Now.ToString)

                    Catch ex As Exception When bErrorHandle = True
                        Me.txtEligiusUserHash.Text = "PJ:API ERROR4"

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                Case enPool.eligius5    'block luck - db unavailable, just process 10 blocks to get luck of last 10
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Eligius5: " & sJSONText)

                        'difficulty * 2^32 / hashrate
                        For Each jp1 In j.Property("output").ToList
                            For Each ja In jp1.Property("rows")
                                For Each jp2 In ja
                                    If jp2.Value(Of Double)("luck") <> 0 Then
                                        iAverage += jp2.Value(Of Double)("network_difficulty") * UInt32.MaxValue / jp2.Value(Of Double)("hashrate")
                                        iActual += jp2.Value(Of Integer)("duration")
                                    End If
                                Next
                            Next
                        Next

                        Me.txtEligiusLast10BlockLuck.Text = Format(iAverage / iActual, "###,##0.##%")

                    Catch ex As Exception When bErrorHandle = True
                        Me.txtEligiusUserHash.Text = "PJ:API ERROR5"

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try

                Case enPool.eligius6    'block luck - db available, update it with any new data then display stats
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Eligius6: " & sJSONText)

                        pd = PoolData(enPool.eligius1)

                        'difficulty * 2^32 / hashrate

                        'update the database
                        For Each jp1 In j.Property("output").ToList
                            For Each ja In jp1.Property("rows")
                                For Each jp2 In ja
                                    With cmLuck
                                        .Parameters("@Pool").Value = pd.sPoolName
                                        .Parameters("@Luck").Value = jp2.Value(Of Double)("luck")
                                        .Parameters("@Height").Value = jp2.Value(Of Integer)("height")

                                        If jp2.Value(Of Double)("luck") <> 0 Then
                                            .Parameters("@AvgSolveTime").Value = jp2.Value(Of Double)("network_difficulty") * UInt32.MaxValue / jp2.Value(Of Double)("hashrate")
                                            .Parameters("@ActualSolveTime").Value = jp2.Value(Of Integer)("duration")
                                        Else
                                            .Parameters("@AvgSolveTime").Value = 0
                                            .Parameters("@ActualSolveTime").Value = 0
                                        End If

                                        .Parameters("@BlockTimeStamp").Value = DateFrom1970(jp2.Value(Of String)("roundend"))
                                        .ExecuteNonQuery()
                                    End With
                                Next
                            Next
                        Next

                        'calculate luck
                        '10 blocks
                        cmAny = New OleDb.OleDbCommand
                        cmAny.Connection = cnDB
                        cmAny.CommandType = CommandType.Text
                        cmAny.CommandText = "SELECT sum(AvgsolveTime) / sum(ActualSolveTime) " & _
                                            "FROM Luck " & _
                                            "where Height >= " & _
                                            "(select min(Height) from " & _
                                            "(SELECT top 10 Height from Luck where Height <> 0 order by blocktimestamp desc));"

                        Me.txtEligiusLast10BlockLuck.Text = Format(cmAny.ExecuteScalar, "###,##0.##%")

                        '12 hours
                        cmAny.CommandText = "Select Sum(Luck.AvgSolveTime) / Sum(Luck.ActualSolveTime) " & _
                                            "FROM Luck " & _
                                            "Where Luck.Pool = '" & pd.sPoolName & "' and BlockTimeStamp > #" & Now.ToUniversalTime.AddHours(-12) & "#;"

                        Me.txtEligiusLast12HourLuck.Text = Format(cmAny.ExecuteScalar, "###,##0.##%")

                        '24 hours
                        cmAny.CommandText = "Select Sum(Luck.AvgSolveTime) / Sum(Luck.ActualSolveTime) " & _
                                            "FROM Luck " & _
                                            "Where Luck.Pool = '" & pd.sPoolName & "' and BlockTimeStamp > #" & Now.ToUniversalTime.AddHours(-24) & "#;"

                        Me.txtEligiusLast24HourLuck.Text = Format(cmAny.ExecuteScalar, "###,##0.##%")

                        '7 days
                        cmAny.CommandText = "Select Sum(Luck.AvgSolveTime) / Sum(Luck.ActualSolveTime) " & _
                                            "FROM Luck " & _
                                            "Where Luck.Pool = '" & pd.sPoolName & "' and BlockTimeStamp > #" & Now.ToUniversalTime.AddDays(-7) & "#;"

                        Me.txtEligiusLast7DaysLuck.Text = Format(cmAny.ExecuteScalar, "###,##0.##%")

                        '30 days
                        cmAny.CommandText = "Select Sum(Luck.AvgSolveTime) / Sum(Luck.ActualSolveTime) " & _
                                            "FROM Luck " & _
                                            "Where Luck.Pool = '" & pd.sPoolName & "' and BlockTimeStamp > #" & Now.ToUniversalTime.AddDays(-30) & "#;"

                        Me.txtEligiusLast30DaysLuck.Text = Format(cmAny.ExecuteScalar, "###,##0.##%")

                        '90 days
                        cmAny.CommandText = "Select Sum(Luck.AvgSolveTime) / Sum(Luck.ActualSolveTime) " & _
                                            "FROM Luck " & _
                                            "Where Luck.Pool = '" & pd.sPoolName & "' and BlockTimeStamp > #" & Now.ToUniversalTime.AddDays(-90) & "#;"

                        Me.txtEligiusLast90DaysLuck.Text = Format(cmAny.ExecuteScalar, "###,##0.##%")
                    Catch ex As Exception When bErrorHandle = True
                        Me.txtEligiusUserHash.Text = "PJ:API ERROR6"

                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
                    End Try
            End Select

        Catch ex As Exception When bErrorHandle = True
            Select Case pool
                Case enPool.eligius1    'user hashrate
                    Me.txtEligiusUserHash.Text = "PJ:API ERROR1"

                Case enPool.eligius2    'pool hashrate
                    Me.txtEligiusUserHash.Text = "PJ:API ERROR2"

                Case enPool.eligius3    'user payout info
                    Me.txtEligiusUserHash.Text = "PJ:API ERROR3"

                Case enPool.eligius4    'payout queue
                    Me.txtEligiusUserHash.Text = "PJ:API ERROR4"

            End Select

            Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, "An error occurred when processing the output from this pool.  DBPx=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try

    End Sub

    Private Sub Handle50BTC(ByVal sJSONText As String)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim dr As DataRow
        Dim iShares As Integer
        Dim t As Integer
        Dim pd As clsPoolData
        Dim dHashTemp As Double
        Dim bDebugPoint As Byte

        Try
            If sJSONText.Contains("Token is invalid! Please renew token on your settings page.") = True Then
                Me.txt50UserHashRate.Text = "CHECK API KEY"

                Exit Sub
            End If

            j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

            bDebugPoint = 1

            pd = PoolData(enPool.f50btc)

            t = 0

            For Each jp1 In j.Property("user").ToList
                Me.txt50ConfirmedBTC.Text = jp1.Value(Of String)("confirmed_rewards")
                Me.txt50CompletedPayouts.Text = jp1.Value(Of String)("payouts")

                If Double.TryParse(jp1.Value(Of String)("hash_rate"), dHashTemp) = True Then
                    dHashTemp *= 1000000
                    pd.dSHA256TotalHashRate = dHashTemp
                Else
                    pd.dSHA256TotalHashRate = 0
                End If

                Me.txt50UserHashRate.Text = FormatHashRate(dHashTemp)
            Next

            If Me.chkConfigStoreDBStatistics.Checked = True Then
                cmHashRates.Parameters("@pool").Value = pd.sPoolName
                cmHashRates.Parameters("@hashtype").Value = "user"
                cmHashRates.Parameters("@hashtotal").Value = pd.dSHA256TotalHashRate
                cmHashRates.ExecuteNonQuery()

                cmPayout.Parameters("@pool").Value = pd.sPoolName
                cmPayout.Parameters("@ConfirmedBTC").Value = Val(Me.txt50ConfirmedBTC.Text)
                cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                cmPayout.Parameters("@EstimatedBTC").Value = DBNull.Value
                cmPayout.Parameters("@PaidBTC").Value = Val(Me.txt50CompletedPayouts.Text)
                cmPayout.ExecuteNonQuery()
            End If

            pd.ds.Tables(0).Clear()

            For Each jp1 In j.Property("workers").ToList
                For Each mhr In jp1.Properties
                    For Each jp2 In mhr
                        dr = pd.ds.Tables(0).NewRow

                        If pd.ds.Tables(0).Rows.Count > 0 Then
                            'add blank row
                            pd.ds.Tables(0).Rows.Add(dr)

                            dr = pd.ds.Tables(0).NewRow
                        End If

                        dr.Item("Worker") = jp2.Value(Of String)("worker_name")
                        dr.Item("Total Shares") = jp2.Value(Of Integer)("total_shares")
                        dr.Item("Last Share") = Format(DateFrom1970(jp2.Value(Of Integer)("last_share")).ToLocalTime, "MM/dd/yyyy HH:mm:ss")

                        iShares += Integer.Parse(jp2.Value(Of String)("total_shares"))

                        pd.ds.Tables(0).Rows.Add(dr)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmWorkHashRates.Parameters("@pool").Value = "50BTC"
                            cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                            cmWorkHashRates.Parameters("@Hashrate").Value = 0
                            cmWorkHashRates.ExecuteNonQuery()
                        End If
                    Next
                Next
            Next

            If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# Then
                cmShareCounts.Parameters("@pool").Value = "50BTC"
                cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                cmShareCounts.ExecuteNonQuery()
            End If

            pd.iYourTotalShares = iShares
            pd.dLastShareTime = Now

            Call ShowTotalHashRate(False)
            Call CheckForIdleWorkers(pd)

            Me.ToolTip1.SetToolTip(Me.txt50UserHashRate, "As of " & Now.ToString)
        Catch ex As Exception When bErrorHandle = True
            Me.txt50UserHashRate.Text = "PJ:API ERROR"

            Me.ToolTip1.SetToolTip(Me.txt50UserHashRate, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try

    End Sub

    Private Sub HandleEclipse(ByVal sJSONText As String, ByVal pool As enPool)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim ja As Newtonsoft.Json.Linq.JArray
        Dim dr As DataRow
        Dim iShares As Integer
        Dim sTemp As String
        Dim dTemp As Date
        Dim pd As clsPoolData
        Dim dHashRate, dHashTemp As Double
        Dim tsTemp As TimeSpan
        Dim bDebugPoint As Byte
        Dim x As Integer

        Try
            'two calls required for eclipse
            Select Case pool
                Case enPool.eclipse1
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    bDebugPoint = 1

                    pd = PoolData(enPool.eclipse1)

                    Me.txtEclPoolHashrate.Text = j.Value(Of String)("hashrate")
                    Me.txtEclBTCRoundShares.Text = j.Value(Of String)("round_shares")

                    sTemp = j.Value(Of String)("round_duration")

                    If sTemp.Contains("d") = False Then
                        tsTemp = New TimeSpan(sTemp.Substring(0, 2), sTemp.Substring(3, 2), sTemp.Substring(6, 2))
                    Else
                        x = InStr(sTemp, "d") - 1

                        tsTemp = New TimeSpan(sTemp.Substring(0, x), sTemp.Substring(x + 2, 2), sTemp.Substring(x + 5, 2), sTemp.Substring(x + 8, 2))
                    End If

                    Me.txtEclBTCRoundDuration.Text = Me.FormatTimeSpan(tsTemp)
                    pd.dLastBlockTime = Date.Now.Subtract(tsTemp)
                    Me.txtEclAvgSharesBlock.Text = j.Value(Of String)("avg_shares_block")

                    If pd.dRoundShares <> 0 AndAlso Double.Parse(Me.txtEclBTCRoundShares.Text) < pd.dRoundShares Then
                        'Me.lblEclNewBlock.Visible = True
                        Debug.Print("Eclipse: " & Date.Now.ToString & " new block found")

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmBlocks.Parameters("@Pool").Value = pd.sPoolName
                            cmBlocks.ExecuteNonQuery()
                        End If
                    End If

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "Pool"

                        If Double.TryParse(Me.txtEclPoolHashrate.Text.Substring(0, InStr(Me.txtEclPoolHashrate.Text, " ") - 1), dHashTemp) = True Then
                            Select Case Me.txtEclPoolHashrate.Text.Substring(InStr(Me.txtEclPoolHashrate.Text, " "))
                                Case "GH/s"
                                    dHashTemp *= 1000

                                Case "TH/s"
                                    dHashTemp *= 1000000

                                Case "EH/s"
                                    dHashTemp *= 1000000000

                            End Select
                        Else
                            dHashTemp = 0
                        End If

                        cmHashRates.Parameters("@HashTotal").Value = dHashTemp
                        cmHashRates.ExecuteNonQuery()
                    End If

                    pd.dRoundShares = Double.Parse(Me.txtEclBTCRoundShares.Text)

                    'Me.lblEclLastBlock.Text = "Last block around " & pd.dLastBlockTime.ToLocalTime

                Case enPool.eclipse2
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    bDebugPoint = 1

                    pd = PoolData(enPool.eclipse1)

                    pd.ds.Tables(0).Clear()

                    For Each jp1 In j.Property("data").ToList
                        For Each jp2 In jp1.Property("user").ToList
                            If jp2.Value(Of String)("confirmed_rewards") Is Nothing Then
                                Me.txtEclUserHashRate.Text = "CHECK API KEY"

                                Exit Sub
                            End If

                            Me.txtEclConfirmedBTC.Text = jp2.Value(Of String)("confirmed_rewards")
                            Me.txtEclUnconfirmedBTC.Text = jp2.Value(Of String)("unconfirmed_rewards")
                            Me.txtEclEstimatedRewards.Text = Format(Val(jp2.Value(Of String)("estimated_rewards")), "0.###########")
                            Me.txtEclTotalPayout.Text = jp2.Value(Of String)("total_payout")
                            Me.txtEclBlocksFound.Text = jp2.Value(Of String)("blocks_found")
                        Next
                    Next

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmPayout.Parameters("@Pool").Value = pd.sPoolName
                        cmPayout.Parameters("@ConfirmedBTC").Value = Val(Me.txtEclConfirmedBTC.Text)
                        cmPayout.Parameters("@UnconfirmedBTC").Value = Val(Me.txtEclUnconfirmedBTC.Text)
                        cmPayout.Parameters("@EstimatedBTC").Value = Val(Me.txtEclEstimatedRewards.Text)
                        cmPayout.Parameters("@PaidBTC").Value = Val(Me.txtEclTotalPayout.Text)
                        cmPayout.ExecuteNonQuery()
                    End If

                    For Each ja In j.Property("workers").ToList
                        For Each jp1 In ja
                            dr = pd.ds.Tables(0).NewRow

                            dr.Item("Worker") = jp1.Value(Of String)("worker_name")

                            sTemp = jp1.Value(Of String)("hash_rate")

                            iShares += Integer.Parse(jp1.Value(Of String)("round_shares"))

                            'base hash rate in mega hash
                            If Double.TryParse(sTemp.Substring(0, InStr(sTemp, " ") - 1), dHashTemp) = True Then
                                Select Case sTemp.Substring(InStr(sTemp, " "))
                                    Case "MH/s"
                                        dHashRate += dHashTemp

                                    Case "GH/s"
                                        dHashTemp *= 1000
                                        dHashRate += dHashTemp

                                    Case "TH/s"
                                        dHashTemp *= 1000000
                                        dHashRate += dHashTemp

                                    Case "EH/s"
                                        dHashTemp *= 1000000000
                                        dHashRate += dHashTemp

                                End Select
                            End If

                            dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp) & " / " & FormatHashRate(ProcessWorkerData(pd, jp1.Value(Of String)("worker_name"), dHashTemp))

                            If Date.TryParse(jp1.Value(Of String)("last_activity"), dTemp) = True Then
                                sTemp = FormatTimeSpan(Date.Now.Subtract(dTemp.ToLocalTime))
                            Else
                                sTemp = "UNKNOWN"
                            End If

                            dr.Item("RShares/TShares/LShare") = jp1.Value(Of String)("round_shares") & " / " & jp1.Value(Of String)("total_shares") & " / " & sTemp

                            pd.ds.Tables(0).Rows.Add(dr)

                            If Me.chkConfigStoreDBStatistics.Checked = True Then
                                cmWorkHashRates.Parameters("@pool").Value = pd.sPoolName
                                cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                cmWorkHashRates.ExecuteNonQuery()
                            End If
                        Next
                    Next

                    pd.dSHA256TotalHashRate = dHashRate

                    Me.txtEclUserHashRate.Text = FormatHashRate(dHashRate)

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "User"
                        cmHashRates.Parameters("@HashTotal").Value = dHashRate
                        cmHashRates.ExecuteNonQuery()
                    End If

                    'add blank row
                    dr = pd.ds.Tables(0).NewRow
                    pd.ds.Tables(0).Rows.Add(dr)

                    'add share stats #1 when relevant
                    If iShares > pd.iYourTotalShares AndAlso pd.iYourTotalShares <> 0 Then
                        dr = pd.ds.Tables(0).NewRow

                        dTemp = Now

                        dr.Item(0) = "Approximately"
                        dr.Item(1) = Format((iShares - pd.iYourTotalShares) / (dTemp - pd.dLastShareTime).TotalMinutes, "0.0000")
                        dr.Item(2) = "shares/minute"

                        pd.ds.Tables(0).Rows.Add(dr)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmShareCounts.Parameters("@pool").Value = pd.sPoolName
                            cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                            cmShareCounts.Parameters("@DurationInSeconds").Value = (dTemp - pd.dLastShareTime).TotalSeconds
                            cmShareCounts.ExecuteNonQuery()
                        End If
                    End If

                    pd.iYourTotalShares = iShares
                    pd.dLastShareTime = Now

                    'add share stats #2 
                    dr = pd.ds.Tables(0).NewRow

                    dr.Item(0) = "Total shares"
                    dr.Item(1) = iShares

                    If iShares <> 0 Then
                        dr.Item(2) = Format(iShares / Val(Me.txtEclBTCRoundShares.Text), "0.000000%")
                    Else
                        dr.Item(2) = "0%"
                    End If

                    pd.ds.Tables(0).Rows.Add(dr)

                    Call ShowTotalHashRate(False)
                    Call CheckForIdleWorkers(pd)

                    Me.ToolTip1.SetToolTip(Me.txtEclUserHashRate, "As of " & Now.ToString)

            End Select
        Catch ex As Exception When bErrorHandle = True
            If pool = enPool.eclipse1 Then
                Me.txtEclUserHashRate.Text = "PJ:API ERROR1"
            Else
                Me.txtEclUserHashRate.Text = "PJ:API ERROR2"
            End If

            Me.ToolTip1.SetToolTip(Me.txtEclUserHashRate, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try

    End Sub

    Private Sub HandleOzCoin(ByVal sJSONText As String)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim dr As DataRow
        Dim iShares As Integer
        Dim sTemp As String
        Dim d, m, h As Integer
        Dim dTemp As Date
        Dim pd As clsPoolData
        Dim bDebugPoint As Byte

        Try
            j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

            bDebugPoint = 1

            Debug.Print("Ozcoin: " & sJSONText)

            pd = PoolData(enPool.ozcoin)

            pd.ds.Tables(0).Clear()

            For Each jp1 In j.Property("user").ToList
                If jp1.Value(Of String)("estimated_payout") IsNot Nothing Then
                    Me.txtOzEstimatedPayout.Text = jp1.Value(Of String)("estimated_payout")
                    Me.txtOzPendingPayoutDGM.Text = jp1.Value(Of String)("pending_payout")
                    Me.txtOzCompletedPayout.Text = jp1.Value(Of String)("completed_payout")
                    Me.txtOzPendingPayoutPPS.Text = jp1.Value(Of String)("estimated_payout_pps")

                    pd.dSHA256TotalHashRate = Double.Parse(jp1.Value(Of String)("hashrate_raw"))

                    Me.txtOzUserHashRate.Text = FormatHashRate(pd.dSHA256TotalHashRate)

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "User"

                        If jp1.Value(Of String)("hashrate_raw") IsNot Nothing Then
                            cmHashRates.Parameters("@HashTotal").Value = jp1.Value(Of Double)("hashrate_raw")
                        Else
                            cmHashRates.Parameters("@HashTotal").Value = 0
                        End If

                        cmHashRates.ExecuteNonQuery()

                        cmPayout.Parameters("@Pool").Value = pd.sPoolName
                        cmPayout.Parameters("@ConfirmedBTC").Value = Val(Me.txtOzPendingPayoutDGM.Text) + Val(Me.txtOzPendingPayoutPPS.Text)
                        cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                        cmPayout.Parameters("@EstimatedBTC").Value = Val(Me.txtOzEstimatedPayout.Text)
                        cmPayout.Parameters("@PaidBTC").Value = Val(Me.txtOzCompletedPayout.Text)
                        cmPayout.ExecuteNonQuery()
                    End If
                Else
                    Me.txtOzUserHashRate.Text = "CHECK API KEY"

                    Exit Sub
                End If
            Next

            For Each jp1 In j.Property("pot").ToList
                Me.txtOzPOTPendingPayout.Text = jp1.Value(Of String)("estimated_payout_pot")
                Me.txtOZPOT_PPSEquivalent.Text = jp1.Value(Of String)("pot_total_PPSEquiv")
                Me.txtOZPOTTotalShares.Text = jp1.Value(Of String)("pot_total_Shares")
                Me.txtOZPOTHighestShare.Text = jp1.Value(Of String)("pot_round_highestShare")
            Next

            For Each jp1 In j.Property("worker").ToList
                For Each mhr In jp1.Properties
                    dr = pd.ds.Tables(0).NewRow

                    dr.Item("Worker") = mhr.Name

                    For Each jp2 In mhr
                        sTemp = jp2.Value(Of String)("current_speed").Replace(",", "")

                        dr.Item("Hashrate/Avg") = FormatHashRate(sTemp) & " / " & FormatHashRate(ProcessWorkerData(pd, dr.Item("Worker"), Double.Parse(sTemp)))
                        dr.Item("Shares/Stales/Efficiency") = jp2.Value(Of String)("valid_shares") & " / " & jp2.Value(Of String)("invalid_shares") & " / " & jp2.Value(Of String)("efficiency") & "%"

                        iShares += Integer.Parse(jp2.Value(Of String)("valid_shares"))

                        pd.ds.Tables(0).Rows.Add(dr)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName
                            cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                            cmWorkHashRates.Parameters("@Hashrate").Value = Double.Parse(jp2.Value(Of String)("current_speed"))
                            cmWorkHashRates.ExecuteNonQuery()
                        End If
                    Next
                Next
            Next

            For Each jp1 In j.Property("pool").ToList
                Me.txtOzPoolHashrate.Text = FormatHashRate(jp1.Value(Of String)("hashrate_raw"))
                Me.txtOzBTCRoundShares.Text = jp1.Value(Of String)("round_shares")
                Me.txtOzBTCEfficiency.Text = jp1.Value(Of String)("round_efficiency") & "%"
                Me.txtOzBTCRoundDuration.Text = jp1.Value(Of String)("round_duration")

                If Me.chkConfigStoreDBStatistics.Checked = True Then
                    cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                    cmHashRates.Parameters("@HashType").Value = "Pool"
                    cmHashRates.Parameters("@HashTotal").Value = jp1.Value(Of Double)("hashrate_raw")
                    cmHashRates.ExecuteNonQuery()
                End If
            Next

            If pd.dRoundShares <> 0 AndAlso Double.Parse(Me.txtOzBTCRoundShares.Text) < pd.dRoundShares Then
                'Me.lblOZNewBlock.Visible = True

                Debug.Print("Ozcoin:" & Date.Now.ToString & " new block found")

                If Me.chkConfigStoreDBStatistics.Checked = True Then
                    cmBlocks.Parameters("@Pool").Value = pd.sPoolName
                    cmBlocks.ExecuteNonQuery()
                End If
            End If

            pd.dRoundShares = Double.Parse(Me.txtOzBTCRoundShares.Text)

            sTemp = Me.txtOzBTCRoundDuration.Text

            d = InStr(sTemp, "d")
            h = InStr(sTemp, "h")
            m = InStr(sTemp, "m")

            pd.dLastBlockTime = Now.AddDays(-Integer.Parse(sTemp.Substring(0, d - 1))).AddHours(-Integer.Parse(sTemp.Substring(d + 1, h - d - 2))).AddMinutes(-Integer.Parse(sTemp.Substring(h + 1, sTemp.Length - h - 2)))

            'Me.lblOZLastBlock.Text = "Last block around " & pd.dLastBlockTime.ToLocalTime

            'add blank row
            dr = pd.ds.Tables(0).NewRow
            pd.ds.Tables(0).Rows.Add(dr)

            'add share stats #1 when relevant
            If iShares > pd.iYourTotalShares AndAlso pd.iYourTotalShares <> 0 Then
                dr = pd.ds.Tables(0).NewRow

                dTemp = Now

                dr.Item(0) = "Approximately"
                dr.Item(1) = Format((iShares - pd.iYourTotalShares) / (dTemp - pd.dLastShareTime).TotalMinutes, "0.0000")
                dr.Item(2) = "shares/minute"

                pd.ds.Tables(0).Rows.Add(dr)

                If Me.chkConfigStoreDBStatistics.Checked = True Then
                    cmShareCounts.Parameters("@Pool").Value = pd.sPoolName
                    cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                    cmShareCounts.Parameters("@DurationInSeconds").Value = (dTemp - pd.dLastShareTime).TotalSeconds
                    cmShareCounts.ExecuteNonQuery()
                End If
            End If

            pd.iYourTotalShares = iShares
            pd.dLastShareTime = Now

            'add share stats #2 
            dr = pd.ds.Tables(0).NewRow

            dr.Item(0) = "Total shares"
            dr.Item(1) = iShares

            If iShares <> 0 Then
                dr.Item(2) = Format(iShares / Double.Parse(Me.txtOzBTCRoundShares.Text), "0.0000000000%")
            Else
                dr.Item(2) = "0%"
            End If

            pd.ds.Tables(0).Rows.Add(dr)

            Call ShowTotalHashRate(False)
            Call CheckForIdleWorkers(pd)

            Me.ToolTip1.SetToolTip(Me.txtOzUserHashRate, "As of " & Now.ToString)
        Catch ex As Exception When bErrorHandle = True
            Me.txtOzUserHashRate.Text = "PJ:API ERROR"

            Me.ToolTip1.SetToolTip(Me.txtOzUserHashRate, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try
    End Sub

    Private Sub HandleP2Pool(ByVal sJSONText As String, ByVal pool As enPool)

        Dim j, jp1 As Newtonsoft.Json.Linq.JObject
        Dim ja As Newtonsoft.Json.Linq.JArray
        Dim dr As DataRow
        Dim iShares As Integer
        Dim sTemp As String
        Dim pd As clsPoolData
        Dim dHashRate, dHashTemp As Double
        Dim wc As System.Net.WebClient
        Dim bDebugPoint As Byte

        Try
            '4 calls required for p2pool
            Select Case pool
                Case enPool.p2pool1
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    Debug.Print("p2pool: " & sJSONText)

                    bDebugPoint = 1

                    pd = PoolData(enPool.p2pool1)

                    pd.ds.Tables(0).Clear()

                    Me.txtP2pUpTime.Text = FormatTimeSpan(TimeSpan.FromSeconds(j.Value(Of String)("uptime")))

                    For Each jp1 In j.Property("shares")
                        Me.txtP2pTotalShares.Text = jp1.Value(Of String)("total")
                        Me.txtP2pOrphanedShares.Text = jp1.Value(Of String)("orphan")
                        Me.txtP2pDeadShares.Text = jp1.Value(Of String)("dead")

                        iShares = Val(jp1.Value(Of String)("total"))

                        If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# Then
                            cmShareCounts.Parameters("@pool").Value = pd.sPoolName
                            cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                            cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                            cmShareCounts.ExecuteNonQuery()
                        End If

                        pd.iYourTotalShares = iShares
                        pd.dLastShareTime = Now
                    Next

                    For Each jp1 In j.Property("peers")
                        Me.txtP2pPeers.Text = jp1.Value(Of String)("incoming") & "/" & jp1.Value(Of String)("outgoing")

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmP2Pool.Parameters("@PeersIn").Value = Val(jp1.Value(Of String)("incoming"))
                            cmP2Pool.Parameters("@PeersOut").Value = Val(jp1.Value(Of String)("outgoing"))
                        End If

                        Exit For
                    Next

                    Me.txtP2pUserStaleRate.Text = Format(Val((Val(Me.txtP2pDeadShares.Text) + Val(Me.txtP2pOrphanedShares.Text)) / Val(Me.txtP2pTotalShares.Text)), "###.##%")

                    Me.txtP2pUserEfficiency.Text = Format(Val(j.Value(Of String)("efficiency")), "####.###%")

                    For Each jp1 In j.Property("miner_hash_rates").ToList
                        For Each mhr In jp1.Properties
                            dr = pd.ds.Tables(0).NewRow

                            dr.Item("Worker") = mhr.Name
                            dHashTemp = Val(mhr.Value.ToString) / 1000000  'convert to MH
                            Debug.Print("p2pool hash: " & mhr.Value.ToString)

                            If Me.chkP2PPublicPool.Checked = False Then
                                dHashRate += dHashTemp
                            Else
                                If mhr.Name.ToLower = Me.txtP2PoolBTCAddy.Text.ToLower Then
                                    dHashRate += dHashTemp
                                End If
                            End If


                            dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp) & " / " & FormatHashRate(ProcessWorkerData(pd, mhr.Name, dHashTemp))

                            pd.ds.Tables(0).Rows.Add(dr)

                            If Me.chkConfigStoreDBStatistics.Checked = True Then
                                cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName
                                cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                cmWorkHashRates.ExecuteNonQuery()
                            End If
                        Next
                    Next

                    If Me.chkP2PoolScrypt.Checked = False Then
                        pd.dSHA256TotalHashRate = dHashRate
                    Else
                        pd.dScryptTotalHashRate = dHashRate
                    End If

                    Me.txtp2pUserHash.Text = FormatHashRate(dHashRate)

                    Me.txtP2pBlockValue.Text = j.Value(Of String)("block_value")

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "User"
                        cmHashRates.Parameters("@HashTotal").Value = dHashRate
                        cmHashRates.ExecuteNonQuery()

                        If pd.oData1 IsNot Nothing AndAlso pd.oData2 IsNot Nothing Then
                            cmP2Pool.Parameters("@BlockValue").Value = Val(Me.txtP2pBlockValue.Text)
                            cmP2Pool.Parameters("@PoolDifficulty").Value = pd.oData1
                            cmP2Pool.Parameters("@PoolStaleRate").Value = pd.oData2
                            cmP2Pool.ExecuteNonQuery()
                        Else
                            Debug.Print("oData1: " & pd.oData1 & " / oData2: " & pd.oData2)
                        End If
                    End If

                    If pd.oData3 IsNot Nothing Then
                        pd.oData1 = dHashRate * 1000000 / DirectCast(pd.oData3, Double) * Val(j.Value(Of String)("block_value")) * (1 - j.Value(Of Double)("donation_proportion"))
                        Me.txtP2PIdealPayout.Text = Format(DirectCast(pd.oData1, Double), "0.######")
                    End If

                    Call ShowTotalHashRate(False)
                    Call CheckForIdleWorkers(pd)

                    pd.oData2 = Nothing
                    pd.oData3 = Nothing

                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri(Me.txtP2PoolURL.Text & "/current_payouts"), enPool.p2pool3)

                Case enPool.p2pool2
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    bDebugPoint = 1

                    pd = PoolData(enPool.p2pool1)

                    pd.oData1 = Val(j.Value(Of String)("min_difficulty"))
                    pd.oData2 = Val(j.Value(Of String)("pool_stale_prop"))
                    pd.oData3 = Val(j.Value(Of String)("pool_hash_rate"))

                    Me.txtP2pPoolDifficulty.Text = Format(Val(j.Value(Of String)("min_difficulty")), "#.##")

                    dHashTemp = Val(j.Value(Of String)("pool_hash_rate")) / 1000000

                    Me.txtP2pPoolHashRate.Text = FormatHashRate(dHashTemp)

                    Me.txtP2pPoolStaleRate.Text = Format(Val(j.Value(Of String)("pool_stale_prop")), "###.##%")

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "Pool"
                        cmHashRates.Parameters("@HashTotal").Value = dHashTemp
                        cmHashRates.ExecuteNonQuery()
                    End If

                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri(Me.txtP2PoolURL.Text & "/local_stats"), enPool.p2pool1)

                Case enPool.p2pool3
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    bDebugPoint = 1

                    pd = PoolData(enPool.p2pool1)

                    sTemp = j.Value(Of String)(Me.txtP2PoolBTCAddy.Text)

                    If String.IsNullOrEmpty(sTemp) = True Then
                        Me.txtP2pPayout.Text = "check pym addy"
                    Else
                        Me.txtP2pPayout.Text = sTemp

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmPayout.Parameters("@pool").Value = pd.sPoolName
                            cmPayout.Parameters("@ConfirmedBTC").Value = DBNull.Value
                            cmPayout.Parameters("@UnconfirmedBTC").Value = DirectCast(pd.oData1, Double)
                            cmPayout.Parameters("@EstimatedBTC").Value = Val(sTemp)
                            cmPayout.Parameters("@PaidBTC").Value = DBNull.Value
                            cmPayout.ExecuteNonQuery()
                        End If
                    End If

                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri(Me.txtP2PoolURL.Text & "/recent_blocks"), enPool.p2pool4)

                Case enPool.p2pool4
                    pd = PoolData(enPool.p2pool1)

                    bDebugPoint = 1

                    ja = Newtonsoft.Json.Linq.JArray.Parse(sJSONText)

                    If ja.Count <> 0 Then
                        For Each j In ja
                            Me.txtP2pRoundDuration.Text = FormatTimeSpan(Format1970Date(UInt32.Parse(j.Value(Of String)("ts"))))

                            pd.dLastBlockTime = DateFrom1970(UInt32.Parse(j.Value(Of String)("ts")))    'in UTC

                            Exit For
                        Next
                    Else
                        If pd.dLastBlockTime <> #12:00:00 AM# Then
                            Me.txtP2pRoundDuration.Text = FormatTimeSpan(Now.Subtract(pd.dLastBlockTime.ToLocalTime))
                        End If
                    End If

                    Me.ToolTip1.SetToolTip(Me.txtp2pUserHash, "As of " & Now.ToString)

            End Select
        Catch ex As Exception When bErrorHandle = True
            Select Case pool
                Case enPool.p2pool1
                    Me.txtp2pUserHash.Text = "PJ:API ERROR1"

                Case enPool.p2pool2
                    Me.txtp2pUserHash.Text = "PJ:API ERROR2"

                Case enPool.p2pool3
                    Me.txtp2pUserHash.Text = "PJ:API ERROR3"

                Case enPool.p2pool4
                    Me.txtp2pUserHash.Text = "PJ:API ERROR4"

            End Select

            Me.ToolTip1.SetToolTip(Me.txtp2pUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try
    End Sub

    Private Sub HandleBitMinter(ByVal sJSONText As String, ByVal pool As enPool)

        Dim j, jp1, jp2, jp3 As Newtonsoft.Json.Linq.JObject
        Dim ja As Newtonsoft.Json.Linq.JArray
        Dim dr As DataRow
        Dim iShares As Integer
        Dim dTemp As Date
        Dim pd As clsPoolData
        Dim dHashTemp As Double
        Dim tsTemp As TimeSpan
        Dim bDebugPoint As Byte

        Try
            Select Case pool 'two calls for BitMinter
                Case enPool.bitminter1  'user data
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    bDebugPoint = 1

                    Debug.Print("Bitminter: " & sJSONText)

                    pd = PoolData(enPool.bitminter1)

                    pd.dSHA256TotalHashRate = j.Value(Of Double)("hash_rate")

                    tsTemp = Now - DateFrom1970(j.Value(Of String)("now")).ToLocalTime

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "User"
                        cmHashRates.Parameters("@HashTotal").Value = pd.dSHA256TotalHashRate
                        cmHashRates.ExecuteNonQuery()
                    End If

                    Me.txtBitMinterUserHash.Text = FormatHashRate(pd.dSHA256TotalHashRate)

                    For Each j1 In j.Property("shift")
                        Me.txtBitMinterUserShiftAccepted.Text = j1.Value(Of String)("accepted")
                        Me.txtBitMinterUserShiftRejected.Text = j1.Value(Of String)("rejected")
                        Me.txtBitMinterUserShiftScore.Text = Format(j1.Value(Of Double)("user_score"), "0.0000000000")
                    Next

                    For Each j1 In j.Property("balances")
                        Me.txtBitMinterNMCBalance.Text = Format(j1.Value(Of Double)("NMC"), "0.0000000000")
                        Me.txtBitMinterBTCBalance.Text = Format(j1.Value(Of Double)("BTC"), "0.0000000000")

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmPayout.Parameters("@pool").Value = pd.sPoolName
                            cmPayout.Parameters("@ConfirmedBTC").Value = j1.Value(Of Double)("BTC")
                            cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                            cmPayout.Parameters("@EstimatedBTC").Value = DBNull.Value
                            cmPayout.Parameters("@PaidBTC").Value = DBNull.Value
                            cmPayout.ExecuteNonQuery()
                        End If
                    Next

                    pd.ds.Tables(0).Clear()

                    For Each ja In j.Property("workers")
                        For Each jp1 In ja
                            If Me.chkBitMinterShowWorkerCheckPoint.Checked = True OrElse Me.chkBitMinterShowWorkerTotals.Checked = True Then
                                If pd.ds.Tables(0).Rows.Count <> 0 Then
                                    'add blank row
                                    dr = pd.ds.Tables(0).NewRow
                                    pd.ds.Tables(0).Rows.Add(dr)
                                End If
                            End If

                            dr = pd.ds.Tables(0).NewRow

                            dr.Item("Worker") = jp1.Value(Of String)("name")

                            dHashTemp = jp1.Value(Of Double)("hash_rate")
                            dr.Item("Hashrate/Avg") = FormatHashRate(dHashTemp) & " / " & FormatHashRate(ProcessWorkerData(pd, jp1.Value(Of String)("name"), dHashTemp))

                            For Each jp2 In jp1.Property("work")
                                For Each jp3 In jp2.Property("BTC")
                                    dr.Item("Shares/Rejected/Last") = jp3.Value(Of String)("round_accepted") & " / " & _
                                                                      jp3.Value(Of String)("round_rejected") & " / " & _
                                                                      FormatTimeSpan(Format1970Date(jp1.Value(Of String)("last_work")) + tsTemp)

                                    'round
                                    pd.ds.Tables(0).Rows.Add(dr)

                                    iShares += Val(jp3.Value(Of String)("round_accepted"))

                                    If Me.chkBitMinterShowWorkerCheckPoint.Checked = True Then
                                        'checkpoint
                                        dr = pd.ds.Tables(0).NewRow

                                        dr.Item("Worker") = "Checkpoint"
                                        dr.Item("Hashrate/Avg") = ""
                                        dr.Item("Shares/Rejected/Last") = jp3.Value(Of String)("checkpoint_accepted") & " / " & jp3.Value(Of String)("checkpoint_rejected")

                                        pd.ds.Tables(0).Rows.Add(dr)
                                    End If


                                    If Me.chkBitMinterShowWorkerTotals.Checked = True Then
                                        'totals
                                        dr = pd.ds.Tables(0).NewRow

                                        dr.Item("Worker") = "Total"
                                        dr.Item("Hashrate/Avg") = ""
                                        dr.Item("Shares/Rejected/Last") = jp3.Value(Of String)("total_accepted") & " / " & jp3.Value(Of String)("total_rejected")

                                        pd.ds.Tables(0).Rows.Add(dr)
                                    End If
                                Next
                            Next

                            If Me.chkConfigStoreDBStatistics.Checked = True Then
                                cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName
                                cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                                cmWorkHashRates.Parameters("@Hashrate").Value = dHashTemp
                                cmWorkHashRates.ExecuteNonQuery()
                            End If
                        Next
                    Next

                    If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# Then
                        cmShareCounts.Parameters("@pool").Value = pd.sPoolName
                        cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                        cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                        cmShareCounts.ExecuteNonQuery()
                    End If

                    pd.dLastShareTime = Now
                    pd.iYourTotalShares = iShares

                    Call ShowTotalHashRate(False)
                    Call CheckForIdleWorkers(pd)

                Case enPool.bitminter2      'pool stats
                    j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                    bDebugPoint = 1

                    pd = PoolData(enPool.bitminter1)

                    For Each jp1 In j.Property("chains")
                        For Each jp2 In jp1.Property("BTC")
                            Me.txtBitMinterBTCRoundShares.Text = jp2.Value(Of String)("accepted")

                            If pd.dRoundShares <> 0 AndAlso pd.dRoundShares > Val(jp2.Value(Of String)("accepted")) Then
                                'Me.lblBitMinterLastBlockFound.Visible = True

                                Debug.Print("BitMinter:" & Date.Now.ToString & " new block found")

                                If Me.chkConfigStoreDBStatistics.Checked = True Then
                                    cmBlocks.Parameters("@Pool").Value = pd.sPoolName
                                    cmBlocks.ExecuteNonQuery()
                                End If
                            End If

                            pd.dRoundShares = Val(jp2.Value(Of String)("accepted"))

                            tsTemp = TimeSpan.FromSeconds(Val(jp2.Value(Of String)("duration")))
                            Me.txtBitMinterBTCRoundDuration.Text = FormatTimeSpan(tsTemp)

                            dTemp = Now.Subtract(tsTemp)
                            'Me.lblBitMinterLastBlockFound.Text = "Last block around " & dTemp.ToLocalTime
                            pd.dLastBlockTime = dTemp.ToLocalTime

                            Me.txtBitMinterBTCEfficiency.Text = Format((Val(jp2.Value(Of String)("accepted")) - Val(jp2.Value(Of String)("rejected"))) / Val(jp2.Value(Of String)("accepted")), "##.###%")
                        Next

                        For Each jp2 In jp1.Property("NMC")
                            Me.txtBitMinterNMCRoundShares.Text = jp2.Value(Of String)("accepted")

                            Me.txtBitMinterNMCRoundDuration.Text = FormatTimeSpan(TimeSpan.FromSeconds(Val(jp2.Value(Of String)("duration"))))

                            Me.txtBitMinterNMCEfficiency.Text = Format((Val(jp2.Value(Of String)("accepted")) - Val(jp2.Value(Of String)("rejected"))) / Val(jp2.Value(Of String)("accepted")), "##.###%")
                        Next
                    Next

                    dHashTemp = Val(j.Value(Of String)("hash_rate")) * 1000

                    Me.txtBitMinterPoolHash.Text = FormatHashRate(dHashTemp)

                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                        cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                        cmHashRates.Parameters("@HashType").Value = "Pool"
                        cmHashRates.Parameters("@HashTotal").Value = dHashTemp
                        cmHashRates.ExecuteNonQuery()
                    End If

                    Me.txtBitMinterShiftDuration.Text = FormatTimeSpan(TimeSpan.FromSeconds(j.Value(Of Double)("shift_duration")))
                    Me.txtBitMinterShiftScore.Text = Format(j.Value(Of Double)("shift_score"), "0.##########")

                    Me.ToolTip1.SetToolTip(Me.txtBitMinterUserHash, "As of " & Now.ToString)

            End Select
        Catch ex As Exception When bErrorHandle = True
            Select Case pool
                Case enPool.bitminter1
                    Me.txtBitMinterUserHash.Text = "PJ:API ERROR1"

                Case enPool.bitminter2
                    Me.txtBitMinterUserHash.Text = "PJ:API ERROR2"

            End Select

            Me.ToolTip1.SetToolTip(Me.txtBitMinterUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try
    End Sub

    Private Sub HandleBTCGuild(ByVal sJSONText As String)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim dr As DataRow
        Dim iShares As Integer
        Dim pd As clsPoolData
        Dim dHashRate As Double
        Dim bDebugPoint As Byte
        Dim x As Integer
        Dim iTemp As UInt64

        Try
            If sJSONText.Contains("API key did not match any users.") = True Then
                Me.txtBTCGuildUserHash.Text = "CHECK API KEY"

                Exit Sub
            End If

            Debug.Print("BTCGuild: " & Now.ToString)

            If sJSONText.ToLower.Contains("you have made too many api requests recently") = True Then
                Me.txtBTCGuildUserHash.Text = "15 SECONDS"
                Me.ToolTip1.SetToolTip(Me.txtBTCGuildUserHash, "API calls for BTC Guild are limited to once every 15 seconds.")

                Debug.Print("15 seconds")

                Exit Sub
            End If

            If sJSONText = "Failed to connect to BTC Guild database.  Please try again later." Then
                Me.txtBTCGuildUserHash.Text = "BTCG ERROR"
                Me.ToolTip1.SetToolTip(Me.txtBTCGuildUserHash, sJSONText)

                Debug.Print("15 seconds")

                Exit Sub
            End If

            Me.ToolTip1.SetToolTip(Me.txtBTCGuildUserHash, "")

            j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

            Debug.Print("BTCGuild: " & sJSONText)

            pd = PoolData(enPool.btcguild)

            bDebugPoint = 1

            pd.ds.Tables(0).Clear()

            For Each jp1 In j.Property("user").ToList
                Me.txtBTCGuildPendingNMCPayout.Text = jp1.Value(Of String)("unpaid_rewards_nmc")
                Me.txtBTCGuildPendingBTCPayout.Text = jp1.Value(Of String)("unpaid_rewards")
                Me.txtBTCGuild24HourBTCPayout.Text = jp1.Value(Of String)("past_24h_rewards")

                If Me.chkConfigStoreDBStatistics.Checked = True Then
                    cmPayout.Parameters("@pool").Value = pd.sPoolName
                    cmPayout.Parameters("@ConfirmedBTC").Value = jp1.Value(Of Double)("unpaid_rewards")
                    cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                    cmPayout.Parameters("@EstimatedBTC").Value = DBNull.Value
                    cmPayout.Parameters("@PaidBTC").Value = jp1.Value(Of Double)("paid_rewards")
                    cmPayout.ExecuteNonQuery()
                End If
            Next

            For Each jp1 In j.Property("pool").ToList
                Me.txtBTCGuildPoolHashrate.Text = FormatHashRate(Val(jp1.Value(Of String)("pool_speed")) * 1000000)

                'Me.txtBTCGuildPPSRate.Text = Format(jp1.Value(Of Double)("pps_rate"), "0.###############")
                'Me.ToolTip1.SetToolTip(Me.txtBTCGuildPPSRate, Me.txtBTCGuildPPSRate.Text)

                'Me.txtBTCGuildDifficulty.Text = Format(Double.Parse(jp1.Value(Of String)("difficulty")), "###,###,###,###,###,###,###")

                If Me.chkConfigStoreDBStatistics.Checked = True Then
                    cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                    cmHashRates.Parameters("@HashType").Value = "Pool"
                    cmHashRates.Parameters("@HashTotal").Value = Val(jp1.Value(Of String)("pool_speed") * 1000000)
                    cmHashRates.ExecuteNonQuery()
                End If
            Next

            For Each jp1 In j.Property("workers").ToList
                For x = 1 To jp1.Count
                    For Each jp2 In jp1.Property(x.ToString).ToList
                        If pd.ds.Tables(0).Rows.Count <> 0 Then
                            'add blank row
                            dr = pd.ds.Tables(0).NewRow
                            pd.ds.Tables(0).Rows.Add(dr)
                        End If

                        'totals
                        dr = pd.ds.Tables(0).NewRow

                        dr.Item("Worker") = jp2.Value(Of String)("worker_name")
                        dr.Item("Hashrate/Avg") = FormatHashRate(jp2.Value(Of String)("hash_rate")) & " / " & _
                            FormatHashRate(ProcessWorkerData(pd, jp2.Value(Of String)("worker_name"), jp2.Value(Of Double)("hash_rate")))

                        dHashRate += jp2.Value(Of Double)("hash_rate")

                        dr.Item("Shares/Stales/Dupe/Unknown") = jp2.Value(Of String)("valid_shares") & " / " & jp2.Value(Of String)("stale_shares") & " / " & jp2.Value(Of String)("dupe_shares") & " / " & jp2.Value(Of String)("unknown_shares")

                        iTemp = jp2.Value(Of UInt64)("valid_shares") + jp2.Value(Of UInt64)("stale_shares") +
                            jp2.Value(Of UInt64)("dupe_shares") + jp2.Value(Of UInt64)("unknown_shares")

                        If iTemp <> 0 Then
                            dr.Item("Bad") = Format((iTemp - jp2.Value(Of UInt64)("valid_shares")) / iTemp, "##0.##%")
                        Else
                            dr.Item("Bad") = "0.00%"
                        End If

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName
                            cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                            cmWorkHashRates.Parameters("@Hashrate").Value = jp2.Value(Of Double)("hash_rate")
                            cmWorkHashRates.ExecuteNonQuery()
                        End If

                        pd.ds.Tables(0).Rows.Add(dr)

                        iShares += jp2.Value(Of Double)("valid_shares")

                        'since reset
                        dr = pd.ds.Tables(0).NewRow

                        dr.Item("Worker") = "Since Reset"
                        dr.Item("Hashrate/Avg") = ""
                        dr.Item("Shares/Stales/Dupe/Unknown") = jp2.Value(Of String)("valid_shares_since_reset") & " / " & jp2.Value(Of String)("stale_shares_since_reset") & " / " & _
                            jp2.Value(Of String)("dupe_shares_since_reset") & " / " & jp2.Value(Of String)("unknown_shares_since_reset")

                        iTemp = jp2.Value(Of UInt64)("valid_shares_since_reset") + jp2.Value(Of UInt64)("stale_shares_since_reset") +
                            jp2.Value(Of UInt64)("dupe_shares_since_reset") + jp2.Value(Of UInt64)("unknown_shares_since_reset")

                        If iTemp <> 0 Then
                            dr.Item("Bad") = Format((iTemp - jp2.Value(Of UInt64)("valid_shares_since_reset")) / iTemp, "##0.##%")
                        Else
                            dr.Item("Bad") = "0.00%"
                        End If

                        pd.ds.Tables(0).Rows.Add(dr)
                    Next
                Next

                If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# Then
                    cmShareCounts.Parameters("@pool").Value = pd.sPoolName
                    cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                    cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                    cmShareCounts.ExecuteNonQuery()
                End If

                pd.iYourTotalShares = iShares
                pd.dLastShareTime = Now
            Next

            Me.txtBTCGuildUserHash.Text = FormatHashRate(dHashRate)
            pd.dSHA256TotalHashRate = dHashRate

            Call ShowTotalHashRate(False)
            Call CheckForIdleWorkers(pd)

            Me.ToolTip1.SetToolTip(Me.txtBTCGuildUserHash, "As of " & Now.ToString)
        Catch ex As Exception When bErrorHandle = True
            Me.txtBTCGuildUserHash.Text = "PJ:API ERROR"

            Me.ToolTip1.SetToolTip(Me.txtBTCGuildUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try

    End Sub

    Private Sub HandleScryptGuild(ByVal sJSONText As String)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim ja As Newtonsoft.Json.Linq.JArray
        Dim dr As DataRow
        Dim iTemp, iShares As UInt64
        Dim pd As clsPoolData
        Dim dHashRate, dTemp As Double
        Dim bDebugPoint As Byte
        Dim coinBalances, coinEarnings As Dictionary(Of String, Double)

        Try
            If sJSONText.Substring(1) = "API key did not match any users." Then
                Me.txtScryptGuildUserHash.Text = "CHECK API KEY"

                Exit Sub
            End If

            If sJSONText.ToLower.Contains("you have made too many api requests recently") = True Then
                Me.txtScryptGuildUserHash.Text = "15 SECONDS"
                Me.ToolTip1.SetToolTip(Me.txtScryptGuildUserHash, "API calls for ScryptGuild are limited to once every 15 seconds.")

                Exit Sub
            End If

            Me.ToolTip1.SetToolTip(Me.txtScryptGuildUserHash, "")

            j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

            Debug.Print("ScryptGuild: " & sJSONText)

            bDebugPoint = 1

            'coin data
            If Me.chkScryptGuildShowBalanceData.Checked = True Then
                pd = PoolData(enPool.scryptguild1)

                pd.ds.Tables(0).Clear()

                coinBalances = New Dictionary(Of String, Double)
                coinEarnings = New Dictionary(Of String, Double)

                For Each jp1 In j.Property("balances").ToList
                    For Each jp2 In jp1.Property("earnings").ToList
                        For Each jp3 In jp2
                            coinBalances.Add(jp3.Key, System.Convert.ChangeType(jp3.Value, GetType(Double)))
                            coinEarnings.Add(jp3.Key, System.Convert.ChangeType(jp3.Value, GetType(Double)))
                        Next
                    Next

                    For Each jp2 In jp1.Property("adjustments").ToList
                        For Each jp3 In jp2
                            coinBalances.Item(jp3.Key) += System.Convert.ChangeType(jp3.Value, GetType(Double))
                            coinEarnings.Item(jp3.Key) += System.Convert.ChangeType(jp3.Value, GetType(Double))
                        Next
                    Next

                    For Each jp2 In jp1.Property("conversions").ToList
                        For Each jp3 In jp2
                            coinBalances.Item(jp3.Key) += System.Convert.ChangeType(jp3.Value, GetType(Double))
                            coinEarnings.Item(jp3.Key) += System.Convert.ChangeType(jp3.Value, GetType(Double))
                        Next
                    Next

                    For Each jp2 In jp1.Property("payouts").ToList
                        For Each jp3 In jp2
                            coinBalances.Item(jp3.Key) -= System.Convert.ChangeType(jp3.Value, GetType(Double))
                        Next
                    Next
                Next

                For Each coin In coinBalances.Keys
                    dr = pd.ds.Tables(0).NewRow

                    dTemp = coinBalances.Item(coin)

                    If coin = "btc" Then
                        Me.txtScryptGuildConfirmedBTC.Text = Format(dTemp, "###,###,###,##0.##########")
                    End If

                    If chkScryptGuildOmitTinyBalances.Checked = True AndAlso (dTemp = 0 OrElse dTemp < 0.0000000001) Then
                        'don't show the coin
                    Else
                        dr.Item("Coin") = coin
                        dr.Item("Balance") = Format(dTemp, "###,###,###,##0.##########")

                        pd.ds.Tables(0).Rows.Add(dr)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmPayout.Parameters("@pool").Value = pd.sPoolName & ":" & coin
                            cmPayout.Parameters("@ConfirmedBTC").Value = dTemp
                            cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                            cmPayout.Parameters("@EstimatedBTC").Value = DBNull.Value
                            cmPayout.Parameters("@PaidBTC").Value = coinEarnings.Item(coin)
                            cmPayout.ExecuteNonQuery()
                        End If
                    End If
                Next
            End If

            If Me.chkScryptGuildShowWorkerData.Checked = True Then
                'now worker data
                pd = PoolData(enPool.scryptguild2)

                bDebugPoint = 1

                pd.ds.Tables(0).Clear()

                For Each ja In j.Property("worker_stats").ToList
                    For Each jp1 In ja
                        'blank row
                        If pd.ds.Tables(0).Rows.Count <> 0 Then
                            dr = pd.ds.Tables(0).NewRow
                            pd.ds.Tables(0).Rows.Add(dr)
                        End If

                        dr = pd.ds.Tables(0).NewRow

                        dr.Item("Worker") = jp1.Value(Of String)("worker_name")
                        dr.Item("Hashrate/Avg") = FormatHashRate(jp1.Value(Of Double)("speed") / 1000) & " / " & _
                            FormatHashRate(ProcessWorkerData(pd, jp1.Value(Of String)("worker_name"), jp1.Value(Of Double)("speed") / 1000))

                        dHashRate += jp1.Value(Of Double)("speed") / 1000

                        dr.Item("Shares/Stales/Dupe/Unknown") = jp1.Value(Of String)("valid") & " / " & jp1.Value(Of String)("stale") & " / " & _
                            jp1.Value(Of String)("duplicate") & " / " & jp1.Value(Of String)("unknown")

                        iTemp = jp1.Value(Of UInt64)("valid") + jp1.Value(Of UInt64)("stale") +
                            jp1.Value(Of UInt64)("duplicate") + jp1.Value(Of UInt64)("unknown") + jp1.Value(Of UInt64)("lowdifficulty")

                        If iTemp <> 0 Then
                            dr.Item("Bad") = Format((iTemp - jp1.Value(Of UInt64)("valid")) / iTemp, "##0.##%")
                        Else
                            dr.Item("Bad") = "0.00%"
                        End If

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmWorkHashRates.Parameters("@Pool").Value = pd.sPoolName
                            cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                            cmWorkHashRates.Parameters("@Hashrate").Value = jp1.Value(Of Double)("speed")
                            cmWorkHashRates.ExecuteNonQuery()
                        End If

                        pd.ds.Tables(0).Rows.Add(dr)

                        iShares += jp1.Value(Of Double)("valid")

                        'since reset
                        dr = pd.ds.Tables(0).NewRow

                        dr.Item("Worker") = "Since Reset"
                        dr.Item("Hashrate/Avg") = ""
                        dr.Item("Shares/Stales/Dupe/Unknown") = jp1.Value(Of String)("valid_reset") & " / " & jp1.Value(Of String)("stale_reset") & " / " & _
                            jp1.Value(Of String)("dupe_reset") & " / " & jp1.Value(Of String)("unknown_reset")

                        iTemp = jp1.Value(Of UInt64)("valid_reset") + jp1.Value(Of UInt64)("stale_reset") +
                            jp1.Value(Of UInt64)("dupe_reset") + jp1.Value(Of UInt64)("unknown_reset") + jp1.Value(Of UInt64)("lowdiff_reset")

                        If iTemp <> 0 Then
                            dr.Item("Bad") = Format((iTemp - jp1.Value(Of UInt64)("valid_reset")) / iTemp, "##0.##%")
                        Else
                            dr.Item("Bad") = "0.00%"
                        End If

                        pd.ds.Tables(0).Rows.Add(dr)
                    Next
                Next

                If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# Then
                    cmShareCounts.Parameters("@pool").Value = pd.sPoolName
                    cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                    cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                    cmShareCounts.ExecuteNonQuery()
                End If

                pd.iYourTotalShares = iShares
                pd.dLastShareTime = Now
            End If

            Me.txtScryptGuildUserHash.Text = FormatHashRate(dHashRate)
            pd.dScryptTotalHashRate = dHashRate

            Call ShowTotalHashRate(False)
            Call CheckForIdleWorkers(pd)

            Me.ToolTip1.SetToolTip(Me.txtScryptGuildUserHash, "As of " & Now.ToString)
        Catch ex As Exception When bErrorHandle = True
            Me.txtScryptGuildUserHash.Text = "PJ:API ERROR"

            Me.ToolTip1.SetToolTip(Me.txtScryptGuildUserHash, "An error occurred when processing the output from this pool.  This could indicate a problem with this application, or with the pool.")
        End Try

    End Sub

    Private Sub HandleSlush(ByVal sJSONText As String)

        Dim j, jp1, jp2 As Newtonsoft.Json.Linq.JObject
        Dim dr As DataRow
        Dim iShares As Integer
        Dim pd As clsPoolData
        Dim dHashTemp As Double
        Dim bDebugPoint As Byte

        Try
            j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

            pd = PoolData(enPool.slush)

            Debug.Print("slush: " & sJSONText)

            bDebugPoint = 1

            pd.ds.Tables(0).Clear()

            Me.txtSlushUserHash.Text = FormatHashRate(j.Value(Of String)("hashrate"))
            'pd.dTotalHashRate = Val(j.Value(Of String)("hashrate"))

            Me.txtSlushConfirmedPayout.Text = j.Value(Of String)("confirmed_reward")
            Me.txtSlushEstimatedPayout.Text = j.Value(Of String)("estimated_reward")
            Me.txtSlushUnconfirmedPayout.Text = j.Value(Of String)("unconfirmed_reward")

            If Me.chkConfigStoreDBStatistics.Checked = True Then
                cmPayout.Parameters("@pool").Value = pd.sPoolName
                cmPayout.Parameters("@ConfirmedBTC").Value = Val(j.Value(Of String)("confirmed_reward"))
                cmPayout.Parameters("@UnconfirmedBTC").Value = Val(j.Value(Of String)("unconfirmed_reward"))
                cmPayout.Parameters("@EstimatedBTC").Value = Val(j.Value(Of String)("estimated_reward"))
                cmPayout.Parameters("@PaidBTC").Value = DBNull.Value
                cmPayout.ExecuteNonQuery()
            End If

            'Me.txtSlushRating.Text = j.Value(Of String)("rating")

            For Each jp1 In j.Property("workers").ToList
                If pd.ds.Tables(0).Rows.Count <> 0 Then
                    'add blank row
                    dr = pd.ds.Tables(0).NewRow
                    pd.ds.Tables(0).Rows.Add(dr)
                End If

                For Each mhr In jp1.Properties
                    dr = pd.ds.Tables(0).NewRow

                    dr.Item("Worker") = mhr.Name

                    For Each jp2 In mhr
                        dr.Item("Hashrate/Avg") = FormatHashRate(jp2.Value(Of String)("hashrate")) & " / " & _
                            FormatHashRate(ProcessWorkerData(pd, mhr.Name, jp2.Value(Of Double)("hashrate")))
                        dr.Item("Shares/Score/Last") = jp2.Value(Of String)("shares") & " / " & jp2.Value(Of String)("score") & " / " & _
                            FormatTimeSpan(Format1970Date(jp2.Value(Of Double)("last_share")))

                        iShares += jp2.Value(Of Double)("shares")

                        pd.ds.Tables(0).Rows.Add(dr)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmWorkHashRates.Parameters("@pool").Value = pd.sPoolName
                            cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker")
                            cmWorkHashRates.Parameters("@Hashrate").Value = jp2.Value(Of Double)("hashrate")
                            cmWorkHashRates.ExecuteNonQuery()
                        End If

                        dHashTemp += jp2.Value(Of Double)("hashrate")
                    Next
                Next
            Next

            If Me.chkConfigStoreDBStatistics.Checked = True AndAlso pd.dLastShareTime <> #12:00:00 AM# AndAlso iShares > pd.iYourTotalShares Then
                cmShareCounts.Parameters("@pool").Value = pd.sPoolName
                cmShareCounts.Parameters("@Shares").Value = iShares - pd.iYourTotalShares
                cmShareCounts.Parameters("@DurationInSeconds").Value = (Now - pd.dLastShareTime).TotalSeconds
                cmShareCounts.ExecuteNonQuery()
            End If

            pd.iYourTotalShares = iShares
            pd.dLastShareTime = Now

            pd.dSHA256TotalHashRate = dHashTemp

            Me.txtSlushUserHash.Text = FormatHashRate(dHashTemp)

            If Me.chkConfigStoreDBStatistics.Checked = True Then
                cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                cmHashRates.Parameters("@HashType").Value = "User"
                cmHashRates.Parameters("@HashTotal").Value = dHashTemp
                cmHashRates.ExecuteNonQuery()
            End If

            Call ShowTotalHashRate(False)
            Call CheckForIdleWorkers(pd)

            Me.ToolTip1.SetToolTip(Me.txtSlushUserHash, "As of " & Now.ToString)
        Catch ex As Exception When bErrorHandle = True
            Me.txtSlushUserHash.Text = "PJ:API ERROR"

            Me.ToolTip1.SetToolTip(Me.txtSlushUserHash, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try
    End Sub

    Private Sub HandleMultipool(ByVal sJSONText As String)

        Dim j, jp1, jp2, jp3 As Newtonsoft.Json.Linq.JObject
        Dim dr As DataRow
        Dim pd As clsPoolData
        Dim dHashRate, dHashTemp, dHashTemp2 As Double
        Dim bDebugPoint As Byte

        Try
            j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

            pd = PoolData(enPool.multipool1)

            Debug.Print("multipool: " & sJSONText)

            bDebugPoint = 1

            pd.ds.Tables(0).Clear()

            For Each jp1 In j.Property("currency").ToList
                For Each mhr In jp1.Properties
                    dr = pd.ds.Tables(0).NewRow

                    dr.Item("Coin") = mhr.Name

                    For Each jp2 In mhr
                        dr.Item("Balance") = Format(Val(jp2.Value(Of String)("confirmed_rewards")), "###,###,###,##0.##########")

                        dHashRate = Val(jp2.Value(Of String)("hashrate"))

                        If IsScryptCoin(mhr.Name) = True Then
                            'scrypt divide by 1000
                            dHashRate /= 1000
                        End If

                        dr.Item("UserHashrate") = FormatHashRate(dHashRate)
                        dr.Item("Pending") = Format(Val(jp2.Value(Of String)("estimated_rewards")), "###,###,###,##0.##########")

                        dHashRate = Val(jp2.Value(Of String)("pool_hashrate"))

                        If IsScryptCoin(mhr.Name) = True Then
                            'scrypt divide by 1000
                            dHashRate /= 1000
                        End If

                        dr.Item("PoolHashrate") = FormatHashRate(dHashRate)

                        pd.ds.Tables(0).Rows.Add(dr)

                        If Me.chkConfigStoreDBStatistics.Checked = True Then
                            cmHashRates.Parameters("@Pool").Value = pd.sPoolName
                            cmHashRates.Parameters("@HashType").Value = "Pool:" & mhr.Name
                            cmHashRates.Parameters("@HashTotal").Value = Val(jp1.Value(Of String)("pool_speed") / 1000)
                            cmHashRates.ExecuteNonQuery()

                            cmPayout.Parameters("@pool").Value = pd.sPoolName & ":" & mhr.Name
                            cmPayout.Parameters("@ConfirmedBTC").Value = Val(jp1.Value(Of String)("confirmed_rewards"))
                            cmPayout.Parameters("@UnconfirmedBTC").Value = DBNull.Value
                            cmPayout.Parameters("@EstimatedBTC").Value = Val(jp1.Value(Of String)("estimated_rewards"))
                            cmPayout.Parameters("@PaidBTC").Value = Val(jp1.Value(Of String)("payout_history"))
                            cmPayout.ExecuteNonQuery()
                        End If
                    Next
                Next
            Next

            pd = PoolData(enPool.multipool2)

            bDebugPoint = 2

            pd.ds.Tables(0).Clear()

            For Each jp1 In j.Property("workers").ToList
                For Each mhr In jp1.Properties
                    For Each jp2 In mhr
                        For Each mhr2 In jp2.Properties
                            dr = pd.ds.Tables(0).NewRow

                            dr.Item("Coin") = mhr.Name
                            dr.Item("Worker") = mhr2.Name

                            For Each jp3 In mhr2
                                dHashRate = Val(jp3.Value(Of String)("hashrate")) / 1000

                                dr.Item("Hashrate") = FormatHashRate(dHashRate)

                                If dHashRate <> 0 Then
                                    'display only if non zero
                                    pd.ds.Tables(0).Rows.Add(dr)

                                    If Me.chkConfigStoreDBStatistics.Checked = True Then
                                        cmWorkHashRates.Parameters("@pool").Value = pd.sPoolName
                                        cmWorkHashRates.Parameters("@worker").Value = dr.Item("Worker") & ":" & mhr.Name
                                        cmWorkHashRates.Parameters("@Hashrate").Value = dHashRate
                                        cmWorkHashRates.ExecuteNonQuery()
                                    End If

                                    Call ProcessWorkerData(pd, dr.Item("Worker"), dHashRate)

                                    If IsScryptCoin(mhr.Name) = True Then
                                        dHashTemp += dHashRate
                                    Else
                                        dHashTemp2 += dHashRate
                                    End If
                                End If
                            Next
                        Next
                    Next
                Next
            Next

            pd.dSHA256TotalHashRate = dHashTemp2
            pd.dScryptTotalHashRate = dHashTemp

            If pd.dScryptTotalHashRate = 0 AndAlso pd.dSHA256TotalHashRate = 0 Then
                Me.txtMultipoolUserHashRate.Text = "ZERO"
            ElseIf pd.dScryptTotalHashRate <> 0 AndAlso pd.dSHA256TotalHashRate = 0 Then
                Me.txtMultipoolUserHashRate.Text = "Scr " & FormatHashRate(pd.dScryptTotalHashRate)
            ElseIf pd.dScryptTotalHashRate = 0 AndAlso pd.dSHA256TotalHashRate <> 0 Then
                Me.txtMultipoolUserHashRate.Text = "SHA " & FormatHashRate(pd.dSHA256TotalHashRate)
            ElseIf pd.dScryptTotalHashRate <> 0 AndAlso pd.dSHA256TotalHashRate <> 0 Then
                Me.txtMultipoolUserHashRate.Text = "SHA " & FormatHashRate(pd.dSHA256TotalHashRate) & " - Scr " & FormatHashRate(pd.dScryptTotalHashRate)
            End If

            Call ShowTotalHashRate(False)
            Call CheckForIdleWorkers(pd)

            Me.ToolTip1.SetToolTip(Me.txtMultipoolUserHashRate, "As of " & Now.ToString)
        Catch ex As Exception When bErrorHandle = True
            Me.txtMultipoolUserHashRate.Text = "PJ:API ERROR"

            Me.ToolTip1.SetToolTip(Me.txtMultipoolUserHashRate, "An error occurred when processing the output from this pool.  DBP=" & bDebugPoint & ".  This could indicate a problem with this application, or with the pool.")
        End Try
    End Sub

    Private Sub HandleBlockChainInfo(ByVal sJSONText As String, ByVal pool As enPool)

        Dim j, j2 As Newtonsoft.Json.Linq.JObject
        Dim bDebugPoint As Byte
        Dim wc As System.Net.WebClient
        Static iBlocksSinceLastChange As Integer
        Static iBlockChangeTime As UInt32
        Static iBlockHeight As Integer
        Dim dbRatio As Double

        Try
            Select Case pool
                Case enPool.blockchaininfo
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Blockchain.info1: " & sJSONText)

                        bDebugPoint = 1

                        Me.txtBCI_AsOfTimestamp.Text = Format(Now, "MM/dd/yyyy HH:mm:ss")
                        Me.txtBCI_Difficulty.Text = Format(j.Value(Of Double)("difficulty"), "###,###,###,###,###,###.##")
                        Me.txtBCI_MarketPriceUSD.Text = Format(j.Value(Of Double)("market_price_usd"), "$###,###,###,###.##")
                        'Me.txtBCI_MinsBetweenBlocks.Text = Format(j.Value(Of Double)("minutes_between_blocks"), "##0.######")
                        Me.txtBCI_NetworkHashRate.Text = FormatHashRate(j.Value(Of Double)("hash_rate") * 1000)
                        Me.txtBCI_NextDifficultyChangeBlocks.Text = j.Value(Of Integer)("nextretarget") - j.Value(Of Integer)("n_blocks_total")
                        'Me.txtBCI_NextDifficultyChangeTime.Text = Format(Now.AddMinutes((j.Value(Of Integer)("nextretarget") - j.Value(Of Integer)("n_blocks_total")) * j.Value(Of Double)("minutes_between_blocks")), "MM/dd/yyyy HH:mm:ss")
                        'Me.txtBCI_EstimatedNextDifficulty.Text = Format(10 / j.Value(Of Double)("minutes_between_blocks") * j.Value(Of Double)("difficulty") * 1000, "###,###,###,###,###,###.##") & " (" & Format((1 - j.Value(Of Double)("minutes_between_blocks") / 10), "##0.#%") & ")"

                        iBlocksSinceLastChange = j.Value(Of Integer)("n_blocks_total") - (j.Value(Of Integer)("nextretarget") - 2016)
                        iBlockHeight = j.Value(Of Integer)("n_blocks_total")

                        'get the block info of last block in last difficulty
                        'use the timestamp to figure out how regularly blocks are being found to calculate the next difficulty change
                        wc = New System.Net.WebClient
                        AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                        wc.DownloadStringAsync(New System.Uri("https://blockchain.info/block-height/" & j.Value(Of Integer)("nextretarget") - 2016 & "?format=json"), enPool.blockchaininfo2)

                    Catch ex As Exception When bErrorHandle = True
                        Me.txtBCI_AsOfTimestamp.Text = "PJ:API ERROR1"

                        Me.ToolTip1.SetToolTip(Me.txtBCI_AsOfTimestamp, "An error occurred when processing the output from Blockchain.info.  PDB=" & bDebugPoint & ". This could indicate a problem with this application, or with the data source.")
                    End Try

                Case enPool.blockchaininfo2
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Blockchain.info2: " & sJSONText)

                        bDebugPoint = 1

                        For Each ja In j.Property("blocks").ToList
                            For Each j2 In ja
                                iBlockChangeTime = j2.Value(Of UInt32)("time")
                            Next
                        Next

                        wc = New System.Net.WebClient
                        AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                        wc.DownloadStringAsync(New System.Uri("https://blockchain.info/block-height/" & iBlockHeight & "?format=json"), enPool.blockchaininfo3)
                    Catch ex As Exception When bErrorHandle = True
                        Me.txtBCI_AsOfTimestamp.Text = "PJ:API ERROR2"

                        Me.ToolTip1.SetToolTip(Me.txtBCI_AsOfTimestamp, "An error occurred when processing the output from Blockchain.info.  PDB=" & bDebugPoint & ". This could indicate a problem with this application, or with the data source.")
                    End Try

                Case enPool.blockchaininfo3
                    Try
                        j = Newtonsoft.Json.Linq.JObject.Parse(sJSONText)

                        Debug.Print("Blockchain.info2: " & sJSONText)

                        bDebugPoint = 1

                        For Each ja In j.Property("blocks").ToList
                            For Each j2 In ja
                                Me.txtBCI_MinsBetweenBlocks.Text = Format((j2.Value(Of UInt32)("time") - iBlockChangeTime) / 60 / iBlocksSinceLastChange, "##.##")

                                'supposed to be 10 mins between blocks
                                dbRatio = 10 / ((j2.Value(Of UInt32)("time") - iBlockChangeTime) / 60 / iBlocksSinceLastChange)

                                Me.txtBCI_EstimatedNextDifficulty.Text = Format(dbRatio * Double.Parse(Me.txtBCI_Difficulty.Text), "###,###,###,###,###,###.##") & " (" & _
                                    Format(dbRatio / 100, "##0.#%") & ")"

                                Me.txtBCI_NextDifficultyChangeTime.Text = Format(Now.AddMinutes(Integer.Parse(Me.txtBCI_NextDifficultyChangeBlocks.Text) * Double.Parse(Me.txtBCI_MinsBetweenBlocks.Text)), "MM/dd/yyyy HH:mm:ss")
                            Next
                        Next

                        iBlocksSinceLastChange = 0
                        iBlockChangeTime = 0
                        iBlockHeight = 0
                    Catch ex As Exception When bErrorHandle = True
                        Me.txtBCI_AsOfTimestamp.Text = "PJ:API ERROR3"

                        Me.ToolTip1.SetToolTip(Me.txtBCI_AsOfTimestamp, "An error occurred when processing the output from Blockchain.info.  PDB=" & bDebugPoint & ". This could indicate a problem with this application, or with the data source.")
                    End Try

            End Select
            
        Catch ex As Exception When bErrorHandle = True
            Select Case pool
                Case enPool.blockchaininfo
                    Me.txtBCI_AsOfTimestamp.Text = "PJ:API ERROR1"

                Case enPool.blockchaininfo2
                    Me.txtBCI_AsOfTimestamp.Text = "PJ:API ERROR2"

                Case enPool.blockchaininfo3
                    Me.txtBCI_AsOfTimestamp.Text = "PJ:API ERROR3"

            End Select

            Me.ToolTip1.SetToolTip(Me.txtBCI_AsOfTimestamp, "An error occurred when processing the output from Blockchain.info.  PDB=x" & bDebugPoint & ". This could indicate a problem with this application, or with the data source.")
        End Try

    End Sub

    Private Function IsScryptCoin(ByVal sCoin As String) As Boolean

        Select Case sCoin.ToLower
            Case "btc", "frc", "ppc", "trc", "zet"
                Return False

            Case Else
                Return True

        End Select

    End Function

    Private Sub ShowTotalHashRate(ByVal bByButton As Boolean)

        Dim dScryptTotal, dSHA256Total As Double

        For Each pd As clsPoolData In PoolData
            dScryptTotal += pd.dScryptTotalHashRate
            dSHA256Total += pd.dSHA256TotalHashRate
        Next

        If dScryptTotal = 0 AndAlso dSHA256Total = 0 Then
            Me.txtTotalHash.Text = "ZERO"
        ElseIf dScryptTotal <> 0 AndAlso dSHA256Total = 0 Then
            Me.txtTotalHash.Text = "Scr " & FormatHashRate(dScryptTotal)
        ElseIf dScryptTotal = 0 AndAlso dSHA256Total <> 0 Then
            Me.txtTotalHash.Text = "SHA " & FormatHashRate(dSHA256Total)
        ElseIf dScryptTotal <> 0 AndAlso dSHA256Total <> 0 Then
            Me.txtTotalHash.Text = "SHA " & FormatHashRate(dSHA256Total) & " - Scr " & FormatHashRate(dScryptTotal)
        End If

        Call ShowBTCPerDay(bByButton, dSHA256Total)

    End Sub

    Private Sub ShowBTCPerDay(ByVal bByButton As Boolean, dSHA256Total As Double)

        Dim sTemp As String
        Dim dTemp As Double

        Try
            If ValidatePool(enPool.blockchaininfo) = True AndAlso String.IsNullOrEmpty(Me.txtBCI_Difficulty.Text) = False Then
                'set defaults if not there
                Me.txtBCIc_Difficulty.Text = Me.txtBCI_Difficulty.Text

                sTemp = FormatHashRate(dSHA256Total)

                If sTemp = "ZERO" Then Exit Sub

                Me.txtBCIc_Hashrate.Text = sTemp.Substring(0, sTemp.Length - 5)
                Me.cmbBCIc_HashRate.Text = sTemp.Substring(sTemp.Length - 4)

                If String.IsNullOrEmpty(Me.txtBCIc_FeeDonation.Text) = True Then
                    Me.txtBCIc_FeeDonation.Text = "1"
                End If

                If String.IsNullOrEmpty(Me.txtBCIc_PeriodInDays.Text) = True Then
                    Me.txtBCIc_PeriodInDays.Text = "1"
                End If

                If String.IsNullOrEmpty(Me.txtBCIc_Blocksize.Text) = True Then
                    Me.txtBCIc_Blocksize.Text = "25"
                End If

                Me.txtBCIc_MarketPrice.Text = Me.txtBCI_MarketPriceUSD.Text

                If Me.cmbBCIc_HashRate.Text = "BFH/s" Then
                    Me.txtBCIc_BTCGenerated.Text = "an ungodly qty of"
                Else
                    dTemp = 1000 * Double.Parse(Me.txtBCIc_Blocksize.Text) * 25 * 3600 / (2 ^ 48 / 65535) / Double.Parse(Me.txtBCIc_Difficulty.Text)

                    If Me.txtBCIc_Hashrate.Text = sTemp.Substring(0, sTemp.Length - 5) AndAlso Me.cmbBCIc_HashRate.Text = sTemp.Substring(sTemp.Length - 4) Then
                        dTemp *= dSHA256Total * 1000
                    Else
                        Select Case Me.cmbBCIc_HashRate.Text
                            Case "MH/s"
                                dTemp *= Double.Parse(Me.txtBCIc_Hashrate.Text) * 1000

                            Case "GH/s"
                                dTemp *= Double.Parse(Me.txtBCIc_Hashrate.Text) * 1000000

                            Case "TH/s"
                                dTemp *= Double.Parse(Me.txtBCIc_Hashrate.Text) * 1000000000

                            Case "PH/s"
                                dTemp *= Double.Parse(Me.txtBCIc_Hashrate.Text) * 1000000000000

                            Case "EH/s"
                                dTemp *= Double.Parse(Me.txtBCIc_Hashrate.Text) * 1000000000000000

                            Case "ZH/s"
                                dTemp *= Double.Parse(Me.txtBCIc_Hashrate.Text) * 1000000000000000000

                        End Select
                    End If

                    dTemp *= Integer.Parse(Me.txtBCIc_PeriodInDays.Text)

                    'minus fee/donation
                    dTemp -= dTemp * Double.Parse(Me.txtBCIc_FeeDonation.Text) / 100

                    Me.txtBCIc_BTCGenerated.Text = Format(dTemp, "###,##0.############")

                    Me.txtBCIc_DollarValue.Text = Format(dTemp * Double.Parse(Me.txtBCIc_MarketPrice.Text.Replace("$", "").Replace(",", "")), "$###,###,###,##0.##")

                    'got this far with no errors, save filled in fields if requested
                    If bByButton = True Then
                        Call SetRegKeyByControl(Me.txtBCIc_Blocksize)
                        Call SetRegKeyByControl(Me.txtBCIc_PeriodInDays)
                        Call SetRegKeyByControl(Me.txtBCIc_FeeDonation)
                    End If
                End If
            End If
        Catch ex As Exception When bErrorHandle = True
            Me.txtBCIc_BTCGenerated.Text = "ERROR (check inputs): " & ex.Message
        End Try

    End Sub

    Private Function ValidatePool(ByVal Pool As enPool) As Boolean

        Select Case Pool
            Case enPool.f50btc
                If Me.chk50BTCEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txt50BTCAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.eclipse1
                If Me.chkEclipseEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtEclipseAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.ozcoin
                If Me.chkOzcoinEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtOzcoinAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.p2pool1
                If Me.chkP2PoolEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtP2PoolURL.Text) = False AndAlso String.IsNullOrEmpty(Me.txtP2PoolBTCAddy.Text) = False Then
                    Return True
                End If

            Case enPool.bitminter1
                If Me.chkBitMinterEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtBitMinterAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.btcguild
                If Me.chkBTCGuildEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtBTCGuildAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.slush
                If Me.chkSlushEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtSlushAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.multipool1
                If Me.chkMultipoolEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtMultipoolAPIKey.Text) = False Then
                    Return True
                End If

            Case enPool.blockchaininfo
                If Me.chkBlockChainInfoEnabled.Checked = True Then
                    Return True
                End If

            Case enPool.scryptguild1
                If Me.chkScryptGuildEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtScryptGuildAPIKey.Text) = False AndAlso _
                    (Me.chkScryptGuildShowBalanceData.Checked = True OrElse Me.chkScryptGuildShowWorkerData.Checked = True) Then
                    Return True
                End If

            Case enPool.eligius1
                If Me.chkEligiusEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtEligiusBTCAddress.Text) = False Then
                    Return True
                End If

            Case enPool.ltcrabbit1
                If Me.chkLTCRabbitEnabled.Checked = True AndAlso String.IsNullOrEmpty(Me.txtLTCRabbitAPIKey.Text) = False Then
                    Return True
                End If

        End Select

        Return False

    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles timer_CountDown.Tick

        Dim wc As System.Net.WebClient
        Dim cmAny As OleDb.OleDbCommand
        Dim bGetNonDBEligiusBlockStats As Boolean
        Dim x As Integer
        Dim o As Object

        If iRefresh <= 0 Then
            'Me.cmdRefresh.Text = "Refreshing..."

            'Call cmdRefresh_Click(sender, e)
            Call RefreshPools()

            My.Application.DoEvents()

            iRefresh = iRefreshRate
        End If

        iRefresh -= 1

        If ValidatePool(enPool.blockchaininfo) = True Then
            If dNextBlockchainInfoRefresh < Now Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri("http://blockchain.info/stats?format=json"), enPool.blockchaininfo)

                Select Case Me.cmbBlockChainInfoRefreshRate.Text
                    Case "1 hour"
                        dNextBlockchainInfoRefresh = Now.AddHours(1)

                    Case "2 hours"
                        dNextBlockchainInfoRefresh = Now.AddHours(2)

                    Case "3 hours"
                        dNextBlockchainInfoRefresh = Now.AddHours(3)

                    Case "4 hours"
                        dNextBlockchainInfoRefresh = Now.AddHours(4)

                    Case "6 hours"
                        dNextBlockchainInfoRefresh = Now.AddHours(6)

                    Case "12 hours"
                        dNextBlockchainInfoRefresh = Now.AddHours(12)

                    Case "24 hours"
                        dNextBlockchainInfoRefresh = Now.AddHours(24)

                    Case Else
                        dNextBlockchainInfoRefresh = Now.AddHours(1)

                End Select
            End If
        End If

        If ValidatePool(enPool.eligius1) = True Then
            If dNextEligiusBlockInfoRefresh < Now Then
                If Me.chkConfigStoreDBStatistics.Checked = True Then
                    cmAny = New OleDb.OleDbCommand
                    cmAny.CommandType = CommandType.Text
                    cmAny.CommandText = "select max(Height) from Luck;"
                    cmAny.Connection = cnDB

                    Try
                        If colDBOpenList.Count = 0 Then
                            cnDB.Open()
                        End If

                        colDBOpenList.Add("TimerCountdown")

                        o = cmAny.ExecuteScalar

                        If IsDBNull(o) = False Then
                            x = o
                        Else
                            x = 0
                        End If

                        If x = 0 Then
                            'no block info at all
                            'as of now, the last 3000 blocks gets 4+ months worth of data
                            wc = New System.Net.WebClient
                            AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                            wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=getblocks&limit=3000&format=json&sortby=time&offset=0&minconfs=0&showpretty=1"), enPool.eligius6)
                        Else
                            wc = New System.Net.WebClient
                            AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                            wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=getblocks&limit=3000&format=json&sortby=time&offset=0&minconfs=0&minheight=" & x + 1 & "&showpretty=1"), enPool.eligius6)
                        End If
                    Catch ex As Exception
                        bGetNonDBEligiusBlockStats = True
                    Finally
                        colDBOpenList.Remove("TimerCountdown")

                        If colDBOpenList.Count = 0 Then
                            If cnDB.State <> ConnectionState.Closed Then
                                cnDB.Close()
                            End If
                        End If
                    End Try
                Else
                    bGetNonDBEligiusBlockStats = True
                End If

                If bGetNonDBEligiusBlockStats = True Then
                    'get last 10 only
                    wc = New System.Net.WebClient
                    AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                    wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=getblocks&limit=10&format=json&sortby=time&offset=0&minconfs=0&showpretty=1"), enPool.eligius5)
                End If

                dNextEligiusBlockInfoRefresh = Now.AddHours(1)
            End If
        End If

        Me.cmdRefresh.Text = iRefresh & "s"
        Me.ToolTip1.SetToolTip(Me.cmdRefresh, "Refreshing in " & iRefresh & " seconds (click to force refresh)")

    End Sub

    Private Sub chkAutoRefresh_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkConfigAutoRefresh.CheckedChanged

        If bStarted = True Then
            If Me.chkConfigAutoRefresh.Checked = True Then
                iRefresh = 0

                Call Timer1_Tick(sender, e)
            Else
                Me.timer_CountDown.Enabled = False

                Me.cmdRefresh.Text = "Refresh"
            End If
        End If

    End Sub

    Private Sub chkOnTop_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkConfigAlwaysOnTop.CheckedChanged

        If Me.chkConfigAlwaysOnTop.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If

    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click

        With My.Computer.Registry
            .CurrentUser.CreateSubKey(csRegKey)

            'general
            Call SetRegKeyByControl(Me.chkConfigStoreDBStatistics)
            Call SetRegKeyByControl(Me.cmbConfigRefreshRate)

            'idle
            Call SetRegKeyByControl(Me.chkIdlePopup)
            Call SetRegKeyByControl(Me.chkIdleStartApp)
            Call SetRegKeyByControl(Me.chkIdleWorkPopUpWithBeeps)
            Call SetRegKeyByControl(Me.chkIdleEMailAlerts)

            Call SetRegKeyByControl(Me.txtIdleStartAppName)
            Call SetRegKeyByControl(Me.txtIdleStartParms)

            'email notifications
            Call SetRegKeyByControl(Me.txtSMTPServer)
            Call SetRegKeyByControl(Me.txtSMTPPort)
            Call SetRegKeyByControl(Me.txtSMTPUserName)
            Call SetRegKeyByControl(Me.txtSMTPPassword)
            Call SetRegKeyByControl(Me.txtSMTPAlertName)
            Call SetRegKeyByControl(Me.txtSMTPAlertAddress)
            Call SetRegKeyByControl(Me.txtSMTPAlertSubject)
            Call SetRegKeyByControl(Me.txtSMTPFromAddress)
            Call SetRegKeyByControl(Me.txtSMTPFromName)
            Call SetRegKeyByControl(Me.chkSMTPSSL)

            If Me.chkIdleEMailAlerts.Checked = True Then
                If String.IsNullOrEmpty(Me.txtSMTPServer.Text) = True OrElse String.IsNullOrEmpty(Me.txtSMTPPort.Text) = True OrElse String.IsNullOrEmpty(Me.txtSMTPUserName.Text) = True _
                    OrElse String.IsNullOrEmpty(Me.txtSMTPPassword.Text) = True OrElse String.IsNullOrEmpty(Me.txtSMTPAlertAddress.Text) = True OrElse _
                    String.IsNullOrEmpty(Me.txtSMTPFromAddress.Text) = True Then

                    MsgBox("Warning: Idle alerts are enabled, but one of more required fields are not specified.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                End If
            End If

            If Me.chkIdleStartApp.Checked = True Then
                If String.IsNullOrEmpty(Me.txtIdleStartAppName.Text) = True Then
                    MsgBox("Warning: The idle alert start application option is enabled, but no application is defined.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                End If
            End If

            '50btc
            Call SetRegKeyByControl(Me.chk50BTCEnabled)
            Call SetRegKeyByControl(Me.txt50BTCAPIKey)

            'eclipse
            Call SetRegKeyByControl(Me.chkEclipseEnabled)
            Call SetRegKeyByControl(Me.txtEclipseAPIKey)

            'ozcoin
            Call SetRegKeyByControl(chkOzcoinEnabled)
            Call SetRegKeyByControl(Me.txtOzcoinAPIKey)

            'p2pool
            Call SetRegKeyByControl(Me.chkP2PoolEnabled)
            Call SetRegKeyByControl(Me.txtP2PoolURL)
            Call SetRegKeyByControl(Me.txtP2PoolBTCAddy)
            Call SetRegKeyByControl(Me.chkP2PoolScrypt)
            Call SetRegKeyByControl(Me.chkP2PPublicPool)

            'bitminter
            Call SetRegKeyByControl(Me.chkBitMinterEnabled)
            Call SetRegKeyByControl(Me.txtBitMinterAPIKey)
            Call SetRegKeyByControl(Me.chkBitMinterShowWorkerCheckPoint)
            Call SetRegKeyByControl(Me.chkBitMinterShowWorkerTotals)

            'btcguild
            Call SetRegKeyByControl(Me.chkBTCGuildEnabled)
            Call SetRegKeyByControl(Me.txtBTCGuildAPIKey)

            'slush
            Call SetRegKeyByControl(Me.chkSlushEnabled)
            Call SetRegKeyByControl(Me.txtSlushAPIKey)

            'multipool
            Call SetRegKeyByControl(Me.chkMultipoolEnabled)
            Call SetRegKeyByControl(Me.txtMultipoolAPIKey)

            'blockchain.info
            Call SetRegKeyByControl(Me.chkBlockChainInfoEnabled)
            Call SetRegKeyByControl(Me.cmbBlockChainInfoRefreshRate)

            'scryptguild
            Call SetRegKeyByControl(Me.chkScryptGuildEnabled)
            Call SetRegKeyByControl(Me.chkScryptGuildShowBalanceData)
            Call SetRegKeyByControl(Me.chkScryptGuildShowWorkerData)
            Call SetRegKeyByControl(Me.txtScryptGuildAPIKey)
            Call SetRegKeyByControl(Me.chkScryptGuildOmitTinyBalances)

            'eligius
            Call SetRegKeyByControl(Me.chkEligiusEnabled)
            Call SetRegKeyByControl(Me.txtEligiusBTCAddress)
            Call SetRegKeyByControl(Me.txtEligiusBTCAddy2)
            Call SetRegKeyByControl(Me.txtEligiusBTCAddy3)

            'ltcrabbit
            Call SetRegKeyByControl(Me.chkLTCRabbitEnabled)
            Call SetRegKeyByControl(Me.txtLTCRabbitAPIKey)
        End With

        If bRunning = False AndAlso (ValidatePool(enPool.eclipse1) = True OrElse ValidatePool(enPool.f50btc) = True OrElse ValidatePool(enPool.ozcoin) = True _
                              OrElse ValidatePool(enPool.p2pool1) = True OrElse ValidatePool(enPool.bitminter1) = True OrElse ValidatePool(enPool.btcguild) = True _
                              OrElse ValidatePool(enPool.slush) = True OrElse ValidatePool(enPool.multipool1) = True OrElse ValidatePool(enPool.blockchaininfo) = True _
                              OrElse ValidatePool(enPool.scryptguild1) = True OrElse ValidatePool(enPool.eligius1) = True OrElse ValidatePool(enPool.ltcrabbit1) = True) Then
            Me.tabsShown.SelectTab(0)

            Me.timer_start.Enabled = True
        End If

    End Sub

    Private Sub SetRegKeyByControl(ByRef chkAny As CheckBox)

        Dim sKeyname As String

        If dictRegkeyNames.TryGetValue(chkAny.Name, sKeyname) = True Then
            If chkAny.Checked = True Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & csRegKey, sKeyname, "Y", Microsoft.Win32.RegistryValueKind.String)
            Else
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & csRegKey, sKeyname, "N", Microsoft.Win32.RegistryValueKind.String)
            End If
        Else
            Throw New Exception("Internal error: " & chkAny.Name & " not found in regKey dictionary.")
        End If

    End Sub

    Private Sub SetRegKeyByControl(ByRef txtAny As TextBox)

        _SetRegKeyByControl(txtAny)

    End Sub

    Private Sub SetRegKeyByControl(ByRef cmbAny As ComboBox)

        _SetRegKeyByControl(cmbAny)

    End Sub

    Private Sub _SetRegKeyByControl(ByRef ctlAny As Control)

        Dim sKeyname As String

        If dictRegkeyNames.TryGetValue(ctlAny.Name, sKeyname) = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & csRegKey, sKeyname, ctlAny.Text, Microsoft.Win32.RegistryValueKind.String)
        Else
            Throw New Exception("Internal error: " & ctlAny.Name & " not found in regKey dictionary.")
        End If

    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As System.EventArgs) Handles NotifyIcon1.DoubleClick

        Me.Show()
        Me.Focus()

    End Sub

    Private Sub NotifyIcon1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseMove

        Dim sbTemp As System.Text.StringBuilder

        sbTemp = New System.Text.StringBuilder

        If ValidatePool(enPool.f50btc) = True Then
            sbTemp.Append("50BTC:" & Me.txt50UserHashRate.Text)
        End If

        If ValidatePool(enPool.eclipse1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("Ecl:" & Me.txtEclUserHashRate.Text)
        End If

        If ValidatePool(enPool.ozcoin) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("Oz:" & Me.txtOzUserHashRate.Text)
        End If

        If ValidatePool(enPool.p2pool1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("P2P:" & Me.txtp2pUserHash.Text)
        End If

        If ValidatePool(enPool.bitminter1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("Btmtr:" & Me.txtBitMinterUserHash.Text)
        End If

        If ValidatePool(enPool.btcguild) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("BTCG:" & Me.txtBTCGuildUserHash.Text)
        End If

        If ValidatePool(enPool.slush) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("SLUSH:" & Me.txtSlushUserHash.Text)
        End If

        If ValidatePool(enPool.multipool1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("MLTPL:" & Me.txtMultipoolUserHashRate.Text)
        End If

        If ValidatePool(enPool.scryptguild1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("ScGd: " & Me.txtScryptGuildUserHash.Text)
        End If

        If ValidatePool(enPool.eligius1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("Elig: " & Me.txtEligiusUserHash.Text)
        End If

        If ValidatePool(enPool.ltcrabbit1) = True Then
            If sbTemp.Length <> 0 Then sbTemp.Append(vbCrLf)

            sbTemp.Append("LTCR: " & Me.txtLTCRabbitUserHash.Text)
        End If

        If sbTemp.Length > 63 Then
            sbTemp.Remove(63, sbTemp.Length - 63)
        End If

        Me.NotifyIcon1.Text = sbTemp.ToString

    End Sub

    Private Sub mnuShow_Click(sender As Object, e As System.EventArgs) Handles mnuShow.Click

        Me.Show()
        Me.Focus()

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As System.EventArgs) Handles mnuExit.Click

        Me.NotifyIcon1.Visible = False
        My.Application.DoEvents()

        End

    End Sub

    Private Sub mnuMainExit_Click(sender As Object, e As System.EventArgs) Handles mnuMainExit.Click

        mnuExit_Click(sender, e)

    End Sub

    Private Sub frmMain_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

        With My.Computer.Registry
            .CurrentUser.CreateSubKey(csRegKey)
            .SetValue("HKEY_CURRENT_USER\" & csRegKey, "Width", Me.Width, Microsoft.Win32.RegistryValueKind.DWord)
            .SetValue("HKEY_CURRENT_USER\" & csRegKey, "Height", Me.Height, Microsoft.Win32.RegistryValueKind.DWord)
        End With

    End Sub

    Private Sub dataGrid_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs)

        Dim dt As DataGridView

        dt = DirectCast(sender, DataGridView)

        With My.Computer.Registry
            .CurrentUser.CreateSubKey(csRegKey & "\Columns\" & dt.Name)
            .SetValue("HKEY_CURRENT_USER\" & csRegKey & "\Columns\" & dt.Name, e.Column.Name, e.Column.Width, Microsoft.Win32.RegistryValueKind.DWord)
        End With

    End Sub

    Private Sub cmbRefreshRate_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbConfigRefreshRate.KeyPress

        e.Handled = True

    End Sub

    Private Sub cmbRefreshRate_Leave(sender As Object, e As System.EventArgs) Handles cmbConfigRefreshRate.Leave

        If String.IsNullOrEmpty(Me.cmbConfigRefreshRate.Text) = True Then
            Me.cmbConfigRefreshRate.Text = "1 minute"
        End If

    End Sub

    Private Sub cmbRefreshRate_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbConfigRefreshRate.SelectedIndexChanged

        Select Case Me.cmbConfigRefreshRate.Text
            Case "5 minutes"
                iRefreshRate = 300
                iRefresh = 300

            Case "10 minutes"
                iRefreshRate = 600
                iRefresh = 600

            Case "15 minutes"
                iRefreshRate = 900
                iRefresh = 900

            Case "30 minutes"
                iRefreshRate = 1800
                iRefresh = 1800

            Case "60 minutes"
                iRefreshRate = 3600
                iRefresh = 3600

            Case Else
                iRefresh = 300

        End Select

    End Sub

    Private Sub timer_start_Tick(sender As Object, e As System.EventArgs) Handles timer_start.Tick

        Me.timer_start.Enabled = False
        Me.timer_CountDown.Enabled = True

        Call cmdRefresh_Click(Nothing, Nothing)

        bRunning = True

    End Sub

    Private Sub WebClientDownloadCompletedHandler(sender As Object, e As System.Net.DownloadStringCompletedEventArgs)

        Dim wc As System.Net.WebClient
        Dim CurrentPool As enPool

        wc = DirectCast(sender, System.Net.WebClient)
        CurrentPool = DirectCast(e.UserState, enPool)

        If e.Cancelled = False Then
            If e.Error Is Nothing Then
                Call HandlePoolResponse(e.Result, CurrentPool)
            Else
                Debug.Print(e.Error.Message)

                Select Case CurrentPool
                    Case enPool.eclipse1
                        Me.txtEclUserHashRate.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtEclUserHashRate, e.Error.Message)

                    Case enPool.eclipse2
                        Me.txtEclUserHashRate.Text = "WC:API ERROR3"
                        Me.ToolTip1.SetToolTip(Me.txtEclUserHashRate, e.Error.Message)

                    Case enPool.f50btc
                        Me.txt50UserHashRate.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txt50UserHashRate, e.Error.Message)

                    Case enPool.ozcoin
                        Me.txtOzUserHashRate.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtOzUserHashRate, e.Error.Message)

                    Case enPool.p2pool1
                        Me.txtp2pUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtp2pUserHash, e.Error.Message)

                    Case enPool.p2pool2
                        Me.txtp2pUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtp2pUserHash, e.Error.Message)

                    Case enPool.p2pool3
                        Me.txtp2pUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtp2pUserHash, e.Error.Message)

                    Case enPool.p2pool4
                        Me.txtp2pUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtp2pUserHash, e.Error.Message)

                    Case enPool.bitminter1
                        If e.Error.Message = "The remote server returned an error: (401) Unauthorized." Then
                            Me.txtBitMinterUserHash.Text = "CHECK API KEY"
                        Else
                            Me.txtBitMinterUserHash.Text = "WC:API ERROR2"
                        End If

                        Me.ToolTip1.SetToolTip(Me.txtBitMinterUserHash, e.Error.Message)

                    Case enPool.bitminter2
                        Me.txtBitMinterUserHash.Text = "WC:API ERROR3"
                        Me.ToolTip1.SetToolTip(Me.txtBitMinterUserHash, e.Error.Message)

                    Case enPool.btcguild
                        Me.txtBTCGuildUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtBTCGuildUserHash, e.Error.Message)

                    Case enPool.slush
                        If e.Error.Message = "The remote server returned an error: (401) Unauthorized." Then
                            Me.txtSlushUserHash.Text = "CHECK API KEY"
                        Else
                            Me.txtSlushUserHash.Text = "WC:API ERROR2"
                        End If

                        Me.ToolTip1.SetToolTip(Me.txtSlushUserHash, e.Error.Message)

                    Case enPool.multipool1
                        Me.txtMultipoolUserHashRate.Text = "WC:API ERROR"
                        Me.ToolTip1.SetToolTip(Me.txtMultipoolUserHashRate, e.Error.Message)

                    Case enPool.blockchaininfo
                        Me.txtBCI_AsOfTimestamp.Text = "WC ERROR: " & e.Error.Message

                    Case enPool.scryptguild1
                        Me.txtScryptGuildUserHash.Text = "WC:API ERROR"
                        Me.ToolTip1.SetToolTip(Me.txtScryptGuildUserHash, e.Error.Message)

                    Case enPool.eligius1
                        Me.txtEligiusUserHash.Text = "WC:API ERROR1"
                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, e.Error.Message)

                    Case enPool.eligius2
                        Me.txtEligiusUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, e.Error.Message)

                    Case enPool.eligius3
                        Me.txtEligiusUserHash.Text = "WC:API ERROR3"
                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, e.Error.Message)

                    Case enPool.eligius4
                        Me.txtEligiusUserHash.Text = "WC:API ERROR4"
                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, e.Error.Message)

                    Case enPool.eligius5
                        Me.txtEligiusUserHash.Text = "WC:API ERROR5"
                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, e.Error.Message)

                    Case enPool.eligius6
                        Me.txtEligiusUserHash.Text = "WC:API ERROR6"
                        Me.ToolTip1.SetToolTip(Me.txtEligiusUserHash, e.Error.Message)

                    Case enPool.ltcrabbit1
                        Me.txtLTCRabbitUserHash.Text = "WC:API ERROR1"
                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, e.Error.Message)

                    Case enPool.ltcrabbit2
                        Me.txtLTCRabbitUserHash.Text = "WC:API ERROR2"
                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, e.Error.Message)

                    Case enPool.ltcrabbit3
                        Me.txtLTCRabbitUserHash.Text = "WC:API ERROR3"
                        Me.ToolTip1.SetToolTip(Me.txtLTCRabbitUserHash, e.Error.Message)

                End Select
            End If
        End If

        RemoveHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
        wc.Dispose()

    End Sub

    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click

        Call RefreshPools()

        'start the clock over again
        Call cmbRefreshRate_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub RefreshPools()

        Dim wc As System.Net.WebClient
        Dim sTemp As String
        Static bRefreshing As Boolean
        Dim curPool As enPool

        If bRefreshing = True Then
            Exit Sub
        End If

        Try
            bRefreshing = True

            'Dim a As New System.Net.Configuration.SettingsSection
            'Dim aNetAssembly As System.Reflection.Assembly = Reflection.Assembly.GetAssembly(a.GetType)
            'Dim aSettingsType As Type = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal")
            'Dim args As Object()
            'Dim anInstance As Object = aSettingsType.InvokeMember("Section", BindingFlags.Static Or BindingFlags.GetProperty Or BindingFlags.NonPublic, Nothing, Nothing, args)
            'Dim aUseUnsafeHeaderParsing As FieldInfo = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic Or BindingFlags.Instance)

            'aUseUnsafeHeaderParsing.SetValue(anInstance, True)

            curPool = enPool.f50btc

            If ValidatePool(enPool.f50btc) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New Uri("https://50btc.com/api/" & Me.txt50BTCAPIKey.Text), enPool.f50btc)
            End If

            curPool = enPool.eclipse1

            If ValidatePool(enPool.eclipse1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New Uri("https://eclipsemc.com/api.php?key=" & Me.txtEclipseAPIKey.Text & "&action=poolstats"), enPool.eclipse1)

                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New Uri("https://eclipsemc.com/api.php?key=" & Me.txtEclipseAPIKey.Text & "&action=userstats"), enPool.eclipse2)
            End If

            curPool = enPool.ozcoin

            If ValidatePool(enPool.ozcoin) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New Uri("http://ozco.in/api.php?api_key=" & Me.txtOzcoinAPIKey.Text), enPool.ozcoin)
            End If

            curPool = enPool.p2pool1

            If ValidatePool(enPool.p2pool1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri(Me.txtP2PoolURL.Text & "/global_stats"), enPool.p2pool2)
            End If

            curPool = enPool.bitminter1

            If ValidatePool(enPool.bitminter1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.Headers.Add("Authorization: key=" & Me.txtBitMinterAPIKey.Text)
                wc.DownloadStringAsync(New System.Uri("https://bitminter.com/api/users"), enPool.bitminter1)

                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.Headers.Add("Authorization: key=" & Me.txtBitMinterAPIKey.Text)
                wc.DownloadStringAsync(New System.Uri("https://bitminter.com/api/pool/round"), enPool.bitminter2)
            End If

            curPool = enPool.btcguild

            If ValidatePool(enPool.btcguild) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri("https://www.btcguild.com/api.php?api_key=" & Me.txtBTCGuildAPIKey.Text), enPool.btcguild)
            End If

            curPool = enPool.slush

            If ValidatePool(enPool.slush) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri("https://mining.bitcoin.cz/accounts/profile/json/" & Me.txtSlushAPIKey.Text), enPool.slush)
            End If

            curPool = enPool.multipool1

            If ValidatePool(enPool.multipool1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri("http://api.multipool.us/api.php?api_key=" & Me.txtMultipoolAPIKey.Text), enPool.multipool1)
            End If

            curPool = enPool.scryptguild1

            If ValidatePool(enPool.scryptguild1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler

                If Me.chkScryptGuildShowBalanceData.Checked = True AndAlso Me.chkScryptGuildShowWorkerData.Checked = True Then
                    sTemp = "http://www.scryptguild.com/api.php?api_key=" & Me.txtScryptGuildAPIKey.Text & "&balances=all&workers=all"
                ElseIf Me.chkScryptGuildShowBalanceData.Checked = True AndAlso Me.chkScryptGuildShowWorkerData.Checked = False Then
                    sTemp = "http://www.scryptguild.com/api.php?api_key=" & Me.txtScryptGuildAPIKey.Text & "&balances=all"
                ElseIf Me.chkScryptGuildShowBalanceData.Checked = False AndAlso Me.chkScryptGuildShowWorkerData.Checked = True Then
                    sTemp = "http://www.scryptguild.com/api.php?api_key=" & Me.txtScryptGuildAPIKey.Text & "&workers=all"
                End If

                wc.DownloadStringAsync(New System.Uri(sTemp), enPool.scryptguild1)
            End If

            curPool = enPool.eligius1

            If ValidatePool(enPool.eligius1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri("http://eligius.st/~wizkid057/newstats/api.php?cmd=gethashrate&username=" & Me.txtEligiusBTCAddress.Text), enPool.eligius1)
            End If

            curPool = enPool.ltcrabbit1

            If ValidatePool(enPool.ltcrabbit1) = True Then
                wc = New System.Net.WebClient
                AddHandler wc.DownloadStringCompleted, AddressOf Me.WebClientDownloadCompletedHandler
                wc.DownloadStringAsync(New System.Uri("https://www.ltcrabbit.com/index.php?page=api&action=getuserstatus&api_key=" & Me.txtLTCRabbitAPIKey.Text), enPool.ltcrabbit1)
            End If
        Catch ex As Exception When bErrorHandle = True
            Me.txtTotalHash.Text = "ERROR WITH" & curPool.ToString

            Me.ToolTip1.SetToolTip(Me.txtTotalHash, "An error has occurred when submitting the API request for " & curPool.ToString & ".  If this continues, you may want to disable this pool and contact the author.")
        Finally
            bRefreshing = False
        End Try

    End Sub

    Private Function FormatHashRate(ByVal dHashRate As Double) As String

        Dim sTemp As String

        Select Case dHashRate
            Case 0
                sTemp = "ZERO"

            Case Is < 0.001
                sTemp = Format(dHashRate * 1000000, "###.##") & " H/s"

            Case Is < 1
                sTemp = Format(dHashRate * 1000, "###.##") & " KH/s"

            Case Is < 1000
                sTemp = Format(dHashRate, "###.##") & " MH/s"

            Case Is < 1000000
                sTemp = Format(dHashRate / 1000, "###.##") & " GH/s"

            Case Is < 1000000000
                sTemp = Format(dHashRate / 1000000, "###.##") & " TH/s"

            Case Is < 1000000000000
                sTemp = Format(dHashRate / 1000000000, "###.##") & " PH/s"

            Case Is < 1000000000000000
                sTemp = Format(dHashRate / 1000000000000, "###.##") & " EH/s"

            Case Is < 1000000000000000000
                sTemp = Format(dHashRate / 1000000000000000, "###.##") & " ZH/s"

            Case Else
                sTemp = "UNKNOWN (BFH?)"

        End Select

        'Debug.Print(dHashRate & ": " & sTemp)

        Return sTemp

    End Function

    Private Function FormatHashRate(ByVal sHashRate As String) As String

        Return FormatHashRate(Val(sHashRate))

    End Function

    Private Function FormatTimeSpan(ByVal ts As TimeSpan) As String

        Return Format(ts.Days, "0d") & " " & Format(ts.Hours, "0h") & " " & Format(ts.Minutes, "0m") & " " & Format(ts.Seconds, "0s")

    End Function

    Private Function Format1970Date(ByVal iSeconds As UInt32) As TimeSpan

        Return Now.Subtract(DateFrom1970(iSeconds).ToLocalTime)

    End Function

    Private Function DateFrom1970(ByVal iSeconds As UInt32) As Date

        Return New DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(iSeconds)

    End Function

    Private Sub cmdSendTestEMail_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendTestEMail.Click

        If String.IsNullOrEmpty(Me.txtSMTPAlertSubject.Text) = True Then
            Call SendEMail("Worker 'TEST' on pool 'TEST' has been idle for 5+ minutes.", "Worker 'TEST' on pool 'TEST' has been idle for 5+ minutes.")
        Else
            Call SendEMail("Worker 'TEST' on pool 'TEST' has been idle for 5+ minutes.", Me.txtSMTPAlertSubject.Text)
        End If

    End Sub

    Private Sub SendEMail(ByVal sBody As String, ByVal sSubject As String)

        Dim SMTP As System.Net.Mail.SmtpClient
        Dim MSGfrom, MSGto As System.Net.Mail.MailAddress
        Dim MSG As System.Net.Mail.MailMessage

        SMTP = New System.Net.Mail.SmtpClient(Me.txtSMTPServer.Text, Me.txtSMTPPort.Text)

        SMTP.UseDefaultCredentials = False
        SMTP.Credentials = New System.Net.NetworkCredential(Me.txtSMTPUserName.Text, Me.txtSMTPPassword.Text)
        SMTP.EnableSsl = Me.chkSMTPSSL.Checked
        SMTP.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

        If String.IsNullOrEmpty(Me.txtSMTPAlertName.Text) = True Then
            MSGto = New System.Net.Mail.MailAddress(Me.txtSMTPAlertAddress.Text, Me.txtSMTPAlertAddress.Text, System.Text.Encoding.UTF8)
        Else
            MSGto = New System.Net.Mail.MailAddress(Me.txtSMTPAlertAddress.Text, Me.txtSMTPAlertName.Text, System.Text.Encoding.UTF8)
        End If

        If String.IsNullOrEmpty(Me.txtSMTPFromName.Text) = True Then
            MSGfrom = New System.Net.Mail.MailAddress(Me.txtSMTPFromAddress.Text, Me.txtSMTPFromAddress.Text, System.Text.Encoding.UTF8)
        Else
            MSGfrom = New System.Net.Mail.MailAddress(Me.txtSMTPFromAddress.Text, Me.txtSMTPFromName.Text, System.Text.Encoding.UTF8)
        End If

        MSG = New System.Net.Mail.MailMessage(MSGfrom, MSGto)
        MSG.Body = sBody
        MSG.BodyEncoding = System.Text.Encoding.UTF8

        MSG.Subject = sSubject
        MSG.SubjectEncoding = System.Text.Encoding.UTF8

        AddHandler SMTP.SendCompleted, AddressOf HandleEMailResponse

        SMTP.SendAsync(MSG, SMTP)

    End Sub

    Private Sub TabEnabled_CheckedChanged(sender As Object, e As System.EventArgs)

        Dim chkAny As CheckBox
        Dim pd As clsPoolData

        chkAny = DirectCast(sender, CheckBox)

        For x As enPool = 0 To PoolData.GetUpperBound(0)
            pd = PoolData(x)

            If pd.chkEnabled IsNot Nothing AndAlso pd.chkEnabled.Name = chkAny.Name Then
                If chkAny.Checked = True Then
                    Call ShowTab(x)
                Else
                    Call HideTab(x)

                    pd.dSHA256TotalHashRate = 0
                    pd.dScryptTotalHashRate = 0
                End If
            End If
        Next

    End Sub

    Private Sub HideTab(ByVal pool As enPool)

        Me.tabsHidden.TabPages.Add(Me.tabsShown.TabPages(PoolData(pool).sTabName))
        Me.tabsShown.TabPages.RemoveByKey(PoolData(pool).sTabName)

    End Sub

    Private Sub ShowTab(ByVal pool As enPool)

        Me.tabsShown.TabPages.Insert(ReturnTabPosition(PoolData(pool).sTabLabel), Me.tabsHidden.TabPages(PoolData(pool).sTabName))
        Me.tabsHidden.TabPages.RemoveByKey(PoolData(pool).sTabName)

    End Sub

    ''' <summary>
    ''' Returns the position a tab should be in based on it's label
    ''' </summary>
    ''' <param name="sTabLabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReturnTabPosition(ByVal sTabLabel As String) As Integer

        Dim x As Integer

        If Me.tabsShown.TabPages.Count = 1 Then
            Return 0
        End If

        For x = 0 To Me.tabsShown.TabPages.Count - 1
            If Me.tabsShown.TabPages(x).Text.ToLower.Chars(0) > sTabLabel.ToLower.Chars(0) Then
                Return x
            ElseIf Me.tabsShown.TabPages(x).Text.ToLower.Chars(0) = sTabLabel.ToLower.Chars(0) Then
                If Me.tabsShown.TabPages(x).Text.ToLower.Chars(1) > sTabLabel.ToLower.Chars(1) Then
                    Return x
                End If
            End If
        Next

        Return x - 1

    End Function

    Private Sub chkScryptGuildShowBalanceData_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkScryptGuildShowBalanceData.CheckedChanged

        Me.lblScryptGuildConfirmedBTC.Visible = Me.chkScryptGuildShowBalanceData.Checked
        Me.txtScryptGuildConfirmedBTC.Visible = Me.chkScryptGuildShowBalanceData.Checked

    End Sub

    Private Sub cmdIdleStartAppFinder_Click(sender As System.Object, e As System.EventArgs) Handles cmdIdleStartAppFinder.Click

        Dim dlg As OpenFileDialog

        dlg = New OpenFileDialog

        dlg.InitialDirectory = "c:\"
        dlg.ShowDialog()

        If String.IsNullOrEmpty(dlg.FileName) = True Then Exit Sub

        Me.txtIdleStartAppName.Text = dlg.FileName

    End Sub

    'if already running, forces the other one to come to the foreground
    Public Sub HandlesAlreadyRunning(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

        e.BringToForeground = True

    End Sub

    Private Sub chkIdlePopup_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIdlePopup.CheckedChanged

        Me.chkIdleWorkPopUpWithBeeps.Visible = Me.chkIdlePopup.Checked

    End Sub

    Private Sub cmbBCIc_HashRate_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBCIc_HashRate.KeyPress

        e.Handled = True

    End Sub

    Private Sub cmdBCIc_CalcSave_Click(sender As Object, e As System.EventArgs) Handles cmdBCIc_CalcSave.Click

        Call ShowTotalHashRate(True)

    End Sub

    Private Sub txtBCIc_PeriodInDays_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBCIc_PeriodInDays.TextChanged

        If Val(Me.txtBCIc_PeriodInDays.Text) > 1 Then
            Me.lblBCIc_Days.Text = "days, assuming"
        Else
            Me.lblBCIc_Days.Text = "day, assuming"
        End If

    End Sub
End Class
