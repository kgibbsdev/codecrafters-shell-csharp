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
                string commandTarget = arg.Substring(5).Trim();
                // Console.WriteLine("commandTarget: " + commandTarget);
                switch (commandTarget)
                {
                    case "echo":
                    case "exit":
                    case "type":
                        Console.WriteLine($"{commandTarget} is a shell builtin");
                        break;
                    default:
                        // Console.WriteLine(commandTarget + ":" + " not found");
                        var pathVars = System.Environment.GetEnvironmentVariable("PATH");
                        var paths = pathVars.Split(":");
                        bool found = false;
                        for (int i = 0; i < paths.Length; i++)
                        {
                            var currentPath = paths[i];
                            if (!Directory.Exists(currentPath))
                            {
                                continue;
                            }

                            var filePath = Path.Combine(currentPath, commandTarget);
                            if (File.Exists(filePath))
                            {
                               var mode = File.GetUnixFileMode(filePath);
                               if ((mode & (UnixFileMode.UserExecute | UnixFileMode.GroupExecute |
                                            UnixFileMode.OtherExecute)) != 0)
                               {
                                   Console.WriteLine(commandTarget + " is " + filePath);
                                   found = true;
                                   break;
                               }
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine(commandTarget + ":" + " not found");   
                        }

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
