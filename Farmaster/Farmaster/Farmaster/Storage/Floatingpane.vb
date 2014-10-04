Public Class Floatingpane

    Private Sub OrderNoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderNoTextBox.TextChanged
        Dim str As String = OrderNoTextBox.Text
        Call connect()
        conn.Open()
        Dim lst As SqlClient.SqlDataReader

        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT * FROM requesthq WHERE ItemreqID='" & str.ToCharArray & "'", conn)
        lst = command.ExecuteReader
        While lst.Read
            CategoryTextBox1.Text = lst("category")
            Item_TypeTextBox1.Text = lst("Item_type")
            Item_NameTextBox1.Text = lst("Item_name")
            QuantityTextBox.Text = lst("Quantity")
            UnitsTextBox1.Text = lst("Units")
            StatusTextBox.Text = lst("Status")
            DOReqDateTimePicker.Value = lst("DOreq")
            ROTextBox.Text = lst("RO")
           

            UnitsTextBox1.Text = UnitsTextBox1.Text.ToUpper

        End While

    End Sub

    Private Sub StoIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoIDTextBox.TextChanged
        Dim stW As String = StoIDTextBox.Text
        Call connect()
        conn.Open()
        Dim lsRW As SqlClient.SqlDataReader

        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT * FROM STORAGEhq WHERE itembatchno='" & stW.ToCharArray & "'", conn)
        lsRW = command.ExecuteReader
        While lsRW.Read
            CategoryTextBox.Text = lsRW("Category")
            Item_TypeTextBox.Text = lsRW("Type")
            Item_NameTextBox.Text = lsRW("Name")
            QttyTextBox.Text = lsRW("Qtty")
            UnitsTextBox.Text = lsRW("units")
            DOPDateTimePicker.Value = lsRW("supplied_on")
            RIDTextBox.Text = lsRW("Class")
            ROfficerTextBox.Text = lsRW("Received_by")

           
            UnitsTextBox.Text = UnitsTextBox.Text.ToUpper
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Val(QuantityTextBox.Text) < Val(QttyTextBox.Text) Or Val(QuantityTextBox.Text) = Val(QttyTextBox.Text) Then
            Dim vall As Integer = Val(QttyTextBox.Text) - Val(QuantityTextBox.Text)
            If (vall > 0) = True Or (vall = 0) = True Then
                Dim CM As New OleDb.OleDbCommand
                Call connect()
                cnn.Open()
                CM.Connection = cnn
                Try
                    CM.CommandText = "Update requesthq set status=0 where itemreqid='" & Trim(OrderNoTextBox.Text) & "'"
                    CM.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Try
                    CM.CommandText = "update storagehq set qtty=" & Trim(vall) & " Where itembatchno='" & Trim(StoIDTextBox.Text) & "'"
                    CM.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                MsgBox("Request has been processed ", MsgBoxStyle.Information)
                GoTo zinduka
            End If
            MsgBox("The current Items in storage cannot satisfy your request therefore Farmaster recomends restocking", MsgBoxStyle.Exclamation, "Out of Stock")
            Exit Sub

        Else
            MsgBox("The current Items in storage cannot satisfy your request therefore Farmaster recomends restocking", MsgBoxStyle.Exclamation, "Out of Stock")
            procurement.ToolStripButton3.PerformClick()
            Me.Close()
        End If
zinduka:
        Me.Close()

    End Sub
End Class