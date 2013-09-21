#region usings

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Orm.Mappings
{
  public class ActorMapping : ClassMapping<Actor>
  {
    public ActorMapping()
    {
      Id(x => x.Id,
         x =>
           {
             x.Generator(Generators.Assigned);
             x.UnsavedValue(null);
           });
      Version(x => x.Version, vm => vm.UnsavedValue(0));
      Property(x => x.Name);
    }
  }
}