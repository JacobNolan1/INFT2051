using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Utils
{
    public class MainPageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MainPageTemplate { get; set; }
        public DataTemplate OtherPageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is bool isMainPage && isMainPage)
            {
                return MainPageTemplate;
            }
            else
            {
                return OtherPageTemplate;
            }
        }
    }
}
