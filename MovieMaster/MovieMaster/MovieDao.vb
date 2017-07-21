Public Class MovieDao

    Private con As New System.Data.SqlClient.SqlConnection
    Private cn As New Connection()

    Sub addMovie(movieID As String, movieName As String, genreID As String)


        con = cn.Connect()

        Dim sc As New SqlClient.SqlCommand
        Dim sdr As System.Data.SqlClient.SqlDataReader
        Dim list As New List(Of String)

        sc.Connection = con

        sc.CommandType = CommandType.Text

        Try

            sc.CommandText = "INSERT INTO M_MOVIE(MOVIE_ID,MOVIE_NAME,GENRE_ID,DELETE_FLAG,CREATE_DATE,CREATE_USER) VALUES(@KEY1,@KEY2,@KEY3,0,GETDATE(),'00')"

            sc.Parameters.Clear()

            sc.Parameters.AddWithValue("@KEY1", movieID)
            sc.Parameters.AddWithValue("@KEY2", movieName)
            sc.Parameters.AddWithValue("@KEY3", genreID)

            sc.ExecuteNonQuery()

            sc.Dispose()

        Catch e As Exception
            Console.WriteLine("Error! {0}", e.Message)

        Finally
            If sc IsNot Nothing Then
                sc.Dispose()
            End If

        End Try


    End Sub

    Function searchMovie(movieName As String) As Boolean


        con = cn.Connect()

        Dim sc As New SqlClient.SqlCommand
        Dim sdr As System.Data.SqlClient.SqlDataReader
        Dim check As New Boolean

        check = True

        sc.Connection = con

        sc.CommandType = CommandType.Text

        Try

            sc.CommandText = "SELECT * FROM M_MOVIE WHERE MOVIE_NAME = @Key1"

            sc.Parameters.Clear()

            sc.Parameters.AddWithValue("@Key1", movieName)

            sdr = sc.ExecuteReader()

            sc.Dispose()

            If sdr.Read() Then

                check = False

            End If

            Return check

        Catch e As Exception
            Console.WriteLine("Error! {0}", e.Message)
            Return check

        Finally
            If sc IsNot Nothing Then
                sc.Dispose()
            End If

        End Try


    End Function

    Function getMovieName() As List(Of String())


        con = cn.Connect()

        Dim sc As New SqlClient.SqlCommand
        Dim sdr As System.Data.SqlClient.SqlDataReader
        Dim movieList As New List(Of String())

        sc.Connection = con

        sc.CommandType = CommandType.Text

        Try

            sc.CommandText = "SELECT * FROM M_MOVIE ORDER BY MOVIE_ID"



            sdr = sc.ExecuteReader()

            sc.Dispose()

            Dim str As String()

            While sdr.Read()

                str = {sdr("MOVIE_ID").ToString, sdr("MOVIE_NAME").ToString}
                movieList.Add(str)

            End While

            Return movieList

        Catch e As Exception
            Console.WriteLine("Error! {0}", e.Message)
            Return movieList

        Finally
            If sc IsNot Nothing Then
                sc.Dispose()
            End If

        End Try


    End Function

    Sub updateMovie(movieName As String, movieID As String)


        con = cn.Connect()

        Dim sc As New SqlClient.SqlCommand

        sc.Connection = con

        sc.CommandType = CommandType.Text

        Try

            sc.CommandText = "UPDATE M_MOVIE SET MOVIE_NAME = @KEY1 WHERE MOVIE_ID = @KEY2"

            sc.Parameters.Clear()

            sc.Parameters.AddWithValue("@KEY1", movieName)
            sc.Parameters.AddWithValue("@KEY2", movieID)

            sc.ExecuteNonQuery()

            sc.Dispose()

        Catch e As Exception
            Console.WriteLine("Error! {0}", e.Message)

        Finally
            If sc IsNot Nothing Then
                sc.Dispose()
            End If

        End Try


    End Sub

    Sub deleteMovie(movieID As String)


        con = cn.Connect()

        Dim sc As New SqlClient.SqlCommand

        sc.Connection = con

        sc.CommandType = CommandType.Text

        Try

            sc.CommandText = "DELETE FROM M_MOVIE WHERE MOVIE_ID = @KEY1"

            sc.Parameters.Clear()

            sc.Parameters.AddWithValue("@KEY1", movieID)

            sc.ExecuteNonQuery()

            sc.Dispose()

        Catch e As Exception
            Console.WriteLine("Error! {0}", e.Message)

        Finally
            If sc IsNot Nothing Then
                sc.Dispose()
            End If

        End Try


    End Sub

End Class
