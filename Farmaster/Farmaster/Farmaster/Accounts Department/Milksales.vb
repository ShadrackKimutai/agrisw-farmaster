Imports System.Data.OleDb
Public Class Milksales
    Dim lock, getmilk As Integer
    Dim Temp1 As Integer
    Dim tod, kk, dd As String
    Dim rant As Integer


    Private Sub DeptRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tmilk()
        Call nextid()
        Call cust()
        Call fillgrid()
        Call fillgrid2()
        rant = 0

    End Sub
    Private Sub cust()
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        'Dim strol As String = "Select Animal_Name From AnimalHQ Where Sex Like '%FEMALE%' and (Datediff(yy,DOB,getDate())>2) and "
        Dim strol As String = "Select  customerid from milkorder WHERE STTPD>GETDATE()"
        Dim da As New OleDbDataAdapter(strol, con)
        Dim ds As New DataSet
        da.Fill(ds, "milkorder")
        With ComboBox1
            .DataSource = ds.Tables("milkorder")
            .DisplayMember = "customerid"
            .ValueMember = "customerid"
            '.SelectedIndex = 0
        End With
    End Sub
    Private Sub nextid()
        Dim pattID, tempid As Integer


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
            newpermcmd.CommandText = "Select top 1 id From farmastermilksales Where ID='" & pattID & "' ORDER BY ID DESC"
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

        Dim a, b, c As String

        a = DateTime.Now.Day.ToString

        b = DateTime.Now.Month.ToString

        c = DateTime.Now.Year.ToString

        TextBox1.Text = "TN" & tempid & "" & Trim(a) & "" & Trim(b) & "" & Trim(c) & ""
        TextBox2.Text = "EXTN" & tempid & "" & Trim(a) & "" & Trim(b) & "" & Trim(c) & ""

    End Sub
    

    Private Sub tmilk()

        Dim LEO As String = Date.Today.ToShortDateString



        kk = DateTime.Now.Hour.ToString
        If kk < 12 Then tod = "MOR" Else tod = "AFT"

        dd = tod + Today.ToShortDateString
        LEO = tod + LEO
        Call connect()
        cnn.Open()
        Dim lstrw As OleDb.OleDbDataReader
        Dim comd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT flag FROM flagpost WHERE leo='" & Trim(dd) & "'", cnn)
        lstrw = comd.ExecuteReader
        While lstrw.Read

            lock = lstrw("flag")




        End While
        'MsgBox(LEO)

        If lock <> 1 Then


            Dim commd As New OleDbCommand
            'Dim rw As OleDbDataReader
            Call connect()
            cnn.Open()

            commd.Connection = cnn
            commd.CommandText = "SELECT SUM(MILK) AS MILO FROM DAIRYMILK where milking_day='" & Today.ToShortDateString & "' AND time ='" & Trim(tod) & "'"
            If commd.ExecuteScalar.ToString = Nothing Then
                supplylabel.Text = 0
                Label9.Text = 0

            Else
                getmilk = commd.ExecuteScalar


                supplylabel.Text = getmilk
                Label9.Text = getmilk
                Dim k As Integer = 1


                Try
                    Dim c1 As New OleDbCommand
                    Call connect()
                    cnn.Open()
                    c1.Connection = cnn
                    c1.CommandText = "insert into flagpost(Leo,Flag) vALUES('" & Trim(LEO) & "',1) "
                    c1.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                'MsgBox(LEO)
                Try
                    Dim C2 As New OleDbCommand
                    Call connect()
                    cnn.Open()
                    C2.Connection = cnn
                    C2.CommandText = "insert into MilkEntrybook(litres,pushed_on,tod) values('" & Trim(getmilk) & "','" & Today.ToShortDateString & "','" & Trim(tod) & "')"
                    C2.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Else

            Call fillother()
        End If
    End Sub
    Private Sub fillother()
        Dim coe As New OleDbCommand
        'Dim rw As OleDbDataReader
        Call connect()
        cnn.Open()

        coe.Connection = cnn
        coe.CommandText = "SELECT Litres  FROM MilkEntrybook where Pushed_on='" & Today.ToShortDateString & "' and tod='" & Trim(tod) & "'"
        If coe.ExecuteScalar.ToString = vbNullString Then
            supplylabel.Text = 0

        Else
            getmilk = coe.ExecuteScalar


            supplylabel.Text = getmilk
            Label9.Text = supplylabel.Text
        End If
        Label9.Text = supplylabel.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        GroupBox3.Enabled = False
        Try


            Dim coe1 As New OleDbCommand
            'Dim rw As OleDbDataReader
            Call connect()
            cnn.Open()

            coe1.Connection = cnn
            coe1.CommandText = "SELECT DEMAND  FROM Milkorder where customerid='" & ComboBox1.Text & "' " '"
            TextBox3.Text = coe1.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Integer
        Dim uniq, dtr As String
        dtr = DateTime.Now.Day.ToString + DateTime.Now.Month.ToString + DateTime.Now.Year.ToString

        uniq = ComboBox1.Text + dtr
        Dim cloe As New OleDbCommand
        

        If Val(TextBox3.Text) > Val(supplylabel.Text) Then
            TextBox3.Text = supplylabel.Text

            MsgBox("the demand is more than the supply. will provide you with the rest of the remaining ammount as it appears on the supply notifier", MsgBoxStyle.Critical)


            Try

                Call connect()
                cnn.Open()
                cloe.Connection = cnn
                cloe.CommandText = "insert into farmastermilksales(id,trno,customerid,demand,serviced_by,uniq,dos) values('" & Trim(Temp1) & "','" & Trim(TextBox1.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(TextBox3.Text) & "','" & Trim(logged.ToUpper) & "','" & Trim(uniq) & "','" & Trim(Today.ToShortDateString) & "')"

                cloe.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("The Customer has already been served", MsgBoxStyle.Exclamation)

                Exit Sub
            End Try

            g = supplylabel.Text - TextBox3.Text


        Else

            Try



                Call connect()
                cnn.Open()
                cloe.Connection = cnn
                cloe.CommandText = "insert into farmastermilksales(id,trno,customerid,demand,serviced_by,uniq,DOS) values('" & Trim(Temp1) & "','" & Trim(TextBox1.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(TextBox3.Text) & "','" & Trim(logged.ToUpper) & "','" & Trim(uniq) & "','" & Trim(Today.ToShortDateString) & "')"

                cloe.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("The Customer has already been served", MsgBoxStyle.Exclamation)
                Exit Sub
            End Try

            g = supplylabel.Text - TextBox3.Text
        End If




        Try
            Dim C12 As New OleDbCommand
            Call connect()
            cnn.Open()
            C12.Connection = cnn
            C12.CommandText = "update MilkEntrybook set litres=" & g & " where Pushed_on='" & Today.ToShortDateString & "' and tod='" & Trim(tod) & "'"


            C12.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Accounts.ToolStripButton1.PerformClick()


    End Sub
    Private Sub externals()
        'Dim uniq, dtr As String
        'dtr = DateTime.Now.Day.ToString + DateTime.Now.Month.ToString + DateTime.Now.Year.ToString

        'uniq = ComboBox1.Text + dtr
        'Dim cloe As New OleDbCommand
        'Try

        '    Call connect()
        '    cnn.Open()
        '    cloe.Connection = cnn
        '    cloe.CommandText = "insert into farmastermilksales(id,trno,customerid,demand,serviced_by,uniq,dos) values('" & Trim(Temp1) & "','" & Trim(TextBox1.Text) & "','" & Trim(TextBox2.Text + " on" + Today.ToShortDateString) & "','" & Trim(ComboBox2.Text) & "','" & Trim(logged.ToUpper) & "','" & Trim(uniq) & "','" & Trim(Today.ToShortDateString) & "')"

        '    cloe.ExecuteNonQuery()
        'Catch ex As Exception
        '    MsgBox("The Customer has already been served", MsgBoxStyle.Exclamation)


        'End Try

        ''g = supplylabel.Text - TextBox3.Text

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub fillgrid()
        Dim cnn2 As New OleDb.OleDbConnection
        Dim adept As OleDb.OleDbDataAdapter
        Dim strng As String
        Dim dst2 As New DataSet
        Dim connectionstring1 As String
        connectionstring1 = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn2 = New OleDb.OleDbConnection(connectionstring1)
        strng = "Select TRNo,CUSTOMERID,demand as SUPPLIED, SERVICED_BY from farmastermilksales WHERE DOS='" & Trim(Today) & "'"

        Try
            cnn2.Open()
            adept = New OleDb.OleDbDataAdapter(strng, cnn2)
            adept.Fill(dst2)
            cnn2.Close()
            milksalesview.DataSource = dst2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub fillgrid2()
        Dim cnn2 As New OleDb.OleDbConnection
        Dim adept As OleDb.OleDbDataAdapter
        Dim strng As String
        Dim dst2 As New DataSet
        Dim connectionstring1 As String
        connectionstring1 = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn2 = New OleDb.OleDbConnection(connectionstring1)
        strng = "Select TRNo,CUSTOMERID,demand as SUPPLIED, SERVICED_BY from farmastermilksales"

        Try
            cnn2.Open()
            adept = New OleDb.OleDbDataAdapter(strng, cnn2)
            adept.Fill(dst2)
            cnn2.Close()
            totalmilksaleview.DataSource = dst2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ComboBox3.Enabled = True

        GroupBox1.Enabled = False
        GroupBox3.Enabled = False

    End Sub



    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GroupBox3.Enabled = True
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabIndexChanged
        If TabControl1.TabIndex = 0 Then

            Call tmilk()
            Call nextid()
            Call cust()
            Call fillgrid()
        Else

            Call tmilk()
            Call nextid()
            Label9.Text = supplylabel.Text
            Call fillgrid()

            TextBox2.Text = TextBox1.Text
        End If
    End Sub

    Private Sub TextBox2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim x As Integer = supplylabel.Text
        If x > 0 Then
            With ComboBox3

                Dim i As Integer = 1
                While i <= x
                    .Items.Add(i)
                    i += 1
                End While
                .SelectedIndex = 0
            End With
        Else
            With ComboBox3
                .Items.Add(0)

                .SelectedIndex = 0
            End With
        End If

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        GroupBox4.Enabled = False

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim s As String = TextBox4.Text
        TextBox4.Text = s.ToUpper


        GroupBox4.Enabled = True


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim g As Integer
        If TextBox4.Text <> "" Then

            Dim uniq, dtr As String
            dtr = DateTime.Now.Day.ToString + DateTime.Now.Month.ToString + DateTime.Now.Year.ToString

            uniq = TextBox4.Text + dtr
            Dim cloe As New OleDbCommand

            Dim temparat As String = "SOLD TO " + TextBox4.Text '+ " ON " + Today.ToShortDateString

            Try

                Call connect()
                cnn.Open()
                cloe.Connection = cnn
                cloe.CommandText = "insert into farmastermilksales(id,trno,customerid,demand,serviced_by,uniq,dos) values('" & Trim(Temp1) & "','" & Trim(TextBox2.Text) & "','" & Trim(temparat) & "','" & Trim(ComboBox3.Text) & "','" & Trim(logged.ToUpper) & "','" & Trim(uniq) & "','" & Trim(Today.ToShortDateString) & "')"

                cloe.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("The Customer has already been served", MsgBoxStyle.Exclamation)
                'MsgBox(ex.Message)
                Exit Sub
            End Try

            g = Label9.Text - ComboBox3.Text




            'Try



            '    Call connect()
            '    cnn.Open()
            '    cloe.Connection = cnn
            '    cloe.CommandText = "insert into farmastermilksales(id,trno,customerid,demand,serviced_by,uniq,DOS) values('" & Trim(Temp1) & "','" & Trim(TextBox1.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(TextBox3.Text) & "','" & Trim(logged.ToUpper) & "','" & Trim(uniq) & "','" & Trim(Today.ToShortDateString) & "')"

            '    cloe.ExecuteNonQuery()
            'Catch ex As Exception
            '    MsgBox("The Customer has already been served", MsgBoxStyle.Exclamation)

            'End Try

            'g = supplylabel.Text - TextBox3.Text

        Else
            MsgBox("Please enter the client's Name", MsgBoxStyle.Information)

            TextBox4.Focus()
            Exit Sub
        End If




        Try
            Dim C12 As New OleDbCommand
            Call connect()
            cnn.Open()
            C12.Connection = cnn
            C12.CommandText = "update MilkEntrybook set litres=" & g & " where Pushed_on='" & Today.ToShortDateString & "' and tod='" & Trim(tod) & "'"


            C12.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Accounts.ToolStripButton1.PerformClick()


    End Sub

    Private Sub totalmilksaleview_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles totalmilksaleview.CellContentClick

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub milksalesView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles milksalesView.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Accounts.ToolStripButton1.PerformClick()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Accounts.ToolStripButton1.PerformClick()
    End Sub
End Class
