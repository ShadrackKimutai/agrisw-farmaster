Public Class Plantation
    Dim fv As Farmview
    Dim pltm As PlantationMng
    Dim dr As Depreq
    Private ReadOnly Property depr() As Depreq
        Get
            Me.dr = New Depreq
            Panel1.Controls.Add(Me.dr)
            Me.dr.Dock = DockStyle.Fill
            Return Me.dr

        End Get
    End Property

    Private Sub Plantation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With frmaster
            .ToolStripButton3.BackColor = Color.Transparent
            '.ToolStripButton2.Font.Bold.ToString()
        End With
    End Sub
    Private Sub Plantation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ToolStripButton1.PerformClick()

        With frmaster
            .ToolStripButton3.BackColor = Color.SteelBlue
            '.ToolStripButton2.Font.Bold.ToString()
        End With
    End Sub
    Private ReadOnly Property pmgr() As PlantationMng
        Get
            Me.pltm = New PlantationMng
            Panel1.Controls.Add(Me.pltm)
            pltm.Dock = DockStyle.Fill
            Return Me.pltm
        End Get
    End Property
    Private ReadOnly Property famv() As Farmview
        Get
            Me.fv = New Farmview
            Panel1.Controls.Add(Me.fv)
            fv.Dock = DockStyle.Fill
            Return Me.fv
        End Get
    End Property
    Private Sub remover()
        Panel1.Controls.Clear()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call remover()
        famv.Visible = True
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call remover()
        pmgr.Visible = True

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Call remover()
        Me.depr.Visible = True

    End Sub
End Class