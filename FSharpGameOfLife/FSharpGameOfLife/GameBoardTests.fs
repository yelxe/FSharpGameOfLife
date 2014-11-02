namespace FSharpGameOfLife

open NUnit.Framework
open FsUnit
open GameBoard
open Patterns

module ``T:GameBoard`` =

    module ``addToBoard`` =
        
        [<Test>]
        let ``Should Return a Board That Matches the Pattern``() =
            addToBoard [] Block |> should equal [(0, 0); (0, 1); (1, 0); (1, 1)]

        [<Test>]
        let ``Should Return a Board With Two Patterns`` () =
            addToBoard [(5, 5); (5, 6)] Block |> should equal [(0, 0); (0, 1); (1, 0); (1, 1); (5, 5); (5, 6)]

    module ``staggerPattern`` =
        
        [<Test>]
        let ``Should Return Staggered Block`` () =
            staggerPattern Block (2, 2) |> should equal [(2, 2); (2, 3); (3, 2); (3, 3)]

        [<Test>]
        let ``Should Return Staggered Beehive`` () =
            staggerPattern Beehive (2, 2) |> should equal [(2, 3); (2, 4); (3, 2); (3, 5); (4, 3); (4, 4)]
