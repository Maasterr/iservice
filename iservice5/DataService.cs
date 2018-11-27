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
        public static List<iservice_users> CheckLogin(String login, String password)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_users>("Select * from dbo.iservice_users where iservice_users_name = '" + login+"' and iservice_users_password='"+password+"'").ToList();
            }
        }
        public static List<iservice_company> CheckKey(String key)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_company>("Select * from iservice_company where iservice_company_key = '" + key+"'").ToList();
            }
        }
        public static List<iservice_company> GetKey()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_company>("Select iservice_company_key from iservice_company where iservice_company_id = 1").ToList();
            }
        }
        public static List<iservice_company> UpdateKey(String key)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_company>("Update iservice_company set iservice_company_key = '" + key+"' where iservice_company_id =1" ).ToList();
            }
        }
        public static List<iservice_users> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_users>("Select * from iservice_users").ToList();
            }
        }
        public static List<iservice_customers> GetAllCustomers()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_customers>("Select * from iservice_customers").ToList();
            }
        }
        public static List<iservice_customers> CheckCustomer(String name,String surname,String patronymic)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_customers>("Select * from iservice_customers where iservice_customers_name= '"+name+"'and iservice_customers_surname = '"+surname+"' and iservice_customers_patronymic='"+patronymic+"'").ToList();
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
                return db.Query<iservice_customers>("SELECT * FROM  iservice_customers WHERE(iservice_customers_id LIKE '%' + N'" + word + "' + '%') OR(iservice_customers_company LIKE '%' + N'" + word + "' + '%') OR (iservice_customers_name LIKE '%' + N'" + word +"' + '%') OR (iservice_customers_surname LIKE '%' + N'"  + word  + "' +'%') OR (iservice_customers_telephone LIKE '%' + N'"  + word  + "' + '%') OR (iservice_customers_email LIKE '%' + N'"  + word  + "' + '%')").ToList();
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

        public static List<iservice_cars> GetCarsByWord(String word)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_cars>("SELECT * FROM iservice_cars WHERE(iservice_cars_reg_number LIKE '%' + N'" + word + "' + '%') OR  (iservice_cars_vin_number LIKE '%' + N'" + word + "' + '%')").ToList();
            }
        }

        public static List<iservice_cars> GetAllCars()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_cars>("SELECT * FROM iservice_cars").ToList();
            }
        }

        public static List<iservice_orders> NewOrder(int iservice_orders_cars_id, int iservice_orders_user_id,String iservice_orders_date_of_creation, String iservice_orders_date_of_last_update, String iservice_orders_expiry_date, String iservice_orders_status_of_payment, String iservice_orders_status_of_work,String iservice_orders_prepayment, String iservice_orders_total_netto,String iservice_orders_total_brutto,String iservice_orders_mileage)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Insert into iservice_orders values (N'" + iservice_orders_cars_id + "',N'" + iservice_orders_user_id + "',(Select MAX(iservice_orders_number)+1 from iservice_orders), N'" + iservice_orders_status_of_payment + " ',N'" + iservice_orders_status_of_work + " ',N'" + iservice_orders_date_of_creation + " ',N'" + iservice_orders_date_of_last_update + " ',N'" + iservice_orders_expiry_date + " ',N'" + iservice_orders_prepayment + "',N'" + iservice_orders_total_netto + "',N'" + iservice_orders_total_brutto + "',N'" + iservice_orders_mileage + "')");
                return null;
            }
        }
        public static List<iservice_orders_items> NewOrderItem(int iservice_orders_item_id, int iservice_orders_items_orders_number, String iservice_orders_items_qty, String iservice_orders_items_price_netto, String iservice_orders_items_price_brutto)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Insert into iservice_orders_items values (N'" + iservice_orders_items_orders_number + "',N'" + iservice_orders_item_id + "',N'" + iservice_orders_items_qty + "',N'" + iservice_orders_items_price_netto  + " ',N'" + iservice_orders_items_price_brutto + " ')");
                return null;
            }
        }

        public static List<iservice_orders_items> UpdateOrderItem(int iservice_orders_item_id, int iservice_orders_items_orders_number, String iservice_orders_items_qty, String iservice_orders_items_price_netto, String iservice_orders_items_price_brutto)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Update iservice_orders_items set iservice_orders_items_qty=N'" + iservice_orders_items_qty + "',iservice_orders_items_price_netto=N'" + iservice_orders_items_price_netto + " ',iservice_orders_items_price_brutto=N'" + iservice_orders_items_price_brutto + " ' where iservice_orders_items_orders_id = N'" + iservice_orders_items_orders_number + "' and iservice_orders_item_id=N'" + iservice_orders_item_id + "'");
                return null;
            }
        }
        public static List<iservice_orders_items> DelteOrderItem(int iservice_orders_item_id, int iservice_orders_items_orders_number)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Delete from iservice_orders_items where iservice_orders_items_orders_id = N'" + iservice_orders_items_orders_number + "' and iservice_orders_item_id=N'" + iservice_orders_item_id + "'");
                return null;
            }
        }
        public static List<iservice_orders_items> CheckOrderItem(int iservice_orders_item_id, int iservice_orders_items_orders_number)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders_items>("SELECT * FROM iservice_orders_items where iservice_orders_items_orders_id = N'" + iservice_orders_items_orders_number + "' and iservice_orders_item_id=N'" + iservice_orders_item_id + "'").ToList();
            }
        }
        public static List<iservice_items> NewItem(string iservice_items_type, int iservice_items_category, int iservice_items_subcategory, String iservice_items_description,String iservice_items_purchase_price_netto, String iservice_items_purchase_price_brutto, String iservice_items_price_netto, String iservice_items_price_brutto,String iservice_items_employee, String iservice_items_date_of_creation, String iservice_items_last_update, String iservice_items_qty, String iservice_items_qty_type)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Insert into iservice_items values (N'" + iservice_items_type + "',N'" + iservice_items_category + "',N'" + iservice_items_subcategory + " ',N'" + iservice_items_description + " ',N'" + iservice_items_purchase_price_netto + " ',N'" + iservice_items_purchase_price_brutto + " ',N'" + iservice_items_price_netto + "',N'" + iservice_items_price_brutto + "',N'" + iservice_items_employee + "',N'" + iservice_items_date_of_creation + "',N'" + iservice_items_last_update + "',N'" + iservice_items_qty + "',N'" + iservice_items_qty_type + "')");
                return null;
            }
        }
        public static List<iservice_items> GetOrderItems( String ItemType, String OrderNumber)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_items>("Select iservice_items.*,iservice_orders_items.iservice_orders_items_qty from iservice_items LEFT JOIN iservice_orders_items ON iservice_orders_items_orders_id = '" + OrderNumber + "' and iservice_orders_item_id = iservice_items.iservice_items_id where iservice_items_type='" + ItemType+ "' and iservice_items_id = (select iservice_orders_item_id from iservice_orders_items where iservice_orders_items_orders_id = '" + OrderNumber + "' and iservice_orders_item_id = iservice_items.iservice_items_id) ").ToList();


            }
        }
        public static List<iservice_orders> UpdateOrder(int iservice_orders_id,String iservice_orders_date_of_last_update, String iservice_orders_expiry_date, String iservice_orders_status_of_payment, String iservice_orders_status_of_work, String iservice_orders_prepayment, String iservice_orders_total_netto, String iservice_orders_total_brutto, String iservice_orders_mileage)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("Update iservice_orders set iservice_orders_date_of_last_update = N'" + iservice_orders_date_of_last_update + " ',iservice_orders_expiry_date =N'" + iservice_orders_expiry_date + " ',iservice_orders_status_of_payment=N'" + iservice_orders_status_of_payment + " ',iservice_orders_status_of_work=N'" + iservice_orders_status_of_work + " ',iservice_orders_prepayment=N'" + iservice_orders_prepayment + "',iservice_orders_total_netto=N'" + iservice_orders_total_netto + "',iservice_orders_total_brutto=N'" + iservice_orders_total_brutto + "', iservice_orders_mileage = N'" + iservice_orders_mileage + "' where iservice_orders_id = '"+ iservice_orders_id+"'");
                return null;
            }
        }
        public static List<iservice_orders> GetOrdersByWord(String word)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT iservice_orders.*,iservice_orders_status.iservice_orders_status_name,iservice_orders_payment_status.iservice_orders_payment_status_name, iservice_users.iservice_users_name FROM iservice_orders LEFT JOIN iservice_orders_status ON iservice_orders.iservice_orders_status_of_work = iservice_orders_status.iservice_orders_status_id LEFT JOIN iservice_orders_payment_status ON iservice_orders.iservice_orders_status_of_payment = iservice_orders_payment_status.iservice_orders_payment_status_id LEFT JOIN iservice_users ON iservice_orders.iservice_orders_user_id = iservice_users.iservice_users_id WHERE(iservice_orders_number LIKE '%' + N'" + word + "' + '%')").ToList();
            }
        }
        public static List<iservice_orders> GetLastOrderNumber()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT * FROM iservice_orders where (iservice_orders_number) IN (select MAX(iservice_orders_number) from iservice_orders)").ToList();
            }
        }
        public static List<iservice_orders> GetAllOrders()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT iservice_orders.*,iservice_orders_status.iservice_orders_status_name,iservice_orders_payment_status.iservice_orders_payment_status_name, iservice_users.iservice_users_name FROM iservice_orders LEFT JOIN iservice_orders_status ON iservice_orders.iservice_orders_status_of_work = iservice_orders_status.iservice_orders_status_id LEFT JOIN iservice_orders_payment_status ON iservice_orders.iservice_orders_status_of_payment = iservice_orders_payment_status.iservice_orders_payment_status_id LEFT JOIN iservice_users ON iservice_orders.iservice_orders_user_id = iservice_users.iservice_users_id").ToList();
            }
        }
        public static List<iservice_orders> GetOrdersByCar(int cars_id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT iservice_orders.*,iservice_orders_status.iservice_orders_status_name,iservice_orders_payment_status.iservice_orders_payment_status_name, iservice_users.iservice_users_name FROM iservice_orders LEFT JOIN iservice_orders_status ON iservice_orders.iservice_orders_status_of_work = iservice_orders_status.iservice_orders_status_id LEFT JOIN iservice_orders_payment_status ON iservice_orders.iservice_orders_status_of_payment = iservice_orders_payment_status.iservice_orders_payment_status_id LEFT JOIN iservice_users ON iservice_orders.iservice_orders_user_id = iservice_users.iservice_users_id where iservice_orders.iservice_orders_cars_id = " + cars_id ).ToList();
            }
        }
        public static List<iservice_orders> GetOrdersById(int order_id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<iservice_orders>("SELECT iservice_orders.*,iservice_orders_status.iservice_orders_status_name,iservice_orders_payment_status.iservice_orders_payment_status_name, iservice_users.iservice_users_name FROM iservice_orders LEFT JOIN iservice_orders_status ON iservice_orders.iservice_orders_status_of_work = iservice_orders_status.iservice_orders_status_id LEFT JOIN iservice_orders_payment_status ON iservice_orders.iservice_orders_status_of_payment = iservice_orders_payment_status.iservice_orders_payment_status_id LEFT JOIN iservice_users ON iservice_orders.iservice_orders_user_id = iservice_users.iservice_users_id where iservice_orders_id = " + order_id).ToList();
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
        public static List<iservice_company> CompanySetData(int iservice_company_key, string iservice_company_name, string iservice_company_country, string iservice_company_city, string iservice_company_street, string iservice_company_zipcode, string iservice_company_phone, string iservice_company_fax, string iservice_company_vat_number,string iservice_company_website, string iservice_company_email,string iservice_company_path)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                db.Execute("UPDATE iservice_company SET iservice_company_name = N'" + iservice_company_name + "', iservice_company_country = N'" + iservice_company_country + "', iservice_company_city = N'" + iservice_company_city + "', iservice_company_street = N'" + iservice_company_street + "', iservice_company_zipcode = N'" + iservice_company_zipcode + "', iservice_company_phone = '" + iservice_company_phone + "', iservice_company_fax = '" + iservice_company_fax + "', iservice_company_website = N'" + iservice_company_website + "',iservice_company_email = N'" + iservice_company_email + "', iservice_company_vat_number = N'" + iservice_company_vat_number + "', iservice_company_path = N'" + iservice_company_path + "' WHERE iservice_company_key = '" + iservice_company_key+"'");           
                return null;
            }
        } 
        public static List<iservice_company> CompanyGetData(int iservice_company_key)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
               
                return db.Query<iservice_company>("select * from iservice_company WHERE iservice_company_key = " + iservice_company_key).ToList();
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
        }
        public static List<iservice_items> ItemsDetailsGetData()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<iservice_items>("select * from iservice_items WHERE iservice_items_type = 'details'").ToList();
            }
        }
        public static List<iservice_timeline> TimelineGetDayByDateandStation(String Date,String Station)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<iservice_timeline>("select * from iservice_timeline WHERE iservice_timeline_date= '" + Date + "' and iservice_timeline_station='" + Station+"'").ToList() ?? null;
            }
        }


        //iservice docs
        public static List<iservice_docs> GetDocsByOrder(int order_number)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.Query<iservice_docs>("select * from iservice_documents WHERE iservice_documents_order_id= '" + order_number + "'").ToList() ?? null;
            }
        }

        //end iservice docs

    }
}
