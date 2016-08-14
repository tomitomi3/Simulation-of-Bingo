''' <summary>
''' Bingo card manager
''' </summary>
Public Class clsBingoCardMgr
    ''' <summary>entry person</summary>
    Public Property N As Integer = 0

    ''' <summary>Exist FREE</summary>
    Public Property IsExistFREE As Boolean = True

    ''' <summary>bingo cards</summary>
    Private _bingoCards As List(Of clsBingoCard) = Nothing

    ''' <summary>bingo No's</summary>
    Private _bingoNos As List(Of Integer) = Nothing

    ''' <summary>round</summary>
    Private _gameRound As Integer = 0

#Region "Public"
    ''' <summary>
    ''' default constructor
    ''' </summary>
    Public Sub New()
        'nop
    End Sub

    ''' <summary>
    ''' Initialze
    ''' </summary>
    Public Sub Init(Optional ByVal isExistFREE As Boolean = True)
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
            tempBingoCard.Init()

            Me._bingoCards.Add(tempBingoCard)
        Next

        'pick bingo No
        Me._bingoNos = clsUtil.RandomPermutaion(99, ai_isZeroStart:=False)
        For i As Integer = 0 To _bingoNos.Count - 1
            Me._bingoNos(i) += 1
        Next

        'clear game round
        Me._gameRound = 0
    End Sub

    ''' <summary>
    ''' Pick ball
    ''' </summary>
    ''' <returns></returns>
    Public Function PickBall() As Integer
        If Me._gameRound = Me._bingoNos.Count Then
            Return -1
        End If

        'びんごー
        Dim existBingoCount As Integer = 0
        Dim ballNo As Integer = Me._bingoNos(_gameRound)
        For Each card In _bingoCards
            card.SetNo(ballNo)
            If card.IsBingo() Then
                existBingoCount += 1
            End If
        Next

        'next
        _gameRound += 1

        Return existBingoCount
    End Function
#End Region
End Class
