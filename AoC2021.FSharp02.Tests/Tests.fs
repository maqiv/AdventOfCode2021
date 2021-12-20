namespace AoC2021.FSharp02.Tests

open AoC2021.FSharp02
open AoC2021.FSharp.Helper
open Microsoft.VisualStudio.TestTools.UnitTesting
open System

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.Direction_ParseFromString_SingleCommand() =
        Assert.AreEqual(Command(Forward, 20), Direction.FromString "forward 20")

    [<DataTestMethod>]
    [<DataRow(@"sample_data")>]
    member this.ParseCoordinates_FromFile_IntoList(dataFile: string) =
        let data = AoCHelper.readFile dataFile
        let expected = [Command(Forward, 5); Command(Down, 5); Command(Forward, 8); Command(Up, 3); Command(Down, 8); Command(Forward, 2)]
        let result = AoCModule.parseCommands data
        Assert.AreEqual(expected, result)

    [<DataTestMethod>]
    [<DataRow(@"sample_data", 150)>]
    member this.ProcessMovements_FromFile_CalculateResult(dataFile: string, expectedResult: int) =
        let data = AoCHelper.readFile dataFile
        let commands = AoCModule.parseCommands data
        let result = AoCModule.processMovements commands { Horizontal = 0; Depth = 0 }
        Assert.AreEqual(expectedResult, result)

    [<DataTestMethod>]
    [<DataRow(@"sample_data", 900)>]
    member this.ProcessMovements_WithAim_CalculateResult(dataFile: string, expectedResult: int) =
        let data = AoCHelper.readFile dataFile
        let commands = AoCModule.parseCommands data
        let result = AoCModule.processMovementsWithAim commands { Horizontal = 0; Depth = 0; Aim = 0 }
        Assert.AreEqual(expectedResult, result)