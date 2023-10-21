Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Connectdbase()

        txtfirst.Enabled = False
        Txtlast.Enabled = False
        txtstudcourse.Enabled = False


    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click

        SaveRecord()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SearchData()

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        Form2.Show()

    End Sub
End Class
