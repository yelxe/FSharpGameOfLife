namespace FSharpGameOfLife

open NUnit.Framework
open FsUnit
open GameBoard
open Patterns

module ``? GameBoard`` =

    module ``createFor`` =
        
        [<Test>]
        let ``Creates a Grid of 10 by 10`` () =
            List.length (createFor 10 10) |> should equal 100

    module ``addTo`` =
        
        [<Test>]
        let ``Returns a Board With a Block Pattern`` () =
            
            let board = createFor 3 3
            addTo board (basePattern Block) |> should equal
                [
                    (0, 0, true);   (0, 1, true);   (0, 2, false);
                    (1, 0, true);   (1, 1, true);   (1, 2, false);
                    (2, 0, false);  (2, 1, false);  (2, 2, false);
                ]
        
        [<Test>]
        let ``Returns a Board With Two Block Patterns`` () =
            
            let board = createFor 4 4
            addTo (addTo board (staggeredPattern Block (0, 0))) (staggeredPattern Block (2, 2)) |> should equal
                [
                    (00, 00, true );    (00, 01, true );    (00, 02, false);    (00, 03, false);
                    (01, 00, true );    (01, 01, true );    (01, 02, false);    (01, 03, false);
                    (02, 00, false);    (02, 01, false);    (02, 02, true );    (02, 03, true );
                    (03, 00, false);    (03, 01, false);    (03, 02, true );    (03, 03, true );                    
                ]
              
    module ``addCellto`` =
        
        [<Test>]
        let ``Returns a Board With A Single Living Cell`` () =
            
            let board = createFor 2 2
            addCellTo board (0, 0) |> should equal
                [
                    (00, 00, true );    (00, 01, false);
                    (01, 00, false);    (01, 01, false);
                ]

    module ``evolve`` =
        
        module ``Block Pattern`` =
            
            [<Test>]
            let ``Remains a Block Pattern`` () =
                let board = addTo (createFor 2 2) (basePattern Block)
                evolve board 1 |> should equal
                    [
                        (00, 00, true );    (00, 01, true );
                        (01, 00, true );    (01, 01, true );
                    ]

        module ``Blinker Pattern`` =
            
            [<TestCaseSource("alternate")>]
            let ``Changes to Alternate`` iterations =
                let board = addTo (createFor 3 3) (staggeredPattern Blinker (1, 0))
                evolve board iterations |> should equal
                    [
                        (00, 00, false);    (00, 01, true );    (00, 02, false);
                        (01, 00, false);    (01, 01, true );    (01, 02, false);
                        (02, 00, false);    (02, 01, true );    (02, 02, false);
                    ]

            let alternate () = [ [|1|];[|3|];[|5|] ]

            [<TestCaseSource("original")>]
            let ``Reverts to Original`` iterations =
                let board = addTo (createFor 3 3) (staggeredPattern Blinker (1, 0))
                evolve board iterations |> should equal
                    [
                        (00, 00, false);    (00, 01, false);    (00, 02, false);
                        (01, 00, true );    (01, 01, true );    (01, 02, true );
                        (02, 00, false);    (02, 01, false);    (02, 02, false);
                    ]

            let original () = [ [|2|];[|4|];[|6|] ]

        module ``Pulsar Pattern`` =
            
            [<TestCaseSource("alternateOne")>]
            let ``Changes to Altenate One`` iterations =
                let board = addTo (createFor 15 15) (staggeredPattern Pulsar (1, 1))
                evolve board iterations |> should equal
                    [
                        (00, 00, false);    (00, 01, false);    (00, 02, false);    (00, 03, false);    (00, 04, true );
                        (00, 05, false);    (00, 06, false);    (00, 07, false);    (00, 08, false);    (00, 09, false);
                        (00, 10, true );    (00, 11, false);    (00, 12, false);    (00, 13, false);    (00, 14, false);

                        (01, 00, false);    (01, 01, false);    (01, 02, false);    (01, 03, false);    (01, 04, true );
                        (01, 05, false);    (01, 06, false);    (01, 07, false);    (01, 08, false);    (01, 09, false);
                        (01, 10, true );    (01, 11, false);    (01, 12, false);    (01, 13, false);    (01, 14, false);

                        (02, 00, false);    (02, 01, false);    (02, 02, false);    (02, 03, false);    (02, 04, true );
                        (02, 05, true );    (02, 06, false);    (02, 07, false);    (02, 08, false);    (02, 09, true );
                        (02, 10, true );    (02, 11, false);    (02, 12, false);    (02, 13, false);    (02, 14, false);

                        (03, 00, false);    (03, 01, false);    (03, 02, false);    (03, 03, false);    (03, 04, false);
                        (03, 05, false);    (03, 06, false);    (03, 07, false);    (03, 08, false);    (03, 09, false);
                        (03, 10, false);    (03, 11, false);    (03, 12, false);    (03, 13, false);    (03, 14, false);

                        (04, 00, true );    (04, 01, true );    (04, 02, true );    (04, 03, false);    (04, 04, false);
                        (04, 05, true );    (04, 06, true );    (04, 07, false);    (04, 08, true );    (04, 09, true );
                        (04, 10, false);    (04, 11, false);    (04, 12, true );    (04, 13, true );    (04, 14, true );

                        (05, 00, false);    (05, 01, false);    (05, 02, true );    (05, 03, false);    (05, 04, true );
                        (05, 05, false);    (05, 06, true );    (05, 07, false);    (05, 08, true );    (05, 09, false);
                        (05, 10, true );    (05, 11, false);    (05, 12, true );    (05, 13, false);    (05, 14, false);

                        (06, 00, false);    (06, 01, false);    (06, 02, false);    (06, 03, false);    (06, 04, true );
                        (06, 05, true );    (06, 06, false);    (06, 07, false);    (06, 08, false);    (06, 09, true );
                        (06, 10, true );    (06, 11, false);    (06, 12, false);    (06, 13, false);    (06, 14, false);

                        (07, 00, false);    (07, 01, false);    (07, 02, false);    (07, 03, false);    (07, 04, false);
                        (07, 05, false);    (07, 06, false);    (07, 07, false);    (07, 08, false);    (07, 09, false);
                        (07, 10, false);    (07, 11, false);    (07, 12, false);    (07, 13, false);    (07, 14, false);

                        (08, 00, false);    (08, 01, false);    (08, 02, false);    (08, 03, false);    (08, 04, true );
                        (08, 05, true );    (08, 06, false);    (08, 07, false);    (08, 08, false);    (08, 09, true );
                        (08, 10, true );    (08, 11, false);    (08, 12, false);    (08, 13, false);    (08, 14, false);

                        (09, 00, false);    (09, 01, false);    (09, 02, true );    (09, 03, false);    (09, 04, true );
                        (09, 05, false);    (09, 06, true );    (09, 07, false);    (09, 08, true );    (09, 09, false);
                        (09, 10, true );    (09, 11, false);    (09, 12, true );    (09, 13, false);    (09, 14, false);

                        (10, 00, true );    (10, 01, true );    (10, 02, true );    (10, 03, false);    (10, 04, false);
                        (10, 05, true );    (10, 06, true );    (10, 07, false);    (10, 08, true );    (10, 09, true );
                        (10, 10, false);    (10, 11, false);    (10, 12, true );    (10, 13, true );    (10, 14, true );

                        (11, 00, false);    (11, 01, false);    (11, 02, false);    (11, 03, false);    (11, 04, false);
                        (11, 05, false);    (11, 06, false);    (11, 07, false);    (11, 08, false);    (11, 09, false);
                        (11, 10, false);    (11, 11, false);    (11, 12, false);    (11, 13, false);    (11, 14, false);

                        (12, 00, false);    (12, 01, false);    (12, 02, false);    (12, 03, false);    (12, 04, true );
                        (12, 05, true );    (12, 06, false);    (12, 07, false);    (12, 08, false);    (12, 09, true );
                        (12, 10, true );    (12, 11, false);    (12, 12, false);    (12, 13, false);    (12, 14, false);

                        (13, 00, false);    (13, 01, false);    (13, 02, false);    (13, 03, false);    (13, 04, true );
                        (13, 05, false);    (13, 06, false);    (13, 07, false);    (13, 08, false);    (13, 09, false);
                        (13, 10, true );    (13, 11, false);    (13, 12, false);    (13, 13, false);    (13, 14, false);

                        (14, 00, false);    (14, 01, false);    (14, 02, false);    (14, 03, false);    (14, 04, true );
                        (14, 05, false);    (14, 06, false);    (14, 07, false);    (14, 08, false);    (14, 09, false);
                        (14, 10, true );    (14, 11, false);    (14, 12, false);    (14, 13, false);    (14, 14, false);
                    ]

            let alternateOne () = [ [|1|];[|4|];[|7|]; ]