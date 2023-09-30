using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Utils
{
    public class PageTracker
    {
        public Type viewType;
        public ContentView view;
        public int pageNumber;
        public PageTracker previousPage;
        public PageTracker nextPage;

        public PageTracker(Type viewType, int pageNumber)
        {
            if (typeof(ContentView).IsAssignableFrom(viewType))
            {
                this.viewType = viewType;
            }
            else
            {
                throw new ArgumentException("Type must be a subclass of ContentView");
            }
            this.pageNumber = pageNumber;
        }
        public void newView()
        {
            this.view = (ContentView)Activator.CreateInstance(viewType);
        }
    }
}
