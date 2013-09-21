#region usings

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Orm.Mappings
{
  public class UserMapping : ClassMapping<User>
  {
    public UserMapping()
    {
      Table("`User`");
      Id(x => x.Id, x => x.Generator(Generators.Identity));
      Property(x => x.Username);
      Property(x => x.Email);
      Set(
        x => x.Sequels,
        x =>
          {
            x.Inverse(true);
            x.Key(k => k.Column("CreatedById"));
          },
        x => x.OneToMany(m => m.Class(typeof (Sequel))));
    }
  }
}