'=================================================================================
'=       Windows Phone 8.1 MessageBox Class Cyberslush@live.com 10/5/15          =
'Usage============================================================================
'Dim MyMsgBox As New MsgBox
'Dim ButtonChoice As Integer = -1
'Await(MyMsgBox.MsgShow("Title101", "Heres my msg", "My button 1", "My button 2"))
'ButtonChoice = MsgBox.IndexNum
'=================================================================================
' Redundant but educational

Imports Windows.UI.Popups

Public Class MsgBox
    Public Shared IndexNum As Integer = -1

    Public Async Function MsgShow(Title As String, Msg As String, Optional Button1 As String = Nothing, Optional CancelButton2 As String = Nothing) As Task
        ' Create the message dialog and set its content, it will get a default "Close" button 
        ' if optional buttons are not defined.
        Dim messageDialog = New MessageDialog(Msg, Title) ' Create the object
        If Button1 IsNot Nothing And Button2 = Nothing Then
            messageDialog.Commands.Add(New UICommand(Button1, Nothing, 0))
            messageDialog.CancelCommandIndex = 0 ' index of the default close button 
            Dim CommandChosen = Await (messageDialog.ShowAsync())

            IndexNum = CommandChosen.Id ' Index number of the button chosen
        End If
        If Button2 IsNot Nothing Then
            messageDialog.Commands.Add(New UICommand(Button1, Nothing, 0)) ' create button 1
            messageDialog.Commands.Add(New UICommand(CancelButton2, Nothing, 1)) ' create button 2
            messageDialog.CancelCommandIndex = 1
            Dim CommandChosen = Await (messageDialog.ShowAsync())
            IndexNum = CommandChosen.Id

        End If
    End Function
End Class

