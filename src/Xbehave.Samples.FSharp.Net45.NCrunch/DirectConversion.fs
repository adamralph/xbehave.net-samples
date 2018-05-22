// QuickStart sample direct conversion to F# from C#
// based on http://fssnip.net/km by Phillip Trelford http://trelford.com/blog
namespace Xbehave.Samples.FSharp

module DirectConversion =
    open Xbehave
    open Xunit

    // SUT
    type Calculator () = member __.Add(x,y) = x + y

    [<Scenario>]
    let addition(x:int, y:int, calculator:Calculator, answer:int) =
        let x, y, calculator, answer = ref x, ref y, ref calculator, ref answer

        "Given the number 1"
            .x(fun () -> x := 1) |> ignore

        "And the number 2"
            .x(fun () -> y := 2) |> ignore

        "And a calculator"
            .x(fun () -> calculator := Calculator()) |> ignore

        "When I add the numbers together"
            .x(fun () -> answer := (!calculator).Add(!x, !y)) |> ignore

        "Then the answer is 3"
            .x(fun () -> Assert.Equal(3, !answer))
