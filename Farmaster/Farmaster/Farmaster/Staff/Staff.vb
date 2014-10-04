Public Class Staff
    Dim sl As Stafflst
    Dim rns As RegModstaff
    Private ReadOnly Property rmsff() As RegModstaff
        Get
            Me.rns = New RegModstaff
            SplitContainer1.Panel2.Controls.Add(Me.rns)
            rns.Dock = DockStyle.Fill
            Return Me.rns
        End Get
    End Property
    Private ReadOnly Property stfl() As Stafflst
        Get
            Me.sl = New Stafflst
            SplitContainer1.Panel2.Controls.Add(Me.sl)
            sl.Dock = DockStyle.Fill
            Return Me.sl
        End Get
    End Property

    Private Sub Staff_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With frmaster
            .ToolStripButton6.BackColor = Color.Transparent
            '.ToolStripButton2.Font.Bold.ToString()
        End With
    End Sub
    Private Sub Staff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With frmaster
            .ToolStripButton6.BackColor = Color.SteelBlue
            .ToolStripButton6.Font.Bold.ToString()
        End With
        stfl.Visible = True

    End Sub
    Private Sub reset()
        SplitContainer1.Panel2.Controls.Clear()
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call reset()
        Me.stfl.Visible = True
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call reset()
        Me.rmsff.Visible = 1

    End Sub
End Class