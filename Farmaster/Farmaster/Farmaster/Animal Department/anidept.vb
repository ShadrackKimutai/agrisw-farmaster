Public Class anidept
    Dim herlst As heardlist
    Dim anreg As Animal_Registrar
    Dim mlk As DailyMilkRecord
    Dim dr As Depreq
    Private ReadOnly Property depr() As Depreq
        Get
            Me.dr = New Depreq
            herdpan.Controls.Add(Me.dr)
            Me.dr.Dock = DockStyle.Fill
            Return Me.dr

        End Get
    End Property


    Private Sub remover()
        Me.herdpan.Controls.Clear()
    End Sub
    Private ReadOnly Property hl() As heardlist
        Get
            Me.herlst = New heardlist
            herdpan.Controls.Add(Me.herlst)
            Me.herlst.Dock = DockStyle.Fill
            Return Me.herlst


        End Get
    End Property


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call remover()
        Me.hl.Visible = True
    End Sub

    Private ReadOnly Property anre() As Animal_Registrar
        Get
            Me.anreg = New Animal_Registrar
            herdpan.Controls.Add(Me.anreg)
            Me.anreg.Dock = DockStyle.Fill
            Return Me.anreg
        End Get
    End Property
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call remover()
        Me.anre.Visible = True
    End Sub

    Private Sub anidept_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With frmaster
            .ToolStripButton2.BackColor = Color.Transparent

            ' .ToolStripButton5.Font.Bold.ToString()
        End With
    End Sub

    Private Sub anidept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        minipadparent = ""
        Me.ToolStripButton1.PerformClick()
        With frmaster
            .ToolStripButton2.BackColor = Color.SteelBlue
            '.ToolStripButton2.Font.Bold.ToString()
        End With

    End Sub
    Private ReadOnly Property dmk() As DailyMilkRecord
        Get
            Me.mlk = New DailyMilkRecord
            herdpan.Controls.Add(Me.mlk)
            Me.mlk.Dock = DockStyle.Fill
            Return Me.mlk

        End Get
    End Property

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Call remover()
        Me.dmk.Visible = True

    End Sub
    
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Call remover()
        Me.depr.Visible = True

    End Sub
End Class