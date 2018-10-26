using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iservice5
{
    class iservice_orders
    {
        public int iservice_orders_id { get; set; }
        public int iservice_orders_cars_id { get; set; }
        public int iservice_orders_user_id { get; set; }
        public int iservice_orders_number { get; set; }
        public string iservice_orders_status_of_payment { get; set; }
        public string iservice_orders_payment_status_name { get; set; }
        public string iservice_orders_status_of_work { get; set; }
        public string iservice_orders_status_name { get; set; }
        public string iservice_orders_date_of_creation { get; set; }
        public string iservice_orders_date_of_last_update { get; set; }
        public string iservice_orders_expiry_date { get; set; }            
        public string iservice_orders_prepayment { get; set; }
        public string iservice_orders_total_netto { get; set; }
        public string iservice_orders_total_brutto { get; set; }
        public string iservice_orders_mileage { get; set; }


    }
}
