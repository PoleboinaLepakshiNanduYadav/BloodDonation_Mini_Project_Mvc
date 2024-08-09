using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BloodDonation_Mini_Project_Mvc.Models
{
    public class BloodData
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string BloodBankName { set; get; }
        public string Address { set; get; }
        public Int64 ContactNumber { set; get; }
        public string Password { set; get; }
        public string City { set; get; }
        public int Age { set; get; }
        public string BloodGroup { set; get; }
    }
    public class BloodOperations
    {
        string constr = @"server=NANDUYADAV\SQLEXPRESS;user id=sa;password=Lepakshi;database=WebApplications";
        SqlConnection con;SqlCommand cmd;
        public int Insert(BloodData BD)
        {
            con = new SqlConnection(constr);
            string Query = "Insert into BloodDetails Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@p1", BD.Id);
            cmd.Parameters.AddWithValue("@p2", BD.Name);
            cmd.Parameters.AddWithValue("@p3", BD.BloodBankName);
            cmd.Parameters.AddWithValue("@p4", BD.Address);
            cmd.Parameters.AddWithValue("@p5", BD.ContactNumber);
            cmd.Parameters.AddWithValue("@p6", BD.Password);
            cmd.Parameters.AddWithValue("@p7", BD.City);
            cmd.Parameters.AddWithValue("@p8", BD.Age);
            cmd.Parameters.AddWithValue("@p9", BD.BloodGroup);
            con.Open();
            int R = cmd.ExecuteNonQuery();
            con.Close();
            return R;
        }
        public int Update(BloodData BD)
        {
            con = new SqlConnection(constr);
            string Query = "Update BloodDetails Set Name=@p1,BloodBankName=@p2,Address=@p3,ContactNumber=@p4,Password=@p5,City=@p6,Age=@p7,BloodGroup=@p8 where Id=@p9";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@p9", BD.Id);
            cmd.Parameters.AddWithValue("@p1", BD.Name);
            cmd.Parameters.AddWithValue("@p2", BD.BloodBankName);
            cmd.Parameters.AddWithValue("@p3", BD.Address);
            cmd.Parameters.AddWithValue("@p4", BD.ContactNumber);
            cmd.Parameters.AddWithValue("@p5", BD.Password);
            cmd.Parameters.AddWithValue("@p6", BD.City);
            cmd.Parameters.AddWithValue("@p7", BD.Age);
            cmd.Parameters.AddWithValue("@p8", BD.BloodGroup);
            con.Open();
            int R = cmd.ExecuteNonQuery();
            con.Close();
            return R;
        }
        public int Delete(int Id)
        {
            con = new SqlConnection(constr);
            string Query = "Delete BloodDetails where Id=@p1";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@p1", Id);
            con.Open();
            int R = cmd.ExecuteNonQuery();
            con.Close();
            return R;
        }
        public BloodData View(int Id)
        {
            BloodData BD = null;
            con = new SqlConnection(constr);
            string Query = "select * From  BloodDetails where Id=@p1";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@p1", Id);
            con.Open();
            SqlDataReader Dr = cmd.ExecuteReader();
            if(Dr.Read())
            {
                BD = new BloodData();
                BD.Id = Convert.ToInt32(Dr[0]);
                BD.Name = Dr[1].ToString();
                BD.BloodBankName = Dr[2].ToString();
                BD.Address = Dr[3].ToString();
                BD.ContactNumber = Convert.ToInt64(Dr[4]);
                BD.Password = Dr[5].ToString();
                BD.City = Dr[6].ToString();
                BD.Age = Convert.ToInt32(Dr[7]);
                BD.BloodGroup = Dr[8].ToString();
            }
            con.Close();
            return BD;
        }
        public List<BloodData> ViewAll()
        {
            con = new SqlConnection(constr);
            string Query = "select * From  BloodDetails";
            cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader Dr = cmd.ExecuteReader();
            List<BloodData> Blist = new List<BloodData>();
            while (Dr.Read())
            {
                BloodData BD = new BloodData();
                BD.Id = Convert.ToInt32(Dr[0]);
                BD.Name = Dr[1].ToString();
                BD.BloodBankName = Dr[2].ToString();
                BD.Address = Dr[3].ToString();
                BD.ContactNumber = Convert.ToInt64(Dr[4]);
                BD.Password = Dr[5].ToString();
                BD.City = Dr[6].ToString();
                BD.Age = Convert.ToInt32(Dr[7]);
                BD.BloodGroup = Dr[8].ToString();
                Blist.Add(BD);
            }
            con.Close();
            return Blist;
        }
    }
}