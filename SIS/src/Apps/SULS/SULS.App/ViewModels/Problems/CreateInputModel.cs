using SIS.MvcFramework.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace SULS.App.ViewModels.Problems
{
    public class CreateInputModel
    {
        private const string NameErrorMessage = "Name must be between 5 and 20 symbols long.";

        //private const string PointsErrorMessage = "Points must be between 50 and 300.";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [Range(50, 300)]
        public int Points { get; set; }
    }
}
