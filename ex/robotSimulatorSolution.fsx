type Direction = North | East | South | West

type Robot = {
    Name: string
    Position: int * int
    Direction: Direction 
}

type Instruction = L | R | A

let toInstruction = 
    function 
        | 'L' -> L
        | 'R' -> R
        | _ -> A

let parseInstructions (s:string) =
    s.ToCharArray() 
        |> Seq.map toInstruction 

let turnLeft = function
    | North -> West
    | East -> North
    | South -> East
    | West -> South

let turnRight = turnLeft << turnLeft << turnLeft

let advance robot =
    let x, y = robot.Position
    match robot.Direction with
    | North -> {robot with Position = x, y+1}
    | East -> {robot with Position = x+1, y}
    | South -> {robot with Position = x, y-1}
    | West -> {robot with Position = x-1, y}

// Robot -> Instruction -> Robot
let execute robot instruction = 
    match instruction with
    | L -> {robot with Direction = turnLeft robot.Direction} 
    | R -> {robot with Direction = turnRight robot.Direction} 
    | A -> advance robot

// Run the whole Shabang

let myRobot = {
   Name = "ROBOBOT 5000"
   Position = 10, 10
   Direction = West
}

let instructions = parseInstructions "RAAALARRAAAARAAAALRAARRRAL"  // [R; R; A; A; A; L; A; A; R; R; A; L; L; L; A; A; R]
let resultRobot =
    instructions 
    |> Seq.fold execute myRobot
