namespace FSharpGameOfLife

open System
open Constants
open Patterns
open GameBoard

module Screen =

    let writeInColor c fmt = 

        Printf.kprintf 
            (fun s -> 
                let old = System.Console.ForegroundColor 
                try 
                  System.Console.ForegroundColor <- c;
                  System.Console.Write s
                finally
                  System.Console.ForegroundColor <- old) 
            fmt
        
    let writeLineInColor c fmt = 
        
        writeInColor c fmt
        printfn ""

    let newLine () =
        
        printfn ""

    let prompt () =
        
        writeInColor ConsoleColor.Magenta "=>  "
        Console.ReadLine()

    let showStart () =
        
        Console.Clear ()
        newLine ()
        writeInColor ConsoleColor.Cyan "Welcome to The Game of Life in "
        writeLineInColor ConsoleColor.Magenta "F#"
        writeLineInColor ConsoleColor.DarkCyan "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        newLine ()
        writeLineInColor ConsoleColor.DarkCyan "This console application was part of a jouney to learn the ways of the F#rce."
        newLine ()
        writeLineInColor ConsoleColor.Cyan "Press ENTER to proceed."
        newLine ()

    let showOption option =
        
        let a, b, c = option
        let num = ((string a).PadLeft 2) + ". "
        let name = (string b).PadRight 15
        let group = (string c)

        writeInColor ConsoleColor.DarkCyan (Printf.StringFormat<unit, unit> num)
        writeInColor ConsoleColor.Cyan (Printf.StringFormat<unit, unit> name)
        writeInColor ConsoleColor.DarkCyan (Printf.StringFormat<unit, unit> group)
        newLine ()

    let showOptions () =
        
        showOption (menuItem Block)
        showOption (menuItem Beehive)
        showOption (menuItem Loaf)
        showOption (menuItem Boat)
        showOption (menuItem Blinker)
        showOption (menuItem Toad)
        showOption (menuItem Beacon)
        showOption (menuItem Pulsar)
        showOption (menuItem Glider)
        showOption (menuItem Lightweight)
        
    let showAdd () =
        
        Console.Clear ()
        newLine ()
        writeLineInColor ConsoleColor.Cyan "Add a Pattern"
        writeLineInColor ConsoleColor.DarkCyan "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        newLine ()
        showOptions ()
        newLine ()
        writeLineInColor ConsoleColor.DarkCyan "To add a pattern to the board, enter its number and coordinates (# X Y)."
        writeLineInColor ConsoleColor.DarkCyan "To add an individual cell, enter its coordinates (X Y)."
        newLine ()

    let printRow board x =

        board
            |> List.filter
            (
                fun (a, b, c) ->
                (a = x)
            )
            |> List.map
            (
                fun (a, b, c) ->
                if c = true
                then writeInColor ConsoleColor.Cyan "@" 
                else writeInColor ConsoleColor.DarkMagenta "+"
            )
            |> ignore
        
        newLine ()

    
    let showBoard (board:List<int * int * bool>) =
        
        Console.Clear ()
        
        for i in [0..(rows board)] do
            printRow board i
        
        newLine ()
        writeInColor ConsoleColor.DarkCyan "Options: "
        writeInColor ConsoleColor.Cyan "ENTER"
        writeInColor ConsoleColor.DarkCyan " = Evolve | "
        writeInColor ConsoleColor.Cyan "A"
        writeInColor ConsoleColor.DarkCyan " = Add Pattern | "
        writeInColor ConsoleColor.Cyan "C"
        writeInColor ConsoleColor.DarkCyan " = Clear Board | "
        writeInColor ConsoleColor.Cyan "Q"
        writeInColor ConsoleColor.DarkCyan " = Quit"
        newLine ()
        newLine ()

    let showView () =
        
        let mutable x = 0

        Console.Clear ()
        writeLineInColor ConsoleColor.Red (Printf.StringFormat<unit, unit> message)
        newLine ()
        
        for i = 0 to 35 do
            writeLineInColor ConsoleColor.Red (Printf.StringFormat<unit, unit> persistantMessage)

        newLine ()
