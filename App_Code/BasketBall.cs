using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
/// <summary>
/// Summary description for BasketBall
/// </summary>
public class BasketBall : Game
{
    protected float points;
    protected float assists;
    protected float rebounds;
    protected float blocks;
    protected float _TO;
    protected float fouls;
    protected float stl;

    public float Points     { get { return points; } set { points = value; } }
    public float Assits  { get { return assists; } set { assists = value; } }
    public float Rebounds { get { return rebounds; } set { rebounds = value; } }
    public float Blocks  { get { return blocks; } set { blocks = value; } }
    public float TO          { get { return _TO; } set { _TO = value; } }
    public float Fouls   { get { return fouls; } set { fouls = value; } }
    public float STL         { get { return stl; } set { stl = value; } }
    public BasketBall()
    {
       
    }
    public static List<BasketBall> GetStatsForAthlere(int athleteID)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseCommand("select * from [dbo].[Game_BasketBall] where [athleteID]= " + athleteID);
        List<BasketBall> players = new List<BasketBall>();

        foreach (DataRow dr in dbs.dt.Rows)
        {
            BasketBall player = new BasketBall();
            try
            {
                
                player.athleteID = athleteID;
                player.date = Convert.ToDateTime(dr["date"]);
                player.points = Convert.ToInt32(dr["points"]);
                player.assists = Convert.ToInt32(dr["assists"]);
                player.rebounds = Convert.ToInt32(dr["rebounds"] );
                player.blocks = Convert.ToInt32( dr["blocks"]);
                player.stl = Convert.ToInt32(dr["STL"]);
                player.minutes = Convert.ToInt32(dr["minutes"]);
                player._TO = Convert.ToInt32(dr["TO"]);
                player.fouls = Convert.ToInt32(dr["fouls"]);
                player.description = dr["description"].ToString();

            }
            catch (Exception ex)
            {

                //TODO - problem in the query or one of the retuned values             
            }
            players.Add(player);
        }


        return players;
    }


    public DataTable readBasketBallDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Game_BasketBall");
        // save the dataset in a session object
        HttpContext.Current.Session["userDataSet"] = dbs;
        return dbs.dt;
    }

    public void insertGameInfoBasketBall()
    {

        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Game_BasketBall");


        DataRow dr = dbs.dt.NewRow();
        dr["athleteID"] = athleteID;
        dr["sportId"] = sportId;
        dr["date"] = date;
        dr["minutes"] = minutes;
        dr["description"] = description;
        dr["points"] = points;
        dr["assists"] = assists;
        dr["rebounds"] = rebounds;
        dr["blocks"] = blocks;
        dr["TO"] = _TO;
        dr["fouls"] = fouls;
        dr["STL"] = stl;
        dr["fouls"] = fouls;

        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }
}

