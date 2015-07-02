using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RateBeverage
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class RateBeverage : System.Web.Services.WebService {

    public RateBeverage () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void Rate(int beverageID,int rating,string personName, string locationName) {
        string SQLConnectionString = "Server=tcp:bzkobrlh0s.database.windows.net,1433;Database=Boozr;User ID=Beerman@bzkobrlh0s;Password={your_password_here};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
        // Create a SqlConnection from the provided connection string.
        using (SqlConnection connection = new SqlConnection(SQLConnectionString))
        {
            // Begin to formulate the command.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            // Specify the query to be executed.
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
            string.Format("insert into Rating(PersonName,BeverageID,Rating,Location) values ('{0}',{1},{2},'{3}'",personName,beverageID,rating,locationName);

            // Open connection to database.
            connection.Open();

            
            command.ExecuteNonQuery();
        }

    }
    
}
