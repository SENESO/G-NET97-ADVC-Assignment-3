using ADV03.Helpers;

namespace ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager
            Console.WriteLine("==== Exercise 1: Student Grade Manager ====\n");

            List<int> grades = [85, 92, 78, 95, 88, 70, 100, 65];

            ConsoleHelper.PrintList("Grades", grades);
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First Grade: {grades[0]}, Last Grade: {grades[^1]}");

            grades.Sort();
            ConsoleHelper.PrintList("Sorted Grades", grades);

            int firstAbove90 = grades.Find(g => g > 90);
            Console.WriteLine($"First grade above 90: {firstAbove90}");

            List<int> failingGrades = grades.FindAll(g => g < 75);
            ConsoleHelper.PrintList("Failing Grades (< 75)", failingGrades);

            grades.RemoveAll(g => g < 75);
            ConsoleHelper.PrintList("After Removing Failing Grades", grades);

            bool has100 = grades.Contains(100);
            Console.WriteLine($"Contains Grade 100: {has100}");

            List<string> formattedGrades = grades.ConvertAll(g => $"Grade: {g}");
            ConsoleHelper.PrintList("Formatted Grades", formattedGrades);
            #endregion

            #region Exercise 2: Leaderboard
            Console.WriteLine("\n==== Exercise 2: Leaderboard ====\n");

            SortedDictionary<int, string> leaderboard = new()
            {
                { 500, "Ahmed" },
                { 200, "Sara" },
                { 800, "Ali" },
                { 350, "Mona" }
            };

            Console.WriteLine("Leaderboard (sorted by score):");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"  Score: {entry.Key} -> Player: {entry.Value}");
            }

            var firstEntry = leaderboard.First();
            Console.WriteLine($"First Key (Score): {firstEntry.Key}, First Value (Player): {firstEntry.Value}");

            Console.WriteLine($"Score 500 exists: {leaderboard.ContainsKey(500)}");

            if (leaderboard.TryGetValue(999, out string? player999))
                Console.WriteLine($"Player with score 999: {player999}");
            else
                Console.WriteLine("Player with score 999: Not found");

            leaderboard.Remove(200);
            Console.WriteLine("After removing player with score 200:");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"  Score: {entry.Key} -> Player: {entry.Value}");
            }
            #endregion

            #region Exercise 3: Phone Book
            Console.WriteLine("\n==== Exercise 3: Phone Book ====\n");

            Dictionary<string, string> phoneBook = new()
            {
                ["Ahmed"] = "01012345678",
                ["Sara"] = "01123456789",
                ["Ali"] = "01234567890",
                ["Mona"] = "01545678901"
            };

            phoneBook["Omar"] = "01099887766";
            Console.WriteLine($"Added Omar: {phoneBook["Omar"]}");

            try
            {
                phoneBook.Add("Ahmed", "01000000000");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception caught on Add(): {ex.Message}");
            }

            bool added = phoneBook.TryAdd("Ahmed", "01000000000");
            Console.WriteLine($"TryAdd(\"Ahmed\"): {added}");

            Console.WriteLine($"Search 'Kareem' exists: {phoneBook.ContainsKey("Kareem")}");

            string contact = phoneBook.GetValueOrDefault("Kareem", "Not Found");
            Console.WriteLine($"Contact 'Kareem': {contact}");

            Console.Write("Keys: ");
            foreach (string key in phoneBook.Keys)
                Console.Write($"{key} ");
            Console.WriteLine();

            Console.Write("Values: ");
            foreach (string val in phoneBook.Values)
                Console.Write($"{val} ");
            Console.WriteLine();
            #endregion

            #region Exercise 4: Unique Email Validator
            Console.WriteLine("\n==== Exercise 4: Unique Email Validator ====\n");

            HashSet<string> emails = new(StringComparer.OrdinalIgnoreCase);

            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine($"Emails Count: {emails.Count}");
            ConsoleHelper.PrintHashSet("Emails in HashSet", emails);
            Console.WriteLine("Stored 2 emails because case-insensitive comparer ignores duplicates.");

            HashSet<int> setA = [1, 2, 3, 4, 5];
            HashSet<int> setB = [4, 5, 6, 7, 8];
            ConsoleHelper.PrintHashSet("Set A", setA);
            ConsoleHelper.PrintHashSet("Set B", setB);

            HashSet<int> union = new(setA);
            union.UnionWith(setB);
            ConsoleHelper.PrintHashSet("A UnionWith B", union);

            HashSet<int> intersect = new(setA);
            intersect.IntersectWith(setB);
            ConsoleHelper.PrintHashSet("A IntersectWith B", intersect);

            HashSet<int> except = new(setA);
            except.ExceptWith(setB);
            ConsoleHelper.PrintHashSet("A ExceptWith B", except);

            HashSet<int> subset = [1, 2];
            Console.WriteLine($"Is {{1, 2}} a subset of Set A: {subset.IsSubsetOf(setA)}");
            #endregion

            #region Exercise 5: Print Queue Simulator
            Console.WriteLine("\n==== Exercise 5: Print Queue Simulator ====\n");

            Queue<string> printQueue = new();
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            ConsoleHelper.PrintQueue("Print Queue", printQueue);
            Console.WriteLine($"Queue Count: {printQueue.Count}");

            Console.WriteLine($"Next document to print (Peek): {printQueue.Peek()}");

            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {doc}");
            }

            if (printQueue.TryDequeue(out string? result))
                Console.WriteLine($"Dequeued: {result}");
            else
                Console.WriteLine("Queue is empty, TryDequeue returned false");
            #endregion

            #region Exercise 6: Browser History (Undo)
            Console.WriteLine("\n==== Exercise 6: Browser History (Undo) ====\n");

            Stack<string> browserHistory = new();

            browserHistory.Push("google.com");
            browserHistory.Push("github.com");
            browserHistory.Push("stackoverflow.com");
            browserHistory.Push("youtube.com");
            browserHistory.Push("claude.ai");

            Console.WriteLine($"Current page (Peek): {browserHistory.Peek()}");

            for (int i = 0; i < 3; i++)
            {
                string leftPage = browserHistory.Pop();
                Console.WriteLine($"Leaving: {leftPage}");
            }

            Console.WriteLine($"Current page after going back: {browserHistory.Peek()}");

            while (browserHistory.Count > 0)
            {
                browserHistory.Pop();
            }

            if (browserHistory.TryPop(out string? poppedPage))
                Console.WriteLine($"Popped: {poppedPage}");
            else
                Console.WriteLine("Stack is empty, TryPop returned false");
            #endregion
        }
    }
}
