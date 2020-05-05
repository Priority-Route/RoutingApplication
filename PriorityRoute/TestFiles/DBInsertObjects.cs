// File Name: DBInsertObjects.cs
// Purpose: test data insert functions in database
//
// Author: Christian Hakim

using PriorityRoute.Data;
using PriorityRoute.Models;

namespace PriorityRoute.TestFiles
{
    public class DBInsertObjects
    {
        public void RunTest()
        {
            DBUserOps userOps = new DBUserOps();
            DBCompanyOps compOps = new DBCompanyOps();
            DBReceptacleOps recOps = new DBReceptacleOps();

            addUsers(userOps);
            addCompanies(compOps);
            addReceptacles(recOps);
        }

        private static void addUsers(DBUserOps ops)
        {
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            User user5 = new User();
            User user6 = new User();
            User user7 = new User();
            User user8 = new User();
            
            user1.Username = "testUser1";
            user1.Password = "testPass1";
            user1.Administrator = 1;
            user2.Username = "testUser2";
            user2.Password = "testPass2";
            user2.Administrator = 0;
            user3.Username = "testUser3";
            user3.Password = "testPass3";
            user3.Administrator = 0;
            user4.Username = "testUser4";
            user4.Password = "testPass4";
            user4.Administrator = 1;
            user5.Username = "testUser5";
            user5.Password = "testPass5";
            user5.Administrator = 0;
            user6.Username = "testUser6";
            user6.Password = "testPass6";
            user6.Administrator = 0;
            user7.Username = "testUser7";
            user7.Password = "testPass7";
            user7.Administrator = 1;
            user8.Username = "testUser8";
            user8.Password = "testPass8";
            user8.Administrator = 0;

            ops.AddUser(user1);
            ops.AddUser(user2);
            ops.AddUser(user3);
            ops.AddUser(user4);
            ops.AddUser(user5);
            ops.AddUser(user6);
            ops.AddUser(user7);
            ops.AddUser(user8);
        }

        private static void addCompanies(DBCompanyOps ops)
        {
            Company comp1 = new Company();
            Company comp2 = new Company();
            Company comp3 = new Company();

            comp1.Name = "testCompany1";
            comp2.Name = "testCompany2";
            comp3.Name = "testCompany3";

            ops.AddCompany(comp1);
            ops.AddCompany(comp2);
            ops.AddCompany(comp3);
        }

        private static void addReceptacles(DBReceptacleOps ops)
        {
            Receptacle rec1 = new Receptacle();
            Receptacle rec2 = new Receptacle();
            Receptacle rec3 = new Receptacle();
            Receptacle rec4 = new Receptacle();
            Receptacle rec5 = new Receptacle();
            Receptacle rec6 = new Receptacle();

            rec1.Name = "testRec1";
            rec2.Name = "testRec2";
            rec3.Name = "testRec3";
            rec4.Name = "testRec4";
            rec5.Name = "testRec5";
            rec6.Name = "testRec6";

            ops.AddReceptacle(rec1);
            ops.AddReceptacle(rec2);
            ops.AddReceptacle(rec3);
            ops.AddReceptacle(rec4);
            ops.AddReceptacle(rec5);
            ops.AddReceptacle(rec6);
        }
    }
}