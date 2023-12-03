open System.IO
open System

let inputData =  File.ReadLines @".\Day1\input.txt"

let getNumberFromString (input:string) = 
    input.Trim()
    |> Seq.filter(fun letter ->
        printfn "%A" letter
        Char.IsNumber(letter)
    ) 
    |> fun numbers  -> Seq.head numbers + Seq.last numbers 
    |> fun number -> Char.ToString(number) |> int

let result =
    inputData
    |> Seq.map getNumberFromString
    // |> Seq.sum

result