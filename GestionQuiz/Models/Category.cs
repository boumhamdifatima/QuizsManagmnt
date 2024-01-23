using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionQuiz.Models
{
    public partial class Category
    {
        public Category()
        {
            Question = new HashSet<Question>();
        }

        [Key]
        [Column("categoryID")]
        public int CategoryId { get; set; }
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
