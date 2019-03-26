using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Net;

namespace Swapi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                List<Pearson> characters = new List<Pearson>();

                while (true)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pearson>));
                    using (var fileStream = new FileStream("pearson.xml", FileMode.OpenOrCreate))
                    {
                        characters = (List<Pearson>)xmlSerializer.Deserialize(fileStream);
                    }

                    Console.WriteLine("Insert Id character");
                    int characterId;

                    if (int.TryParse(Console.ReadLine(), out characterId))
                    {
                        bool isExists = false;
                        foreach (var pearson in characters)
                        {
                            if (pearson.Id == characterId)
                            {
                                isExists = true;
                                PrintPerson(pearson);
                            }
                        }

                        if (!isExists)
                        {
                            try
                            {
                                string json = client.DownloadString("https://swapi.co/api/people/" + characterId);
                                Pearson result = JsonConvert.DeserializeObject<Pearson>(json);
                                result.Id = characterId;
                                characters.Add(result);
                                PrintPerson(result);

                                XmlSerializer tryXmlSerializer = new XmlSerializer(typeof(List<Pearson>));

                                using (var fileStream = new FileStream("pearson.xml", FileMode.OpenOrCreate))
                                {
                                    tryXmlSerializer.Serialize(fileStream, characters);
                                }
                            }
                            catch (WebException)
                            {
                                Console.Clear();
                                continue;
                            }
                        }
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }
        static public void PrintPerson(Pearson pearson)
        {
            Console.WriteLine("Id: " + pearson.Id);
            Console.WriteLine("Name: " + pearson.Name);
            Console.WriteLine("Height: " + pearson.Height);
            Console.WriteLine("Mass: " + pearson.Mass);
            Console.WriteLine("Hair_color: " + pearson.HairColor);
            Console.WriteLine("Skin_color: " + pearson.SkinColor);
            Console.WriteLine("Eye_color: " + pearson.EyeColor);
            Console.WriteLine("Birth_year: " + pearson.BirthYear);
            Console.WriteLine("Gender: " + pearson.Gender);
            Console.WriteLine("Homeworld: " + pearson.Homeworld);

            Console.WriteLine("Films: ");
            foreach (var film in pearson.Films)
                Console.WriteLine("   " + film);

            Console.WriteLine("Species: ");
            foreach (var Specie in pearson.Species)
                Console.WriteLine("   " + Specie);

            Console.WriteLine("Vehicles: ");
            foreach (var Vehicle in pearson.Vehicles)
                Console.WriteLine("   " + Vehicle);

            Console.WriteLine("Starships: ");
            foreach (var Starship in pearson.Starships)
                Console.WriteLine("   " + Starship);

            Console.WriteLine("Created: " + pearson.Created);
            Console.WriteLine("Edited: " + pearson.Edited);
            Console.WriteLine("Url: " + pearson.Url);
        }
    }
    
}
