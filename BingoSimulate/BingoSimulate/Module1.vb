Module Module1
    ''' <summary>
    ''' A Bingo simulation using Monte carlo method
    ''' </summary>
    Sub Main(args() As String)
        Dim sim As New clsBingoCardMgr()

        'result
        Dim countBingo = New List(Of List(Of Integer))
        Dim countAccumBingo = New List(Of List(Of Integer))
        Dim countBingoRate = New List(Of List(Of Double))

        'simulation of Bingo settings
        Dim tempCountBingoPerRound = New List(Of Integer)
        Dim tempAccumCountBingo = New List(Of Integer)
        Dim tempCountBingoRate = New List(Of Double)
        Dim person As Integer = 0
        Dim tryCount As Integer = 10000

        '1 person, 1 to 75 number
        person = 1
        sim.IsExistFREE = True
        sim.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.Collumn15Number
        BingoSimulate(sim, person, tryCount, tempCountBingoPerRound, tempAccumCountBingo, tempCountBingoRate)
        countBingo.Add(tempCountBingoPerRound)
        countAccumBingo.Add(tempAccumCountBingo)
        countBingoRate.Add(tempCountBingoRate)

        '1 person, 1 to 75 number, without FREE
        person = 1
        sim.IsExistFREE = False
        sim.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.Collumn15Number
        BingoSimulate(sim, person, tryCount, tempCountBingoPerRound, tempAccumCountBingo, tempCountBingoRate)
        countBingo.Add(tempCountBingoPerRound)
        countAccumBingo.Add(tempAccumCountBingo)
        countBingoRate.Add(tempCountBingoRate)

        '1 person, all random
        person = 1
        sim.IsExistFREE = True
        sim.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.AllRandom
        BingoSimulate(sim, person, tryCount, tempCountBingoPerRound, tempAccumCountBingo, tempCountBingoRate)
        countBingo.Add(tempCountBingoPerRound)
        countAccumBingo.Add(tempAccumCountBingo)
        countBingoRate.Add(tempCountBingoRate)

        '1 person, all random, without FREE
        person = 1
        sim.IsExistFREE = True
        sim.NumberSequenceSeries = clsBingoCard.EnumBingoNumberSequence.AllRandom
        BingoSimulate(sim, person, tryCount, tempCountBingoPerRound, tempAccumCountBingo, tempCountBingoRate)
        countBingo.Add(tempCountBingoPerRound)
        countAccumBingo.Add(tempAccumCountBingo)
        countBingoRate.Add(tempCountBingoRate)

        'Output
        Console.Write("Round,")
        For i = 0 To countBingo.Count - 1
            Console.Write("Bingo_{0},Accum_{0},BingoRate_{0},", i + 1)
        Next
        Console.WriteLine("")
        'data
        For i = 0 To 99 - 1
            Console.Write("{0},", i + 1)
            For j = 0 To countBingo.Count - 1
                If countBingo(j).Count <= i Then
                    Console.Write(",,,")
                    Continue For
                End If
                Console.Write("{0},", countBingo(j)(i))
                Console.Write("{0},", countAccumBingo(j)(i))
                Console.Write("{0},", countBingoRate(j)(i))
            Next
            Console.WriteLine("")
        Next
    End Sub

    Private Sub BingoSimulate(ByRef sim As clsBingoCardMgr, ByVal person As Integer, ByVal tryCount As Integer,
                              ByRef countBingo As List(Of Integer),
                              ByRef countAccumBingo As List(Of Integer),
                              ByRef countBingoRate As List(Of Double))
        Dim maxNumber = sim.MaxBingoNumber
        countBingo = New List(Of Integer)
        countAccumBingo = New List(Of Integer)
        countBingoRate = New List(Of Double)
        For i As Integer = 0 To maxNumber - 1
            countBingo.Add(0)
            countAccumBingo.Add(0)
            countBingoRate.Add(0.0)
        Next

        'playing bingo!
        sim.N = person
        For i = 0 To tryCount - 1

            If i Mod 1000 = 0 Then
                'Console.WriteLine(CInt(i / 1000).ToString & " try")
            End If

            sim.Init()
            For j = 0 To maxNumber - 1
                sim.PickBall()
                countBingo(j) += sim.CountBingo
                countAccumBingo(j) += sim.CountBingoCumulative
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
