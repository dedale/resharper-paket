module Resharper.Paket.Tests

open Resharper.Paket
open NUnit.Framework

[<Test>]
let ``hello returns 42`` () =
  let result = Library.hello 0
  printfn "%i" result
  Assert.AreEqual(42, result)
