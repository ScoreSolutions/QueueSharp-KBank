Imports System.Data
Imports System.Data.SqlClient
Imports QueueSharp.Org.Mentalis.Files
Imports System.Threading

Public Class frmLogin

    Dim Sql As String = ""
    Public ExitApp As Boolean = False
    Public Serve As Boolean = False     'เช็คว่า User สามารถใช้งานเมนูนี้ได้หรือไม่ ถ้าใช้ได้ตอน Login ก็ให้เปิดเมนูนี้เลย
    Public Register As Boolean = False  'เช็คว่า User สามารถใช้งานเมนูนี้ได้หรือไม่ ถ้าใช้ได้ตอน Login ก็ให้เปิดเมนูนี้เลย
    Public CheckCam As Boolean = False

    Private Sub TextUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPassword.Focus()
        End If
    End Sub

    Private Sub TextPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cbCounter.Enabled = True Then
                cbCounter.Focus()
            Else
                btnLogin.Focus()
            End If

        End If
    End Sub

    Private Sub cbCounter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCounter.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogin.PerformClick()
        End If
    End Sub

    Sub save_ini()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("userlogin", txtUserName.Text)
        ini.Write("counter", cbCounter.SelectedValue.ToString)
        ini = Nothing
    End Sub

    Sub read_ini()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        If CStr(ini.ReadString("userlogin")) <> "" Then
            txtUserName.Text = CStr(ini.ReadString("userlogin"))
            txtPassword.Focus()
            txtPassword.SelectAll()
            cbCounter.SelectedValue = ini.ReadInteger("counter")
        Else
            txtUserName.Text = ""
            txtPassword.Text = ""
            txtUserName.Focus()
        End If
        ini = Nothing
    End Sub

    Private Function Validation() As Boolean
        Try
            If txtUserName.Text.Trim = "" Then
                MessageBox.Show("Please enter Username", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUserName.Focus()
                Return False
            End If

            If txtPassword.Text.Trim = "" Then
                MessageBox.Show("Please enter Password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return False
            End If

            If CDbl(cbCounter.SelectedValue) = 0 Then
                MessageBox.Show("Please select Counter", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cbCounter.Focus()
                Return False
            End If

            'Encrypt
            Dim PW As String = Engine.Common.FunctionEng.EnCripPwd(txtPassword.Text.Trim)
            '*****************************
            If txtUserName.Text.ToUpper <> "ADMIN" Then
                If QueueCheckLDAP() = True Then
                    Try
                        'สำหรับ Bypass SSL กรณีเรียก WebService ผ่าน https://
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = _
                          Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, _
                          chain As System.Security.Cryptography.X509Certificates.X509Chain, _
                          sslerror As System.Net.Security.SslPolicyErrors) True

                        Dim FindData As New ShopWebServiceMain.WebServiceAPI
                        Dim LDAP As New ShopWebServiceMain.LDAPResponsePara
                        FindData.Url = GetWebServiceURL(True)

                        LDAP = FindData.LDAPAuth(txtUserName.Text.Trim, txtPassword.Text.Trim)
                        If LDAP.RESULT = True Then
                            Sql = "update tb_user set password = '" & FixDB(PW) & "' where username = '" & FixDB(txtUserName.Text.Trim) & "'"
                            executeSQL(Sql)
                        Else

                            If InStr(LDAP.RESPONSE_MSG, "User") > 0 Then
                                MessageBox.Show("User not found", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf InStr(LDAP.RESPONSE_MSG, "Password") > 0 Then
                                MessageBox.Show("Invalid password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                MessageBox.Show("Your username or password is incorrect.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                            Return False
                        End If
                        'End If
                    Catch ex As Exception
                        Try
                            Dim FindData As New ShopWebServiceDisplay.WebServiceAPI
                            Dim LDAP As New ShopWebServiceDisplay.LDAPResponsePara
                            FindData.Url = GetWebServiceURL(False)
                            LDAP = FindData.LDAPAuth(txtUserName.Text.Trim, txtPassword.Text.Trim)
                            If LDAP.RESULT = True Then
                                Sql = "update tb_user set password = '" & FixDB(PW) & "' where username = '" & FixDB(txtUserName.Text.Trim) & "'"
                                executeSQL(Sql)
                            Else
                                If InStr(LDAP.RESPONSE_MSG.ToUpper, "USER") > 0 Then
                                    MessageBox.Show("User not found", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ElseIf InStr(LDAP.RESPONSE_MSG.ToUpper, "PASSWORD") > 0 Then
                                    MessageBox.Show("Invalid password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    MessageBox.Show("Your username or password is incorrect.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                                Return False
                            End If
                        Catch ey As Exception
                            'LDAP_CONNECT = False
                            Dim dt As New DataTable
                            Sql = "select * from tb_user where username = '" & FixDB(txtUserName.Text.Trim) & "' and password = '" & FixDB(PW) & "'"
                            dt = getDataTable(Sql)
                            If dt.Rows.Count = 0 Then
                                Return False
                            End If
                        End Try
                    End Try
                End If
            Else
                Dim dt As New DataTable
                Sql = "select * from tb_user where username = '" & FixDB(txtUserName.Text.Trim) & "' and password = '" & FixDB(PW) & "'"
                dt = getDataTable(Sql)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Invalid password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                Sql = "update tb_user set password = '" & FixDB(PW) & "' where username = '" & FixDB(txtUserName.Text.Trim) & "'"
                executeSQL(Sql)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
        
    End Function

    Private Function ChkCurrentLogin() As Boolean
        'ตรวจสอบว่าผู้ใช้กำลังอยู่ในระบบที่เครื่องเดียวกันอยู่แล้วหรือไม่
        Dim ret As Boolean = False
        Dim sql As String = "select id, ip_address  from tb_user where username='" & txtUserName.Text & "' "
        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("ip_address").ToString = GetIPAddress() Then
                'ถ้า User เดียวกัน มา Login ที่เครื่องเดียวกันแล้วก็ ให้ตรวจสอบว่าเปิดโปรแกรม Q# ค้างอยู่หรือไม่
                Dim pCount As Int16 = 0
                Dim pList() As Process = Process.GetProcessesByName("QueueSharp.vshost")
                If pList.Length = 0 Then
                    pList = Process.GetProcessesByName("QueueSharp")
                    If pList.Length > 0 Then
                        pCount += pList.Length
                    End If
                Else
                    pCount += pList.Length
                    pList = Process.GetProcessesByName("QueueSharp")
                    pCount += pList.Length
                End If

                If pCount > 1 Then
                    ret = True
                End If
            End If
        Else
            'ถ้าผู้ใช้ยังไม่ได้ Login ตรวจสอบว่า Counter ที่เลือกถูกใช้งานไปแล้วหรือไม่
            Dim sql2 As String = "select id, ip_address from tb_user where counter_id = '" & cbCounter.SelectedValue & "' "
            Dim dt2 As DataTable = getDataTable(sql2)
            If dt2.Rows.Count > 0 Then
                If dt2.Rows(0)("ip_address") = GetIPAddress() Then
                    ret = False
                Else
                    ret = True
                End If
            End If
        End If

        Return ret
    End Function

    Public Sub Login(ByVal UserName As String, ByVal Pwd As String, ByVal dt As DataTable)
        myUser.username = txtUserName.Text
        myUser.user_id = dt.Rows(0).Item("id").ToString
        myUser.user_code = dt.Rows(0).Item("user_code").ToString
        myUser.fulllname = dt.Rows(0).Item("fullname").ToString
        myUser.counter_id = cbCounter.SelectedValue
        myUser.counter_name = cbCounter.Text
        myUser.ip_address = GetIPAddress()

        Sql = "select item_id from TB_USER_SERVICE_SCHEDULE where datediff(D,GETDATE(),service_date)=0 and user_id = " & myUser.user_id & " and priority = 1 and item_id in (select item_id from TB_USER_SKILL left join TB_SKILL_ITEM on TB_USER_SKILL.skill_id = TB_SKILL_ITEM.skill_id where user_id = " & myUser.user_id & ")"
        dt = New DataTable
        dt = getDataTable(Sql)
        If dt.Rows.Count > 0 Then
            myUser.item_id = dt.Rows(0).Item("item_id").ToString
        Else
            myUser.item_id = 0
        End If

        dt = New DataTable
        Sql = "select * from TB_APPOINTMENT_USER where DATEDIFF(D,GETDATE(),app_date )=0 and user_id = " & myUser.user_id
        dt = getDataTable(Sql)
        If dt.Rows.Count > 0 Then
            myUser.assign_appointment = 1
        Else
            myUser.assign_appointment = 0
        End If

        UpdateCounterStatus(cbCounter.SelectedValue, True)
        LastService.LastQueue = ""
        LastService.LastRoom = ""
        LastService.LastService = ""
        save_ini()
        ExitApp = False
        frmMain.Text = Replace(frmMain.Text, "[-]", "[" & myUser.fulllname & "]")
        FindMenuList(myUser.user_id)
        If txtUserName.Enabled = True Then
            LogLogin(1)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Yes
        'Me.Close()
        ClearUnitDisplay(False)
    End Sub

    Private Sub butlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Cursor = Cursors.WaitCursor
        btnLogin.Enabled = False
        'Dim lic As New ScoreLicense.ScoreLicense("QSHARP")
        'lic.SerializedLicenseKey

        If Validation() = True Then
            Dim sql = ""
            Dim dt As New DataTable
            'Encrypt
            Dim PW As String = Engine.Common.FunctionEng.EnCripPwd(txtPassword.Text.Trim)
            '*****************************
            sql = "select x.id,title_name + ' ' + fname + ' ' + lname as fullname,user_code,group_id from TB_USER x left join TB_TITLE y on x.title_id = y.id where username = '" & FixDB(txtUserName.Text.Trim) & "' and [password] = '" & FixDB(PW) & "' and active_status = 1"
            dt = getDataTable(sql)
            If dt.Rows.Count > 0 Then
                Dim dt_tmp As New DataTable
                sql = "select * from TB_GROUPUSER where active_status = 1 and id = " & dt.Rows(0).Item("group_id").ToString
                dt_tmp = getDataTable(sql)
                If dt_tmp.Rows.Count = 0 Then
                    MessageBox.Show("Group User can't active", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    btnLogin.Enabled = True
                    dt_tmp.Dispose()
                    Exit Sub
                End If

                dt_tmp = New DataTable
                sql = "select id from tb_user where username='" & FixDB(txtUserName.Text.Trim) & "' and counter_id <> 0 "
                dt_tmp = getDataTable(sql)
                If dt_tmp.Rows.Count > 0 Then
                    MessageBox.Show("This User already exists! Please re-enter the new one", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    btnLogin.Enabled = True
                    dt_tmp.Dispose()
                    Exit Sub
                End If
                dt_tmp.Dispose()

                If CreateLogInTrans() = True Then
                    sql = "update TB_USER set check_update = GETDATE(),counter_id = " & cbCounter.SelectedValue & " "
                    sql += " where id = '" & dt.Rows(0).Item("id").ToString & "' and (counter_id=0 or counter_id is null)"
                    If executeSQL(sql, shTrans, True) = True Then
                        Dim cDt = New DataTable
                        sql = "select counter_id from tb_user "
                        sql += " where counter_id = " & cbCounter.SelectedValue.ToString
                        sql += " and id<>'" & dt.Rows(0).Item("id").ToString & "'"
                        cDt = getDataTable(sql, shTrans)
                        If cDt.Rows.Count > 0 Then
                            RollbackTransaction()
                            cDt.Dispose()
                            MessageBox.Show("Counter has been updated by the other user", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Default
                            btnLogin.Enabled = True
                            ShowCounter()
                            Exit Sub
                        Else
                            CommitTransaction()


                            Login(txtUserName.Text, txtPassword.Text, dt)
                            frmMain.TimerCheckStatus.Enabled = True
                            frmMain.timerCheckForce.Enabled = True
                            frmMain.TimerCheckBackupQM.Enabled = True
                            dt.Dispose()


                            cDt = New DataTable
                            cDt = getDataTable("select id from tb_counter where (back_office=1 or counter_manager=1) and id='" & cbCounter.SelectedValue & "' ")
                            If cDt.Rows.Count = 0 Then
                                frmMain.CheckCam = True
                            Else
                                frmMain.CheckCam = False
                            End If
                            cDt.Dispose()

                            ClearQMLog()
                            'QM.StartQMScheduleLogin()
                        End If
                    Else
                        RollbackTransaction()
                        MessageBox.Show("Counter has been updated by the other user", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Default
                        btnLogin.Enabled = True
                        ShowCounter()
                        Exit Sub
                    End If
                Else
                    RollbackTransaction()
                    MessageBox.Show("Counter has been updated by the other user", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    btnLogin.Enabled = True
                    ShowCounter()
                    Exit Sub
                End If
            Else
                MessageBox.Show("User not found in Queue System", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUserName.Focus()
            End If
        End If
        Me.Cursor = Cursors.Default
        btnLogin.Enabled = True
    End Sub
#Region "QM Process"
    Private Sub ClearQMLog()
        Dim QMLogMonth As String = Engine.Common.ShopConnectDBENG.GetShopConfig(INIFileName, "QMLogMonth", "QueueSharp", "frmLogin_ClearQMLog")

        If QMLogMonth.Trim <> "" Then
            Dim MMonth As String = DateAdd(DateInterval.Month, (0 - Convert.ToInt16(QMLogMonth)), DateTime.Today).ToString("yyyyMM", New Globalization.CultureInfo("en-US"))
            Dim DDay As String = DateAdd(DateInterval.Month, (0 - Convert.ToInt16(QMLogMonth)), DateTime.Today).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

            'Clear Event Log
            If IO.Directory.Exists(Application.StartupPath & "\QM\EventLog") = True Then
                Dim EventLogFld() As String = IO.Directory.GetDirectories(Application.StartupPath & "\QM\EventLog")
                For Each Dir As String In EventLogFld
                    Dim dInfo As New IO.DirectoryInfo(Dir)
                    If dInfo.Name < MMonth Then
                        IO.Directory.Delete(Dir, True)
                        dInfo = Nothing
                        Continue For
                    End If

                    For Each f As String In IO.Directory.GetFiles(Dir)
                        Dim fInfo As New IO.FileInfo(f)
                        If fInfo.LastWriteTime.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < DDay Then
                            IO.File.Delete(f)
                        End If
                        fInfo = Nothing
                    Next
                Next
            End If

            'Clear Error Log
            If IO.Directory.Exists(Application.StartupPath & "\QM\ErrorLog") = True Then
                Dim ErrorLogFld() As String = IO.Directory.GetDirectories(Application.StartupPath & "\QM\ErrorLog")
                For Each Dir As String In ErrorLogFld
                    Dim dInfo As New IO.DirectoryInfo(Dir)
                    If dInfo.Name < MMonth Then
                        IO.Directory.Delete(Dir, True)
                        dInfo = Nothing
                        Continue For
                    End If

                    For Each f As String In IO.Directory.GetFiles(Dir)
                        Dim fInfo As New IO.FileInfo(f)
                        If fInfo.LastWriteTime.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < DDay Then
                            IO.File.Delete(f)
                        End If
                        fInfo = Nothing
                    Next
                Next
            End If
        End If
    End Sub
#End Region    'QM Process
    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ExitApp = True Then
            System.Environment.Exit(0)
        End If
        If Me.DialogResult <> Windows.Forms.DialogResult.Yes Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Dim cDt As New DataTable
    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        frmMain.TimerCheckStatus.Enabled = False
        ShowCounter()
        read_ini()
    End Sub

    Sub ShowCounter()
        Dim sql As String = ""
        Dim dt As New DataTable
        'sql = "select id,counter_name from TB_counter where active_status = 1 AND id not in (SELECT id from TB_COUNTER as TB_COUNTER2 WHERE back_office=1) and  id not in (select distinct isnull(counter_id,0) from tb_user where counter_id not in (select id from TB_counter where counter_manager =1 )) order by counter_name"
        sql = "select id,counter_name from TB_counter where active_status = 1 and id not in (select distinct isnull(counter_id,0) from tb_user) order by counter_code"
        dt = getDataTable(sql)

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("id") = 0
            dr("counter_name") = ""
            dt.Rows.InsertAt(dr, 0)

            If dt.Rows.Count <> cDt.Rows.Count Then
                With cbCounter
                    .DataSource = dt
                    .DisplayMember = "counter_name"
                    .ValueMember = "id"
                End With

                Dim ini As New IniReader(INIFileName)
                ini.Section = "SETTING"
                cbCounter.SelectedValue = ini.ReadInteger("counter")
                ini = Nothing

                cDt = dt.Copy
            End If
        End If
    End Sub

    Sub FindMenuList(ByVal UserID As Integer)
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select z.menu_id,TB_MENU.menu_name   from TB_GROUPUSER x left join TB_USER y on x.id = y.group_id left join TB_GROUPUSER_MENU z on x.id = z.group_id left join TB_MENU on z.menu_id = TB_MENU.id where y.id = " & UserID
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            DisableFormMainButton()
            For i As Int32 = 0 To dt.Rows.Count - 1
                Select Case CInt(dt.Rows(i).Item("menu_id").ToString)
                    Case 1
                        frmMain.btnSegment.Enabled = True
                        Register = True
                    Case 2
                        frmMain.BtnServe.Enabled = True
                        Serve = True
                    Case 3
                        frmMain.BtnHistory.Enabled = True
                    Case 4
                        frmMain.BtnAwaiting.Enabled = True
                    Case 5
                        frmMain.BtnCounterStatus.Enabled = True
                    Case 6
                        frmMain.BtnCusInfo.Enabled = True
                    Case 7
                        frmMain.BtnCusType.Enabled = True
                    Case 8
                        frmMain.BtnCounter.Enabled = True
                    Case 9
                        frmMain.BtnItem.Enabled = True
                    Case 10
                        frmMain.BtnGroupUser.Enabled = True
                    Case 11
                        frmMain.BtnUser.Enabled = True
                    Case 12
                        frmMain.btnLogoutReason.Enabled = True
                    Case 13
                        frmMain.btnHoldReason.Enabled = True
                    Case 14
                        frmMain.btnSkill.Enabled = True
                    Case 15
                        frmMain.btnWorkFlow.Enabled = True
                    Case 16
                        frmMain.btnSetting.Enabled = True
                    Case 17
                        frmMain.btnAppointment.Enabled = True
                    Case 18
                        frmMain.btnForce.Enabled = True
                    Case 19
                        frmMain.BtnAppointmentCustomer.Enabled = True
                        'Case 20
                        '    frmMain.btnMDSetting.Enabled = True
                    Case 21
                        frmMain.btnQSetting.Enabled = True
                End Select
            Next
        End If

    End Sub

    Sub DisableFormMainButton()
        frmMain.btnSegment.Enabled = False
        frmMain.BtnServe.Enabled = False
        frmMain.BtnHistory.Enabled = False
        frmMain.BtnAwaiting.Enabled = False
        frmMain.BtnCounterStatus.Enabled = False
        frmMain.BtnCusInfo.Enabled = False
        frmMain.BtnCusType.Enabled = False
        frmMain.BtnCounter.Enabled = False
        frmMain.BtnItem.Enabled = False
        frmMain.BtnGroupUser.Enabled = False
        frmMain.BtnUser.Enabled = False
        frmMain.btnLogoutReason.Enabled = False
        frmMain.btnHoldReason.Enabled = False
        frmMain.btnWorkFlow.Enabled = False
        frmMain.btnAppointment.Enabled = False
        frmMain.btnSkill.Enabled = False
        frmMain.btnSetting.Enabled = False
        frmMain.btnForce.Enabled = False
        frmMain.BtnAppointmentCustomer.Enabled = False
        'frmMain.btnMDSetting.Enabled = False
        frmMain.btnQSetting.Enabled = False
    End Sub

    Dim LastRefreshTime As DateTime = DateTime.Now
    Dim AutoRefreshSec As String = Engine.Common.ShopConnectDBENG.GetShopConfig(INIFileName, "LoginCounterRefreshSec", "QueueSharp", "frmLogin_CheckCounter.Tick")
    Private Sub CheckCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCounter.Tick
        Try
            If AutoRefreshSec.Trim = "" Then
                AutoRefreshSec = "1"
            End If
            If DateAdd(DateInterval.Second, Convert.ToInt16(AutoRefreshSec), LastRefreshTime) < DateTime.Now Then
                ShowCounter()
                LastRefreshTime = DateTime.Now
                AutoRefreshSec = Engine.Common.ShopConnectDBENG.GetShopConfig(INIFileName, "LoginCounterRefreshSec", "QueueSharp", "frmLogin_CheckCounter.Tick")
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub cbCounter_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCounter.SelectionChangeCommitted
        If cbCounter.SelectedValue <> 0 Then
            Dim ini As New IniReader(INIFileName)
            ini.Section = "SETTING"
            ini.Write("counter", cbCounter.SelectedValue.ToString)
            ini = Nothing
        End If
    End Sub
End Class