using Inventory.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace Inventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        private ItemEntry NewItemEntryRec { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            NewItemEntryRec = new ItemEntry();
            BindingContext = NewItemEntryRec;
        }
        void New_Clicked(object sender, EventArgs e)
        {

            Console.WriteLine("New item number: " + NewItemEntryRec.item_number);
            var client = new RestClient("https://tavortest.herokuapp.com/InsertItem");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            
            request.AddParameter("application/json", JsonConvert.SerializeObject(NewItemEntryRec), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            
        }
    }
}