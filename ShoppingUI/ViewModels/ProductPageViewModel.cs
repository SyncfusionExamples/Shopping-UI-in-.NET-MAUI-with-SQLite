
using System;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Input;

namespace ShoppingUI
{
    public class ProductPageViewModel
    {
        public ObservableCollection<Items> Items { get; set; }

        public ObservableCollection<Items> CartItems { get; set; }

        public Items SelectedItem { get; set; }

        public ICommand Itemclick { get; set; }
        public ICommand CartItemclick { get; set; }
        public ProductPageViewModel(INavigation navigation)
        {
            Items = new ObservableCollection<Items>
            {
                new Items
                {
                    Picture="watch.png",
                    Name = "Cool Watch",
                    Quantity = "1",
                    Price = "$99"
                },
                new Items
                {
                    Picture="divingwatch.png",
                    Name = "Diving Watch",
                    Quantity = "1",
                    Price = "$89"
                },
                new Items
                {
                    Picture="dresswatch.png",
                    Name = "Dress Watch",
                    Quantity = "1",
                    Price = "$85"
                },
                new Items
                {
                    Picture="militarywatch.png",
                    Name = "Military Watch",
                    Quantity = "1",
                    Price = "$99"
                },
                new Items
                {
                    Picture="wristwatch.png",
                    Name = "Wrist Watch",
                    Quantity = "1",
                    Price = "$85"
                },
                new Items
                {
                    Picture="militarywatch.png",
                    Name = "Army Watch",
                    Quantity = "1",
                    Price = "$99"
                }
            };
            CartItems = new ObservableCollection<Items> { };
            Itemclick = new Command<Items>(executeitemclickcommand);
            CartItemclick = new Command<Items>(executeCartitemclickcommand);
            this.navigation = navigation;
        }
        private INavigation navigation;

        async void executeitemclickcommand(Items item)
        {
            this.SelectedItem = item;
            await navigation.PushModalAsync(new DetailsPage(this));
        }

        async void executeCartitemclickcommand(Items item)
        {
            this.CartItems.Add(this.SelectedItem);
            await navigation.PushModalAsync(new CartPage(this));

        }
    }
}
