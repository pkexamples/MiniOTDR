Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports AxGNGRAPHLib
Imports GN8000Lib
Imports GNOTDRLib
Imports GNOTDRBELLCOREHANDLERLib
Imports GNOTDRSIGNATURELib
Imports GNOTDRSIGNATURESERVERLib
Imports GNOTDRSIGCONNECTIONMGRLib
Imports GNOTDRSIGNATURERENDERERLib
Imports GNGRAPHLib

Public Class MiniOTDRForm

#Region "Fields"
	Private Const NominalOTDRSpeedOfLight = 100000000.0# 'm/s round trip, nominal value
	Private Const SpeedOfLight As Double = 299792458.0
	Private GN8k As GN8000Lib.GN8000
	Private SigServer As GNOTDRSIGNATURESERVERLib.GNOTDRSignatureServer
	Private WithEvents OTDRAcq As GNOTDRLib.GNOTDR
	Private ConnMgr As GNOTDRSIGCONNECTIONMGRLib.GNOTDRSigConnectionMgr
	Private FileHandler As GNOTDRBELLCOREHANDLERLib.GNOTDRBellcoreHandler
	Private FileName As String
	Private SigHandle As Integer
	Private IsClosing As Boolean
	Private firstScale As Boolean
	Private Graph As GNGraph
	Private Overview As GNOverview
	Private Markers As IList(Of GNGRAPHLib.GNMarker)
#End Region

#Region "Form Creation, Load, and Closed"
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()
		' Add any initialization after the InitializeComponent() call.

		Graph = DirectCast(AxGraph.GetOcx, GNGraph)

		' Initialize variables, clear "Actual" label text
		SigHandle = -1
		FileName = ""
		WavelengthBox.Text = 1310
		PulseWidthBox.Text = 20
		RangeBox.Text = 16
		AverageTimeBox.Text = 5
		firstScale = True
		WavelengthLbl.Text = ""
		PulseWidthLbl.Text = ""
		RangeLbl.Text = ""
		lblActdB.Text = ""
		lblRefDb.Text = ""
	End Sub

	Private Sub MiniOTDRForm_Load(sender As Object, e As EventArgs) Handles Me.Load
		' Create OTDR objects
		GN8k = New GN8000()
		SigServer = New GNOTDRSignatureServer()
		SigHandle = SigServer.Add()
		HandleLbl.Text = $"Signature Handle {SigHandle}"
		FileHandler = New GNOTDRBellcoreHandler()

		' Initialize 7600 card 0
		GN8k.Initialize(0, SigServer)

		If GN8k.ONLINE Then
			OTDRAcq = GN8k.OTDR
		Else
			MsgBox("Sorry, OTDR did not initialize correctly.")
			Close()
		End If

		' Add some Graph features
		With AxGraph
			.ScrollBars()
			.AttachOverview(AxOverview.GetOcx())
			With .Axes
				.HorizUnits = "km"
				.HorizUnitFactor = 0.001 * NominalOTDRSpeedOfLight
				.VertUnits = "dB"
				.VertUnitFactor = 0.001
			End With
			.Grid.Color = RGB(255, 0, 0) ' Red
		End With

		' Weird -- load gets called TWICE! Don't add extra markers...
		If Markers Is Nothing Then
			Markers = New List(Of GNMarker)
			' Add two markers for basic measurements
			AddMarker()
			AddMarker()
			Markers(1).Style = LineStyle.lsDash
		End If

		' Set up connection between signature and graph
		Dim sConnID As String
		ConnMgr = GetNewConnectionManager()
		sConnID = $"Simple OTDR: {SigHandle}"
		ConnMgr.MakeConnection(CShort(SigHandle), AxGraph.GetOcx(), GetNewRenderer(), sConnID)
	End Sub

	Private Sub MiniOTDRForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
		If ConnMgr IsNot Nothing Then
			ConnMgr.BreakAll()
			ConnMgr.DisconnectServer()
		End If

		If Markers IsNot Nothing AndAlso Markers.Count > 0 Then
			For Each m In Markers
				RemoveHandler m.MarkerMoved, AddressOf MarkerMoved_Handler
			Next
			ClearMarkers()
		End If

		AxGraph.RemoveAll()

		If GN8k.ONLINE Then
			IsClosing = True
			OTDRAcq.Stop()
		End If

		If SigHandle > -1 Then
			SigServer.Remove(SigHandle)
		End If

		SigServer = Nothing
		GN8k = Nothing
		OTDRAcq = Nothing
		ConnMgr = Nothing
		FileHandler = Nothing
	End Sub
#End Region

#Region "Properties"
	Public Property MarkerLocation(ByVal marker As GNMarker) As Double
		Get
			Return 0.5 * marker.LogXPosition * SpeedOfLight / Signature.GroupIndex
		End Get
		Set(ByVal value As Double)
			marker.LogXPosition = (value * Signature.GroupIndex) / (0.5 * SpeedOfLight)
		End Set
	End Property

	Public ReadOnly Property Signature As GNOTDRSignature
		Get
			Return CType(SigServer.Signature(CShort(SigHandle)), GNOTDRSignature)
		End Get
	End Property
#End Region

#Region "Main Menu"
	Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
		Try
			If GN8k.ONLINE Then
				OTDRAcq.Stop()
			End If
			With FileDialog
				.Title = "Select file to open"
				.ShowDialog()
				If FileHandler.CanHandle(.FileName) Then
					FileName = .FileName
					FileHandler.Read(.FileName, SigServer.Signature(SigHandle))
					SaveToolStripMenuItem.Enabled = True
					SaveAsToolStripMenuItem.Enabled = True
					DisplayTraceParams()
					RangeBox.Text = RangeLbl.Text
					SetScale()
				Else
					MsgBox($"File { .FileName} is not valid")
				End If
			End With
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
		Try
			If GN8k.ONLINE Then
				OTDRAcq.Stop()
			End If
			If String.IsNullOrEmpty(FileName) Then
				SaveAsToolStripMenuItem_Click(sender, e)
			Else
				FileHandler.Write(FileName, SigServer.Signature(SigHandle))
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
		Try
			If GN8k.ONLINE Then
				OTDRAcq.Stop()
			End If

			If SigHandle = -1 Then Exit Sub

			With FileDialog
				.FilterIndex = 1
				.Title = "Save File"
				.ValidateNames = False
				If .ShowDialog() = DialogResult.OK And .FileName <> "" Then
					FileName = .FileName
					FileHandler.Write(FileName, SigServer.Signature(SigHandle))
				End If
			End With
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
		Close()
	End Sub

#End Region

#Region "OTDR Acquisition"
	Private Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click
		RunButton.Enabled = False
		Try
			With OTDRAcq
				.AcquisitionMode = GNOTDRAcquisitionMode.AvgTime
				Dim wave As Integer = Integer.Parse(WavelengthBox.Text)
				.Wavelength = wave
				.Range = Double.Parse(RangeBox.Text) * 1000.0# / NominalOTDRSpeedOfLight 'Convert km to m, then convert to seconds
				.Pulsewidth = Double.Parse(PulseWidthBox.Text) / NominalOTDRSpeedOfLight 'Convert m to time
				.AverageTime = Double.Parse(AverageTimeBox.Text) 'Already in seconds
				.Pointspacing = 2 / NominalOTDRSpeedOfLight

				' Clear "actual" labels
				WavelengthLbl.Text = ""
				PulseWidthLbl.Text = ""
				RangeLbl.Text = ""

				SetScale()

				SaveAsToolStripMenuItem.Enabled = True
				.Acquire(CShort(SigHandle))
				DisplayTraceParams()
			End With
		Catch ex As Exception
			MsgBox(ex.Message)
		Finally
			RunButton.Enabled = True
		End Try
	End Sub

	Private Sub OTDRAcq_OTDRAcquisitionStop(Reason As GNOTDRStopReason) Handles OTDRAcq.OTDRAcquisitionStop
		If IsClosing Then
			Return
		End If
		If Reason = GNOTDRStopReason.AcqError Then
			Dim Err As String = ""
			Dim ErrNum As Long
			ErrNum = OTDRAcq.Error(Err)
			MsgBox(Err)
		ElseIf Reason = GNOTDRStopReason.AcqCompleted Or Reason = GNOTDRStopReason.AcqAborted Then
			'DisplayTraceParams()
		End If
		'RunButton.Enabled = True
	End Sub

#End Region

#Region "Markers text boxes"
	Private Sub txtMarkers_KeyPress(sender As Object, e As KeyPressEventArgs)
		If e.KeyChar = ChrW(Keys.Enter) Then
			Me.ActiveControl = Nothing
		End If
	End Sub

	Private Sub txtMarkers_Leave(sender As Object, e As EventArgs) Handles txtMarkers1.Leave, txtMarkers2.Leave
		If Not ValidLocation(txtMarkers1) Then
			txtMarkers1.Text = $"{Markers(0).LogXPosition * 0.001 * NominalOTDRSpeedOfLight:#0.000}"
		Else
			Markers(0).LogXPosition = Double.Parse(txtMarkers1.Text) / (0.001 * NominalOTDRSpeedOfLight)
		End If
		If Not ValidLocation(txtMarkers2) Then
			txtMarkers2.Text = $"{Markers(1).LogXPosition * 0.001 * NominalOTDRSpeedOfLight:0.000}"
		Else
			Markers(1).LogXPosition = Double.Parse(txtMarkers2.Text) / (0.001 * NominalOTDRSpeedOfLight)
		End If
	End Sub

	Private Function ValidLocation(txt As TextBox) As Boolean
		Dim loc As Double
		Dim isNumber As Boolean = Double.TryParse(txt.Text.Trim, loc)
		If Not isNumber Then
			Return False
		ElseIf loc / (0.001 * NominalOTDRSpeedOfLight) < AxGraph.LogicalXMin OrElse
				loc / (0.001 * NominalOTDRSpeedOfLight) > AxGraph.LogicalXMax Then
			Return False
		Else
			Return True
		End If
	End Function

#End Region

#Region "Markers"

	Public Function AddMarker() As GNMarker
		Dim m As GNMarker = AxGraph.Markers.Add()
		m.Visible = True
		m.Color = Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(Color.White))
		AddHandler m.MarkerMoved, AddressOf MarkerMoved_Handler
		' Must keep references to markers. Garbage collector is not smart enough to know that the
		' graph is holding on to the marker, and you'll stop getting events from it if you don't keep a reference.
		If Not Markers.Contains(m) Then
			Markers.Add(m)
		End If
		Return m
	End Function

	Public Sub ClearMarkers()
		For i As Integer = AxGraph.Markers.Count - 1 To 0 Step -1
			AxGraph.Markers.Remove(CShort(i))
		Next
		Markers.Clear()
	End Sub

	Private Sub MarkerMoved_Handler(ByVal markerID As Short, ByVal x As Double, ByVal y As Double, ByVal deltaX As Integer, ByVal deltaY As Integer)
		If Markers.Count < 2 Then Return
		Dim marker As GNMarker = DirectCast(AxGraph.Markers.Item(markerID), GNMarker)
		UpdateMarker(marker)
	End Sub

	Private Sub UpdateMarker(ByVal marker As GNMarker)
		' Call when marker is updated by either being moved or having the underlying waveform update
		If SigHandle < 0 Then
			Return
		End If
		' scale values to real world.
		Dim valid As Boolean
		Dim value As Double
		GetMarkerDataValue(marker, value, valid)
		Dim args As MarkerUpdatedEventArgs = New MarkerUpdatedEventArgs(marker, MarkerLocation(marker), value, valid)
		OnMarkerUpdated(marker, args)
	End Sub

	Protected Overridable Sub OnMarkerUpdated(sender As Object, e As MarkerUpdatedEventArgs)
		RemoveHandler CType(e.Marker, GNMarker).MarkerMoved, AddressOf MarkerMoved_Handler
		Dim loc = e.x / 1000
		Dim txt = loc.ToString("0.000")
		Dim dB = e.y.ToString("0.00")
		If e.Marker.Equals(Markers(0)) Then
			txtMarkers1.Text = txt
			lblActdB.Text = dB
		ElseIf e.Marker.Equals(Markers(1)) Then
			txtMarkers2.Text = txt
			lblRefDb.Text = dB
		End If
		AddHandler CType(e.Marker, GNMarker).MarkerMoved, AddressOf MarkerMoved_Handler
	End Sub

	Private Delegate Sub GetMarkerDataValueDel(ByVal marker As GNMarker, ByRef value As Double, ByRef isValid As Boolean)
	Private Sub GetMarkerDataValue(ByVal marker As GNMarker, ByRef value As Double, ByRef isValid As Boolean)
		If Me.InvokeRequired Then
			Me.Invoke(New GetMarkerDataValueDel(AddressOf GetMarkerDataValue), marker, value, isValid)
		Else
			Dim waveform As IGNWaveForm3 = DirectCast(AxGraph.WaveForms.Item(0), IGNWaveForm3)
			Dim renderer As IGNRender3 = DirectCast(waveform.Renderer, IGNRender3)
			renderer.GetValueAt2(marker.LogXPosition, isValid, value)
			value *= 0.001
		End If
	End Sub

#End Region

#Region "Private helper methods"

	Private Function GetNewConnectionManager() As GNOTDRSigConnectionMgr
		Dim cmgr As GNOTDRSigConnectionMgr = New GNOTDRSigConnectionMgr
		cmgr.ConnectServer(SigServer)
		Return cmgr
	End Function

	Private Function GetNewRenderer() As GNOTDRSignatureRenderer
		Return DirectCast(SigServer.CreateRenderer(), GNOTDRSignatureRenderer)
	End Function

	Private Sub SetScale()
		Dim range As Double
		If Double.TryParse(RangeBox.Text * 1000.0# / NominalOTDRSpeedOfLight, range) Then
			If firstScale Then
				firstScale = False
				Markers(0).LogXPosition = range * 0.4
				Markers(1).LogXPosition = range * 0.6
			End If
			With AxGraph
				.SetLogMinMax(0, range, -15000, 32000)
				.SetLogView(0, range, -15000, 32000)
			End With
		Else
			MsgBox($"Invalid Range value: {RangeBox.Text}")
		End If
	End Sub

	Private Sub DisplayTraceParams()

		If Signature Is Nothing Then
			WavelengthLbl.Text = ""
			PulseWidthLbl.Text = ""
			RangeLbl.Text = ""
		Else
			With Signature
				WavelengthLbl.Text = $"{ .Wavelength.ToString("0")}"
				PulseWidthLbl.Text = $"{ (.PulseWidth * NominalOTDRSpeedOfLight).ToString("0")}"
				RangeLbl.Text = $"{ (.Trace.NumPoints * .PointSpacing * (NominalOTDRSpeedOfLight / 1000)).ToString("0") }"
			End With
		End If
	End Sub

#End Region

End Class

Public Class MarkerUpdatedEventArgs : Inherits EventArgs
	Public Marker As GNMarker
	Public x As Double
	Public y As Double
	Public IsValid As Boolean
	Public Sub New()
	End Sub
	Public Sub New(ByVal marker As GNMarker, ByVal x As Double, ByVal y As Double, ByVal isValid As Boolean)
		Me.Marker = marker
		Me.x = x
		Me.y = y
		Me.IsValid = isValid
	End Sub
End Class
