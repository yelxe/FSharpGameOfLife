namespace FSharpGameOfLife

open Screen

module Programs =
    
    [<EntryPoint>]
    let main argv = 
        
        showStart ()
        let response = prompt ()
        0
