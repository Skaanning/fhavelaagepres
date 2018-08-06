namespace FsharpLibrary
open System

module Calculate =
    
    let add x y = x + y

    let mult x y = x * y

    let square x = mult x x

    type Maybe<'t> = 
            | Some of 't
            | None
            
    let maybeString = Some "hello world"