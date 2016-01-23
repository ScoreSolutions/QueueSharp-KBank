Imports System.IO
Imports Engine
Imports HeartBeat
Imports System.Data

Public Class frmAisCSIAgent
    Dim patch As String = "D:\HeartBeat\HeartBeat.txt"

    Private Sub frmHQAgent_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = "KBank CSI Agent V" & getMyVersion()
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub tmCSISurvey_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmCSISurvey.Tick
        lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
        Application.DoEvents()

        tmCSISurvey.Enabled = False
        Dim eng As New CSISurveyENG
        eng.SetTextLog(txtLog)
        eng.FilterData(lblTime)
        eng.SendATSR(lblTime)
        eng.GetATSRResult(lblTime)
        eng.SendResultToShop(lblTime)
        eng = Nothing
        tmCSISurvey.Enabled = True
        'UpdateHB(patch, "CSISurvey")
    End Sub

    Private Sub frmAisCSIAgent_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Text = "KBank CSI Agent V" & getMyVersion()
    End Sub

    Public Function getMyVersion() As String
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Return version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision
    End Function

    Private Sub txtLog_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLog.KeyPress
        e.Handled = True
    End Sub

    Private Sub tmCalTarget_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmCalTarget.Tick
        tmCalTarget.Enabled = False
        Dim eng As New Engine.CSISurveyENG
        eng.CalTarget()
        eng = Nothing
        tmCalTarget.Enabled = True
    End Sub
End Class