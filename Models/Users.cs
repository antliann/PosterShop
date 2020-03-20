using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosterShop
{
    public partial class Users
    {
        public Users()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }

        [RegularExpression("+380[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "Введите номер в формате +380XXXXXXXXX")]
        [Display(Name="Номер телефона")]
        public string Telephone { get; set; }

        [RegularExpression("[а-Я]+[а-Я ]*", ErrorMessage = "Неверно введены фамилия и имя")]
        [Display(Name = "Фамилия и имя")]
        public string Name { get; set; }

        [RegularExpression("/.*([a-z]+[A-Z]+[0-9]+|[a-z]+[0-9]+[A-Z]+|[A-Z]+[a-z]+[0-9]+|[A-Z]+[0-9]+[a-z]+|[0-9]+[a-z]+[A-Z]+|[0-9]+[A-Z]+[a-z]+).*/",
            ErrorMessage = "Минимум одна цифра, одна заглавная и одна строчная латинские буквы")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
