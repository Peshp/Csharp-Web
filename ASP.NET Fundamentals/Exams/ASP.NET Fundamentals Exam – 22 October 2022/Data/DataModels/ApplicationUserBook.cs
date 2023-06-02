﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.DataModels
{
    public class ApplicationUserBook
    {
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId  { get; set; }
        public ApplicationUser ApplicationUser  { get; set; }


        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
