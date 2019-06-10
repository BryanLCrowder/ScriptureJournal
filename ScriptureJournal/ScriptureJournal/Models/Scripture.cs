using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Book { get; set; }

        [Required]
        [StringLength(30)]
        public string Chapters { get; set; }

        [Required]
        [StringLength(30)]
        public string Verses { get; set; }

        [Required]
        [StringLength(500)]
        public string Note { get; set; }

        [Required]
        [Display(Name = "Date Added:")]
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }
    }
}
