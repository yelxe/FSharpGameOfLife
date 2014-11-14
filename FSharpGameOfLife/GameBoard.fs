namespace FSharpGameOfLife


module GameBoard =

    let snd' (x, y, z) = y

    let fst' (x, y, z) = x

    let rows board = board |> List.maxBy fst' |> fst'

    let cols board = board |> List.maxBy snd' |> snd'

    let neighbourhood =
        [for a in -1..1 do for b in -1..1 -> (a, b)] |> List.filter (fun (a, b) -> (a, b) <> (0, 0))

    let addCells (a, b) (c, d) = (a + c, b + d)

    let createFor rows columns =
        [for x in 0..(rows - 1) do for y in 0..(columns - 1) -> (x, y, false)]

    let addTo board pattern =
        let isCellAlive a b = pattern |> List.exists (fun (x, y) -> (a, b) = (x, y))
        board |> List.map (fun (x, y, z) -> (x, y, isCellAlive x y || z))
        
    let addCellTo board cell =
        let makeItLive (x, y, z) = (x, y, (x, y) = cell)
        board |> List.map makeItLive

    let livingNeighbours (x, y, _) board =
        let neighbours = neighbourhood |> List.map (addCells (x, y))
        let isAlive (a, b) = board |> List.exists (fun (x, y, z) -> (x, y, z) = (a, b, true))
        neighbours |> List.filter isAlive |> List.length

    let iterate board =
        let nextGeneration (x, y, isAlive) =
            let neighbours = board |> livingNeighbours (x, y, isAlive)
            match neighbours with
            | 3 -> (x, y, true)
            | 2 -> (x, y, isAlive)
            | _ -> (x, y, false)
        board |> List.map nextGeneration

    let rec evolve board turns =
        match turns with
        | 0 -> board
        | _ -> evolve (iterate board) (turns - 1)
