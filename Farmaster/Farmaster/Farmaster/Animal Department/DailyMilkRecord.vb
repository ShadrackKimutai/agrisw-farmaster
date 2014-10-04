Imports System.Data.OleDb
Public Class DailyMilkRecord
    Dim r, l, anid As String
    Dim id As Integer
    Dim h As String = DateTime.Today.ToShortDateString

    Private Sub DailyMilkRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call fillcombo()
        Call nextid()
        Call fillmilkgrid()
    End Sub

    Private Sub tagid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tagid.SelectedIndexChanged
        'Dim str As String = Tagid.Text
        'Dim comd As New OleDbCommand
        'Call connect()
        'cnn.Open()
        'Dim lstrw As OleDbDataReader
        '' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
        'comd.Connection = cnn

        'comd.CommandText = ("SELECT animal_name,breed FROM AnimalHq WHERE TagID='" & str.ToCharArray & "'")
        'lstrw = comd.ExecuteReader


        'While lstrw.Read
        '    AnimalTextBox.Clear()
        '    AnimalTextBox.Text = lstrw("Animal_Name")
        '    BreedTextBox.Clear()
        '    BreedTextBox.Text = lstrw("Breed")


        'End While
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False




        Dim stw As String = Tagid.Text

        Call connect()
        cnn.Open()
        Dim lstrw As OleDbDataReader
        ' lstrw.IsClosed.ToString = False

        ' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
        Dim comd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM AnimalHq WHERE TagID='" & stw.ToCharArray & "'", cnn)
        lstrw = comd.ExecuteReader
        While lstrw.Read
            animalTextBox.Clear()
            r = lstrw("Animal_Name")
            breedTextBox.Clear()
            l = lstrw("Breed")
            anid = lstrw("id")
            animalTextBox.Text = r
            breedTextBox.Text = l

            'MsgBox(stw, r, l)

        End While

        ' cnn.Close()
        'Call calf()
        
    End Sub
    Private Sub calf()

        Call connect()
        cnn.Open()
        Dim clst As OleDbDataReader
        Dim c1 As OleDb.OleDbCommand = New OleDb.OleDbCommand("Select animal_name from animalhq where parent='" & r.ToCharArray & "' and age<800", cnn)
        clst = c1.ExecuteReader
        While clst.Read
            calftextbox.Clear()
            calftextbox.Text = clst("Animal_name")
        End While
    End Sub
    Private Sub fillcombo()
        Dim t, vo As String
        t = DateTime.Now.Hour.ToString
        If t < 12 Then vo = "MOR" Else vo = "AFT"

        vo = vo + h
        ' SELECT     Animal_Name FROM   AnimalHQ WHERE     (Sex = 'female') AND (Animal_Name IN  (SELECT     parent   FROM    animalhq   WHERE      AGE < 800))
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        ' Dim strg As String = "SELECt tagid FROM   AnimalHQ WHERE (Sex = 'female') AND CURRENT_CONDITION='HEALTHY' AND (Animal_Name IN  (SELECT     parent   FROM    animalhq   WHERE AGE < 800))and "
        Dim strg As String = "SELECt tagid FROM   AnimalHQ WHERE (Sex = 'female') AND CURRENT_CONDITION='HEALTHY' AND (Animal_Name IN  (SELECT     parent   FROM    animalhq   WHERE AGE < 800)) and  (NOT (TagID IN  (SELECT     tagid  FROM          dairylist   WHERE      DIFF = '" & Trim(vo) & "')))"
        Dim datad As New OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "animalhq")
        With Tagid
            .DataSource = dset.Tables("animalhq")
            .DisplayMember = "tagid"
            .ValueMember = "tagid"
            '.SelectedIndex = 0
        End With
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        


    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If animalTextBox.Text <> "" Then


            Call calf()
            Dim t As Integer
            Dim k, v, d, m, y As String

            d = DateTime.Now.Hour.ToString
            v = DateTime.Now.Day.ToString
            m = DateTime.Now.Month.ToString
            y = DateTime.Now.Year.ToString
            ' TextBox1.Text = d

            If d > 12 Then k = "AFT" Else k = "MOR"

            'TextBox1.Text = k

            'v = animalTextBox.Text


            batch.Text = k + v + m + y + anid

            Call fillmilk()
            Call fillstaff()
            GroupBox3.Enabled = True
            GroupBox4.Enabled = True

            ComboBox1.Focus()
        Else
            MsgBox("Invalid Operation. Access denied", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub calftextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calftextbox.TextChanged

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
            newpermcmd.CommandText = "Select top 1 id From dairymilk Where ID='" & pattID & "' ORDER BY ID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                id = pattID
            Else
                Temp1 += 1
                GoTo genesis

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub fillstaff()
        Dim c1n As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim str2 As String = "SELECt Username FROM   privstaffHQ WHERE Department='ANIDEPT' and SUB_DEPARTMENT='DAIRY' and status='ON DUTY'"
        Dim datad As New OleDbDataAdapter(str2, c1n)
        Dim dse7 As New DataSet
        datad.Fill(dse7, "privstaffhq")
        With ComboBox2
            .DataSource = dse7.Tables("privstaffhq")
            .DisplayMember = "username"
            .ValueMember = "username"
            '.SelectedIndex = 0
        End With
    End Sub

    Private Sub breedTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles breedTextBox.TextChanged
        ' Button1.PerformClick()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
    Private Sub fillmilk()
        Dim k As Integer
        k = 0
        
        With ComboBox1
            While k < 70

                .Items.Add(k)
                k += 1
            End While
            .SelectedIndex = 0

        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Tagid.Text <> "" And animalTextBox.Text <> "" And calftextbox.Text <> "" And batch.Text <> "" And ComboBox1.Text <> "" And ComboBox2.Text <> "" Then


            Call restr()
            Call fillmein()
        Else
            MsgBox("One of your inputs is invalid, Rectify this", MsgBoxStyle.Exclamation, "Input error")
            Tagid.Focus()

        End If
    End Sub
    Private Sub restr()
        Dim t, vo As String
        t = DateTime.Now.Hour.ToString
        If t < 12 Then vo = "MOR" Else vo = "AFT"
        vo = vo + h
        Try


            Call connect()
            Dim cm As New OleDbCommand

            cm.Connection = cnn
            cm.Connection.Open()
            cm.CommandText = "insert into dairylist(dIFF,Tagid) values('" & Trim(vo) & "','" & Trim(Tagid.Text) & "')"
            cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        anidept.ToolStripButton3.PerformClick()
    End Sub
    Private Sub fillmein()
        Dim k As String = DateTime.Today.ToShortDateString
        Dim d, o As String
        o = DateTime.Now.Hour.ToString
        Dim com As New OleDbCommand
        If o > 12 Then d = "AFT" Else d = "MOR"
        Try

       
            Call connect()
            com.Connection = cnn
            com.Connection.Open()
            'SELECT        Id, Milking_Day, Time, TagID, Animal, Breed, Calf, Uniq, Supervisor, MilkFROM            DairyMilk)
            com.CommandText = "insert into dairymilk( Id, Milking_Day, Time, TagID, Animal, Breed, Calf, Uniq, Supervisor, Milk) Values('" & Trim(id) & "','" & Trim(k) & "','" & Trim(d) & "','" & Trim(Tagid.Text) & "','" & Trim(animalTextBox.Text) & "','" & Trim(breedTextBox.Text) & "','" & Trim(calftextbox.Text) & "','" & Trim(batch.Text) & "','" & Trim(ComboBox2.Text) & "','" & Trim(ComboBox1.Text) & "')"
            com.ExecuteNonQuery()
            MsgBox("entry added successfuly", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        anidept.ToolStripButton3.PerformClick()

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub fillmilkgrid()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select   Milking_Day, Time, TagID, Animal, Breed, Calf, Milk, Supervisor, Uniq from dairymilk ORDER BY Id DESC"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            milkgrid.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub milkgrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles milkgrid.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        anidept.ToolStripButton3.PerformClick()

    End Sub
End Class
