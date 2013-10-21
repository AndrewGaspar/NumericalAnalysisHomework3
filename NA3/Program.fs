// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System
open NumericalAnalysis.Interpolation
open NumericalAnalysis.Roots

let part2Data = 
    [|   
        [|0.0;   0.0;    75.0|]; 
        [|3.0;   225.0;  77.0|]; 
        [|5.0;   383.0;  80.0|];
        [|8.0;   623.0;  74.0|];
        [|13.0;  993.0;  72.0|]
    |];

let part2DataSeq = part2Data |> Seq.map Array.toSeq;

let part2cData = part2Data |> Array.map (fun arr -> [| arr.[0]; arr.[2] |])
let part2cDataSeq = part2cData |> Seq.map Array.toSeq

let part2() =
    printfn "Problem 2"
    printfn "Part a:"

    part2DataSeq
    |> hermiteEquation 
    |> printfn "H(x) = %s"

    printfn "Part b:"
    let d = part2DataSeq |> hermite
    d 10.0 |> printfn "H(10.0) = %f"

    printfn "Part c:"
    let v = part2DataSeq |> hermite'
    secant (fun t -> v t - 55.0*5280.0/3600.0) (5.0, 5.1)  1e-6 500
    |> fun t -> printfn "H(%f) = %f f/s" t (v t)

[<EntryPoint>]
let main argv = 
    part2();
    Console.ReadKey() |> ignore
    0 // return an integer exit code
