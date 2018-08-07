// single line comments use a double slash

// ======== "Variables" (but not really) ==========
// The "let" keyword defines an (immutable) value
let myInt = 5
let myFloat = 3.14
let myString = "hello"  //note that no types needed

// single "=" is NOT assignment but equallity 
myString = "goodbye" // this is false

// assignment to variable can be done with "<-"
// But only if you have declared your variable with the mutable keyword.
// So,   myString <- "goodbye"    Does not compile
let mutable myString2 =  "hello" 
myString2 <- "goodbye"


// ======== Lists ============
let twoToFive = [2;3;4;5]        // Square brackets create a list with
                                 // semicolon delimiters.
let oneToTen = [1..10] // list of one two... ten
let everyOther = [1..2..10] // [1;3;5;7;9] - 1 is starting point, 2 is step size, 10 is end point
let oneToFive = 1 :: twoToFive   // :: creates list with the element prepended
let zeroToFive = [0;1] @ twoToFive   // @ concats two lists

// IMPORTANT: commas are never used as delimiters, only semicolons!



// ======== Functions ========
// The "let" keyword also defines a named function.
let square x = x * x          // Note that no parens are used.
square 3                      // Now run the function. Again, no parens.

let add x y = x + y           // don't use add (x,y)! It means something
                              // completely different.
add 2 3                       // Now run the function.


// Partial application (currying)
// you can partially apply a function by only giving it some of its parameters
let add5 = add 5 // calling add function with only one param - so add5 is now a one param funcition that adds 5 to the input


// Function composition - Stick two functions together into a new function
let add5ThenSquare = add5 << square

add5ThenSquare 3

// to define a multiline function, just use indents. No semicolons needed.
let evens list =
   let isEven x = x % 2 = 0   // Define "isEven" as an inner ("nested") function
   List.filter isEven list    // List.filter is a library function
                              // with two parameters: a boolean function
                              // and a list to work on

evens oneToFive               // Now run the function

// You can use parens to clarify precedence. In this example,
// do "map" first, with two args, then do "sum" on the result.
// Without the parens, "List.map" would be passed as an arg to List.sum
let sumOfSquaresTo100 =
   List.sum ( List.map square [1..100] )

// You can pipe the output of one operation to the next using "|>"
// Here is the same sumOfSquares function written using pipes
let sumOfSquaresTo100piped =
   [1..100] 
   |> List.map square   // "square" was defined earlier 
   |> List.sum  

// you can define lambdas (anonymous functions) using the "fun" keyword
let sumOfSquaresTo100withFun =
   [1..100] |> List.map (fun x -> x * x) |> List.sum

// In F# returns are implicit -- no "return" needed. A function always
// returns the value of the last expression used.

// ======== Printing to console =========== 

// example of printf formats  
printfn "A string: %s. An int: %i. A float: %f. A bool: %b" "hello" 42 3.14 true

// sprintf uses the same formats but returns the string instead of printing it to console
let someString = sprintf "hello %s - number is %i" "world" 42

// ======== "foreach" loop =========== 
let loop = 
    for number in [0..10] do
        printf "%i" number

// ======== if else expressions ==========

let isAorB x = 
    if x = "a" then                 // if SOME EXPR then ...
        "x is 'a'"        
    elif x = "b" then "x is 'b'"    // else if is written as elif
    else "x is something else"      

// NOTE that if / else is not a Statement like in C#
// It's an expression - meaning it returns a value. 
// This also means that each branch of the if / else needs to return the same type.


/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////// Fizz Buzz woooo /////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
let fizzbuzz numbers = 
// implement me.


fizzbuzz [1..30] // implement fizzbuzz and run this