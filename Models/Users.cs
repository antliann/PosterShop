using System;
using System.Collections.Generic;

namespace PosterShop
{
    public partial class Users
    {
        public Users()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }
        public string Telephone { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
