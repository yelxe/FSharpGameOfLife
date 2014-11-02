namespace FSharpGameOfLife

open System

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
        writeLineInColor ConsoleColor.DarkCyan "Please select a life pattern below by entering the number:"
        newLine ()
        writeInColor ConsoleColor.DarkCyan "1.  "
        writeLineInColor ConsoleColor.Cyan "Block"
        writeInColor ConsoleColor.DarkCyan "2.  "
        writeLineInColor ConsoleColor.Cyan "Beehive"
        newLine ()

    let prompt () =
        
        writeInColor ConsoleColor.Magenta "->  "
        Console.ReadLine()
