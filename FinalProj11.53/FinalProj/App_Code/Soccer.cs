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
        else
        {
            dr["goals"] = goals;
            dr["assists"] = assists;
            dr["total_shots"] = totalShots;
            dr["passes"] = passes;
        }
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }
}