using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class MainClass {
    static async Task Main() {
        HttpClient client = new HttpClient();
        
        // 1. Requisição GET na API
        string response = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/age-counting");

        // 2. Deserializa o JSON para obter o valor da chave "data"
        JObject json = JObject.Parse(response);
        string dataContent = json["data"].ToString();

        // 3. Quebrar a string por vírgulas para isolar os itens
        string[] items = dataContent.Split(',');

        // 4. Lógica de contagem usando LINQ
        // Filtramos os itens que começam com " age=" (atenção ao espaço), 
        // pegamos o valor após o '=' e convertemos para int.
        int count = items
            .Where(item => item.Contains("age="))
            .Select(item => int.Parse(item.Split('=')[1]))
            .Count(age => age >= 50);

        // 5. Saída Final
        Console.WriteLine(count);
    }
}