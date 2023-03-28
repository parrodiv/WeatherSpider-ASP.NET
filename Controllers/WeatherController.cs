using System.Net;
using Microsoft.AspNetCore.Mvc;


namespace WeatherSpider.Controllers;

public class WeatherController : Controller
{
    public IActionResult Index()
    {
        var url = "https://meteostat.p.rapidapi.com/stations/monthly?station=10637&start=2020-01-01&end=2020-12-31";

        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";

        request.Headers["X-RapidAPI-Key"] = "8afbffc5e5mshc195410ab554382p191892jsnb0532d7d599b";
        request.Headers["X-RapidAPI-Host"] = "meteostat.p.rapidapi.com";

        try
        {
            using var webResponse = request.GetResponse();
            //...elabora la risposta HTTP...
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            Console.WriteLine(data);
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex);
        }

        
        // senza using
        /*WebResponse webResponse = null;
        try
        {
            webResponse = request.GetResponse();

            //...usa l'oggetto WebResponse per eseguire il codice desiderato
        }
        finally
        {
            if (webResponse != null)
            {
                webResponse.Dispose();
                // Dispose() serve per rilasciare le risorse non gestite dal Garbage Collector alla fine dell'operazione, altrimenti rimarrebbero in memoria,
                
            }
        }*/
        
       
        
        //n sintesi, il codice crea un oggetto Stream dalla risposta HTTP, un oggetto StreamReader per leggere i dati dallo Stream, e quindi legge tutti i dati dallo Stream e li assegna alla variabile "data".
        //In questo modo, l'applicazione .NET può leggere e utilizzare i dati ricevuti come risposta alla richiesta HTTP effettuata.
        
        return View();
    }
}