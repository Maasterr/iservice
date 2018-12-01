using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Collections.ObjectModel;
using MetroFramework.Forms;

namespace iService
{
    public partial class warehouse : MetroFramework.Forms.MetroForm
    {
        public warehouse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SetUp();
            Synchronize();
            Deprovision();


        }
        public static void Synchronize()
        {
            // Connection to  SQL Server
            SqlConnection serverConn = new SqlConnection(@"Data Source=den1.mssql1.gear.host;Persist Security Info=True;User ID=iservice;Password=19550721qQ); Initial Catalog=iservice;Connect Timeout=60");

            // Connection to SQL client
            // SqlConnection clientConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\iservice.mdf;Connect Timeout=60;Integrated Security=True");
            SqlConnection clientConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Projects\iService\Projects\iservice5\iservice5\iservice.mdf;Integrated Security=True;");

            // Perform Synchronization between SQL Server and the SQL client.
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

            // Create provider for SQL Server
            SqlSyncProvider serverProvider = new SqlSyncProvider("iservice_customers", serverConn);

            // Set the command timeout and maximum transaction size for the SQL Azure provider.
            SqlSyncProvider clientProvider = new SqlSyncProvider("iservice_customers", clientConn);

            // Set Local provider of SyncOrchestrator to the server provider
            syncOrchestrator.LocalProvider = serverProvider;

            // Set Remote provider of SyncOrchestrator to the client provider
            syncOrchestrator.RemoteProvider = clientProvider;

            // Set the direction of SyncOrchestrator session to Upload and Download
            syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

            // Create SyncOperations Statistics Object
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

            // Display the Statistics
            /* MessageBox.Show(syncStats.UploadChangesTotal, "form", 0);
             textBox1.Value = syncStats.UploadChangesTotal;
            */
            Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
            Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
            
            // Shut down database connections.
            serverConn.Close();
            serverConn.Dispose();
            clientConn.Close();
            clientConn.Dispose();

        }


        public static void SetUp()
        {
            // Connection to on  SQL Server database
            SqlConnection serverConn = new SqlConnection(@"Data Source=den1.mssql1.gear.host;Persist Security Info=True;User ID=iservice;Password=19550721qQ); Initial Catalog=iservice;Connect Timeout=60");

            // Connection to SQL client database
            SqlConnection clientConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Projects\iService\Projects\iservice5\iservice5\iservice.mdf;Integrated Security=True;");

            // Create a scope named "product" and add tables to it.
            DbSyncScopeDescription productScope = new DbSyncScopeDescription("iservice_customers");

            // Select the colums to be included in the Collection Object
            Collection<string> includeColumns = new Collection<string>();
            includeColumns.Add("iservice_customers_id");
            includeColumns.Add("iservice_customers_name");
            includeColumns.Add("iservice_customers_surname");
            includeColumns.Add("iservice_customers_patronymic");
            includeColumns.Add("iservice_customers_address");
            includeColumns.Add("iservice_customers_telephone");
            includeColumns.Add("iservice_customers_telephone_home");
            includeColumns.Add("iservice_customers_date_of_birthday");
            includeColumns.Add("iservice_customers_email");
            includeColumns.Add("iservice_customers_date_of_creation");
  
           
            // Define the Products table.
            DbSyncTableDescription productDescription =
                                                    SqlSyncDescriptionBuilder.GetDescriptionForTable("dbo.iservice_customers",
                                                                                                        includeColumns, serverConn);
            DbSyncScopeDescription carsScope = new DbSyncScopeDescription("iservice_cars");

            // Select the colums to be included in the Collection Object
            Collection<string> includeColumncarsScope = new Collection<string>();
            includeColumncarsScope.Add("iservice_cars_id");
            includeColumncarsScope.Add("iservice_cars_customers_id");
            includeColumncarsScope.Add("iservice_cars_reg_number");
            includeColumncarsScope.Add("iservice_cars_vin_number");
            includeColumncarsScope.Add("iservice_cars_brand");
            includeColumncarsScope.Add("iservice_cars_model");
            includeColumncarsScope.Add("iservice_cars_year");
            includeColumncarsScope.Add("iservice_cars_color");


            // Define the Products table.
            DbSyncTableDescription carsDescription =
                                                    SqlSyncDescriptionBuilder.GetDescriptionForTable("dbo.iservice_cars",
                                                                                                        includeColumncarsScope, serverConn);
            // Add the Table to the scope object.    
            productScope.Tables.Add(productDescription);
            productScope.Tables.Add(carsDescription);

            // Create a provisioning object for "product" and apply it to the on-premise database if one does not exist.
            SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, productScope);


            // Filter Rows for the ListPrice column
            //serverProvision.Tables["dbo.iservice_customers"].AddFilterColumn("ListPrice");
            //serverProvision.Tables["dbo.iservice_customers"].FilterClause = "[side].[ListPrice] < '600'";

            if (!serverProvision.ScopeExists("iservice_customers")&& !serverProvision.ScopeExists("iservice_cars"))
                serverProvision.Apply();

            // Provision the SQL client database from the on-premise SQL Server database if one does not exist.
            SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, productScope);


            if (!clientProvision.ScopeExists("iservice_customers")&& !clientProvision.ScopeExists("iservice_customers"))
                clientProvision.Apply();

            // Shut down database connections.

            serverConn.Close();

            serverConn.Dispose();

            clientConn.Close();

            clientConn.Dispose();
        }

        public static void Deprovision()
        {
            // Connection to on  SQL Server database
            SqlConnection serverConn = new SqlConnection(@"Data Source=den1.mssql1.gear.host;Persist Security Info=True;User ID=iservice;Password=19550721qQ); Initial Catalog=iservice;Connect Timeout=60");

            // Connection to SQL client database
            SqlConnection clientConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Projects\iService\Projects\iservice5\iservice5\iservice.mdf;Integrated Security=True;");

            // Create Scope Deprovisioning for Sql Server and SQL client.
            SqlSyncScopeDeprovisioning serverSqlDepro = new SqlSyncScopeDeprovisioning(serverConn);
            SqlSyncScopeDeprovisioning clientSqlDepro = new SqlSyncScopeDeprovisioning(clientConn);

            // Remove the scope from SQL Server remove all synchronization objects.
            serverSqlDepro.DeprovisionScope("iservice_customers");
            serverSqlDepro.DeprovisionStore();

            // Remove the scope from SQL client and remove all synchronization objects.
            clientSqlDepro.DeprovisionScope("iservice_customers");
            clientSqlDepro.DeprovisionStore();

            // Shut down database connections.
            serverConn.Close();
            serverConn.Dispose();
            clientConn.Close();
            clientConn.Dispose();

        }

        private void warehouse_Load(object sender, EventArgs e)
        {

        }
    }
}
