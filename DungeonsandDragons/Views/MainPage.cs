using System;

using Xamarin.Forms;

namespace DungeonsandDragons
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page monstersPage, itemsPage, aboutPage, gamePage= null;
            Page heroPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    heroPage = new NavigationPage(new HeroesPage())
                    {
                        Title = "Heroes"
                    };
                    monstersPage = new NavigationPage(new MonstersPage())
                    {
                        Title = "Monsters"
                    };
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Items"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    gamePage = new NavigationPage(new GamePage())
                    {
                        Title = "Game"
                    };
                    monstersPage.Icon = "tab_feed.png";
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    gamePage.Icon = "tab_about.png";
                    break;
                default:
                    heroPage = new HeroesPage()
                    {
                        Title = "Heroes"
                    };
                    monstersPage = new MonstersPage()
                    {
                        Title = "Monsters"
                    };
                    itemsPage = new ItemsPage()
                    {
                        Title = "Items"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    gamePage = new GamePage()
                    {
                        Title = "Game"
                    };
                    break;
            }

            Children.Add(heroPage);
            Children.Add(monstersPage);
            Children.Add(itemsPage);
            Children.Add(aboutPage);
            Children.Add(gamePage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
