﻿Imports System.IO
Imports System.Data
Imports AMS
Imports Engine.Kiosk.KioskModule
Imports Engine.Kiosk

Public Class frmKiosCapture
    Private ConfigINI As Profile.Ini
    Private webcam As WebCam
    Dim _MobileNumber As String
    Dim _IsCapture As Boolean = False

    Dim CamIndex As Integer = 0

    Public WriteOnly Property MobileNumber() As String
        Set(ByVal value As String)
            _MobileNumber = value
        End Set
    End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConfigINI = New Profile.Ini(Application.StartupPath & "\kiosk.ini")
        'Dim DeBug As String = DateTime.Now.ToString("HH:mm:ss.fff") & " Start" & vbNewLine
        FillCustomerData()
        'DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " After GetCustomerInfo" & vbNewLine
        Try
            'Threading.Thread.Sleep(1000)
            webcam = New WebCam()
            webcam.InitializeWebCam(pcCapture)
            webcam.Start(CamIndex)
            'DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " After webcam.Start" & vbNewLine

            Me.BackgroundImage = Image.FromFile(Application.StartupPath & "/images/bgCapture.jpg")

            Dim FormWidth As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim FormHeight As Integer = Screen.PrimaryScreen.Bounds.Height
            Dim CaptureHeight As Integer = ConfigINI.GetValue("CaptureImage", "CaptureHeight", "")
            Dim CaptureWidth As Integer = ConfigINI.GetValue("CaptureImage", "CaptureWidth", "")
            Me.Size = New Size(FormWidth, FormHeight)
            pcCapture.BringToFront()
            pcCapture.Size = New Size(640, 480)
            btnDiaplayImage.Size = New Size(640, 480)
            pcCapture.Location = New Point(FormWidth / 2 - 500, FormHeight / 2 - 220)
            btnDiaplayImage.Location = New Point(FormWidth / 2 - 500, FormHeight / 2 - 220)
            pbCapture.Location = New Point((FormWidth / 2 - (pbCapture.Width / 2)) - 200, FormHeight / 2 + 270)
            pbReCapture.Location = New Point((FormWidth / 2 - (pbCapture.Width / 2)) - 240, FormHeight / 2 + 270)
            pbSave.Location = New Point((FormWidth / 2 - (pbCapture.Width / 2) - 100), FormHeight / 2 + 270)
            pbClose.Location = New Point(FormWidth - 40, 12)
            pnlCusInfo.Location = New Point(FormWidth / 2 + 150, FormHeight / 2 - 220)

            'DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " After Set Form" & vbNewLine
            webcam.CaptureHeight(CaptureHeight)
            webcam.CaptureWidth(CaptureWidth)
            'DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " After Set webcam" & vbNewLine
            'MessageBox.Show(DeBug)
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Sub FillCustomerData()
        'DisplayPAGroup.Text = CustomerPAGroup
        'DisplaySegment.Text = Segment
        DisplayImage.Text = CustomerURLCapture

        Dim vDate As New Date(1, 1, 1)
        If CustomerURLCaptureDate.Trim <> "" Then
            Dim arr As String() = CustomerURLCaptureDate.Substring(0, 10).Split("/")
            vDate = New Date(arr(2), arr(0), arr(1))
            DisplayLastDate.Text = vDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
        Else
            DisplayLastDate.Text = ""
        End If

        DisplayMobileNo.Text = _MobileNumber
        DisplayAccountNumber.Text = NetworkType
        DisplayBillingSystem.Text = CustomerBOS
        'DisplayContactID.Text = Contact_ID
        'DisplayMobileStatus.Text = CustomerMobileStatus
        'DisplayCategory.Text = CustomerCategory

        DisplayLastDate.ForeColor = Color.Black
        If DisplayLastDate.Text <> "" Then
           

            Dim ShowRedLastCaptureDate As String = Engine.Common.ShopConnectDBENG.GetShopConfig(INIFileName, "ShowRedLastCaptureDate", SoftwareName, "frmKioskCapture_GetCustomerInfo")
            If ShowRedLastCaptureDate.Trim <> "" Then
                If DateAdd(DateInterval.Month, CInt(ShowRedLastCaptureDate), vDate) < DateTime.Now.Date Then
                    DisplayLastDate.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub pbReCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReCapture.Click
        webcam.Start(CamIndex)
        'pbCapture.Location = New Point((Screen.PrimaryScreen.Bounds.Width / 2 - (pbCapture.Width / 2)) - 240, Screen.PrimaryScreen.Bounds.Height / 2 + 270)
        pbCapture.Visible = True
        pbReCapture.Visible = False
        pbSave.Visible = False

        pcCapture.BringToFront()
    End Sub

    Private Sub pbCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCapture.Click
        pbReCapture.Visible = True
        pbSave.Visible = True
        pbCapture.Visible = False



        'Threading.Thread.Sleep(100)
        'Save ภาพลงใน Temp ของ Kiosk
        Dim eng As New Engine.Kiosk.KioskCaptureENG
        eng.SaveImageCapture(ConfigINI, pcCapture.Image, pcCapture, btnDiaplayImage, frmDialogMsg, frmDialogMsg.lblText, _MobileNumber)
        eng = Nothing
        Application.DoEvents()

        btnDiaplayImage.BringToFront()
        webcam.Stop()
        _IsCapture = True

        ' Me.Close()
    End Sub

    Private Sub pbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSave.Click
        If _IsCapture = False Then
            ' MessageBox.Show("ไม่สามารถบันทึกภาพได้!")
            frmDialogMsg.lblText.Text = msgDialogCaptureNotComplete
            frmDialogMsg.ShowDialog()
            Exit Sub
        End If

        Try
            CustomerImageID = SendImageFile(Mobile, "", New Date(1, 1, 1))

            _IsCapture = False
            pbReCapture.Visible = False
            pbCapture.Visible = True
            pbSave.Visible = False
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClose.Click
        _IsCapture = False
        pbReCapture.Visible = False
        pbCapture.Visible = True
        pbSave.Visible = False
        webcam.Stop()

        Dim eng As New Engine.Kiosk.KioskCaptureENG
        eng.DeleteTempCaptureFile(_MobileNumber)
        eng = Nothing
        Me.Close()
    End Sub

    Private Sub frmKiosCapture_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'ตอนเปิดฟอร์มให้ลบไฟล์ใน Temp ของ Kiosk ก่อนเลย 55
        Dim eng As New Engine.Kiosk.KioskCaptureENG
        eng.DeleteTempCaptureAllFile()
        eng = Nothing
    End Sub
End Class
