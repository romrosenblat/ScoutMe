using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for Feed
/// </summary>
public class Feed
{
    public Feed()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int athleteID;
    public int AthleteID
    {
        get { return athleteID; }
        set { athleteID = value; }
    }

    string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }


    public void InsertToFeed_NewGame(int id, string desc)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("sp_insertFeed_NewGame", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAthleteID = new SqlParameter("@athleteID", id);
            SqlParameter paramDescription = new SqlParameter("@desc", desc);


            cmd.Parameters.Add(paramAthleteID);
            cmd.Parameters.Add(paramDescription);


            try
            {

                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                adptr.Fill(ds, "t1");
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
    
    }
}