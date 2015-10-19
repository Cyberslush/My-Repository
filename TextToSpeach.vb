'======================================================================================
' TTS Text To Speach class by Cyberslush  -  cyberslush@live.com

' Windows Phone 8.1 Silverlight only! uses the default phoe voice. 
' This is short and simple I like it!!!
' Click the Show All Files icon in the Solution Explorer, Open the My Project Directory,
' Double click the WMAppManifest.xml file, Click the capabilities Tab And make sure that
' the following option is ticked.
' ID_CAP_SPEECH_RECOGNITION
' Usage
' Dim _Speach As New TextToSpeach
' _Speach.SayIt("Text to speak")
'=======================================================================================

Imports Windows.Phone.Speech.Synthesis

Public Class TextToSpeach
    Inherits PhoneApplicationPage
    Private _synth As New SpeechSynthesizer
    Public Async Sub SayIt(_Speak As String)
        Await _synth.SpeakTextAsync(_Speak)
    End Sub
End Class
