using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swapi_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://swapi.dev/api/people/1/").Result;
            
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Person personResponse = response.Content.ReadAsAsync<Person>().Result;
            Console.WriteLine(personResponse.Name);
            Console.WriteLine(personResponse.Created);
            

            SwapiService service = new SwapiService();
            Person person = service.GetPersonAsync("https://swapi.dev/api/people/3/").Result;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Height);

            Person samePerson = service.GetAsAsync<Person>("https://swapi.dev/api/people/3/").Result;
            Console.WriteLine(samePerson.Name);
            Console.WriteLine(samePerson.Height);

            Console.ReadKey();
        }
    }
}
