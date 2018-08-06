[<Measure>] type km
[<Measure>] type hour

let distance = 120.0<km>    
let time = 2.0<hour>    
let speed = distance / time


let invalid = speed + 5.0
let valid = speed + 5.0<km/hour> 

