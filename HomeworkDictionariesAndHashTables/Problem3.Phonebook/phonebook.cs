namespace Problem3.Phonebook
{
    using System;
    using System.Collections.Generic;

    class Phonebook
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            string inputLine = Console.ReadLine();

            for (int i = 0; i < inputLine.Length; i++)
            {
                string[] input = inputLine.Split('-');
                string name = input[0];
                string phoneNumber = input[1];

                phonebook[name] = phoneNumber;

                inputLine = Console.ReadLine();
                if (inputLine == "search")
                {
                    break;
                }
            }

            while (inputLine != "end")
            {
                inputLine = Console.ReadLine();

                if (phonebook.ContainsKey(inputLine))
                {
                    Console.WriteLine("{0} -> {1}", inputLine, phonebook[inputLine]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", inputLine);
                }
            }
        }
    }
}
