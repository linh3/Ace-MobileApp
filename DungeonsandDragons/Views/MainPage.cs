using System;

using Xamarin.Forms;

namespace DungeonsandDragons
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page monstersPage, itemsPage, aboutPage, gamePage,heroesPage, scoresPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    heroesPage = new NavigationPage(new HeroesPage())
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
                    scoresPage = new NavigationPage(new ScorePage())
                    {
                        Title = "Scores"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    gamePage = new NavigationPage(new GamePage())
                    {
                        Title = "Game"
                    };
                    heroesPage.Icon = "tab_feed.png";
                    scoresPage.Icon = "tab_feed.png";
                    monstersPage.Icon = "tab_feed.png";
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    gamePage.Icon = "tab_about.png";
                    break;
                default:
                    heroesPage = new HeroesPage()
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
                    scoresPage= new ScorePage()
                    {
                        Title = "Scores"
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
            Children.Add(gamePage);
            Children.Add(heroesPage);
            Children.Add(monstersPage);
            Children.Add(itemsPage);
            Children.Add(scoresPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
