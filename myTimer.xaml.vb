
Public NotInheritable Class myTimer

    '=======================================================================
    ' VB 6 style timer control by Cyberslush - cyberslush@live.com  10/18/15
    ' Usage -
    ' create a user control named myTimer and add the folowing code
    ' ----------------------------------------------------------------------
    ' xaml  ----  Declare the control
    '  <Grid> 
    ' <local:myTimer x:Name="_Timer" /> 
    ' </Grid>
    ' ----------------------------------------------------------------------
    ' VB  ----  set Interval and start timer
    ' _Timer._Interval = 5          '5 seconds
    ' _Timer._Enabled = True
    ' When double clicking control the default event "Loaded" is created 
    ' use TimerTic event for code execution
    ' ToDo
    ' I have no clue how to set the default event in windows phone ?????????
    ' the app has to be built once before the control is avalible
    '=======================================================================
    Inherits UserControl
        Dim _timer As DispatcherTimer
        Public Event _TickEvent()
        Sub New()
            _Enabled = False
        End Sub
        Private Sub Tic()
            RaiseEvent _TickEvent()
        End Sub
        Private EnabledProperty As Boolean
        Public Property _Enabled() As Boolean
            Get
                Return EnabledProperty
            End Get
            Set(ByVal value As Boolean)
                If Not (value = EnabledProperty) Then
                    Me.EnabledProperty = value
                    If _Enabled = True Then
                        StartTimer()
                    ElseIf _Enabled = False Then
                        _timer.Stop()
                    End If
                End If
            End Set
        End Property
        Private _Span As Integer = 5  ' Default 5 seconds
        Public Property _Interval() As Integer
            Get
                Return _Span
            End Get
            Set(value As Integer)
                _Span = value
            End Set
        End Property
        Private Sub StartTimer()
            _Interval = _Span
            _timer = New DispatcherTimer()
            _timer.Interval = New TimeSpan(0, 0, _Span)
            AddHandler _timer.Tick, AddressOf Tic
            _timer.Start()
        End Sub
    End Class


