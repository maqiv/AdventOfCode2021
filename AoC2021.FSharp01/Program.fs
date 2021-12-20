namespace AoC2021.FSharp01

module AoCModule =

    open AoC2021.FSharp.Helper
    
    let rec measureDepth list incrCnt =
        match list with
        | a :: (b :: tail) -> measureDepth (b :: tail) (incrCnt + (if (a < b) then 1 else 0))
        // | a :: tail when tail.Length > 0 -> measureDepth tail (incrCnt + (if (a < tail.Head) then 1 else 0))
        | _ -> incrCnt
    
    let rec measureSlidingDepth list incrCnt =
        match list with
        | a :: (b :: (c :: (d :: tail))) -> measureSlidingDepth (b :: (c :: (d :: tail))) (incrCnt + (if ((a + b + c) < (b + c + d)) then 1 else 0))
        | _ -> incrCnt

    [<EntryPoint>]
    let main argv =
        let data = AoCHelper.loadIntData @".\input"

        let count = measureDepth data 0
        printfn $"Result for quest 0: {count}"

        let countSliding = measureSlidingDepth data 0
        printfn $"Result for quest 1: {countSliding}"

        0
