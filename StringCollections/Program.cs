using System;
using System.Collections.Generic;

namespace StringCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() {
                "Quagsire", "Lando-T","T-Tar", "Lucario", "Quagsire" };

            Stack<string> stack = new Stack<string>();
            stack.Push("Quagsire");
            stack.Push("Lando-T");
            stack.Push("T-Tar");
            stack.Push("Lucario");
            stack.Push("Quagsire");

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Quagsire");
            queue.Enqueue("Lando-T");
            queue.Enqueue("T-Tar");
            queue.Enqueue("Lucario");
            queue.Enqueue("Quagsire");


            HashSet<string> hashset = new HashSet<string>() {
                "Quagsire", "Lando-T","T-Tar", "Lucario", "Quagsire" };


            Console.WriteLine("Collection contents:");
            Console.WriteLine("List:");
            foreach (string c in list)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Stack:");
            foreach (string c in stack)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();

            Console.WriteLine("Queue:");
            foreach (string c in queue)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();

            Console.WriteLine("HashSet:");
            foreach (string c in hashset)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();

















        }
    }
}
