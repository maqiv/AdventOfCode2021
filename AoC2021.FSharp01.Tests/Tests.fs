namespace AoC2021.FSharp01.Tests

open AoC2021.FSharp01
open AoC2021.FSharp.Helper
open Microsoft.VisualStudio.TestTools.UnitTesting
open System

[<TestClass>]
type TestClass() =

    [<TestMethod>]
    member this.MeasureDepth_ListWithMultipleElements_Increasing() =
        let count = AoCModule.measureDepth [ 1 .. 10 ] 0
        Assert.AreEqual(9, count)

    [<TestMethod>]
    member this.MeasureDepth_ListWithMultipleElements_Decreasing() =
        let count = AoCModule.measureDepth [ 10 .. 1 ] 0
        Assert.AreEqual(0, count)

    [<DataTestMethod>]
    [<DataRow(@"sample_data", 7)>]
    member this.MeasureDepth_ListWithMultipleElements_RandomData(dataFile: string, expectedCount: int) =
        let data =
            AoCHelper.readFile dataFile
            |> List.map Int32.Parse

        let count = AoCModule.measureDepth data 0
        Assert.AreEqual(expectedCount, count)

    [<TestMethod>]
    member this.MeasureDepth_ListWithOneElement() =
        let count = AoCModule.measureDepth [ 1 ] 0
        Assert.AreEqual(0, count)

    [<DataTestMethod>]
    [<DataRow(@"sample_data", 5)>]
    member this.MeasureSlidingDepth_ListWithMultipleElements_RandomData(dataFile: string, expectedCount: int) =
        let data = AoCHelper.loadData dataFile
        let count = AoCModule.measureSlidingDepth data 0
        Assert.AreEqual(expectedCount, count)

    [<TestMethod>]
    member this.MeasureSlidingDepth_ListWithThreeElements() =
        let count =
            AoCModule.measureSlidingDepth [ 1; 2; 3 ] 0

        Assert.AreEqual(0, count)
