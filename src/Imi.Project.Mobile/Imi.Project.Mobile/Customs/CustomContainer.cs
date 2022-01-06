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
    public class CustomContainer : NavigationPage , IFreshNavigationService
    {
        BottomBarPage _innerTabbedPage;
        public BottomBarPage FirstTabbedPage { get { return _innerTabbedPage; } }

        readonly List<Page> _tabs = new List<Page>();
        public IEnumerable<Page> TabbedPages { get { return _tabs; } }

        public CustomContainer() : this(Constants.DefaultNavigationServiceName)
        {

        }

        public CustomContainer(string navigationServiceName) : base(new BottomBarPage())
        {
            NavigationServiceName = navigationServiceName;
            RegisterNavigation();
            _innerTabbedPage = (BottomBarPage)this.CurrentPage;
            SetHasNavigationBar(_innerTabbedPage, false);
            _innerTabbedPage.FixedMode = true;
        }

        protected void RegisterNavigation()
        {
            FreshIOC.Container.Register<IFreshNavigationService>(this, NavigationServiceName);
        }

        public virtual Page AddTab<T>(string title, string icon, object data = null) where T : FreshBasePageModel
        {
            var page = FreshPageModelResolver.ResolvePageModel<T>(data);
            page.GetModel().CurrentNavigationServiceName = NavigationServiceName;
            SetHasNavigationBar(page, false);
            _tabs.Add(page);
            var container = CreateNavigationPageSafe(page);
            container.Title = title;
            if (!string.IsNullOrWhiteSpace(icon))
                container.IconImageSource = icon;
            _innerTabbedPage.Children.Add(container);
            return container;
        }

        internal Page CreateNavigationPageSafe(Page page)
        {
            if (page is NavigationPage || page is TabbedPage)
                return page;

            return CreateNavigationPage(page);
        }

        protected virtual Page CreateNavigationPage(Page page)
        {
            ////return new NavigationPage(page);
            //var navpage = new NavigationPage(page);
            //NavigationPage.SetHasNavigationBar(navpage, false);
            return page;
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
                return this.Navigation.PopModalAsync(animate);
            return this.CurrentPage.Navigation.PopAsync(animate);
        }

        public Task PopToRoot(bool animate = true)
        {
            return this.Navigation.PopToRootAsync(animate);
        }

        public string NavigationServiceName { get; private set; }

        public void NotifyChildrenPageWasPopped()
        {
            foreach (var page in _innerTabbedPage.Children)
            {
                if (page is NavigationPage)
                    ((NavigationPage)page).NotifyAllChildrenPopped();
            }
        }

        public Task<FreshBasePageModel> SwitchSelectedRootPageModel<T>() where T : FreshBasePageModel
        {
            if (this.CurrentPage == _innerTabbedPage)
            {
                var page = _tabs.FindIndex(o => o.GetModel().GetType().FullName == typeof(T).FullName);
                if (page > -1)
                {
                    _innerTabbedPage.CurrentPage = this._innerTabbedPage.Children[page];
                    return Task.FromResult(_innerTabbedPage.CurrentPage.GetModel());
                }
            }
            else
            {
                throw new Exception("Cannot switch tabs when the tab screen is not visible");
            }

            return null;
        }
    }
}

