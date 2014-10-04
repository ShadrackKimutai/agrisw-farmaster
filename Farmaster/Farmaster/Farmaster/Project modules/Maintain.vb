
Module Maintain

    Public stat As Boolean = False
    Public inp, tempstring As String
    Public minipadid As String
    Public minipadparent As String
    Public sterm As String
    Public msgg As String

    Public Sub defineme()
        If dept = "ANIDEPT" Then
            frmaster.ToolStripButton1.Enabled = False
            frmaster.ToolStripButton3.Enabled = False
            frmaster.ToolStripButton6.Enabled = False
            frmaster.ToolStripButton5.Enabled = False

            frmaster.ToolStripButton2.PerformClick()
        End If

        If dept = "PLTDEPT" Then

            frmaster.ToolStripButton1.Enabled = False
            frmaster.ToolStripButton6.Enabled = False
            frmaster.ToolStripButton3.PerformClick()
            frmaster.ToolStripButton5.Enabled = False
            frmaster.ToolStripButton2.Enabled = False
        End If
        If dept = "HRMDEPT" Then
            With frmaster
                frmaster.ToolStripButton1.Enabled = False
                'frmaster.ToolStripButton4.Enabled = False
                frmaster.ToolStripButton3.Enabled = False
                frmaster.ToolStripButton5.Enabled = False
                frmaster.ToolStripButton2.Enabled = False
                .ToolStripButton6.PerformClick()
            End With

        End If
        If dept = "ACCDEPT" Then
            frmaster.ToolStripButton1.PerformClick()
            frmaster.ToolStripButton3.Enabled = False
            frmaster.ToolStripButton2.Enabled = False
            frmaster.ToolStripButton5.Enabled = False
            frmaster.ToolStripButton6.Enabled = False

        End If
        If dept = "STODEPT" Then
            frmaster.ToolStripButton1.Enabled = False
            frmaster.ToolStripButton6.Enabled = False
            frmaster.ToolStripButton5.PerformClick()
            frmaster.ToolStripButton3.Enabled = False
            frmaster.ToolStripButton2.Enabled = False

        End If
        If dept = "SA" Then
            'frmaster.ToolStripButton1.Enabled = False


        End If


    End Sub



   


End Module
