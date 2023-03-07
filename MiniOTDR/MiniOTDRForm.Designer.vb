<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiniOTDRForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiniOTDRForm))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.WavelengthBox = New System.Windows.Forms.TextBox()
		Me.PulseWidthBox = New System.Windows.Forms.TextBox()
		Me.RangeBox = New System.Windows.Forms.TextBox()
		Me.AverageTimeBox = New System.Windows.Forms.TextBox()
		Me.HandleLbl = New System.Windows.Forms.Label()
		Me.pnlOverview = New System.Windows.Forms.Panel()
		Me.MainMenu = New System.Windows.Forms.MenuStrip()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.RunButton = New System.Windows.Forms.Button()
		Me.FileDialog = New System.Windows.Forms.OpenFileDialog()
		Me.WavelengthLbl = New System.Windows.Forms.Label()
		Me.PulseWidthLbl = New System.Windows.Forms.Label()
		Me.RangeLbl = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtMarkers1 = New System.Windows.Forms.TextBox()
		Me.txtMarkers2 = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.lblActdB = New System.Windows.Forms.Label()
		Me.lblRefDb = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.AxGraph = New AxGNGRAPHLib.AxGNGraph()
		Me.AxOverview = New AxGNGRAPHLib.AxGNOverview()
		Me.pnlOverview.SuspendLayout()
		Me.MainMenu.SuspendLayout()
		CType(Me.AxGraph, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.AxOverview, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label1.Location = New System.Drawing.Point(13, 69)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(88, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Wavelength (nm)"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label2.Location = New System.Drawing.Point(13, 107)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(81, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Pulse Width (m)"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label3.Location = New System.Drawing.Point(13, 149)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(62, 13)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Range (km)"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label4.Location = New System.Drawing.Point(12, 189)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(95, 13)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "Averaging Time (s)"
		'
		'WavelengthBox
		'
		Me.WavelengthBox.Location = New System.Drawing.Point(126, 66)
		Me.WavelengthBox.Name = "WavelengthBox"
		Me.WavelengthBox.Size = New System.Drawing.Size(51, 20)
		Me.WavelengthBox.TabIndex = 0
		'
		'PulseWidthBox
		'
		Me.PulseWidthBox.Location = New System.Drawing.Point(126, 104)
		Me.PulseWidthBox.Name = "PulseWidthBox"
		Me.PulseWidthBox.Size = New System.Drawing.Size(51, 20)
		Me.PulseWidthBox.TabIndex = 1
		'
		'RangeBox
		'
		Me.RangeBox.Location = New System.Drawing.Point(126, 146)
		Me.RangeBox.Name = "RangeBox"
		Me.RangeBox.Size = New System.Drawing.Size(51, 20)
		Me.RangeBox.TabIndex = 2
		'
		'AverageTimeBox
		'
		Me.AverageTimeBox.Location = New System.Drawing.Point(126, 186)
		Me.AverageTimeBox.Name = "AverageTimeBox"
		Me.AverageTimeBox.Size = New System.Drawing.Size(51, 20)
		Me.AverageTimeBox.TabIndex = 3
		'
		'HandleLbl
		'
		Me.HandleLbl.AutoSize = True
		Me.HandleLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.HandleLbl.Location = New System.Drawing.Point(278, 33)
		Me.HandleLbl.Name = "HandleLbl"
		Me.HandleLbl.Size = New System.Drawing.Size(89, 13)
		Me.HandleLbl.TabIndex = 8
		Me.HandleLbl.Text = "Signature Handle"
		'
		'pnlOverview
		'
		Me.pnlOverview.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.pnlOverview.Controls.Add(Me.AxOverview)
		Me.pnlOverview.Location = New System.Drawing.Point(281, 260)
		Me.pnlOverview.Name = "pnlOverview"
		Me.pnlOverview.Size = New System.Drawing.Size(112, 75)
		Me.pnlOverview.TabIndex = 10
		'
		'MainMenu
		'
		Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
		Me.MainMenu.Location = New System.Drawing.Point(0, 0)
		Me.MainMenu.Name = "MainMenu"
		Me.MainMenu.Size = New System.Drawing.Size(617, 24)
		Me.MainMenu.TabIndex = 11
		Me.MainMenu.Text = "MenuStrip1"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		Me.FileToolStripMenuItem.Text = "&File"
		'
		'OpenToolStripMenuItem
		'
		Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
		Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
		Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.OpenToolStripMenuItem.Text = "&Open"
		'
		'SaveToolStripMenuItem
		'
		Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
		Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
		Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.SaveToolStripMenuItem.Text = "&Save"
		'
		'SaveAsToolStripMenuItem
		'
		Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
		Me.SaveAsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
		Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.SaveAsToolStripMenuItem.Text = "Save &As..."
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.ExitToolStripMenuItem.Text = "E&xit"
		'
		'RunButton
		'
		Me.RunButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.RunButton.Location = New System.Drawing.Point(151, 230)
		Me.RunButton.Name = "RunButton"
		Me.RunButton.Size = New System.Drawing.Size(100, 67)
		Me.RunButton.TabIndex = 4
		Me.RunButton.Text = "Run"
		Me.RunButton.UseVisualStyleBackColor = True
		'
		'FileDialog
		'
		Me.FileDialog.DefaultExt = "sor"
		Me.FileDialog.Filter = "sor files (*.sor)|*.sor"
		Me.FileDialog.InitialDirectory = "c:\users\public\documents\photon kinetics\8000 OTDR\Data"
		'
		'WavelengthLbl
		'
		Me.WavelengthLbl.AutoSize = True
		Me.WavelengthLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.WavelengthLbl.Location = New System.Drawing.Point(187, 69)
		Me.WavelengthLbl.Name = "WavelengthLbl"
		Me.WavelengthLbl.Size = New System.Drawing.Size(88, 13)
		Me.WavelengthLbl.TabIndex = 16
		Me.WavelengthLbl.Text = "Wavelength (nm)"
		'
		'PulseWidthLbl
		'
		Me.PulseWidthLbl.AutoSize = True
		Me.PulseWidthLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.PulseWidthLbl.Location = New System.Drawing.Point(187, 107)
		Me.PulseWidthLbl.Name = "PulseWidthLbl"
		Me.PulseWidthLbl.Size = New System.Drawing.Size(81, 13)
		Me.PulseWidthLbl.TabIndex = 17
		Me.PulseWidthLbl.Text = "Pulse Width (m)"
		'
		'RangeLbl
		'
		Me.RangeLbl.AutoSize = True
		Me.RangeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.RangeLbl.Location = New System.Drawing.Point(187, 149)
		Me.RangeLbl.Name = "RangeLbl"
		Me.RangeLbl.Size = New System.Drawing.Size(62, 13)
		Me.RangeLbl.TabIndex = 18
		Me.RangeLbl.Text = "Range (km)"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label5.Location = New System.Drawing.Point(123, 50)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(35, 13)
		Me.Label5.TabIndex = 19
		Me.Label5.Text = "Setup"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label8.Location = New System.Drawing.Point(187, 50)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(37, 13)
		Me.Label8.TabIndex = 20
		Me.Label8.Text = "Actual"
		'
		'txtMarkers1
		'
		Me.txtMarkers1.Location = New System.Drawing.Point(417, 276)
		Me.txtMarkers1.Name = "txtMarkers1"
		Me.txtMarkers1.Size = New System.Drawing.Size(51, 20)
		Me.txtMarkers1.TabIndex = 22
		'
		'txtMarkers2
		'
		Me.txtMarkers2.Location = New System.Drawing.Point(523, 276)
		Me.txtMarkers2.Name = "txtMarkers2"
		Me.txtMarkers2.Size = New System.Drawing.Size(51, 20)
		Me.txtMarkers2.TabIndex = 23
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label6.Location = New System.Drawing.Point(414, 260)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(62, 13)
		Me.Label6.TabIndex = 24
		Me.Label6.Text = "Act. Marker"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label7.Location = New System.Drawing.Point(520, 260)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(63, 13)
		Me.Label7.TabIndex = 25
		Me.Label7.Text = "Ref. Marker"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label9.Location = New System.Drawing.Point(474, 279)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(21, 13)
		Me.Label9.TabIndex = 26
		Me.Label9.Text = "km"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label10.Location = New System.Drawing.Point(580, 279)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(21, 13)
		Me.Label10.TabIndex = 27
		Me.Label10.Text = "km"
		'
		'lblActdB
		'
		Me.lblActdB.AutoSize = True
		Me.lblActdB.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblActdB.Location = New System.Drawing.Point(414, 308)
		Me.lblActdB.Name = "lblActdB"
		Me.lblActdB.Size = New System.Drawing.Size(46, 13)
		Me.lblActdB.TabIndex = 28
		Me.lblActdB.Text = "lblActdB"
		'
		'lblRefDb
		'
		Me.lblRefDb.AutoSize = True
		Me.lblRefDb.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblRefDb.Location = New System.Drawing.Point(520, 308)
		Me.lblRefDb.Name = "lblRefDb"
		Me.lblRefDb.Size = New System.Drawing.Size(48, 13)
		Me.lblRefDb.TabIndex = 29
		Me.lblRefDb.Text = "lblRefDb"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label13.Location = New System.Drawing.Point(580, 308)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(20, 13)
		Me.Label13.TabIndex = 30
		Me.Label13.Text = "dB"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label14.Location = New System.Drawing.Point(474, 308)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(20, 13)
		Me.Label14.TabIndex = 31
		Me.Label14.Text = "dB"
		'
		'AxGraph
		'
		Me.AxGraph.Location = New System.Drawing.Point(281, 50)
		Me.AxGraph.Name = "AxGraph"
		Me.AxGraph.OcxState = CType(resources.GetObject("AxGraph.OcxState"), System.Windows.Forms.AxHost.State)
		Me.AxGraph.Size = New System.Drawing.Size(324, 192)
		Me.AxGraph.TabIndex = 21
		'
		'AxOverview
		'
		Me.AxOverview.Dock = System.Windows.Forms.DockStyle.Fill
		Me.AxOverview.Location = New System.Drawing.Point(0, 0)
		Me.AxOverview.Name = "AxOverview"
		Me.AxOverview.OcxState = CType(resources.GetObject("AxOverview.OcxState"), System.Windows.Forms.AxHost.State)
		Me.AxOverview.Size = New System.Drawing.Size(112, 75)
		Me.AxOverview.TabIndex = 0
		'
		'MiniOTDRForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(617, 344)
		Me.Controls.Add(Me.Label14)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.lblRefDb)
		Me.Controls.Add(Me.lblActdB)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.txtMarkers2)
		Me.Controls.Add(Me.txtMarkers1)
		Me.Controls.Add(Me.AxGraph)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.RangeLbl)
		Me.Controls.Add(Me.PulseWidthLbl)
		Me.Controls.Add(Me.WavelengthLbl)
		Me.Controls.Add(Me.RunButton)
		Me.Controls.Add(Me.pnlOverview)
		Me.Controls.Add(Me.HandleLbl)
		Me.Controls.Add(Me.AverageTimeBox)
		Me.Controls.Add(Me.RangeBox)
		Me.Controls.Add(Me.PulseWidthBox)
		Me.Controls.Add(Me.WavelengthBox)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.MainMenu)
		Me.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.MainMenuStrip = Me.MainMenu
		Me.MaximumSize = New System.Drawing.Size(633, 383)
		Me.MinimumSize = New System.Drawing.Size(633, 383)
		Me.Name = "MiniOTDRForm"
		Me.ShowIcon = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Mini OTDR"
		Me.TopMost = True
		Me.pnlOverview.ResumeLayout(False)
		Me.MainMenu.ResumeLayout(False)
		Me.MainMenu.PerformLayout()
		CType(Me.AxGraph, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.AxOverview, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents WavelengthBox As TextBox
	Friend WithEvents PulseWidthBox As TextBox
	Friend WithEvents RangeBox As TextBox
	Friend WithEvents AverageTimeBox As TextBox
	Friend WithEvents HandleLbl As Label
	Friend WithEvents pnlOverview As Panel
	Friend WithEvents MainMenu As MenuStrip
	Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents RunButton As Button
	Friend WithEvents FileDialog As OpenFileDialog
	Friend WithEvents WavelengthLbl As Label
	Friend WithEvents PulseWidthLbl As Label
	Friend WithEvents RangeLbl As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents AxOverview As AxGNGRAPHLib.AxGNOverview
	Friend WithEvents AxGraph As AxGNGRAPHLib.AxGNGraph
	Friend WithEvents txtMarkers1 As TextBox
	Friend WithEvents txtMarkers2 As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents lblActdB As Label
	Friend WithEvents lblRefDb As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label14 As Label
End Class
