namespace FSharp.UpdateFSharpVersion

module Migrator =
    open System.Xml

    let updateFSharpVersion (version : string) (paths : string seq) =
        let loadAndUpdate (version : string) (path : string) =
            let doc = new XmlDocument()
            doc.Load(path)
            let mgr = new XmlNamespaceManager(doc.NameTable)
            mgr.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003")
            let node = doc.SelectSingleNode("//x:TargetFSharpCoreVersion", mgr)
            node.InnerText <- version
            doc.Save(path)
        
        paths |> Seq.iter(loadAndUpdate version)
        