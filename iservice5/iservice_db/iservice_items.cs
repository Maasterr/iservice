using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iservice5
{
    class iservice_items
    {
        public int iservice_items_id { get; set; }
        public string iservice_items_type { get; set; }
        public int iservice_items_category { get; set; }
        public int iservice_items_subcategory { get; set; }
        public string iservice_items_description { get; set; }
        public string iservice_items_purchase_price_netto { get; set; }
        public string iservice_items_purchase_price_brutto { get; set; }
        public string iservice_items_price_netto { get; set; }
        public string iservice_items_price_brutto { get; set; }
        public string iservice_items_employee { get; set; }
        public Nullable<System.DateTime> iservice_items_date_of_creation { get; set; }
        public Nullable<System.DateTime> iservice_items_last_update { get; set; }
     
    }
}
