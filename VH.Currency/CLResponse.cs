using System;
using System.Collections.Generic;
using System.Text;

namespace VH.Currency
{
    public class CLResponse
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public int timestamp { get; set; }
        public string source { get; set; }
        public Dictionary<string,decimal> quotes { get; set; }
    }

}
