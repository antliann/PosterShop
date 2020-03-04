using System;
using System.Collections.Generic;

namespace PosterShop
{
    public partial class Reservations
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int ShopId { get; set; }
        public int UserId { get; set; }
        public int PosterId { get; set; }

        public virtual Posters Poster { get; set; }
        public virtual Shops Shop { get; set; }
        public virtual Users User { get; set; }
    }
}
