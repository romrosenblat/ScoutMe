using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string HelloWorld(int num)
    {
        return "Hello World" + num;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string InsertAthlete(string pass, string firstName, string lastName, string sportName, DateTime dob, string phone,
      string eMail, decimal hight, decimal weight, string city, string agentName, string teamName, bool isGoaley, string sex)
    {
        string status;
        try
        {
            Athlete athelete = new Athlete();
            athelete.readAthletesDB();
            athelete.Password = pass;
            athelete.First_name = firstName;
            athelete.Last_name = lastName;
            switch (sportName)
            {
                case "Basketball":
                    athelete.SportID = 2;
                    break;
                case "Handball":
                    athelete.SportID = 3;
                    break;
                case "Soccer":
                    athelete.SportID = 1;
                    break;
            }
            athelete.Dob = dob;
            athelete.Phone = phone;
            athelete.Email = eMail;
            athelete.Hight = hight;
            athelete.Weight = weight;
            athelete.City = city;
            athelete.AgentName = agentName;
            athelete.TeamName = teamName;
            athelete.IsGoaley = isGoaley;
            athelete.Sex = sex;
            athelete.insertAthlete();
            status = "Insered succsusfully";
        }
        catch (Exception ex)
        {

            status = "Some error had acured: " + ex;
        }

        return status;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string InsertAgent(int agentNum, string pass, string firstName, string lastName, DateTime dob, string phone,
    string eMail, string city)
    {
        string status;
        try
        {
            Agent agent = new Agent();
            agent.readAgentDB();
            agent.LicenceNumber = agentNum;
            agent.Password = pass;
            agent.First_name = firstName;
            agent.Last_name = lastName;
            agent.Dob = dob;
            agent.Phone = phone;
            agent.Email = eMail;
            agent.City = city;
            agent.insertAgent();
            status = "Insered succsusfully";
        }
        catch (Exception ex)
        {

            status = "Some error had acured: " + ex;
        }

        return status; ;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string Insertteam(string teamName, string pass, string firstName, string lastName, string role, string phone,
   string eMail, string city)
    {
        string status;
        try
        {
            Teams team = new Teams();
            team.readTeamsDB();
            team.Team_name = teamName;
            team.Password = pass;
            team.First_name = firstName;
            team.Last_name = lastName;
            team.Role = role;
            team.Phone = phone;
            team.Email = eMail;
            team.City = city;
            team.insertTeam();
            status = "Insered succsusfully";
        }
        catch (Exception ex)
        {

            status = "Some error had acured: " + ex;
        }

        return status;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAthleteInfo(string name, string pass)
    {
        Athlete ath = new Athlete();
        ath.readAthletesDB();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string serializedResult = js.Serialize(ath.GetAthleteInfo(name, pass));
        return serializedResult;
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAgentInfo(string name, string pass)
    {
        Agent agent = new Agent();
        agent.readAgentDB();
        var serializer = new JavaScriptSerializer();
        var serializedResult = serializer.Serialize(agent.GetAgentInfo(name, pass));
        return serializedResult;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetTeamInfo(string name, string pass)
    {
        Teams team = new Teams();
        team.readTeamsDB();
        var serializer = new JavaScriptSerializer();
        var serializedResult = serializer.Serialize(team.GetTeamInfo(name, pass));
        return serializedResult;
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAthleteVideo(int athleteID)
    {
        Videos video = new Videos();
        video.readVideosDB();
        var serializer = new JavaScriptSerializer();
        var serializedResult = serializer.Serialize(video.GetAthleteVideos(athleteID));
        return serializedResult;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAllAgents()
    {
        Agent agent = new Agent();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(agent.GetAllagents());
        return jsonString;

    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAllTeams()
    {
        Teams team = new Teams();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(team.GetAllTeams());
        return jsonString;
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public int UpdateAthlete(int athleteID, string firstName, string lastNAme, decimal hight, decimal weight, string city, string phone
        , string eMail)
    {
        try
        {

            DBservices dbs = new DBservices();
            return dbs.spUpdate_Athlete(athleteID, firstName, lastNAme, hight, weight, city, phone, eMail);

        }
        catch (Exception)
        {

            return -1;
        }
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public int UpdateAgent(int agentNum, string firstName, string lastNAme, string city, string phone
       , string eMail)
    {
        try
        {

            DBservices dbs = new DBservices();
            return dbs.spUpdate_Agent(agentNum, firstName, lastNAme, city, phone, eMail);

        }
        catch (Exception)
        {

            return -1;
        }
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public int UpdateTeam(int teamNum, string firstName, string lastNAme, string city, string phone
     , string eMail)
    {
        try
        {

            DBservices dbs = new DBservices();
            return dbs.spUpdate_Team(teamNum, firstName, lastNAme, city, phone, eMail);

        }
        catch (Exception)
        {

            return -1;
        }
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string InsertNewVideo(int athleteID, string desc, DateTime date, string url)
    {
        Videos vid = new Videos();
        string status;
        try
        {
            vid.AthleteId = athleteID;
            vid.Descripition = desc;
            vid.VideoURL = url;
            vid.Date = date;
            vid.insertVideo();
            status = "Insered succsusfully";
        }
        catch (Exception ex)
        {

            status = "Some error had acured: " + ex;
        }

        return status; ;
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAthletesVideos(int athleteID)
    {
        Videos vid = new Videos();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(vid.GetAthleteVideos(athleteID));
        return jsonString;

    }


}
