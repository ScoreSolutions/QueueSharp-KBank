﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSegment
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSegment))
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Grid = New System.Windows.Forms.DataGridView
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbCustomerType = New System.Windows.Forms.ComboBox
        Me.cbActive = New System.Windows.Forms.CheckBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Grouper1 = New CodeVendor.Controls.Grouper
        Me.cbSearch = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.ColorPicker = New System.Windows.Forms.ColorDialog
        Me.segment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.customertype_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.active_status = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxButton.SuspendLayout()
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName.Location = New System.Drawing.Point(144, 57)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(294, 24)
        Me.txtName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Segment :"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToOrderColumns = True
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.segment, Me.id, Me.customertype_id, Me.active_status, Me.status})
        Me.Grid.Location = New System.Drawing.Point(9, 52)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(449, 216)
        Me.Grid.TabIndex = 11
        '
        'GroupBoxButton
        '
        Me.GroupBoxButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxButton.BackgroundColor = System.Drawing.Color.White
        Me.GroupBoxButton.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.GroupBoxButton.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.GroupBoxButton.BorderColor = System.Drawing.Color.SteelBlue
        Me.GroupBoxButton.BorderThickness = 1.0!
        Me.GroupBoxButton.Controls.Add(Me.Label1)
        Me.GroupBoxButton.Controls.Add(Me.cbCustomerType)
        Me.GroupBoxButton.Controls.Add(Me.cbActive)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.btnCancel)
        Me.GroupBoxButton.Controls.Add(Me.btnAdd)
        Me.GroupBoxButton.Controls.Add(Me.Label2)
        Me.GroupBoxButton.Controls.Add(Me.btnSave)
        Me.GroupBoxButton.Controls.Add(Me.txtName)
        Me.GroupBoxButton.CustomGroupBoxColor = System.Drawing.Color.White
        Me.GroupBoxButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBoxButton.GroupImage = Nothing
        Me.GroupBoxButton.GroupTitle = ""
        Me.GroupBoxButton.Location = New System.Drawing.Point(6, -2)
        Me.GroupBoxButton.MinimumSize = New System.Drawing.Size(1, 1)
        Me.GroupBoxButton.Name = "GroupBoxButton"
        Me.GroupBoxButton.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBoxButton.PaintGroupBox = False
        Me.GroupBoxButton.RoundCorners = 10
        Me.GroupBoxButton.ShadowColor = System.Drawing.Color.DarkGray
        Me.GroupBoxButton.ShadowControl = True
        Me.GroupBoxButton.ShadowThickness = 3
        Me.GroupBoxButton.Size = New System.Drawing.Size(471, 176)
        Me.GroupBoxButton.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Customer Type :"
        '
        'cbCustomerType
        '
        Me.cbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomerType.FormattingEnabled = True
        Me.cbCustomerType.Location = New System.Drawing.Point(144, 23)
        Me.cbCustomerType.Name = "cbCustomerType"
        Me.cbCustomerType.Size = New System.Drawing.Size(202, 26)
        Me.cbCustomerType.TabIndex = 18
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Enabled = False
        Me.cbActive.Location = New System.Drawing.Point(144, 89)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(66, 22)
        Me.cbActive.TabIndex = 7
        Me.cbActive.Text = "Active"
        Me.cbActive.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(353, 57)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Image = Global.QueueSharp.My.Resources.Resources.Close
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(336, 121)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 40)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAdd.Image = Global.QueueSharp.My.Resources.Resources.Add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(144, 121)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 40)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSave.Image = Global.QueueSharp.My.Resources.Resources.Save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(240, 121)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Grouper1
        '
        Me.Grouper1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.Grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.Grouper1.BorderColor = System.Drawing.Color.SteelBlue
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.cbSearch)
        Me.Grouper1.Controls.Add(Me.Label3)
        Me.Grouper1.Controls.Add(Me.txtSearch)
        Me.Grouper1.Controls.Add(Me.Grid)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 166)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(471, 280)
        Me.Grouper1.TabIndex = 25
        '
        'cbSearch
        '
        Me.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Items.AddRange(New Object() {"All", "Active", "Inactive"})
        Me.cbSearch.Location = New System.Drawing.Point(318, 18)
        Me.cbSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(140, 26)
        Me.cbSearch.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 18)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Search :"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(75, 19)
        Me.txtSearch.MaxLength = 100
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(237, 24)
        Me.txtSearch.TabIndex = 9
        '
        'segment
        '
        Me.segment.DataPropertyName = "segment"
        Me.segment.FillWeight = 194.9239!
        Me.segment.HeaderText = "Segment"
        Me.segment.Name = "segment"
        Me.segment.ReadOnly = True
        Me.segment.Width = 280
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'customertype_id
        '
        Me.customertype_id.DataPropertyName = "customertype_id"
        Me.customertype_id.HeaderText = "customertype_id"
        Me.customertype_id.Name = "customertype_id"
        Me.customertype_id.ReadOnly = True
        Me.customertype_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.customertype_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.customertype_id.Visible = False
        Me.customertype_id.Width = 80
        '
        'active_status
        '
        Me.active_status.DataPropertyName = "active_status"
        Me.active_status.HeaderText = "Active"
        Me.active_status.Name = "active_status"
        Me.active_status.ReadOnly = True
        Me.active_status.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.active_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.active_status.Visible = False
        Me.active_status.Width = 80
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle1
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'frmSegment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(481, 450)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSegment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Segment"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents ColorPicker As System.Windows.Forms.ColorDialog
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCustomerType As System.Windows.Forms.ComboBox
    Friend WithEvents segment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customertype_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents active_status As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
