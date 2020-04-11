using System;
using SQLite;


[Table("Users")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int employeeID { get; set; }
    private int companyID;
    private Boolean administrator;
    private String firstName;
    private String lastName;
    private String username;
    private String password;
    private String birthday;

    public User(
        int empID,
        int compID,
        int admin,
        String fname,
        String lname,
        String uname,
        String pass,
        String birthday)
    {
        this.employeeID = empID;
        this.companyID = compID;
        
        if (admin == 1)
        {
            administrator = true;
        }
        else
        {
            administrator = false;
        }

        this.firstName = fname;
        this.lastName = lname;
        this.username = uname;
        this.password = pass;
        this.birthday = birthday;
    }

    /*public User(User usr)
    {
        this.employeeID = usr.getEmployeeID;

    }*/

    public int getEmployeeID()
    {
        return this.employeeID;
    }

    public int getCompanyID()
    {
        return this.companyID;
    }

    public Boolean getAdministrator()
    {
        return this.administrator;
    }

    public String getFirstName()
    {
        return this.firstName;
    }

    public String getLastName()
    {
        return this.lastName;
    }
    
    public String getUsername()
    {
        return this.username;
    }

    public String getPassword()
    {
        return this.password;
    }

    public String getBirthday()
    {
        return this.birthday;
    }
}