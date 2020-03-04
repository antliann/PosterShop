using System;
using System.Collections.Generic;

namespace PosterShop
{
    public partial class Shops
    {
        public Shops()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Worktime { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
