using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosterShop
{
    public partial class Posters
    {
        public Posters()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }

        [RegularExpression("Posters/Images/.+jpg", ErrorMessage = "Недействительная ссылка")]
        [Display(Name = "Путь к изображению")]
        public string Path { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!"), Range(0, 100000, ErrorMessage = "Неверная цена")]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Display(Name = "Тема")]
        public int TopicId { get; set; }

        public virtual Topics Topic { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
