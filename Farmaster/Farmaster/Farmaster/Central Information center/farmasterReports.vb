Imports System.Data.OleDb
Public Class farmasterReports
    Dim fx, c As Integer

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rp As New animalreg
        Dim storeps As New Storagereps
        Dim drp As New daymilktrend
        Dim deran As New danimrep
        Dim lndus As New Plantyield
        Dim con As New OleDb.OleDbConnection
        Dim sconn As New OleDb.OleDbConnection
        Dim ly As New landyield
        Try
            cnn.Close()
            Call connect()

        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "An Error Occured")
        End Try
        cnn.Open()
        Dim daSrch As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
        'Dim ds As DataSet = New DataSet
        Dim dt As DataTable = New DataTable
        Dim dsSrch As DataSet = New DataSet
        'Dim drSrch As DataRow
        Select Case fx
            Case 1
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where Animal_Name like'%" & TextBox1.Text & "%' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.reportview.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 2
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where sex ='" & ComboBox1.Text & "' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.reportview.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 3
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where (DOB BETWEEN '" & Trim(ComboBox2.Text) & " /01/01 12:00:00 AM' AND '" & Trim(ComboBox2.Text) & " /12/31 12:00:00 AM')", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.reportview.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 4
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where breed like '%" & Trim(ComboBox3.Text) & "%'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.reportview.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 5
                Try
                    If ComboBox7.Text <> "OTHER" Then
                        daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where CURREnt_condition like '%" & Trim(ComboBox7.Text) & "%' ", cnn)

                    Else
                        daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where  (Current_Condition NOT LIKE 'healthy') AND (Current_Condition NOT LIKE 'sick') AND (Current_Condition NOT LIKE 'dead')", cnn)

                    End If
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.reportview.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()


            Case 6
             Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where (DOB BETWEEN '" & Trim(ComboBox5.Text) & " /01/01 12:00:00 AM' AND '" & Trim(ComboBox5.Text) & " /12/31 12:00:00 AM') and breed like '%" & Trim(ComboBox4.Text) & "%' and sex ='" & ComboBox6.Text & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.reportview.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 7
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from dairymilk Where animal='" & ComboBox10.Text & "' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    drp.SetDataSource(dt)
                    Me.reportview.ReportSource = drp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 8
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from dairymilk Where tagid='" & ComboBox11.Text & "' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    drp.SetDataSource(dt)
                    Me.reportview.ReportSource = drp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 9
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from dairymilk Where milking_day='" & DateTimePicker1.Text & "' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    drp.SetDataSource(dt)
                    Me.reportview.ReportSource = drp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 10
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from dairymilk where milking_day between '" & DateTimePicker2.Text & "' and '" & DateTimePicker3.Text & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    drp.SetDataSource(dt)
                    Me.reportview.ReportSource = drp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 11
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from danimalhq Where Reason='" & Trim(ComboBox8.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    deran.SetDataSource(dt)
                    Me.reportview.ReportSource = deran
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 12
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from danimalhq Where (DOdr BETWEEN '" & Trim(ComboBox9.Text) & " /01/01 12:00:00 AM' AND '" & Trim(ComboBox9.Text) & " /12/31 12:00:00 AM')", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    deran.SetDataSource(dt)
                    Me.reportview.ReportSource = deran
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 13
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landuse Where plotname='" & Trim(ComboBox13.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    lndus.SetDataSource(dt)
                    Me.reportview.ReportSource = lndus
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 14
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landuse Where plantationid='" & Trim(ComboBox12.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    lndus.SetDataSource(dt)
                    Me.reportview.ReportSource = lndus
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
                'Case 15
                '    Try
                '        daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landuse Where plantationid='" & Trim(ComboBox12.Text) & "'", cnn)
                '        dsSrch.Clear()
                '        daSrch.Fill(dt)
                '        lndus.SetDataSource(dt)
                '        Me.reportview.ReportSource = lndus
                '    Catch ex As Exception

                '        MsgBox(ex.Message)
                '    End Try
                '    cnn.Close()
            Case 15
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landuse Where Planted_on < '" & Trim(DateTimePicker4.Value.ToString) & "' and due > '" & Trim(DateTimePicker4.Value.ToString) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    lndus.SetDataSource(dt)
                    Me.reportview.ReportSource = lndus
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 16
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landuse Where crop='" & Trim(ComboBox14.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    lndus.SetDataSource(dt)
                    Me.reportview.ReportSource = lndus
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 17
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landyieldhq Where crop='" & Trim(ComboBox15.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    ly.SetDataSource(dt)
                    Me.reportview.ReportSource = ly
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 18
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landyieldhq Where plotid='" & Trim(ComboBox16.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    ly.SetDataSource(dt)
                    Me.reportview.ReportSource = ly
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 19
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from landyieldhq Where harvested_on='" & Trim(DateTimePicker5.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    ly.SetDataSource(dt)
                    Me.reportview.ReportSource = ly
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
            Case 20
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from STORAGEHQ Where NAME='" & Trim(TextBox2.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    storeps.SetDataSource(dt)
                    Me.reportview.ReportSource = storeps
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()

            Case 21
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from STORAGEHQ Where category='" & Trim(ComboBox17.Text) & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    storeps.SetDataSource(dt)
                    Me.reportview.ReportSource = storeps
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
        End Select

        reportview.Zoom(62)
        'reportview.
        Dim x As MsgBoxResult = MsgBox("do you want to export the report?", MsgBoxStyle.YesNo)
        If x = MsgBoxResult.Yes Then
            Call Butt()
        Else
        End If
    End Sub

    Private Sub farmasterReports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With frmaster
            .ToolStripSplitButton1.BackColor = Color.Transparent

            '.ToolStripButton1.Font.Bold.ToString()
        End With
    End Sub

    Private Sub farmasterReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         Call fillcombos()
        Call fillyears()
        Call fillbl()

        With frmaster
            .ToolStripSplitButton1.BackColor = Color.Sienna
            '.ToolStripButton1.Font.Bold.ToString()
        End With
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True


        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        fx = 1
    End Sub
    Private Sub fillyears()
        Dim y(15) As Integer
        Dim x, i, j As Integer
        c = DateTime.Now.Year.ToString
        x = c - 15
        'For i = 0 To i = 14
        '    y(i) = x
        '    x = x + 1
        '    i = i + 1
        '    MsgBox(x)
        'Next i
        i = 0
        While i < 16
            y(i) = x
            x = x + 1
            i = i + 1
            'MsgBox(x)

        End While
        j = 0
        With ComboBox2
            While j < 16
                .Items.Add(y(j))
                j = j + 1
                'MsgBox(y(j))
            End While
            .SelectedIndex = 0
        End With
        With ComboBox5
            Dim k As Integer = 0
            While k < 16
                .Items.Add(y(k))
                k = k + 1
                'MsgBox(y(j))
            End While
            .SelectedIndex = 0
        End With
        With ComboBox9
            Dim M As Integer = 0
            While M < 16
                .Items.Add(y(M))
                M = M + 1
                'MsgBox(y(j))
            End While
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
    Private Sub fillcombos()
        With ComboBox7
            .Items.Add("HEALTHY")
            .Items.Add("SICK")
            .Items.Add("DEAD")
            .Items.Add("OTHER")
            .SelectedIndex = 0
        End With
        With ComboBox1
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .SelectedIndex = 0
        End With

        With ComboBox8
            .Items.Add("SOLD")
            .Items.Add("DEAD")
            .Items.Add("OTHER")

            .SelectedIndex = 0
        End With

        Dim cn As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim str As String = "SELECT breedname FROM Breed"
        Dim dat As New OleDbDataAdapter(str, cn)
        Dim ds As New DataSet
        dat.Fill(ds, "Breed")
        With ComboBox3
            .DataSource = ds.Tables("Breed")
            .DisplayMember = "Breedname"
            .ValueMember = "Breedname"
            '.SelectedIndex = 0
       
        End With
       
        With ComboBox6
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub fillbl()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT breedname FROM Breed"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "Breed")
        With ComboBox4
            .DataSource = dset.Tables("Breed")
            .DisplayMember = "Breedname"
            .ValueMember = "Breedname"
            '.SelectedIndex = 0
        End With

    End Sub
    Private Sub filldcow()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct animal from dairymilk"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "dairymilk")
        With ComboBox10
            .DataSource = dset.Tables("dairymilk")
            .DisplayMember = "animal"
            .ValueMember = "animal"
            '.SelectedIndex = 0
        End With
        Call filldtag()

    End Sub
    Private Sub filldtag()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct tagid from dairymilk"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "dairymilk")
        With ComboBox11
            .DataSource = dset.Tables("dairymilk")
            .DisplayMember = "tagid"
            .ValueMember = "tagid"
            '.SelectedIndex = 0
        End With
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        fx = 2
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        fx = 3
    End Sub

    Private Sub reportview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportview.Load

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        fx = 4
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        fx = 6
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        fx = 6
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        fx = 6
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        fx = 5
    End Sub

    

   
    Private Sub Butt()
        reportview.ExportReport()
    End Sub

    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        With ToolTip1
            .Show("Select Condition(s)above and then Press Process to Generate reports based on the conditions stated", Me, 5000)

        End With
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        fx = 7
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        fx = 8
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        fx = 9
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Call filldcow()
            DateTimePicker2.MaxDate = Today
            DateTimePicker2.Enabled = True
            DateTimePicker3.Enabled = False
        Else
            If TabControl1.SelectedIndex = 2 Then
                Call fillland()
                Call fillplotname()
                Call fillcrop()
            End If
        End If
    End Sub
    Private Sub fillcrop()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct crop from landuse"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "landuse")
        With ComboBox15
            .DataSource = dset.Tables("landuse")
            .DisplayMember = "crop"
            .ValueMember = "crop"
            '.SelectedIndex = 0
        End With
        Call fillcrop2()
    End Sub
    Private Sub fillcrop2()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct crop from landyieldhq"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "landyieldhq")
        With ComboBox14
            .DataSource = dset.Tables("landyieldhq")
            .DisplayMember = "crop"
            .ValueMember = "crop"
            '.SelectedIndex = 0
        End With
        Call fillplotid()
    End Sub
    Private Sub fillplotid()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct plotid from landyieldhq"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "landyieldhq")
        With ComboBox16
            .DataSource = dset.Tables("landyieldhq")
            .DisplayMember = "plotid"
            .ValueMember = "plotid"
            '.SelectedIndex = 0
        End With
    End Sub
    Private Sub fillland()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct Plantationid from landuse"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "landuse")
        With ComboBox12
            .DataSource = dset.Tables("landuse")
            .DisplayMember = "plantationid"
            .ValueMember = "plantationid"
            '.SelectedIndex = 0
        End With

    End Sub
    Private Sub fillplotname()
        Dim con As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=farmaster;User ID=sa;Password=swiftshady")

        Dim stor As String = "SELECT distinct Plotname from landuse"
        Dim data As New SqlClient.SqlDataAdapter(stor, con)
        Dim dset As New DataSet
        data.Fill(dset, "landuse")
        With ComboBox13
            .DataSource = dset.Tables("landuse")
            .DisplayMember = "plotname"
            .ValueMember = "plotname"
            '.SelectedIndex = 0
        End With
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker2.Enabled = False
        fx = 10
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        With DateTimePicker3

            .MinDate = DateTimePicker2.Value
            .MaxDate = Today
            .Enabled = True
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        '
        DateTimePicker2.Enabled = True
        DateTimePicker3.Enabled = False
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox13.SelectedIndexChanged
        fx = 13
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        fx = 11
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        fx = 12
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        fx = 14
    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged
        fx = 15
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox14.SelectedIndexChanged
        fx = 16
    End Sub

    Private Sub ComboBox15_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox15.SelectedIndexChanged
        fx = 17
    End Sub

    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox16.SelectedIndexChanged
        fx = 18
    End Sub

    Private Sub DateTimePicker5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker5.ValueChanged
        fx = 19
    End Sub

    Private Sub TextBox2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        fx = 20
        ComboBox17.SelectedIndex = 0
    End Sub

    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox17.SelectedIndexChanged
        fx = 21
    End Sub

    Private Sub DateTimePicker6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker6.ValueChanged
        fx = 22
    End Sub

    Private Sub DateTimePicker7_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker7.ValueChanged

        DateTimePicker8.Enabled = True
        DateTimePicker8.MinDate = DateTimePicker7.Value
        DateTimePicker8.MaxDate = Today
        DateTimePicker7.Enabled = False

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        DateTimePicker7.Enabled = True
        DateTimePicker7.MaxDate = Today

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DateTimePicker7.Enabled = False
        DateTimePicker8.Enabled = False
        TextBox3.Focus()

    End Sub

    Private Sub DateTimePicker8_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker8.ValueChanged
        fx = 23
    End Sub
End Class