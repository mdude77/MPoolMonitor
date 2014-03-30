<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.timer_CountDown = New System.Windows.Forms.Timer(Me.components)
        Me.tabsShown = New System.Windows.Forms.TabControl()
        Me.tab50BTC = New System.Windows.Forms.TabPage()
        Me.txtPleaseSupport = New System.Windows.Forms.TextBox()
        Me.txt50UserHashRate = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txt50ConfirmedBTC = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.data50btc = New System.Windows.Forms.DataGridView()
        Me.txt50CompletedPayouts = New System.Windows.Forms.TextBox()
        Me.tabBitMinter = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtBitMinterNMCBalance = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtBitMinterBTCBalance = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtBitMinterUserHash = New System.Windows.Forms.TextBox()
        Me.txtBitMinterUserShiftRejected = New System.Windows.Forms.TextBox()
        Me.txtBitMinterBTCRoundDuration = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtBitMinterNMCEfficiency = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtBitMinterNMCRoundShares = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtBitMinterNMCRoundDuration = New System.Windows.Forms.TextBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtBitMinterUserShiftScore = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtBitMinterUserShiftAccepted = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtBitMinterBTCEfficiency = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.txtBitMinterBTCRoundShares = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.txtBitMinterPoolHash = New System.Windows.Forms.TextBox()
        Me.txtBitMinterShiftDuration = New System.Windows.Forms.TextBox()
        Me.txtBitMinterShiftScore = New System.Windows.Forms.TextBox()
        Me.dataBitMinter = New System.Windows.Forms.DataGridView()
        Me.tabBlockchainInfo = New System.Windows.Forms.TabPage()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.txtBCI_NextDifficultyChangeBlocks = New System.Windows.Forms.TextBox()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.txtBCI_EstimatedNextDifficulty = New System.Windows.Forms.TextBox()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.txtBCI_AsOfTimestamp = New System.Windows.Forms.TextBox()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.txtBCI_Difficulty = New System.Windows.Forms.TextBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.txtBCI_NetworkHashRate = New System.Windows.Forms.TextBox()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.txtBCI_MarketPriceUSD = New System.Windows.Forms.TextBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.txtBCI_MinsBetweenBlocks = New System.Windows.Forms.TextBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.txtBCI_NextDifficultyChangeTime = New System.Windows.Forms.TextBox()
        Me.tabBTCGuild = New System.Windows.Forms.TabPage()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtBTCGuild24HourBTCPayout = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtBTCGuildUserHash = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.dataBTCGuild = New System.Windows.Forms.DataGridView()
        Me.txtBTCGuildPoolHashrate = New System.Windows.Forms.TextBox()
        Me.txtBTCGuildPendingBTCPayout = New System.Windows.Forms.TextBox()
        Me.txtBTCGuildPendingNMCPayout = New System.Windows.Forms.TextBox()
        Me.tabEclipse = New System.Windows.Forms.TabPage()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtEclAvgSharesBlock = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtEclUserHashRate = New System.Windows.Forms.TextBox()
        Me.txtEclUnconfirmedBTC = New System.Windows.Forms.TextBox()
        Me.txtEclBTCRoundDuration = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtEclBlocksFound = New System.Windows.Forms.TextBox()
        Me.txtEclConfirmedBTC = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtEclBTCRoundShares = New System.Windows.Forms.TextBox()
        Me.dataEclipse = New System.Windows.Forms.DataGridView()
        Me.txtEclPoolHashrate = New System.Windows.Forms.TextBox()
        Me.txtEclEstimatedRewards = New System.Windows.Forms.TextBox()
        Me.txtEclTotalPayout = New System.Windows.Forms.TextBox()
        Me.tabEligius = New System.Windows.Forms.TabPage()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.txtEligiusLast90DaysLuck = New System.Windows.Forms.TextBox()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.txtEligiusLast30DaysLuck = New System.Windows.Forms.TextBox()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.txtEligiusLast7DaysLuck = New System.Windows.Forms.TextBox()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.txtEligiusLast24HourLuck = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.txtEligiusLast12HourLuck = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.txtEligiusLast10BlockLuck = New System.Windows.Forms.TextBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.txtEligiusPayoutQueuePositions = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.txtEligiusEstimatedBalance = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.txtEligiusBalanceLastBlock = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtEligiusPoolHash256 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.dataEligius = New System.Windows.Forms.DataGridView()
        Me.txtEligiusUserHash = New System.Windows.Forms.TextBox()
        Me.tabOzcoin = New System.Windows.Forms.TabPage()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtOzUserHashRate = New System.Windows.Forms.TextBox()
        Me.txtOzPendingPayoutPPS = New System.Windows.Forms.TextBox()
        Me.txtOzBTCRoundDuration = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOZPOTTotalShares = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOZPOT_PPSEquivalent = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOZPOTHighestShare = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOzPOTPendingPayout = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtOzPendingPayoutDGM = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOzBTCEfficiency = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOzBTCRoundShares = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dataOz = New System.Windows.Forms.DataGridView()
        Me.txtOzPoolHashrate = New System.Windows.Forms.TextBox()
        Me.txtOzEstimatedPayout = New System.Windows.Forms.TextBox()
        Me.txtOzCompletedPayout = New System.Windows.Forms.TextBox()
        Me.tabLTCRabbit = New System.Windows.Forms.TabPage()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.txtLTCRabbitPoolhash = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.txtLTCRabbitUserHash = New System.Windows.Forms.TextBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.txtLTCRabbitConfirmedLTC = New System.Windows.Forms.TextBox()
        Me.dataLTCRabbit = New System.Windows.Forms.DataGridView()
        Me.tabMultipool = New System.Windows.Forms.TabPage()
        Me.tabMultiDataGrids = New System.Windows.Forms.TabControl()
        Me.tabCoinData = New System.Windows.Forms.TabPage()
        Me.dataMultiCoinData = New System.Windows.Forms.DataGridView()
        Me.tabWorkerData = New System.Windows.Forms.TabPage()
        Me.dataMultiWorkerData = New System.Windows.Forms.DataGridView()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.txtMultipoolUserHashRate = New System.Windows.Forms.TextBox()
        Me.tabP2pool = New System.Windows.Forms.TabPage()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.txtP2PIdealPayout = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtP2pPeers = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtP2pBlockValue = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtP2pPoolDifficulty = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.dataP2pool = New System.Windows.Forms.DataGridView()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtp2pUserHash = New System.Windows.Forms.TextBox()
        Me.txtP2pOrphanedShares = New System.Windows.Forms.TextBox()
        Me.txtP2pRoundDuration = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtP2pUpTime = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtP2pUserEfficiency = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtP2pUserStaleRate = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtP2pDeadShares = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtP2pTotalShares = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtP2pPoolStaleRate = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtP2pPoolHashRate = New System.Windows.Forms.TextBox()
        Me.txtP2pPayout = New System.Windows.Forms.TextBox()
        Me.tabScryptGuild = New System.Windows.Forms.TabPage()
        Me.lblScryptGuildConfirmedBTC = New System.Windows.Forms.Label()
        Me.txtScryptGuildConfirmedBTC = New System.Windows.Forms.TextBox()
        Me.txtScryptGuildUserHash = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabWorkerInfo = New System.Windows.Forms.TabPage()
        Me.dataScryptGuildWorkerData = New System.Windows.Forms.DataGridView()
        Me.tabBalances = New System.Windows.Forms.TabPage()
        Me.dataScryptGuildBalanceData = New System.Windows.Forms.DataGridView()
        Me.tabSlush = New System.Windows.Forms.TabPage()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtSlushUserHash = New System.Windows.Forms.TextBox()
        Me.txtSlushUnconfirmedPayout = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.dataSlush = New System.Windows.Forms.DataGridView()
        Me.txtSlushEstimatedPayout = New System.Windows.Forms.TextBox()
        Me.txtSlushConfirmedPayout = New System.Windows.Forms.TextBox()
        Me.tabConfigure = New System.Windows.Forms.TabPage()
        Me.menuStripMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMainExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.tabConfiguration = New System.Windows.Forms.TabControl()
        Me.tabConfigure50BTC = New System.Windows.Forms.TabPage()
        Me.chk50BTCEnabled = New System.Windows.Forms.CheckBox()
        Me.txt50BTCAPIKey = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabConfigureBitMinter = New System.Windows.Forms.TabPage()
        Me.chkBitMinterShowWorkerTotals = New System.Windows.Forms.CheckBox()
        Me.chkBitMinterShowWorkerCheckPoint = New System.Windows.Forms.CheckBox()
        Me.chkBitMinterEnabled = New System.Windows.Forms.CheckBox()
        Me.txtBitMinterAPIKey = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.tabConfigBlockChainInfo = New System.Windows.Forms.TabPage()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.cmbBlockChainInfoRefreshRate = New System.Windows.Forms.ComboBox()
        Me.chkBlockChainInfoEnabled = New System.Windows.Forms.CheckBox()
        Me.tabConfigureBTCGuild = New System.Windows.Forms.TabPage()
        Me.chkBTCGuildEnabled = New System.Windows.Forms.CheckBox()
        Me.txtBTCGuildAPIKey = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.tabConfigureEclipse = New System.Windows.Forms.TabPage()
        Me.chkEclipseEnabled = New System.Windows.Forms.CheckBox()
        Me.txtEclipseAPIKey = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tabConfigureEligius = New System.Windows.Forms.TabPage()
        Me.chkEligiusEnabled = New System.Windows.Forms.CheckBox()
        Me.txtEligiusBTCAddress = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tabConfigureLTCRabbit = New System.Windows.Forms.TabPage()
        Me.chkLTCRabbitEnabled = New System.Windows.Forms.CheckBox()
        Me.txtLTCRabbitAPIKey = New System.Windows.Forms.TextBox()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.tabConfigureMultipool = New System.Windows.Forms.TabPage()
        Me.chkMultipoolEnabled = New System.Windows.Forms.CheckBox()
        Me.txtMultipoolAPIKey = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tabConfigureOzcoin = New System.Windows.Forms.TabPage()
        Me.chkOzcoinEnabled = New System.Windows.Forms.CheckBox()
        Me.txtOzcoinAPIKey = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tabConfigureP2Pool = New System.Windows.Forms.TabPage()
        Me.chkP2PPublicPool = New System.Windows.Forms.CheckBox()
        Me.chkP2PoolScrypt = New System.Windows.Forms.CheckBox()
        Me.txtP2PoolBTCAddy = New System.Windows.Forms.TextBox()
        Me.txtP2PoolURL = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkP2PoolEnabled = New System.Windows.Forms.CheckBox()
        Me.tabConfigureScryptGuild = New System.Windows.Forms.TabPage()
        Me.chkScryptGuildOmitTinyBalances = New System.Windows.Forms.CheckBox()
        Me.chkScryptGuildShowBalanceData = New System.Windows.Forms.CheckBox()
        Me.chkScryptGuildShowWorkerData = New System.Windows.Forms.CheckBox()
        Me.chkScryptGuildEnabled = New System.Windows.Forms.CheckBox()
        Me.txtScryptGuildAPIKey = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tabConfigureSlush = New System.Windows.Forms.TabPage()
        Me.chkSlushEnabled = New System.Windows.Forms.CheckBox()
        Me.txtSlushAPIKey = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.tabIdleWorkers = New System.Windows.Forms.TabPage()
        Me.chkIdleWorkPopUpWithBeeps = New System.Windows.Forms.CheckBox()
        Me.chkIdleStartApp = New System.Windows.Forms.CheckBox()
        Me.chkIdlePopup = New System.Windows.Forms.CheckBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tabIdleUserProcess = New System.Windows.Forms.TabPage()
        Me.cmdIdleStartAppFinder = New System.Windows.Forms.Button()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtIdleStartAppName = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtIdleStartParms = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.tabIdleEmail = New System.Windows.Forms.TabPage()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.txtSMTPServer = New System.Windows.Forms.TextBox()
        Me.cmdSendTestEMail = New System.Windows.Forms.Button()
        Me.txtSMTPPort = New System.Windows.Forms.TextBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.txtSMTPUserName = New System.Windows.Forms.TextBox()
        Me.txtSMTPFromName = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.txtSMTPPassword = New System.Windows.Forms.TextBox()
        Me.txtSMTPFromAddress = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.chkSMTPSSL = New System.Windows.Forms.CheckBox()
        Me.txtSMTPAlertAddress = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.txtSMTPAlertSubject = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.txtSMTPAlertName = New System.Windows.Forms.TextBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.chkIdleEMailAlerts = New System.Windows.Forms.CheckBox()
        Me.chkConfigStoreDBStatistics = New System.Windows.Forms.CheckBox()
        Me.tabsHidden = New System.Windows.Forms.TabControl()
        Me.chkConfigAlwaysOnTop = New System.Windows.Forms.CheckBox()
        Me.chkConfigAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbConfigRefreshRate = New System.Windows.Forms.ComboBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.menuStripNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.txtTotalHash = New System.Windows.Forms.TextBox()
        Me.timer_start = New System.Windows.Forms.Timer(Me.components)
        Me.tabsShown.SuspendLayout()
        Me.tab50BTC.SuspendLayout()
        CType(Me.data50btc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBitMinter.SuspendLayout()
        CType(Me.dataBitMinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBlockchainInfo.SuspendLayout()
        Me.tabBTCGuild.SuspendLayout()
        CType(Me.dataBTCGuild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEclipse.SuspendLayout()
        CType(Me.dataEclipse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEligius.SuspendLayout()
        CType(Me.dataEligius, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOzcoin.SuspendLayout()
        CType(Me.dataOz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLTCRabbit.SuspendLayout()
        CType(Me.dataLTCRabbit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMultipool.SuspendLayout()
        Me.tabMultiDataGrids.SuspendLayout()
        Me.tabCoinData.SuspendLayout()
        CType(Me.dataMultiCoinData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWorkerData.SuspendLayout()
        CType(Me.dataMultiWorkerData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabP2pool.SuspendLayout()
        CType(Me.dataP2pool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabScryptGuild.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabWorkerInfo.SuspendLayout()
        CType(Me.dataScryptGuildWorkerData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBalances.SuspendLayout()
        CType(Me.dataScryptGuildBalanceData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSlush.SuspendLayout()
        CType(Me.dataSlush, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConfigure.SuspendLayout()
        Me.menuStripMain.SuspendLayout()
        Me.tabConfiguration.SuspendLayout()
        Me.tabConfigure50BTC.SuspendLayout()
        Me.tabConfigureBitMinter.SuspendLayout()
        Me.tabConfigBlockChainInfo.SuspendLayout()
        Me.tabConfigureBTCGuild.SuspendLayout()
        Me.tabConfigureEclipse.SuspendLayout()
        Me.tabConfigureEligius.SuspendLayout()
        Me.tabConfigureLTCRabbit.SuspendLayout()
        Me.tabConfigureMultipool.SuspendLayout()
        Me.tabConfigureOzcoin.SuspendLayout()
        Me.tabConfigureP2Pool.SuspendLayout()
        Me.tabConfigureScryptGuild.SuspendLayout()
        Me.tabConfigureSlush.SuspendLayout()
        Me.tabIdleWorkers.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tabIdleUserProcess.SuspendLayout()
        Me.tabIdleEmail.SuspendLayout()
        Me.menuStripNotifyIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'timer_CountDown
        '
        Me.timer_CountDown.Interval = 1000
        '
        'tabsShown
        '
        Me.tabsShown.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabsShown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabsShown.Controls.Add(Me.tab50BTC)
        Me.tabsShown.Controls.Add(Me.tabBitMinter)
        Me.tabsShown.Controls.Add(Me.tabBlockchainInfo)
        Me.tabsShown.Controls.Add(Me.tabBTCGuild)
        Me.tabsShown.Controls.Add(Me.tabEclipse)
        Me.tabsShown.Controls.Add(Me.tabEligius)
        Me.tabsShown.Controls.Add(Me.tabOzcoin)
        Me.tabsShown.Controls.Add(Me.tabLTCRabbit)
        Me.tabsShown.Controls.Add(Me.tabMultipool)
        Me.tabsShown.Controls.Add(Me.tabP2pool)
        Me.tabsShown.Controls.Add(Me.tabScryptGuild)
        Me.tabsShown.Controls.Add(Me.tabSlush)
        Me.tabsShown.Controls.Add(Me.tabConfigure)
        Me.tabsShown.Location = New System.Drawing.Point(2, 49)
        Me.tabsShown.Name = "tabsShown"
        Me.tabsShown.SelectedIndex = 0
        Me.tabsShown.Size = New System.Drawing.Size(673, 523)
        Me.tabsShown.TabIndex = 35
        '
        'tab50BTC
        '
        Me.tab50BTC.Controls.Add(Me.txtPleaseSupport)
        Me.tab50BTC.Controls.Add(Me.txt50UserHashRate)
        Me.tab50BTC.Controls.Add(Me.Label45)
        Me.tab50BTC.Controls.Add(Me.Label49)
        Me.tab50BTC.Controls.Add(Me.txt50ConfirmedBTC)
        Me.tab50BTC.Controls.Add(Me.Label51)
        Me.tab50BTC.Controls.Add(Me.data50btc)
        Me.tab50BTC.Controls.Add(Me.txt50CompletedPayouts)
        Me.tab50BTC.Location = New System.Drawing.Point(4, 4)
        Me.tab50BTC.Name = "tab50BTC"
        Me.tab50BTC.Size = New System.Drawing.Size(665, 490)
        Me.tab50BTC.TabIndex = 3
        Me.tab50BTC.Text = "50BTC"
        Me.tab50BTC.UseVisualStyleBackColor = True
        '
        'txtPleaseSupport
        '
        Me.txtPleaseSupport.Location = New System.Drawing.Point(8, 63)
        Me.txtPleaseSupport.Name = "txtPleaseSupport"
        Me.txtPleaseSupport.ReadOnly = True
        Me.txtPleaseSupport.Size = New System.Drawing.Size(614, 27)
        Me.txtPleaseSupport.TabIndex = 99
        Me.txtPleaseSupport.TabStop = False
        Me.txtPleaseSupport.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'txt50UserHashRate
        '
        Me.txt50UserHashRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt50UserHashRate.Location = New System.Drawing.Point(10, 6)
        Me.txt50UserHashRate.Name = "txt50UserHashRate"
        Me.txt50UserHashRate.ReadOnly = True
        Me.txt50UserHashRate.Size = New System.Drawing.Size(294, 49)
        Me.txt50UserHashRate.TabIndex = 93
        Me.txt50UserHashRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(310, 30)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(143, 20)
        Me.Label45.TabIndex = 75
        Me.Label45.Text = "Completed payout"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.ForeColor = System.Drawing.Color.Red
        Me.Label49.Location = New System.Drawing.Point(311, 3)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(125, 20)
        Me.Label49.TabIndex = 79
        Me.Label49.Text = "Confirmed BTC"
        '
        'txt50ConfirmedBTC
        '
        Me.txt50ConfirmedBTC.Location = New System.Drawing.Point(478, 3)
        Me.txt50ConfirmedBTC.Name = "txt50ConfirmedBTC"
        Me.txt50ConfirmedBTC.ReadOnly = True
        Me.txt50ConfirmedBTC.Size = New System.Drawing.Size(144, 27)
        Me.txt50ConfirmedBTC.TabIndex = 87
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(315, 204)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(0, 20)
        Me.Label51.TabIndex = 81
        '
        'data50btc
        '
        Me.data50btc.AllowUserToAddRows = False
        Me.data50btc.AllowUserToDeleteRows = False
        Me.data50btc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.data50btc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data50btc.Location = New System.Drawing.Point(7, 94)
        Me.data50btc.Name = "data50btc"
        Me.data50btc.ReadOnly = True
        Me.data50btc.RowTemplate.Height = 24
        Me.data50btc.Size = New System.Drawing.Size(628, 389)
        Me.data50btc.TabIndex = 73
        '
        'txt50CompletedPayouts
        '
        Me.txt50CompletedPayouts.Location = New System.Drawing.Point(478, 30)
        Me.txt50CompletedPayouts.Name = "txt50CompletedPayouts"
        Me.txt50CompletedPayouts.ReadOnly = True
        Me.txt50CompletedPayouts.Size = New System.Drawing.Size(144, 27)
        Me.txt50CompletedPayouts.TabIndex = 83
        '
        'tabBitMinter
        '
        Me.tabBitMinter.Controls.Add(Me.TextBox1)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterNMCBalance)
        Me.tabBitMinter.Controls.Add(Me.Label62)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterBTCBalance)
        Me.tabBitMinter.Controls.Add(Me.Label75)
        Me.tabBitMinter.Controls.Add(Me.Label76)
        Me.tabBitMinter.Controls.Add(Me.Label59)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterUserHash)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterUserShiftRejected)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterBTCRoundDuration)
        Me.tabBitMinter.Controls.Add(Me.Label63)
        Me.tabBitMinter.Controls.Add(Me.Label64)
        Me.tabBitMinter.Controls.Add(Me.Label65)
        Me.tabBitMinter.Controls.Add(Me.Label66)
        Me.tabBitMinter.Controls.Add(Me.Label67)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterNMCEfficiency)
        Me.tabBitMinter.Controls.Add(Me.Label68)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterNMCRoundShares)
        Me.tabBitMinter.Controls.Add(Me.Label69)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterNMCRoundDuration)
        Me.tabBitMinter.Controls.Add(Me.Label70)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterUserShiftScore)
        Me.tabBitMinter.Controls.Add(Me.Label71)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterUserShiftAccepted)
        Me.tabBitMinter.Controls.Add(Me.Label72)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterBTCEfficiency)
        Me.tabBitMinter.Controls.Add(Me.Label73)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterBTCRoundShares)
        Me.tabBitMinter.Controls.Add(Me.Label74)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterPoolHash)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterShiftDuration)
        Me.tabBitMinter.Controls.Add(Me.txtBitMinterShiftScore)
        Me.tabBitMinter.Controls.Add(Me.dataBitMinter)
        Me.tabBitMinter.Location = New System.Drawing.Point(4, 4)
        Me.tabBitMinter.Name = "tabBitMinter"
        Me.tabBitMinter.Size = New System.Drawing.Size(665, 490)
        Me.tabBitMinter.TabIndex = 5
        Me.tabBitMinter.Text = "BitMinter"
        Me.tabBitMinter.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 228)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(614, 27)
        Me.TextBox1.TabIndex = 70
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'txtBitMinterNMCBalance
        '
        Me.txtBitMinterNMCBalance.Location = New System.Drawing.Point(478, 30)
        Me.txtBitMinterNMCBalance.Name = "txtBitMinterNMCBalance"
        Me.txtBitMinterNMCBalance.ReadOnly = True
        Me.txtBitMinterNMCBalance.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterNMCBalance.TabIndex = 11
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.ForeColor = System.Drawing.Color.Red
        Me.Label62.Location = New System.Drawing.Point(311, 3)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(106, 20)
        Me.Label62.TabIndex = 67
        Me.Label62.Text = "BTC balance"
        '
        'txtBitMinterBTCBalance
        '
        Me.txtBitMinterBTCBalance.Location = New System.Drawing.Point(478, 3)
        Me.txtBitMinterBTCBalance.Name = "txtBitMinterBTCBalance"
        Me.txtBitMinterBTCBalance.ReadOnly = True
        Me.txtBitMinterBTCBalance.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterBTCBalance.TabIndex = 4
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(314, 235)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(0, 20)
        Me.Label75.TabIndex = 68
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(311, 30)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(110, 20)
        Me.Label76.TabIndex = 69
        Me.Label76.Text = "NMC balance"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(310, 90)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(147, 20)
        Me.Label59.TabIndex = 64
        Me.Label59.Text = "User shift rejected"
        '
        'txtBitMinterUserHash
        '
        Me.txtBitMinterUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBitMinterUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtBitMinterUserHash.Name = "txtBitMinterUserHash"
        Me.txtBitMinterUserHash.ReadOnly = True
        Me.txtBitMinterUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtBitMinterUserHash.TabIndex = 0
        Me.txtBitMinterUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBitMinterUserShiftRejected
        '
        Me.txtBitMinterUserShiftRejected.Location = New System.Drawing.Point(478, 90)
        Me.txtBitMinterUserShiftRejected.Name = "txtBitMinterUserShiftRejected"
        Me.txtBitMinterUserShiftRejected.ReadOnly = True
        Me.txtBitMinterUserShiftRejected.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterUserShiftRejected.TabIndex = 9
        '
        'txtBitMinterBTCRoundDuration
        '
        Me.txtBitMinterBTCRoundDuration.Location = New System.Drawing.Point(160, 145)
        Me.txtBitMinterBTCRoundDuration.Name = "txtBitMinterBTCRoundDuration"
        Me.txtBitMinterBTCRoundDuration.ReadOnly = True
        Me.txtBitMinterBTCRoundDuration.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterBTCRoundDuration.TabIndex = 5
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(7, 63)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(108, 20)
        Me.Label63.TabIndex = 39
        Me.Label63.Text = "Shift duration"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(7, 90)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(90, 20)
        Me.Label64.TabIndex = 40
        Me.Label64.Text = "Shift score"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(7, 117)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(112, 20)
        Me.Label65.TabIndex = 41
        Me.Label65.Text = "Pool hashrate"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(7, 145)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(155, 20)
        Me.Label66.TabIndex = 42
        Me.Label66.Text = "BTC round duration"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(7, 172)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(146, 20)
        Me.Label67.TabIndex = 43
        Me.Label67.Text = "BTC round shares"
        '
        'txtBitMinterNMCEfficiency
        '
        Me.txtBitMinterNMCEfficiency.Location = New System.Drawing.Point(478, 199)
        Me.txtBitMinterNMCEfficiency.Name = "txtBitMinterNMCEfficiency"
        Me.txtBitMinterNMCEfficiency.ReadOnly = True
        Me.txtBitMinterNMCEfficiency.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterNMCEfficiency.TabIndex = 14
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(7, 199)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(119, 20)
        Me.Label68.TabIndex = 44
        Me.Label68.Text = "BTC efficiency"
        '
        'txtBitMinterNMCRoundShares
        '
        Me.txtBitMinterNMCRoundShares.Location = New System.Drawing.Point(478, 172)
        Me.txtBitMinterNMCRoundShares.Name = "txtBitMinterNMCRoundShares"
        Me.txtBitMinterNMCRoundShares.ReadOnly = True
        Me.txtBitMinterNMCRoundShares.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterNMCRoundShares.TabIndex = 13
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(310, 63)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(155, 20)
        Me.Label69.TabIndex = 45
        Me.Label69.Text = "User shift accepted"
        '
        'txtBitMinterNMCRoundDuration
        '
        Me.txtBitMinterNMCRoundDuration.Location = New System.Drawing.Point(478, 145)
        Me.txtBitMinterNMCRoundDuration.Name = "txtBitMinterNMCRoundDuration"
        Me.txtBitMinterNMCRoundDuration.ReadOnly = True
        Me.txtBitMinterNMCRoundDuration.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterNMCRoundDuration.TabIndex = 12
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(310, 117)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(129, 20)
        Me.Label70.TabIndex = 46
        Me.Label70.Text = "User shift score"
        '
        'txtBitMinterUserShiftScore
        '
        Me.txtBitMinterUserShiftScore.Location = New System.Drawing.Point(478, 117)
        Me.txtBitMinterUserShiftScore.Name = "txtBitMinterUserShiftScore"
        Me.txtBitMinterUserShiftScore.ReadOnly = True
        Me.txtBitMinterUserShiftScore.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterUserShiftScore.TabIndex = 10
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(310, 145)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(159, 20)
        Me.Label71.TabIndex = 47
        Me.Label71.Text = "NMC round duration"
        '
        'txtBitMinterUserShiftAccepted
        '
        Me.txtBitMinterUserShiftAccepted.Location = New System.Drawing.Point(478, 63)
        Me.txtBitMinterUserShiftAccepted.Name = "txtBitMinterUserShiftAccepted"
        Me.txtBitMinterUserShiftAccepted.ReadOnly = True
        Me.txtBitMinterUserShiftAccepted.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterUserShiftAccepted.TabIndex = 8
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(310, 172)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(150, 20)
        Me.Label72.TabIndex = 48
        Me.Label72.Text = "NMC round shares"
        '
        'txtBitMinterBTCEfficiency
        '
        Me.txtBitMinterBTCEfficiency.Location = New System.Drawing.Point(160, 199)
        Me.txtBitMinterBTCEfficiency.Name = "txtBitMinterBTCEfficiency"
        Me.txtBitMinterBTCEfficiency.ReadOnly = True
        Me.txtBitMinterBTCEfficiency.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterBTCEfficiency.TabIndex = 7
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(314, 204)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(0, 20)
        Me.Label73.TabIndex = 49
        '
        'txtBitMinterBTCRoundShares
        '
        Me.txtBitMinterBTCRoundShares.Location = New System.Drawing.Point(160, 172)
        Me.txtBitMinterBTCRoundShares.Name = "txtBitMinterBTCRoundShares"
        Me.txtBitMinterBTCRoundShares.ReadOnly = True
        Me.txtBitMinterBTCRoundShares.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterBTCRoundShares.TabIndex = 6
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(310, 199)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(123, 20)
        Me.Label74.TabIndex = 50
        Me.Label74.Text = "NMC efficiency"
        '
        'txtBitMinterPoolHash
        '
        Me.txtBitMinterPoolHash.Location = New System.Drawing.Point(160, 117)
        Me.txtBitMinterPoolHash.Name = "txtBitMinterPoolHash"
        Me.txtBitMinterPoolHash.ReadOnly = True
        Me.txtBitMinterPoolHash.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterPoolHash.TabIndex = 3
        '
        'txtBitMinterShiftDuration
        '
        Me.txtBitMinterShiftDuration.Location = New System.Drawing.Point(160, 63)
        Me.txtBitMinterShiftDuration.Name = "txtBitMinterShiftDuration"
        Me.txtBitMinterShiftDuration.ReadOnly = True
        Me.txtBitMinterShiftDuration.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterShiftDuration.TabIndex = 1
        '
        'txtBitMinterShiftScore
        '
        Me.txtBitMinterShiftScore.Location = New System.Drawing.Point(160, 90)
        Me.txtBitMinterShiftScore.Name = "txtBitMinterShiftScore"
        Me.txtBitMinterShiftScore.ReadOnly = True
        Me.txtBitMinterShiftScore.Size = New System.Drawing.Size(144, 27)
        Me.txtBitMinterShiftScore.TabIndex = 2
        '
        'dataBitMinter
        '
        Me.dataBitMinter.AllowUserToAddRows = False
        Me.dataBitMinter.AllowUserToDeleteRows = False
        Me.dataBitMinter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataBitMinter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataBitMinter.Location = New System.Drawing.Point(7, 261)
        Me.dataBitMinter.Name = "dataBitMinter"
        Me.dataBitMinter.ReadOnly = True
        Me.dataBitMinter.RowTemplate.Height = 24
        Me.dataBitMinter.Size = New System.Drawing.Size(628, 226)
        Me.dataBitMinter.TabIndex = 38
        '
        'tabBlockchainInfo
        '
        Me.tabBlockchainInfo.Controls.Add(Me.TextBox9)
        Me.tabBlockchainInfo.Controls.Add(Me.Label113)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_NextDifficultyChangeBlocks)
        Me.tabBlockchainInfo.Controls.Add(Me.Label112)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_EstimatedNextDifficulty)
        Me.tabBlockchainInfo.Controls.Add(Me.Label111)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_AsOfTimestamp)
        Me.tabBlockchainInfo.Controls.Add(Me.Label110)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_Difficulty)
        Me.tabBlockchainInfo.Controls.Add(Me.Label109)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_NetworkHashRate)
        Me.tabBlockchainInfo.Controls.Add(Me.Label108)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_MarketPriceUSD)
        Me.tabBlockchainInfo.Controls.Add(Me.Label107)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_MinsBetweenBlocks)
        Me.tabBlockchainInfo.Controls.Add(Me.Label105)
        Me.tabBlockchainInfo.Controls.Add(Me.txtBCI_NextDifficultyChangeTime)
        Me.tabBlockchainInfo.Location = New System.Drawing.Point(4, 4)
        Me.tabBlockchainInfo.Name = "tabBlockchainInfo"
        Me.tabBlockchainInfo.Size = New System.Drawing.Size(665, 490)
        Me.tabBlockchainInfo.TabIndex = 9
        Me.tabBlockchainInfo.Text = "Blockchain.info"
        Me.tabBlockchainInfo.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(8, 270)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(618, 27)
        Me.TextBox9.TabIndex = 91
        Me.TextBox9.TabStop = False
        Me.TextBox9.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.Location = New System.Drawing.Point(6, 193)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(108, 20)
        Me.Label113.TabIndex = 89
        Me.Label113.Text = "... In x Blocks"
        '
        'txtBCI_NextDifficultyChangeBlocks
        '
        Me.txtBCI_NextDifficultyChangeBlocks.Location = New System.Drawing.Point(192, 193)
        Me.txtBCI_NextDifficultyChangeBlocks.Name = "txtBCI_NextDifficultyChangeBlocks"
        Me.txtBCI_NextDifficultyChangeBlocks.ReadOnly = True
        Me.txtBCI_NextDifficultyChangeBlocks.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_NextDifficultyChangeBlocks.TabIndex = 90
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Location = New System.Drawing.Point(6, 163)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(148, 20)
        Me.Label112.TabIndex = 87
        Me.Label112.Text = "Est. Next Difficulty"
        '
        'txtBCI_EstimatedNextDifficulty
        '
        Me.txtBCI_EstimatedNextDifficulty.Location = New System.Drawing.Point(192, 163)
        Me.txtBCI_EstimatedNextDifficulty.Name = "txtBCI_EstimatedNextDifficulty"
        Me.txtBCI_EstimatedNextDifficulty.ReadOnly = True
        Me.txtBCI_EstimatedNextDifficulty.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_EstimatedNextDifficulty.TabIndex = 88
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Location = New System.Drawing.Point(6, 10)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(136, 20)
        Me.Label111.TabIndex = 85
        Me.Label111.Text = "As of Timestamp"
        '
        'txtBCI_AsOfTimestamp
        '
        Me.txtBCI_AsOfTimestamp.Location = New System.Drawing.Point(192, 10)
        Me.txtBCI_AsOfTimestamp.Name = "txtBCI_AsOfTimestamp"
        Me.txtBCI_AsOfTimestamp.ReadOnly = True
        Me.txtBCI_AsOfTimestamp.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_AsOfTimestamp.TabIndex = 86
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Location = New System.Drawing.Point(6, 133)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(136, 20)
        Me.Label110.TabIndex = 83
        Me.Label110.Text = "Current Difficulty"
        '
        'txtBCI_Difficulty
        '
        Me.txtBCI_Difficulty.Location = New System.Drawing.Point(192, 133)
        Me.txtBCI_Difficulty.Name = "txtBCI_Difficulty"
        Me.txtBCI_Difficulty.ReadOnly = True
        Me.txtBCI_Difficulty.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_Difficulty.TabIndex = 84
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(6, 103)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(155, 20)
        Me.Label109.TabIndex = 81
        Me.Label109.Text = "Network Hash Rate"
        '
        'txtBCI_NetworkHashRate
        '
        Me.txtBCI_NetworkHashRate.Location = New System.Drawing.Point(192, 103)
        Me.txtBCI_NetworkHashRate.Name = "txtBCI_NetworkHashRate"
        Me.txtBCI_NetworkHashRate.ReadOnly = True
        Me.txtBCI_NetworkHashRate.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_NetworkHashRate.TabIndex = 82
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(6, 73)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(145, 20)
        Me.Label108.TabIndex = 79
        Me.Label108.Text = "Market Price USD"
        '
        'txtBCI_MarketPriceUSD
        '
        Me.txtBCI_MarketPriceUSD.Location = New System.Drawing.Point(192, 73)
        Me.txtBCI_MarketPriceUSD.Name = "txtBCI_MarketPriceUSD"
        Me.txtBCI_MarketPriceUSD.ReadOnly = True
        Me.txtBCI_MarketPriceUSD.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_MarketPriceUSD.TabIndex = 80
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(6, 46)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(171, 20)
        Me.Label107.TabIndex = 77
        Me.Label107.Text = "Mins Between Blocks"
        '
        'txtBCI_MinsBetweenBlocks
        '
        Me.txtBCI_MinsBetweenBlocks.Location = New System.Drawing.Point(192, 43)
        Me.txtBCI_MinsBetweenBlocks.Name = "txtBCI_MinsBetweenBlocks"
        Me.txtBCI_MinsBetweenBlocks.ReadOnly = True
        Me.txtBCI_MinsBetweenBlocks.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_MinsBetweenBlocks.TabIndex = 78
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(6, 226)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(152, 20)
        Me.Label105.TabIndex = 73
        Me.Label105.Text = "... At Approximately"
        '
        'txtBCI_NextDifficultyChangeTime
        '
        Me.txtBCI_NextDifficultyChangeTime.Location = New System.Drawing.Point(192, 223)
        Me.txtBCI_NextDifficultyChangeTime.Name = "txtBCI_NextDifficultyChangeTime"
        Me.txtBCI_NextDifficultyChangeTime.ReadOnly = True
        Me.txtBCI_NextDifficultyChangeTime.Size = New System.Drawing.Size(246, 27)
        Me.txtBCI_NextDifficultyChangeTime.TabIndex = 74
        '
        'tabBTCGuild
        '
        Me.tabBTCGuild.Controls.Add(Me.Label36)
        Me.tabBTCGuild.Controls.Add(Me.txtBTCGuild24HourBTCPayout)
        Me.tabBTCGuild.Controls.Add(Me.TextBox2)
        Me.tabBTCGuild.Controls.Add(Me.txtBTCGuildUserHash)
        Me.tabBTCGuild.Controls.Add(Me.Label80)
        Me.tabBTCGuild.Controls.Add(Me.Label81)
        Me.tabBTCGuild.Controls.Add(Me.Label82)
        Me.tabBTCGuild.Controls.Add(Me.dataBTCGuild)
        Me.tabBTCGuild.Controls.Add(Me.txtBTCGuildPoolHashrate)
        Me.tabBTCGuild.Controls.Add(Me.txtBTCGuildPendingBTCPayout)
        Me.tabBTCGuild.Controls.Add(Me.txtBTCGuildPendingNMCPayout)
        Me.tabBTCGuild.Location = New System.Drawing.Point(4, 4)
        Me.tabBTCGuild.Name = "tabBTCGuild"
        Me.tabBTCGuild.Size = New System.Drawing.Size(665, 490)
        Me.tabBTCGuild.TabIndex = 6
        Me.tabBTCGuild.Text = "BTCGuild"
        Me.tabBTCGuild.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(311, 63)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(158, 20)
        Me.Label36.TabIndex = 67
        Me.Label36.Text = "24 hour BTC payout"
        '
        'txtBTCGuild24HourBTCPayout
        '
        Me.txtBTCGuild24HourBTCPayout.Location = New System.Drawing.Point(478, 63)
        Me.txtBTCGuild24HourBTCPayout.Name = "txtBTCGuild24HourBTCPayout"
        Me.txtBTCGuild24HourBTCPayout.ReadOnly = True
        Me.txtBTCGuild24HourBTCPayout.Size = New System.Drawing.Size(142, 27)
        Me.txtBTCGuild24HourBTCPayout.TabIndex = 68
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(8, 96)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(614, 27)
        Me.TextBox2.TabIndex = 66
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'txtBTCGuildUserHash
        '
        Me.txtBTCGuildUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBTCGuildUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtBTCGuildUserHash.Name = "txtBTCGuildUserHash"
        Me.txtBTCGuildUserHash.ReadOnly = True
        Me.txtBTCGuildUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtBTCGuildUserHash.TabIndex = 65
        Me.txtBTCGuildUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.ForeColor = System.Drawing.Color.Red
        Me.Label80.Location = New System.Drawing.Point(310, 3)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(162, 20)
        Me.Label80.TabIndex = 38
        Me.Label80.Text = "Pending BTC payout"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(310, 31)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(166, 20)
        Me.Label81.TabIndex = 39
        Me.Label81.Text = "Pending NMC payout"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(7, 63)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(112, 20)
        Me.Label82.TabIndex = 40
        Me.Label82.Text = "Pool hashrate"
        '
        'dataBTCGuild
        '
        Me.dataBTCGuild.AllowUserToAddRows = False
        Me.dataBTCGuild.AllowUserToDeleteRows = False
        Me.dataBTCGuild.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataBTCGuild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataBTCGuild.Location = New System.Drawing.Point(7, 129)
        Me.dataBTCGuild.Name = "dataBTCGuild"
        Me.dataBTCGuild.ReadOnly = True
        Me.dataBTCGuild.RowHeadersVisible = False
        Me.dataBTCGuild.RowTemplate.Height = 24
        Me.dataBTCGuild.Size = New System.Drawing.Size(628, 358)
        Me.dataBTCGuild.TabIndex = 37
        '
        'txtBTCGuildPoolHashrate
        '
        Me.txtBTCGuildPoolHashrate.Location = New System.Drawing.Point(183, 63)
        Me.txtBTCGuildPoolHashrate.Name = "txtBTCGuildPoolHashrate"
        Me.txtBTCGuildPoolHashrate.ReadOnly = True
        Me.txtBTCGuildPoolHashrate.Size = New System.Drawing.Size(121, 27)
        Me.txtBTCGuildPoolHashrate.TabIndex = 52
        '
        'txtBTCGuildPendingBTCPayout
        '
        Me.txtBTCGuildPendingBTCPayout.Location = New System.Drawing.Point(478, 3)
        Me.txtBTCGuildPendingBTCPayout.Name = "txtBTCGuildPendingBTCPayout"
        Me.txtBTCGuildPendingBTCPayout.ReadOnly = True
        Me.txtBTCGuildPendingBTCPayout.Size = New System.Drawing.Size(142, 27)
        Me.txtBTCGuildPendingBTCPayout.TabIndex = 50
        '
        'txtBTCGuildPendingNMCPayout
        '
        Me.txtBTCGuildPendingNMCPayout.Location = New System.Drawing.Point(478, 30)
        Me.txtBTCGuildPendingNMCPayout.Name = "txtBTCGuildPendingNMCPayout"
        Me.txtBTCGuildPendingNMCPayout.ReadOnly = True
        Me.txtBTCGuildPendingNMCPayout.Size = New System.Drawing.Size(142, 27)
        Me.txtBTCGuildPendingNMCPayout.TabIndex = 51
        '
        'tabEclipse
        '
        Me.tabEclipse.Controls.Add(Me.TextBox3)
        Me.tabEclipse.Controls.Add(Me.Label35)
        Me.tabEclipse.Controls.Add(Me.Label26)
        Me.tabEclipse.Controls.Add(Me.Label25)
        Me.tabEclipse.Controls.Add(Me.Label32)
        Me.tabEclipse.Controls.Add(Me.txtEclAvgSharesBlock)
        Me.tabEclipse.Controls.Add(Me.Label24)
        Me.tabEclipse.Controls.Add(Me.txtEclUserHashRate)
        Me.tabEclipse.Controls.Add(Me.txtEclUnconfirmedBTC)
        Me.tabEclipse.Controls.Add(Me.txtEclBTCRoundDuration)
        Me.tabEclipse.Controls.Add(Me.Label27)
        Me.tabEclipse.Controls.Add(Me.Label28)
        Me.tabEclipse.Controls.Add(Me.Label29)
        Me.tabEclipse.Controls.Add(Me.Label30)
        Me.tabEclipse.Controls.Add(Me.Label31)
        Me.tabEclipse.Controls.Add(Me.Label33)
        Me.tabEclipse.Controls.Add(Me.Label34)
        Me.tabEclipse.Controls.Add(Me.txtEclBlocksFound)
        Me.tabEclipse.Controls.Add(Me.txtEclConfirmedBTC)
        Me.tabEclipse.Controls.Add(Me.Label37)
        Me.tabEclipse.Controls.Add(Me.txtEclBTCRoundShares)
        Me.tabEclipse.Controls.Add(Me.dataEclipse)
        Me.tabEclipse.Controls.Add(Me.txtEclPoolHashrate)
        Me.tabEclipse.Controls.Add(Me.txtEclEstimatedRewards)
        Me.tabEclipse.Controls.Add(Me.txtEclTotalPayout)
        Me.tabEclipse.Location = New System.Drawing.Point(4, 4)
        Me.tabEclipse.Name = "tabEclipse"
        Me.tabEclipse.Size = New System.Drawing.Size(665, 490)
        Me.tabEclipse.TabIndex = 2
        Me.tabEclipse.Text = "Eclipse"
        Me.tabEclipse.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(8, 229)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(614, 27)
        Me.TextBox3.TabIndex = 73
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(315, 208)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(165, 20)
        Me.Label35.TabIndex = 72
        Me.Label35.Text = "LShare = Last Share"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(315, 188)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(187, 20)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "TShares = Total Shares"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(315, 168)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(200, 20)
        Me.Label25.TabIndex = 70
        Me.Label25.Text = "RShares = Round Shares"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(7, 198)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(137, 20)
        Me.Label32.TabIndex = 66
        Me.Label32.Text = "Avg shares/block"
        '
        'txtEclAvgSharesBlock
        '
        Me.txtEclAvgSharesBlock.Location = New System.Drawing.Point(160, 198)
        Me.txtEclAvgSharesBlock.Name = "txtEclAvgSharesBlock"
        Me.txtEclAvgSharesBlock.ReadOnly = True
        Me.txtEclAvgSharesBlock.Size = New System.Drawing.Size(144, 27)
        Me.txtEclAvgSharesBlock.TabIndex = 67
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(311, 63)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(143, 20)
        Me.Label24.TabIndex = 63
        Me.Label24.Text = "Unconfirmed BTC"
        '
        'txtEclUserHashRate
        '
        Me.txtEclUserHashRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEclUserHashRate.Location = New System.Drawing.Point(10, 6)
        Me.txtEclUserHashRate.Name = "txtEclUserHashRate"
        Me.txtEclUserHashRate.ReadOnly = True
        Me.txtEclUserHashRate.Size = New System.Drawing.Size(294, 49)
        Me.txtEclUserHashRate.TabIndex = 65
        Me.txtEclUserHashRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEclUnconfirmedBTC
        '
        Me.txtEclUnconfirmedBTC.Location = New System.Drawing.Point(478, 63)
        Me.txtEclUnconfirmedBTC.Name = "txtEclUnconfirmedBTC"
        Me.txtEclUnconfirmedBTC.ReadOnly = True
        Me.txtEclUnconfirmedBTC.Size = New System.Drawing.Size(144, 27)
        Me.txtEclUnconfirmedBTC.TabIndex = 64
        '
        'txtEclBTCRoundDuration
        '
        Me.txtEclBTCRoundDuration.Location = New System.Drawing.Point(160, 144)
        Me.txtEclBTCRoundDuration.Name = "txtEclBTCRoundDuration"
        Me.txtEclBTCRoundDuration.ReadOnly = True
        Me.txtEclBTCRoundDuration.Size = New System.Drawing.Size(144, 27)
        Me.txtEclBTCRoundDuration.TabIndex = 53
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(7, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(138, 20)
        Me.Label27.TabIndex = 38
        Me.Label27.Text = "Estimated payout"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(7, 90)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(143, 20)
        Me.Label28.TabIndex = 39
        Me.Label28.Text = "Completed payout"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(7, 117)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 20)
        Me.Label29.TabIndex = 40
        Me.Label29.Text = "Pool hashrate"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(7, 144)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(155, 20)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "BTC round duration"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(7, 171)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(146, 20)
        Me.Label31.TabIndex = 42
        Me.Label31.Text = "BTC round shares"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Red
        Me.Label33.Location = New System.Drawing.Point(311, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(125, 20)
        Me.Label33.TabIndex = 44
        Me.Label33.Text = "Confirmed BTC"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(311, 90)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(106, 20)
        Me.Label34.TabIndex = 45
        Me.Label34.Text = "Blocks found"
        '
        'txtEclBlocksFound
        '
        Me.txtEclBlocksFound.Location = New System.Drawing.Point(478, 90)
        Me.txtEclBlocksFound.Name = "txtEclBlocksFound"
        Me.txtEclBlocksFound.ReadOnly = True
        Me.txtEclBlocksFound.Size = New System.Drawing.Size(144, 27)
        Me.txtEclBlocksFound.TabIndex = 57
        '
        'txtEclConfirmedBTC
        '
        Me.txtEclConfirmedBTC.Location = New System.Drawing.Point(478, 3)
        Me.txtEclConfirmedBTC.Name = "txtEclConfirmedBTC"
        Me.txtEclConfirmedBTC.ReadOnly = True
        Me.txtEclConfirmedBTC.Size = New System.Drawing.Size(144, 27)
        Me.txtEclConfirmedBTC.TabIndex = 56
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(315, 204)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(0, 20)
        Me.Label37.TabIndex = 48
        '
        'txtEclBTCRoundShares
        '
        Me.txtEclBTCRoundShares.Location = New System.Drawing.Point(160, 171)
        Me.txtEclBTCRoundShares.Name = "txtEclBTCRoundShares"
        Me.txtEclBTCRoundShares.ReadOnly = True
        Me.txtEclBTCRoundShares.Size = New System.Drawing.Size(144, 27)
        Me.txtEclBTCRoundShares.TabIndex = 54
        '
        'dataEclipse
        '
        Me.dataEclipse.AllowUserToAddRows = False
        Me.dataEclipse.AllowUserToDeleteRows = False
        Me.dataEclipse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataEclipse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataEclipse.Location = New System.Drawing.Point(7, 262)
        Me.dataEclipse.Name = "dataEclipse"
        Me.dataEclipse.ReadOnly = True
        Me.dataEclipse.RowHeadersVisible = False
        Me.dataEclipse.RowTemplate.Height = 24
        Me.dataEclipse.Size = New System.Drawing.Size(628, 225)
        Me.dataEclipse.TabIndex = 37
        '
        'txtEclPoolHashrate
        '
        Me.txtEclPoolHashrate.Location = New System.Drawing.Point(160, 117)
        Me.txtEclPoolHashrate.Name = "txtEclPoolHashrate"
        Me.txtEclPoolHashrate.ReadOnly = True
        Me.txtEclPoolHashrate.Size = New System.Drawing.Size(144, 27)
        Me.txtEclPoolHashrate.TabIndex = 52
        '
        'txtEclEstimatedRewards
        '
        Me.txtEclEstimatedRewards.Location = New System.Drawing.Point(160, 63)
        Me.txtEclEstimatedRewards.Name = "txtEclEstimatedRewards"
        Me.txtEclEstimatedRewards.ReadOnly = True
        Me.txtEclEstimatedRewards.Size = New System.Drawing.Size(144, 27)
        Me.txtEclEstimatedRewards.TabIndex = 50
        '
        'txtEclTotalPayout
        '
        Me.txtEclTotalPayout.Location = New System.Drawing.Point(160, 90)
        Me.txtEclTotalPayout.Name = "txtEclTotalPayout"
        Me.txtEclTotalPayout.ReadOnly = True
        Me.txtEclTotalPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtEclTotalPayout.TabIndex = 51
        '
        'tabEligius
        '
        Me.tabEligius.Controls.Add(Me.Label117)
        Me.tabEligius.Controls.Add(Me.txtEligiusLast90DaysLuck)
        Me.tabEligius.Controls.Add(Me.Label118)
        Me.tabEligius.Controls.Add(Me.txtEligiusLast30DaysLuck)
        Me.tabEligius.Controls.Add(Me.Label115)
        Me.tabEligius.Controls.Add(Me.txtEligiusLast7DaysLuck)
        Me.tabEligius.Controls.Add(Me.Label116)
        Me.tabEligius.Controls.Add(Me.txtEligiusLast24HourLuck)
        Me.tabEligius.Controls.Add(Me.Label88)
        Me.tabEligius.Controls.Add(Me.txtEligiusLast12HourLuck)
        Me.tabEligius.Controls.Add(Me.Label87)
        Me.tabEligius.Controls.Add(Me.txtEligiusLast10BlockLuck)
        Me.tabEligius.Controls.Add(Me.Label114)
        Me.tabEligius.Controls.Add(Me.txtEligiusPayoutQueuePositions)
        Me.tabEligius.Controls.Add(Me.Label104)
        Me.tabEligius.Controls.Add(Me.txtEligiusEstimatedBalance)
        Me.tabEligius.Controls.Add(Me.Label86)
        Me.tabEligius.Controls.Add(Me.txtEligiusBalanceLastBlock)
        Me.tabEligius.Controls.Add(Me.Label50)
        Me.tabEligius.Controls.Add(Me.txtEligiusPoolHash256)
        Me.tabEligius.Controls.Add(Me.TextBox11)
        Me.tabEligius.Controls.Add(Me.dataEligius)
        Me.tabEligius.Controls.Add(Me.txtEligiusUserHash)
        Me.tabEligius.Location = New System.Drawing.Point(4, 4)
        Me.tabEligius.Name = "tabEligius"
        Me.tabEligius.Size = New System.Drawing.Size(665, 490)
        Me.tabEligius.TabIndex = 11
        Me.tabEligius.Text = "Eligius"
        Me.tabEligius.UseVisualStyleBackColor = True
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Location = New System.Drawing.Point(311, 145)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(140, 20)
        Me.Label117.TabIndex = 115
        Me.Label117.Text = "Last 90 days luck"
        '
        'txtEligiusLast90DaysLuck
        '
        Me.txtEligiusLast90DaysLuck.Location = New System.Drawing.Point(477, 145)
        Me.txtEligiusLast90DaysLuck.Name = "txtEligiusLast90DaysLuck"
        Me.txtEligiusLast90DaysLuck.ReadOnly = True
        Me.txtEligiusLast90DaysLuck.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusLast90DaysLuck.TabIndex = 116
        Me.ToolTip1.SetToolTip(Me.txtEligiusLast90DaysLuck, "All luck ratings except ""last 10 blocks"" requires DB stats to be enabled and work" & _
        "ing")
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Location = New System.Drawing.Point(7, 145)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(140, 20)
        Me.Label118.TabIndex = 113
        Me.Label118.Text = "Last 30 days luck"
        '
        'txtEligiusLast30DaysLuck
        '
        Me.txtEligiusLast30DaysLuck.Location = New System.Drawing.Point(160, 145)
        Me.txtEligiusLast30DaysLuck.Name = "txtEligiusLast30DaysLuck"
        Me.txtEligiusLast30DaysLuck.ReadOnly = True
        Me.txtEligiusLast30DaysLuck.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusLast30DaysLuck.TabIndex = 114
        Me.ToolTip1.SetToolTip(Me.txtEligiusLast30DaysLuck, "All luck ratings except ""last 10 blocks"" requires DB stats to be enabled and work" & _
        "ing")
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.Location = New System.Drawing.Point(311, 117)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(131, 20)
        Me.Label115.TabIndex = 111
        Me.Label115.Text = "Last 7 days luck"
        '
        'txtEligiusLast7DaysLuck
        '
        Me.txtEligiusLast7DaysLuck.Location = New System.Drawing.Point(477, 117)
        Me.txtEligiusLast7DaysLuck.Name = "txtEligiusLast7DaysLuck"
        Me.txtEligiusLast7DaysLuck.ReadOnly = True
        Me.txtEligiusLast7DaysLuck.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusLast7DaysLuck.TabIndex = 112
        Me.ToolTip1.SetToolTip(Me.txtEligiusLast7DaysLuck, "All luck ratings except ""last 10 blocks"" requires DB stats to be enabled and work" & _
        "ing")
        '
        'Label116
        '
        Me.Label116.AutoSize = True
        Me.Label116.Location = New System.Drawing.Point(7, 117)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(147, 20)
        Me.Label116.TabIndex = 109
        Me.Label116.Text = "Last 24 hours luck"
        '
        'txtEligiusLast24HourLuck
        '
        Me.txtEligiusLast24HourLuck.Location = New System.Drawing.Point(160, 117)
        Me.txtEligiusLast24HourLuck.Name = "txtEligiusLast24HourLuck"
        Me.txtEligiusLast24HourLuck.ReadOnly = True
        Me.txtEligiusLast24HourLuck.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusLast24HourLuck.TabIndex = 110
        Me.ToolTip1.SetToolTip(Me.txtEligiusLast24HourLuck, "All luck ratings except ""last 10 blocks"" requires DB stats to be enabled and work" & _
        "ing")
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(311, 90)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(147, 20)
        Me.Label88.TabIndex = 107
        Me.Label88.Text = "Last 12 hours luck"
        '
        'txtEligiusLast12HourLuck
        '
        Me.txtEligiusLast12HourLuck.Location = New System.Drawing.Point(477, 90)
        Me.txtEligiusLast12HourLuck.Name = "txtEligiusLast12HourLuck"
        Me.txtEligiusLast12HourLuck.ReadOnly = True
        Me.txtEligiusLast12HourLuck.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusLast12HourLuck.TabIndex = 108
        Me.ToolTip1.SetToolTip(Me.txtEligiusLast12HourLuck, "All luck ratings except ""last 10 blocks"" requires DB stats to be enabled and work" & _
        "ing")
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(7, 90)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(153, 20)
        Me.Label87.TabIndex = 105
        Me.Label87.Text = "Last 10 blocks luck"
        '
        'txtEligiusLast10BlockLuck
        '
        Me.txtEligiusLast10BlockLuck.Location = New System.Drawing.Point(160, 90)
        Me.txtEligiusLast10BlockLuck.Name = "txtEligiusLast10BlockLuck"
        Me.txtEligiusLast10BlockLuck.ReadOnly = True
        Me.txtEligiusLast10BlockLuck.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusLast10BlockLuck.TabIndex = 106
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Location = New System.Drawing.Point(311, 63)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(142, 20)
        Me.Label114.TabIndex = 103
        Me.Label114.Text = "Payout queue pos"
        '
        'txtEligiusPayoutQueuePositions
        '
        Me.txtEligiusPayoutQueuePositions.Location = New System.Drawing.Point(477, 63)
        Me.txtEligiusPayoutQueuePositions.Name = "txtEligiusPayoutQueuePositions"
        Me.txtEligiusPayoutQueuePositions.ReadOnly = True
        Me.txtEligiusPayoutQueuePositions.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusPayoutQueuePositions.TabIndex = 104
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(310, 30)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(121, 20)
        Me.Label104.TabIndex = 101
        Me.Label104.Text = "Estimated total"
        '
        'txtEligiusEstimatedBalance
        '
        Me.txtEligiusEstimatedBalance.Location = New System.Drawing.Point(478, 30)
        Me.txtEligiusEstimatedBalance.Name = "txtEligiusEstimatedBalance"
        Me.txtEligiusEstimatedBalance.ReadOnly = True
        Me.txtEligiusEstimatedBalance.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusEstimatedBalance.TabIndex = 102
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.ForeColor = System.Drawing.Color.Red
        Me.Label86.Location = New System.Drawing.Point(311, 3)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(146, 20)
        Me.Label86.TabIndex = 99
        Me.Label86.Text = "Balance last block"
        '
        'txtEligiusBalanceLastBlock
        '
        Me.txtEligiusBalanceLastBlock.Location = New System.Drawing.Point(478, 3)
        Me.txtEligiusBalanceLastBlock.Name = "txtEligiusBalanceLastBlock"
        Me.txtEligiusBalanceLastBlock.ReadOnly = True
        Me.txtEligiusBalanceLastBlock.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusBalanceLastBlock.TabIndex = 100
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(7, 63)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(112, 20)
        Me.Label50.TabIndex = 95
        Me.Label50.Text = "Pool hashrate"
        '
        'txtEligiusPoolHash256
        '
        Me.txtEligiusPoolHash256.Location = New System.Drawing.Point(160, 63)
        Me.txtEligiusPoolHash256.Name = "txtEligiusPoolHash256"
        Me.txtEligiusPoolHash256.ReadOnly = True
        Me.txtEligiusPoolHash256.Size = New System.Drawing.Size(144, 27)
        Me.txtEligiusPoolHash256.TabIndex = 98
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(8, 173)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(614, 27)
        Me.TextBox11.TabIndex = 94
        Me.TextBox11.TabStop = False
        Me.TextBox11.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'dataEligius
        '
        Me.dataEligius.AllowUserToAddRows = False
        Me.dataEligius.AllowUserToDeleteRows = False
        Me.dataEligius.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataEligius.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataEligius.Location = New System.Drawing.Point(7, 206)
        Me.dataEligius.Name = "dataEligius"
        Me.dataEligius.ReadOnly = True
        Me.dataEligius.RowHeadersVisible = False
        Me.dataEligius.RowTemplate.Height = 24
        Me.dataEligius.Size = New System.Drawing.Size(628, 281)
        Me.dataEligius.TabIndex = 93
        '
        'txtEligiusUserHash
        '
        Me.txtEligiusUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEligiusUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtEligiusUserHash.Name = "txtEligiusUserHash"
        Me.txtEligiusUserHash.ReadOnly = True
        Me.txtEligiusUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtEligiusUserHash.TabIndex = 92
        Me.txtEligiusUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabOzcoin
        '
        Me.tabOzcoin.Controls.Add(Me.TextBox4)
        Me.tabOzcoin.Controls.Add(Me.Label17)
        Me.tabOzcoin.Controls.Add(Me.txtOzUserHashRate)
        Me.tabOzcoin.Controls.Add(Me.txtOzPendingPayoutPPS)
        Me.tabOzcoin.Controls.Add(Me.txtOzBTCRoundDuration)
        Me.tabOzcoin.Controls.Add(Me.Label1)
        Me.tabOzcoin.Controls.Add(Me.Label2)
        Me.tabOzcoin.Controls.Add(Me.Label3)
        Me.tabOzcoin.Controls.Add(Me.Label4)
        Me.tabOzcoin.Controls.Add(Me.Label5)
        Me.tabOzcoin.Controls.Add(Me.txtOZPOTTotalShares)
        Me.tabOzcoin.Controls.Add(Me.Label7)
        Me.tabOzcoin.Controls.Add(Me.txtOZPOT_PPSEquivalent)
        Me.tabOzcoin.Controls.Add(Me.Label8)
        Me.tabOzcoin.Controls.Add(Me.txtOZPOTHighestShare)
        Me.tabOzcoin.Controls.Add(Me.Label9)
        Me.tabOzcoin.Controls.Add(Me.txtOzPOTPendingPayout)
        Me.tabOzcoin.Controls.Add(Me.Label10)
        Me.tabOzcoin.Controls.Add(Me.txtOzPendingPayoutDGM)
        Me.tabOzcoin.Controls.Add(Me.Label11)
        Me.tabOzcoin.Controls.Add(Me.txtOzBTCEfficiency)
        Me.tabOzcoin.Controls.Add(Me.Label12)
        Me.tabOzcoin.Controls.Add(Me.txtOzBTCRoundShares)
        Me.tabOzcoin.Controls.Add(Me.Label6)
        Me.tabOzcoin.Controls.Add(Me.dataOz)
        Me.tabOzcoin.Controls.Add(Me.txtOzPoolHashrate)
        Me.tabOzcoin.Controls.Add(Me.txtOzEstimatedPayout)
        Me.tabOzcoin.Controls.Add(Me.txtOzCompletedPayout)
        Me.tabOzcoin.Location = New System.Drawing.Point(4, 4)
        Me.tabOzcoin.Name = "tabOzcoin"
        Me.tabOzcoin.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOzcoin.Size = New System.Drawing.Size(665, 490)
        Me.tabOzcoin.TabIndex = 0
        Me.tabOzcoin.Text = "OzCoin"
        Me.tabOzcoin.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(8, 226)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(614, 27)
        Me.TextBox4.TabIndex = 37
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(310, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(161, 20)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Pending payout PPS"
        '
        'txtOzUserHashRate
        '
        Me.txtOzUserHashRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOzUserHashRate.Location = New System.Drawing.Point(10, 6)
        Me.txtOzUserHashRate.Name = "txtOzUserHashRate"
        Me.txtOzUserHashRate.ReadOnly = True
        Me.txtOzUserHashRate.Size = New System.Drawing.Size(294, 49)
        Me.txtOzUserHashRate.TabIndex = 36
        Me.txtOzUserHashRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOzPendingPayoutPPS
        '
        Me.txtOzPendingPayoutPPS.Location = New System.Drawing.Point(478, 90)
        Me.txtOzPendingPayoutPPS.Name = "txtOzPendingPayoutPPS"
        Me.txtOzPendingPayoutPPS.ReadOnly = True
        Me.txtOzPendingPayoutPPS.Size = New System.Drawing.Size(144, 27)
        Me.txtOzPendingPayoutPPS.TabIndex = 35
        '
        'txtOzBTCRoundDuration
        '
        Me.txtOzBTCRoundDuration.Location = New System.Drawing.Point(160, 117)
        Me.txtOzBTCRoundDuration.Name = "txtOzBTCRoundDuration"
        Me.txtOzBTCRoundDuration.ReadOnly = True
        Me.txtOzBTCRoundDuration.Size = New System.Drawing.Size(144, 27)
        Me.txtOzBTCRoundDuration.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(311, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Estimated payout"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Completed payout"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Pool hashrate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "BTC round duration"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "BTC round shares"
        '
        'txtOZPOTTotalShares
        '
        Me.txtOZPOTTotalShares.Location = New System.Drawing.Point(478, 198)
        Me.txtOZPOTTotalShares.Name = "txtOZPOTTotalShares"
        Me.txtOZPOTTotalShares.ReadOnly = True
        Me.txtOZPOTTotalShares.Size = New System.Drawing.Size(144, 27)
        Me.txtOZPOTTotalShares.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "BTC efficiency"
        '
        'txtOZPOT_PPSEquivalent
        '
        Me.txtOZPOT_PPSEquivalent.Location = New System.Drawing.Point(478, 171)
        Me.txtOZPOT_PPSEquivalent.Name = "txtOZPOT_PPSEquivalent"
        Me.txtOZPOT_PPSEquivalent.ReadOnly = True
        Me.txtOZPOT_PPSEquivalent.Size = New System.Drawing.Size(144, 27)
        Me.txtOZPOT_PPSEquivalent.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(310, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 20)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Pending payout DGM"
        '
        'txtOZPOTHighestShare
        '
        Me.txtOZPOTHighestShare.Location = New System.Drawing.Point(478, 144)
        Me.txtOZPOTHighestShare.Name = "txtOZPOTHighestShare"
        Me.txtOZPOTHighestShare.ReadOnly = True
        Me.txtOZPOTHighestShare.Size = New System.Drawing.Size(144, 27)
        Me.txtOZPOTHighestShare.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(310, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(162, 20)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Pending payout POT"
        '
        'txtOzPOTPendingPayout
        '
        Me.txtOzPOTPendingPayout.Location = New System.Drawing.Point(478, 117)
        Me.txtOzPOTPendingPayout.Name = "txtOzPOTPendingPayout"
        Me.txtOzPOTPendingPayout.ReadOnly = True
        Me.txtOzPOTPendingPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtOzPOTPendingPayout.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(310, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "POT highest share"
        '
        'txtOzPendingPayoutDGM
        '
        Me.txtOzPendingPayoutDGM.Location = New System.Drawing.Point(478, 63)
        Me.txtOzPendingPayoutDGM.Name = "txtOzPendingPayoutDGM"
        Me.txtOzPendingPayoutDGM.ReadOnly = True
        Me.txtOzPendingPayoutDGM.Size = New System.Drawing.Size(144, 27)
        Me.txtOzPendingPayoutDGM.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(310, 171)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(172, 20)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "POT->PPS equivalent"
        '
        'txtOzBTCEfficiency
        '
        Me.txtOzBTCEfficiency.Location = New System.Drawing.Point(160, 171)
        Me.txtOzBTCEfficiency.Name = "txtOzBTCEfficiency"
        Me.txtOzBTCEfficiency.ReadOnly = True
        Me.txtOzBTCEfficiency.Size = New System.Drawing.Size(144, 27)
        Me.txtOzBTCEfficiency.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(314, 203)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 20)
        Me.Label12.TabIndex = 13
        '
        'txtOzBTCRoundShares
        '
        Me.txtOzBTCRoundShares.Location = New System.Drawing.Point(160, 144)
        Me.txtOzBTCRoundShares.Name = "txtOzBTCRoundShares"
        Me.txtOzBTCRoundShares.ReadOnly = True
        Me.txtOzBTCRoundShares.Size = New System.Drawing.Size(144, 27)
        Me.txtOzBTCRoundShares.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(310, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "POT total shares"
        '
        'dataOz
        '
        Me.dataOz.AllowUserToAddRows = False
        Me.dataOz.AllowUserToDeleteRows = False
        Me.dataOz.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataOz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataOz.Location = New System.Drawing.Point(7, 258)
        Me.dataOz.Name = "dataOz"
        Me.dataOz.ReadOnly = True
        Me.dataOz.RowHeadersVisible = False
        Me.dataOz.RowTemplate.Height = 24
        Me.dataOz.Size = New System.Drawing.Size(628, 229)
        Me.dataOz.TabIndex = 0
        '
        'txtOzPoolHashrate
        '
        Me.txtOzPoolHashrate.Location = New System.Drawing.Point(160, 90)
        Me.txtOzPoolHashrate.Name = "txtOzPoolHashrate"
        Me.txtOzPoolHashrate.ReadOnly = True
        Me.txtOzPoolHashrate.Size = New System.Drawing.Size(144, 27)
        Me.txtOzPoolHashrate.TabIndex = 18
        '
        'txtOzEstimatedPayout
        '
        Me.txtOzEstimatedPayout.Location = New System.Drawing.Point(478, 3)
        Me.txtOzEstimatedPayout.Name = "txtOzEstimatedPayout"
        Me.txtOzEstimatedPayout.ReadOnly = True
        Me.txtOzEstimatedPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtOzEstimatedPayout.TabIndex = 16
        '
        'txtOzCompletedPayout
        '
        Me.txtOzCompletedPayout.Location = New System.Drawing.Point(160, 63)
        Me.txtOzCompletedPayout.Name = "txtOzCompletedPayout"
        Me.txtOzCompletedPayout.ReadOnly = True
        Me.txtOzCompletedPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtOzCompletedPayout.TabIndex = 17
        '
        'tabLTCRabbit
        '
        Me.tabLTCRabbit.Controls.Add(Me.Label121)
        Me.tabLTCRabbit.Controls.Add(Me.txtLTCRabbitPoolhash)
        Me.tabLTCRabbit.Controls.Add(Me.TextBox12)
        Me.tabLTCRabbit.Controls.Add(Me.txtLTCRabbitUserHash)
        Me.tabLTCRabbit.Controls.Add(Me.Label120)
        Me.tabLTCRabbit.Controls.Add(Me.txtLTCRabbitConfirmedLTC)
        Me.tabLTCRabbit.Controls.Add(Me.dataLTCRabbit)
        Me.tabLTCRabbit.Location = New System.Drawing.Point(4, 4)
        Me.tabLTCRabbit.Name = "tabLTCRabbit"
        Me.tabLTCRabbit.Size = New System.Drawing.Size(665, 490)
        Me.tabLTCRabbit.TabIndex = 12
        Me.tabLTCRabbit.Text = "LTC Rabbit"
        Me.tabLTCRabbit.UseVisualStyleBackColor = True
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label121.Location = New System.Drawing.Point(7, 63)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(112, 20)
        Me.Label121.TabIndex = 79
        Me.Label121.Text = "Pool hashrate"
        '
        'txtLTCRabbitPoolhash
        '
        Me.txtLTCRabbitPoolhash.Location = New System.Drawing.Point(160, 63)
        Me.txtLTCRabbitPoolhash.Name = "txtLTCRabbitPoolhash"
        Me.txtLTCRabbitPoolhash.ReadOnly = True
        Me.txtLTCRabbitPoolhash.Size = New System.Drawing.Size(144, 27)
        Me.txtLTCRabbitPoolhash.TabIndex = 80
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(8, 97)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(614, 27)
        Me.TextBox12.TabIndex = 78
        Me.TextBox12.TabStop = False
        Me.TextBox12.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'txtLTCRabbitUserHash
        '
        Me.txtLTCRabbitUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLTCRabbitUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtLTCRabbitUserHash.Name = "txtLTCRabbitUserHash"
        Me.txtLTCRabbitUserHash.ReadOnly = True
        Me.txtLTCRabbitUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtLTCRabbitUserHash.TabIndex = 77
        Me.txtLTCRabbitUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label120
        '
        Me.Label120.AutoSize = True
        Me.Label120.ForeColor = System.Drawing.Color.Red
        Me.Label120.Location = New System.Drawing.Point(311, 3)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(123, 20)
        Me.Label120.TabIndex = 75
        Me.Label120.Text = "Confirmed LTC"
        '
        'txtLTCRabbitConfirmedLTC
        '
        Me.txtLTCRabbitConfirmedLTC.Location = New System.Drawing.Point(478, 3)
        Me.txtLTCRabbitConfirmedLTC.Name = "txtLTCRabbitConfirmedLTC"
        Me.txtLTCRabbitConfirmedLTC.ReadOnly = True
        Me.txtLTCRabbitConfirmedLTC.Size = New System.Drawing.Size(144, 27)
        Me.txtLTCRabbitConfirmedLTC.TabIndex = 76
        '
        'dataLTCRabbit
        '
        Me.dataLTCRabbit.AllowUserToAddRows = False
        Me.dataLTCRabbit.AllowUserToDeleteRows = False
        Me.dataLTCRabbit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataLTCRabbit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataLTCRabbit.Location = New System.Drawing.Point(7, 130)
        Me.dataLTCRabbit.Name = "dataLTCRabbit"
        Me.dataLTCRabbit.ReadOnly = True
        Me.dataLTCRabbit.RowHeadersVisible = False
        Me.dataLTCRabbit.RowTemplate.Height = 24
        Me.dataLTCRabbit.Size = New System.Drawing.Size(628, 357)
        Me.dataLTCRabbit.TabIndex = 74
        '
        'tabMultipool
        '
        Me.tabMultipool.Controls.Add(Me.tabMultiDataGrids)
        Me.tabMultipool.Controls.Add(Me.TextBox8)
        Me.tabMultipool.Controls.Add(Me.txtMultipoolUserHashRate)
        Me.tabMultipool.Location = New System.Drawing.Point(4, 4)
        Me.tabMultipool.Name = "tabMultipool"
        Me.tabMultipool.Size = New System.Drawing.Size(665, 490)
        Me.tabMultipool.TabIndex = 8
        Me.tabMultipool.Text = "Multipool"
        Me.tabMultipool.UseVisualStyleBackColor = True
        '
        'tabMultiDataGrids
        '
        Me.tabMultiDataGrids.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.tabMultiDataGrids.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMultiDataGrids.Controls.Add(Me.tabWorkerData)
        Me.tabMultiDataGrids.Controls.Add(Me.tabCoinData)
        Me.tabMultiDataGrids.Location = New System.Drawing.Point(3, 94)
        Me.tabMultiDataGrids.Multiline = True
        Me.tabMultiDataGrids.Name = "tabMultiDataGrids"
        Me.tabMultiDataGrids.SelectedIndex = 0
        Me.tabMultiDataGrids.Size = New System.Drawing.Size(658, 397)
        Me.tabMultiDataGrids.TabIndex = 99
        '
        'tabCoinData
        '
        Me.tabCoinData.Controls.Add(Me.dataMultiCoinData)
        Me.tabCoinData.Location = New System.Drawing.Point(4, 4)
        Me.tabCoinData.Name = "tabCoinData"
        Me.tabCoinData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCoinData.Size = New System.Drawing.Size(625, 389)
        Me.tabCoinData.TabIndex = 0
        Me.tabCoinData.Text = "Coin Data"
        Me.tabCoinData.UseVisualStyleBackColor = True
        '
        'dataMultiCoinData
        '
        Me.dataMultiCoinData.AllowUserToAddRows = False
        Me.dataMultiCoinData.AllowUserToDeleteRows = False
        Me.dataMultiCoinData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataMultiCoinData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataMultiCoinData.Location = New System.Drawing.Point(6, 6)
        Me.dataMultiCoinData.Name = "dataMultiCoinData"
        Me.dataMultiCoinData.ReadOnly = True
        Me.dataMultiCoinData.RowHeadersVisible = False
        Me.dataMultiCoinData.RowTemplate.Height = 24
        Me.dataMultiCoinData.Size = New System.Drawing.Size(616, 380)
        Me.dataMultiCoinData.TabIndex = 98
        '
        'tabWorkerData
        '
        Me.tabWorkerData.Controls.Add(Me.dataMultiWorkerData)
        Me.tabWorkerData.Location = New System.Drawing.Point(4, 4)
        Me.tabWorkerData.Name = "tabWorkerData"
        Me.tabWorkerData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWorkerData.Size = New System.Drawing.Size(625, 389)
        Me.tabWorkerData.TabIndex = 1
        Me.tabWorkerData.Text = "Worker Data"
        Me.tabWorkerData.UseVisualStyleBackColor = True
        '
        'dataMultiWorkerData
        '
        Me.dataMultiWorkerData.AllowUserToAddRows = False
        Me.dataMultiWorkerData.AllowUserToDeleteRows = False
        Me.dataMultiWorkerData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataMultiWorkerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataMultiWorkerData.Location = New System.Drawing.Point(6, 4)
        Me.dataMultiWorkerData.Name = "dataMultiWorkerData"
        Me.dataMultiWorkerData.ReadOnly = True
        Me.dataMultiWorkerData.RowHeadersVisible = False
        Me.dataMultiWorkerData.RowTemplate.Height = 24
        Me.dataMultiWorkerData.Size = New System.Drawing.Size(616, 380)
        Me.dataMultiWorkerData.TabIndex = 99
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(8, 61)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(614, 27)
        Me.TextBox8.TabIndex = 97
        Me.TextBox8.TabStop = False
        Me.TextBox8.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'txtMultipoolUserHashRate
        '
        Me.txtMultipoolUserHashRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMultipoolUserHashRate.Location = New System.Drawing.Point(10, 6)
        Me.txtMultipoolUserHashRate.Name = "txtMultipoolUserHashRate"
        Me.txtMultipoolUserHashRate.ReadOnly = True
        Me.txtMultipoolUserHashRate.Size = New System.Drawing.Size(586, 49)
        Me.txtMultipoolUserHashRate.TabIndex = 94
        Me.txtMultipoolUserHashRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabP2pool
        '
        Me.tabP2pool.Controls.Add(Me.TextBox5)
        Me.tabP2pool.Controls.Add(Me.txtP2PIdealPayout)
        Me.tabP2pool.Controls.Add(Me.Label58)
        Me.tabP2pool.Controls.Add(Me.txtP2pPeers)
        Me.tabP2pool.Controls.Add(Me.Label57)
        Me.tabP2pool.Controls.Add(Me.txtP2pBlockValue)
        Me.tabP2pool.Controls.Add(Me.Label46)
        Me.tabP2pool.Controls.Add(Me.txtP2pPoolDifficulty)
        Me.tabP2pool.Controls.Add(Me.Label42)
        Me.tabP2pool.Controls.Add(Me.dataP2pool)
        Me.tabP2pool.Controls.Add(Me.Label38)
        Me.tabP2pool.Controls.Add(Me.txtp2pUserHash)
        Me.tabP2pool.Controls.Add(Me.txtP2pOrphanedShares)
        Me.tabP2pool.Controls.Add(Me.txtP2pRoundDuration)
        Me.tabP2pool.Controls.Add(Me.Label41)
        Me.tabP2pool.Controls.Add(Me.Label43)
        Me.tabP2pool.Controls.Add(Me.Label44)
        Me.tabP2pool.Controls.Add(Me.txtP2pUpTime)
        Me.tabP2pool.Controls.Add(Me.Label47)
        Me.tabP2pool.Controls.Add(Me.txtP2pUserEfficiency)
        Me.tabP2pool.Controls.Add(Me.Label48)
        Me.tabP2pool.Controls.Add(Me.txtP2pUserStaleRate)
        Me.tabP2pool.Controls.Add(Me.Label52)
        Me.tabP2pool.Controls.Add(Me.txtP2pDeadShares)
        Me.tabP2pool.Controls.Add(Me.Label53)
        Me.tabP2pool.Controls.Add(Me.txtP2pTotalShares)
        Me.tabP2pool.Controls.Add(Me.Label54)
        Me.tabP2pool.Controls.Add(Me.txtP2pPoolStaleRate)
        Me.tabP2pool.Controls.Add(Me.Label55)
        Me.tabP2pool.Controls.Add(Me.Label56)
        Me.tabP2pool.Controls.Add(Me.txtP2pPoolHashRate)
        Me.tabP2pool.Controls.Add(Me.txtP2pPayout)
        Me.tabP2pool.Location = New System.Drawing.Point(4, 4)
        Me.tabP2pool.Name = "tabP2pool"
        Me.tabP2pool.Size = New System.Drawing.Size(665, 490)
        Me.tabP2pool.TabIndex = 4
        Me.tabP2pool.Text = "P2Pool"
        Me.tabP2pool.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(8, 254)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(614, 27)
        Me.TextBox5.TabIndex = 91
        Me.TextBox5.TabStop = False
        Me.TextBox5.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'txtP2PIdealPayout
        '
        Me.txtP2PIdealPayout.Location = New System.Drawing.Point(478, 197)
        Me.txtP2PIdealPayout.Name = "txtP2PIdealPayout"
        Me.txtP2PIdealPayout.ReadOnly = True
        Me.txtP2PIdealPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtP2PIdealPayout.TabIndex = 14
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(311, 197)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(167, 20)
        Me.Label58.TabIndex = 90
        Me.Label58.Text = "Ideal payout @ 24hrs"
        '
        'txtP2pPeers
        '
        Me.txtP2pPeers.Location = New System.Drawing.Point(160, 197)
        Me.txtP2pPeers.Name = "txtP2pPeers"
        Me.txtP2pPeers.ReadOnly = True
        Me.txtP2pPeers.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pPeers.TabIndex = 7
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(7, 197)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(99, 20)
        Me.Label57.TabIndex = 88
        Me.Label57.Text = "Peers in/out"
        '
        'txtP2pBlockValue
        '
        Me.txtP2pBlockValue.Location = New System.Drawing.Point(160, 225)
        Me.txtP2pBlockValue.Name = "txtP2pBlockValue"
        Me.txtP2pBlockValue.ReadOnly = True
        Me.txtP2pBlockValue.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pBlockValue.TabIndex = 13
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 225)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(153, 20)
        Me.Label46.TabIndex = 86
        Me.Label46.Text = "Current block value"
        '
        'txtP2pPoolDifficulty
        '
        Me.txtP2pPoolDifficulty.Location = New System.Drawing.Point(160, 63)
        Me.txtP2pPoolDifficulty.Name = "txtP2pPoolDifficulty"
        Me.txtP2pPoolDifficulty.ReadOnly = True
        Me.txtP2pPoolDifficulty.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pPoolDifficulty.TabIndex = 2
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(7, 91)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(112, 20)
        Me.Label42.TabIndex = 84
        Me.Label42.Text = "Pool hashrate"
        '
        'dataP2pool
        '
        Me.dataP2pool.AllowUserToAddRows = False
        Me.dataP2pool.AllowUserToDeleteRows = False
        Me.dataP2pool.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataP2pool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataP2pool.Location = New System.Drawing.Point(7, 287)
        Me.dataP2pool.Name = "dataP2pool"
        Me.dataP2pool.ReadOnly = True
        Me.dataP2pool.RowHeadersVisible = False
        Me.dataP2pool.RowTemplate.Height = 24
        Me.dataP2pool.Size = New System.Drawing.Size(628, 200)
        Me.dataP2pool.TabIndex = 81
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(310, 90)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(138, 20)
        Me.Label38.TabIndex = 77
        Me.Label38.Text = "Orphaned shares"
        '
        'txtp2pUserHash
        '
        Me.txtp2pUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtp2pUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtp2pUserHash.Name = "txtp2pUserHash"
        Me.txtp2pUserHash.ReadOnly = True
        Me.txtp2pUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtp2pUserHash.TabIndex = 0
        Me.txtp2pUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtP2pOrphanedShares
        '
        Me.txtP2pOrphanedShares.Location = New System.Drawing.Point(478, 90)
        Me.txtP2pOrphanedShares.Name = "txtP2pOrphanedShares"
        Me.txtP2pOrphanedShares.ReadOnly = True
        Me.txtP2pOrphanedShares.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pOrphanedShares.TabIndex = 9
        '
        'txtP2pRoundDuration
        '
        Me.txtP2pRoundDuration.Location = New System.Drawing.Point(160, 119)
        Me.txtP2pRoundDuration.Name = "txtP2pRoundDuration"
        Me.txtP2pRoundDuration.ReadOnly = True
        Me.txtP2pRoundDuration.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pRoundDuration.TabIndex = 4
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.Red
        Me.Label41.Location = New System.Drawing.Point(311, 3)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(138, 20)
        Me.Label41.TabIndex = 52
        Me.Label41.Text = "Estimated payout"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(7, 63)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(109, 20)
        Me.Label43.TabIndex = 54
        Me.Label43.Text = "Pool difficulty"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(7, 119)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(122, 20)
        Me.Label44.TabIndex = 55
        Me.Label44.Text = "Round duration"
        '
        'txtP2pUpTime
        '
        Me.txtP2pUpTime.Location = New System.Drawing.Point(160, 170)
        Me.txtP2pUpTime.Name = "txtP2pUpTime"
        Me.txtP2pUpTime.ReadOnly = True
        Me.txtP2pUpTime.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pUpTime.TabIndex = 6
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(7, 146)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(117, 20)
        Me.Label47.TabIndex = 57
        Me.Label47.Text = "Pool stale rate"
        '
        'txtP2pUserEfficiency
        '
        Me.txtP2pUserEfficiency.Location = New System.Drawing.Point(478, 171)
        Me.txtP2pUserEfficiency.Name = "txtP2pUserEfficiency"
        Me.txtP2pUserEfficiency.ReadOnly = True
        Me.txtP2pUserEfficiency.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pUserEfficiency.TabIndex = 12
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(310, 63)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(102, 20)
        Me.Label48.TabIndex = 58
        Me.Label48.Text = "Total shares"
        '
        'txtP2pUserStaleRate
        '
        Me.txtP2pUserStaleRate.Location = New System.Drawing.Point(478, 144)
        Me.txtP2pUserStaleRate.Name = "txtP2pUserStaleRate"
        Me.txtP2pUserStaleRate.ReadOnly = True
        Me.txtP2pUserStaleRate.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pUserStaleRate.TabIndex = 11
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(310, 117)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(105, 20)
        Me.Label52.TabIndex = 59
        Me.Label52.Text = "Dead shares"
        '
        'txtP2pDeadShares
        '
        Me.txtP2pDeadShares.Location = New System.Drawing.Point(478, 117)
        Me.txtP2pDeadShares.Name = "txtP2pDeadShares"
        Me.txtP2pDeadShares.ReadOnly = True
        Me.txtP2pDeadShares.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pDeadShares.TabIndex = 10
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(310, 144)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(81, 20)
        Me.Label53.TabIndex = 60
        Me.Label53.Text = "Stale rate"
        '
        'txtP2pTotalShares
        '
        Me.txtP2pTotalShares.Location = New System.Drawing.Point(478, 63)
        Me.txtP2pTotalShares.Name = "txtP2pTotalShares"
        Me.txtP2pTotalShares.ReadOnly = True
        Me.txtP2pTotalShares.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pTotalShares.TabIndex = 8
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(310, 171)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(82, 20)
        Me.Label54.TabIndex = 61
        Me.Label54.Text = "Efficiency"
        '
        'txtP2pPoolStaleRate
        '
        Me.txtP2pPoolStaleRate.Location = New System.Drawing.Point(160, 146)
        Me.txtP2pPoolStaleRate.Name = "txtP2pPoolStaleRate"
        Me.txtP2pPoolStaleRate.ReadOnly = True
        Me.txtP2pPoolStaleRate.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pPoolStaleRate.TabIndex = 5
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(314, 203)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(0, 20)
        Me.Label55.TabIndex = 62
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(7, 169)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(67, 20)
        Me.Label56.TabIndex = 63
        Me.Label56.Text = "Up time"
        '
        'txtP2pPoolHashRate
        '
        Me.txtP2pPoolHashRate.Location = New System.Drawing.Point(160, 91)
        Me.txtP2pPoolHashRate.Name = "txtP2pPoolHashRate"
        Me.txtP2pPoolHashRate.ReadOnly = True
        Me.txtP2pPoolHashRate.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pPoolHashRate.TabIndex = 3
        '
        'txtP2pPayout
        '
        Me.txtP2pPayout.Location = New System.Drawing.Point(478, 3)
        Me.txtP2pPayout.Name = "txtP2pPayout"
        Me.txtP2pPayout.ReadOnly = True
        Me.txtP2pPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtP2pPayout.TabIndex = 1
        '
        'tabScryptGuild
        '
        Me.tabScryptGuild.Controls.Add(Me.lblScryptGuildConfirmedBTC)
        Me.tabScryptGuild.Controls.Add(Me.txtScryptGuildConfirmedBTC)
        Me.tabScryptGuild.Controls.Add(Me.txtScryptGuildUserHash)
        Me.tabScryptGuild.Controls.Add(Me.TextBox10)
        Me.tabScryptGuild.Controls.Add(Me.TabControl1)
        Me.tabScryptGuild.Location = New System.Drawing.Point(4, 4)
        Me.tabScryptGuild.Name = "tabScryptGuild"
        Me.tabScryptGuild.Size = New System.Drawing.Size(665, 490)
        Me.tabScryptGuild.TabIndex = 10
        Me.tabScryptGuild.Text = "ScryptGuild"
        Me.tabScryptGuild.UseVisualStyleBackColor = True
        '
        'lblScryptGuildConfirmedBTC
        '
        Me.lblScryptGuildConfirmedBTC.AutoSize = True
        Me.lblScryptGuildConfirmedBTC.ForeColor = System.Drawing.Color.Red
        Me.lblScryptGuildConfirmedBTC.Location = New System.Drawing.Point(311, 3)
        Me.lblScryptGuildConfirmedBTC.Name = "lblScryptGuildConfirmedBTC"
        Me.lblScryptGuildConfirmedBTC.Size = New System.Drawing.Size(125, 20)
        Me.lblScryptGuildConfirmedBTC.TabIndex = 103
        Me.lblScryptGuildConfirmedBTC.Text = "Confirmed BTC"
        '
        'txtScryptGuildConfirmedBTC
        '
        Me.txtScryptGuildConfirmedBTC.Location = New System.Drawing.Point(478, 3)
        Me.txtScryptGuildConfirmedBTC.Name = "txtScryptGuildConfirmedBTC"
        Me.txtScryptGuildConfirmedBTC.ReadOnly = True
        Me.txtScryptGuildConfirmedBTC.Size = New System.Drawing.Size(144, 27)
        Me.txtScryptGuildConfirmedBTC.TabIndex = 104
        '
        'txtScryptGuildUserHash
        '
        Me.txtScryptGuildUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScryptGuildUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtScryptGuildUserHash.Name = "txtScryptGuildUserHash"
        Me.txtScryptGuildUserHash.ReadOnly = True
        Me.txtScryptGuildUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtScryptGuildUserHash.TabIndex = 102
        Me.txtScryptGuildUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(8, 65)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(614, 27)
        Me.TextBox10.TabIndex = 101
        Me.TextBox10.TabStop = False
        Me.TextBox10.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabWorkerInfo)
        Me.TabControl1.Controls.Add(Me.tabBalances)
        Me.TabControl1.Location = New System.Drawing.Point(3, 94)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(658, 397)
        Me.TabControl1.TabIndex = 100
        '
        'tabWorkerInfo
        '
        Me.tabWorkerInfo.Controls.Add(Me.dataScryptGuildWorkerData)
        Me.tabWorkerInfo.Location = New System.Drawing.Point(4, 4)
        Me.tabWorkerInfo.Name = "tabWorkerInfo"
        Me.tabWorkerInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWorkerInfo.Size = New System.Drawing.Size(625, 389)
        Me.tabWorkerInfo.TabIndex = 1
        Me.tabWorkerInfo.Text = "Worker Data"
        Me.tabWorkerInfo.UseVisualStyleBackColor = True
        '
        'dataScryptGuildWorkerData
        '
        Me.dataScryptGuildWorkerData.AllowUserToAddRows = False
        Me.dataScryptGuildWorkerData.AllowUserToDeleteRows = False
        Me.dataScryptGuildWorkerData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataScryptGuildWorkerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataScryptGuildWorkerData.Location = New System.Drawing.Point(6, 4)
        Me.dataScryptGuildWorkerData.Name = "dataScryptGuildWorkerData"
        Me.dataScryptGuildWorkerData.ReadOnly = True
        Me.dataScryptGuildWorkerData.RowHeadersVisible = False
        Me.dataScryptGuildWorkerData.RowTemplate.Height = 24
        Me.dataScryptGuildWorkerData.Size = New System.Drawing.Size(616, 380)
        Me.dataScryptGuildWorkerData.TabIndex = 99
        '
        'tabBalances
        '
        Me.tabBalances.Controls.Add(Me.dataScryptGuildBalanceData)
        Me.tabBalances.Location = New System.Drawing.Point(4, 4)
        Me.tabBalances.Name = "tabBalances"
        Me.tabBalances.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBalances.Size = New System.Drawing.Size(625, 389)
        Me.tabBalances.TabIndex = 0
        Me.tabBalances.Text = "Balances"
        Me.tabBalances.UseVisualStyleBackColor = True
        '
        'dataScryptGuildBalanceData
        '
        Me.dataScryptGuildBalanceData.AllowUserToAddRows = False
        Me.dataScryptGuildBalanceData.AllowUserToDeleteRows = False
        Me.dataScryptGuildBalanceData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataScryptGuildBalanceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataScryptGuildBalanceData.Location = New System.Drawing.Point(6, 6)
        Me.dataScryptGuildBalanceData.Name = "dataScryptGuildBalanceData"
        Me.dataScryptGuildBalanceData.ReadOnly = True
        Me.dataScryptGuildBalanceData.RowHeadersVisible = False
        Me.dataScryptGuildBalanceData.RowTemplate.Height = 24
        Me.dataScryptGuildBalanceData.Size = New System.Drawing.Size(616, 380)
        Me.dataScryptGuildBalanceData.TabIndex = 98
        '
        'tabSlush
        '
        Me.tabSlush.Controls.Add(Me.TextBox6)
        Me.tabSlush.Controls.Add(Me.Label79)
        Me.tabSlush.Controls.Add(Me.txtSlushUserHash)
        Me.tabSlush.Controls.Add(Me.txtSlushUnconfirmedPayout)
        Me.tabSlush.Controls.Add(Me.Label83)
        Me.tabSlush.Controls.Add(Me.Label84)
        Me.tabSlush.Controls.Add(Me.dataSlush)
        Me.tabSlush.Controls.Add(Me.txtSlushEstimatedPayout)
        Me.tabSlush.Controls.Add(Me.txtSlushConfirmedPayout)
        Me.tabSlush.Location = New System.Drawing.Point(4, 4)
        Me.tabSlush.Name = "tabSlush"
        Me.tabSlush.Size = New System.Drawing.Size(665, 490)
        Me.tabSlush.TabIndex = 7
        Me.tabSlush.Text = "Slush's Pool"
        Me.tabSlush.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(8, 96)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(614, 27)
        Me.TextBox6.TabIndex = 80
        Me.TextBox6.TabStop = False
        Me.TextBox6.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(310, 63)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(158, 20)
        Me.Label79.TabIndex = 77
        Me.Label79.Text = "Unconfirmed payout"
        '
        'txtSlushUserHash
        '
        Me.txtSlushUserHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlushUserHash.Location = New System.Drawing.Point(10, 6)
        Me.txtSlushUserHash.Name = "txtSlushUserHash"
        Me.txtSlushUserHash.ReadOnly = True
        Me.txtSlushUserHash.Size = New System.Drawing.Size(294, 49)
        Me.txtSlushUserHash.TabIndex = 79
        Me.txtSlushUserHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSlushUnconfirmedPayout
        '
        Me.txtSlushUnconfirmedPayout.Location = New System.Drawing.Point(478, 63)
        Me.txtSlushUnconfirmedPayout.Name = "txtSlushUnconfirmedPayout"
        Me.txtSlushUnconfirmedPayout.ReadOnly = True
        Me.txtSlushUnconfirmedPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtSlushUnconfirmedPayout.TabIndex = 78
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label83.Location = New System.Drawing.Point(7, 63)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(138, 20)
        Me.Label83.TabIndex = 67
        Me.Label83.Text = "Estimated payout"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.ForeColor = System.Drawing.Color.Red
        Me.Label84.Location = New System.Drawing.Point(311, 3)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(140, 20)
        Me.Label84.TabIndex = 68
        Me.Label84.Text = "Confirmed payout"
        '
        'dataSlush
        '
        Me.dataSlush.AllowUserToAddRows = False
        Me.dataSlush.AllowUserToDeleteRows = False
        Me.dataSlush.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataSlush.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataSlush.Location = New System.Drawing.Point(7, 129)
        Me.dataSlush.Name = "dataSlush"
        Me.dataSlush.ReadOnly = True
        Me.dataSlush.RowHeadersVisible = False
        Me.dataSlush.RowTemplate.Height = 24
        Me.dataSlush.Size = New System.Drawing.Size(628, 358)
        Me.dataSlush.TabIndex = 66
        '
        'txtSlushEstimatedPayout
        '
        Me.txtSlushEstimatedPayout.Location = New System.Drawing.Point(160, 63)
        Me.txtSlushEstimatedPayout.Name = "txtSlushEstimatedPayout"
        Me.txtSlushEstimatedPayout.ReadOnly = True
        Me.txtSlushEstimatedPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtSlushEstimatedPayout.TabIndex = 72
        '
        'txtSlushConfirmedPayout
        '
        Me.txtSlushConfirmedPayout.Location = New System.Drawing.Point(477, 3)
        Me.txtSlushConfirmedPayout.Name = "txtSlushConfirmedPayout"
        Me.txtSlushConfirmedPayout.ReadOnly = True
        Me.txtSlushConfirmedPayout.Size = New System.Drawing.Size(144, 27)
        Me.txtSlushConfirmedPayout.TabIndex = 73
        '
        'tabConfigure
        '
        Me.tabConfigure.ContextMenuStrip = Me.menuStripMain
        Me.tabConfigure.Controls.Add(Me.TextBox7)
        Me.tabConfigure.Controls.Add(Me.tabConfiguration)
        Me.tabConfigure.Controls.Add(Me.chkConfigStoreDBStatistics)
        Me.tabConfigure.Controls.Add(Me.tabsHidden)
        Me.tabConfigure.Controls.Add(Me.chkConfigAlwaysOnTop)
        Me.tabConfigure.Controls.Add(Me.chkConfigAutoRefresh)
        Me.tabConfigure.Controls.Add(Me.Label16)
        Me.tabConfigure.Controls.Add(Me.cmbConfigRefreshRate)
        Me.tabConfigure.Controls.Add(Me.cmdSave)
        Me.tabConfigure.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigure.Name = "tabConfigure"
        Me.tabConfigure.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfigure.Size = New System.Drawing.Size(665, 490)
        Me.tabConfigure.TabIndex = 1
        Me.tabConfigure.Text = "Configure"
        Me.tabConfigure.UseVisualStyleBackColor = True
        '
        'menuStripMain
        '
        Me.menuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainExit})
        Me.menuStripMain.Name = "menuStripMain"
        Me.menuStripMain.Size = New System.Drawing.Size(103, 28)
        '
        'mnuMainExit
        '
        Me.mnuMainExit.Name = "mnuMainExit"
        Me.mnuMainExit.Size = New System.Drawing.Size(102, 24)
        Me.mnuMainExit.Text = "E&xit"
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.Location = New System.Drawing.Point(6, 460)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(618, 27)
        Me.TextBox7.TabIndex = 56
        Me.TextBox7.TabStop = False
        Me.TextBox7.Text = "Please support this app: 1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku"
        '
        'tabConfiguration
        '
        Me.tabConfiguration.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.tabConfiguration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabConfiguration.Controls.Add(Me.tabConfigure50BTC)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureBitMinter)
        Me.tabConfiguration.Controls.Add(Me.tabConfigBlockChainInfo)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureBTCGuild)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureEclipse)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureEligius)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureLTCRabbit)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureMultipool)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureOzcoin)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureP2Pool)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureScryptGuild)
        Me.tabConfiguration.Controls.Add(Me.tabConfigureSlush)
        Me.tabConfiguration.Controls.Add(Me.tabIdleWorkers)
        Me.tabConfiguration.Location = New System.Drawing.Point(7, 6)
        Me.tabConfiguration.Multiline = True
        Me.tabConfiguration.Name = "tabConfiguration"
        Me.tabConfiguration.SelectedIndex = 0
        Me.tabConfiguration.Size = New System.Drawing.Size(626, 386)
        Me.tabConfiguration.TabIndex = 55
        '
        'tabConfigure50BTC
        '
        Me.tabConfigure50BTC.Controls.Add(Me.chk50BTCEnabled)
        Me.tabConfigure50BTC.Controls.Add(Me.txt50BTCAPIKey)
        Me.tabConfigure50BTC.Controls.Add(Me.Label21)
        Me.tabConfigure50BTC.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigure50BTC.Name = "tabConfigure50BTC"
        Me.tabConfigure50BTC.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfigure50BTC.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigure50BTC.TabIndex = 0
        Me.tabConfigure50BTC.Text = "50BTC"
        Me.tabConfigure50BTC.UseVisualStyleBackColor = True
        '
        'chk50BTCEnabled
        '
        Me.chk50BTCEnabled.AutoSize = True
        Me.chk50BTCEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chk50BTCEnabled.Name = "chk50BTCEnabled"
        Me.chk50BTCEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chk50BTCEnabled.TabIndex = 0
        Me.chk50BTCEnabled.Text = "Enabled"
        Me.chk50BTCEnabled.UseVisualStyleBackColor = True
        '
        'txt50BTCAPIKey
        '
        Me.txt50BTCAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txt50BTCAPIKey.Name = "txt50BTCAPIKey"
        Me.txt50BTCAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txt50BTCAPIKey.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 36)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 20)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "API Key:"
        '
        'tabConfigureBitMinter
        '
        Me.tabConfigureBitMinter.Controls.Add(Me.chkBitMinterShowWorkerTotals)
        Me.tabConfigureBitMinter.Controls.Add(Me.chkBitMinterShowWorkerCheckPoint)
        Me.tabConfigureBitMinter.Controls.Add(Me.chkBitMinterEnabled)
        Me.tabConfigureBitMinter.Controls.Add(Me.txtBitMinterAPIKey)
        Me.tabConfigureBitMinter.Controls.Add(Me.Label60)
        Me.tabConfigureBitMinter.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureBitMinter.Name = "tabConfigureBitMinter"
        Me.tabConfigureBitMinter.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfigureBitMinter.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureBitMinter.TabIndex = 1
        Me.tabConfigureBitMinter.Text = "BitMinter"
        Me.tabConfigureBitMinter.UseVisualStyleBackColor = True
        '
        'chkBitMinterShowWorkerTotals
        '
        Me.chkBitMinterShowWorkerTotals.AutoSize = True
        Me.chkBitMinterShowWorkerTotals.Location = New System.Drawing.Point(10, 106)
        Me.chkBitMinterShowWorkerTotals.Name = "chkBitMinterShowWorkerTotals"
        Me.chkBitMinterShowWorkerTotals.Size = New System.Drawing.Size(173, 24)
        Me.chkBitMinterShowWorkerTotals.TabIndex = 46
        Me.chkBitMinterShowWorkerTotals.Text = "Show worker totals"
        Me.chkBitMinterShowWorkerTotals.UseVisualStyleBackColor = True
        '
        'chkBitMinterShowWorkerCheckPoint
        '
        Me.chkBitMinterShowWorkerCheckPoint.AutoSize = True
        Me.chkBitMinterShowWorkerCheckPoint.Location = New System.Drawing.Point(10, 76)
        Me.chkBitMinterShowWorkerCheckPoint.Name = "chkBitMinterShowWorkerCheckPoint"
        Me.chkBitMinterShowWorkerCheckPoint.Size = New System.Drawing.Size(249, 24)
        Me.chkBitMinterShowWorkerCheckPoint.TabIndex = 45
        Me.chkBitMinterShowWorkerCheckPoint.Text = "Show worker checkpoint data"
        Me.chkBitMinterShowWorkerCheckPoint.UseVisualStyleBackColor = True
        '
        'chkBitMinterEnabled
        '
        Me.chkBitMinterEnabled.AutoSize = True
        Me.chkBitMinterEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkBitMinterEnabled.Name = "chkBitMinterEnabled"
        Me.chkBitMinterEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkBitMinterEnabled.TabIndex = 42
        Me.chkBitMinterEnabled.Text = "Enabled"
        Me.chkBitMinterEnabled.UseVisualStyleBackColor = True
        '
        'txtBitMinterAPIKey
        '
        Me.txtBitMinterAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtBitMinterAPIKey.Name = "txtBitMinterAPIKey"
        Me.txtBitMinterAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtBitMinterAPIKey.TabIndex = 43
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(6, 36)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(73, 20)
        Me.Label60.TabIndex = 44
        Me.Label60.Text = "API Key:"
        '
        'tabConfigBlockChainInfo
        '
        Me.tabConfigBlockChainInfo.Controls.Add(Me.Label106)
        Me.tabConfigBlockChainInfo.Controls.Add(Me.cmbBlockChainInfoRefreshRate)
        Me.tabConfigBlockChainInfo.Controls.Add(Me.chkBlockChainInfoEnabled)
        Me.tabConfigBlockChainInfo.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigBlockChainInfo.Name = "tabConfigBlockChainInfo"
        Me.tabConfigBlockChainInfo.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigBlockChainInfo.TabIndex = 9
        Me.tabConfigBlockChainInfo.Text = "Blockchain.info"
        Me.tabConfigBlockChainInfo.UseVisualStyleBackColor = True
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Location = New System.Drawing.Point(5, 42)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(118, 20)
        Me.Label106.TabIndex = 53
        Me.Label106.Text = "Refresh every:"
        '
        'cmbBlockChainInfoRefreshRate
        '
        Me.cmbBlockChainInfoRefreshRate.FormattingEnabled = True
        Me.cmbBlockChainInfoRefreshRate.Items.AddRange(New Object() {"1 hour", "2 hours", "3 hours", "4 hours", "6 hours", "12 hours", "12 hours"})
        Me.cmbBlockChainInfoRefreshRate.Location = New System.Drawing.Point(129, 39)
        Me.cmbBlockChainInfoRefreshRate.Name = "cmbBlockChainInfoRefreshRate"
        Me.cmbBlockChainInfoRefreshRate.Size = New System.Drawing.Size(121, 28)
        Me.cmbBlockChainInfoRefreshRate.TabIndex = 52
        Me.cmbBlockChainInfoRefreshRate.Text = "1 hour"
        '
        'chkBlockChainInfoEnabled
        '
        Me.chkBlockChainInfoEnabled.AutoSize = True
        Me.chkBlockChainInfoEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkBlockChainInfoEnabled.Name = "chkBlockChainInfoEnabled"
        Me.chkBlockChainInfoEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkBlockChainInfoEnabled.TabIndex = 0
        Me.chkBlockChainInfoEnabled.Text = "Enabled"
        Me.chkBlockChainInfoEnabled.UseVisualStyleBackColor = True
        '
        'tabConfigureBTCGuild
        '
        Me.tabConfigureBTCGuild.Controls.Add(Me.chkBTCGuildEnabled)
        Me.tabConfigureBTCGuild.Controls.Add(Me.txtBTCGuildAPIKey)
        Me.tabConfigureBTCGuild.Controls.Add(Me.Label61)
        Me.tabConfigureBTCGuild.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureBTCGuild.Name = "tabConfigureBTCGuild"
        Me.tabConfigureBTCGuild.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureBTCGuild.TabIndex = 5
        Me.tabConfigureBTCGuild.Text = "BTCGuild"
        Me.tabConfigureBTCGuild.UseVisualStyleBackColor = True
        '
        'chkBTCGuildEnabled
        '
        Me.chkBTCGuildEnabled.AutoSize = True
        Me.chkBTCGuildEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkBTCGuildEnabled.Name = "chkBTCGuildEnabled"
        Me.chkBTCGuildEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkBTCGuildEnabled.TabIndex = 36
        Me.chkBTCGuildEnabled.Text = "Enabled"
        Me.chkBTCGuildEnabled.UseVisualStyleBackColor = True
        '
        'txtBTCGuildAPIKey
        '
        Me.txtBTCGuildAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtBTCGuildAPIKey.Name = "txtBTCGuildAPIKey"
        Me.txtBTCGuildAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtBTCGuildAPIKey.TabIndex = 37
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(6, 36)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(73, 20)
        Me.Label61.TabIndex = 38
        Me.Label61.Text = "API Key:"
        '
        'tabConfigureEclipse
        '
        Me.tabConfigureEclipse.Controls.Add(Me.chkEclipseEnabled)
        Me.tabConfigureEclipse.Controls.Add(Me.txtEclipseAPIKey)
        Me.tabConfigureEclipse.Controls.Add(Me.Label18)
        Me.tabConfigureEclipse.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureEclipse.Name = "tabConfigureEclipse"
        Me.tabConfigureEclipse.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureEclipse.TabIndex = 2
        Me.tabConfigureEclipse.Text = "Eclipse"
        Me.tabConfigureEclipse.UseVisualStyleBackColor = True
        '
        'chkEclipseEnabled
        '
        Me.chkEclipseEnabled.AutoSize = True
        Me.chkEclipseEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkEclipseEnabled.Name = "chkEclipseEnabled"
        Me.chkEclipseEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkEclipseEnabled.TabIndex = 0
        Me.chkEclipseEnabled.Text = "Enabled"
        Me.chkEclipseEnabled.UseVisualStyleBackColor = True
        '
        'txtEclipseAPIKey
        '
        Me.txtEclipseAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtEclipseAPIKey.Name = "txtEclipseAPIKey"
        Me.txtEclipseAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtEclipseAPIKey.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 20)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "API Key:"
        '
        'tabConfigureEligius
        '
        Me.tabConfigureEligius.Controls.Add(Me.chkEligiusEnabled)
        Me.tabConfigureEligius.Controls.Add(Me.txtEligiusBTCAddress)
        Me.tabConfigureEligius.Controls.Add(Me.Label19)
        Me.tabConfigureEligius.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureEligius.Name = "tabConfigureEligius"
        Me.tabConfigureEligius.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureEligius.TabIndex = 11
        Me.tabConfigureEligius.Text = "Eligius"
        Me.tabConfigureEligius.UseVisualStyleBackColor = True
        '
        'chkEligiusEnabled
        '
        Me.chkEligiusEnabled.AutoSize = True
        Me.chkEligiusEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkEligiusEnabled.Name = "chkEligiusEnabled"
        Me.chkEligiusEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkEligiusEnabled.TabIndex = 36
        Me.chkEligiusEnabled.Text = "Enabled"
        Me.chkEligiusEnabled.UseVisualStyleBackColor = True
        '
        'txtEligiusBTCAddress
        '
        Me.txtEligiusBTCAddress.Location = New System.Drawing.Point(127, 33)
        Me.txtEligiusBTCAddress.Name = "txtEligiusBTCAddress"
        Me.txtEligiusBTCAddress.Size = New System.Drawing.Size(402, 27)
        Me.txtEligiusBTCAddress.TabIndex = 37
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(115, 20)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "BTC Address:"
        '
        'tabConfigureLTCRabbit
        '
        Me.tabConfigureLTCRabbit.Controls.Add(Me.chkLTCRabbitEnabled)
        Me.tabConfigureLTCRabbit.Controls.Add(Me.txtLTCRabbitAPIKey)
        Me.tabConfigureLTCRabbit.Controls.Add(Me.Label119)
        Me.tabConfigureLTCRabbit.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureLTCRabbit.Name = "tabConfigureLTCRabbit"
        Me.tabConfigureLTCRabbit.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureLTCRabbit.TabIndex = 12
        Me.tabConfigureLTCRabbit.Text = "LTC Rabbit"
        Me.tabConfigureLTCRabbit.UseVisualStyleBackColor = True
        '
        'chkLTCRabbitEnabled
        '
        Me.chkLTCRabbitEnabled.AutoSize = True
        Me.chkLTCRabbitEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkLTCRabbitEnabled.Name = "chkLTCRabbitEnabled"
        Me.chkLTCRabbitEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkLTCRabbitEnabled.TabIndex = 36
        Me.chkLTCRabbitEnabled.Text = "Enabled"
        Me.chkLTCRabbitEnabled.UseVisualStyleBackColor = True
        '
        'txtLTCRabbitAPIKey
        '
        Me.txtLTCRabbitAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtLTCRabbitAPIKey.Name = "txtLTCRabbitAPIKey"
        Me.txtLTCRabbitAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtLTCRabbitAPIKey.TabIndex = 37
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.Location = New System.Drawing.Point(6, 36)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(73, 20)
        Me.Label119.TabIndex = 38
        Me.Label119.Text = "API Key:"
        '
        'tabConfigureMultipool
        '
        Me.tabConfigureMultipool.Controls.Add(Me.chkMultipoolEnabled)
        Me.tabConfigureMultipool.Controls.Add(Me.txtMultipoolAPIKey)
        Me.tabConfigureMultipool.Controls.Add(Me.Label22)
        Me.tabConfigureMultipool.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureMultipool.Name = "tabConfigureMultipool"
        Me.tabConfigureMultipool.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureMultipool.TabIndex = 8
        Me.tabConfigureMultipool.Text = "Multipool"
        Me.tabConfigureMultipool.UseVisualStyleBackColor = True
        '
        'chkMultipoolEnabled
        '
        Me.chkMultipoolEnabled.AutoSize = True
        Me.chkMultipoolEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkMultipoolEnabled.Name = "chkMultipoolEnabled"
        Me.chkMultipoolEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkMultipoolEnabled.TabIndex = 36
        Me.chkMultipoolEnabled.Text = "Enabled"
        Me.chkMultipoolEnabled.UseVisualStyleBackColor = True
        '
        'txtMultipoolAPIKey
        '
        Me.txtMultipoolAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtMultipoolAPIKey.Name = "txtMultipoolAPIKey"
        Me.txtMultipoolAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtMultipoolAPIKey.TabIndex = 37
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 36)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 20)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "API Key:"
        '
        'tabConfigureOzcoin
        '
        Me.tabConfigureOzcoin.Controls.Add(Me.chkOzcoinEnabled)
        Me.tabConfigureOzcoin.Controls.Add(Me.txtOzcoinAPIKey)
        Me.tabConfigureOzcoin.Controls.Add(Me.Label13)
        Me.tabConfigureOzcoin.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureOzcoin.Name = "tabConfigureOzcoin"
        Me.tabConfigureOzcoin.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureOzcoin.TabIndex = 3
        Me.tabConfigureOzcoin.Text = "Ozcoin"
        Me.tabConfigureOzcoin.UseVisualStyleBackColor = True
        '
        'chkOzcoinEnabled
        '
        Me.chkOzcoinEnabled.AutoSize = True
        Me.chkOzcoinEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkOzcoinEnabled.Name = "chkOzcoinEnabled"
        Me.chkOzcoinEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkOzcoinEnabled.TabIndex = 0
        Me.chkOzcoinEnabled.Text = "Enabled"
        Me.chkOzcoinEnabled.UseVisualStyleBackColor = True
        '
        'txtOzcoinAPIKey
        '
        Me.txtOzcoinAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtOzcoinAPIKey.Name = "txtOzcoinAPIKey"
        Me.txtOzcoinAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtOzcoinAPIKey.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 20)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "API Key:"
        '
        'tabConfigureP2Pool
        '
        Me.tabConfigureP2Pool.Controls.Add(Me.chkP2PPublicPool)
        Me.tabConfigureP2Pool.Controls.Add(Me.chkP2PoolScrypt)
        Me.tabConfigureP2Pool.Controls.Add(Me.txtP2PoolBTCAddy)
        Me.tabConfigureP2Pool.Controls.Add(Me.txtP2PoolURL)
        Me.tabConfigureP2Pool.Controls.Add(Me.Label14)
        Me.tabConfigureP2Pool.Controls.Add(Me.Label20)
        Me.tabConfigureP2Pool.Controls.Add(Me.Label23)
        Me.tabConfigureP2Pool.Controls.Add(Me.chkP2PoolEnabled)
        Me.tabConfigureP2Pool.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureP2Pool.Name = "tabConfigureP2Pool"
        Me.tabConfigureP2Pool.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureP2Pool.TabIndex = 4
        Me.tabConfigureP2Pool.Text = "P2Pool"
        Me.tabConfigureP2Pool.UseVisualStyleBackColor = True
        '
        'chkP2PPublicPool
        '
        Me.chkP2PPublicPool.AutoSize = True
        Me.chkP2PPublicPool.Location = New System.Drawing.Point(9, 135)
        Me.chkP2PPublicPool.Name = "chkP2PPublicPool"
        Me.chkP2PPublicPool.Size = New System.Drawing.Size(306, 24)
        Me.chkP2PPublicPool.TabIndex = 48
        Me.chkP2PPublicPool.Text = "Public P2Pool, use address hashrate"
        Me.ToolTip1.SetToolTip(Me.chkP2PPublicPool, "If unchecked, the total of all workers is the ""user hashrate"".  If checked, just " & _
        "the address entered is the user hashrate.")
        Me.chkP2PPublicPool.UseVisualStyleBackColor = True
        '
        'chkP2PoolScrypt
        '
        Me.chkP2PoolScrypt.AutoSize = True
        Me.chkP2PoolScrypt.Location = New System.Drawing.Point(9, 105)
        Me.chkP2PoolScrypt.Name = "chkP2PoolScrypt"
        Me.chkP2PoolScrypt.Size = New System.Drawing.Size(184, 24)
        Me.chkP2PoolScrypt.TabIndex = 47
        Me.chkP2PoolScrypt.Text = "This is a Scrypt pool"
        Me.ToolTip1.SetToolTip(Me.chkP2PoolScrypt, "Checking this will put the total hash rate into the Scrypt total instead of SHA25" & _
        "6 total")
        Me.chkP2PoolScrypt.UseVisualStyleBackColor = True
        '
        'txtP2PoolBTCAddy
        '
        Me.txtP2PoolBTCAddy.Location = New System.Drawing.Point(85, 62)
        Me.txtP2PoolBTCAddy.Name = "txtP2PoolBTCAddy"
        Me.txtP2PoolBTCAddy.Size = New System.Drawing.Size(444, 27)
        Me.txtP2PoolBTCAddy.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtP2PoolBTCAddy, "If not entered, will use default for P2Pool server")
        '
        'txtP2PoolURL
        '
        Me.txtP2PoolURL.Location = New System.Drawing.Point(85, 33)
        Me.txtP2PoolURL.Name = "txtP2PoolURL"
        Me.txtP2PoolURL.Size = New System.Drawing.Size(444, 27)
        Me.txtP2PoolURL.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 20)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Address:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 20)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = "URL:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(106, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(371, 20)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "Enter the P2Pool URL and port like http://url:port"
        '
        'chkP2PoolEnabled
        '
        Me.chkP2PoolEnabled.AutoSize = True
        Me.chkP2PoolEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkP2PoolEnabled.Name = "chkP2PoolEnabled"
        Me.chkP2PoolEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkP2PoolEnabled.TabIndex = 0
        Me.chkP2PoolEnabled.Text = "Enabled"
        Me.chkP2PoolEnabled.UseVisualStyleBackColor = True
        '
        'tabConfigureScryptGuild
        '
        Me.tabConfigureScryptGuild.Controls.Add(Me.chkScryptGuildOmitTinyBalances)
        Me.tabConfigureScryptGuild.Controls.Add(Me.chkScryptGuildShowBalanceData)
        Me.tabConfigureScryptGuild.Controls.Add(Me.chkScryptGuildShowWorkerData)
        Me.tabConfigureScryptGuild.Controls.Add(Me.chkScryptGuildEnabled)
        Me.tabConfigureScryptGuild.Controls.Add(Me.txtScryptGuildAPIKey)
        Me.tabConfigureScryptGuild.Controls.Add(Me.Label15)
        Me.tabConfigureScryptGuild.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureScryptGuild.Name = "tabConfigureScryptGuild"
        Me.tabConfigureScryptGuild.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureScryptGuild.TabIndex = 10
        Me.tabConfigureScryptGuild.Text = "ScryptGuild"
        Me.tabConfigureScryptGuild.UseVisualStyleBackColor = True
        '
        'chkScryptGuildOmitTinyBalances
        '
        Me.chkScryptGuildOmitTinyBalances.AutoSize = True
        Me.chkScryptGuildOmitTinyBalances.Checked = True
        Me.chkScryptGuildOmitTinyBalances.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScryptGuildOmitTinyBalances.Location = New System.Drawing.Point(38, 136)
        Me.chkScryptGuildOmitTinyBalances.Name = "chkScryptGuildOmitTinyBalances"
        Me.chkScryptGuildOmitTinyBalances.Size = New System.Drawing.Size(240, 24)
        Me.chkScryptGuildOmitTinyBalances.TabIndex = 49
        Me.chkScryptGuildOmitTinyBalances.Text = "Omit zero and tiny balances"
        Me.chkScryptGuildOmitTinyBalances.UseVisualStyleBackColor = True
        '
        'chkScryptGuildShowBalanceData
        '
        Me.chkScryptGuildShowBalanceData.AutoSize = True
        Me.chkScryptGuildShowBalanceData.Checked = True
        Me.chkScryptGuildShowBalanceData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScryptGuildShowBalanceData.Location = New System.Drawing.Point(10, 106)
        Me.chkScryptGuildShowBalanceData.Name = "chkScryptGuildShowBalanceData"
        Me.chkScryptGuildShowBalanceData.Size = New System.Drawing.Size(172, 24)
        Me.chkScryptGuildShowBalanceData.TabIndex = 48
        Me.chkScryptGuildShowBalanceData.Text = "Show balance data"
        Me.chkScryptGuildShowBalanceData.UseVisualStyleBackColor = True
        '
        'chkScryptGuildShowWorkerData
        '
        Me.chkScryptGuildShowWorkerData.AutoSize = True
        Me.chkScryptGuildShowWorkerData.Checked = True
        Me.chkScryptGuildShowWorkerData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScryptGuildShowWorkerData.Location = New System.Drawing.Point(10, 76)
        Me.chkScryptGuildShowWorkerData.Name = "chkScryptGuildShowWorkerData"
        Me.chkScryptGuildShowWorkerData.Size = New System.Drawing.Size(164, 24)
        Me.chkScryptGuildShowWorkerData.TabIndex = 47
        Me.chkScryptGuildShowWorkerData.Text = "Show worker data"
        Me.chkScryptGuildShowWorkerData.UseVisualStyleBackColor = True
        '
        'chkScryptGuildEnabled
        '
        Me.chkScryptGuildEnabled.AutoSize = True
        Me.chkScryptGuildEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkScryptGuildEnabled.Name = "chkScryptGuildEnabled"
        Me.chkScryptGuildEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkScryptGuildEnabled.TabIndex = 36
        Me.chkScryptGuildEnabled.Text = "Enabled"
        Me.chkScryptGuildEnabled.UseVisualStyleBackColor = True
        '
        'txtScryptGuildAPIKey
        '
        Me.txtScryptGuildAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtScryptGuildAPIKey.Name = "txtScryptGuildAPIKey"
        Me.txtScryptGuildAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtScryptGuildAPIKey.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 20)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "API Key:"
        '
        'tabConfigureSlush
        '
        Me.tabConfigureSlush.Controls.Add(Me.chkSlushEnabled)
        Me.tabConfigureSlush.Controls.Add(Me.txtSlushAPIKey)
        Me.tabConfigureSlush.Controls.Add(Me.Label78)
        Me.tabConfigureSlush.Location = New System.Drawing.Point(4, 4)
        Me.tabConfigureSlush.Name = "tabConfigureSlush"
        Me.tabConfigureSlush.Size = New System.Drawing.Size(543, 378)
        Me.tabConfigureSlush.TabIndex = 6
        Me.tabConfigureSlush.Text = "Slush's Pool"
        Me.tabConfigureSlush.UseVisualStyleBackColor = True
        '
        'chkSlushEnabled
        '
        Me.chkSlushEnabled.AutoSize = True
        Me.chkSlushEnabled.Location = New System.Drawing.Point(9, 6)
        Me.chkSlushEnabled.Name = "chkSlushEnabled"
        Me.chkSlushEnabled.Size = New System.Drawing.Size(91, 24)
        Me.chkSlushEnabled.TabIndex = 45
        Me.chkSlushEnabled.Text = "Enabled"
        Me.chkSlushEnabled.UseVisualStyleBackColor = True
        '
        'txtSlushAPIKey
        '
        Me.txtSlushAPIKey.Location = New System.Drawing.Point(85, 33)
        Me.txtSlushAPIKey.Name = "txtSlushAPIKey"
        Me.txtSlushAPIKey.Size = New System.Drawing.Size(444, 27)
        Me.txtSlushAPIKey.TabIndex = 46
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(6, 36)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(73, 20)
        Me.Label78.TabIndex = 47
        Me.Label78.Text = "API Key:"
        '
        'tabIdleWorkers
        '
        Me.tabIdleWorkers.Controls.Add(Me.chkIdleWorkPopUpWithBeeps)
        Me.tabIdleWorkers.Controls.Add(Me.chkIdleStartApp)
        Me.tabIdleWorkers.Controls.Add(Me.chkIdlePopup)
        Me.tabIdleWorkers.Controls.Add(Me.TabControl2)
        Me.tabIdleWorkers.Controls.Add(Me.chkIdleEMailAlerts)
        Me.tabIdleWorkers.Location = New System.Drawing.Point(4, 4)
        Me.tabIdleWorkers.Name = "tabIdleWorkers"
        Me.tabIdleWorkers.Size = New System.Drawing.Size(543, 378)
        Me.tabIdleWorkers.TabIndex = 7
        Me.tabIdleWorkers.Text = "Idle Workers"
        Me.tabIdleWorkers.UseVisualStyleBackColor = True
        '
        'chkIdleWorkPopUpWithBeeps
        '
        Me.chkIdleWorkPopUpWithBeeps.AutoSize = True
        Me.chkIdleWorkPopUpWithBeeps.Checked = True
        Me.chkIdleWorkPopUpWithBeeps.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIdleWorkPopUpWithBeeps.Location = New System.Drawing.Point(167, 12)
        Me.chkIdleWorkPopUpWithBeeps.Name = "chkIdleWorkPopUpWithBeeps"
        Me.chkIdleWorkPopUpWithBeeps.Size = New System.Drawing.Size(115, 24)
        Me.chkIdleWorkPopUpWithBeeps.TabIndex = 62
        Me.chkIdleWorkPopUpWithBeeps.Text = "(w/ beeps!)"
        Me.chkIdleWorkPopUpWithBeeps.UseVisualStyleBackColor = True
        '
        'chkIdleStartApp
        '
        Me.chkIdleStartApp.AutoSize = True
        Me.chkIdleStartApp.Location = New System.Drawing.Point(432, 12)
        Me.chkIdleStartApp.Name = "chkIdleStartApp"
        Me.chkIdleStartApp.Size = New System.Drawing.Size(101, 24)
        Me.chkIdleStartApp.TabIndex = 61
        Me.chkIdleStartApp.Text = "Start App"
        Me.chkIdleStartApp.UseVisualStyleBackColor = True
        '
        'chkIdlePopup
        '
        Me.chkIdlePopup.AutoSize = True
        Me.chkIdlePopup.Checked = True
        Me.chkIdlePopup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIdlePopup.Location = New System.Drawing.Point(10, 12)
        Me.chkIdlePopup.Name = "chkIdlePopup"
        Me.chkIdlePopup.Size = New System.Drawing.Size(151, 24)
        Me.chkIdlePopup.TabIndex = 60
        Me.chkIdlePopup.Text = "Annoying Popup"
        Me.chkIdlePopup.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.tabIdleUserProcess)
        Me.TabControl2.Controls.Add(Me.tabIdleEmail)
        Me.TabControl2.Location = New System.Drawing.Point(3, 45)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(609, 327)
        Me.TabControl2.TabIndex = 58
        '
        'tabIdleUserProcess
        '
        Me.tabIdleUserProcess.Controls.Add(Me.cmdIdleStartAppFinder)
        Me.tabIdleUserProcess.Controls.Add(Me.Label77)
        Me.tabIdleUserProcess.Controls.Add(Me.txtIdleStartAppName)
        Me.tabIdleUserProcess.Controls.Add(Me.Label39)
        Me.tabIdleUserProcess.Controls.Add(Me.txtIdleStartParms)
        Me.tabIdleUserProcess.Controls.Add(Me.Label40)
        Me.tabIdleUserProcess.Location = New System.Drawing.Point(29, 4)
        Me.tabIdleUserProcess.Name = "tabIdleUserProcess"
        Me.tabIdleUserProcess.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIdleUserProcess.Size = New System.Drawing.Size(576, 319)
        Me.tabIdleUserProcess.TabIndex = 1
        Me.tabIdleUserProcess.Text = "Start app"
        Me.tabIdleUserProcess.UseVisualStyleBackColor = True
        '
        'cmdIdleStartAppFinder
        '
        Me.cmdIdleStartAppFinder.Location = New System.Drawing.Point(475, 11)
        Me.cmdIdleStartAppFinder.Name = "cmdIdleStartAppFinder"
        Me.cmdIdleStartAppFinder.Size = New System.Drawing.Size(26, 27)
        Me.cmdIdleStartAppFinder.TabIndex = 14
        Me.cmdIdleStartAppFinder.Text = "?"
        Me.cmdIdleStartAppFinder.UseVisualStyleBackColor = True
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(74, 84)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(371, 20)
        Me.Label77.TabIndex = 13
        Me.Label77.Text = "Use %W for worker name and %P for pool name"
        '
        'txtIdleStartAppName
        '
        Me.txtIdleStartAppName.Location = New System.Drawing.Point(137, 11)
        Me.txtIdleStartAppName.Name = "txtIdleStartAppName"
        Me.txtIdleStartAppName.Size = New System.Drawing.Size(332, 27)
        Me.txtIdleStartAppName.TabIndex = 9
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(7, 14)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(106, 20)
        Me.Label39.TabIndex = 11
        Me.Label39.Text = "App location:"
        '
        'txtIdleStartParms
        '
        Me.txtIdleStartParms.Location = New System.Drawing.Point(137, 40)
        Me.txtIdleStartParms.Name = "txtIdleStartParms"
        Me.txtIdleStartParms.Size = New System.Drawing.Size(332, 27)
        Me.txtIdleStartParms.TabIndex = 10
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(7, 43)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(101, 20)
        Me.Label40.TabIndex = 12
        Me.Label40.Text = "Parameters:"
        '
        'tabIdleEmail
        '
        Me.tabIdleEmail.Controls.Add(Me.Label85)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPServer)
        Me.tabIdleEmail.Controls.Add(Me.cmdSendTestEMail)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPPort)
        Me.tabIdleEmail.Controls.Add(Me.Label101)
        Me.tabIdleEmail.Controls.Add(Me.Label89)
        Me.tabIdleEmail.Controls.Add(Me.Label102)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPUserName)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPFromName)
        Me.tabIdleEmail.Controls.Add(Me.Label90)
        Me.tabIdleEmail.Controls.Add(Me.Label103)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPPassword)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPFromAddress)
        Me.tabIdleEmail.Controls.Add(Me.Label91)
        Me.tabIdleEmail.Controls.Add(Me.chkSMTPSSL)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPAlertAddress)
        Me.tabIdleEmail.Controls.Add(Me.Label100)
        Me.tabIdleEmail.Controls.Add(Me.Label92)
        Me.tabIdleEmail.Controls.Add(Me.Label99)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPAlertSubject)
        Me.tabIdleEmail.Controls.Add(Me.Label98)
        Me.tabIdleEmail.Controls.Add(Me.Label93)
        Me.tabIdleEmail.Controls.Add(Me.Label97)
        Me.tabIdleEmail.Controls.Add(Me.txtSMTPAlertName)
        Me.tabIdleEmail.Controls.Add(Me.Label96)
        Me.tabIdleEmail.Controls.Add(Me.Label94)
        Me.tabIdleEmail.Controls.Add(Me.Label95)
        Me.tabIdleEmail.Location = New System.Drawing.Point(29, 4)
        Me.tabIdleEmail.Name = "tabIdleEmail"
        Me.tabIdleEmail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIdleEmail.Size = New System.Drawing.Size(576, 319)
        Me.tabIdleEmail.TabIndex = 0
        Me.tabIdleEmail.Text = "EMail"
        Me.tabIdleEmail.UseVisualStyleBackColor = True
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(7, 14)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(112, 20)
        Me.Label85.TabIndex = 2
        Me.Label85.Text = "Server Name:"
        '
        'txtSMTPServer
        '
        Me.txtSMTPServer.Location = New System.Drawing.Point(137, 11)
        Me.txtSMTPServer.Name = "txtSMTPServer"
        Me.txtSMTPServer.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPServer.TabIndex = 0
        '
        'cmdSendTestEMail
        '
        Me.cmdSendTestEMail.Location = New System.Drawing.Point(316, 190)
        Me.cmdSendTestEMail.Name = "cmdSendTestEMail"
        Me.cmdSendTestEMail.Size = New System.Drawing.Size(153, 29)
        Me.cmdSendTestEMail.TabIndex = 27
        Me.cmdSendTestEMail.Text = "Send Test EMail"
        Me.cmdSendTestEMail.UseVisualStyleBackColor = True
        '
        'txtSMTPPort
        '
        Me.txtSMTPPort.Location = New System.Drawing.Point(137, 40)
        Me.txtSMTPPort.Name = "txtSMTPPort"
        Me.txtSMTPPort.Size = New System.Drawing.Size(63, 27)
        Me.txtSMTPPort.TabIndex = 1
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.ForeColor = System.Drawing.Color.Red
        Me.Label101.Location = New System.Drawing.Point(471, 161)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(15, 20)
        Me.Label101.TabIndex = 26
        Me.Label101.Text = "*"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(7, 43)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(99, 20)
        Me.Label89.TabIndex = 4
        Me.Label89.Text = "Server Port:"
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(7, 131)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(102, 20)
        Me.Label102.TabIndex = 25
        Me.Label102.Text = "From Name:"
        '
        'txtSMTPUserName
        '
        Me.txtSMTPUserName.Location = New System.Drawing.Point(137, 69)
        Me.txtSMTPUserName.Name = "txtSMTPUserName"
        Me.txtSMTPUserName.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPUserName.TabIndex = 2
        '
        'txtSMTPFromName
        '
        Me.txtSMTPFromName.Location = New System.Drawing.Point(137, 128)
        Me.txtSMTPFromName.Name = "txtSMTPFromName"
        Me.txtSMTPFromName.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPFromName.TabIndex = 4
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(7, 72)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(91, 20)
        Me.Label90.TabIndex = 6
        Me.Label90.Text = "Username:"
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Location = New System.Drawing.Point(7, 160)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(120, 20)
        Me.Label103.TabIndex = 23
        Me.Label103.Text = "From Address:"
        '
        'txtSMTPPassword
        '
        Me.txtSMTPPassword.Location = New System.Drawing.Point(137, 98)
        Me.txtSMTPPassword.Name = "txtSMTPPassword"
        Me.txtSMTPPassword.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPPassword.TabIndex = 3
        '
        'txtSMTPFromAddress
        '
        Me.txtSMTPFromAddress.Location = New System.Drawing.Point(137, 157)
        Me.txtSMTPFromAddress.Name = "txtSMTPFromAddress"
        Me.txtSMTPFromAddress.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPFromAddress.TabIndex = 5
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(7, 101)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(88, 20)
        Me.Label91.TabIndex = 8
        Me.Label91.Text = "Password:"
        '
        'chkSMTPSSL
        '
        Me.chkSMTPSSL.AutoSize = True
        Me.chkSMTPSSL.Location = New System.Drawing.Point(371, 44)
        Me.chkSMTPSSL.Name = "chkSMTPSSL"
        Me.chkSMTPSSL.Size = New System.Drawing.Size(98, 24)
        Me.chkSMTPSSL.TabIndex = 21
        Me.chkSMTPSSL.Text = "Use SSL"
        Me.chkSMTPSSL.UseVisualStyleBackColor = True
        '
        'txtSMTPAlertAddress
        '
        Me.txtSMTPAlertAddress.Location = New System.Drawing.Point(137, 252)
        Me.txtSMTPAlertAddress.Name = "txtSMTPAlertAddress"
        Me.txtSMTPAlertAddress.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPAlertAddress.TabIndex = 7
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.ForeColor = System.Drawing.Color.Red
        Me.Label100.Location = New System.Drawing.Point(471, 15)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(15, 20)
        Me.Label100.TabIndex = 20
        Me.Label100.Text = "*"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(7, 255)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(76, 20)
        Me.Label92.TabIndex = 10
        Me.Label92.Text = "Address:"
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.ForeColor = System.Drawing.Color.Red
        Me.Label99.Location = New System.Drawing.Point(203, 44)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(15, 20)
        Me.Label99.TabIndex = 19
        Me.Label99.Text = "*"
        '
        'txtSMTPAlertSubject
        '
        Me.txtSMTPAlertSubject.Location = New System.Drawing.Point(137, 281)
        Me.txtSMTPAlertSubject.Name = "txtSMTPAlertSubject"
        Me.txtSMTPAlertSubject.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPAlertSubject.TabIndex = 8
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.ForeColor = System.Drawing.Color.Red
        Me.Label98.Location = New System.Drawing.Point(471, 73)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(15, 20)
        Me.Label98.TabIndex = 18
        Me.Label98.Text = "*"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(7, 284)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(70, 20)
        Me.Label93.TabIndex = 12
        Me.Label93.Text = "Subject:"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.ForeColor = System.Drawing.Color.Red
        Me.Label97.Location = New System.Drawing.Point(471, 101)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(15, 20)
        Me.Label97.TabIndex = 17
        Me.Label97.Text = "*"
        '
        'txtSMTPAlertName
        '
        Me.txtSMTPAlertName.Location = New System.Drawing.Point(137, 223)
        Me.txtSMTPAlertName.Name = "txtSMTPAlertName"
        Me.txtSMTPAlertName.Size = New System.Drawing.Size(332, 27)
        Me.txtSMTPAlertName.TabIndex = 6
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.ForeColor = System.Drawing.Color.Red
        Me.Label96.Location = New System.Drawing.Point(471, 256)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(15, 20)
        Me.Label96.TabIndex = 16
        Me.Label96.Text = "*"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(7, 226)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(58, 20)
        Me.Label94.TabIndex = 14
        Me.Label94.Text = "Name:"
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.ForeColor = System.Drawing.Color.Maroon
        Me.Label95.Location = New System.Drawing.Point(7, 196)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(109, 20)
        Me.Label95.TabIndex = 15
        Me.Label95.Text = "Send alert to:"
        '
        'chkIdleEMailAlerts
        '
        Me.chkIdleEMailAlerts.AutoSize = True
        Me.chkIdleEMailAlerts.Location = New System.Drawing.Point(304, 12)
        Me.chkIdleEMailAlerts.Name = "chkIdleEMailAlerts"
        Me.chkIdleEMailAlerts.Size = New System.Drawing.Size(122, 24)
        Me.chkIdleEMailAlerts.TabIndex = 0
        Me.chkIdleEMailAlerts.Text = "EMail Alerts"
        Me.chkIdleEMailAlerts.UseVisualStyleBackColor = True
        '
        'chkConfigStoreDBStatistics
        '
        Me.chkConfigStoreDBStatistics.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkConfigStoreDBStatistics.AutoSize = True
        Me.chkConfigStoreDBStatistics.Location = New System.Drawing.Point(484, 400)
        Me.chkConfigStoreDBStatistics.Name = "chkConfigStoreDBStatistics"
        Me.chkConfigStoreDBStatistics.Size = New System.Drawing.Size(145, 24)
        Me.chkConfigStoreDBStatistics.TabIndex = 52
        Me.chkConfigStoreDBStatistics.Text = "Store DB Stats"
        Me.chkConfigStoreDBStatistics.UseVisualStyleBackColor = True
        '
        'tabsHidden
        '
        Me.tabsHidden.Location = New System.Drawing.Point(666, 35)
        Me.tabsHidden.Name = "tabsHidden"
        Me.tabsHidden.SelectedIndex = 0
        Me.tabsHidden.Size = New System.Drawing.Size(200, 47)
        Me.tabsHidden.TabIndex = 51
        Me.tabsHidden.Visible = False
        '
        'chkConfigAlwaysOnTop
        '
        Me.chkConfigAlwaysOnTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkConfigAlwaysOnTop.AutoSize = True
        Me.chkConfigAlwaysOnTop.Location = New System.Drawing.Point(257, 426)
        Me.chkConfigAlwaysOnTop.Name = "chkConfigAlwaysOnTop"
        Me.chkConfigAlwaysOnTop.Size = New System.Drawing.Size(144, 24)
        Me.chkConfigAlwaysOnTop.TabIndex = 39
        Me.chkConfigAlwaysOnTop.Text = "Always On Top"
        Me.chkConfigAlwaysOnTop.UseVisualStyleBackColor = True
        '
        'chkConfigAutoRefresh
        '
        Me.chkConfigAutoRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkConfigAutoRefresh.AutoSize = True
        Me.chkConfigAutoRefresh.Checked = True
        Me.chkConfigAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConfigAutoRefresh.Location = New System.Drawing.Point(257, 402)
        Me.chkConfigAutoRefresh.Name = "chkConfigAutoRefresh"
        Me.chkConfigAutoRefresh.Size = New System.Drawing.Size(129, 24)
        Me.chkConfigAutoRefresh.TabIndex = 38
        Me.chkConfigAutoRefresh.Text = "Auto Refresh"
        Me.chkConfigAutoRefresh.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 401)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 20)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Refresh every:"
        '
        'cmbConfigRefreshRate
        '
        Me.cmbConfigRefreshRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbConfigRefreshRate.FormattingEnabled = True
        Me.cmbConfigRefreshRate.Items.AddRange(New Object() {"5 minutes", "10 minutes", "15 minutes", "30 minutes", "60 minutes"})
        Me.cmbConfigRefreshRate.Location = New System.Drawing.Point(130, 398)
        Me.cmbConfigRefreshRate.Name = "cmbConfigRefreshRate"
        Me.cmbConfigRefreshRate.Size = New System.Drawing.Size(121, 28)
        Me.cmbConfigRefreshRate.TabIndex = 43
        Me.cmbConfigRefreshRate.Text = "5 minutes"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(484, 426)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(141, 28)
        Me.cmdSave.TabIndex = 37
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.menuStripNotifyIcon
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'menuStripNotifyIcon
        '
        Me.menuStripNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShow, Me.mnuExit})
        Me.menuStripNotifyIcon.Name = "ContextMenuStrip1"
        Me.menuStripNotifyIcon.Size = New System.Drawing.Size(115, 52)
        '
        'mnuShow
        '
        Me.mnuShow.Name = "mnuShow"
        Me.mnuShow.Size = New System.Drawing.Size(114, 24)
        Me.mnuShow.Text = "Show"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(114, 24)
        Me.mnuExit.Text = "Exit"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(608, 6)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(63, 31)
        Me.cmdRefresh.TabIndex = 0
        Me.cmdRefresh.Text = "300s"
        Me.ToolTip1.SetToolTip(Me.cmdRefresh, "Click to refresh")
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'txtTotalHash
        '
        Me.txtTotalHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHash.Location = New System.Drawing.Point(16, 6)
        Me.txtTotalHash.Name = "txtTotalHash"
        Me.txtTotalHash.ReadOnly = True
        Me.txtTotalHash.Size = New System.Drawing.Size(586, 41)
        Me.txtTotalHash.TabIndex = 0
        Me.txtTotalHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'timer_start
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 579)
        Me.ContextMenuStrip = Me.menuStripMain
        Me.Controls.Add(Me.txtTotalHash)
        Me.Controls.Add(Me.tabsShown)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.Text = "M's Pool Monitor v3.6"
        Me.tabsShown.ResumeLayout(False)
        Me.tab50BTC.ResumeLayout(False)
        Me.tab50BTC.PerformLayout()
        CType(Me.data50btc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBitMinter.ResumeLayout(False)
        Me.tabBitMinter.PerformLayout()
        CType(Me.dataBitMinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBlockchainInfo.ResumeLayout(False)
        Me.tabBlockchainInfo.PerformLayout()
        Me.tabBTCGuild.ResumeLayout(False)
        Me.tabBTCGuild.PerformLayout()
        CType(Me.dataBTCGuild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEclipse.ResumeLayout(False)
        Me.tabEclipse.PerformLayout()
        CType(Me.dataEclipse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEligius.ResumeLayout(False)
        Me.tabEligius.PerformLayout()
        CType(Me.dataEligius, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOzcoin.ResumeLayout(False)
        Me.tabOzcoin.PerformLayout()
        CType(Me.dataOz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLTCRabbit.ResumeLayout(False)
        Me.tabLTCRabbit.PerformLayout()
        CType(Me.dataLTCRabbit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMultipool.ResumeLayout(False)
        Me.tabMultipool.PerformLayout()
        Me.tabMultiDataGrids.ResumeLayout(False)
        Me.tabCoinData.ResumeLayout(False)
        CType(Me.dataMultiCoinData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWorkerData.ResumeLayout(False)
        CType(Me.dataMultiWorkerData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabP2pool.ResumeLayout(False)
        Me.tabP2pool.PerformLayout()
        CType(Me.dataP2pool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabScryptGuild.ResumeLayout(False)
        Me.tabScryptGuild.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabWorkerInfo.ResumeLayout(False)
        CType(Me.dataScryptGuildWorkerData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBalances.ResumeLayout(False)
        CType(Me.dataScryptGuildBalanceData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSlush.ResumeLayout(False)
        Me.tabSlush.PerformLayout()
        CType(Me.dataSlush, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConfigure.ResumeLayout(False)
        Me.tabConfigure.PerformLayout()
        Me.menuStripMain.ResumeLayout(False)
        Me.tabConfiguration.ResumeLayout(False)
        Me.tabConfigure50BTC.ResumeLayout(False)
        Me.tabConfigure50BTC.PerformLayout()
        Me.tabConfigureBitMinter.ResumeLayout(False)
        Me.tabConfigureBitMinter.PerformLayout()
        Me.tabConfigBlockChainInfo.ResumeLayout(False)
        Me.tabConfigBlockChainInfo.PerformLayout()
        Me.tabConfigureBTCGuild.ResumeLayout(False)
        Me.tabConfigureBTCGuild.PerformLayout()
        Me.tabConfigureEclipse.ResumeLayout(False)
        Me.tabConfigureEclipse.PerformLayout()
        Me.tabConfigureEligius.ResumeLayout(False)
        Me.tabConfigureEligius.PerformLayout()
        Me.tabConfigureLTCRabbit.ResumeLayout(False)
        Me.tabConfigureLTCRabbit.PerformLayout()
        Me.tabConfigureMultipool.ResumeLayout(False)
        Me.tabConfigureMultipool.PerformLayout()
        Me.tabConfigureOzcoin.ResumeLayout(False)
        Me.tabConfigureOzcoin.PerformLayout()
        Me.tabConfigureP2Pool.ResumeLayout(False)
        Me.tabConfigureP2Pool.PerformLayout()
        Me.tabConfigureScryptGuild.ResumeLayout(False)
        Me.tabConfigureScryptGuild.PerformLayout()
        Me.tabConfigureSlush.ResumeLayout(False)
        Me.tabConfigureSlush.PerformLayout()
        Me.tabIdleWorkers.ResumeLayout(False)
        Me.tabIdleWorkers.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tabIdleUserProcess.ResumeLayout(False)
        Me.tabIdleUserProcess.PerformLayout()
        Me.tabIdleEmail.ResumeLayout(False)
        Me.tabIdleEmail.PerformLayout()
        Me.menuStripNotifyIcon.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timer_CountDown As System.Windows.Forms.Timer
    Friend WithEvents tabsShown As System.Windows.Forms.TabControl
    Friend WithEvents tabConfigure As System.Windows.Forms.TabPage
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOzcoinAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents menuStripNotifyIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuStripMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMainExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbConfigRefreshRate As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tabEclipse As System.Windows.Forms.TabPage
    Friend WithEvents tab50BTC As System.Windows.Forms.TabPage
    Friend WithEvents tabP2pool As System.Windows.Forms.TabPage
    Friend WithEvents chkEclipseEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtEclipseAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkOzcoinEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chk50BTCEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txt50BTCAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkP2PoolEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtP2PoolURL As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtP2PoolBTCAddy As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkConfigAlwaysOnTop As System.Windows.Forms.CheckBox
    Friend WithEvents chkConfigAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtEclUserHashRate As System.Windows.Forms.TextBox
    Friend WithEvents txtEclUnconfirmedBTC As System.Windows.Forms.TextBox
    Friend WithEvents txtEclBTCRoundDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtEclBlocksFound As System.Windows.Forms.TextBox
    Friend WithEvents txtEclConfirmedBTC As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtEclBTCRoundShares As System.Windows.Forms.TextBox
    Friend WithEvents dataEclipse As System.Windows.Forms.DataGridView
    Friend WithEvents txtEclPoolHashrate As System.Windows.Forms.TextBox
    Friend WithEvents txtEclEstimatedRewards As System.Windows.Forms.TextBox
    Friend WithEvents txtEclTotalPayout As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtEclAvgSharesBlock As System.Windows.Forms.TextBox
    Friend WithEvents tabsHidden As System.Windows.Forms.TabControl
    Friend WithEvents txtTotalHash As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt50UserHashRate As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txt50ConfirmedBTC As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents data50btc As System.Windows.Forms.DataGridView
    Friend WithEvents txt50CompletedPayouts As System.Windows.Forms.TextBox
    Friend WithEvents chkConfigStoreDBStatistics As System.Windows.Forms.CheckBox
    Friend WithEvents dataP2pool As System.Windows.Forms.DataGridView
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtp2pUserHash As System.Windows.Forms.TextBox
    Friend WithEvents txtP2pOrphanedShares As System.Windows.Forms.TextBox
    Friend WithEvents txtP2pRoundDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtP2pUpTime As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtP2pUserEfficiency As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtP2pUserStaleRate As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtP2pDeadShares As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtP2pTotalShares As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txtP2pPoolStaleRate As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtP2pPoolHashRate As System.Windows.Forms.TextBox
    Friend WithEvents txtP2pPayout As System.Windows.Forms.TextBox
    Friend WithEvents txtP2pPoolDifficulty As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents timer_start As System.Windows.Forms.Timer
    Friend WithEvents txtP2pBlockValue As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtP2pPeers As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtP2PIdealPayout As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents tabBitMinter As System.Windows.Forms.TabPage
    Friend WithEvents tabConfiguration As System.Windows.Forms.TabControl
    Friend WithEvents tabConfigure50BTC As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureBitMinter As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureEclipse As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureOzcoin As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureP2Pool As System.Windows.Forms.TabPage
    Friend WithEvents chkBitMinterEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtBitMinterAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents dataBitMinter As System.Windows.Forms.DataGridView
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterUserHash As System.Windows.Forms.TextBox
    Friend WithEvents txtBitMinterUserShiftRejected As System.Windows.Forms.TextBox
    Friend WithEvents txtBitMinterBTCRoundDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterNMCEfficiency As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterNMCRoundShares As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterNMCRoundDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterUserShiftScore As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterUserShiftAccepted As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterBTCEfficiency As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterBTCRoundShares As System.Windows.Forms.TextBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterPoolHash As System.Windows.Forms.TextBox
    Friend WithEvents txtBitMinterShiftDuration As System.Windows.Forms.TextBox
    Friend WithEvents txtBitMinterShiftScore As System.Windows.Forms.TextBox
    Friend WithEvents txtBitMinterNMCBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents txtBitMinterBTCBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents tabBTCGuild As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureBTCGuild As System.Windows.Forms.TabPage
    Friend WithEvents chkBTCGuildEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtBTCGuildAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtBTCGuildUserHash As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents dataBTCGuild As System.Windows.Forms.DataGridView
    Friend WithEvents txtBTCGuildPoolHashrate As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCGuildPendingBTCPayout As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCGuildPendingNMCPayout As System.Windows.Forms.TextBox
    Friend WithEvents tabSlush As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureSlush As System.Windows.Forms.TabPage
    Friend WithEvents chkSlushEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtSlushAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents txtSlushUserHash As System.Windows.Forms.TextBox
    Friend WithEvents txtSlushUnconfirmedPayout As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents dataSlush As System.Windows.Forms.DataGridView
    Friend WithEvents txtSlushEstimatedPayout As System.Windows.Forms.TextBox
    Friend WithEvents txtSlushConfirmedPayout As System.Windows.Forms.TextBox
    Friend WithEvents chkBitMinterShowWorkerTotals As System.Windows.Forms.CheckBox
    Friend WithEvents chkBitMinterShowWorkerCheckPoint As System.Windows.Forms.CheckBox
    Friend WithEvents txtPleaseSupport As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents tabIdleWorkers As System.Windows.Forms.TabPage
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPPort As System.Windows.Forms.TextBox
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPServer As System.Windows.Forms.TextBox
    Friend WithEvents chkIdleEMailAlerts As System.Windows.Forms.CheckBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPAlertName As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPAlertSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPAlertAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents chkSMTPSSL As System.Windows.Forms.CheckBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPFromName As System.Windows.Forms.TextBox
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPFromAddress As System.Windows.Forms.TextBox
    Friend WithEvents cmdSendTestEMail As System.Windows.Forms.Button
    Friend WithEvents tabConfigureMultipool As System.Windows.Forms.TabPage
    Friend WithEvents chkMultipoolEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtMultipoolAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tabMultipool As System.Windows.Forms.TabPage
    Friend WithEvents txtMultipoolUserHashRate As System.Windows.Forms.TextBox
    Friend WithEvents tabMultiDataGrids As System.Windows.Forms.TabControl
    Friend WithEvents tabCoinData As System.Windows.Forms.TabPage
    Friend WithEvents dataMultiCoinData As System.Windows.Forms.DataGridView
    Friend WithEvents tabWorkerData As System.Windows.Forms.TabPage
    Friend WithEvents dataMultiWorkerData As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents chkP2PoolScrypt As System.Windows.Forms.CheckBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtBTCGuild24HourBTCPayout As System.Windows.Forms.TextBox
    Friend WithEvents chkP2PPublicPool As System.Windows.Forms.CheckBox
    Friend WithEvents tabConfigBlockChainInfo As System.Windows.Forms.TabPage
    Friend WithEvents chkBlockChainInfoEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents tabBlockchainInfo As System.Windows.Forms.TabPage
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_NextDifficultyChangeTime As System.Windows.Forms.TextBox
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_AsOfTimestamp As System.Windows.Forms.TextBox
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_Difficulty As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_NetworkHashRate As System.Windows.Forms.TextBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_MarketPriceUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_MinsBetweenBlocks As System.Windows.Forms.TextBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_NextDifficultyChangeBlocks As System.Windows.Forms.TextBox
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents txtBCI_EstimatedNextDifficulty As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents cmbBlockChainInfoRefreshRate As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents tabScryptGuild As System.Windows.Forms.TabPage
    Friend WithEvents tabConfigureScryptGuild As System.Windows.Forms.TabPage
    Friend WithEvents chkScryptGuildShowBalanceData As System.Windows.Forms.CheckBox
    Friend WithEvents chkScryptGuildShowWorkerData As System.Windows.Forms.CheckBox
    Friend WithEvents chkScryptGuildEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtScryptGuildAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabBalances As System.Windows.Forms.TabPage
    Friend WithEvents dataScryptGuildBalanceData As System.Windows.Forms.DataGridView
    Friend WithEvents tabWorkerInfo As System.Windows.Forms.TabPage
    Friend WithEvents dataScryptGuildWorkerData As System.Windows.Forms.DataGridView
    Friend WithEvents txtScryptGuildUserHash As System.Windows.Forms.TextBox
    Friend WithEvents chkScryptGuildOmitTinyBalances As System.Windows.Forms.CheckBox
    Friend WithEvents lblScryptGuildConfirmedBTC As System.Windows.Forms.Label
    Friend WithEvents txtScryptGuildConfirmedBTC As System.Windows.Forms.TextBox
    Friend WithEvents tabConfigureEligius As System.Windows.Forms.TabPage
    Friend WithEvents chkEligiusEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtEligiusBTCAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tabEligius As System.Windows.Forms.TabPage
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents dataEligius As System.Windows.Forms.DataGridView
    Friend WithEvents txtEligiusUserHash As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusPoolHash256 As System.Windows.Forms.TextBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusEstimatedBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusBalanceLastBlock As System.Windows.Forms.TextBox
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusPayoutQueuePositions As System.Windows.Forms.TextBox
    Friend WithEvents tabOzcoin As System.Windows.Forms.TabPage
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtOzUserHashRate As System.Windows.Forms.TextBox
    Friend WithEvents txtOzPendingPayoutPPS As System.Windows.Forms.TextBox
    Friend WithEvents txtOzBTCRoundDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOZPOTTotalShares As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOZPOT_PPSEquivalent As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOZPOTHighestShare As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOzPOTPendingPayout As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOzPendingPayoutDGM As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOzBTCEfficiency As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOzBTCRoundShares As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dataOz As System.Windows.Forms.DataGridView
    Friend WithEvents txtOzPoolHashrate As System.Windows.Forms.TextBox
    Friend WithEvents txtOzEstimatedPayout As System.Windows.Forms.TextBox
    Friend WithEvents txtOzCompletedPayout As System.Windows.Forms.TextBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tabIdleEmail As System.Windows.Forms.TabPage
    Friend WithEvents tabIdleUserProcess As System.Windows.Forms.TabPage
    Friend WithEvents txtIdleStartAppName As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtIdleStartParms As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents cmdIdleStartAppFinder As System.Windows.Forms.Button
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusLast90DaysLuck As System.Windows.Forms.TextBox
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusLast30DaysLuck As System.Windows.Forms.TextBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusLast7DaysLuck As System.Windows.Forms.TextBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusLast24HourLuck As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusLast12HourLuck As System.Windows.Forms.TextBox
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents txtEligiusLast10BlockLuck As System.Windows.Forms.TextBox
    Friend WithEvents chkIdlePopup As System.Windows.Forms.CheckBox
    Friend WithEvents chkIdleStartApp As System.Windows.Forms.CheckBox
    Friend WithEvents chkIdleWorkPopUpWithBeeps As System.Windows.Forms.CheckBox
    Friend WithEvents tabLTCRabbit As System.Windows.Forms.TabPage
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents txtLTCRabbitUserHash As System.Windows.Forms.TextBox
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents txtLTCRabbitConfirmedLTC As System.Windows.Forms.TextBox
    Friend WithEvents dataLTCRabbit As System.Windows.Forms.DataGridView
    Friend WithEvents tabConfigureLTCRabbit As System.Windows.Forms.TabPage
    Friend WithEvents chkLTCRabbitEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtLTCRabbitAPIKey As System.Windows.Forms.TextBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents txtLTCRabbitPoolhash As System.Windows.Forms.TextBox

End Class
