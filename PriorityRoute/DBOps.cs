using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;



public class DBOps
{
    // Setting path to database
    readonly String DBPath = "PRDB01.db";
    readonly SQLiteAsyncConnection connection;

    public DBOps()
    {
        connection = new SQLiteAsyncConnection(DBPath);
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
    

    public async Task<int> AddUserAsync(User user)
    {
        return await connection.InsertAsync(user);
    }

    public async Task<int> AddCompanyAsync(Company comp)
    {
        return await connection.InsertAsync(comp);
    }

    public async Task<int> AddPointAsync(Point point)
    {
        return await connection.InsertAsync(point);
    }


    public async Task<bool> DeleteUserAsync(int ID)
    {
        var user_to_delete = connection.Table<User>().Where(i => i.ID == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(user_to_delete.Result);

        return number_deleted == 1;
    }

    public async Task<bool> DeleteCompanyAsync(int ID)
    {
        var company_to_delete = connection.Table<Company>().Where(i => i.ID == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(company_to_delete.Result);

        return number_deleted == 1;
    }

    public async Task<bool> DeletePointAsync(int ID)
    {
        var point_to_delete = connection.Table<Point>().Where(i => i.Designation == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(point_to_delete.Result);

        return number_deleted == 1;
    }


    public Task<User> GetUserAsync(int id)
    {
        return connection.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public Task<User> GetUserAsync(String username)
    {
        return connection.Table<User>().Where(x => x.Username == username).FirstOrDefaultAsync();
    }

    public async Task<bool> VerifyUsernameAsync(String username, String password)
    {
        User user_to_verify = await connection.Table<User>().Where(x => x.Username == username).FirstOrDefaultAsync();
        if (user_to_verify.Password.Equals(password))
        {
            return true;
        }
        return false;
    }

    public Task<Company> GetCompanyAsync(int id)
    {
        return connection.Table<Company>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public Task<Point> GetPointAsync(int id)
    {
        return connection.Table<Point>().Where(i => i.Designation == id).FirstOrDefaultAsync();
    }


    public async Task<bool> UpdateUserAsync(User user)
    {
        var usersUpdated = await connection.UpdateAsync(user);

        return usersUpdated == 1;
    }

    public async Task<bool> UpdateComapnyAsync(Company comp)
    {
        var companiesUpdated = await connection.UpdateAsync(comp);

        return companiesUpdated == 1;
    }

    public async Task<bool> UpdatePointAsync(Point point)
    {
        var pointsUpdated = await connection.UpdateAsync(point);

        return pointsUpdated == 1;
    }
}