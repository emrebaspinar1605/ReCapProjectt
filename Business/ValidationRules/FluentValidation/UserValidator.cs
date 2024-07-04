using Business.Constant;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(30);

            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).MaximumLength(30);

            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(2);
            RuleFor(u => u.Email).MaximumLength(30);
            RuleFor(u => u.Email).Must(ContainsComet);
            RuleFor(u => u.Email).Must(ContainsDotCom);

            //RuleFor(u => u.Password).NotNull();
            //RuleFor(u => u.Password).NotEmpty();
            //RuleFor(u => u.Password).MinimumLength(4);
            //RuleFor(u => u.Password).MaximumLength(16);
            //RuleFor(u => u.Password).Must(ContainsSpecialChar).WithMessage(Messages.PassMustContainSpecialChar);
            //RuleFor(u => u.Password).Must(ContainsBigLetter).WithMessage(Messages.PassMustContainBigLetter);
            //RuleFor(u => u.Password).Must(ContainLetterAndDigit).WithMessage(Messages.PassMustContainLetterAndDigit);
        }

        private bool ContainsSpecialChar(string arg)
        {
            char[] privateChar = { '?', '@', '!', '#', '%', '+', '-', '_', '*', '_', '|' };

            foreach (var chara in privateChar)
            {
                if (arg.Contains(chara))
                {
                    return arg.Contains(chara);
                }
            }
            return false;
        }

        private bool ContainsDotCom(string arg)
        {
            return arg.Contains(".com");
        }

        private bool ContainsComet(string arg)
        {
            return arg.Contains("@");
        }
        private bool ContainsBigLetter(string arg)
        {
            return arg.Any(char.IsUpper);
        }
        private bool ContainLetterAndDigit(string arg)
        {
            bool containsLetter = arg.Any(char.IsLetter);
            bool containsDigit = arg.Any(char.IsDigit);
            return containsLetter && containsDigit;
        }
    }
   
}
