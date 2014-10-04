Imports System.Data.OleDb

Public Class pltsales
    Dim s, t, vale, vine, R As String
        
    Dim temp1 As Integer
   
    

    Private Sub pltsales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Call crop()
        Call nextid()
        ComboBox2.SelectedIndex = 0
        Call fillgrids()
    End Sub
    Private Sub fillgrids()
        Call filla()
        Call fillb()
    End Sub
    Private Sub filla()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "SELECT [HarvID], [PlotID], [Crop], [Planted_On], [Harvested_on], [Yield], [Units] FROM [farmaster].[dbo].[LandyieldHQ] where flag=1"
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
    Private Sub fillb()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from Cropsales"
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
    Private Sub nextid()
        Dim pattID, tempid As Integer


        temp1 = Val(temp1) + 1

        Try
genesis:
            pattID = temp1
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 id From cropsales Where ID='" & pattID & "' ORDER BY ID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                tempid = pattID
            Else
                temp1 += 1
                GoTo genesis

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Dim a, b, c As String

        a = DateTime.Now.Day.ToString

        b = DateTime.Now.Month.ToString

        c = DateTime.Now.Year.ToString

        TextBox1.Text = "CTN" & tempid & "" & Trim(a) & "" & Trim(b) & "" & Trim(c) & ""
        'TextBox6.Text = "EXCTN" & tempid & "" & Trim(a) & "" & Trim(b) & "" & Trim(c) & ""
    End Sub


    Private Sub fillnew()
        Dim cd As New OleDbCommand
        Dim vale, vine As Integer
        Dim ext As String
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        Try
            cd.CommandText = "select sum (Yield) from landyieldhq  where crop='" & Trim(ComboBox1.Text) & "' and flag=1"
            vale = cd.ExecuteScalar
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Try
            cd.CommandText = "Update Landyieldhq set flag=0 Where Crop='" & Trim(ComboBox1.Text) & "'"
            cd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        'MsgBox(vale)
        Try
            Try
                cd.CommandText = "select crop from farmsubs where crop='" & Trim(ComboBox1.Text) & "'"
                ext = cd.ExecuteScalar
                If ext = vbNullString Then
                    GoTo newcrop
                Else
                    GoTo updatecrop

                End If
            Catch ex As Exception

            End Try
newcrop:
            cd.CommandText = "INSERT INTO farmaster.dbo.FarmSubs(Crop, Ammount, As_Of) values('" & Trim(ComboBox1.Text) & "','" & Trim(vale) & "','" & Trim(DateTime.Now.Date.ToString) & "')"
            cd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Exit Sub

updatecrop:
        Try
            cd.CommandText = "Select Ammount from farmsubs where crop='" & Trim(ComboBox1.Text) & "' "
            vine = cd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        vale = vine + vale

        Try
            cd.CommandText = "Update Farmsubs set Ammount='" & Trim(vale) & "' where crop='" & Trim(ComboBox1.Text) & "'"
        Catch ex As Exception

        End Try
        Label5.Text = vale

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Call fillnew()
        TabControl1.Enabled = True
        Call fillcust()

        


    End Sub
    Private Sub fillcust()


        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        'Dim strol As String = "Select Animal_Name From AnimalHQ Where Sex Like '%FEMALE%' and (Datediff(yy,DOB,getDate())>2) and "
        Dim strol As String = "Select  customerid from Plantationorder where crop='" & Trim(ComboBox1.Text) & "' and datediff(dd,getdate(),period_ending)>0 "
        Dim da As New OleDbDataAdapter(strol, con)
        Dim ds As New DataSet
        da.Fill(ds, "Plantationorder")
        With ComboBox3
            .DataSource = ds.Tables("plantationorder")
            .DisplayMember = "customerid"
            .ValueMember = "customerid"
            '.SelectedIndex = 0
        End With
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim X As String = ComboBox2.Text

        If X = "PERISHABLE" Then
            Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
            'Dim strol As String = "Select Animal_Name From AnimalHQ Where Sex Like '%FEMALE%' and (Datediff(yy,DOB,getDate())>2) and "
            Dim strol As String = "Select distinct crop from landyieldhq WHERE  datediff(dd,harvested_on,Getdate())<30  and crop in (select crop from landgrade where crop_type='Perishable')"
            Dim da As New OleDbDataAdapter(strol, con)
            Dim ds As New DataSet
            da.Fill(ds, "landyieldhq")
            With ComboBox1

                .DataSource = ds.Tables("landyieldhq")
                .DisplayMember = "crop"
                .ValueMember = "crop"
                '.SelectedIndex = 0
            End With
        Else
            Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
            'Dim strol As String = "Select Animal_Name From AnimalHQ Where Sex Like '%FEMALE%' and (Datediff(yy,DOB,getDate())>2) and "
            Dim strol As String = "Select distinct crop from landyieldhq WHERE  datediff(dd,harvested_on,Getdate())<365  and crop in (select crop from landgrade where crop_type='Non Perishable') "
            Dim da As New OleDbDataAdapter(strol, con)
            Dim ds As New DataSet
            da.Fill(ds, "landyieldhq")
            With ComboBox1

                .DataSource = ds.Tables("landyieldhq")
                .DisplayMember = "crop"
                .ValueMember = "crop"
                '.SelectedIndex = 0
            End With
        End If
        ComboBox1.Enabled = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        ' Call fillcrop()
    End Sub
    Private Sub SIMBE()

        R = Val(Label5.Text) - Val(TextBox3.Text)
        If R < 1 Then


            R = 1
        Else
            R = 2
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If vale = 0 Then
            MsgBox("There is insufficient stock. Quiting...", MsgBoxStyle.Exclamation)
        Else
            s = Label5.Text

            Call SIMBE()
            Dim aksum As String = TextBox3.Text


            Dim cloe As New OleDbCommand
            MsgBox(R)
            Select Case R
                Case 1
                    Try
                        TextBox3.Text = s
                        Call connect()
                        cnn.Open()
                        cloe.Connection = cnn
                        cloe.CommandText = "insert into cropsales( TransactionID, crop,CustomerID, Tonne_Sold) values('" & Trim(TextBox1.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(ComboBox3.Text) & "','" & Trim(TextBox3.Text) & "')"
                        cloe.ExecuteNonQuery()
                        MsgBox("Sales Done sucessfuly")
                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                    MsgBox(TextBox3.Text)
                    MsgBox(1)
irenne:
                    'TextBox3.Text = s
                Case 2
                    Try
                        MsgBox(2)
                        Call connect()
                        cnn.Open()
                        cloe.Connection = cnn
                        cloe.CommandText = "insert into cropsales( TransactionID, crop,CustomerID, Tonne_Sold) values('" & Trim(TextBox1.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(ComboBox3.Text) & "','" & Trim(TextBox3.Text) & "')"
                        cloe.ExecuteNonQuery()
                        MsgBox("Sales Done sucessfuly")
                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
            End Select
            MsgBox(TextBox3.Text)

final:
            s = Val(s) - Val(TextBox3.Text)
            Call der()
        End If
    End Sub
    Private Sub der()
        Try
            Dim cloe As New OleDbCommand

            Call connect()
            cnn.Open()
            cloe.Connection = cnn
            cloe.CommandText = "Update farmsubs set ammount='" & Trim(s.ToCharArray) & "' where crop='" & Trim(ComboBox1.Text) & "'"
            cloe.ExecuteNonQuery()
            'MsgBox("Sales Done sucessfuly")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Accounts.ToolStripButton2.PerformClick()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim cd As New OleDbCommand
        Dim lstrw As OleDbDataReader


        Call connect()
        cnn.Open()
        cd.Connection = cnn
        cd.CommandText = "Select * from plantationorder where customerid='" & Trim(ComboBox3.Text) & "'"
        lstrw = cd.ExecuteReader
        Label5.Controls.Clear()
        While lstrw.Read
            TextBox3.Text = lstrw("Demand_(Tonnes)")
        End While



    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Dim A As String
            A = "EX" & Trim(TextBox1.Text) & ""
            TextBox1.Text = A
            NumericUpDown1.Maximum = Val(Label5.Text)
        Else
            Call nextid()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If NumericUpDown1.Value > 0 Or TextBox4.Text <> "" Then
            If vale = 0 Then
                MsgBox("There is insufficient stock. Quiting...", MsgBoxStyle.Exclamation)
            Else

                Dim cLR As New OleDbCommand
                TextBox4.Text = "SOLD TO " & Trim(TextBox4.Text) & ""
                Try

                    Call connect()
                    cnn.Open()
                    cLR.Connection = cnn
                    cLR.CommandText = "insert into cropsales( TransactionID, crop,CustomerID, Tonne_Sold) values('" & Trim(TextBox1.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(TextBox4.Text) & "','" & Trim(NumericUpDown1.Value) & "')"
                    cLR.ExecuteNonQuery()
                    MsgBox("Sales Done sucessfuly")
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

                s = Val(Label5.Text) - NumericUpDown1.Value
                Call der()

            End If
        Else
            MsgBox("One or more of the required Input(s) is missing", MsgBoxStyle.Exclamation)

        End If
        Accounts.ToolStripButton2.PerformClick()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        NumericUpDown1.ReadOnly = False
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Accounts.ToolStripButton2.PerformClick()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Accounts.ToolStripButton2.PerformClick()
    End Sub
End Class
