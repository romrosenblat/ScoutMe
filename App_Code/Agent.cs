using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/// <summary>
/// Summary description for Agent
/// </summary>
public class Agent
{
    public Agent()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int licenceNumber;
    public int LicenceNumber
    {
        get { return licenceNumber; }
        set { licenceNumber = value; }
    }

    string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    string first_name;
    public string First_name
    {
        get { return first_name; }
        set { first_name = value; }
    }
    string fullName;
    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }
    string last_name;
    public string Last_name
    {
        get { return last_name; }
        set { last_name = value; }
    }
    string phone;
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    string eMail;
    public string Email
    {
        get { return eMail; }
        set { eMail = value; }
    }
    string city;
    public string City
    {
        get { return city; }
        set { city = value; }
    }
    DateTime dob;
    public DateTime Dob
    {
        get { return dob; }
        set { dob = value; }
    }
    public DataTable readAgentDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Agent");
        // save the dataset in a session object

        return dbs.dt;
    }

    public void insertAgent()
    {

        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Agent");

        DataRow dr = dbs.dt.NewRow();
        dr["agentNum"] = licenceNumber;
        dr["password"] = password;
        dr["first_name"] = first_name;
        dr["last_name"] = last_name;
        dr["date_of_birth"] = dob;
        dr["phone"] = phone;
        dr["eMail"] = eMail;
        dr["city"] = city;
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }

    public List<string> GetAllagents()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select CAST(agentNum as nvarchar(50))+' '+first_name+' '+last_name as 'name' from [dbo].[Agent]");
        List<string> agentList = new List<string>();
        foreach (DataRow dr in dbs.dt.Rows)
        {

            string agentName = dr["name"].ToString();
            agentList.Add(agentName);
        }
        return agentList;
    }
    public Agent GetAgentInfo(string email, string pass)
    {

        string where = "[eMail] ='" + email + "' and [password] = '" + pass + "' ";
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseAuthentication(@"select * from Agent where ", where);
        DataRow dr = dbs.dt.Rows[0];
        Agent agent = new Agent();
        agent.licenceNumber = int.Parse(dr["agentNum"].ToString());
        agent.first_name = dr["first_name"].ToString();
        agent.last_name = dr["last_name"].ToString();
        agent.dob = (DateTime)dr["date_of_birth"];
        agent.phone = dr["phone"].ToString();
        agent.eMail = dr["eMail"].ToString();
        agent.city = dr["city"].ToString();
        agent.password = dr["password"].ToString();

        return agent;
    }
    public string[] BreakNAme(string fullName)
    {
        string[] arr = fullName.Split(' ');

        return arr;
    }
}