using static System.Console;
namespace DIP
{
        public enum Relationship
        {
            Parent,
            Child,
            Sibling
        }
        public class Person
        {
            public string Name { get; set; }
            public Person(string name)
            {
                Name = name;
            }
        }
        public class Reationships : IReadRelationships
    {
            private List<(Person, Relationship, Person)> _relations = new List<(Person, Relationship, Person)>();
            public void AddParentAndChild(Person parent, Person child)
            {
                _relations.Add((parent, Relationship.Parent, child));
                _relations.Add((child, Relationship.Child, parent));
            }
            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return _relations
                    .Where(r => r.Item1.Name == name && r.Item2 == Relationship.Parent)
                    .Select(r => r.Item3);
            }
        }
    public interface IReadRelationships
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
    public class Program
    {
        static List<string> FindChildrenOf(string name, IReadRelationships relationships)
        {
            return relationships.FindAllChildrenOf(name).Select(c => c.Name).ToList();
        }
        public static void Main(string[] args)
        {
            Person parent = new("Ahmed");
            Person child1 = new("Ali");
            Person child2 = new("Fatima");
            Reationships relationships = new();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            WriteLine($"Children of {parent.Name}:");
            foreach (var child in FindChildrenOf( parent.Name,relationships))
            {
                WriteLine(child);
            }
        }
    }
}