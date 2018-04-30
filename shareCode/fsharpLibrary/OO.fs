namespace ObjectOrientatedInFsharp
open System


type AgeCalculator() =
    
        member x.GetAge(birthdate: DateTime) =
            let today = DateTime.Today
            today.Year - birthdate.Year
    
    
type Person(firstName: string, lastName: string, birthday: DateTime) =
    member this.FirstName = firstName
    member this.LastName = lastName
    member this.Birthday = birthday