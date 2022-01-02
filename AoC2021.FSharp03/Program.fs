namespace AoC2021.FSharp03

module AoCModule =

    open System
    open AoC2021.FSharp.Helper

    let collectAndIndex a =
        Seq.collect Seq.indexed a
    
    let groupIt a =
        Seq.groupBy fst a

    let mapIt a =
        Seq.map (snd >> Seq.map snd) a
    
    let countOcs a =
        Seq.map (Seq.countBy id) a
    
    let maxOut a =
        Seq.map (Seq.maxBy snd) a
    
    let minOut a =
        Seq.map (Seq.minBy snd) a
    
    let decimalConv a =
            Seq.map (Seq.map (fun c -> Int32.Parse(string c))) a
            |> Seq.map (fun a -> ((a |> Seq.length) / 2, a |> Seq.sum))
            |> Seq.map (fun (l, c) -> if c > l then 1 else 0)
            |> Seq.fold (fun (g, e) num -> g + $"{num}", e + $"{((num + 1) % 2)}") ("", "")
            |> (fun (g, e) -> (Convert.ToInt32 (g, 2)) * (Convert.ToInt32 (e, 2)))

    let binaryConv compare (slice:seq<int>) =
        if (compare (slice |> Seq.length) ((slice |> Seq.sum)*2)) then 1 else 0

    let iFlt pos filter (input:string) =
        string input.[pos] = filter

    let rec rate comparison input pos =
        match input with
        | [|item|] -> item
        | items -> 
            let filter = 
                items
                |> collectAndIndex
                |> groupIt
                |> mapIt
                |> Seq.map (Seq.map (fun c -> Int32.Parse(string c)))
                |> (fun x -> binaryConv comparison (x |> Seq.item pos))
            let newInput = (items |> Seq.filter (iFlt pos (string filter))) |> Seq.toArray
            rate comparison newInput (pos+1)

    let oxy l c = c >= l
    let co2 l c = c < l

    let oxyRate l = rate oxy (List.toArray l) 0
    let co2Rate l = rate co2 (List.toArray l) 0

    [<EntryPoint>]
    let main argv =
        let data = AoCHelper.loadStringData @".\input"

        let result0 =
            collectAndIndex data
            |> groupIt
            |> mapIt
            |> decimalConv
        
        printfn $"Result for part 1: {result0}"

        let result1 = (Convert.ToInt32 ((oxyRate data), 2)) * (Convert.ToInt32 ((co2Rate data), 2))

        printfn $"Result for part 2: {result1}"
        
        0