#region usings

using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

#endregion

namespace SequelShack.Domain.Entities
{
  public class Movie : IEquatable<Movie>
  {
    public Movie()
    {
      Characters = new HashedSet<Character>();
    }

    public virtual string Id { get; set; }
    public virtual int Version { get; protected set; }
    public virtual string Title { get; set; }
    public virtual int? Year { get; set; }
    public virtual string ProfilePosterUrl { get; set; }
    public virtual string DetailedPosterUrl { get; set; }
    public virtual string Synopsis { get; set; }
    public virtual Iesi.Collections.Generic.ISet<Character> Characters { get; protected set; }
    public virtual IEnumerable<Sequel> Sequels { get; protected set; }
    public virtual bool OnFrontPage { get; set; }

    public virtual bool Equals(Movie other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Id, other.Id);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as Movie;
      return other != null && Equals(other);
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public static bool operator ==(Movie left, Movie right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Movie left, Movie right)
    {
      return !Equals(left, right);
    }
  }
}