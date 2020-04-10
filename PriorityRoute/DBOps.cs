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
    public void AddUser(
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

    // Simplified AddUser method: only requires username and password
    public void AddUser(
        String username,
        String password)
    {
        AddUser(0, false, "null", "null", username, password, "01/01/70");
    }

    // Verifies User with username and password credentials
    // Returns boolean if user is found
    public Boolean VerifyUser(
        String username,
        String password)
    {
        if (GetUser(username, password) != null)
        {
            return true;
        }
        return false;
    }

    // Finds user in database using username and password
    public User GetUser(String username, String password)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        String stm = "SELECT * FROM User WHERE Username = @unm AND Password = @pwd";
        stm.Parameters.AddWithValue("@unm", username);
        stm.Parameters.AddWithValue("@pwd", password);
        stm.Prepare();

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();
        // 0 - Employee ID
        // 1 - Company ID
        // 2 - Administrator
        // 3 - First Name
        // 4 - Last Name
        // 5 - Username
        // 6 - Password
        // 7 - Birthday
        try
        {
            int empID = (int)rdr.GetString(0);
            User usr = new User(
                rdr.GetInt32(0),
                rdr.GetInt32(1),
                rdr.GetInt32(2),
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetString(5),
                rdr.GetString(6),
                rdr.GetString(7));
            return usr;
        }
        catch
        {
            return null;
        }
    }

    /* Add company to database
     *
     * Company must be input with the following information:
     * String Name
     * String License
     * String Expiration
     */
    public void AddCompany(
        String name,
        String license,
        String expiration)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = "INSERT INTO Company(Name, License, Expiration) VALUES(@name, @lic, @exp)";

        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@lic", license);
        cmd.Parameters.AddWithValue("@exp", expiration);
        cmd.Prepare();

        cmd.ExecuteNonQuery();
    }

    // Returns Company object given ID
    public Company getCompany(int ID)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        String stm = "SELECT * FROM Company WHERE ID = @cID";
        stm.Parameters.AddWithValue("@cID", ID.ToString());
        stm.Prepare();

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();
        // 0 - ID
        // 1 - Name
        // 2 - License
        // 3 - Expiration
        // 4 - Valid

        try
        {
            Company comp = new Company(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3)
            );
            return comp;
        }
        catch
        {
            return null;
        }
    }

    /* Returns all users in a given company
     * Requires a company object
     * Returns a list of employees (users)
     */
    public List<User> companyGetUsers(Company comp)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        String stm = "SELECT * FROM User WHERE CompanyID = @cID";
        stm.Parameters.AddWithValue("@cID", comp.getCompanyID());
        stm.Prepare();

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();
        // 0 - ID
        // 1 - Company ID
        // 2 - Administrator Status
        // 3 - First Name
        // 4 - Last Name
        // 5 - Username
        // 6 - Password
        // 7 - Birthday

        try
        {
            List<User> employees = new List<User>();
            while (rdr.Read())
            {
                User usr = new User(
                    rdr.GetInt32(0),
                    rdr.GetInt32(1),
                    rdr.GetInt32(2),
                    rdr.GetString(3),
                    rdr.GetString(4),
                    rdr.GetString(5),
                    rdr.GetString(6),
                    rdr.GetString(7)
                );
                employees.add(usr);
            }
            return employees;
        }
        catch
        {
            return null;
        }
    }

    /* Add point to database with additional information
     *
     * Point must be input with the following information:
     * int Company ID
     * int Status
     * String Latitude
     * String Longitude
     * String Address
     * int Zip Code
     * String Additional Information
     */
    public void AddPointAddInfo(
        int CompanyID,
        int Status,
        String Latitude,
        String Longitude,
        String Address,
        int ZipCode,
        String AdditionalInformation)
    {
        string cs = DBPath;

        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = "INSERT INTO Points(CompanyID, Status, Latitude, Longitude, Address, ZipCode, AddInfo) VALUES(@cID, @stt, @lat, @lon, @add, @zcd, @ain)";

        cmd.Parameters.AddWithValue("@cID", CompanyID);
        cmd.Parameters.AddWithValue("@stt", Status);
        cmd.Parameters.AddWithValue("@lat", Latitude);
        cmd.Parameters.AddWithValue("@lon", Longitude);
        cmd.Parameters.AddWithValue("@add", Address);
        cmd.Parameters.AddWithValue("@zcd", ZipCode);
        cmd.Parameters.AddWithValue("@ain", AdditionalInformation);
        cmd.Prepare();

        cmd.ExecuteNonQuery();
    }

    // Add point to database without additiona information
    // Simplified version of AddPointAddInfo method
    public void AddPoint(
        int CompanyID,
        int Status,
        String Latitude,
        String Longitude,
        String Address,
        int ZipCode)
    {
        AddPointAddInfo(CompanyID,Status,Latitude,Longitude,Address,ZipCode,"");
    }    
}