using static System.Console;
namespace ISP
{
    // Interface Segregation Principle (ISP) Example
    public class Document {
    } 
    public interface IMachine:IPrinter, IFax, IScanner
    {
     
    }
    public interface IPrinter
    {
        public void Print(Document d);
    }
    public interface IFax
    {
        public void Fax(Document d);
    }
    public interface IScanner
    {
        public void Scan(Document d);
        public void PhotoCopy(Document d);
    }
  
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            WriteLine("Printing document...");
        }
        public void Fax(Document d)
        {
            WriteLine("Faxing document...");
        }
        public void Scan(Document d)
        {
            WriteLine("Scanning document...");
        }
        public void PhotoCopy(Document d)
        {
            WriteLine("Photocopying document...");
        }
    }
    public class SimplePrinter : IPrinter
    {
        public void Print(Document d)
        {
            WriteLine("Printing document...");
        }
        // Not applicable methods throw an exception
      
    }
    public class Program
    {
        public static void Main(string[] args)
        {
           
        }
    }
}