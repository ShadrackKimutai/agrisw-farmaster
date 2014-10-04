Public Class Accounts

    Dim cr As pltsales
    Dim dr As Milksales
    Dim cusr As CustReg
    Dim cas As Customer_Accounts
    Dim sr As Supreq
    Private Sub reset()
        SplitContainer1.Panel2.Controls.Clear()
    End Sub
    Private ReadOnly Property creg() As CustReg
        Get
            Me.cusr = New CustReg
            SplitContainer1.Panel2.Controls.Add(Me.cusr)
            Me.cusr.Dock = DockStyle.Fill
            Return Me.cusr
        End Get
    End Property
    Private ReadOnly Property spreq() As Supreq
        Get
            Me.sr = New Supreq
            SplitContainer1.Panel2.Controls.Add(Me.sr)
            Me.sr.Dock = DockStyle.Fill
            Return Me.sr

        End Get
    End Property
    Private ReadOnly Property cacs() As Customer_Accounts
        Get
            Me.cas = New Customer_Accounts
            SplitContainer1.Panel2.Controls.Add(Me.cas)
            Me.cas.Dock = DockStyle.Fill
            Return Me.cas
        End Get
    End Property
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call reset()
        Me.depr.Visible = True

    End Sub
    Private ReadOnly Property plant() As pltsales
        Get
            Me.cr = New pltsales
            SplitContainer1.Panel2.Controls.Add(Me.cr)
            Me.cr.Dock = DockStyle.Fill
            Return Me.cr
        End Get
    End Property
    Private ReadOnly Property depr() As Milksales
        Get
            Me.dr = New Milksales
            SplitContainer1.Panel2.Controls.Add(Me.dr)
            Me.dr.Dock = DockStyle.Fill
            Return Me.dr
        End Get
    End Property

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub Accounts_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With frmaster
            .ToolStripButton1.BackColor = Color.Transparent
        End With

    End Sub

    Private Sub Accounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With frmaster
            .ToolStripButton1.BackColor = Color.SteelBlue
            .ToolStripButton1.Font.Bold.ToString()
        End With
        Me.depr.Visible = True
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call reset()
        Me.plant.Visible = True
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Call reset()
        Me.creg.Visible = True

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Call reset()
        Me.cacs.Visible = True
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Call reset()
        Me.spreq.Visible = True
    End Sub
End Class