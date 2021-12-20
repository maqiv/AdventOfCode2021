namespace AoC2021.FSharp02

open System

type Direction =
    | Forward
    | Down
    | Up
    | Command of Direction * Int32

    static member FromString s =
        match s with
            | "forward" -> Forward
            | "down" -> Down
            | "up" -> Up
            | x -> (x.Split ' ') |> (fun x -> Command(Direction.FromString x.[0], Int32.Parse x.[1]))

type Movements = { Horizontal: Int32; Depth: Int32 } with
    static member Match d m =
            match d with
                | Command(Forward, x) -> { Horizontal = m.Horizontal + x; Depth = m.Depth }
                | Command(Down, x) -> { Horizontal = m.Horizontal; Depth = m.Depth + x }
                | Command(Up, x) -> { Horizontal = m.Horizontal; Depth = m.Depth - x }
                | _ -> m

type MovementsWithAim = { Horizontal: Int32; Depth: Int32; Aim: Int32 } with
    static member Match d m =
            match d with
                | Command(Forward, x) -> { Horizontal = m.Horizontal + x; Depth = m.Depth + (m.Aim * x); Aim = m.Aim }
                | Command(Down, x) -> { Horizontal = m.Horizontal; Depth = m.Depth; Aim = m.Aim + x }
                | Command(Up, x) -> { Horizontal = m.Horizontal; Depth = m.Depth; Aim = m.Aim - x }
                | _ -> m

module AoCModule =
    open AoC2021.FSharp.Helper

    let parseCommands data =
        List.map Direction.FromString data

    let rec processMovements cmds mvmnts =
        match cmds with
            | a :: tail -> processMovements tail (Movements.Match a mvmnts)
            | _ -> mvmnts.Horizontal * mvmnts.Depth

    let rec processMovementsWithAim cmds mvmnts =
        match cmds with
            | a :: tail -> processMovementsWithAim tail (MovementsWithAim.Match a mvmnts)
            | _ -> mvmnts.Horizontal * mvmnts.Depth

    [<EntryPoint>]
    let main argv =
        let data = AoCHelper.readFile @"input"
        let commands = parseCommands data
        
        let result = processMovements commands { Horizontal = 0; Depth = 0 }
        printfn $"Result for quest 0: {result}"
        
        let result = processMovementsWithAim commands { Horizontal = 0; Depth = 0; Aim = 0 }
        printfn $"Result for quest 0: {result}"

        0