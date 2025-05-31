using System.Diagnostics;
using static System.Console;

namespace SRP
{
    public class Journal
    {
        private readonly List<string> _entries = new List<string>();
        private static int _count = 0;
        public int AddEntry(string text)
        {
            _entries.Add($"{++_count}: {text}");
            return _count; //memonto
        }
        public void RemoveEntry(int index)
        {
            if (index < 0 || index >= _entries.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid entry index.");
            _entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }     
    }
    class JournalPersistence
    {
        public static void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (!File.Exists(filename) || !overwrite)
            {
                File.WriteAllText(filename, journal.ToString());
            }

        }
    }
    public class Demo
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var entry1 = journal.AddEntry("I learned about the Single Responsibility Principle today.");
            var entry2 = journal.AddEntry("I implemented a simple journal class in C#.");
            WriteLine(journal);
            JournalPersistence.SaveToFile(journal,"journal.txt");
           Process.Start(new ProcessStartInfo("notepad.exe", "journal.txt") { UseShellExecute = true });
            // Uncomment to test loading functionality
            // journal.Load("journal.txt");
        }
    }
}
