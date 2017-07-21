Public Class pegeingDao
    Dim cn As System.Data.SqlClient.SqlConnection
    Dim con As New Class1
    Dim command As New SqlClient.SqlCommand
    Dim sr As SqlClient.SqlDataReader
    Sub conDB()
        cn = con.Connect()
    End Sub
    Function getCount()
        conDB()
        Dim allCount As Integer
        command.Connection = cn 'コネクションの指定

        command.CommandType = CommandType.Text 'コマンドの種類をテキストにする（省略可）

        command.CommandText = "SELECT CHILD.VIEWER_ID, CHILD.VIEWER_NAME FROM(
                                SELECT ROW_NUMBER() OVER(ORDER BY VIEWER_ID ASC) AS ROW, VIEWER_ID, VIEWER_NAME
                                FROM M_VIEWER WHERE DELETE_FLAG = 0)CHILD"

        sr = command.ExecuteReader()
        command.Dispose()   'SQLの結果を取得する

        '取得した結果を出力する
        While sr.Read
            allCount = allCount + 1
        End While
        sr.Dispose()
        Return allCount
    End Function
    Function getDispInfo1()
        Dim beanList As New List(Of viewerBean)

        Command.Connection = cn 'コネクションの指定

        Command.CommandType = CommandType.Text 'コマンドの種類をテキストにする（省略可）

        Command.CommandText = "SELECT CHILD.VIEWER_ID, CHILD.VIEWER_NAME FROM(
                                SELECT ROW_NUMBER() OVER(ORDER BY VIEWER_ID ASC) AS ROW, VIEWER_ID, VIEWER_NAME
                                FROM M_VIEWER WHERE DELETE_FLAG = 0)CHILD
                                WHERE CHILD.ROW BETWEEN 0 AND 4"

        sr = command.ExecuteReader()
        command.Dispose()   'SQLの結果を取得する

        '取得した結果を出力する

        While sr.Read
            Dim bean As New viewerBean
            bean.setName(SR(1))
            bean.setId(SR(0))
            beanList.Add(bean)
        End While
        SR.Dispose()
        Return beanList
    End Function
    Function getDispInfo2(start As Integer, stops As Integer)
        Dim beanList As New List(Of viewerBean)


        Command.Connection = cn 'コネクションの指定

        Command.CommandType = CommandType.Text 'コマンドの種類をテキストにする（省略可）

        Command.CommandText = "SELECT CHILD.VIEWER_ID, CHILD.VIEWER_NAME FROM(
                                SELECT ROW_NUMBER() OVER(ORDER BY VIEWER_ID ASC) AS ROW, VIEWER_ID, VIEWER_NAME
                                FROM M_VIEWER WHERE DELETE_FLAG = 0)CHILD
                                WHERE CHILD.ROW BETWEEN" + " " + start.ToString + " AND" + " " + stops.ToString

        sr = command.ExecuteReader()
        command.Dispose()   'SQLの結果を取得する

        '取得した結果を出力する
        While sr.Read
            Dim bean As New viewerBean
            bean.setName(SR(1))
            bean.setId(SR(0))
            beanList.Add(bean)
        End While
        SR.Dispose()
        Return beanList
    End Function
End Class
