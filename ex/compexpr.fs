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