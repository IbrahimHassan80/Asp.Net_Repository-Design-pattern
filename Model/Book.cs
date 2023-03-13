using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required, MaxLength(250)] 
        public string Title { get; set; }
    
        public Author author { get; set; }

        public int AuthorId { get; set; }
    }
}