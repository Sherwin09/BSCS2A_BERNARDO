Imports System.Runtime.Versioning
Imports K4os.Compression.LZ4.Streams
Imports Microsoft.VisualBasic.Devices
Imports MySql.Data.MySqlClient

Module Module1

    Dim con As New MySqlConnection

    Dim reader As MySqlDataReader

    Dim mysqlcmd As New MySqlCommand

    Dim host, uname, pwd, dbname As String

    Dim sqlquery As String

    Dim dtTable As New DataTable

    Dim adapter As New MySqlDataAdapter

    Public Sub Connectdbase()

        host = "127.0.0.1"

        dbname = "bscs2a_oop"

        uname = "root"

        pwd = "password"

        ' check  if connection is open 

        If Not con Is Nothing Then

            con.Close() ' close the dbaseconnection

            'connention string signature
            con.ConnectionString = "server=" & host & ";user id =" & uname & "; password =" & pwd & ";database=" & dbname & ""

            Try 'open the connection

                con.Open()

                MessageBox.Show("Connected")

            Catch ex As Exception

                MessageBox.Show(ex.Message)



            End Try

        End If


    End Sub

    Public Sub SaveRecord()

        Dim fname, lname, course As String


        fname = Form1.txtfname.Text
        lname = Form1.txtlname.Text
        course = Form1.txtcourse.Text

        sqlquery = "INSERT INTO student(studFname,studLname,course)
                    VALUES(@fname,@lname,@course)"


        'pass the query and connection to mysqlcommand

        mysqlcmd = New MySqlCommand(sqlquery, con)

        'add the parameters valuew

        mysqlcmd.Parameters.AddWithValue("@fname", fname)

        mysqlcmd.Parameters.AddWithValue("@lname", lname)

        mysqlcmd.Parameters.AddWithValue("@course", course)

        Try
            'try execute th sql query command

            mysqlcmd.ExecuteNonQuery()

            MsgBox("Record Save Successfully!")


        Catch ex As Exception

            MessageBox.Show("Error" & ex.Message)

        Finally

            textclear()



        End Try

    End Sub

    Sub textclear()

        Form1.txtfname.Clear()
        Form1.txtlname.Clear()
        Form1.txtcourse.Clear()


    End Sub

    Public Sub SearchData()

        Dim uid As String

        uid = Form1.txtstudid.Text

        sqlquery = "SELECT * FROM student where studID = @uid"

        mysqlcmd = New MySqlCommand(sqlquery, con)

        mysqlcmd.Parameters.AddWithValue("@uid", uid)

        Try
            reader = mysqlcmd.ExecuteReader()

            If reader.Read Then
                Form1.txtfirst.Text = reader("studFname").ToString()

                Form1.txtlast.text = reader("studLname").ToString()

                Form1.txtstudcourse.Text = reader("course").ToString()

                Form1.btndelete.Enabled = True

                Form1.btnupdate.Enabled = True

                Form1.txtfirst.Enabled = True

                Form1.Txtlast.Enabled = True

                Form1.txtstudcourse.Enabled = True

            Else

                MsgBox("No Record!")
            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            reader.Close()


        End Try





    End Sub

    Public Sub LoadAllData()

        sqlquery = "SELECT * FROM student"

        adapter = New MySqlDataAdapter(sqlquery, con)

        Try

            dtTable = New DataTable

            adapter.Fill(dtTable)

            With Form2.dgvData

                .DataSource = dtTable

                .AutoResizeColumns()





            End With

            'mysqlcmd = New MySqlCommand(sqlquery, con)

            'reader = mysqlcmd.ExecuteReader()

            'display the record in your datagridview

        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            con.Close()



        End Try

    End Sub

    Public Sub LoadCourse()

        sqlquery = "select distinct course from student"


        sqlquery = "select course  from student"

        Try

            mysqlcmd = New MySqlCommand(sqlquery, con)

            reader = mysqlcmd.ExecuteReader

            While reader.Read

                Form2.cboCourse.Items.Add(reader("course").ToString)

            End While

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Public Sub DisplayData(kurso As String)


        sqlquery = "SELECT * FROM student where course = @kurso"

        adapter = New MySqlDataAdapter(sqlquery, con)

        adapter.SelectCommand.Parameters.AddWithValue("@kurso", kurso)


        Try

            dtTable = New DataTable

            adapter.Fill(dtTable)

            With Form2.dgvData

                .DataSource = dtTable

                .AutoResizeColumns()





            End With

            'mysqlcmd = New MySqlCommand(sqlquery, con)

            'reader = mysqlcmd.ExecuteReader()

            'display the record in your datagridview

        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            con.Close()



        End Try

    End Sub

    Public Sub updaterecord(studID As String, fname As String, lname As String, course As String)

        sqlquery = "UPDATE student set studFname = @fname, studLname = @lname, course = @course where studID = @studID"

        Try

            Using cmd As New MySqlCommand(sqlquery, con)
                cmd.Parameters.AddWithValue("@fname", fname)
                cmd.Parameters.AddWithValue("@lname", lname)
                cmd.Parameters.AddWithValue("@course", course)
                cmd.Parameters.AddWithValue("@studid", studID)
                cmd.ExecuteNonQuery()
                MsgBox("Update Successful", vbInformation, "Update Message")


            End Using

        Catch ex As Exception

            MsgBox("Error" & ex.Message, vbInformation, "Error Message")

        Finally

            Form1.txtfirst.Clear()
            Form1.Txtlast.Clear()
            Form1.txtstudcourse.Clear()

        End Try

    End Sub

    Public Sub DeleteRecords(studid As String)

        sqlquery = "delete from  student  where studid = @studid"

        Try

            Using cmd As New MySqlCommand(sqlquery, con)
                cmd.Parameters.AddWithValue("@studid" , studid)

                cmd.ExecuteNonQuery()
                MsgBox("Deletion Successfull!", vbInformation, "Delete Message")


            End Using

        Catch ex As Exception

            MsgBox("Error" & ex.Message, vbInformation, "Error Message")

        Finally

            Form1.txtfirst.Clear()
            Form1.Txtlast.Clear()
            Form1.txtstudcourse.Clear()

        End Try


    End Sub

End Module
