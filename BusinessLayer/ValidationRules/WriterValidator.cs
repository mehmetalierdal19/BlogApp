using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Writer name cannot be empty");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Writer email cannot be empty"); 
            RuleFor(x => x.Password).NotEmpty().WithMessage("Writer password cannot be empty");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please enter a name with a minimum of 2 characters");
        }
    }
}
