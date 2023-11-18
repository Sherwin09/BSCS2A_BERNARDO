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

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        Dim ans As DialogResult = MessageBox.Show("Are you sure you want to save your changes?",
                                                  " Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ans = DialogResult.Yes Then
            updaterecord(txtstudid.Text, txtfirst.Text, Txtlast.Text, txtstudcourse.Text)
            MsgBox("Update Successfull")
        Else
            MsgBox("Update Cancelled")
        End If

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click


        Dim ans As DialogResult = MessageBox.Show("Are you sure you want to save your changes?",
                                                  " Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ans = DialogResult.Yes Then
            DeleteRecords(txtstudid.Text)
            MsgBox("Deletion Successfull!")
        Else
            MsgBox("Deletion Cancelled!")
        End If

    End Sub
End Class
