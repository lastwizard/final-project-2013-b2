#region usings

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Orm.Mappings
{
  public class MovieMapping : ClassMapping<Movie>
  {
    public MovieMapping()
    {
      Id(x => x.Id,
         x =>
           {
             x.Generator(Generators.Assigned);
             x.UnsavedValue(null);
           });
      Version(x => x.Version, vm => vm.UnsavedValue(0));
      Property(x => x.Title);
      Property(x => x.Year);
      Property(x => x.ProfilePosterUrl);
      Property(x => x.DetailedPosterUrl);
      Property(x => x.Synopsis, x => x.Type(NHibernateUtil.StringClob));
      Set(x => x.Characters,
          x =>
            {
              x.Inverse(true);
              x.Key(km => km.Column("MovieId"));
              x.OrderBy(c => c.Id);
            },
          x => x.OneToMany(otm => otm.Class(typeof (Character))));
      Set(x => x.Sequels,
          x =>
          {
            x.Inverse(true);
            x.Key(km => km.Column("MovieId"));
            x.Lazy(CollectionLazy.Extra);
            x.OrderBy("CreatedAt DESC");
          },
          x => x.OneToMany(otm => otm.Class(typeof(Sequel))));
      Property(x => x.OnFrontPage);
    }
  }
}