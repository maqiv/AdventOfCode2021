namespace AoC2021.FSharp.Helper

module AoCHelper =
    
    open System
    open System.IO

    let readFile filePath =
        Array.toList (File.ReadAllLines filePath)
    
    let loadData filePath =
        readFile filePath

    let loadIntData filePath =
        loadData filePath
        |> List.map Int32.Parse
    
    let loadStringData filePath =
        loadData filePath
        |> List.map (fun x -> x.Trim())