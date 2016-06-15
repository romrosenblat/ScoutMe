using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
/// <summary>
/// Summary description for HandBall
/// </summary>
public class HandBall : Game
{
    protected float goals;
    protected float shots;
    protected float twoMin;
    protected float sevenM_Goal;
    protected float saves_G;
    protected float shots_G;

    public float Goals { get { return goals; } set { goals = value; } }
    public float Shots { get { return shots; } set { shots = value; } }
    public float TwoMin { get { return twoMin; } set { twoMin = value; } }
    public float SevenM_Goal { get { return sevenM_Goal; } set { sevenM_Goal = value; } }
    public float Saves_G { get { return saves_G; } set { saves_G = value; } }
    public float Shots_G { get { return shots_G; } set { shots_G = value; } }
    public HandBall()
    {

    }

    public static List<HandBall> GetStatsForAthlere(int athleteID)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select * from [dbo].[Game_HandBall] where [athleteID]= " + athleteID);
        List<HandBall> players = new List<HandBall>();

        foreach (DataRow dr in dbs.dt.Rows)
        {
            HandBall player = new HandBall();
            try
            {
                player.athleteID = athleteID;
                player.date = Convert.ToDateTime(dr["date"]);
                player.goals = Convert.ToInt32(dr["goals"]);
                player.shots = Convert.ToInt32(dr["shots"]);
                player.twoMin = Convert.ToInt32(dr["2_Min"]);
                player.sevenM_Goal = Convert.ToInt32(dr["7M_Goal"]);
                player.redCard = Convert.ToInt32(dr["redCard"]);
                player.yellowCard = Convert.ToInt32(dr["yellowCard"]);
                player.minutes = Convert.ToInt32(dr["minutes"]);
                player.description = dr["description"].ToString();
                player.saves_G = Convert.ToInt32(dr["saves_G"]);
                player.shots_G= Convert.ToInt32(dr["shots_G"]);

            }
            catch (Exception ex)
            {

                //TODO - problem in the query or one of the retuned values             
            }
            players.Add(player);
        }


        return players;
    }


    public void insertGameInfoHandball(bool isGoaley)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Game_HandBall");

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
            dr["shots_G"] = shots_G;
        }
        dr["goals"] = goals;
        dr["shots"] = shots;
        dr["2_Min"] = twoMin;
        dr["7M_Goal"] = sevenM_Goal;
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }
}

