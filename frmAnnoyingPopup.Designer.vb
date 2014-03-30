<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnnoyingPopup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnnoyingPopup))
        Me.lblIdleWorker = New System.Windows.Forms.Label()
        Me.timer_beep = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblIdleWorker
        '
        Me.lblIdleWorker.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdleWorker.ForeColor = System.Drawing.Color.Red
        Me.lblIdleWorker.Location = New System.Drawing.Point(12, 9)
        Me.lblIdleWorker.Name = "lblIdleWorker"
        Me.lblIdleWorker.Size = New System.Drawing.Size(523, 154)
        Me.lblIdleWorker.TabIndex = 0
        Me.lblIdleWorker.Text = "Worker X on pool Y went idle at 03 Mar 2014 @ 15:21:03"
        '
        'timer_beep
        '
        Me.timer_beep.Interval = 60000
        '
        'frmAnnoyingPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 172)
        Me.Controls.Add(Me.lblIdleWorker)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnnoyingPopup"
        Me.Text = "Idle worker alert!"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblIdleWorker As System.Windows.Forms.Label
    Friend WithEvents timer_beep As System.Windows.Forms.Timer
End Class
