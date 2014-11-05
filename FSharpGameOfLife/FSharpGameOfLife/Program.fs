namespace FSharpGameOfLife

open System
open Constants
open Screen
open Patterns
open GameBoard

module Program =
    
    let mutable board = createFor 40 80
    let mutable response = ""

    let choosePattern board num x y =
        match num with
        | 1 ->  addTo board (staggeredPattern Block (x, y))
        | 2 ->  addTo board (staggeredPattern Beehive (x, y))
        | 3 ->  addTo board (staggeredPattern Loaf (x, y))
        | 4 ->  addTo board (staggeredPattern Boat (x, y))
        | 5 ->  addTo board (staggeredPattern Blinker (x, y))
        | 6 ->  addTo board (staggeredPattern Toad (x, y))
        | 7 ->  addTo board (staggeredPattern Beacon (x, y))
        | 8 ->  addTo board (staggeredPattern Pulsar (x, y))
        | 9 ->  addTo board (staggeredPattern Glider (x, y))
        | 10 -> addTo board (staggeredPattern Lightweight (x, y))
        | a ->  board

    let doStart () =
            
        showStart ()
        prompt ()

    let doBoard () =
            
        showBoard board
        prompt ()

    let doOptions () =
            
        showOptions ()
        response <- prompt ()
        doBoard ()

    let doAdd () =
            
        showAdd ()
        response <- prompt ()

        let args = response.Split ' '

        if args.Length = 3 then
            board <- choosePattern board (int (args.[0])) (int (args.[1])) (int (args.[2]))
            
        if args.Length = 2 then
            let xy = (int args.[0]), (int args.[1])
            board <- addCellTo board xy

        doBoard ()

    let doEvolve iterations =
            
        board <- evolve board iterations
        doBoard ()

    let doClear () =
        
        board <- createFor 40 80
        doBoard ()

    let doQuit () =
            
        "Q"
        
    let doView () =
        
        showView ()
        view ()
        response <- prompt ()
        doBoard ()

    [<EntryPoint>]
    let main argv = 
 
        Console.WindowWidth <- 81
        Console.WindowHeight <- 45

        response <- doStart ()
        response <- doBoard ()

        while response <> "Q" do
            if response = lowerKey || response = upperKey then
                response <- doView()
            else
                response <-
                    match response with
                    | "o" | "O" -> doOptions ()
                    | "a" | "A" -> doAdd ()
                    | "c" | "C" -> doClear ()
                    | "q" | "Q" -> doQuit ()
                    | a         -> doEvolve 1

        0

