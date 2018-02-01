using Abp.Web.Mvc.Views;

namespace MyAbpProject.Web.Views
{
    public abstract class MyAbpProjectWebViewPageBase : MyAbpProjectWebViewPageBase<dynamic>
    {

    }

    public abstract class MyAbpProjectWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MyAbpProjectWebViewPageBase()
        {
            LocalizationSourceName = MyAbpProjectConsts.LocalizationSourceName;
        }
    }
}