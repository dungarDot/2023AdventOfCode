open System.IO
open System

let inputData: Collections.Generic.IEnumerable<string> =  File.ReadLines @".\Day1\input.txt"

let numberWords =
    [   "one", 1
        "two", 2
        "three", 3
        "four", 4
        "five", 5
        "six", 6
        "seven", 7
        "eight", 8
        "nine", 9 ]

type NumberIndex = 
    {   Index: int
        Value: string }

let getNumberFromWord (input:string) = 
    numberWords
    |> List.collect(fun (number, value) -> 
        [   { Index = input.IndexOf number; Value = value.ToString() }
            { Index = input.LastIndexOf number; Value = value.ToString()} ] ) 
    |> List.filter(fun indexes -> indexes.Index >= 0)
    |> List.sortBy(fun index -> index.Value)
    
let getNumberFromCharacter (input:string) = 
    input
    |> Seq.mapi( fun i c ->
        match Char.IsNumber c with 
        | true -> Some { Index = i; Value = c.ToString() } 
        | false -> None )
    |> Seq.choose id
    |> Seq.toList

let result =
    inputData
    |> Seq.map( fun line ->
        getNumberFromWord line @ getNumberFromCharacter line
        |> List.sortBy _.Index
        |> fun indexes -> (List.head indexes).Value + (List.last indexes).Value |> int )
    |> Seq.toList
    |> Seq.sum

result

// Ye ole fashion debugging.
// result 
// |> Seq.map _.ToString()
// |> fun data -> File.WriteAllLines(@".\test.txt", data)