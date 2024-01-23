using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionQuiz.Models
{
    public partial class ItemOption
    {
        public ItemOption()
        {
            Answer = new HashSet<Answer>();
        }

        [Key]
        [Column("optionID")]
        public int OptionId { get; set; }
        [Column("text")]
        [StringLength(255)]
        public string Text { get; set; }
        [Column("isRight")]
        public bool IsRight { get; set; }
        [Column("questionID")]
        public int? QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty("ItemOption")]
        public virtual Question Question { get; set; }
        [InverseProperty("Option")]
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
