<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKiosCapture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKiosCapture))
        Me.pcCapture = New System.Windows.Forms.PictureBox()
        Me.pbReCapture = New System.Windows.Forms.PictureBox()
        Me.pbCapture = New System.Windows.Forms.PictureBox()
        Me.pbSave = New System.Windows.Forms.PictureBox()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.pnlCusInfo = New System.Windows.Forms.Panel()
        Me.DisplayBillingSystem = New System.Windows.Forms.Label()
        Me.lblCustomerType = New System.Windows.Forms.Label()
        Me.DisplayAccountNumber = New System.Windows.Forms.Label()
        Me.lblAccountNumber = New System.Windows.Forms.Label()
        Me.DisplayMobileNo = New System.Windows.Forms.Label()
        Me.DisplayLastDate = New System.Windows.Forms.Label()
        Me.DisplayImage = New System.Windows.Forms.Label()
        Me.lblMobileNo = New System.Windows.Forms.Label()
        Me.lblLastDate = New System.Windows.Forms.Label()
        Me.lblImage = New System.Windows.Forms.Label()
        Me.btnDiaplayImage = New System.Windows.Forms.Button()
        CType(Me.pcCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbReCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCusInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pcCapture
        '
        Me.pcCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pcCapture.Location = New System.Drawing.Point(21, 109)
        Me.pcCapture.Name = "pcCapture"
        Me.pcCapture.Size = New System.Drawing.Size(640, 480)
        Me.pcCapture.TabIndex = 13
        Me.pcCapture.TabStop = False
        '
        'pbReCapture
        '
        Me.pbReCapture.BackgroundImage = CType(resources.GetObject("pbReCapture.BackgroundImage"), System.Drawing.Image)
        Me.pbReCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbReCapture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbReCapture.Location = New System.Drawing.Point(151, 53)
        Me.pbReCapture.Name = "pbReCapture"
        Me.pbReCapture.Size = New System.Drawing.Size(140, 50)
        Me.pbReCapture.TabIndex = 16
        Me.pbReCapture.TabStop = False
        Me.pbReCapture.Visible = False
        '
        'pbCapture
        '
        Me.pbCapture.BackgroundImage = CType(resources.GetObject("pbCapture.BackgroundImage"), System.Drawing.Image)
        Me.pbCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCapture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbCapture.Location = New System.Drawing.Point(12, 53)
        Me.pbCapture.Name = "pbCapture"
        Me.pbCapture.Size = New System.Drawing.Size(140, 50)
        Me.pbCapture.TabIndex = 17
        Me.pbCapture.TabStop = False
        '
        'pbSave
        '
        Me.pbSave.BackgroundImage = CType(resources.GetObject("pbSave.BackgroundImage"), System.Drawing.Image)
        Me.pbSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSave.Location = New System.Drawing.Point(297, 53)
        Me.pbSave.Name = "pbSave"
        Me.pbSave.Size = New System.Drawing.Size(140, 50)
        Me.pbSave.TabIndex = 18
        Me.pbSave.TabStop = False
        Me.pbSave.Visible = False
        '
        'pbClose
        '
        Me.pbClose.BackgroundImage = CType(resources.GetObject("pbClose.BackgroundImage"), System.Drawing.Image)
        Me.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Location = New System.Drawing.Point(1099, 12)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(40, 35)
        Me.pbClose.TabIndex = 24
        Me.pbClose.TabStop = False
        '
        'pnlCusInfo
        '
        Me.pnlCusInfo.Controls.Add(Me.DisplayBillingSystem)
        Me.pnlCusInfo.Controls.Add(Me.lblCustomerType)
        Me.pnlCusInfo.Controls.Add(Me.DisplayAccountNumber)
        Me.pnlCusInfo.Controls.Add(Me.lblAccountNumber)
        Me.pnlCusInfo.Controls.Add(Me.DisplayMobileNo)
        Me.pnlCusInfo.Controls.Add(Me.DisplayLastDate)
        Me.pnlCusInfo.Controls.Add(Me.DisplayImage)
        Me.pnlCusInfo.Controls.Add(Me.lblMobileNo)
        Me.pnlCusInfo.Controls.Add(Me.lblLastDate)
        Me.pnlCusInfo.Controls.Add(Me.lblImage)
        Me.pnlCusInfo.Location = New System.Drawing.Point(667, 109)
        Me.pnlCusInfo.Name = "pnlCusInfo"
        Me.pnlCusInfo.Size = New System.Drawing.Size(518, 480)
        Me.pnlCusInfo.TabIndex = 25
        '
        'DisplayBillingSystem
        '
        Me.DisplayBillingSystem.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DisplayBillingSystem.BackColor = System.Drawing.Color.Transparent
        Me.DisplayBillingSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.DisplayBillingSystem.Location = New System.Drawing.Point(189, 188)
        Me.DisplayBillingSystem.Name = "DisplayBillingSystem"
        Me.DisplayBillingSystem.Size = New System.Drawing.Size(299, 26)
        Me.DisplayBillingSystem.TabIndex = 15
        Me.DisplayBillingSystem.Text = "-"
        Me.DisplayBillingSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomerType
        '
        Me.lblCustomerType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCustomerType.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.lblCustomerType.Location = New System.Drawing.Point(2, 188)
        Me.lblCustomerType.Name = "lblCustomerType"
        Me.lblCustomerType.Size = New System.Drawing.Size(180, 26)
        Me.lblCustomerType.TabIndex = 14
        Me.lblCustomerType.Text = "Customer Type :"
        Me.lblCustomerType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DisplayAccountNumber
        '
        Me.DisplayAccountNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DisplayAccountNumber.BackColor = System.Drawing.Color.Transparent
        Me.DisplayAccountNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.DisplayAccountNumber.Location = New System.Drawing.Point(189, 144)
        Me.DisplayAccountNumber.Name = "DisplayAccountNumber"
        Me.DisplayAccountNumber.Size = New System.Drawing.Size(299, 26)
        Me.DisplayAccountNumber.TabIndex = 13
        Me.DisplayAccountNumber.Text = "-"
        Me.DisplayAccountNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAccountNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.lblAccountNumber.Location = New System.Drawing.Point(3, 144)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(180, 26)
        Me.lblAccountNumber.TabIndex = 12
        Me.lblAccountNumber.Text = "Account Number :"
        Me.lblAccountNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DisplayMobileNo
        '
        Me.DisplayMobileNo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DisplayMobileNo.BackColor = System.Drawing.Color.Transparent
        Me.DisplayMobileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.DisplayMobileNo.Location = New System.Drawing.Point(189, 100)
        Me.DisplayMobileNo.Name = "DisplayMobileNo"
        Me.DisplayMobileNo.Size = New System.Drawing.Size(299, 26)
        Me.DisplayMobileNo.TabIndex = 11
        Me.DisplayMobileNo.Text = "-"
        Me.DisplayMobileNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DisplayLastDate
        '
        Me.DisplayLastDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DisplayLastDate.BackColor = System.Drawing.Color.Transparent
        Me.DisplayLastDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.DisplayLastDate.Location = New System.Drawing.Point(192, 58)
        Me.DisplayLastDate.Name = "DisplayLastDate"
        Me.DisplayLastDate.Size = New System.Drawing.Size(296, 26)
        Me.DisplayLastDate.TabIndex = 10
        Me.DisplayLastDate.Text = "-"
        Me.DisplayLastDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DisplayImage
        '
        Me.DisplayImage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DisplayImage.BackColor = System.Drawing.Color.Transparent
        Me.DisplayImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.DisplayImage.Location = New System.Drawing.Point(189, 14)
        Me.DisplayImage.Name = "DisplayImage"
        Me.DisplayImage.Size = New System.Drawing.Size(299, 26)
        Me.DisplayImage.TabIndex = 9
        Me.DisplayImage.Text = "-"
        Me.DisplayImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMobileNo
        '
        Me.lblMobileNo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMobileNo.BackColor = System.Drawing.Color.Transparent
        Me.lblMobileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.lblMobileNo.Location = New System.Drawing.Point(3, 100)
        Me.lblMobileNo.Name = "lblMobileNo"
        Me.lblMobileNo.Size = New System.Drawing.Size(180, 26)
        Me.lblMobileNo.TabIndex = 6
        Me.lblMobileNo.Text = "Mobile No :"
        Me.lblMobileNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastDate
        '
        Me.lblLastDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLastDate.BackColor = System.Drawing.Color.Transparent
        Me.lblLastDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.lblLastDate.Location = New System.Drawing.Point(3, 58)
        Me.lblLastDate.Name = "lblLastDate"
        Me.lblLastDate.Size = New System.Drawing.Size(180, 26)
        Me.lblLastDate.TabIndex = 5
        Me.lblLastDate.Text = "Last Capture Date :"
        Me.lblLastDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImage
        '
        Me.lblImage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblImage.BackColor = System.Drawing.Color.Transparent
        Me.lblImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(222, Byte))
        Me.lblImage.Location = New System.Drawing.Point(3, 14)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Size = New System.Drawing.Size(180, 26)
        Me.lblImage.TabIndex = 4
        Me.lblImage.Text = "Picture  :"
        Me.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDiaplayImage
        '
        Me.btnDiaplayImage.Location = New System.Drawing.Point(21, 109)
        Me.btnDiaplayImage.Name = "btnDiaplayImage"
        Me.btnDiaplayImage.Size = New System.Drawing.Size(274, 201)
        Me.btnDiaplayImage.TabIndex = 28
        Me.btnDiaplayImage.UseVisualStyleBackColor = True
        '
        'frmKiosCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1151, 666)
        Me.Controls.Add(Me.btnDiaplayImage)
        Me.Controls.Add(Me.pnlCusInfo)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.pbSave)
        Me.Controls.Add(Me.pbCapture)
        Me.Controls.Add(Me.pbReCapture)
        Me.Controls.Add(Me.pcCapture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmKiosCapture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Capture"
        CType(Me.pcCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbReCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCusInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcCapture As System.Windows.Forms.PictureBox
    Friend WithEvents pbReCapture As System.Windows.Forms.PictureBox
    Friend WithEvents pbCapture As System.Windows.Forms.PictureBox
    Friend WithEvents pbSave As System.Windows.Forms.PictureBox
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCusInfo As System.Windows.Forms.Panel
    Friend WithEvents lblImage As System.Windows.Forms.Label
    Friend WithEvents lblLastDate As System.Windows.Forms.Label
    Friend WithEvents lblMobileNo As System.Windows.Forms.Label
    Friend WithEvents DisplayMobileNo As System.Windows.Forms.Label
    Friend WithEvents DisplayLastDate As System.Windows.Forms.Label
    Friend WithEvents DisplayImage As System.Windows.Forms.Label
    Friend WithEvents lblAccountNumber As System.Windows.Forms.Label
    Friend WithEvents DisplayAccountNumber As System.Windows.Forms.Label
    Friend WithEvents lblCustomerType As System.Windows.Forms.Label
    Friend WithEvents DisplayBillingSystem As System.Windows.Forms.Label
    Friend WithEvents btnDiaplayImage As System.Windows.Forms.Button

End Class
