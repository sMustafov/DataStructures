namespace Problem1.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class PlayingWithStudentsAndCourses
    {
        static void Main()
        {
            SortedDictionary<string,SortedSet<Person>> persons = 
                new SortedDictionary<string, SortedSet<Person>>();

            var reader = 
                new StreamReader("../../students.txt");

            using (reader)
            {
                var input = reader.ReadLine();
                while (input != null)
                {
                    var inputLine = input.Split('|');
                    string firstName = inputLine[0].Trim();
                    string lastName = inputLine[1].Trim();
                    string course = inputLine[2].Trim();

                    var person = new Person(firstName, lastName);
                    if (!persons.ContainsKey(course))
                    {
                        persons[course] = new SortedSet<Person>();
                    }
                    persons[course].Add(person);

                    input = reader.ReadLine();
                }
            }

            foreach (var person in persons)
            {
                Console.WriteLine("{0}: {1}", person.Key,
                    string.Join(", ",person.Value.Select(s => s.FirstName + " " + s.LastName)));
            }
        }
    }
}
