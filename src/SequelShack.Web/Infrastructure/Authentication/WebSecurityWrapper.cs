#region usings

using NHibernate;
using SequelShack.Domain.Entities;
using WebMatrix.WebData;

#endregion

namespace SequelShack.Web.Infrastructure.Authentication
{
  public class WebSecurityWrapper : IWebSecurity
  {
    private readonly ISession _nhSession;
    private User _currentUser;

    public WebSecurityWrapper(ISession nhSession)
    {
      _nhSession = nhSession;
    }

    public User GetCurrentUser(bool refresh = false)
    {
      if (WebSecurity.IsAuthenticated && WebSecurity.HasUserId)
      {
        if (refresh || _currentUser == null)
        {
          return (_currentUser = _nhSession.Get<User>(WebSecurity.CurrentUserId));
        }

        return _currentUser;
      }

      return null;
    }

    public bool SignIn(string username, string password, bool createPersistentCookie = false)
    {
      return WebSecurity.Login(username, password, createPersistentCookie);
    }

    public void SignOut()
    {
      WebSecurity.Logout();
    }

    public void CreateUserAndAccount(string username, string email, string password, bool requireConfirmationToken = false)
    {
      WebSecurity.CreateUserAndAccount(username, password, new {Email = email}, requireConfirmationToken);
    }
  }
}