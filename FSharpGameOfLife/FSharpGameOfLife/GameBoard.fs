namespace FSharpGameOfLife

open Patterns

module GameBoard =
    
    let createFor rows columns =
        
        [for x in 0..(rows - 1) do for y in 0..(columns - 1) -> (x, y, false)]

    let addTo board pattern =
        
        board |> List.map
            (
                fun (x, y, z) ->
                    if List.exists (fun (a, b) -> a = x && b = y) pattern
                    then (x, y, true)
                    else (x, y, z)
            )
        
    let livingNeighbours (x, y, z) board =
        
        board |> List.filter
            (
                fun (a, b, c) ->
                    (x = a - 1 || x = a || x = a + 1) && 
                    (y = b - 1 || y = b || y = b + 1) && 
                    (x <> a || y <> b) &&
                    (c = true)
            )

    let iterate board =
        
        board |> List.map
            (
                fun (x, y, isAlive) ->
                    if isAlive = false
                    then
                        match (livingNeighbours (x, y, isAlive) board).Length with
                            | 3 -> (x, y, true)
                            | a -> (x, y, false)
                    else
                        match (livingNeighbours (x, y, isAlive) board).Length with
                            | 2 -> (x, y, true)
                            | 3 -> (x, y, true)
                            | a -> (x, y, false)
            )

    let evolve board turns =
        
        let mutable evolved = board
        
        for i = 0 to turns - 1 do
            evolved <- iterate evolved
        
        evolved
