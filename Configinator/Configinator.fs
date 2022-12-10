module Configinator.Configinator

open System.IO
open System.Text.RegularExpressions

type ConfigFile = {
    Source   : string
    Lines    : string []
    Entries  : Map<string, string>
}

module ConfigFile =
    
    let private entryRegex = Regex(@"^([^\=]+)\=([^#]*)(#.*)?$", RegexOptions.Compiled)
    
    let fromLines (source: string) (linesSeq: string seq) =
        let lines = linesSeq |> Array.ofSeq
        let entries =
            lines
            |> Seq.choose (fun line -> let m = entryRegex.Match line in if m.Success then (m.Groups[1].Value.Trim(), m.Groups[2].Value.Trim()) |> Some else None)
            |> Map.ofSeq<string, string>
        {
            Source  = source
            Lines   = lines
            Entries = entries
        }
        
        
    
    let fromFilepath (filepath: string) = filepath |> File.ReadLines |> fromLines filepath
    
    let getAs func key configFile = configFile.Entries[key] |> func
    
    let getString = getAs id
    
    let getInt = getAs int
    
    let getFloat = getAs float
    