using System;
using System.Data.SQLite;

public class DBOps
{
    // Setting path to database
    readonly String DBPath = "Data Source=PriorityRoute/PRDB01";

    /* Add user to database.
     * 
     * User must be input with the following variables:
     * int Company ID
     * Boolean Administrator
     * String First Name
     * String Last Name
     * String Username
     * String Password
     * String Birthday (in format "MM/DD/YYYY")
     */
    static void AddUser(
        int companyID,
        Boolean admin,
        String firstName,
        String lastName,
        String username,
        String password,
        String birthday)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        int adminVal = 0;
        if (admin)
        {
            adminVal = 1;
        }
            
        cmd.CommandText = "INSERT INTO User(CompanyID, Administrator, FirstName, LastName, Username, Password, Birthday) VALUES(@compID, @adVal, @fName, @lName, @uName, @pass, @bday)";

        cmd.Parameters.AddWithValue("@compID", companyID);
        cmd.Parameters.AddWithValue("adVal", adminVal);
        cmd.Parameters.AddWithValue("fName", firstName);
        cmd.Parameters.AddWithValue("lName", lastName);
        cmd.Parameters.AddWithValue("uName", username);
        cmd.Parameters.AddWithValue("pass", password);
        cmd.Parameters.AddWithValue("bday", birthday);
        cmd.Prepare();

        cmd.ExecuteNonQuery();
    }

    /* Verifies user login credentials
     * Returns true if user is found, false otherwise
     *
     * Verification is done with Username and Password
     */
    static Boolean VerifyUser(
        String username,
        String password)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        String stm = "SELECT Username, Password FROM User";

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        Boolean found = false;

        while (rdr.Read())
        {
            if (rdr.GetString(0).equals(username))
            {
                if (rdr.GetString(1).equals(password))
                {
                    found = true;
                }
            }
        }

        return found;
    }
}