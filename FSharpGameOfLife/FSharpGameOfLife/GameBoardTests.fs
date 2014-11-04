namespace FSharpGameOfLife

open NUnit.Framework
open FsUnit
open GameBoard
open Patterns

module ``|GameBoard`` =

    module ``createFor`` =
        
        [<Test>]
        let ``Should Create a Grid of 10 by 10`` () =
            List.length (createFor 10 10) |> should equal 100

    module ``addTo`` =
        
        [<Test>]
        let ``Should Return a Board With a Block Pattern`` () =
            
            let board = createFor 3 3
            addTo board (basePattern Block) |> should equal
                [
                    (0, 0, true);   (0, 1, true);   (0, 2, false);
                    (1, 0, true);   (1, 1, true);   (1, 2, false);
                    (2, 0, false);  (2, 1, false);  (2, 2, false)
                ]
                
    module ``evolve`` =
        
        module ``Block Pattern`` =
            
            [<Test>]
            let ``Should Remain a Block Pattern`` () =
                let board = addTo (createFor 3 3) (basePattern Block)
                evolve board 5 |> should equal
                    [
                        (0, 0, true);   (0, 1, true);   (0, 2, false);
                        (1, 0, true);   (1, 1, true);   (1, 2, false);
                        (2, 0, false);  (2, 1, false);  (2, 2, false)
                    ]
