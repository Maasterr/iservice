using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace iservice5
{
    class DataService
    {
        public static List<iservice_customers> GetAllCustomers()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_customers>("Select * from iservice_customers").ToList();
            }
        }
         public static List<iservice_customers> NewCustomer(String iservice_customers_name,String iservice_customers_surname,String iservice_customers_patronymic, String iservice_customers_country, String iservice_customers_city, String iservice_customers_street, String iservice_customers_zipcode, String iservice_customers_telephone, String iservice_customers_telephone_home, String iservice_customers_date_of_birthday, String iservice_customers_email, String iservice_customers_date_of_creation,String iservice_customers_employee, String iservice_customers_company)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
               db.Execute("Insert into iservice_customers values (N'"+ iservice_customers_name + "',N'" + iservice_customers_surname + "',N'" + iservice_customers_patronymic +" ',N'" + iservice_customers_country + " ',N'" + iservice_customers_city + " ',N'" + iservice_customers_street + " ',N'" + iservice_customers_zipcode + " ','" + iservice_customers_telephone +" ',' " + iservice_customers_telephone_home + " ','"+ iservice_customers_date_of_birthday+" ','" + iservice_customers_email +" ','"+ iservice_customers_date_of_creation + " ',N'" + iservice_customers_employee + " ',N'" + iservice_customers_company+ " ')");
                return null;
            }
        }
        public static List<iservice_customers> EditCustomerById(int iservice_customers_id, String iservice_customers_name,String iservice_customers_surname,String iservice_customers_patronymic, String iservice_customers_country, String iservice_customers_city, String iservice_customers_street, String iservice_customers_zipcode, String iservice_customers_telephone, String iservice_customers_telephone_home, String iservice_customers_date_of_birthday, String iservice_customers_email, String iservice_customers_date_of_creation,String iservice_customers_employee, String iservice_customers_company)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
               db.Execute("Update iservice_customers set iservice_customers_name = N'" + iservice_customers_name + "',iservice_customers_surname = N'" + iservice_customers_surname + "',iservice_customers_patronymic = N'" + iservice_customers_patronymic + " ',iservice_customers_country = N'" + iservice_customers_country + " ',iservice_customers_city = N'" + iservice_customers_city + " ',iservice_customers_street=N'" + iservice_customers_street + " ',iservice_customers_zipcode = N'" + iservice_customers_zipcode + " ',iservice_customers_telephone='" + iservice_customers_telephone + " ',iservice_customers_telephone_home = '" + iservice_customers_telephone_home + " ',iservice_customers_date_of_birthday='" + iservice_customers_date_of_birthday+ " ',iservice_customers_email='" + iservice_customers_email + " ',iservice_customers_date_of_creation='" + iservice_customers_date_of_creation+ " ',iservice_customers_employee=N'" + iservice_customers_employee + " ',iservice_customers_company=N'" + iservice_customers_company + " ' where iservice_customers_id ='" + iservice_customers_id + " '");
                return null;
            }
        }
        public static List<iservice_customers> GetCustomersByWord(String word)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_customers>("SELECT * FROM  iservice_customers WHERE(iservice_customers_name LIKE '%' + N'" +word +"' + '%') OR (iservice_customers_surname LIKE '%' + N'"  + word  + "' +'%') OR (iservice_customers_telephone LIKE '%' + N'"  + word  + "' + '%') OR (iservice_customers_email LIKE '%' + N'"  + word  + "' + '%')").ToList();
            }
        }


        public static List<iservice_customers> GetCustomersById(int customers_id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_customers>("SELECT * FROM iservice_customers WHERE iservice_customers_id = " + customers_id).ToList();
            }
        }

 
        public static List<iservice_cars> NewCar(int iservice_cars_customers_id, String iservice_cars_reg_number, String iservice_cars_brand, String iservice_cars_model, String iservice_cars_vin, String iservice_cars_year, String iservice_cars_color, String iservice_cars_date_of_creation, String iservice_cars_employee)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Insert into iservice_cars values (N'" + iservice_cars_customers_id + "',N'" + iservice_cars_reg_number + "',N'" + iservice_cars_vin + " ',N'" + iservice_cars_brand + " ',N'" + iservice_cars_model + " ',N'" + iservice_cars_year + " ',N'" + iservice_cars_color + " ',N'" + iservice_cars_date_of_creation + " ',N'" + iservice_cars_employee + " ')");
                return null;
            }
        }
        public static List<iservice_cars> EditCar(int iservice_cars_id, String iservice_cars_reg_number, String iservice_cars_brand, String iservice_cars_model, String iservice_cars_vin, String iservice_cars_year, String iservice_cars_color)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Update iservice_cars set iservice_cars_reg_number=N'" + iservice_cars_reg_number + "',iservice_cars_vin_number=N'" + iservice_cars_vin + " ',iservice_cars_brand=N'" + iservice_cars_brand + " ',iservice_cars_model=N'" + iservice_cars_model + " ',iservice_cars_year=N'" + iservice_cars_year + " ',iservice_cars_color=N'" + iservice_cars_color + " ' where iservice_cars_id ='" + iservice_cars_id + " '");
                return null;
            }
        }
        public static List<iservice_cars> GetCarsByCustomer(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_cars>("SELECT iservice_cars.iservice_cars_brand, iservice_cars.iservice_cars_model, iservice_cars.iservice_cars_year, iservice_cars.iservice_cars_color, iservice_cars.iservice_cars_customers_id, iservice_cars.iservice_cars_reg_number, iservice_cars.iservice_cars_vin_number, iservice_cars.iservice_cars_id FROM iservice_cars INNER JOIN iservice_customers ON iservice_cars.iservice_cars_customers_id = iservice_customers.iservice_customers_id WHERE(iservice_cars.iservice_cars_customers_id = " + id+")").ToList();
            }
        }
        public static List<iservice_cars> NewOrder(int iservice_orders_cars_id, int iservice_orders_user_id,String iservice_orders_date_of_creation, String iservice_orders_date_of_last_update, String iservice_orders_expiry_date, String iservice_orders_status_of_payment, String iservice_orders_status_of_work,String iservice_orders_prepayment, String iservice_orders_total_netto,String iservice_orders_total_brutto,String iservice_orders_mileage)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Insert into iservice_orders values (N'" + iservice_orders_cars_id + "',N'" + iservice_orders_user_id + "',(Select MAX(iservice_orders_number)+1 from iservice_orders),N'" + iservice_orders_date_of_creation + " ',N'" + iservice_orders_date_of_last_update + " ',N'" + iservice_orders_expiry_date + " ',N'" + iservice_orders_status_of_payment + " ',N'" + iservice_orders_status_of_work + " ',N'" + iservice_orders_prepayment + "',N'" + iservice_orders_total_netto + "',N'" + iservice_orders_total_brutto + "',N'" + iservice_orders_mileage + "')");
                return null;
            }
        }
        public static List<iservice_orders> GetNewOrderNumber()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
               // List<iservice_orders> result();
                return db.Query<iservice_orders>("Select MAX(iservice_orders_number) from iservice_orders").ToList();

            }
        }
        public static List<iservice_orders> GetOrdersByCar(int cars_id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT iservice_orders.*,iservice_orders_status.iservice_orders_status_name FROM iservice_orders INNER JOIN iservice_orders_status ON iservice_orders.iservice_orders_status_of_work = iservice_orders_status.iservice_orders_status_id where iservice_orders.iservice_orders_cars_id = " + cars_id ).ToList();
            }
        }
        /*public static List<iservice_orders> GetOrdersByCar(int cars_id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT * FROM iservice_orders INNER JOIN iservice_cars ON iservice_orders.iservice_orders_cars_id = iservice_cars.iservice_cars_id WHERE(iservice_orders.iservice_orders_cars_id = " + cars_id + ")").ToList();
            }
        }*/
        public static List<iservice_orders_status> GetOrderStatusList()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders_status>("SELECT * FROM iservice_orders_status").ToList();
            }
        }
        public static List<iservice_orders_payment_status> GetOrderPaymentStatusList()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders_payment_status>("SELECT * FROM iservice_orders_payment_status").ToList();
            }
        }
        public static List<iservice_company> CompanySetData(int iservice_company_inside_id, string iservice_company_name, string iservice_company_country, string iservice_company_city, string iservice_company_street, string iservice_company_zipcode, string iservice_company_phone, string iservice_company_fax, string iservice_company_vat_number,string iservice_company_website, string iservice_company_email)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("UPDATE iservice_company SET iservice_company_name = N'" + iservice_company_name + "', iservice_company_country = N'" + iservice_company_country + "', iservice_company_city = N'" + iservice_company_city + "', iservice_company_street = N'" + iservice_company_street + "', iservice_company_zipcode = N'" + iservice_company_zipcode + "', iservice_company_phone = '" + iservice_company_phone + "', iservice_company_fax = '" + iservice_company_fax + "', iservice_company_website = N'" + iservice_company_website + "',iservice_company_email = N'" + iservice_company_email + "', iservice_company_vat_number = N'" + iservice_company_vat_number + "' WHERE iservice_company_inside_id = '" + iservice_company_inside_id+"'");           
                return null;
            }
        } 
        public static List<iservice_company> CompanyGetData(int iservice_company_inside_id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
               
                return db.Query<iservice_company>("select * from iservice_company WHERE iservice_company_inside_id = " + iservice_company_inside_id).ToList();
            }
        }

        public static List<iservice_items> ItemsWorksGetData()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<iservice_items>("select * from iservice_items WHERE iservice_items_type = 'works'").ToList();
            }
        }   public static List<iservice_items> ItemsDetailsGetData()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<iservice_items>("select * from iservice_items WHERE iservice_items_type = 'details'").ToList();
            }
        }


    }
}
