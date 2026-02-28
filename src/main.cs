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
            Console.WriteLine(arg + ":" + " command not found");
        }
    }
}
