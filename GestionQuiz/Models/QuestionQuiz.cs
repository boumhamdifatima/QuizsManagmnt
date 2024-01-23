using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionQuiz.Models
{
    public partial class QuestionQuiz
    {
        [Key]
        [Column("questionID")]
        public int QuestionId { get; set; }
        [Key]
        [Column("quizID")]
        public int QuizId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty("QuestionQuiz")]
        public virtual Question Question { get; set; }
        [ForeignKey(nameof(QuizId))]
        [InverseProperty("QuestionQuiz")]
        public virtual Quiz Quiz { get; set; }
    }
}
