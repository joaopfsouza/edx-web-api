using System.Collections.Generic;
using System.Linq;

namespace WebServer.Models
{
    public class Repository
    {
        public static int Counter { get; set; }
        public static IList<Person> People { get; } = new List<Person>();

        public static Person GetPersonById(int id)
        {
            return People.SingleOrDefault(p => p.Id == id);
        }

        public static void RemovePersonById(int id)
        {
            var target = People.SingleOrDefault(p => p.Id == id);
            if (target != null)
            {

                People.Remove(target);
            }
        }

        public static void ReplacePersonById(int id, Person person)
        {

            var target = People.SingleOrDefault(p => p.Id == id);

            if (target != null)
            {

                People.Remove(target);
                People.Add(person);

            }
        }

        public static void AddPerson(Person person)
        {
            person.Id = Counter++;
            People.Add(person);
        }

    }
}