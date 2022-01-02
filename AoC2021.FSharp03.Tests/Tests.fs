namespace AoC2021.FSharp03.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        let data = [
                "00100"
                "11110"
                "10110"
                "10111"
                "10101"
                "01111"
                "00111"
                "11100"
                "10000"
                "11001"
                "00010"
                "01010" ]

        let result = List.transpose (List.map Seq.toList data)
        Console.WriteLine(result)