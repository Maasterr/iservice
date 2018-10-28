using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iservice5
{
    class iservice_orders_items
    {
        public int iservice_orders_items_id { get; set; }
        public int iservice_orders_items_orders_id { get; set; }
        public int iservice_orders_item_id { get; set; }
        public string iservice_orders_items_qty { get; set; }
        public string iservice_orders_items_price_netto { get; set; }
        public string iservice_orders_items_price_brutto { get; set; }

    }
}
