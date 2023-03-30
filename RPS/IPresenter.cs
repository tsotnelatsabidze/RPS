using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    public interface IPresenter
    {
        void Write(string text);
        void WriteLine(string text);

        void WriteLine();

    }
}
