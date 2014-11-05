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

    let menuItem pattern =
        
        match pattern with
        | Block ->          (1, "Block", "Still Life")
        | Beehive ->        (2, "Beehive", "Still Life")
        | Loaf ->           (3, "Loaf", "Still Life")
        | Boat ->           (4, "Boat", "Still Life")
        | Blinker ->        (5, "Blinker", "Oscillator")
        | Toad ->           (6, "Toad", "Oscillator")
        | Beacon ->         (7, "Beacon", "Oscillator")
        | Pulsar ->         (8, "Pulsar", "Oscillator")
        | Glider ->         (9, "Glider", "Spaceship")
        | Lightweight ->    (10, "Lightweight", "Spaceship")

    let basePattern pattern =
        
        match pattern with
        
        // Still Life
        | Block ->          [   ( 0,  0); ( 0,  1); ( 1,  0); ( 1,  1)]
        | Beehive ->        [   ( 0,  1); ( 0,  2); ( 1,  0); ( 1,  3); ( 2,  1); ( 2,  2)]
        | Loaf ->           [
                                ( 0,  1); ( 0,  2); ( 1,  0); ( 1,  3);
                                ( 2,  1); ( 2,  3); ( 3,  2)
                            ]
        | Boat ->           [   ( 0,  0); ( 0,  1); ( 1,  0); ( 1,  2); ( 2,  1)]
        
        // Oscillators
        | Blinker ->        [   ( 0,  0); ( 0,  1); ( 0,  2)]                                   // Stagger (1, 0) to persist
        | Toad ->           [   ( 0,  1); ( 0,  2); ( 0,  3); ( 1,  0); ( 1,  1); ( 1,  2)]     // Stagger (1, 0) to persist
        | Beacon ->         [
                                ( 0,  0); ( 0,  1); ( 1,  0); ( 1,  1);
                                ( 2,  2); ( 2,  3); ( 3,  2); ( 3,  3)
                            ]
        | Pulsar ->         [
                                ( 0,  2); ( 0,  3); ( 0,  4);  ( 0,  8); ( 0,  9); ( 0, 10);
                                ( 2,  0); ( 2,  5); ( 2,  7);  ( 2, 12); ( 3,  0); ( 3,  5);
                                ( 3,  7); ( 3, 12); ( 4,  0);  ( 4,  5); ( 4,  7); ( 4, 12);
                                ( 5,  2); ( 5,  3); ( 5,  4);  ( 5,  8); ( 5,  9); ( 5, 10);
                                ( 7,  2); ( 7,  3); ( 7,  4);  ( 7,  8); ( 7,  9); ( 7, 10);
                                ( 8,  0); ( 8,  5); ( 8,  7);  ( 8, 12); ( 9,  0); ( 9,  5);
                                ( 9,  7); ( 9, 12); (10,  0);  (10,  5); (10,  7); (10, 12);
                                (12,  2); (12,  3); (12,  4);  (12,  8); (12,  9); (12, 10)
                            ]                                                                   // Stagger (1, 1) to persist
        
        // Spaceships
        | Glider ->         [   ( 0,  2); ( 1,  0); ( 1,  2); ( 2,  1); ( 2,  2)]
        | Lightweight ->    [
                                ( 0,  1); ( 0,  2); ( 0,  3);
                                ( 0,  4); ( 1,  0); ( 1,  4);
                                ( 2,  4); ( 3,  0); ( 3,  3)
                            ]                                                                   // Stagger (0, 1) to persist

    let staggeredPattern pattern (x, y) =
        basePattern pattern |> List.map (fun (a, b) -> a + x, b + y)
