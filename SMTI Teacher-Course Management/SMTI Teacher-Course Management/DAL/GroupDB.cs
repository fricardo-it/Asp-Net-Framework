using SMTI_Teacher_Course_Management.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_Teacher_Course_Management.DAL
{
    public class GroupDB
    {
        public static List<Group> GetAllRecords()
        {
            List<Group> listG = new List<Group>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Groups", conn);
            SqlDataReader dr = cmdSelectAll.ExecuteReader();
            Group group;
            while (dr.Read())
            {
                group = new Group();
                group.GroupNumber = Convert.ToInt32(dr["GroupNumber"]);
                group.Description = dr["Description"].ToString();

                listG.Add(group);
            }

            conn.Close();
            return listG;
        }
    }
}