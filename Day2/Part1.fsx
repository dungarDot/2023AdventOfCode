open System.IO
open System

let inputData =  File.ReadLines @".\Day2\input.txt"

type Round = 
    {   Red: int 
        Green: int
        Blue: int
        Valid: bool }

type Game = 
    {   Id: int
        Rounds: Round list
        Total: int }

let colors =
    [   "red"
        "green"
        "blue" ]

let parseGames (lines: string seq) =
    lines
    |> Seq.map(fun line ->
        let id = 
            line.Split ' ' 
            |> fun arr -> arr.[1]
            |> int

        let games = 
            line.Split ';'
        ) 