class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("$ ");
            string arg = Console.ReadLine();
            if (arg == "exit")
            {
                break;
            }
            else if (arg.StartsWith("echo"))
            {
                Console.WriteLine(arg.Substring(5));
            }
            else if (arg.StartsWith("type"))
            {
                string commandTarget = arg.Substring(5);
                switch (commandTarget)
                {
                    case "echo":
                    case "exit":
                    case "type":
                        Console.WriteLine($"{commandTarget} is a shell builtin");
                        break;
                    default:
                        Console.WriteLine(commandTarget + ":" + " command not found");
                        break;
                }
            }
            else
            {
                Console.WriteLine(arg + ":" + " command not found");    
            }
        }
    }
}
