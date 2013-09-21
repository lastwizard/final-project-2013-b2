#region usings

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Orm.Mappings
{
  public class SequelMapping : ClassMapping<Sequel>
  {
    public SequelMapping()
    {
      Id(x => x.Id, x => x.Generator(Generators.Identity));
      ManyToOne(x => x.Movie, x => x.Column("MovieId"));
      Property(x => x.Title);
      Property(x => x.Content, x => x.Type(NHibernateUtil.StringClob));
      ManyToOne(x => x.CreatedBy, x => x.Column("CreatedById"));
      Property(x => x.CreatedAt, x => x.Type(NHibernateUtil.DateTime2));
    }
  }
}