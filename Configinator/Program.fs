// For more information see https://aka.ms/fsharp-console-apps

open Configinator
open Configinator.Configinator

let configFile = "example.txt" |> Configinator.ConfigFile.fromFilepath

printfn "Raw values:"
configFile.Entries |> Map.iter (fun key value -> printfn $"{key}:\t{value}")
    
    
let exampleString = configFile |> ConfigFile.getString "exampleString"
let exampleInt    = configFile |> ConfigFile.getInt    "exampleInt"
let exampleFloat  = configFile |> ConfigFile.getFloat  "exampleFloat"

printfn $""
printfn $""
printfn $"Parsed values:"
printfn $"exampleString:\t{exampleString}"
printfn $"exampleInt:\t{exampleInt}"
printfn $"exampleFloat:\t{exampleFloat}"



