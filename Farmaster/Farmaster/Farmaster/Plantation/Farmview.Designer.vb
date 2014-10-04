<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Farmview
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Farmview))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.rigthpan = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.toprigthpan = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.botrigthpan = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.botleftpan = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.botcpan = New System.Windows.Forms.Panel
        Me.topleftpan = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.rigthpan.SuspendLayout()
        Me.toprigthpan.SuspendLayout()
        Me.botrigthpan.SuspendLayout()
        Me.botleftpan.SuspendLayout()
        Me.topleftpan.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.rigthpan)
        Me.Panel1.Controls.Add(Me.toprigthpan)
        Me.Panel1.Controls.Add(Me.botrigthpan)
        Me.Panel1.Controls.Add(Me.botleftpan)
        Me.Panel1.Controls.Add(Me.topleftpan)
        Me.Panel1.Location = New System.Drawing.Point(16, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(893, 321)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(323, 162)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(260, 157)
        Me.Panel3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label4.Location = New System.Drawing.Point(47, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Plot 5"
        '
        'rigthpan
        '
        Me.rigthpan.BackColor = System.Drawing.Color.Transparent
        Me.rigthpan.Controls.Add(Me.Label6)
        Me.rigthpan.Location = New System.Drawing.Point(741, 0)
        Me.rigthpan.Name = "rigthpan"
        Me.rigthpan.Size = New System.Drawing.Size(150, 309)
        Me.rigthpan.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Plot 3"
        '
        'toprigthpan
        '
        Me.toprigthpan.BackColor = System.Drawing.Color.Transparent
        Me.toprigthpan.Controls.Add(Me.Label2)
        Me.toprigthpan.Location = New System.Drawing.Point(424, 3)
        Me.toprigthpan.Name = "toprigthpan"
        Me.toprigthpan.Size = New System.Drawing.Size(318, 159)
        Me.toprigthpan.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(136, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Plot 2"
        '
        'botrigthpan
        '
        Me.botrigthpan.BackColor = System.Drawing.Color.Transparent
        Me.botrigthpan.Controls.Add(Me.Label5)
        Me.botrigthpan.Location = New System.Drawing.Point(585, 161)
        Me.botrigthpan.Name = "botrigthpan"
        Me.botrigthpan.Size = New System.Drawing.Size(158, 149)
        Me.botrigthpan.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Plot 4"
        '
        'botleftpan
        '
        Me.botleftpan.BackColor = System.Drawing.Color.Transparent
        Me.botleftpan.Controls.Add(Me.Label3)
        Me.botleftpan.Controls.Add(Me.botcpan)
        Me.botleftpan.Location = New System.Drawing.Point(56, 161)
        Me.botleftpan.Name = "botleftpan"
        Me.botleftpan.Size = New System.Drawing.Size(265, 160)
        Me.botleftpan.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Plot 6"
        '
        'botcpan
        '
        Me.botcpan.Location = New System.Drawing.Point(264, 1)
        Me.botcpan.Name = "botcpan"
        Me.botcpan.Size = New System.Drawing.Size(264, 158)
        Me.botcpan.TabIndex = 0
        '
        'topleftpan
        '
        Me.topleftpan.BackColor = System.Drawing.Color.Transparent
        Me.topleftpan.Controls.Add(Me.Label1)
        Me.topleftpan.Location = New System.Drawing.Point(42, 7)
        Me.topleftpan.Name = "topleftpan"
        Me.topleftpan.Size = New System.Drawing.Size(381, 155)
        Me.topleftpan.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Plot 1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1074, 342)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Plantation Land View"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 371)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1074, 293)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(379, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 22)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Label13"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(703, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 22)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(703, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 22)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(703, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 22)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(379, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 22)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(379, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 22)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Label8"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Location = New System.Drawing.Point(6, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 271)
        Me.Panel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Georgia Ref", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 22)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Label7"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(332, 271)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Farmview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Farmview"
        Me.Size = New System.Drawing.Size(1106, 667)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.rigthpan.ResumeLayout(False)
        Me.rigthpan.PerformLayout()
        Me.toprigthpan.ResumeLayout(False)
        Me.toprigthpan.PerformLayout()
        Me.botrigthpan.ResumeLayout(False)
        Me.botrigthpan.PerformLayout()
        Me.botleftpan.ResumeLayout(False)
        Me.botleftpan.PerformLayout()
        Me.topleftpan.ResumeLayout(False)
        Me.topleftpan.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rigthpan As System.Windows.Forms.Panel
    Friend WithEvents toprigthpan As System.Windows.Forms.Panel
    Friend WithEvents botrigthpan As System.Windows.Forms.Panel
    Friend WithEvents botleftpan As System.Windows.Forms.Panel
    Friend WithEvents botcpan As System.Windows.Forms.Panel
    Friend WithEvents topleftpan As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

End Class
