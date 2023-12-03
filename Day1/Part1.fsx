open System.IO
open System

let inputData =  File.ReadLines @".\Day1\input.txt"

let getNumberFromString (input:string) = 
    input
    |> Seq.filter Char.IsNumber
    |> fun numbers  -> 
        let first = Seq.head numbers
        let last =  Seq.last numbers 
        (first.ToString() + last.ToString()) |> int

let result =
    inputData
    |> Seq.map getNumberFromString
    |> Seq.sum

result