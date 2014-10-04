Imports System.Data.oledb
Public Class PlantationMng
    Dim d, m, y, mgr As String
    Dim tempid, tempharvid, nina, tempplt As Integer

    Dim plt0n As Date

        
    Private Sub PlantationMng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call PLOTS()
        Call harv()
        Call nextid()
        Call fillplot()
        Call fillc()
        d = DateTime.Now.Day.ToString
        y = DateTime.Now.Year.ToString
        m = DateTime.Now.Month.ToString
        DateTimePicker1.Value = Today
        Call fillmat()
call havid
       
    End Sub
    Private Sub fillplot()
        Dim cm As New OleDbCommand
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT plotno  FROM plantationhq where  vacant='1'"
        Dim datad As New OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "PLANTATIONhq")
        With ComboBox1
            .DataSource = dset.Tables("plantationhq")
            .DisplayMember = "plotno"
            .ValueMember = "plotno"
            '
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
       
    End Sub
    Private Sub fillc()
        ComboBox3.SelectedIndex = 1
    End Sub

    Private Sub ComboBox3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox3.MouseClick
        Button3.Enabled = True
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        '   ComboBox3.SelectedIndex = 1
        Dim x As String
        Dim mmm As String

        If ComboBox3.Text = "Over 12 Months" Then

            If m < 12 Then
                Select Case m
                    Case 1
                        mmm = "February"
                    Case 2
                        mmm = "march"

                    Case 3
                        mmm = "April"
                    Case 4
                        mmm = "May"
                    Case 5
                        mmm = "June"
                    Case 6
                        mmm = "July"
                    Case 7
                        mmm = "August"
                    Case 8
                        mmm = "September"
                    Case 9
                        mmm = "October"
                    Case 10
                        mmm = "November"
                    Case 11
                        mmm = "December"
                    Case 12
                        mmm = "January"


                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                x = "" & Trim(d) & "" & Trim(("January")) & "" & Trim(y + 2) & ""

                DateTimePicker1.Text = x
            End If
        End If
        If ComboBox3.Text = "11 to 12 Months" Then

            If m < 12 Then
                Select Case m
                    Case 1
                        mmm = "January"
                    Case 2
                        mmm = "February"
                    Case 3
                        mmm = "march"

                    Case 4
                        mmm = "April"
                    Case 5
                        mmm = "May"
                    Case 6
                        mmm = "June"
                    Case 7
                        mmm = "July"
                    Case 8
                        mmm = "August"
                    Case 9
                        mmm = "September"
                    Case 10
                        mmm = "October"
                    Case 11
                        mmm = "November"
                    Case 12
                        mmm = "December"



                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""
                If GroupBox3.Enabled = False Then

                    x = Today

                    DateTimePicker1.Text = x
                Else
                    DateTimePicker1.Text = x
                End If

            Else
                x = "" & Trim(d) & "/" & Trim((DateTime.Now.Month.ToString)) & "/" & Trim(y + 1) & ""

                If GroupBox3.Enabled = False Then

                    x = Today

                    DateTimePicker1.Text = x
                Else
                    DateTimePicker1.Text = x
                End If
            End If
        End If
        If ComboBox3.Text = "10 to 11 Months" Then

            If m > 1 Then
                Select Case m
                    Case 3
                        mmm = "February"
                    Case 4
                        mmm = "march"

                    Case 5
                        mmm = "April"
                    Case 6
                        mmm = "May"
                    Case 7
                        mmm = "June"
                    Case 8
                        mmm = "July"
                    Case 9
                        mmm = "August"
                    Case 10
                        mmm = "September"
                    Case 11
                        mmm = "October"
                    Case 12
                        mmm = "November"
                    Case 1
                        mmm = "December"
                    Case 2
                        mmm = "January"


                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                x = "" & Trim(d) & "" & Trim(("December")) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If
        If ComboBox3.Text = "9 to 10 Months" Then

            If m > 2 Then
                Select Case m
                    Case 4
                        mmm = "February"
                    Case 5
                        mmm = "march"

                    Case 6
                        mmm = "April"
                    Case 7
                        mmm = "May"
                    Case 8
                        mmm = "June"
                    Case 9
                        mmm = "July"
                    Case 10
                        mmm = "August"
                    Case 11
                        mmm = "September"
                    Case 12
                        mmm = "October"
                   
                    Case 3
                        mmm = "January"


                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    Case 1
                        mmm = "November"
                    Case 2
                        mmm = "December"
                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If
        If ComboBox3.Text = "8 to 9 Months" Then

            If m > 3 Then
                Select Case m
                    Case 4
                        mmm = "January"
                    Case 5
                        mmm = "fEBRUARY"
                    Case 6
                        mmm = "march"

                    Case 7
                        mmm = "April"
                    Case 8
                        mmm = "May"
                    Case 9
                        mmm = "June"
                    Case 10
                        mmm = "July"
                    Case 11
                        mmm = "August"

                   

                   

                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    
                    Case 1
                        mmm = "October"
                    Case 2
                        mmm = "November"
                    Case 3
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If
        If ComboBox3.Text = "7 to 8 Months" Then

            If m > 4 Then
                Select Case m
                    Case 5
                        mmm = "January"
                    
                    Case 6
                        mmm = "February"

                    Case 7
                        mmm = "March"
                    Case 8
                        mmm = "April"
                    Case 9
                        mmm = "May"
                    Case 10
                        mmm = "June"
                    Case 11
                        mmm = "July"
                    Case 12
                        mmm = "August"
                    




                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                   
                    Case 1
                        mmm = "September"
                    Case 2
                        mmm = "October"
                    Case 3
                        mmm = "November"
                    Case 4
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If
        If ComboBox3.Text = "6 to 7 Months" Then

            If m > 5 Then
                Select Case m
                    Case 6
                        mmm = "January"

                    Case 7
                        mmm = "February"

                    Case 8
                        mmm = "March"
                    Case 9
                        mmm = "April"
                    Case 10
                        mmm = "May"
                    Case 11
                        mmm = "June"
                    Case 12
                        mmm = "July"
                   




                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    Case 1
                        mmm = "August"


                    Case 2
                        mmm = "September"
                    Case 3
                        mmm = "October"
                    Case 4
                        mmm = "November"
                    Case 5
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If

        If ComboBox3.Text = "5 to 6 Months" Then

            If m > 6 Then
                Select Case m
                    Case 7
                        mmm = "January"

                    Case 8
                        mmm = "February"

                    Case 9
                        mmm = "March"
                    Case 10
                        mmm = "April"
                    Case 11
                        mmm = "May"
                    Case 12
                        mmm = "June"
                    





                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    Case 1
                        mmm = "July"
                    Case 2
                        mmm = "August"


                    Case 3
                        mmm = "September"
                    Case 4
                        mmm = "October"
                    Case 5
                        mmm = "November"
                    Case 6
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If

        If ComboBox3.Text = "4 to 5 Months" Then

            If m > 7 Then
                Select Case m
                    Case 8
                        mmm = "January"

                    Case 9
                        mmm = "February"

                    Case 10
                        mmm = "March"
                    Case 11
                        mmm = "April"
                    Case 12
                        mmm = "May"






                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    Case 1
                        mmm = "June"

                    Case 2
                        mmm = "July"
                    Case 3
                        mmm = "August"

                    Case 4
                        mmm = "September"
                    Case 5
                        mmm = "October"
                    Case 6
                        mmm = "November"
                    Case 7
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If


        If ComboBox3.Text = "3 to 4 Months" Then

            If m > 8 Then
                Select Case m
                    Case 9
                        mmm = "January"

                    Case 10
                        mmm = "February"

                    Case 11
                        mmm = "March"
                    Case 12
                        mmm = "April"
                    





                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    Case 1
                        mmm = "May"

                    Case 2
                        mmm = "June"

                    Case 3
                        mmm = "July"
                    Case 4
                        mmm = "August"

                    Case 5
                        mmm = "September"
                    Case 6
                        mmm = "October"
                    Case 7
                        mmm = "November"
                    Case 8
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If

        If ComboBox3.Text = "2 to 3 Months" Then

            If m > 9 Then
                Select Case m
                    Case 10
                        mmm = "January"

                    Case 11
                        mmm = "February"

                    Case 12
                        mmm = "March"
                   





                End Select
                x = "" & Trim(d) & " " & Trim(mmm) & " " & Trim(y + 1) & ""

                DateTimePicker1.Text = x

            Else
                Select Case m
                    Case 1
                        mmm = "April"

                    Case 2
                        mmm = "May"

                    Case 3
                        mmm = "June"

                    Case 4
                        mmm = "July"
                    Case 5
                        mmm = "August"

                    Case 6
                        mmm = "September"
                    Case 7
                        mmm = "October"
                    Case 8
                        mmm = "November"
                    Case 9
                        mmm = "December"



                End Select
                x = "" & Trim(d) & "" & Trim((mmm)) & "" & Trim(y) & ""

                DateTimePicker1.Text = x
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cd As New OleDbCommand
        Dim lstrw As OleDbDataReader
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        cd.CommandText = "Select * from PlantationHq where PlotNo='" & Trim(ComboBox1.Text) & "'"
        lstrw = cd.ExecuteReader
        While lstrw.Read
            TextBox1.Text = lstrw("PlotName")
            TextBox2.Text = lstrw("size_in_hectares")
            TextBox3.Text = lstrw("Grade")
            mgr = lstrw("Manager")


        End While
        GroupBox3.Enabled = False

    End Sub
    Private Sub fillpref()
        Dim cm As New OleDbCommand
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT crop  FROM landgrade where  Grade='" & Trim(TextBox3.Text) & "'"
        Dim datad As New OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "landgrade")
        With ComboBox2
            .DataSource = dset.Tables("landgrade")
            .DisplayMember = "crop"
            .ValueMember = "crop"
            '.SelectedIndex = 0
        End With
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text <> "" Then
            Call fillpref()
            TextBox4.Text = mgr
            GroupBox3.Enabled = True

            ComboBox2.Focus()
        Else
            MsgBox("Apparently there is an error with your entry, Request has thus been rejected", MsgBoxStyle.Exclamation)
            ComboBox1.Focus()

        End If
    End Sub
   
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        '11 to 12 Months
        '10 to 11 Months
        '9 to 10 Months
        '8 to 9 Months
        '7 to 8 Months
        '6 to 7 Months
        '5 to 6 Months
        '4 to 5 Months
        '3 to 4 Months
        '2 to 3 Months
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        MsgBox("Make sure that the crop duration you selected is correct", MsgBoxStyle.Information)
        GroupBox4.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cm As New OleDbCommand
        Call connect()
        cnn.Open()
        Try

       
            cm.Connection = cnn
            cm.CommandText = " INSERT INTO LandUse(PlantationID, PlotNo, PlotName, Land_Size, Crop, Duration, Planted_On, Due, Land_Manager, Registered_By)VALUES('" & Trim(tempid) & "','" & Trim(ComboBox1.Text) & "','" & Trim(TextBox1.Text) & "','" & Trim(TextBox2.Text) & "','" & Trim(ComboBox2.Text) & "','" & Trim(ComboBox3.Text) & "','" & Trim(Today.ToShortDateString) & "','" & Trim(DateTimePicker1.Value) & "','" & Trim(TextBox4.Text) & "','" & Trim(logged) & "')"
            cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            cm.Connection = cnn
            cm.CommandText = "Update Plantationhq set Vacant=0 where plotNo='" & Trim(ComboBox1.Text) & "'"
            cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("Planting Process Has been Recorded Successfuly,The Plots Involved are Now Locked and can be only unlocked through harvest,or Premature land release", MsgBoxStyle.Information)
        Plantation.ToolStripButton2.PerformClick()
    End Sub
    Private Sub nextid()
        Dim pattID As Integer

        Dim Temp1 As Integer
        Temp1 = Val(Temp1) + 1

        Try
genesis:
            pattID = Temp1
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 plantationid From landuse Where PlantationID='" & pattID & "' ORDER BY plantationID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                tempid = pattID
            Else
                Temp1 += 1
                GoTo genesis

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub
    Private Sub fillmat()
        Dim cm As New OleDbCommand
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = " select plotno from landuse where  countdown >-20 and countdown <20"
        Dim datad As New OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "landuse")
        With ComboBox4
            .DataSource = dset.Tables("Landuse")
            .DisplayMember = "plotno"
            .ValueMember = "plotno"
            '
        End With

    End Sub
    Private Sub confirm()
        Dim cn As New OleDbCommand
        Call connect()
        cnn.Open()
        cn.Connection = cnn

        cn.CommandText = "Select vacant from plantationhq where plotno='" & Trim(ComboBox4.Text) & "'"
        Dim c As String = cn.ExecuteScalar
        If c = 0 Then

        Else
            MsgBox("The land has already been harvested. It will remove itself 20 days after the Preset day of harvest", MsgBoxStyle.Exclamation)
            Plantation.ToolStripButton2.PerformClick()
        End If


    End Sub
    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter



    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim cd As New OleDbCommand
        Dim lstrw As OleDbDataReader
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        cd.CommandText = "Select * from landuse where PlotNo='" & Trim(ComboBox4.Text) & "'"
        lstrw = cd.ExecuteReader
        While lstrw.Read
            TextBox7.Text = lstrw("PlotName")
            TextBox6.Text = lstrw("land_size")
            TextBox5.Text = lstrw("crop")
            mgr = lstrw("Land_Manager")
            plt0n = lstrw("Planted_on")


        End While
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Call confirm()
        If TextBox5.Text <> "" Then
            Call fillpref()
            TextBox8.Text = mgr
            GroupBox6.Enabled = True

            TextBox10.Focus()
        Else
            MsgBox("An error has been detected in your entry, your Request has  been rejected", MsgBoxStyle.Exclamation)
            ComboBox4.Focus()

        End If
        ComboBox5.SelectedIndex = 0
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then


            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TextBox8.Text <> "" Then
            MsgBox("Ensure that the units you have used is correct", MsgBoxStyle.Information)

            GroupBox8.Enabled = True
        Else

        End If
    End Sub
    Private Sub havid()
        Dim pattID As Integer

        Dim Temp2 As Integer
        Temp2 = Val(Temp2) + 1

        Try
genesis:
            pattID = Temp2
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 Harvid From landyieldHQ Where HarvID='" & pattID & "' ORDER BY harvID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                tempharvid = pattID
            Else
                Temp2 += 1
                GoTo genesis

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub pltid()
        Dim pattID As Integer

        Dim Temp2 As Integer
        Temp2 = Val(Temp2) + 1

        Try
genesis:
            pattID = Temp2
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 id From plttable Where ID='" & pattID & "' ORDER BY ID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                tempplt = pattID
            Else
                Temp2 += 1
                GoTo genesis

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Call FILLY()
        Else
            If TabControl1.SelectedIndex = 2 Then
                Call filky()
            Else

                Call PLOTS()
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If ComboBox4.Text <> "" And TextBox10.Text <> "" Then


            Dim cm As New OleDbCommand
            Call connect()
            cnn.Open()
            Try


                cm.Connection = cnn
                cm.CommandText = " INSERT INTO Landyieldhq(Harvid,plotid,crop,Planted_on,Harvested_on,Yield,Units,flag)VALUES('" & Trim(tempharvid) & "','" & Trim(ComboBox4.Text) & "','" & Trim(TextBox5.Text) & "','" & Trim(plt0n) & "','" & Trim(Today.ToShortDateString) & "','" & Trim(TextBox10.Text) & "','" & Trim(ComboBox5.Text) & "',1)"
                cm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If RadioButton2.Checked = True Then
                Try
                    cm.Connection = cnn
                    cm.CommandText = "Update Plantationhq set Vacant=1 where plotNo='" & Trim(ComboBox4.Text) & "'"
                    cm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                MsgBox("Harvest Registration Process completed Successfuly, The Land is Now Free for Usage", MsgBoxStyle.Information)
                Plantation.ToolStripButton2.PerformClick()

            Else
                If RadioButton2.Checked = True Then
                    Try
                        cm.Connection = cnn
                        cm.CommandText = "Update landuse set due=getdate() where plotNo='" & Trim(ComboBox4.Text) & "'"
                        cm.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    MsgBox("Harvest Registration Process completed Successfuly, The crop on the Land is still Harvestable", MsgBoxStyle.Information)
                    Plantation.ToolStripButton2.PerformClick()
                End If
            End If
        Else
            MsgBox("there is something missing in your entries")
        End If
        Plantation.ToolStripButton2.PerformClick()

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        GroupBox7.Enabled = True


    End Sub

    Private Sub GroupBox11_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox11.Enter



    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        ComboBox7.SelectedIndex = 0
        Dim cd As New OleDbCommand
        Dim lstrw As OleDbDataReader
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        cd.CommandText = "Select * from landuse where PlotNo='" & Trim(ComboBox6.Text) & "'"
        lstrw = cd.ExecuteReader
        While lstrw.Read
            
            TextBox9.Text = lstrw("crop")
            TextBox12.Text = lstrw("Plantationid")
           


        End While

    End Sub

    Private Sub GroupBox11_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox11.MouseClick
        GroupBox12.Enabled = False
    End Sub

    Private Sub GroupBox12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox12.Enter

    End Sub

    Private Sub GroupBox12_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox12.MouseClick
        GroupBox11.Enabled = False
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MsgBox("Please select a Radiobutton from the pair provided", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If RadioButton3.Checked = True Then
            GroupBox11.Enabled = True
            Dim cm As New OleDbCommand
            Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

            Dim strg As String = "SELECT plotno  FROM plantationhq where  vacant='0'"
            Dim datad As New OleDbDataAdapter(strg, con)
            Dim dset As New DataSet
            datad.Fill(dset, "PLANTATIONhq")
            With ComboBox6
                .DataSource = dset.Tables("plantationhq")
                .DisplayMember = "plotno"
                .ValueMember = "plotno"
                '
            End With
            ComboBox6.Focus()

        Else
            GroupBox12.Enabled = True
            TextBox11.Focus()
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        nina = 2
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        nina = 1
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If ComboBox6.Text <> "" And ComboBox7.Text <> "" And TextBox9.Text <> "" Then
            GroupBox14.Enabled = True
        Else
            MsgBox("Not all entries have been entered", MsgBoxStyle.Exclamation)
            Exit Sub

        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If TextBox11.Text <> "" And ComboBox8.Text <> "" Then
            GroupBox14.Enabled = True
        Else
            MsgBox("Not all entries have been entered", MsgBoxStyle.Exclamation)
            Exit Sub

        End If
        TextBox11.Text = TextBox11.Text.ToUpper

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Call pltid()
        Dim cm As New OleDbCommand
        Call connect()
        cnn.Open()
        cm.Connection = cnn
        Dim x As String
        x = ComboBox8.Text


        '  MsgBox(x)
        Select Case nina
            Case 1
                Try
                    cm.CommandText = "Delete from Landuse where Plantationid='" & Trim(TextBox12.Text) & "'"
                    cm.ExecuteNonQuery()
                    cm.CommandText = "Update Plantationhq set Vacant=1 where PlotNo='" & Trim(ComboBox6.Text) & "'"
                    cm.ExecuteNonQuery()

                    cm.CommandText = "insert into PlTtable(ID,PlotNo,PlantationNo,Crop,Reason)Values('" & Trim(tempplt) & "','" & Trim(ComboBox6.Text) & "','" & Trim(TextBox12.Text) & "','" & Trim(TextBox9.Text) & "','" & Trim(ComboBox7.Text) & "')"
                    cm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Case 2
                Try
                    cm.CommandText = "Insert into Landgrade(Grade,Crop,CROP_TYPE) Values('" & Trim(ComboBox8.Text) & "','" & Trim(TextBox11.Text) & "','" & Trim(ComboBox9.Text) & "')"
                    cm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
        End Select
        MsgBox("Task performed successfuly", MsgBoxStyle.Information)

        Plantation.ToolStripButton2.PerformClick()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        Dim c As String = ComboBox8.Text
        ' Else
        'If ComboBox8.Text = "B" Then

        'Else
        '    If ComboBox8.Text = "C" Then


        '    Else
        '        If ComboBox8.Text = "D" Then

        '        Else
        '            If ComboBox8.Text = "E" Then

        '            End If

        '        End If
        '    End If
        'End If
        'End If

        Select Case c
            Case "A"

                TextBox13.Text = "Black Loam, Heavy Rainfall,Well Drained Terrain"

            Case "B"
                TextBox13.Text = "Undulating Land, Seasonal Rainfall, Red Loam"
            Case "C"
                TextBox13.Text = "Black Cotton Loam,Heavy Rainfall,Well Drained"
            Case "D"
                TextBox8.Text = "Black Loam, Seasonal Rainfall,Rocky Terrain"
            Case "E"

                TextBox8.Text = "Black Clay,Periodic Rainfall,Swampy Terrain"
        End Select
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub PLOTS()


        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * FROM pLANtationhq "
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView1.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
    Private Sub filky()

        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * FROM pLttable "
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView1.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub harv()

        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * FROM landuse "
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView2.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub FILLY()

        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * FROM landYIELDHQ "
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView1.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        If Char.IsSymbol(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        ComboBox9.SelectedIndex = 0
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Plantation.ToolStripButton2.PerformClick()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Plantation.ToolStripButton2.PerformClick()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Plantation.ToolStripButton2.PerformClick()
    End Sub
End Class
