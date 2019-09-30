using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class EmployeeView
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не должно быть пустым")]
        [Display(Name = "Имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "В именни не должно быть менее 2 и более 200")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не должно быть пустым")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Возраст")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательно")]
        public int Age { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
