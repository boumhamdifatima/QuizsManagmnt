using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionQuiz.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Answer = new HashSet<Answer>();
            QuestionQuiz = new HashSet<QuestionQuiz>();
        }
        
        [Key]
        [Column("quizID")]
        public int QuizId { get; set; }
        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty("Quiz")]
        public virtual ICollection<Answer> Answer { get; set; }
        [InverseProperty("Quiz")]
        public virtual ICollection<QuestionQuiz> QuestionQuiz { get; set; }
    }
}
