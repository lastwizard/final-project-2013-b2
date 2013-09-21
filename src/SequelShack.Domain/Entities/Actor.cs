#region usings

using System;

#endregion

namespace SequelShack.Domain.Entities
{
  public class Actor : IEquatable<Actor>
  {
    public virtual string Id { get; set; }
    public virtual int Version { get; protected set; }
    public virtual string Name { get; set; }

    public virtual bool Equals(Actor other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Id, other.Id);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as Actor;
      return other != null && Equals(other);
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public static bool operator ==(Actor left, Actor right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Actor left, Actor right)
    {
      return !Equals(left, right);
    }
  }
}