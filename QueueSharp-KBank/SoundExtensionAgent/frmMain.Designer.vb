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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbConfig = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDisplayDBTest = New System.Windows.Forms.Button()
        Me.txtDisplayPass = New System.Windows.Forms.TextBox()
        Me.txtDisplayUserName = New System.Windows.Forms.TextBox()
        Me.txtDisplayDBName = New System.Windows.Forms.TextBox()
        Me.txtDisplayServer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudLoop = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudFreq = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtMainPass = New System.Windows.Forms.TextBox()
        Me.txtMainUserName = New System.Windows.Forms.TextBox()
        Me.txtMainDBName = New System.Windows.Forms.TextBox()
        Me.txtMainServer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSoundQ = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblQueue = New System.Windows.Forms.Label()
        Me.lblCounter = New System.Windows.Forms.Label()
        Me.lblNation = New System.Windows.Forms.Label()
        Me.btnState = New System.Windows.Forms.Button()
        Me.imgTabs = New System.Windows.Forms.ImageList(Me.components)
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.tabCfg = New System.Windows.Forms.TabControl()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.gbAbout = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblWeb = New System.Windows.Forms.LinkLabel()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.tmrUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.TimerStrart = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lblCounterNo = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.tbConfig.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nudLoop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbSoundQ.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tabCfg.SuspendLayout()
        Me.tabAbout.SuspendLayout()
        Me.gbAbout.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 391)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(731, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'tbConfig
        '
        Me.tbConfig.AutoScroll = True
        Me.tbConfig.Controls.Add(Me.GroupBox2)
        Me.tbConfig.Controls.Add(Me.GroupBox4)
        Me.tbConfig.Controls.Add(Me.GroupBox3)
        Me.tbConfig.Controls.Add(Me.GroupBox1)
        Me.tbConfig.ImageIndex = 1
        Me.tbConfig.Location = New System.Drawing.Point(4, 23)
        Me.tbConfig.Name = "tbConfig"
        Me.tbConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tbConfig.Size = New System.Drawing.Size(723, 306)
        Me.tbConfig.TabIndex = 1
        Me.tbConfig.Text = "Configuration"
        Me.tbConfig.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDisplayDBTest)
        Me.GroupBox2.Controls.Add(Me.txtDisplayPass)
        Me.GroupBox2.Controls.Add(Me.txtDisplayUserName)
        Me.GroupBox2.Controls.Add(Me.txtDisplayDBName)
        Me.GroupBox2.Controls.Add(Me.txtDisplayServer)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Location = New System.Drawing.Point(315, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(301, 143)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Display Server Database"
        '
        'btnDisplayDBTest
        '
        Me.btnDisplayDBTest.Location = New System.Drawing.Point(234, 98)
        Me.btnDisplayDBTest.Name = "btnDisplayDBTest"
        Me.btnDisplayDBTest.Size = New System.Drawing.Size(53, 23)
        Me.btnDisplayDBTest.TabIndex = 8
        Me.btnDisplayDBTest.Text = "Test"
        Me.btnDisplayDBTest.UseVisualStyleBackColor = True
        '
        'txtDisplayPass
        '
        Me.txtDisplayPass.Enabled = False
        Me.txtDisplayPass.Location = New System.Drawing.Point(85, 99)
        Me.txtDisplayPass.MaxLength = 254
        Me.txtDisplayPass.Name = "txtDisplayPass"
        Me.txtDisplayPass.Size = New System.Drawing.Size(143, 22)
        Me.txtDisplayPass.TabIndex = 7
        Me.txtDisplayPass.UseSystemPasswordChar = True
        '
        'txtDisplayUserName
        '
        Me.txtDisplayUserName.Enabled = False
        Me.txtDisplayUserName.Location = New System.Drawing.Point(85, 73)
        Me.txtDisplayUserName.MaxLength = 254
        Me.txtDisplayUserName.Name = "txtDisplayUserName"
        Me.txtDisplayUserName.Size = New System.Drawing.Size(143, 22)
        Me.txtDisplayUserName.TabIndex = 6
        '
        'txtDisplayDBName
        '
        Me.txtDisplayDBName.Enabled = False
        Me.txtDisplayDBName.Location = New System.Drawing.Point(85, 47)
        Me.txtDisplayDBName.MaxLength = 254
        Me.txtDisplayDBName.Name = "txtDisplayDBName"
        Me.txtDisplayDBName.Size = New System.Drawing.Size(143, 22)
        Me.txtDisplayDBName.TabIndex = 5
        '
        'txtDisplayServer
        '
        Me.txtDisplayServer.Enabled = False
        Me.txtDisplayServer.Location = New System.Drawing.Point(85, 21)
        Me.txtDisplayServer.MaxLength = 254
        Me.txtDisplayServer.Name = "txtDisplayServer"
        Me.txtDisplayServer.Size = New System.Drawing.Size(143, 22)
        Me.txtDisplayServer.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(9, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Password:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(7, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Username:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label15.Location = New System.Drawing.Point(10, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Database:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label16.Location = New System.Drawing.Point(27, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Server:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.nudLoop)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.nudFreq)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 165)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(301, 71)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Other Configs."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Reading Loop:"
        '
        'nudLoop
        '
        Me.nudLoop.Location = New System.Drawing.Point(110, 17)
        Me.nudLoop.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudLoop.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLoop.Name = "nudLoop"
        Me.nudLoop.Size = New System.Drawing.Size(43, 22)
        Me.nudLoop.TabIndex = 4
        Me.nudLoop.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(159, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Time"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(159, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Seconds"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label9.Location = New System.Drawing.Point(13, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Reload Freq.:"
        '
        'nudFreq
        '
        Me.nudFreq.Location = New System.Drawing.Point(110, 43)
        Me.nudFreq.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudFreq.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFreq.Name = "nudFreq"
        Me.nudFreq.Size = New System.Drawing.Size(43, 22)
        Me.nudFreq.TabIndex = 13
        Me.nudFreq.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCancel)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Location = New System.Drawing.Point(315, 165)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(301, 71)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(194, 19)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 39)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(83, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 39)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTest)
        Me.GroupBox1.Controls.Add(Me.txtMainPass)
        Me.GroupBox1.Controls.Add(Me.txtMainUserName)
        Me.GroupBox1.Controls.Add(Me.txtMainDBName)
        Me.GroupBox1.Controls.Add(Me.txtMainServer)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 143)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Main Server Database"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(234, 98)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(53, 23)
        Me.btnTest.TabIndex = 8
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'txtMainPass
        '
        Me.txtMainPass.Enabled = False
        Me.txtMainPass.Location = New System.Drawing.Point(85, 99)
        Me.txtMainPass.MaxLength = 254
        Me.txtMainPass.Name = "txtMainPass"
        Me.txtMainPass.Size = New System.Drawing.Size(143, 22)
        Me.txtMainPass.TabIndex = 7
        Me.txtMainPass.UseSystemPasswordChar = True
        '
        'txtMainUserName
        '
        Me.txtMainUserName.Enabled = False
        Me.txtMainUserName.Location = New System.Drawing.Point(85, 73)
        Me.txtMainUserName.MaxLength = 254
        Me.txtMainUserName.Name = "txtMainUserName"
        Me.txtMainUserName.Size = New System.Drawing.Size(143, 22)
        Me.txtMainUserName.TabIndex = 6
        '
        'txtMainDBName
        '
        Me.txtMainDBName.Enabled = False
        Me.txtMainDBName.Location = New System.Drawing.Point(85, 47)
        Me.txtMainDBName.MaxLength = 254
        Me.txtMainDBName.Name = "txtMainDBName"
        Me.txtMainDBName.Size = New System.Drawing.Size(143, 22)
        Me.txtMainDBName.TabIndex = 5
        '
        'txtMainServer
        '
        Me.txtMainServer.Enabled = False
        Me.txtMainServer.Location = New System.Drawing.Point(85, 21)
        Me.txtMainServer.MaxLength = 254
        Me.txtMainServer.Name = "txtMainServer"
        Me.txtMainServer.Size = New System.Drawing.Size(143, 22)
        Me.txtMainServer.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(9, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(7, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(10, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Database:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(27, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server:"
        '
        'tbSoundQ
        '
        Me.tbSoundQ.AutoScroll = True
        Me.tbSoundQ.Controls.Add(Me.lblCounterNo)
        Me.tbSoundQ.Controls.Add(Me.GroupBox8)
        Me.tbSoundQ.Controls.Add(Me.btnState)
        Me.tbSoundQ.Controls.Add(Me.btnExit)
        Me.tbSoundQ.Controls.Add(Me.btnStart)
        Me.tbSoundQ.Controls.Add(Me.btnStop)
        Me.tbSoundQ.ImageIndex = 0
        Me.tbSoundQ.Location = New System.Drawing.Point(4, 23)
        Me.tbSoundQ.Name = "tbSoundQ"
        Me.tbSoundQ.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSoundQ.Size = New System.Drawing.Size(723, 306)
        Me.tbSoundQ.TabIndex = 0
        Me.tbSoundQ.Text = "Sound Queue"
        Me.tbSoundQ.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 36)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(709, 207)
        Me.GroupBox8.TabIndex = 10
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Calling Queue"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblQueue, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNation, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(697, 165)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Teal
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 39)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "ID:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 39)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Queue#:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Teal
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(6, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 39)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Counter:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(6, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 42)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Nationality:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.LightCyan
        Me.lblID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(144, 3)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(547, 39)
        Me.lblID.TabIndex = 4
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQueue
        '
        Me.lblQueue.AutoSize = True
        Me.lblQueue.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQueue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueue.Location = New System.Drawing.Point(144, 42)
        Me.lblQueue.Name = "lblQueue"
        Me.lblQueue.Size = New System.Drawing.Size(547, 39)
        Me.lblQueue.TabIndex = 5
        Me.lblQueue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCounter
        '
        Me.lblCounter.AutoSize = True
        Me.lblCounter.BackColor = System.Drawing.Color.LightCyan
        Me.lblCounter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter.Location = New System.Drawing.Point(144, 81)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.Size = New System.Drawing.Size(547, 39)
        Me.lblCounter.TabIndex = 6
        Me.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNation
        '
        Me.lblNation.AutoSize = True
        Me.lblNation.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblNation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNation.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNation.Location = New System.Drawing.Point(144, 120)
        Me.lblNation.Name = "lblNation"
        Me.lblNation.Size = New System.Drawing.Size(547, 42)
        Me.lblNation.TabIndex = 7
        Me.lblNation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnState
        '
        Me.btnState.FlatAppearance.BorderSize = 0
        Me.btnState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnState.ImageKey = "Grey"
        Me.btnState.ImageList = Me.imgTabs
        Me.btnState.Location = New System.Drawing.Point(153, 7)
        Me.btnState.Name = "btnState"
        Me.btnState.Size = New System.Drawing.Size(34, 23)
        Me.btnState.TabIndex = 9
        Me.btnState.UseVisualStyleBackColor = True
        '
        'imgTabs
        '
        Me.imgTabs.ImageStream = CType(resources.GetObject("imgTabs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTabs.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTabs.Images.SetKeyName(0, "loudspeaker.ico")
        Me.imgTabs.Images.SetKeyName(1, "wrench.ico")
        Me.imgTabs.Images.SetKeyName(2, "inbox_into.ico")
        Me.imgTabs.Images.SetKeyName(3, "user_headset.ico")
        Me.imgTabs.Images.SetKeyName(4, "Green")
        Me.imgTabs.Images.SetKeyName(5, "Grey")
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Location = New System.Drawing.Point(647, 7)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(68, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(9, 6)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(68, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(83, 6)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(68, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'tabCfg
        '
        Me.tabCfg.Controls.Add(Me.tbSoundQ)
        Me.tabCfg.Controls.Add(Me.tbConfig)
        Me.tabCfg.Controls.Add(Me.tabAbout)
        Me.tabCfg.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabCfg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCfg.ImageList = Me.imgTabs
        Me.tabCfg.Location = New System.Drawing.Point(0, 0)
        Me.tabCfg.Margin = New System.Windows.Forms.Padding(0)
        Me.tabCfg.Name = "tabCfg"
        Me.tabCfg.SelectedIndex = 0
        Me.tabCfg.Size = New System.Drawing.Size(731, 333)
        Me.tabCfg.TabIndex = 5
        '
        'tabAbout
        '
        Me.tabAbout.Controls.Add(Me.gbAbout)
        Me.tabAbout.ImageIndex = 3
        Me.tabAbout.Location = New System.Drawing.Point(4, 23)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAbout.Size = New System.Drawing.Size(723, 306)
        Me.tabAbout.TabIndex = 3
        Me.tabAbout.Text = "About"
        Me.tabAbout.UseVisualStyleBackColor = True
        '
        'gbAbout
        '
        Me.gbAbout.Controls.Add(Me.PictureBox1)
        Me.gbAbout.Controls.Add(Me.lblProductName)
        Me.gbAbout.Controls.Add(Me.lblWeb)
        Me.gbAbout.Controls.Add(Me.lblCompanyName)
        Me.gbAbout.Controls.Add(Me.lblCopyright)
        Me.gbAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbAbout.Location = New System.Drawing.Point(3, 3)
        Me.gbAbout.Name = "gbAbout"
        Me.gbAbout.Size = New System.Drawing.Size(717, 300)
        Me.gbAbout.TabIndex = 5
        Me.gbAbout.TabStop = False
        Me.gbAbout.Text = "About QueueSharp Sound Extension"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(272, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(171, 53)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.Location = New System.Drawing.Point(244, 30)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(71, 17)
        Me.lblProductName.TabIndex = 0
        Me.lblProductName.Text = "AppNAme"
        '
        'lblWeb
        '
        Me.lblWeb.AutoSize = True
        Me.lblWeb.LinkArea = New System.Windows.Forms.LinkArea(11, 31)
        Me.lblWeb.Location = New System.Drawing.Point(245, 165)
        Me.lblWeb.Name = "lblWeb"
        Me.lblWeb.Size = New System.Drawing.Size(226, 20)
        Me.lblWeb.TabIndex = 4
        Me.lblWeb.TabStop = True
        Me.lblWeb.Text = "Homepage : http://www.scoresolutions.co.th"
        Me.lblWeb.UseCompatibleTextRendering = True
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.Location = New System.Drawing.Point(253, 60)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(211, 13)
        Me.lblCompanyName.TabIndex = 1
        Me.lblCompanyName.Text = "Empowered by Score Solutions Co., Ltd."
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(290, 143)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(126, 13)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "Copyright © 2007-2008"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Gray
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 333)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(731, 3)
        Me.Splitter1.TabIndex = 6
        Me.Splitter1.TabStop = False
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(0, 336)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(731, 55)
        Me.txtLog.TabIndex = 7
        '
        'tmrUpdate
        '
        '
        'TimerStrart
        '
        Me.TimerStrart.Enabled = True
        Me.TimerStrart.Interval = 5000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'lblCounterNo
        '
        Me.lblCounterNo.AutoSize = True
        Me.lblCounterNo.Location = New System.Drawing.Point(349, 17)
        Me.lblCounterNo.Name = "lblCounterNo"
        Me.lblCounterNo.Size = New System.Drawing.Size(0, 13)
        Me.lblCounterNo.TabIndex = 11
        Me.lblCounterNo.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(731, 413)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.tabCfg)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(548, 39)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QueueSharp™ Sound Extension v[%V%]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbConfig.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nudLoop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbSoundQ.ResumeLayout(False)
        Me.tbSoundQ.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tabCfg.ResumeLayout(False)
        Me.tabAbout.ResumeLayout(False)
        Me.gbAbout.ResumeLayout(False)
        Me.gbAbout.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tbConfig As System.Windows.Forms.TabPage
    Friend WithEvents tbSoundQ As System.Windows.Forms.TabPage
    Friend WithEvents tabCfg As System.Windows.Forms.TabControl
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents txtMainPass As System.Windows.Forms.TextBox
    Friend WithEvents txtMainUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtMainDBName As System.Windows.Forms.TextBox
    Friend WithEvents txtMainServer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudLoop As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents nudFreq As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tmrUpdate As System.Windows.Forms.Timer
    Friend WithEvents tabAbout As System.Windows.Forms.TabPage
    Friend WithEvents imgTabs As System.Windows.Forms.ImageList
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblQueue As System.Windows.Forms.Label
    Friend WithEvents lblCounter As System.Windows.Forms.Label
    Friend WithEvents btnState As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNation As System.Windows.Forms.Label
    Friend WithEvents lblWeb As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents gbAbout As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerStrart As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDisplayDBTest As System.Windows.Forms.Button
    Friend WithEvents txtDisplayPass As System.Windows.Forms.TextBox
    Friend WithEvents txtDisplayUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtDisplayDBName As System.Windows.Forms.TextBox
    Friend WithEvents txtDisplayServer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents lblCounterNo As System.Windows.Forms.Label

End Class
