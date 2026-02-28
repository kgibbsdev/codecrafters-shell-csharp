class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("$ ");
            string arg = Console.ReadLine();
            Console.WriteLine(arg + ":" + " command not found");
        }
    }
}
