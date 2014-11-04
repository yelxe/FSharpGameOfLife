namespace FSharpGameOfLife

open System
open Microsoft.FSharp.Reflection
open Patterns

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

    let showStart () =
        
        writeInColor ConsoleColor.Cyan "Welcome to The Game of Life in "
        writeLineInColor ConsoleColor.Magenta "F#"
        writeLineInColor ConsoleColor.DarkCyan "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
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
        
//        let cases = FSharpType.GetUnionCases typeof<Pattern>
//        
//        for case in cases do
//            let x = System.Type.GetType case.Name
//
//            showOption (menuItem x)
        
        writeLineInColor ConsoleColor.DarkCyan "Available Patterns:"
        newLine ()
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
        newLine ()
        writeLineInColor ConsoleColor.DarkCyan "To add a pattern to the board, enter its number and coordinates (# X Y)."
        newLine ()

    let prompt () =
        
        writeInColor ConsoleColor.Magenta "=>  "
        Console.ReadLine()
