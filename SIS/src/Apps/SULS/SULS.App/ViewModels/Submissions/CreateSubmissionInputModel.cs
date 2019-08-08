﻿using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Submissions
{
    public class CreateSubmissionInputModel
    {
        private const string CodeErrorMessage = "Code must be between 30 and 800 symbols long.";

        [RequiredSis]
        [StringLengthSis(30, 800, CodeErrorMessage)]
        public string Code { get; set; }
    }
}
