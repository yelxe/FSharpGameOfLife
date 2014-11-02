namespace FSharpGameOfLife

open Patterns

module GameBoard =
    
    let addToBoard board (pattern:Pattern) = 
        List.concat [board; basePattern pattern] |> Set.ofList |> Set.toList

    let staggerPattern pattern (x, y) =
        basePattern pattern |> List.map (fun (a, b) -> a + x, b + y)
