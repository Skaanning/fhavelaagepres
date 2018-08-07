#r @"..\Fsharp.Data\bin\lib\net45\FSharp.Data.dll"

open FSharp.Data


let apiUrl = sprintf "http://api.openweathermap.org/data/2.5/weather?q=%s&units=metric&APPID=a942c636b9333edb8f79b79495d800f9"
type WeatherProvider = JsonProvider<"http://api.openweathermap.org/data/2.5/weather?q=london&units=metric&APPID=a942c636b9333edb8f79b79495d800f9">

let london = WeatherProvider.GetSample()

// try it out
london.Main.Temp
london.Wind.Speed

let aarhusUrl = apiUrl "aarhus"
let aarhus = WeatherProvider.Load(aarhusUrl)



type WeatherForMultiple = JsonProvider<"weather.json">

let moscowAndKiev = WeatherForMultiple.Load("http://api.openweathermap.org/data/2.5/group?id=524901,703448&units=metric&APPID=a942c636b9333edb8f79b79495d800f9")
moscowAndKiev.List
    |> Seq.map (fun city -> city.Name)

// where is it warmer?
// more windy?


////////////////////////////////////////////////////////////////////////////////////////
let url = "https://en.wikipedia.org/wiki/2017_FIA_Formula_One_World_Championship"
type grandPrix2017 = HtmlProvider<"https://en.wikipedia.org/wiki/2017_FIA_Formula_One_World_Championship">

let grandPrix = grandPrix2017.Load(url).Tables.``Grands Prix``

let belgianWinner = grandPrix.Rows 
                    |> Seq.where (fun x -> x.``Grand Prix`` = "Belgian Grand Prix")
                    |> Seq.map (fun x -> x.``Winning driver``) 
                    |> Seq.head
            


/////////////////////////////////////////////////////////////////////////////////////////
type cryptoCurrencies = HtmlProvider<"https://coinmarketcap.com/">

let current = cryptoCurrencies.Load("https://coinmarketcap.com/").Tables.Currencies.Rows

printf "%A" current

let first = Seq.head current
first.Name