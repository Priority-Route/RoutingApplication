using System;
using System.Data.SQLite;

public class DBAddUser
{
    static void Main(String[] args)
    {
        DBOps ops = new DBOps();

        // Insert testing information here
        int companyID   = 0;
        Boolean admin   = true;
        String firstName= "John";
        String lastName = "Doe";
        String username = "jdoe";
        String password = "12345";
        String birthday = "01/23/45";

        // Add new user using information from above
        ops.AddUser(companyID, admin, firstName, lastName, username, password, birthday);

        // Verify if user is found and print to terminal
        Boolean success = ops.VerifyUser(username, password);
        Console.WriteLine(success);
    }
}