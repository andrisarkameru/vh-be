using System;
using System.Collections.Generic;
using System.Text;

namespace VH.Core.Transport
{
    public class AssetDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Identification { get; set; }
        public decimal BasePrice { get; set; }
        public string Properties { get; set; }

    }
}
