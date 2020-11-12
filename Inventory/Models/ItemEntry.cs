using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models
{
    public class ItemEntry
    {
        public string item_id { get; set; }
        public string item_number { get; set; }
        public string item_description { get; set; }
        public DateTime expire_date { get; set; }
    }
}
