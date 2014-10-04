Imports System.Data.OleDb
Public Class Tempmap

    Private Sub tempgrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tempgrid.CellClick
        tempgrid.CurrentRow.Selected = True
    End Sub

    Private Sub tempgrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tempgrid.CellContentClick
        tempgrid.CurrentRow.Selected = True
    End Sub
    Private Sub temp()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from dailytemp"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            tempgrid.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub mefilt()
        Try
            Dim cloe As New OleDbCommand


            Call connect()
            cnn.Open()
            cloe.Connection = cnn
            cloe.CommandText = "insert into dailytemp(Day, Morning_tempratures, Afternoon_tempratures, Evening_Tempratures, Nigth_Tempratures) values('" & Today.ToShortDateString & "',' 0 ',' 0 ','0','0')"

            cloe.ExecuteNonQuery()
        Catch ex As Exception


            Exit Sub
        End Try
    End Sub

    Private Sub Tempmap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call temp()
        Call mefilt()

    End Sub

    Private Sub tempgrid_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tempgrid.CellContentDoubleClick
        ' tempgrid.CurrentRow.Selected = True


    End Sub

    Private Sub tempgrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tempgrid.CellDoubleClick
        tempgrid.CurrentRow.Selected = True
        Dim x, y As String
        x = DateTime.Now.Hour.ToString

        If x >= 0 And x < 12 Then



6:

            MsgBox("Please enter the current temprature in the hatchery ", MsgBoxStyle.OkOnly)

            Dim er As String = InputBox("Enter current temprature", "Temprature Input")
            If Char.IsLetter(er) Or Char.IsPunctuation(er) Or Char.IsSymbol(er) Or er > 50 Or er < 10 Then
                MsgBox("your input has been rejected")
                GoTo 5



                Exit Sub

5:

                Dim c As MsgBoxResult = MsgBox("do you still want to try the task", MsgBoxStyle.YesNo, "Retry Task")
                If c = MsgBoxResult.Yes Then
                    GoTo 6
                Else
                    Exit Sub
                End If
            Else

            End If
            '  MsgBox(er)

            Try
                Dim cm As New OleDb.OleDbCommand
                Call connect()
                cm.Connection = cnn
                cm.Connection = cnn
                cm.Connection.Open()
                cm.CommandText = "UPDATE dailytemp SET morning_Tempratures = '" & Trim(er) & "' wHERE (day like '%" & Today.ToShortDateString & "%')"
                cm.ExecuteNonQuery()


                MsgBox("Entry Updates Successfuly", MsgBoxStyle.Information, "Updated")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Hatchery.ToolStripButton1.PerformClick()
        Else
            
            'MsgBox("afternoon")
            'GoTo 1
        End If

        If x >= 12 And x < 17 Then

8:

            MsgBox("Please enter the current temprature in the hatchery ", MsgBoxStyle.OkOnly)

            Dim er As String = InputBox("Enter current temprature", "Temprature Input")
            If Char.IsLetter(er) Or Char.IsPunctuation(er) Or Char.IsSymbol(er) Or er > 50 Or er < 10 Then
                MsgBox("your input has been rejected")
                GoTo 7



                Exit Sub

7:

                Dim c As MsgBoxResult = MsgBox("do you still want to try the task", MsgBoxStyle.YesNo, "Retry Task")
                If c = MsgBoxResult.Yes Then
                    GoTo 8
                Else
                    Exit Sub
                End If
            Else

            End If
            '  MsgBox(er)

            Try
                Dim cm As New OleDb.OleDbCommand
                Call connect()
                cm.Connection = cnn
                cm.Connection = cnn
                cm.Connection.Open()
                cm.CommandText = "UPDATE dailytemp SET Afternoon_Tempratures = '" & Trim(er) & "' wHERE (day like '%" & Today.ToShortDateString & "%')"
                cm.ExecuteNonQuery()


                MsgBox("Entry Updates Successfuly", MsgBoxStyle.Information, "Updated")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Hatchery.ToolStripButton1.PerformClick()
        Else
           
            'MsgBox("afternoon")
            'GoTo 1
        End If
        If x >= 17 And x < 20 Then


3:

            MsgBox("Please enter the current temprature in the hatchery ", MsgBoxStyle.OkOnly)

            Dim er As String = InputBox("Enter current temprature", "Temprature Input")
            If Char.IsLetter(er) Or Char.IsPunctuation(er) Or Char.IsSymbol(er) Or er > 50 Or er < 10 Then
                MsgBox("your input has been rejected")
                GoTo 4



                Exit Sub

4:

                Dim c As MsgBoxResult = MsgBox("do you still want to try the task", MsgBoxStyle.YesNo, "Retry Task")
                If c = MsgBoxResult.Yes Then
                    GoTo 3
                Else
                    Exit Sub
                End If
            Else

            End If
            '  MsgBox(er)

            Try
                Dim cm As New OleDb.OleDbCommand
                Call connect()
                cm.Connection = cnn
                cm.Connection = cnn
                cm.Connection.Open()
                cm.CommandText = "UPDATE dailytemp SET Evening_Tempratures = '" & Trim(er) & "' wHERE (day like '%" & Today.ToShortDateString & "%')"
                cm.ExecuteNonQuery()


                MsgBox("Entry Updates Successfuly", MsgBoxStyle.Information, "Updated")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Hatchery.ToolStripButton1.PerformClick()
        Else
            
        End If
        'MsgBox("nigth")

        If x > 20 Then

1:

            MsgBox("Please enter the current temprature in the hatchery ", MsgBoxStyle.OkOnly)

            Dim er As String = InputBox("Enter current temprature", "Temprature Input")
            If Char.IsLetter(er) Or Char.IsPunctuation(er) Or Char.IsSymbol(er) Or er > 50 Or er < 10 Then
                MsgBox("your input has been rejected")
                GoTo 2



                Exit Sub

2:

                Dim c As MsgBoxResult = MsgBox("do you still want to try the task", MsgBoxStyle.YesNo, "Retry Task")
                If c = MsgBoxResult.Yes Then
                    GoTo 1
                Else
                    Exit Sub
                End If
            Else

            End If
            '  MsgBox(er)

            Try
                Dim cm As New OleDb.OleDbCommand
                Call connect()
                cm.Connection = cnn
                cm.Connection = cnn
                cm.Connection.Open()
                cm.CommandText = "UPDATE dailytemp SET nigth_tempratures = '" & Trim(er) & "' wHERE (day like '%" & Today.ToShortDateString & "%')"
                cm.ExecuteNonQuery()


                MsgBox("Entry Updates Successfuly", MsgBoxStyle.Information, "Updated")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Hatchery.ToolStripButton1.PerformClick()
        Else
           
        End If
        'MsgBox("nigth")

        ' GoTo 1
        ' End If






    End Sub
End Class
