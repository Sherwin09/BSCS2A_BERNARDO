Public Class Form2
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click

        Form1.Show()

        Me.Hide()

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Connectdbase()
        LoadCourse()
        LoadAllData()


        With dgvData

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .RowsDefaultCellStyle.BackColor = Color.LightPink
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue

        End With

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        If cboCourse.SelectedIndex = 0 Then

            DisplayData("bscs")

        ElseIf cboCourse.SelectedIndex = 1 Then

            DisplayData("coa")

        ElseIf cboCourse.SelectedIndex = 2 Then

            DisplayData("cba")

        Else

            MsgBox("No Record!")

        End If


    End Sub
End Class