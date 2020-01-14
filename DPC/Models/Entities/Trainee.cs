using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.Models.Entities
{
    public class Trainee
    {
        [Key]
        public int TraineeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public Deanery Deanery { get; set; }
        [Required]
        public string Parish { get; set; }
        public Pathway Pathway { get; set; }
        public DateTime DateAdded { get; set; }
    }


    public enum Deanery
    {
        Kabba,
        Lokoja,
        Okene
    }

    public enum Pathway
    {
        [Display(Name = "Evangelization")]
        Evangelization = 0,
        [Display(Name ="Spirituality")]
        Spirituality = 1,
        [Display(Name = "Catechesis")]
        Catechesis =2,
        [Display(Name ="Lay Apostolate and Leadership")]
        Lay_Apostolate_and_Leadership = 3,
        [Display(Name = "Marriage and Family Life")]
        Marriage_and_Family_Life = 4,
        [Display(Name = "Liturgy and Divine Worship")]
        Liturgy_and_Divine_Worship = 5
    }
}
