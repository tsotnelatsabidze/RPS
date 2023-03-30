using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    public class ConsolePresenter : IPresenter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string? text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
