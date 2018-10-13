
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iservice5
{
    public class GlobalVars
    {
        public static int iservice_company_inside_id = 111111;
        public static String Employee;
        public static String regnumber;
        public static String OrderNumber;
        public static String Client;
        public static String iservice_company_name = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_name;
        public static String iservice_company_country = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_country;
        public static String iservice_company_city = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_city;
        public static String iservice_company_street = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_street;
        public static String iservice_company_zipcode = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_zipcode;
        public static String iservice_company_phone = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_phone;
        public static String iservice_company_fax = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_fax;
        public static String iservice_company_email = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_email;
        public static String iservice_company_vat_number = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_vat_number;
        public static String iservice_company_website = DataService.CompanyGetData(GlobalVars.iservice_company_inside_id)[0].iservice_company_website;

        public static int selected_iservice_customers_id;
        public static String selected_iservice_customers_name;
        public static String selected_iservice_customers_surname;
        public static String selected_iservice_customers_patronymic;
        public static String selected_iservice_customers_country;
        public static String selected_iservice_customers_city;
        public static String selected_iservice_customers_street;
        public static String selected_iservice_customers_zipcode;
        public static String selected_iservice_customers_telephone;
        public static String selected_iservice_customers_telephone_home;
        public static String selected_iservice_customers_date_of_birthday;
        public static String selected_iservice_customers_email;
        public static String selected_iservice_customers_date_of_creation;
        public static String selected_iservice_customers_employee;
        public static String selected_iservice_customers_company;

        public static int selected_iservice_cars_id;
        public static String selected_iservice_cars_reg_number;
        public static String selected_iservice_cars_vin;
        public static String selected_iservice_cars_brand;
        public static String selected_iservice_cars_model;
        public static String selected_iservice_cars_date_of_creation;
        public static String selected_iservice_cars_year;
        public static String selected_iservice_cars_color;
        public static String selected_iservice_cars_employee;
        
        public static int selected_iservice_orders_id;
        public static int selected_iservice_orders_cars_id;
        public static int selected_iservice_orders_user_id;
        public static int selected_iservice_orders_number;
        public static String selected_iservice_orders_date_of_creation;
        public static String selected_iservice_orders_date_of_last_update;
        public static String selected_iservice_orders_expiry_date;
        public static String selected_iservice_orders_status_of_payment;
        public static String selected_iservice_orders_status_of_work;
        public static String selected_iservice_orders_prepayment;
        public static String selected_iservice_orders_total_netto;
        public static String selected_iservice_orders_total_brutto;
        public static String selected_iservice_orders_mileage;
        


    }
}