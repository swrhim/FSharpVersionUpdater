namespace FSharp.UpdateFSharpVersion

module Traverser =
    open System.IO

    let findAllfsprojFiles startingLocation = 
        let determineIfFSProj file = 
            match Path.GetExtension file with
            | ".fsproj" -> Some file
            | _ -> None

        let rec traverse root = seq {
            let files = Directory.GetFiles root
            yield!  files |> Array.choose(determineIfFSProj)
            for subdir in Directory.GetDirectories(root) do yield! traverse subdir
        } 
    
        traverse startingLocation