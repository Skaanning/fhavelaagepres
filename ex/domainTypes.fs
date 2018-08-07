type CustomerNo = CustomerNo of string

type Customer = {
    Name: string
    CustomerNumber: CustomerNo
} 

let value (CustomerNo x) = x

let getCustomer customerNo = 
    let customerNumber = value customerNo
    // so some real logic, like  try to find in db
    if (customerNumber = "")  
        then None
        else Some {Name = "Bob"; CustomerNumber = customerNo} 

let myCustomer = 
    let customer = CustomerNo "1234" |> getCustomer
    match customer with
    | None -> printfn "Found no customer"
    | Some cust -> cust |> printfn "%A"  




// see https://fsharpforfunandprofit.com/posts/designing-with-types-single-case-dus/ for more realworldy examples