using System;
using System.Data.SQLite;

public class Company
{
    private int companyID;
    private String name;

    private String license;
    private String expiration;
    private Boolean valid = true;

    private List<User> employees;

    public Company(
        int compID,
        String nam,
        String lic,
        String exp)
    {
        this.companyID = compID;
        this.name = nam;
        this.license = lic;
        this.expiration = exp;
    }

    public int getCompanyID()
    {
        return this.companyID;
    }

    public String getCompanyName()
    {
        return this.name;
    }

    public String getLicense()
    {
        return this.license;
    }

    public String getExpiration()
    {
        return this.expiration;
    }

    public List<User> getEmployees()
    {
        return this.employees;
    }
}