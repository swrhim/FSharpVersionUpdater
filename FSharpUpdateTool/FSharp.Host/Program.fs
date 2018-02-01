// Learn more about F# at http://fsharp.org

open System
open FSharp.UpdateFSharpVersion
[<EntryPoint>]
let main argv =
    printfn "Enter the directory of the project"
    let path = Console.ReadLine()
    printfn "Looking for fsproj in this directory=%s..." path
    let results = Traverser.findAllfsprojFiles path
    printfn "Here are the fsproj I found:"
    results |> Seq.iter(fun p -> printfn "%s" p)
    printfn "Enter the version to upgrade to:"
    let version = Console.ReadLine()
    printfn "Running..."
    Migrator.updateFSharpVersion version results
    printfn "Updated!"
    0 // return an integer exit code
