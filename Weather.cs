//Obten la API-KEY registrandote en https://openweathermap.org/
//Version del codigo 2.5 actualmente 

private static string GetWeather()
        {
            string CityName = "ve"; //acronimo del pais (Venezuela)
            string Estado = "Caracas"; //estado o region
            string lang = "es"; 
            string key = "API-KEY";
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + Estado + ","+ CityName + "&appid=" + key + "&lang=" + lang + "&units=" + "metric" + "&mode=" + "xml";
            XmlDocument Document = new XmlDocument();
            Document.Load(url);

            string temperatura = Document.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;
            string nubes = Document.DocumentElement.SelectSingleNode("weather").Attributes["value"].Value;
            string Clima = "La temperatura es de " + temperatura + "ºC." + Environment.NewLine + "Tipo de clima: " + nubes;

            return Clima;
        }
