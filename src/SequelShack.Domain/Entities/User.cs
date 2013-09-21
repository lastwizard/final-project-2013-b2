using System.Collections.Generic;

namespace SequelShack.Domain.Entities
{
  public class User
  {
    public virtual int Id { get; set; }
    public virtual string Username { get; set; }
    public virtual string Email { get; set; }
    public virtual IEnumerable<Sequel> Sequels { get; protected set; }

    protected virtual bool Equals(User other)
    {
      return string.Equals(Username, other.Username);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as User;
      return other != null && Equals(other);
    }

    public override int GetHashCode()
    {
      return Username.GetHashCode();
    }

    public static bool operator ==(User left, User right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(User left, User right)
    {
      return !Equals(left, right);
    }

    public override string ToString()
    {
      return string.Format("{0}: {1}", Username, Email);
    }
  }
}