Imports AlexPilotti.FTPS.Client
Imports AlexPilotti.FTPS.Common
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.IO

Public Class frmTestFTPFolder

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Using FTP As New AlexPilotti.FTPS.Client.FTPSClient
    '        Dim credentials As System.Net.NetworkCredential = New System.Net.NetworkCredential("vdo", "vdo1234")
    '        Try
    '            'FTP.Connect(shopFtpHost, 990, credentials, AlexPilotti.FTPS.Client.ESSLSupportMode.Implicit, _
    '            '            New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate), _
    '            '            New System.Security.Cryptography.X509Certificates.X509Certificate(), 0, 0, 0, 200, True)
    '            'FTP.PutFile(Localfile, DestinationFile) 'eg. "/jddddd.flv"

    '            FTP.Connect("172.16.59.149", 990, credentials, AlexPilotti.FTPS.Client.ESSLSupportMode.Implicit, _
    '                        New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate), _
    '                        New System.Security.Cryptography.X509Certificates.X509Certificate(), 0, 0, 0, 200, True)

    '            CheckToDayDirectory(FTP)
    '            FTP.PutFile("D:\Movie\GI_JOE_RETALIATION_2013.iso", "/20130911/GI_JOE_RETALIATION_2013.iso")
    '            'Return True
    '        Catch ex As Exception
    '            'Return False
    '        End Try
    '    End Using
    'End Sub

    'Private Sub CheckToDayDirectory(ByVal FTP As AlexPilotti.FTPS.Client.FTPSClient)
    '    Dim DirName As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
    '    Try
    '        FTP.GetDirectoryListUnparsed(DirName)
    '    Catch ex As Exception
    '        FTP.MakeDir(DirName)
    '    End Try
    'End Sub

    'Public Function ValidateCertificate(ByVal sender As Object, _
    '                                  ByVal certificate As X509Certificate, _
    '                                  ByVal chain As X509Chain, _
    '                                  ByVal sslPolicyErrors As Security.SslPolicyErrors) As Boolean
    '    Return True
    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim StartTime As DateTime = DateTime.Now
            Dim ret As Boolean = False
            Dim FileName As String = "131025104.flv"
            Dim FilePath As String = "D:\MyProject\QueueSharp-AIS\QualityManagement\QMSchedule\bin\Debug\QM\Backup\" & FileName
            Dim ws As New ShopWebService.WebServiceAPI
            ws.DeleteIsDuplicateFile(FileName)

            Dim Stream As FileStream = File.OpenRead(FilePath)
            Dim buffer As Byte() = New Byte((1024 * 1024) - 1) {}
            While Stream.Read(buffer, 0, buffer.Length)
                Try
                    'Dim dr As DataRow = ret.NewRow
                    'dr("CharData") = Convert.ToBase64String(buffer)
                    'ret.Rows.Add(dr)

                    ret = ws.SendVdoBinary(FileName, Convert.ToBase64String(buffer))
                    If ret = False Then
                        Exit While
                    End If
                Catch ex As Exception
                    ret = False
                    Exit While
                End Try
            End While
            Stream.Close()
            ws = Nothing

            MessageBox.Show(DateDiff(DateInterval.Second, StartTime, DateTime.Now))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class