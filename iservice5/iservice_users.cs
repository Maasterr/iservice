//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iservice5
{
    using System;
    using System.Collections.Generic;
    
    public partial class iservice_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public iservice_users()
        {
            this.iservice_orders = new HashSet<iservice_orders>();
            this.iservice_timeline = new HashSet<iservice_timeline>();
        }
    
        public int iservice_users_id { get; set; }
        public string iservice_users_name { get; set; }
        public string iservice_users_surname { get; set; }
        public string iservice_users_patronymic { get; set; }
        public string iservice_users_address { get; set; }
        public string iservice_users_telephone { get; set; }
        public string iservice_users_telephone_home { get; set; }
        public Nullable<System.DateTime> iservice_users_date_of_birthday { get; set; }
        public string iservice_users_email { get; set; }
        public string iservice_users_access { get; set; }
        public Nullable<System.DateTime> iservice_customers_date_of_creation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<iservice_orders> iservice_orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<iservice_timeline> iservice_timeline { get; set; }
    }
}