using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
/// <summary>
/// Summary description for Soccer
/// </summary>
public class Soccer : Game
{

    protected float goals;
    protected float assists;
    protected float totalShots;
    protected float passes;
    protected float saves_G;
    protected float shotsOnTarget_G;
    protected float goals_G;

    public float Goals { get { return goals; } set { goals = value; } }
    public float Assits { get { return assists; } set { assists = value; } }
    public float TotalShots { get { return totalShots; } set { totalShots = value; } }
    public float Passes { get { return passes; } set { passes = value; } }
    public float Saves_G { get { return saves_G; } set { saves_G = value; } }
    public float ShotsOnTarget_G { get { return shotsOnTarget_G; } set { shotsOnTarget_G = value; } }
    public float Goals_G { get { return goals_G; } set { goals_G = value; } }
    public Soccer()
    {

    }


    public static List<Soccer> GetStatsForAthlere(int athleteID)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select * from [dbo].[Game_Soccer] where [athleteID]= " + athleteID);
        List<Soccer> players = new List<Soccer>();

        foreach (DataRow dr in dbs.dt.Rows)
        {
            Soccer player = new Soccer();
            try
            {
                player.athleteID = athleteID;
                player.date = Convert.ToDateTime(dr["date"]);
                player.goals = Convert.ToInt32(dr["goals"]);
                player.totalShots = Convert.ToInt32(dr["total_shots"]);
                player.assists = Convert.ToInt32(dr["assists"]);
                player.passes = Convert.ToInt32(dr["passes"]);
                player.redCard = Convert.ToInt32(dr["redCard"]);
                player.yellowCard = Convert.ToInt32(dr["yellowCard"]);
                player.minutes = Convert.ToInt32(dr["minutes"]);
                player.description = dr["description"].ToString();
            }
            catch (Exception ex)
            {

                //TODO - problem in the query or one of the retuned values             
            }
            if (Athlete.GetIsGoalyByAthleteId(player.athleteID))
            {

            }

            players.Add(player);
        }


        return players;
    }


    public DataTable readSoccerDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Game_Soccer");
        // save the dataset in a session object
        HttpContext.Current.Session["userDataSet"] = dbs;
        return dbs.dt;
    }

    public void insertGameInfoSoccer(bool isGoaley)
    {

        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Game_Soccer");


        DataRow dr = dbs.dt.NewRow();
        dr["athleteID"] = athleteID;
        dr["sportId"] = sportId;
        dr["date"] = date;
        dr["minutes"] = minutes;
        dr["redCard"] = redCard;
        dr["yellowCard"] = yellowCard;
        dr["description"] = description;
        if (isGoaley)
        {

            dr["saves_G"] = saves_G;
            dr["shotsOnTarget_G"] = shotsOnTarget_G;
            dr["GoalsC_G"] = goals_G;
        }
        dr["goals"] = goals;
        dr["assists"] = assists;
        dr["total_shots"] = totalShots;
        dr["passes"] = passes;
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database


        Feed feed = new Feed();
        feed.InsertToFeed_NewGame(athleteID, description);
    }
}