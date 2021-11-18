using BottomBar.XamarinForms;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Customs
{
    public class CustomContainer : BottomBarPage , IFreshNavigationService
    {
        List<Page> _tabs = new List<Page>();
        public IEnumerable<Page> TabbedPages { get { return _tabs; } }

        public CustomContainer() : this(Constants.DefaultNavigationServiceName)
        {
            
        }

        public CustomContainer(string navigationServiceName)
        {
            NavigationServiceName = navigationServiceName;
            RegisterNavigation();
        }

        protected void RegisterNavigation()
        {
            FreshIOC.Container.Register<IFreshNavigationService>(this, NavigationServiceName);
        }

        public virtual Page AddTab<T>(string title, string icon, object data = null) where T : FreshBasePageModel
        {
            var page = FreshPageModelResolver.ResolvePageModel<T>(data);
            page.GetModel().CurrentNavigationServiceName = NavigationServiceName;
            NavigationPage.SetHasNavigationBar(page, false);
            _tabs.Add(page);
            var NavigationNavigation = CreateNavigationPageSafe(page);
            NavigationNavigation.Title = title;
            if (!string.IsNullOrWhiteSpace(icon))
                NavigationNavigation.IconImageSource = icon;
            Children.Add(NavigationNavigation);
            return NavigationNavigation;
        }

        internal Page CreateNavigationPageSafe(Page page)
        {
            if (page is NavigationPage || page is TabbedPage)
                return page;

            return CreateNavigationPage(page);
        }

        protected virtual Page CreateNavigationPage(Page page)
        {
            return new NavigationPage(page);
        }

        public System.Threading.Tasks.Task PushPage(Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                return this.CurrentPage.Navigation.PushModalAsync(CreateNavigationPageSafe(page));
            return this.CurrentPage.Navigation.PushAsync(page);
        }

        public System.Threading.Tasks.Task PopPage(bool modal = false, bool animate = true)
        {
            if (modal)
                return this.CurrentPage.Navigation.PopModalAsync(animate);
            return this.CurrentPage.Navigation.PopAsync(animate);
        }

        public Task PopToRoot(bool animate = true)
        {
            return this.CurrentPage.Navigation.PopToRootAsync(animate);
        }

        public string NavigationServiceName { get; private set; }

        public void NotifyChildrenPageWasPopped()
        {
            foreach (var page in this.Children)
            {
                if (page is NavigationPage)
                    ((NavigationPage)page).NotifyAllChildrenPopped();
            }
        }

        public Task<FreshBasePageModel> SwitchSelectedRootPageModel<T>() where T : FreshBasePageModel
        {
            var page = _tabs.FindIndex(o => o.GetModel().GetType().FullName == typeof(T).FullName);

            if (page > -1)
            {
                CurrentPage = this.Children[page];
                var topOfStack = CurrentPage.Navigation.NavigationStack.LastOrDefault();
                if (topOfStack != null)
                    return Task.FromResult(topOfStack.GetModel());

            }
            return null;
        }
    }
}

