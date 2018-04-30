open FSharp.Data

let url = "https://en.wikipedia.org/wiki/2017_FIA_Formula_One_World_Championship"
type grandPrix2017 = HtmlProvider<"https://en.wikipedia.org/wiki/2017_FIA_Formula_One_World_Championship">

let grandPrix = grandPrix2017.Load(url).Tables.``Grands Prix``

let belgianWinner = grandPrix.Rows 
                    |> Seq.where (fun x -> x.``Grand Prix`` = "Belgian Grand Prix")
                    |> Seq.map (fun x -> x.``Winning driver``) 
                    |> Seq.head
            



type cryptoCurrencies = HtmlProvider<"https://coinmarketcap.com/">

let current = cryptoCurrencies.Load("https://coinmarketcap.com/").Tables.Currencies.Rows

printf "%A" current