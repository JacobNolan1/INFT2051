using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Utils
{
    class NavigationManager
    {
        public static NavigationPage NavigationPage { get; private set; }

        public static void Initialize(NavigationPage navigationPage)
        {
            NavigationPage = navigationPage;
        }
    }
}
