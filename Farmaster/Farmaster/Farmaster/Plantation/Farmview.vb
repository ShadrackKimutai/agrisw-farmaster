Imports System.Data.oledb
Public Class Farmview
    Dim pltn As String

    Private Sub topleftpan_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles topleftpan.MouseClick

        pltn = 1
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\topleft.gif"
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub topleftpan_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles topleftpan.Paint

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub fetchdet()

        Dim PlotName, Terrain, Soil, Siz, Manager, Best_for, Cc As String
        Dim Planted_on As Date

        Dim cd As New OleDbCommand
        Dim lstrw As OleDbDataReader
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        cd.CommandText = "Select * from PlantationHq where PlotNo='" & Trim(pltn) & "'"
        lstrw = cd.ExecuteReader
        While lstrw.Read
            PlotName = lstrw("Plotname")
            Terrain = lstrw("terrain")
            Soil = lstrw("soil")
            Siz = lstrw("size_in_Hectares")
            Manager = lstrw("manager")
            ' Best_for = lstrw("Best_for")
            'Cc = lstrw("current_crop")
            'Planted_on = lstrw("Planted_On")
        End While

        Siz = Siz + "Hectares"
        Label8.Text = "Plot Name:" + PlotName

        Label7.Text = "Plot Number " + pltn 
        Label9.Text = "Terrain :" + Terrain
        Label10.Text = "Soil: " + Soil
        'Label11.Text = "Best Suited For :" + Best_for
        ' Label12.Text = "Current Crop :" + Cc
        Label13.Text = "  Size :" + Siz
        Call furcher()

    End Sub
    Private Sub furcher()
        Dim d, o As String
        Dim cd As New OleDbCommand
        Dim lstrw As OleDbDataReader
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        cd.CommandText = "Select * from landuse where PlotNo='" & Trim(pltn) & "'"
        lstrw = cd.ExecuteReader
        While lstrw.Read

            d = lstrw("Crop")
            o = lstrw("Planted_on")

        End While
        Label11.Text = " Current Crop :" + d
        Label12.Text = " Planted On :" + o
    End Sub

    Private Sub Farmview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pltn = 1
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\topleft.gif"
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub PictureBox1_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.BackgroundImageChanged

    End Sub

    '++++++++++++++++++++++++++++++++++++++++++++++++++++
    'Dim stocat, stoype, stoiname, stoid, rid, stouni, rofficer As String
    'Dim dop As Date
    'Dim qtty As Integer
    'Dim lstrw As OleDbDataReader
    '' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
    'Dim cEmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM storageHq WHERE category Like '%CHEMICAL%' And Item_Type='" & Itype.ToCharArray & "' and Item_Name='" & Iname.ToCharArray & "'", cnn)
    '    lstrw = cEmd.ExecuteReader


    '    While lstrw.Read

    '        stoid = lstrw("stoid")
    '        stouni = lstrw("Units")
    '        stocat = lstrw("Category")
    '        stoype = lstrw("Item_type")
    '        stoiname = lstrw("Item_name")
    '        rid = lstrw("rid")
    '        dop = lstrw("dop")
    '        qtty = lstrw("qtty")
    '        rofficer = lstrw("rofficer")

    '        stouni = stouni.ToUpper()

    '    End While

    '    units = units.ToUpper()
    '++++++++++++++++++++++++++++++++++++++++++++++++++++

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub toprigthpan_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles toprigthpan.MouseClick
        pltn = 2
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\topc.gif"
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub toprigthpan_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles toprigthpan.Paint

    End Sub

    Private Sub rigthpan_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rigthpan.MouseClick
        pltn = 3
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\rigth.bmp"
            .Dock = DockStyle.None
            '.SizeMode = PictureBoxSizeMode.Normal
        End With
    End Sub

    Private Sub rigthpan_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles rigthpan.Paint
       
    End Sub

    Private Sub botleftpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles botleftpan.Click

    End Sub

    Private Sub botleftpan_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles botleftpan.MouseClick
        pltn = 6
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\botleft.gif"
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub botleftpan_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles botleftpan.Paint

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseClick
        pltn = 5
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\botc.gif"
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub botrigthpan_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles botrigthpan.MouseClick
        pltn = 4
        Call fetchdet()
        With PictureBox1
            .ImageLocation = "C:\Users\user\Documents\Visual Studio 2005\Projects\Farmaster\Farmaster\Images\botrigth.bmp"
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub botrigthpan_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles botrigthpan.Paint

    End Sub
End Class
