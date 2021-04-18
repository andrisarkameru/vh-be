using System;
using System.Collections.Generic;
using System.Text;

namespace VH.Core.Transport
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public string StatusBefore { get; set; }
        public string StatusAfter { get; set; }

        public CustomerDTO Customer { get; set; }
        
        
        public virtual LocationDTO Location { get; set; }
        public virtual AssetDTO Asset { get; set; }
        public virtual List<PaymentDTO> Payment { get; set; }
    }
}
