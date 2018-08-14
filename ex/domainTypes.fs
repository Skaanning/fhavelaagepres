module Cart = 
    type Quantity = Quantity of int
    type PaymentId = PaymentId of int

    type Payment = {
        PaymentId: PaymentId
        Amount: decimal }

    type Item = { 
        SKU: string 
        quantity: Quantity }

    type ActiveCartData = {
        Items: Item list } 

    type PaidCartData = {
        PaidItems: Item list
        Payment: Payment }

    type ShoppingCart =      
        | Empty  // no data     
        | Active of ActiveCartData     
        | Paid of PaidCartData 


// Cart API
    let init item = 
        Active { Items = [item] }

    let add cartData item = 
        Active { cartData with Items = item :: cartData.Items } 

    let remove cart item =  
        let remainingItems = cart.Items |> List.filter (fun x -> x <> item)      
        match remainingItems with     
            | [] -> Empty     
            | _ -> Active {cart with Items = remainingItems} 

    let pay cart payment =
        // do some payment stuff...
        Paid { PaidItems = cart.Items; Payment = payment}

// Use API
module CartController = 
    let addItem cart item =
        match cart with 
        | Cart.Empty -> Cart.init item
        | Cart.Active cartData -> Cart.add cartData item
        | Cart.Paid paidData -> failwith "Cannot write code that complies to add to a paidCart..."   // And thats nice :)

    let removeItem cart item =
        match cart with
        | Cart.Empty -> failwith "????" //  no way to do this.
        | Cart.Active cartData -> Cart.remove cartData item
        | Cart.Paid paidData -> failwith "????" // no way to remove from paid

    let payForCart cart payment =
        match cart with
        | Cart.Empty -> failwith "????" //  cannot pay for empty basket.. Now what.
        | Cart.Active cartData -> Cart.pay cartData payment
        | Cart.Paid paidData -> failwith "????" // cannot pay for already paid basket. does not compile.
