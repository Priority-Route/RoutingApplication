// File Name: DBInsertData.cs
// Purpose: test data update functions in database
//
// Author: Christian Hakim

using System.Collections.Generic;
using PriorityRoute.Data;
using PriorityRoute.Models;

namespace PriorityRoute.TestFiles
{
    public class DBInsertData
    {
        public void RunTest()
        {
            DBUserOps userOps = new DBUserOps();
            DBCompanyOps compOps = new DBCompanyOps();
            DBReceptacleOps recOps = new DBReceptacleOps();

            setUserCompIDs(userOps, compOps);
            setRecCompIDs(compOps, recOps);
            setRecCoordinates(compOps, recOps);
        }

        public static void setUserCompIDs(DBUserOps userOps, DBCompanyOps compOps)
        {
            userOps.GetUser("testUser1").CompanyID = compOps.GetCompany("testCompany1").ID;
            userOps.GetUser("testUser2").CompanyID = compOps.GetCompany("testCompany1").ID;
            userOps.GetUser("testUser3").CompanyID = compOps.GetCompany("testCompany1").ID;
            userOps.GetUser("testUser4").CompanyID = compOps.GetCompany("testCompany2").ID;
            userOps.GetUser("testUser5").CompanyID = compOps.GetCompany("testCompany2").ID;
            userOps.GetUser("testUser6").CompanyID = compOps.GetCompany("testCompany2").ID;
            userOps.GetUser("testUser7").CompanyID = compOps.GetCompany("testCompany3").ID;
            userOps.GetUser("testUser8").CompanyID = compOps.GetCompany("testCompany3").ID;
        }

        public static void setRecCompIDs(DBCompanyOps compOps, DBReceptacleOps recOps)
        {
            recOps.GetReceptacle("testRec1").CompanyID = compOps.GetCompany("testCompany1").ID;
            recOps.GetReceptacle("testRec2").CompanyID = compOps.GetCompany("testCompany1").ID;
            recOps.GetReceptacle("testRec3").CompanyID = compOps.GetCompany("testCompany2").ID;
            recOps.GetReceptacle("testRec4").CompanyID = compOps.GetCompany("testCompany2").ID;
            recOps.GetReceptacle("testRec5").CompanyID = compOps.GetCompany("testCompany3").ID;
            recOps.GetReceptacle("testRec6").CompanyID = compOps.GetCompany("testCompany3").ID;
        }

        public static void setRecCoordinates(DBCompanyOps compOps, DBReceptacleOps recOps)
        {
            List<Receptacle> network = recOps.GetNetwork(compOps.GetCompany("testCompany1").ID);

            foreach(Receptacle rec in network)
            {
                rec.Latitude = "0.0000";
                rec.Longitude = "0.0000";
            }

            network = recOps.GetNetwork(compOps.GetCompany("testCompany2").ID);

            foreach(Receptacle rec in network)
            {
                rec.Latitude = "1.0000";
                rec.Longitude = "1.0000";
            }

            network = recOps.GetNetwork(compOps.GetCompany("testCompany3").ID);

            foreach(Receptacle rec in network)
            {
                rec.Latitude = "2.0000";
                rec.Longitude = "2.0000";
            }
        }
    }
}