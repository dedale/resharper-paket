namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Resharper.Paket")>]
[<assembly: AssemblyProductAttribute("Resharper.Paket")>]
[<assembly: AssemblyDescriptionAttribute("Plugin for ReSharper to support Paket references correctly")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
