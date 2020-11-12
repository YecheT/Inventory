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
    public partial class DetailItemPage : ContentPage
    {
        public DetailItemPage(ItemEntry entry)
        {
            InitializeComponent();
            item_id.Text = entry.item_id;
            expire_date.Text = entry.expire_date.ToString("M");
            item_number.Text = entry.item_number;
            item_description.Text = entry.item_description;
        }
    }
}