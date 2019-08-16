﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Submission
    {
        public string Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set;}
        
        public Problem Problem { get; set; }
        public string ProblemId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
