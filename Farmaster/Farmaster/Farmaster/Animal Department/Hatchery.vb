Public Class Hatchery
    Dim tempma As Tempmap
    Dim eggchicmann As eggchicman
    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Call reset()
        Me.tmp.Visible = True

    End Sub
    Private ReadOnly Property ecm() As eggchicman
        Get
            Me.eggchicmann = New eggchicman
            SplitContainer1.Panel2.Controls.Add(Me.eggchicmann)
            Me.eggchicmann.Dock = DockStyle.Fill
            Return Me.eggchicmann
        End Get
    End Property
    Private ReadOnly Property tmp() As Tempmap
        Get
            Me.tempma = New Tempmap
            SplitContainer1.Panel2.Controls.Add(Me.tempma)
            Me.tempma.Dock = DockStyle.Fill
            Return Me.tempma
        End Get
    End Property
    Private Sub reset()
        SplitContainer1.Panel2.Controls.Clear()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call reset()
        Me.ecm.Visible = True
    End Sub
End Class