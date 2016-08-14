﻿''' <summary>
''' Bingocard
''' </summary>
Public Class clsBingoCard
    Private _bingoCard As New List(Of Integer)(32)
    Private _hitNoMask As New List(Of Boolean)(32)
    Private _IsDoneBingo As Boolean = False
    Public Property FREE_POSITION As Integer = 12
    Public Const BINGONO As Integer = 25

    ''' <summary>
    ''' default constructor
    ''' </summary>
    Public Sub New()
        'nop
    End Sub

    ''' <summary>
    ''' Init
    ''' </summary>
    Public Sub Init()
        Dim tempBingoNos = clsUtil.RandomPermutaion(99, ai_isZeroStart:=False)

        'Bingo card index
        ' 1  2  3  4  5
        ' 6  7  8  9 10
        '11 12 13 14 15 index 13(12) = free!
        '16 17 18 19 20
        '21 22 23 24 25
        For i As Integer = 0 To BINGONO - 1
            _bingoCard.Add(-1)
            _hitNoMask.Add(False)
            If i = FREE_POSITION Then
                _hitNoMask(i) = True 'Free
            Else
                _bingoCard(i) = tempBingoNos(i)
            End If
        Next
    End Sub

    ''' <summary>
    ''' set no
    ''' </summary>
    Public Sub SetNo(ByVal pickNo As Integer)
        If _IsDoneBingo = True Then
            Return
        End If

        For i As Integer = 0 To BINGONO - 1
            If _bingoCard(i) = pickNo Then
                _hitNoMask(i) = True 'found!
                Return
            End If
        Next
    End Sub

    ''' <summary>
    ''' previous bingo
    ''' </summary>
    ''' <returns></returns>
    Public Function IsReach() As Boolean
        Throw New NotImplementedException
    End Function

    ''' <summary>
    ''' Bing
    ''' </summary>
    ''' <returns></returns>
    Public Function IsBingo() As Boolean
        If _IsDoneBingo = True Then
            Return True
        End If

        'all bingo combination are 12 patterns.
        _IsDoneBingo = Me.CheckBingo()

        Return _IsDoneBingo
    End Function

    ''' <summary>
    ''' done bingo
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDoneBingo() As Boolean
        Return _IsDoneBingo
    End Function

    ''' <summary>
    ''' Check bingo
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckBingo() As Boolean
        'not smart implment

        'check row
        Dim i As Integer = 0
        If _hitNoMask(i) AndAlso _hitNoMask(i + 1) AndAlso _hitNoMask(i + 2) AndAlso _hitNoMask(i + 3) AndAlso _hitNoMask(i + 4) Then
            Return True
        End If
        i = 5
        If _hitNoMask(i) AndAlso _hitNoMask(i + 1) AndAlso _hitNoMask(i + 2) AndAlso _hitNoMask(i + 3) AndAlso _hitNoMask(i + 4) Then
            Return True
        End If
        i = 10
        If _hitNoMask(i) AndAlso _hitNoMask(i + 1) AndAlso _hitNoMask(i + 2) AndAlso _hitNoMask(i + 3) AndAlso _hitNoMask(i + 4) Then
            Return True
        End If
        i = 15
        If _hitNoMask(i) AndAlso _hitNoMask(i + 1) AndAlso _hitNoMask(i + 2) AndAlso _hitNoMask(i + 3) AndAlso _hitNoMask(i + 4) Then
            Return True
        End If
        i = 20
        If _hitNoMask(i) AndAlso _hitNoMask(i + 1) AndAlso _hitNoMask(i + 2) AndAlso _hitNoMask(i + 3) AndAlso _hitNoMask(i + 4) Then
            Return True
        End If

        'check coll
        i = 0
        If _hitNoMask(i) AndAlso _hitNoMask(i + 5) AndAlso _hitNoMask(i + 10) AndAlso _hitNoMask(i + 15) AndAlso _hitNoMask(i + 20) Then
            Return True
        End If
        i = 1
        If _hitNoMask(i) AndAlso _hitNoMask(i + 5) AndAlso _hitNoMask(i + 10) AndAlso _hitNoMask(i + 15) AndAlso _hitNoMask(i + 20) Then
            Return True
        End If
        i = 2
        If _hitNoMask(i) AndAlso _hitNoMask(i + 5) AndAlso _hitNoMask(i + 10) AndAlso _hitNoMask(i + 15) AndAlso _hitNoMask(i + 20) Then
            Return True
        End If
        i = 3
        If _hitNoMask(i) AndAlso _hitNoMask(i + 5) AndAlso _hitNoMask(i + 10) AndAlso _hitNoMask(i + 15) AndAlso _hitNoMask(i + 20) Then
            Return True
        End If
        i = 4
        If _hitNoMask(i) AndAlso _hitNoMask(i + 5) AndAlso _hitNoMask(i + 10) AndAlso _hitNoMask(i + 15) AndAlso _hitNoMask(i + 20) Then
            Return True
        End If

        'check cross
        If _hitNoMask(0) AndAlso _hitNoMask(6) AndAlso _hitNoMask(12) AndAlso _hitNoMask(18) AndAlso _hitNoMask(24) Then
            Return True
        End If
        If _hitNoMask(4) AndAlso _hitNoMask(8) AndAlso _hitNoMask(12) AndAlso _hitNoMask(11) AndAlso _hitNoMask(16) Then
            Return True
        End If

        Return False
    End Function
End Class