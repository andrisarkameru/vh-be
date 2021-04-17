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
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int RentableItemId { get; set; }
        public string StatusBefore { get; set; }
        public string StatusAfter { get; set; }

        public virtual CustomerDTO Customer { get; set; }
        public virtual LocationDTO Location { get; set; }
        public virtual RentableItemDTO RentableItem { get; set; }
        public virtual List<PaymentDTO> Payment { get; set; }
    }
}
