<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Floatingpane
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
        Dim OrderNoLabel As System.Windows.Forms.Label
        Dim CategoryLabel1 As System.Windows.Forms.Label
        Dim Item_TypeLabel1 As System.Windows.Forms.Label
        Dim Item_NameLabel1 As System.Windows.Forms.Label
        Dim QuantityLabel As System.Windows.Forms.Label
        Dim DOReqLabel As System.Windows.Forms.Label
        Dim StatusLabel As System.Windows.Forms.Label
        Dim ROLabel As System.Windows.Forms.Label
        Dim UnitsLabel1 As System.Windows.Forms.Label
        Dim StoIDLabel As System.Windows.Forms.Label
        Dim CategoryLabel As System.Windows.Forms.Label
        Dim Item_TypeLabel As System.Windows.Forms.Label
        Dim Item_NameLabel As System.Windows.Forms.Label
        Dim QttyLabel As System.Windows.Forms.Label
        Dim UnitsLabel As System.Windows.Forms.Label
        Dim DOPLabel As System.Windows.Forms.Label
        Dim RIDLabel As System.Windows.Forms.Label
        Dim ROfficerLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Floatingpane))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.OrderNoTextBox = New System.Windows.Forms.TextBox
        Me.CategoryTextBox1 = New System.Windows.Forms.TextBox
        Me.Item_TypeTextBox1 = New System.Windows.Forms.TextBox
        Me.Item_NameTextBox1 = New System.Windows.Forms.TextBox
        Me.QuantityTextBox = New System.Windows.Forms.TextBox
        Me.DOReqDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.StatusTextBox = New System.Windows.Forms.TextBox
        Me.ROTextBox = New System.Windows.Forms.TextBox
        Me.UnitsTextBox1 = New System.Windows.Forms.TextBox
        Me.StoIDTextBox = New System.Windows.Forms.TextBox
        Me.CategoryTextBox = New System.Windows.Forms.TextBox
        Me.Item_TypeTextBox = New System.Windows.Forms.TextBox
        Me.Item_NameTextBox = New System.Windows.Forms.TextBox
        Me.QttyTextBox = New System.Windows.Forms.TextBox
        Me.UnitsTextBox = New System.Windows.Forms.TextBox
        Me.DOPDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.RIDTextBox = New System.Windows.Forms.TextBox
        Me.ROfficerTextBox = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        OrderNoLabel = New System.Windows.Forms.Label
        CategoryLabel1 = New System.Windows.Forms.Label
        Item_TypeLabel1 = New System.Windows.Forms.Label
        Item_NameLabel1 = New System.Windows.Forms.Label
        QuantityLabel = New System.Windows.Forms.Label
        DOReqLabel = New System.Windows.Forms.Label
        StatusLabel = New System.Windows.Forms.Label
        ROLabel = New System.Windows.Forms.Label
        UnitsLabel1 = New System.Windows.Forms.Label
        StoIDLabel = New System.Windows.Forms.Label
        CategoryLabel = New System.Windows.Forms.Label
        Item_TypeLabel = New System.Windows.Forms.Label
        Item_NameLabel = New System.Windows.Forms.Label
        QttyLabel = New System.Windows.Forms.Label
        UnitsLabel = New System.Windows.Forms.Label
        DOPLabel = New System.Windows.Forms.Label
        RIDLabel = New System.Windows.Forms.Label
        ROfficerLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OrderNoLabel
        '
        OrderNoLabel.AutoSize = True
        OrderNoLabel.Location = New System.Drawing.Point(8, 49)
        OrderNoLabel.Name = "OrderNoLabel"
        OrderNoLabel.Size = New System.Drawing.Size(53, 13)
        OrderNoLabel.TabIndex = 61
        OrderNoLabel.Text = "Order No:"
        '
        'CategoryLabel1
        '
        CategoryLabel1.AutoSize = True
        CategoryLabel1.Location = New System.Drawing.Point(8, 75)
        CategoryLabel1.Name = "CategoryLabel1"
        CategoryLabel1.Size = New System.Drawing.Size(52, 13)
        CategoryLabel1.TabIndex = 63
        CategoryLabel1.Text = "Category:"
        '
        'Item_TypeLabel1
        '
        Item_TypeLabel1.AutoSize = True
        Item_TypeLabel1.Location = New System.Drawing.Point(8, 101)
        Item_TypeLabel1.Name = "Item_TypeLabel1"
        Item_TypeLabel1.Size = New System.Drawing.Size(57, 13)
        Item_TypeLabel1.TabIndex = 65
        Item_TypeLabel1.Text = "Item Type:"
        '
        'Item_NameLabel1
        '
        Item_NameLabel1.AutoSize = True
        Item_NameLabel1.Location = New System.Drawing.Point(8, 127)
        Item_NameLabel1.Name = "Item_NameLabel1"
        Item_NameLabel1.Size = New System.Drawing.Size(61, 13)
        Item_NameLabel1.TabIndex = 67
        Item_NameLabel1.Text = "Item Name:"
        '
        'QuantityLabel
        '
        QuantityLabel.AutoSize = True
        QuantityLabel.Location = New System.Drawing.Point(8, 153)
        QuantityLabel.Name = "QuantityLabel"
        QuantityLabel.Size = New System.Drawing.Size(49, 13)
        QuantityLabel.TabIndex = 69
        QuantityLabel.Text = "Quantity:"
        '
        'DOReqLabel
        '
        DOReqLabel.AutoSize = True
        DOReqLabel.Location = New System.Drawing.Point(8, 231)
        DOReqLabel.Name = "DOReqLabel"
        DOReqLabel.Size = New System.Drawing.Size(77, 13)
        DOReqLabel.TabIndex = 71
        DOReqLabel.Text = "Requested on:"
        '
        'StatusLabel
        '
        StatusLabel.AutoSize = True
        StatusLabel.Location = New System.Drawing.Point(8, 205)
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New System.Drawing.Size(40, 13)
        StatusLabel.TabIndex = 73
        StatusLabel.Text = "Status:"
        '
        'ROLabel
        '
        ROLabel.AutoSize = True
        ROLabel.Location = New System.Drawing.Point(8, 257)
        ROLabel.Name = "ROLabel"
        ROLabel.Size = New System.Drawing.Size(76, 13)
        ROLabel.TabIndex = 75
        ROLabel.Text = "Requested by:"
        '
        'UnitsLabel1
        '
        UnitsLabel1.AutoSize = True
        UnitsLabel1.Location = New System.Drawing.Point(7, 178)
        UnitsLabel1.Name = "UnitsLabel1"
        UnitsLabel1.Size = New System.Drawing.Size(34, 13)
        UnitsLabel1.TabIndex = 77
        UnitsLabel1.Text = "Units:"
        '
        'StoIDLabel
        '
        StoIDLabel.AutoSize = True
        StoIDLabel.Location = New System.Drawing.Point(413, 51)
        StoIDLabel.Name = "StoIDLabel"
        StoIDLabel.Size = New System.Drawing.Size(66, 13)
        StoIDLabel.TabIndex = 43
        StoIDLabel.Text = "ItemBatchID"
        '
        'CategoryLabel
        '
        CategoryLabel.AutoSize = True
        CategoryLabel.Location = New System.Drawing.Point(413, 77)
        CategoryLabel.Name = "CategoryLabel"
        CategoryLabel.Size = New System.Drawing.Size(52, 13)
        CategoryLabel.TabIndex = 45
        CategoryLabel.Text = "Category:"
        '
        'Item_TypeLabel
        '
        Item_TypeLabel.AutoSize = True
        Item_TypeLabel.Location = New System.Drawing.Point(413, 103)
        Item_TypeLabel.Name = "Item_TypeLabel"
        Item_TypeLabel.Size = New System.Drawing.Size(57, 13)
        Item_TypeLabel.TabIndex = 47
        Item_TypeLabel.Text = "Item Type:"
        '
        'Item_NameLabel
        '
        Item_NameLabel.AutoSize = True
        Item_NameLabel.Location = New System.Drawing.Point(413, 129)
        Item_NameLabel.Name = "Item_NameLabel"
        Item_NameLabel.Size = New System.Drawing.Size(61, 13)
        Item_NameLabel.TabIndex = 49
        Item_NameLabel.Text = "Item Name:"
        '
        'QttyLabel
        '
        QttyLabel.AutoSize = True
        QttyLabel.Location = New System.Drawing.Point(413, 155)
        QttyLabel.Name = "QttyLabel"
        QttyLabel.Size = New System.Drawing.Size(49, 13)
        QttyLabel.TabIndex = 51
        QttyLabel.Text = "Quantity:"
        '
        'UnitsLabel
        '
        UnitsLabel.AutoSize = True
        UnitsLabel.Location = New System.Drawing.Point(413, 181)
        UnitsLabel.Name = "UnitsLabel"
        UnitsLabel.Size = New System.Drawing.Size(34, 13)
        UnitsLabel.TabIndex = 53
        UnitsLabel.Text = "Units:"
        '
        'DOPLabel
        '
        DOPLabel.AutoSize = True
        DOPLabel.Location = New System.Drawing.Point(413, 208)
        DOPLabel.Name = "DOPLabel"
        DOPLabel.Size = New System.Drawing.Size(76, 13)
        DOPLabel.TabIndex = 55
        DOPLabel.Text = "Purchased on:"
        '
        'RIDLabel
        '
        RIDLabel.AutoSize = True
        RIDLabel.Location = New System.Drawing.Point(413, 233)
        RIDLabel.Name = "RIDLabel"
        RIDLabel.Size = New System.Drawing.Size(73, 13)
        RIDLabel.TabIndex = 57
        RIDLabel.Text = "RequisitionID:"
        '
        'ROfficerLabel
        '
        ROfficerLabel.AutoSize = True
        ROfficerLabel.Location = New System.Drawing.Point(413, 259)
        ROfficerLabel.Name = "ROfficerLabel"
        ROfficerLabel.Size = New System.Drawing.Size(76, 13)
        ROfficerLabel.TabIndex = 59
        ROfficerLabel.Text = "Requested by:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(462, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Storage"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Requests"
        '
        'OrderNoTextBox
        '
        Me.OrderNoTextBox.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.OrderNoTextBox.Location = New System.Drawing.Point(85, 46)
        Me.OrderNoTextBox.Name = "OrderNoTextBox"
        Me.OrderNoTextBox.ReadOnly = True
        Me.OrderNoTextBox.Size = New System.Drawing.Size(200, 20)
        Me.OrderNoTextBox.TabIndex = 62
        '
        'CategoryTextBox1
        '
        Me.CategoryTextBox1.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.CategoryTextBox1.Location = New System.Drawing.Point(85, 72)
        Me.CategoryTextBox1.Name = "CategoryTextBox1"
        Me.CategoryTextBox1.ReadOnly = True
        Me.CategoryTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.CategoryTextBox1.TabIndex = 64
        '
        'Item_TypeTextBox1
        '
        Me.Item_TypeTextBox1.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.Item_TypeTextBox1.Location = New System.Drawing.Point(85, 98)
        Me.Item_TypeTextBox1.Name = "Item_TypeTextBox1"
        Me.Item_TypeTextBox1.ReadOnly = True
        Me.Item_TypeTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.Item_TypeTextBox1.TabIndex = 66
        '
        'Item_NameTextBox1
        '
        Me.Item_NameTextBox1.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.Item_NameTextBox1.Location = New System.Drawing.Point(85, 124)
        Me.Item_NameTextBox1.Name = "Item_NameTextBox1"
        Me.Item_NameTextBox1.ReadOnly = True
        Me.Item_NameTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.Item_NameTextBox1.TabIndex = 68
        '
        'QuantityTextBox
        '
        Me.QuantityTextBox.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.QuantityTextBox.Location = New System.Drawing.Point(85, 150)
        Me.QuantityTextBox.Name = "QuantityTextBox"
        Me.QuantityTextBox.ReadOnly = True
        Me.QuantityTextBox.Size = New System.Drawing.Size(200, 20)
        Me.QuantityTextBox.TabIndex = 70
        '
        'DOReqDateTimePicker
        '
        Me.DOReqDateTimePicker.Enabled = False
        Me.DOReqDateTimePicker.Location = New System.Drawing.Point(85, 227)
        Me.DOReqDateTimePicker.Name = "DOReqDateTimePicker"
        Me.DOReqDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DOReqDateTimePicker.TabIndex = 72
        '
        'StatusTextBox
        '
        Me.StatusTextBox.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.StatusTextBox.Location = New System.Drawing.Point(85, 201)
        Me.StatusTextBox.Name = "StatusTextBox"
        Me.StatusTextBox.ReadOnly = True
        Me.StatusTextBox.Size = New System.Drawing.Size(200, 20)
        Me.StatusTextBox.TabIndex = 74
        '
        'ROTextBox
        '
        Me.ROTextBox.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ROTextBox.Location = New System.Drawing.Point(85, 254)
        Me.ROTextBox.Name = "ROTextBox"
        Me.ROTextBox.ReadOnly = True
        Me.ROTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ROTextBox.TabIndex = 76
        '
        'UnitsTextBox1
        '
        Me.UnitsTextBox1.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.UnitsTextBox1.Location = New System.Drawing.Point(84, 175)
        Me.UnitsTextBox1.Name = "UnitsTextBox1"
        Me.UnitsTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.UnitsTextBox1.TabIndex = 78
        '
        'StoIDTextBox
        '
        Me.StoIDTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.StoIDTextBox.Location = New System.Drawing.Point(493, 48)
        Me.StoIDTextBox.Name = "StoIDTextBox"
        Me.StoIDTextBox.ReadOnly = True
        Me.StoIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.StoIDTextBox.TabIndex = 44
        '
        'CategoryTextBox
        '
        Me.CategoryTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.CategoryTextBox.Location = New System.Drawing.Point(493, 74)
        Me.CategoryTextBox.Name = "CategoryTextBox"
        Me.CategoryTextBox.ReadOnly = True
        Me.CategoryTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CategoryTextBox.TabIndex = 46
        '
        'Item_TypeTextBox
        '
        Me.Item_TypeTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.Item_TypeTextBox.Location = New System.Drawing.Point(493, 100)
        Me.Item_TypeTextBox.Name = "Item_TypeTextBox"
        Me.Item_TypeTextBox.ReadOnly = True
        Me.Item_TypeTextBox.Size = New System.Drawing.Size(200, 20)
        Me.Item_TypeTextBox.TabIndex = 48
        '
        'Item_NameTextBox
        '
        Me.Item_NameTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.Item_NameTextBox.Location = New System.Drawing.Point(493, 126)
        Me.Item_NameTextBox.Name = "Item_NameTextBox"
        Me.Item_NameTextBox.ReadOnly = True
        Me.Item_NameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.Item_NameTextBox.TabIndex = 50
        '
        'QttyTextBox
        '
        Me.QttyTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.QttyTextBox.Location = New System.Drawing.Point(493, 152)
        Me.QttyTextBox.Name = "QttyTextBox"
        Me.QttyTextBox.ReadOnly = True
        Me.QttyTextBox.Size = New System.Drawing.Size(200, 20)
        Me.QttyTextBox.TabIndex = 52
        '
        'UnitsTextBox
        '
        Me.UnitsTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.UnitsTextBox.Location = New System.Drawing.Point(493, 178)
        Me.UnitsTextBox.Name = "UnitsTextBox"
        Me.UnitsTextBox.ReadOnly = True
        Me.UnitsTextBox.Size = New System.Drawing.Size(200, 20)
        Me.UnitsTextBox.TabIndex = 54
        '
        'DOPDateTimePicker
        '
        Me.DOPDateTimePicker.Enabled = False
        Me.DOPDateTimePicker.Location = New System.Drawing.Point(493, 204)
        Me.DOPDateTimePicker.Name = "DOPDateTimePicker"
        Me.DOPDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DOPDateTimePicker.TabIndex = 56
        '
        'RIDTextBox
        '
        Me.RIDTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.RIDTextBox.Location = New System.Drawing.Point(493, 230)
        Me.RIDTextBox.Name = "RIDTextBox"
        Me.RIDTextBox.ReadOnly = True
        Me.RIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.RIDTextBox.TabIndex = 58
        '
        'ROfficerTextBox
        '
        Me.ROfficerTextBox.BackColor = System.Drawing.Color.LightCyan
        Me.ROfficerTextBox.Location = New System.Drawing.Point(493, 256)
        Me.ROfficerTextBox.Name = "ROfficerTextBox"
        Me.ROfficerTextBox.ReadOnly = True
        Me.ROfficerTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ROfficerTextBox.TabIndex = 60
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(306, 306)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 45)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "&Process"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Floatingpane
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(706, 363)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(OrderNoLabel)
        Me.Controls.Add(Me.OrderNoTextBox)
        Me.Controls.Add(CategoryLabel1)
        Me.Controls.Add(Me.CategoryTextBox1)
        Me.Controls.Add(Item_TypeLabel1)
        Me.Controls.Add(Me.Item_TypeTextBox1)
        Me.Controls.Add(Item_NameLabel1)
        Me.Controls.Add(Me.Item_NameTextBox1)
        Me.Controls.Add(QuantityLabel)
        Me.Controls.Add(Me.QuantityTextBox)
        Me.Controls.Add(DOReqLabel)
        Me.Controls.Add(Me.DOReqDateTimePicker)
        Me.Controls.Add(StatusLabel)
        Me.Controls.Add(Me.StatusTextBox)
        Me.Controls.Add(ROLabel)
        Me.Controls.Add(Me.ROTextBox)
        Me.Controls.Add(UnitsLabel1)
        Me.Controls.Add(Me.UnitsTextBox1)
        Me.Controls.Add(StoIDLabel)
        Me.Controls.Add(Me.StoIDTextBox)
        Me.Controls.Add(CategoryLabel)
        Me.Controls.Add(Me.CategoryTextBox)
        Me.Controls.Add(Item_TypeLabel)
        Me.Controls.Add(Me.Item_TypeTextBox)
        Me.Controls.Add(Item_NameLabel)
        Me.Controls.Add(Me.Item_NameTextBox)
        Me.Controls.Add(QttyLabel)
        Me.Controls.Add(Me.QttyTextBox)
        Me.Controls.Add(UnitsLabel)
        Me.Controls.Add(Me.UnitsTextBox)
        Me.Controls.Add(DOPLabel)
        Me.Controls.Add(Me.DOPDateTimePicker)
        Me.Controls.Add(RIDLabel)
        Me.Controls.Add(Me.RIDTextBox)
        Me.Controls.Add(ROfficerLabel)
        Me.Controls.Add(Me.ROfficerTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Floatingpane"
        Me.ShowInTaskbar = False
        Me.Text = "Process Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OrderNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CategoryTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Item_TypeTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Item_NameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents QuantityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DOReqDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ROTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitsTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents StoIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CategoryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Item_TypeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Item_NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QttyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DOPDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents RIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ROfficerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
