namespace FSharpGameOfLife

open Screen

module Programs =
    
    [<EntryPoint>]
    let main argv = 
        
        showStart ()
        showOptions ()

        let response = prompt ()
        0
