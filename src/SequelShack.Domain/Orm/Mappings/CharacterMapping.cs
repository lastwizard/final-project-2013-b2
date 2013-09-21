#region usings

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Orm.Mappings
{
  public class CharacterMapping : ClassMapping<Character>
  {
    public CharacterMapping()
    {
      Id(x => x.Id, x => x.Generator(Generators.HighLow, gm => gm.Params(new {max_lo = "255"})));
      ManyToOne(x => x.Movie, mto => mto.Column("MovieId"));
      ManyToOne(x => x.Actor, mto => mto.Column("ActorId"));
      Property(x => x.Name);
    }
  }
}