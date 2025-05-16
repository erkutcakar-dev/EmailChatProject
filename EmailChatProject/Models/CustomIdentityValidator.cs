using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmailChatProject.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = " Lütfen 1 Büyük Harf Girin"

            };

        }

        public override IdentityError PasswordRequiresLower()
        {


            return new IdentityError()

            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen En az bir küçük harf girin."

            };
        }

        
    }
}