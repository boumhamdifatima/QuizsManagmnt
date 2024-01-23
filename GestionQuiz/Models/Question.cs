using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionQuiz.Models
{
    public partial class Question
    {
        public Question()
        {
            ItemOption = new HashSet<ItemOption>();
            QuestionQuiz = new HashSet<QuestionQuiz>();
        }

        [Key]
        [Column("questionID")]
        public int QuestionId { get; set; }
        [Column("text")]
        [StringLength(255)]
        public string Text { get; set; }
        [Column("categoryID")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Question")]
        public virtual Category Category { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<ItemOption> ItemOption { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<QuestionQuiz> QuestionQuiz { get; set; }
    }
}
