using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using PriorityRoute.Models;

public class DBOps
{
    // Setting path to database
    readonly String DBPath = "PriorityRoute/PRDB01.db";
    readonly SQLiteAsyncConnection connection;

    public DBOps()
    {
        connection = new SQLiteAsyncConnection(DBPath);
        connection.CreateTableAsync<User>.Wait();
        connection.CreateTableAsync<Company>.Wait();
        connection.CreateTableAsync<Point>.Wait();
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
    }

    public async Task<bool> DeleteCompanyAsync(int ID)
    {
        var company_to_delete = connection.Table<Company>().Where(i => i.ID == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(company_to_delete.Result);
    }

    public async Task<bool> DeletePointAsync(int ID)
    {
        var point_to_delete = connection.Table<Point>().Where(i => i.Designation == ID).FirstOrDefaultAsync();
        var number_deleted = await connection.DeleteAsync(point_to_delete.Result);
    }

    public async Task<User> GetUserAsync(int ID)
    {
        return connection.Table<User>().OrderBy(x => x.ID == ID).ToListAsync();
    }

    public async Task<User> VerifyUserAsync(String username, String password)
    {
        User user_to_verify = connection.Table<User>().OrderBy(x => x.Username == username).ToListAsync();
        if (user_to_verify.Password.Equals(password))
        {
            return user_to_verify;
        }
        return null;
    }

    public async Task<Company> GetCompanyAsync(int ID)
    {
        return connection.Table<Company>().OrderBy(x => x.ID == ID).ToListAsync();
    }

    public async Task<Point> GetPointAsync(int ID)
    {
        return connection.Table<Point>().OrderBy(x => x.Designation == ID).ToListAsync();
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