using APIDemoProject.Models;
using Microsoft.AspNetCore.Identity;

namespace APIDemoProject.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(Signup signUpModel);

        Task<string> LoginAsync(Login signInModel);
    }
}
