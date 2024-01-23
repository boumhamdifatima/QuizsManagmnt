using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionQuiz.Models
{
    public partial class Answer
    {
        [Key]
        [Column("answerID")]
        public int AnswerId { get; set; }
        [Column("optionID")]
        public int? OptionId { get; set; }
        [Column("quizID")]
        public int? QuizId { get; set; }

        [ForeignKey(nameof(OptionId))]
        [InverseProperty(nameof(ItemOption.Answer))]
        public virtual ItemOption Option { get; set; }
        [ForeignKey(nameof(QuizId))]
        [InverseProperty("Answer")]
        public virtual Quiz Quiz { get; set; }
    }
}
