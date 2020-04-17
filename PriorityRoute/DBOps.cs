using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;



public class DBOps
{
    // Setting path to database and creating connection object
    readonly String DBPath = "PRDB01.db";
    readonly SQLiteAsyncConnection connection;

    // opening connection
    // creating database tables
    // creating default users
    public DBOps()
    {
        connection = DependencyService.Get<ISQLite>().GetConnection();
        connection.CreateTableAsync<User>().Wait();
        connection.CreateTableAsync<Company>().Wait();
        connection.CreateTableAsync<Point>().Wait();

        User user = new User {
            ID = 1,
            CompanyID = 1,
            Administrator = 1,
            FirstName = "Admin",
            LastName = "Administrator",
            Username = "admin",
            Password = "PRadmin01",
            Birthday = "09/01/19"
        };

        Company comp = new Company {
            ID = 1,
            Name = "Priority Route",
            License = "N/A",
            Expiration = "N/A",
            Valid = 1
        };

        this.AddUserAsync(user).Wait();
        this.AddCompanyAsync(comp).Wait();
    }
    

    // ADD INFORMATION METHODS

    // add user to database
    // requires user
    public async Task<int> AddUserAsync(User user)
    {
        return await connection.InsertAsync(user);
    }

    // add company to database
    // requires company
    public async Task<int> AddCompanyAsync(Company comp)
    {
        return await connection.InsertAsync(comp);
    }

    // add point to database
    // requires point
    public async Task<int> AddPointAsync(Point point)
    {
        return await connection.InsertAsync(point);
    }


    // DELETE INFORMATION METHODS

    // delete user from database
    // requires user ID
    // returns true if successful
    public async Task<bool> DeleteUserAsync(int ID)
    {
        var user_to_delete = connection.Table<User>().Where(i => i.ID == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(user_to_delete.Result);

        return number_deleted == 1;
    }

    // delete company from database
    // requires company ID
    // returns true if successful
    public async Task<bool> DeleteCompanyAsync(int ID)
    {
        var company_to_delete = connection.Table<Company>().Where(i => i.ID == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(company_to_delete.Result);

        return number_deleted == 1;
    }

    // delete point from database
    // requires point designation
    // returns true if successful
    public async Task<bool> DeletePointAsync(int ID)
    {
        var point_to_delete = connection.Table<Point>().Where(i => i.Designation == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(point_to_delete.Result);

        return number_deleted == 1;
    }


    // GET INFORMATION METHODS

    // get user from database
    // requires user ID
    // returns user object
    public Task<User> GetUserAsync(int id)
    {
        return connection.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    // get user from database
    // requires user username
    // returns user object
    public Task<User> GetUserAsync(String username)
    {
        return connection.Table<User>().Where(x => x.Username == username).FirstOrDefaultAsync();
    }

    // verify user in database
    // requires user username and password
    // returns boolean (true if verified)
    public async Task<bool> VerifyUsernameAsync(String username, String password)
    {
        User user_to_verify = await connection.Table<User>().Where(x => x.Username == username).FirstOrDefaultAsync();
        if (user_to_verify.Password.Equals(password))
        {
            return true;
        }
        return false;
    }

    // get company from database
    // requires company ID
    // returns company object
    public Task<Company> GetCompanyAsync(int id)
    {
        return connection.Table<Company>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    // get company from database
    // requires company name
    // returns company object
    public Task<Company> GetCompanyAsync(String name)
    {
        return connection.Table<Company>().Where(i => i.Name == name).FirstOrDefaultAsync();
    }

    // get employees of certain company
    // requires company ID
    // returns enumerable object of employees
    // public async Task<IEnumerable<User>> GetEmployeesAsync(bool forceRefresh = false, int compID)
    // {
    //     IEnumerable<User> employees = await connection.Table<User>().OrderBy(i => i.ID).ToListAsync();
    //     IEnumerable<User> employees_to_return = new IEnumerable<User>();

    //     foreach (User employee in employees)
    //     {
    //         if (employee.CompanyID == compID)
    //         {
    //             employees_to_return.AddUserAsync(employee);
    //         }
    //     }

    //     return employees_to_return;
    // }

    // get employees of certain company
    // requires company name
    // returns enumerable object of employees
    // public async Task<IEnumerable<User>> GetEmployeesAsync(bool forceRefresh = false, String compName)
    // {
    //     Company comp = await this.GetCompanyAsync(compName);
    //     int compID = comp.ID;

    //     return this.GetEmployeesAsync(compID);
    // }

    // get point from database
    // requires point ID
    // returns point object
    public Task<Point> GetPointAsync(int id)
    {
        return connection.Table<Point>().Where(i => i.Designation == id).FirstOrDefaultAsync();
    }

    // get points in company network
    // requires company ID
    // returns enumerable object of points
    // public async Task<IEnumerable<Point>> GetNetworkAsync(bool forceRefresh = false, int compID)
    // {
    //     IEnumerable<Point> points = await connection.Table<Point>().OrderBy(i => i.Designation).ToListAsync();
    //     IEnumerable<Point> network = new IEnumerable<Point>();

    //     foreach (Point point in points)
    //     {
    //         if (point.CompanyID == compID)
    //         {
    //             network.AddPointAsync(point);
    //         }
    //     }

    //     return network;
    // }

    // get points of company network
    // requires company name
    // returns enumerable object of points
    // public async Task<IEnumerable<Point>> GetNetworkAsync(bool forceRefresh = false, String compName)
    // {
    //     Company comp = await this.GetCompanyAsync(compName);
    //     int compID = comp.ID;

    //     return this.GetNetworkAsync(compID);
    // }


    // UPDATE INFORMATION METHODS

    // update user information
    // requires user object
    // returns true if successful
    public async Task<bool> UpdateUserAsync(User user)
    {
        var usersUpdated = await connection.UpdateAsync(user);

        return usersUpdated == 1;
    }

    // update company information
    // requires company object
    // returns true if successful
    public async Task<bool> UpdateComapnyAsync(Company comp)
    {
        var companiesUpdated = await connection.UpdateAsync(comp);

        return companiesUpdated == 1;
    }

    // update point information
    // requires point object
    // returns true if successful
    public async Task<bool> UpdatePointAsync(Point point)
    {
        var pointsUpdated = await connection.UpdateAsync(point);

        return pointsUpdated == 1;
    }
}