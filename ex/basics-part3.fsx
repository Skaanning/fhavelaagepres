

// Record types have named fields. Semicolons or newlines are separators.
type Person = {
    First:string
    Last:string }

let john = {   
    First="john" 
    Last="Doe" }

john.First
john.Last

let betterJohn = { john with Last = "Wick" }

// Union types have choices. Vertical bars are separators.
type Temp = 
    | DegreesC of float
    | DegreesF of float
let temp = DegreesF 98.6

// Generic
type MyOption<'t> = 
    | Something of 't
    | Nothing

let somethingString = Something "hello"
let nothing = Nothing

let myFunction x = 
    match x with
    | Something x -> x
    | Nothing -> "I got nothing"

// Types can be combined recursively in complex ways.
// E.g. here is a union type that contains a list of the same type:
type Employee = 
  | Worker of Person
  | Manager of Name: string * Employees: Employee list
let jdoe = {First="John";Last="Doe"}
let worker = Worker jdoe
let manager = Manager ("Bob", [worker])

// ========= Printing =========
// The printf/printfn functions are similar to the
// Console.Write/WriteLine functions in C#.
printfn "Printing an int %i, a float %f, a bool %b" 1 2.0 true
printfn "A string %s, and something generic %A" "hello" [1;2;3;4]

let twoTuple = "hello", 5

// all complex types have pretty printing built in
printfn "twoTuple=%A,\nPerson=%A,\nTemp=%A,\nEmployee=%A" 
         twoTuple john temp worker

// There are also sprintf/sprintfn functions for formatting data
// into a string, similar to String.Format.


