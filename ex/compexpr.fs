// creating a "safe" divide by functtion
let divideBy bot top = // revesered param order of what you would expect.. Makes it intuitive to pipe 
  match bot with
  | 0 -> None
  | _ -> Some(top / bot)

// infix version
let (=/) top bot = 
  match bot with
  | 0 -> None
  | _ -> Some(top / bot)

let number = divideBy 5 10
let number1 = 10 |> divideBy 0 
let number2 = 10 =/ 5
let number3 = 10 =/ 0


// Annoying pyramid of doom 
let myNumber = 
  let x = 24 |> divideBy 2
  match x with
  | None -> None
  | Some x ->   
      let y = x |> divideBy 2
      match y with
      | None -> None
      | Some y -> 
          let z = y |> divideBy 3
          match z with 
          | None -> None
          | Some z -> Some z

// If only there were a better way


type OptionBuilder() =
    member this.Bind(m, f) = 
        printfn "Binding..."
        match m with
        | None -> None
        | Some x -> f x
    member this.Return(x) = 
        printfn "Wrapping a raw value into an option"
        Some x
    member this.ReturnFrom(m) = 
        printfn "Returning an option directly"
        m

let option = new OptionBuilder()
let someValue = 
  option {
    let! x = 24 |> divideBy 2
    let! y = x |> divideBy 2 
    let! z = y |> divideBy 3 

    return z
  }







type FizzBuzzSequenceBuilder() =

  member x.Yield(v) =
    match (v % 3, v % 5) with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> v.ToString()

  member x.Delay(f) = f() |> Seq.singleton

  member x.Delay(f : unit -> string seq) = f()

  member x.Combine(l, r) =
    Seq.append (Seq.singleton l) (Seq.singleton r)

  member x.Combine(l, r) =
    Seq.append (Seq.singleton l) r

  member x.For(g, f) = Seq.map f g


let FizzBuzz = new FizzBuzzSequenceBuilder()

let result = FizzBuzz { 
    for x in [1..30] do 
      yield x
}


Seq.toList result
