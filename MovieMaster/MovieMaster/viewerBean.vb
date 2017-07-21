Public Class viewerBean
    Dim Name As String
    Dim Id As String
    Sub setName(Para As String)
        Name = Para
    End Sub
    Sub setId(Para As String)
        Id = Para
    End Sub
    Function getName()
        Return Name
    End Function
    Function getId()
        Return Id
    End Function
End Class
