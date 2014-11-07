namespace FSharpGameOfLife

open System

module Constants = 
    
    let view () =
        Diagnostics.Process.Start("iexplore", "https://www.youtube.com/watch?v=J0Itc6v2rTo&t=0m53s") |> ignore

    let shortKey = "AMSG"
    let longKey = "ACCESS MAIN SECURITY GRID"
    let message = "access: PERMISSION DENIED....and..."
    let persistantMessage = "YOU DIDN'T SAY THE MAGIC WORD!"

