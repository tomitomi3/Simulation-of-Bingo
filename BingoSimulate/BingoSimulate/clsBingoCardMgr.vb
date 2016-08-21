''' <summary>
''' Bingo card manager
''' </summary>
Public Class clsBingoCardMgr
    ''' <summary>bingo cards</summary>
    Private _bingoCards As List(Of clsBingoCard) = Nothing

    ''' <summary>bingo No's</summary>
    Private _bingoNos As List(Of Integer) = Nothing

    ''' <summary>round</summary>
    Private _gameRound As Integer = 0

    ''' <summary>cumulative bingo count</summary>
    Private _bingoCumulativeCount As Integer = 0

    ''' <summary>bingo count</summary>
    Private _bingoCount As Integer = 0

    ''' <summary>entry person</summary>
    Public Property N As Integer = 0

    ''' <summary>Exist FREE</summary>
    Public Property IsExistFREE As Boolean = True

    ''' <summary>Bingo card number sequence</summary>
    Public Property NumberSequenceSeries As clsBingoCard.EnumBingoNumberSequence = clsBingoCard.EnumBingoNumberSequence.Collumn15Number

#Region "Public"
    ''' <summary>
    ''' default constructor
    ''' </summary>
    Public Sub New()
        clsRandomXorshiftSingleton.GetInstance.SetSeed(Date.Now.Millisecond)
        For i As Integer = 0 To 99
            clsRandomXorshiftSingleton.GetInstance.Next()
        Next
    End Sub

    ''' <summary>
    ''' Initialze
    ''' </summary>
    Public Sub Init()
        If Me.N = 0 Then
            Return
        End If

        'create bingo cards
        Me._bingoCards = New List(Of clsBingoCard)
        For i As Integer = 0 To N - 1
            Dim tempBingoCard As New clsBingoCard
            If Me.IsExistFREE = False Then
                tempBingoCard.FREE_POSITION = -1
            End If
            tempBingoCard.Init(Me.NumberSequenceSeries)

            Me._bingoCards.Add(tempBingoCard)
        Next

        'pick bingo No
        If Me.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.AllRandom Then
            Me._bingoNos = clsUtil.RandomPermutaion(1, 100, -1)
        ElseIf Me.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.Collumn15Number Then
            Me._bingoNos = clsUtil.RandomPermutaion(1, 15 * 5 + 1, -1)
        End If
        For i As Integer = 0 To _bingoNos.Count - 1
            Me._bingoNos(i) += 1
        Next

        'clear result
        Me._bingoCumulativeCount = 0
        Me._bingoCount = 0

        'clear game round
        Me._gameRound = 0
    End Sub

    ''' <summary>
    ''' Pick ball
    ''' </summary>
    Public Sub PickBall()
        If Me._gameRound = Me._bingoNos.Count Then
            Return
        End If

        'びんごー
        Dim nowBingoCount As Integer = 0
        Dim ballNo As Integer = Me._bingoNos(_gameRound)
        For Each card In _bingoCards
            card.SetNo(ballNo)

            'count bingo
            If card.GetResult() = clsBingoCard.EnumBingoResult.Bingo Then
                nowBingoCount += 1
            End If
        Next

        'result
        Me._bingoCumulativeCount += nowBingoCount
        Me._bingoCount = nowBingoCount

        'next
        _gameRound += 1
    End Sub

    Public ReadOnly Property CountBingoCumulative As Integer
        Get
            Return Me._bingoCumulativeCount
        End Get
    End Property

    Public ReadOnly Property CountBingo As Integer
        Get
            Return Me._bingoCount
        End Get
    End Property

    Public ReadOnly Property MaxBingoNumber As Integer
        Get
            If Me.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.AllRandom Then
                Return 99
            ElseIf Me.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.Collumn15Number Then
                Return 15 * 5
            End If

            Return -1
        End Get
    End Property
#End Region
End Class
