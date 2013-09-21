#region usings

using System.Web.Optimization;
using BundleTransformer.Core.Bundles;

#endregion

namespace SequelShack.Web.App_Start
{
  public static class BundleRegistrar
  {
    public static void Register(BundleCollection bundles)
    {
      var bootstrapCss = new CustomStyleBundle("~/bundles/bootstrap_css")
        .Include("~/Content/Css/lib/bootstrap/bootstrap.less")
        .Include("~/Content/Css/misc.less");
      bundles.Add(bootstrapCss);
    }
  }
}