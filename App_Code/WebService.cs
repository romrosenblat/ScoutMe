using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text;

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
    public string GetAllTeamsMinimized()
    {
        Teams team = new Teams();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(team.GetAllTeamsMinimized());
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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string SearchAthlete()
    {
        Athlete ath = new Athlete();
        JavaScriptSerializer js = new JavaScriptSerializer();
        string result = js.Serialize(ath.SearchAthlete());
        return result;
    }

    public int GetSoccertats(int id, bool isGoaley)
    {
        DBservices dbs = new DBservices();
        return dbs.spSoccer_Stats(id, isGoaley);
    }

    public int GetBasketBallStats(int id)
    {
        DBservices dbs = new DBservices();
        return dbs.spBasketBall_Stats(id);
    }
    public int GetHandBallStats(int id, bool isGoaley)
    {
        DBservices dbs = new DBservices();
        return dbs.sp_HandBall_Stats(id, isGoaley);
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public int SetSoccerStats(int athleteID, DateTime Date, float Minutes, int vsTeam,
        float Goals, float Assits, float TotalShots,
        float Passes, float Saves_G, float ShotsOnTarget_G, float Goals_G, bool isGoaly)
    {
         string vsTeamName = Teams.GetTeamById(vsTeam);
        string athleteTeam = myTeamName;
        string tempDesc = Date.ToShortDateString() + ", " + athleteTeam + " Vs. " + vsTeamName;
        Game g = new Game()
         {
            AthleteID = athleteID,
            Date = Date,
            Minutes =(int)Minutes,
            Description = tempDesc,
            SportId = 1

        };
        int gameId = g.InsertNewGame();

        Soccer b = new Soccer(){
              GameId = gameId,
            AthleteID = athleteID,
            Date = Date,
            Description = tempDesc,
            Goals = Goals,
            Assits = Assits,
            TotalShots = TotalShots,
            Passes = Passes,
            Saves_G = Saves_G,
            ShotsOnTarget_G = ShotsOnTarget_G,
            Goals_G = Goals_G,
            Minutes = (int)Minutes,
            RedCard = 0,
        };
        b.insertGameInfoSoccer(isGoaly);
        return 1;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public int SetHandBallStats(int athleteID, DateTime Date, float Minutes, int vsTeam,string myTeamName,
        float Goals, float Shots, float TwoMin, float SevenM_Goal,
        float Saves_G, float Shots_G, bool isGoaly)
    {
        string vsTeamName = Teams.GetTeamById(vsTeam);
        string athleteTeam = myTeamName;
        string tempDesc = Date.ToShortDateString() + ", " + athleteTeam + " Vs. " + vsTeamName;
        Game g = new Game()
        {
            AthleteID = athleteID,
            Date = Date,
            Minutes =(int)Minutes,
            Description = tempDesc,
            SportId = 3

        };
        int gameId = g.InsertNewGame();

        //int gameId = insert game get id
        HandBall b = new HandBall()
        {
            GameId = gameId,
            AthleteID = athleteID,
            Date = Date,
            Description = tempDesc,
            Goals = Goals,
            Minutes = (int)Minutes,
            RedCard = 0,
            Saves_G = Saves_G,
            SevenM_Goal = SevenM_Goal,
            Shots = Shots,
            Shots_G = Shots_G,
            SportId = 3,
            TwoMin = TwoMin,
            YellowCard = 0
        };
        b.insertGameInfoHandball(isGoaly);

        return 1;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public int SetBasketBallStats(int athleteID, DateTime Date, float Minutes, int vsTeam,
        float Points, float Assits, float Rebounds, float Blocks, float TO, float Fouls, float STL)
    {
        string vsTeamName = Teams.GetTeamById(vsTeam);
        string athleteTeam = myTeamName;
        string tempDesc = Date.ToShortDateString() + ", " + athleteTeam + " Vs. " + vsTeamName;
        Game g = new Game()
        {
            AthleteID = athleteID,
            Date = Date,
            Minutes = (int)Minutes,
            Description = tempDesc,
            SportId = 3

        };
        int gameId = g.InsertNewGame();

        //int gameId = insert game get id

        BasketBall b = new BasketBall()
        {
            GameId = gameId,
            AthleteID = athleteID,
            Date = Date,
            Description = tempDesc,
            Points = Points,
            Assits = Assits,
            Rebounds = Rebounds,
            Blocks = Blocks,
            TO =TO,
            Fouls =   Fouls,
            STL = STL
        };
        b.insertGameInfoBasketBall();
        return 1;
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string AdvanceSearch(decimal hightMax,decimal hightMin,decimal weightMin,decimal wegithMax,string sex,int sportID)
    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.AdvanceSerch(hightMax,hightMin,weightMin,wegithMax,sex,sportID));
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string AdvanceSearch_Soccer(decimal hightMax, decimal hightMin, decimal weightMin, decimal wegithMax, string sex,
        int _goalsMin, int _goalsMax, int _assitsMin, int _assitsMax)
    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.AdvanceSearch_Soccer(hightMax, hightMin, weightMin, wegithMax, sex,_goalsMin,_goalsMax, _assitsMin,_assitsMax));
    }


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string AdvanceSearch_HandBall(decimal hightMax, decimal hightMin, decimal weightMin, decimal wegithMax, string sex,
        int _goalsMin, int _goalsMax, int _shotsMin, int _shotsMax)
    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.AdvanceSearch_HandBall(hightMax, hightMin, weightMin, wegithMax, sex, _goalsMin, _goalsMax, _shotsMin,_shotsMax));
    }


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string AdvanceSearch_BasketBall(decimal hightMax, decimal hightMin, decimal weightMin, decimal wegithMax, string sex,
        int _pointsMin, int _pointsMax, int _assitsMin, int _assitsMax,int _reboundMin, int _reboundMax)
    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.AdvanceSearch_BasketBall(hightMax, hightMin, weightMin, wegithMax, sex,_pointsMin,_pointsMax,_assitsMin,_assitsMax,_reboundMin,_reboundMax));
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetFeed()
    {
        Feed feed = new Feed();
        return DataTableToJsonObj(feed.GetLiveFeed());
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetAthleteCount()

    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.GetAthCount());
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string GetCitiesCount()

    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.GetCityCount());
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public string UsersCount()

    {
        Athlete ath = new Athlete();
        return DataTableToJsonObj(ath.GetUsersCount());
    }

    public string DataTableToJsonObj(DataTable dt)
    {
        DataSet ds = new DataSet();
        ds.Merge(dt);
        StringBuilder JsonString = new StringBuilder();
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            JsonString.Append("[");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                JsonString.Append("{");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    if (j < ds.Tables[0].Columns.Count - 1)
                    {
                        JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");
                    }
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    JsonString.Append("}");
                }
                else
                {
                    JsonString.Append("},");
                }
            }
            JsonString.Append("]");
            return JsonString.ToString();
        }
        else
        {
            return null;
        }
    }  

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public List<HandBall> GetHBStats(int athleteID)
    {
        return HandBall.GetStatsForAthlere(athleteID);
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public List<Soccer> GetSoStats(int athleteID)
    {
        return Soccer.GetStatsForAthlere(athleteID);
        
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public List<BasketBall> GetBBStats(int athleteID)
    {
        return BasketBall.GetStatsForAthlere(athleteID);
        

    }



    public string myTeamName { get; set; }
}


