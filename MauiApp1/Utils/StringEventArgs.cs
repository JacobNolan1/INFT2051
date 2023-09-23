using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Utils
{
    internal class StringEventArgs : EventArgs
    {
        public string Data { get; }

        public StringEventArgs(string data)
        {
            Data = data;
        }
    }
}
