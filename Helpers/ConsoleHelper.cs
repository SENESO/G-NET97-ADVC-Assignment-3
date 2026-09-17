namespace ADV03.Helpers
{
    internal static class ConsoleHelper
    {
        public static void PrintList<T>(string listName, List<T> items)
        {
            Console.WriteLine($"{listName} : [{string.Join(", ", items)}]");
        }

        public static void PrintHashSet<T>(string setName, HashSet<T> items)
        {
            Console.WriteLine($"{setName} : [{string.Join(", ", items)}]");
        }

        public static void PrintQueue<T>(string queueName, Queue<T> items)
        {
            Console.WriteLine($"{queueName} : [{string.Join(", ", items)}]");
        }

        public static void PrintStack<T>(string stackName, Stack<T> items)
        {
            Console.WriteLine($"{stackName} : [{string.Join(", ", items)}]");
        }

        public static void PrintCollection<T>(string colName, IEnumerable<T> items)
        {
            Console.WriteLine($"{colName} : [{string.Join(", ", items)}]");
        }
    }
}
