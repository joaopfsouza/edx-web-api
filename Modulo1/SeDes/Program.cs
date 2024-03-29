﻿using System;
using Newtonsoft.Json;

namespace SeDes
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = DoSerialization();
            System.Console.WriteLine(json);
            System.Console.WriteLine("================");
            DoDeserialization(json);
        }

        // Serialize a Rocket array to JSON string
        public static string DoSerialization()
        {

            Rocket[] rockets = {
        new Rocket{ Id = 0, Builder = "NASA", Target = "Moon", Speed=7.8},
        new Rocket{ Id = 1, Builder = "NASA", Target = "Mars", Speed=10.9},
        new Rocket{ Id = 2, Builder = "NASA", Target = "Kepler-452b", Speed=42.1},
        new Rocket{ Id = 3, Builder = "NASA", Target = "N/A", Speed=0}
    };

            var json = JsonConvert.SerializeObject(rockets);
            return json;

        }

        // Deserialize a JSON string back to a Rocket array
        public static void DoDeserialization(string json)
        {
            // var rockets = JsonConvert.DeserializeObject<Rocket[]>(json);
            // foreach (var r in rockets)
            // {
            //     System.Console.WriteLine($"ID:{r.Id} Builder:{r.Builder} Target:{r.Target} Speed:{r.Speed}");
            // }

            var ufos = JsonConvert.DeserializeObject<UFO[]>(json);
            foreach (var ufo in ufos)
            {
                System.Console.WriteLine($"Target:{ufo.Target} Speed:{ufo.Id}");
            }
        }
    }


}