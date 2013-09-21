#region usings

using System;

#endregion

namespace SequelShack.Domain.Entities
{
  public class Character : IEquatable<Character>
  {
    public virtual int Id { get; protected set; }
    public virtual Movie Movie { get; set; }
    public virtual Actor Actor { get; set; }
    public virtual string Name { get; set; }

    public virtual bool Equals(Character other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Equals(Movie, other.Movie) && Equals(Actor, other.Actor) && string.Equals(Name, other.Name);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as Character;
      return other != null && Equals(other);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = Movie.GetHashCode();
        hashCode = (hashCode * 397) ^ Actor.GetHashCode();
        hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
        return hashCode;
      }
    }

    public static bool operator ==(Character left, Character right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Character left, Character right)
    {
      return !Equals(left, right);
    }
  }
}