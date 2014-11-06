namespace FSharpGameOfLife

open System
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Reflection
open Constants
open Patterns
open GameBoard

module Screen =

    let writeInColor c str = 
        
        let fmt = Printf.StringFormat<unit, unit> str

        Printf.kprintf 
            (
                fun s -> 
                let old = System.Console.ForegroundColor 
                try 
                    System.Console.ForegroundColor <- c;
                    System.Console.Write s
                finally
                    System.Console.ForegroundColor <- old
            ) 
            fmt
        
    let writeLineInColor c str = 
        
        writeInColor c str
        printfn ""

    let writeLineInDualColor c1 c2 str =
        
        str
            |> List.mapi
            (
                fun i  x ->
                if i % 2 = 0
                    then writeInColor c1 x
                    else writeInColor c2 x
            )
            |> ignore
            
        printfn ""

    let newLine () =
        
        printfn ""

    let prompt () =
        
        writeInColor ConsoleColor.Magenta "|> "
        Console.ReadLine()

    let showStart () =
        
        Console.Clear ()
        newLine ()
        newLine ()
        writeLineInDualColor ConsoleColor.Cyan ConsoleColor.DarkCyan ["Welcome to Conway's Game of Life ";"(Windows Console Edition)"]
        newLine ()
        writeLineInColor ConsoleColor.DarkCyan "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        newLine ()
        
        writeLineInColor ConsoleColor.Magenta                               "         ########      ###   ###      "
        writeLineInColor ConsoleColor.Magenta                               "         ########      ###   ###      "
        writeLineInDualColor ConsoleColor.Magenta ConsoleColor.DarkCyan [   "         ###        ###############   ";"    Special Thanks To:             "   ]
        writeLineInDualColor ConsoleColor.Magenta ConsoleColor.DarkCyan [   "         ###        ###############   ";"                                   "   ]
        writeLineInDualColor ConsoleColor.Magenta ConsoleColor.Cyan     [   "         #######       ###   ###      ";"    F# for fun and profit          "   ]
        writeLineInDualColor ConsoleColor.Magenta ConsoleColor.DarkCyan [   "         #######       ###   ###      ";"    www.fsharpforfunandprofit.com  "   ]
        writeLineInDualColor ConsoleColor.Magenta ConsoleColor.DarkCyan [   "         ###        ###############   ";"                                   "   ]
        writeLineInDualColor ConsoleColor.Magenta ConsoleColor.Cyan     [   "         ###        ###############   ";"    \"An oustanding resource!\"    "   ]
        writeLineInColor ConsoleColor.Magenta                               "         ###           ###   ###      "
        writeLineInColor ConsoleColor.Magenta                               "         ###           ###   ###      "
        newLine ()
        newLine ()
        writeLineInColor ConsoleColor.DarkCyan "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        newLine ()

        newLine ()
        newLine ()
        writeLineInDualColor ConsoleColor.DarkCyan ConsoleColor.Cyan ["Please press ";"ENTER";" to begin."]
        newLine ()

    let showOption option =
        
        let a, b, c = option
        let num = ((string a).PadLeft 3) + ". "
        let name = (string b).PadRight 15
        let group = (string c)

        writeInColor ConsoleColor.DarkCyan num
        writeInColor ConsoleColor.Cyan name
        writeInColor ConsoleColor.DarkCyan group
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
        writeLineInColor ConsoleColor.Cyan "Add a Pattern to the Board"
        newLine ()
        writeLineInColor ConsoleColor.DarkMagenta "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        newLine ()
        showOptions ()
        newLine ()
        writeLineInColor ConsoleColor.DarkMagenta "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        newLine ()
        writeLineInDualColor ConsoleColor.DarkCyan ConsoleColor.Cyan ["To add a pattern to the board, enter its number and coordinates:  ";"# x y"]
        writeLineInDualColor ConsoleColor.DarkCyan ConsoleColor.Cyan ["To add an individual cell to the board, enter its coordinates:    ";"x y  "]
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
        
        writeLineInDualColor
            ConsoleColor.DarkCyan
            ConsoleColor.Cyan
            ["| ";"ENTER";" = Evolve | ";"N";" = Evolve N | ";"A";" = Add Pattern | ";"C";" = Clear Board | ";"Q";" = Quit |"]

        newLine ()

    let showView () =
        
        let mutable x = 0

        Console.Clear ()
        writeLineInColor ConsoleColor.DarkGray message
        newLine ()
        
        for i = 0 to 35 do
            writeLineInColor ConsoleColor.Gray persistantMessage

        newLine ()
