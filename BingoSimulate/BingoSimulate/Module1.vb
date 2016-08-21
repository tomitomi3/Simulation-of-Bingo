Module Module1
    ''' <summary>
    ''' A Bingo simulation using Monte carlo method
    ''' </summary>
    Sub Main(args() As String)
        Dim sim As New clsBingoCardMgr()

        'result
        Dim countBingo = New List(Of List(Of Integer))
        Dim countBingoRate = New List(Of List(Of Double))

        'simulation of Bingo
        Dim tempCountBingo = New List(Of Integer)
        Dim tempCountBingoRate = New List(Of Double)
        Dim person As Integer = 0
        Dim tryCount As Integer = 100000

        'person 1, per 15 number
        person = 1
        sim.IsExistFREE = True
        sim.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.Collumn15Number
        BingoSimulate(sim, person, tryCount, tempCountBingo, tempCountBingoRate)
        countBingo.Add(tempCountBingo)
        countBingoRate.Add(tempCountBingoRate)

        'person 1, all random
        person = 1
        sim.IsExistFREE = True
        sim.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.AllRandom
        BingoSimulate(sim, person, tryCount, tempCountBingo, tempCountBingoRate)
        countBingo.Add(tempCountBingo)
        countBingoRate.Add(tempCountBingoRate)

        'Output
        Console.Write("Round,")
        For i = 0 To countBingo.Count - 1
            Console.Write("Condition{0},,", i + 1)
        Next
        Console.WriteLine("")
        'data
        For i = 0 To countBingo(0).Count - 1
            Console.Write("{0},", i + 1)
            For j = 0 To countBingo.Count - 1
                Console.Write("{0},", countBingo(j)(i))
                Console.Write("{0},", countBingoRate(j)(i))
            Next
            Console.WriteLine("")
        Next
    End Sub

    Private Sub BingoSimulate(ByRef sim As clsBingoCardMgr, ByVal person As Integer, ByVal tryCount As Integer,
                              ByRef countBingo As List(Of Integer), ByRef countBingoRate As List(Of Double))
        Dim maxNumber = sim.MaxBingoNumber
        countBingo = New List(Of Integer)
        countBingoRate = New List(Of Double)
        For i As Integer = 0 To maxNumber - 1
            countBingo.Add(0)
            countBingoRate.Add(0.0)
        Next

        'playing bingo!
        sim.N = person
        For i = 0 To tryCount - 1
            sim.Init()
            For j = 0 To maxNumber - 1
                sim.PickBall()
                countBingo(j) += sim.CountBingo
                countBingoRate(j) += sim.CountBingoCumulative
            Next
        Next

        'calc "Bingo!" rate
        Dim totalTryal As Double = CDbl(tryCount * person)
        For i = 0 To maxNumber - 1
            countBingoRate(i) = CDbl(countBingoRate(i) / totalTryal)
        Next
    End Sub
End Module
