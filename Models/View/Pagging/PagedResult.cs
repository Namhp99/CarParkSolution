using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Pagging
{
    public class PagedResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { get; set; }
    }
}
