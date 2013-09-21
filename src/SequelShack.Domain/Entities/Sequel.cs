#region usings

using System;

#endregion

namespace SequelShack.Domain.Entities
{
  public class Sequel : IEquatable<Sequel>
  {
    public Sequel()
    {
      CreatedAt = DateTime.UtcNow;
    }

    public virtual int Id { get; protected set; }
    public virtual Movie Movie { get; set; }
    public virtual string Title { get; set; }
    public virtual string Content { get; set; }
    public virtual User CreatedBy { get; set; }
    public virtual DateTime CreatedAt { get; protected set; }

    public virtual bool Equals(Sequel other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Id == other.Id;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as Sequel;
      return other != null && Equals(other);
    }

    public override int GetHashCode()
    {
      return Id;
    }

    public static bool operator ==(Sequel left, Sequel right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Sequel left, Sequel right)
    {
      return !Equals(left, right);
    }
  }
}