namespace FSharpGameOfLife

module Patterns =
    
    type Pattern =
        | Block
        | Beehive
        | Loaf
        | Boat
        | Blinker
        | Toad
        | Beacon
        | Pulsar
        | Glider
        | Lightweight

    let public basePattern pattern =
        match pattern with
        
        // Still Life
        | Block ->          [(0, 0); (0, 1); (1, 0); (1, 1)]
        | Beehive ->        [(0, 1); (0, 2); (1, 0); (1, 3); (2, 1); (2, 2)]
        | Loaf ->           [(0, 0); (0, 0); (0, 0); (0, 0); (0, 0); (0, 0); (0, 0)]
        | Boat ->           [(0, 0); (0, 1); (1, 0); (1, 2); (2, 1)]
        // Oscillators
        | Blinker ->        [(1, 0); (1, 1); (1, 2)]
        | Toad ->           [(1, 1); (1, 2); (1, 3); (2, 0); (2, 1); (2, 2)]
        | Beacon ->         [(0, 0); (0, 1); (1, 0); (1, 1); (2, 2); (2, 3); (3, 2); (3, 3)]
        | Pulsar ->         [(0, 0)] // TODO: Complete
        // Spaceships
        | Glider ->         [(0, 2); (1, 0); (1, 2); (2, 1); (2, 2)]
        | Lightweight ->    [(0, 0)] // TODO: Complete

       