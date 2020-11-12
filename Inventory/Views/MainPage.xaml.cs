using Newtonsoft.Json;
using RestSharp;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Inventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var client = new RestClient("https://tavortest.herokuapp.com/allitems");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<ItemEntry> itemjsonList = JsonConvert.DeserializeObject<List<ItemEntry>>(response.Content);
            Items.ItemsSource = itemjsonList;
        }
        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewItemPage());
        }
        async void Items_SelectionChanged(object s, SelectionChangedEventArgs e)
        {
           
            var item = (ItemEntry)e.CurrentSelection.FirstOrDefault();
            if (item != null)
            {
                await Navigation.PushAsync(new DetailItemPage(item));
            }

            // Clear selection
            Items.SelectedItem = null;
        }
    }
}