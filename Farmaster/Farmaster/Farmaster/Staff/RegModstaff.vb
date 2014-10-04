Public Class RegModstaff
    Dim pattID, Prodid, ds As String

    Dim x As String
    Dim y As String
    Private Sub RegModstaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call sanaa()
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub
    'ID, TagID, First_Name, Last_Name, National_ID, DOE, POE, DEPARTMENT, SUB_DEPARTMENT, USERNAME, PASSCODE, STATUS

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress

        If Char.IsNumber(e.KeyChar) Then


        End If
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Click

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        TextBox7.ReadOnly = False
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then Call fillid()
    End Sub
    Private Sub filldept()
        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT DISTINCT Dept from DEPART"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "DEPART")
        With ComboBox1
            .DataSource = dset.Tables("DEPART")
            .DisplayMember = "dept"
            .ValueMember = "dept"
            '
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox4.SelectAll()
        If TextBox4.SelectionLength < 8 Then
            MsgBox("The Id Number is shorter than expected", MsgBoxStyle.Exclamation)
            Exit Sub

        End If
        If TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
            Call filldept()

            GroupBox3.Enabled = True
            GroupBox2.Enabled = False

        Else
            MsgBox("There is something that is still not rigth with your entries", MsgBoxStyle.Exclamation)

        End If


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call fillid()
    End Sub
    Private Sub fillid()
        Dim Temp1 As Integer
        Dim a, b, c, k As String
        ' MsgBox(x)
        Select Case x
            Case "ANIDEPT"
                ds = "AH"
            Case "PLTDEPT"
                ds = "PT"
            Case "ACCDEPT"
                ds = "AC"
            Case "STODEPT"
                ds = "ST"
            Case "SA"
                ds = "SA"
            Case "HRMDEPT"
                ds = "HR"
            Case "MANAGEMENT"
                ds = "MN"
        End Select
        ' MsgBox(ds)

        With DateTime.Now
            a = .Day.ToString
            b = .Month.ToString
            c = .Year.ToString

        End With
        k = a + b + c

        Temp1 = Val(Temp1) + 1
        Prodid = "EN"
        Try
start:
            pattID = Prodid & Temp1 & k & ds
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 SYSID From PrivStaffHQ Where SYSID='" & pattID.ToCharArray & "' ORDER BY sysid DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                TextBox1.Text = pattID
            Else
                Temp1 += 1
                GoTo start

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        'End Select
        ' Call fillid()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        'Dim conn As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=NFMIS;User ID=sa;Password=swiftshady")

        Dim strSQL As String = "SELECT  SUB from DEPART where DEPT Like '" & "%" & ComboBox1.Text & "%'"
        Dim dat As New OleDb.OleDbDataAdapter(strSQL, con)
        Dim ds As New DataSet
        dat.Fill(ds, "DEPART")
        With ComboBox2
            .DataSource = ds.Tables("DEPART")
            .DisplayMember = "SUB"
            .ValueMember = "SUB"
            '.SelectedIndex = 0
        End With
        x = ComboBox1.Text

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then

            GroupBox4.Enabled = True
            GroupBox3.Enabled = False
        Else
            MsgBox("Invalid or Null entry detected. Rectify this", MsgBoxStyle.Exclamation)

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim t, u, d As String
        t = TextBox6.Text
        u = TextBox7.Text
        d = (String.Compare(t, u))
        If TextBox5.Text <> "" And TextBox6.Text <> "" Then
            If d = 0 Then
                Dim cd As New OleDb.OleDbCommand
                Call connect()
                cnn.Open()
                cd.Connection = cnn
                Try
                    cd.CommandText = "Select Username from privstaffhq where username='" & Trim(TextBox5.Text) & "'"
                    t = cd.ExecuteScalar
                    If t = vbNullString Then
                        Button4.Enabled = 1
                        GroupBox4.Enabled = 0
                    Else
                        MsgBox("The Username you Picked is already taken, Please try another username or modify the current", MsgBoxStyle.Exclamation)
                        TextBox5.Focus()
                        Exit Sub

                    End If
                Catch ex As Exception

                End Try

            Else
                MsgBox("Password missmatch", MsgBoxStyle.Critical)
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox7.ReadOnly = True

                TextBox6.Focus()
            End If
        Else
            MsgBox("Username cannot be null", MsgBoxStyle.Critical)
            TextBox5.Focus()

        End If

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim leahk As New OleDb.OleDbCommand
        Call connect()
        cnn.Open()

        leahk.Connection = cnn
        Try
            leahk.CommandText = "insert into privstaffhq(SysID, First_Name, Last_Name, National_ID, DOE,  DEPARTMENT, SUB_DEPARTMENT, USERNAME, PASSCODE, STATUS ) values('" & Trim(TextBox1.Text) & "','" & Trim(TextBox2.Text) & "','" & Trim(TextBox3.Text) & "','" & Trim(TextBox4.Text) & "','" & Trim(DateTimePicker1.Value) & "','" & Trim(ComboBox1.Text) & "','" & Trim(ComboBox2.Text) & "','" & Trim(TextBox5.Text) & "','" & Trim(TextBox7.Text) & "','ON DUTY')"
            leahk.ExecuteNonQuery()
            MsgBox("Staff named '" & TextBox5.Text & "' can now log in to the Farmaster system", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Call sanaa()
    End Sub
    Private Sub sanaa()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "SELECT [ID], [SysID], [First_Name], [Last_Name], [National_ID], [DOE], [POE], [DEPARTMENT], [SUB_DEPARTMENT], [USERNAME],STATUS from PrivStaffHQ "
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView1.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Char.IsNumber(e.KeyChar) Then


        End If
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If TextBox8.Text <> "" And TextBox9.Text <> "" And TextBox10.Text <> "" Then
            Dim sam As String
            Dim aloo As New OleDb.OleDbCommand
            Call connect()
            cnn.Open()
            aloo.Connection = cnn
            Try
                aloo.CommandText = "Select * from Privstaffhq where First_name='" & Trim(TextBox8.Text) & "' and Last_name='" & Trim(TextBox9.Text) & "' and National_ID='" & Trim(TextBox10.Text) & "'"
                sam = aloo.ExecuteScalar
                If sam = vbNullString Then
                    MsgBox("No such user Exists", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    Try
                        aloo.CommandText = "Update Privstaffhq set Passcode='1234' where National_ID='" & Trim(TextBox10.Text) & "'"
                        aloo.ExecuteNonQuery()
                        MsgBox("Password Reset!.current password is 1234 change it in your next loggon", MsgBoxStyle.Information)

                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            MsgBox("Fill all entries Before Performing Recovery", MsgBoxStyle.Exclamation)
            Exit Sub

        End If
        Staff.ToolStripButton2.PerformClick()


    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        Call filld1()
    End Sub
    Private Sub filld1()


        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT DISTINCT Dept from DEPART"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "DEPART")
        With ComboBox4
            .DataSource = dset.Tables("DEPART")
            .DisplayMember = "dept"
            .ValueMember = "dept"
            '
        End With
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim con As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        'Dim conn As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=NFMIS;User ID=sa;Password=swiftshady")

        Dim strSQL As String = "SELECT  SUB from DEPART where DEPT Like '" & "%" & ComboBox4.Text & "%'"
        Dim dat As New OleDb.OleDbDataAdapter(strSQL, con)
        Dim ds As New DataSet
        dat.Fill(ds, "DEPART")
        With ComboBox3
            .DataSource = ds.Tables("DEPART")
            .DisplayMember = "SUB"
            .ValueMember = "SUB"
            '.SelectedIndex = 0
        End With


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TextBox13.Text <> "" Then
            Dim sam As String
            Dim aloo As New OleDb.OleDbCommand
            Call connect()
            cnn.Open()
            aloo.Connection = cnn
            Try
                aloo.CommandText = "Select * from Privstaffhq where Username='" & Trim(TextBox13.Text) & "'"
                sam = aloo.ExecuteScalar
                If sam = vbNullString Then
                    MsgBox("No such user Exists", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    Try
                        aloo.CommandText = "Update Privstaffhq set department='" & Trim(ComboBox4.Text) & "' , SUB_department='" & Trim(ComboBox3.Text) & "' where username='" & Trim(TextBox13.Text) & "'"
                        aloo.ExecuteNonQuery()
                        MsgBox("User Transfered Successfuly", MsgBoxStyle.Information)

                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            MsgBox("Fill all entries Before Performing Transfer", MsgBoxStyle.Exclamation)
            Exit Sub

        End If
        Staff.ToolStripButton2.PerformClick()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If TextBox14.Text <> "" And TextBox12.Text <> "" And TextBox11.Text <> "" Then
            Dim sam As String
            Dim aloo As New OleDb.OleDbCommand
            Call connect()
            cnn.Open()
            aloo.Connection = cnn
            Try
                aloo.CommandText = "Select * from Privstaffhq where First_name='" & Trim(TextBox14.Text) & "' and Last_name='" & Trim(TextBox12.Text) & "' and username='" & Trim(TextBox11.Text) & "'"
                sam = aloo.ExecuteScalar
                If sam = vbNullString Then
                    MsgBox("No such user Exists", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    Try
                        aloo.CommandText = "Update Privstaffhq set Status='SUSPENDED' where UserName='" & Trim(TextBox11.Text) & "' and First_Name='" & Trim(TextBox14.Text) & "' and last_name='" & Trim(TextBox12.Text) & "'"
                        aloo.ExecuteNonQuery()
                        MsgBox("User Suspended", MsgBoxStyle.Information)

                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            MsgBox("Fill all entries Before Performing Task", MsgBoxStyle.Exclamation)
            Exit Sub

        End If
        Staff.ToolStripButton2.PerformClick()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Staff.ToolStripButton2.PerformClick()

    End Sub
End Class
