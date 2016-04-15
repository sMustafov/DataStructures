namespace RopeForStringEditing
{
    using System;
    using Wintellect.PowerCollections;

    class RopeForStringEditing
    {
        static void Main()
        {
            BigList<string> text = new BigList<string>();

            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');
            string command = tokens[0].Trim();
            string message = tokens[1].Trim();
            bool isNotPrint = true;

            while (isNotPrint)
            {
                switch (command)
                {
                    case "INSERT":
                        text.AddToFront(message);
                        Console.WriteLine("OK");
                        break;
                    case "APPEND":
                        text.Add(message);
                        Console.WriteLine("OK");
                        break;
                    case "DELETE":
                        text.Remove(message);
                        Console.WriteLine("OK");
                        break;
                    case "PRINT":
                        foreach (var m in text)
                        {
                            Console.Write(m + " ");
                        }
                        Console.WriteLine();
                        isNotPrint = false;
                        return;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

                input = Console.ReadLine();
                tokens = input.Split(' ');
                command = tokens[0].Trim();
                if (command != "PRINT")
                {
                    message = tokens[1].Trim();
                }
            }
        }
    }
}
