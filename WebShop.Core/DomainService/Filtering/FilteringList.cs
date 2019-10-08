using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Core.DomainService.Filtering
{
    public class FilteringList <T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
