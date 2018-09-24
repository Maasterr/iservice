using System;


namespace iservice5
{
    public class iservice_cars
    {
     

        public int iservice_cars_id { get; set; }
        public int iservice_cars_customers_id { get; set; }
        public string iservice_cars_reg_number { get; set; }
        public string iservice_cars_vin_number { get; set; }
        public string iservice_cars_brand { get; set; }
        public string iservice_cars_model { get; set; }
        public Nullable<int> iservice_cars_year { get; set; }
        public string iservice_cars_color { get; set; }
        public string iservice_cars_date_of_creation { get; set; }
        public string iservice_cars_employee { get; set; }

      
     //   public virtual ICollection<iservice_orders> iservice_orders { get; set; }
    }
}
