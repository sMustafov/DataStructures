namespace Problem1.StudentsAndCourses
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            return this.LastName.CompareTo(other.LastName);
        }
    }
}