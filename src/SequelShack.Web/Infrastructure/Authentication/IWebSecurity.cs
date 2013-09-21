#region usings

using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Web.Infrastructure.Authentication
{
  public interface IWebSecurity
  {
    User GetCurrentUser(bool refresh = false);
    bool SignIn(string username, string password, bool createPersistentCookie = false);
    void SignOut();
    void CreateUserAndAccount(string username, string email, string password, bool requireConfirmationToken = false);
  }
}