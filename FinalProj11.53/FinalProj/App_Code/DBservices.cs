using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBservices
/// </summary>
public class DBservices
{

    public SqlDataAdapter da;
    public DataTable dt;
    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }
    public DBservices ReadFromDataBase(string conString, string tableName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            string selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReadFromDataBaseCommandWhere(string command, int ID)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect("bgroup33_prodConnectionString"); // open the connection to the database/

            string selectStr = command + ID; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReadFromDataBaseAuthentication(string command, string where)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect("bgroup33_prodConnectionString"); // open the connection to the database/

            string selectStr = command + where; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public DBservices ReadFromDataBaseCommand(string command)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect("bgroup33_prodConnectionString"); // open the connection to the database/

            string selectStr = command; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    //public DBservices ReadFromDataBaseCommand(int name)
    //{

    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = "Data Source=media.ruppin.ac.il;Initial Catalog=bgroup33_prod;Persist Security Info=True;User ID=bgroup33;Password=bgroup33_99691";

    //    string type;
    //    string typer = "select * from Athlete where athleteID ="+name;
    //    SqlCommand findType = new SqlCommand(typer, con);
    //    con.Open();
    //    type = Convert.ToString(findType.ExecuteScalar());
    //    con.Close();
    //    return type;
    //}
    public void Update()
    {
        // the command build will automatically create insert/update/delete commands according to the select command
        SqlCommandBuilder builder = new SqlCommandBuilder(da);
        da.Update(dt);
    }

    public string AuthSP(string userEmail, string password)
    {
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("spAuthUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUserEmail = new SqlParameter("@@Email", userEmail);
            SqlParameter paramUserPass = new SqlParameter("@password", password);

            cmd.Parameters.Add(paramUserEmail);
            cmd.Parameters.Add(paramUserPass);

            try
            {
                con.Open();
                int returenCode = cmd.ExecuteNonQuery();
                string type = "";
                switch (returenCode)
                {
                    case 1:
                        type = "Soccer";
                        break;
                    case 2:
                        type = "BasketBall";
                        break;
                    case 3:
                        type = "HandBall";
                        break;

                }
                return type;
            }
            catch (Exception ex)
            {
                return "No_User";

            }
            finally
            {
                con.Close();
            }
        }
    }
    public int spBasketBall_Stats(int athleteID)
    {
        
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("spBasketBall_Stats", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAthleteID = new SqlParameter("@athleteID", athleteID);

            cmd.Parameters.Add(paramAthleteID);

            try
            {
                con.Open();

                int a = cmd.ExecuteNonQuery();
                return a;
            }
            catch (Exception ex)
            {
                
                return -1;

            }
            finally
            {
                con.Close();


            }
        }
    }
    public int sp_HandBall_Stats(int athleteID, bool isGoaley)
    {
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("sp_HandBall_Stats", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAthleteID = new SqlParameter("@athleteID", athleteID);
            SqlParameter paramIsGoaley = new SqlParameter("@isGoaley", isGoaley);

            cmd.Parameters.Add(paramAthleteID);
            cmd.Parameters.Add(paramIsGoaley);

            try
            {
                con.Open();
                int returenCode = cmd.ExecuteNonQuery();
                return returenCode;
            }
            catch (Exception)
            {
                return -1;

            }
            finally
            {
                con.Close();
            }
        }
    }
    public int spSoccer_Stats(int athleteID, bool isGoaley)
    {
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("spSoccer_Stats", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAthleteID = new SqlParameter("@athleteID", athleteID);
            SqlParameter paramIsGoaley = new SqlParameter("@isGoaley", isGoaley);

            cmd.Parameters.Add(paramAthleteID);
            cmd.Parameters.Add(paramIsGoaley);

            try
            {
                con.Open();
                int returenCode = cmd.ExecuteNonQuery();
                return returenCode;
            }
            catch (Exception)
            {
                return -1;

            }
            finally
            {
                con.Close();
            }
        }
    }

    public int spUpdate_Athlete(int athleteID, string firstName, string lastNAme, decimal hight, decimal weight, string city, string phone
        , string eMail)
    {
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("spUpdate_Athlete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAthleteID = new SqlParameter("@athleteID", athleteID);
            SqlParameter paramAthletFirst = new SqlParameter("@FirstName", firstName);
            SqlParameter paramAthleteLast = new SqlParameter("@lasttName", lastNAme);
            SqlParameter paramAthleteHight = new SqlParameter("@hight", hight);
            SqlParameter paramAthleteWieght = new SqlParameter("@weight", weight);
            SqlParameter paramAthleteCity = new SqlParameter("@city", city);
            SqlParameter paramAthletePhone = new SqlParameter("@phone", phone);
            SqlParameter paramAthleteEmail = new SqlParameter("@eMail", eMail);

            cmd.Parameters.Add(paramAthleteID);
            cmd.Parameters.Add(paramAthletFirst);
            cmd.Parameters.Add(paramAthleteLast);
            cmd.Parameters.Add(paramAthleteHight);
            cmd.Parameters.Add(paramAthleteWieght);
            cmd.Parameters.Add(paramAthleteCity);
            cmd.Parameters.Add(paramAthletePhone);
            cmd.Parameters.Add(paramAthleteEmail);

            try
            {
                con.Open();
                int returenCode = (int)cmd.ExecuteNonQuery();
                return returenCode;
            }
            catch (Exception)
            {
                return -1;

            }
            finally
            {
                con.Close();
            }
        }
    }
    public int spUpdate_Agent(int agentNum, string firstName, string lastNAme, string city, string phone
       , string eMail)
    {
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("spUpdate_Agent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAgentNum = new SqlParameter("@agentNum", agentNum);
            SqlParameter paramAgentFirst = new SqlParameter("@firstName", firstName);
            SqlParameter paramAgentLast = new SqlParameter("@lasttName", lastNAme);
            SqlParameter paramAgentCity = new SqlParameter("@city", city);
            SqlParameter paramAgentPhone = new SqlParameter("@phone", phone);
            SqlParameter paramAgentEmail = new SqlParameter("@eMail", eMail);

            cmd.Parameters.Add(paramAgentNum);
            cmd.Parameters.Add(paramAgentFirst);
            cmd.Parameters.Add(paramAgentLast);
            cmd.Parameters.Add(paramAgentCity);
            cmd.Parameters.Add(paramAgentPhone);
            cmd.Parameters.Add(paramAgentEmail);

            try
            {
                con.Open();
                int returenCode = (int)cmd.ExecuteNonQuery();
                return returenCode;
            }
            catch (Exception )
            {
                return -1;

            }
            finally
            {
                con.Close();
            }
        }
    }
    public int spUpdate_Team(int teamNum, string firstName, string lastNAme, string city, string phone
     , string eMail)
    {
        string cStr = WebConfigurationManager.ConnectionStrings["bgroup33_prodConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cStr))
        {
            SqlCommand cmd = new SqlCommand("spUpdate_Team", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramTeamNum = new SqlParameter("@teamNum", teamNum);
            SqlParameter paramTeamFirst = new SqlParameter("@FirstName", firstName);
            SqlParameter paramTeamLast = new SqlParameter("@lasttName", lastNAme);
            SqlParameter paramTeamCity = new SqlParameter("@city", city);
            SqlParameter paramTeamPhone = new SqlParameter("@phone", phone);
            SqlParameter paramTeamEmail = new SqlParameter("@eMail", eMail);

            cmd.Parameters.Add(paramTeamNum);
            cmd.Parameters.Add(paramTeamFirst);
            cmd.Parameters.Add(paramTeamLast);
            cmd.Parameters.Add(paramTeamCity);
            cmd.Parameters.Add(paramTeamPhone);
            cmd.Parameters.Add(paramTeamEmail);

            try
            {
                con.Open();
                int returenCode = (int)cmd.ExecuteNonQuery();
                return returenCode;
            }
            catch (Exception)
            {
                return -1;

            }
            finally
            {
                con.Close();
            }
        }
    }

}