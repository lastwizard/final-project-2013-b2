#region usings

using System.Linq;
using AutoMapper;
using Autofac;
using SequelShack.Web.Mapping.TypeConverters;

#endregion

namespace SequelShack.Web.IoC
{
  public class MappingModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(c => Mapper.Engine).As<IMappingEngine>();
      builder.RegisterAssemblyTypes(ThisAssembly).As<Profile>();
      RegisterTypeConverters(builder);
      RegisterValueResolvers(builder);
    }

    private void RegisterTypeConverters(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(ThisAssembly)
             .Where(t => t.GetInterfaces().Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == typeof (ITypeConverter<,>)))
             .AsSelf();
    }

    private void RegisterValueResolvers(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(ThisAssembly)
             .Where(t => t.IsAssignableTo<IValueResolver>())
             .AsSelf();
    }
  }
}