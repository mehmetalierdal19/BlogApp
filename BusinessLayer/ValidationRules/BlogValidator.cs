using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog title cannot be empty.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog image cannot be empty.");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Please enter a blog title with a maximum of 150 characters.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please enter a name with a minimum of 5 characters.");
        }


    }
}
