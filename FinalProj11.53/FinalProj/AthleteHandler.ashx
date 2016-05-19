<%@ WebHandler Language="C#" Class="AthleteHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

public class AthleteHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string term = context.Request["terms"] ?? "";
        List<string> listAth = new List<string>();
        string cs = ConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("sp_SearchAthlete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@terms",
                Value = term
            });
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listAth.Add(rdr["first_name"].ToString());
                    listAth.Add(rdr["last_name"].ToString());
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        context.Response.Write(js.Serialize(listAth));



    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}