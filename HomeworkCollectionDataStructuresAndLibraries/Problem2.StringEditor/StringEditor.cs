namespace Problem2.StringEditor
{
    using System;
    using Wintellect.PowerCollections;

    class StringEditor
    {
        static void Main()
        {
            var text = new BigList<char>();

            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');
            string command = tokens[0].Trim();
            string message = tokens[1].Trim();
            bool isNotTheEnd = true;

            while (isNotTheEnd)
            {
                switch (command)
                {
                    case "INSERT":
                        message = tokens[2].Trim();
                        int pos = int.Parse(tokens[1].Trim());
                        for (int i = 0; i < message.Length; i++)
                        {
                            if (pos >= text.Count)
                            {
                                Console.WriteLine("ERROR");
                                break;
                            }
                            if (i == 0)
                            {
                                text.Insert(pos, message[i]);
                            }
                            else
                            {
                                text.Insert(pos, message[i]);
                            }
                            pos++;
                        }
                        Console.WriteLine("OK");
                        break;
                    case "APPEND":
                        message = null;
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            message += tokens[i];
                            message += " ";
                        }
                        message = message.Trim();
                        for (int i = 0; i < message.Length; i++)
                        {
                            text.Add(message[i]);
                        }
                        Console.WriteLine("OK");
                        break;
                    case "DELETE":
                        int startIndex = int.Parse(tokens[1].Trim());
                        int count = int.Parse(tokens[2].Trim());
                        if (startIndex >= text.Count || count > text.Count - startIndex)
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }

                        text.RemoveRange(startIndex, count);
                        Console.WriteLine("OK");
                        break;
                    case "REPLACE":
                        startIndex = int.Parse(tokens[1]);
                        count = int.Parse(tokens[2]);
                        message = tokens[3];
                        if (startIndex >= text.Count || count > text.Count - startIndex)
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                        text.RemoveRange(startIndex, count);
                        if (count > message.Length)
                        {
                            count = message.Length;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            text.Insert(startIndex, message[i]);
                            startIndex++;
                        }
                        break;
                    case "PRINT":
                        foreach (var m in text)
                        {
                            Console.Write(m);
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

                input = Console.ReadLine();
                if (input == "END")
                {
                    return;
                }

                tokens = input.Split(' ');
                command = tokens[0];
            }
        }
    }
}
