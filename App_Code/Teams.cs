using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Collections.Generic;
/// <summary>
/// Summary description for Teams
/// </summary>
public class Teams
{
    public Teams()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int teamNumber;
    public int TeamNumber
    {
        get { return teamNumber; }
        set { teamNumber = value; }
    }

    string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    string team_name;
    public string Team_name
    {
        get { return team_name; }
        set { team_name = value; }
    }
    string first_name;
    public string First_name
    {
        get { return first_name; }
        set { first_name = value; }
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
    string role;
    public string Role
    {
        get { return role; }
        set { role = value; }
    }
    public DataTable readTeamsDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Teams");
        // save the dataset in a session object

        return dbs.dt;
    }
    public void insertTeam()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Teams");

        DataRow dr = dbs.dt.NewRow();
        dr["password"] = password;
        dr["team_name"] = team_name;
        dr["first_name"] = first_name;
        dr["last_name"] = last_name;
        dr["role"] = role;
        dr["phone"] = phone;
        dr["eMail"] = eMail;
        dr["city"] = city;
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }

    public static string GetTeamById(int TeamId)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select team_name from Teams where teamNum="+ TeamId);
        string teamName = "";
        foreach (DataRow dr in dbs.dt.Rows)
        {

            teamName = dr["team_name"].ToString();
        }
        return teamName;
    }

    public List<string> GetAllTeams()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select CAST(teamNum as nvarchar(50))+' '+[team_name] as 'team_name' from Teams");
        List<string> teamsList = new List<string>();
        foreach (DataRow dr in dbs.dt.Rows)
        {

            string team = dr["team_name"].ToString();
            teamsList.Add(team);
        }
        return teamsList;
    }

    public List<Teams> GetAllTeamsMinimized()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select teamNum ,team_name from Teams");
        List<Teams> teamsList = new List<Teams>();
        foreach (DataRow dr in dbs.dt.Rows)
        {
            teamsList.Add(new Teams()
            {
                TeamNumber = Convert.ToInt32(dr["teamNum"].ToString()),
                Team_name = dr["team_name"].ToString()
            });
        }
        return teamsList;
    }

    public Teams GetTeamInfo(string email, string pass)
    {

        string where = "[eMail] ='" + email + "' and [password] = '" + pass + "' ";
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseAuthentication(@"select * from Teams where ", where);
        DataRow dr = dbs.dt.Rows[0];
        Teams team = new Teams();
        team.teamNumber = int.Parse(dr["teamNum"].ToString());
        team.team_name = dr["team_name"].ToString();
        team.first_name = dr["first_name"].ToString();
        team.last_name = dr["last_name"].ToString();
        team.role = dr["role"].ToString();
        team.phone = dr["phone"].ToString();
        team.eMail = dr["eMail"].ToString();
        team.city = dr["city"].ToString();
        team.password = dr["password"].ToString();

        return team;
    }

}