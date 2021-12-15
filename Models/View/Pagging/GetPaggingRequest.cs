using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Pagging
{
    public class GetPaggingRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }
    }
}
