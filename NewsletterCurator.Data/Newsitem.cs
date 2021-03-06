﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsletterCurator.Data
{
    public class Newsitem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid ID { get; set; }
        [Required]
        public DateTimeOffset DateTime { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Guid CategoryID { get; set; }
        [Required]
        public string URL { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public bool IsAlreadySent { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
