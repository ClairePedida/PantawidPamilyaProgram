using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PantawidPamilyaProgram.Models
{
    public class Pppp
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength = 20)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [StringLength(6, MinimumLength = 1)]
        [Required]
        public string Gender { get; set; } = string.Empty;
        [StringLength(200, MinimumLength = 20)]
        [Required]
        public string Address { get; set; } = string.Empty;
        public int Benificiaries { get; set; }


    }
}
