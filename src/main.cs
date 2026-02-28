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
            else
            {
                Console.WriteLine(arg + ":" + " command not found");    
            }
        }
    }
}
