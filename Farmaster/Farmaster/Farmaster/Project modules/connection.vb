
Module connection

    Public cnn As New OleDb.OleDbConnection '
    Public conn As New SqlClient.SqlConnection
    Public cmd As New OleDb.OleDbCommand    '
    Public comd As New SqlClient.SqlCommand

    Public da As New OleDb.OleDbDataAdapter '
    Public dta As New SqlClient.SqlDataAdapter
    Public dv As New DataGridView
    Public ds As New DataSet
    Public dr As DataRow
    Public drd As OleDb.OleDbDataReader '
    Public drdr As SqlClient.SqlDataReader
    Public dt As DataTable
    Public logged As String = "MOJO"
    Public dept As String = "ADMINISTRATOR"
    Public loginallowed As Boolean = False










    Public Sub connect()
        If ((cnn.State = ConnectionState.Connecting Or ConnectionState.Open) Or (conn.State = ConnectionState.Connecting Or ConnectionState.Open)) Then
            cnn.Close()
            conn.Close()
            cnn = New OleDb.OleDbConnection 'SqlClient.SqlConnection
            conn = New SqlClient.SqlConnection
            conn.ConnectionString = "Data Source=(local);Initial Catalog=Farmaster;Persist Security Info=True;User ID=sa;Password=swiftshady"
            cnn.ConnectionString = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=farmaster"
        Else
            cnn = New OleDb.OleDbConnection
            conn = New SqlClient.SqlConnection
            conn.ConnectionString = "Data Source=(local);Initial Catalog=Farmaster;Persist Security Info=True;User ID=sa;Password=swiftshady"
            cnn.ConnectionString = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=farmaster"
        End If

    End Sub
End Module

