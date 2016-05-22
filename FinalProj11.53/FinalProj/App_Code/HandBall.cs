using System.Data;
using System.Web;
/// <summary>
/// Summary description for HandBall
/// </summary>
public class HandBall: Game
{
    protected float goals;
    protected float shots;
    protected float twoMin;
    protected float sevenM_Goal;
    protected float saves_G;
    protected float shots_G;

    public float Goals       { get { return goals; } set { goals = value; } }
    public float Shots       { get { return shots; } set { shots = value; } }
    public float TwoMin         { get { return twoMin; } set { twoMin = value; } }
    public float SevenM_Goal { get { return sevenM_Goal; } set { sevenM_Goal = value; } }
    public float Saves_G        { get { return saves_G; } set { saves_G = value; } }
    public float Shots_G        { get { return shots_G; } set { shots_G = value; } }
    public HandBall()
    {
        readHandBallDB();
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable readHandBallDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Game_HandBall");
        // save the dataset in a session object
        HttpContext.Current.Session["userDataSet"] = dbs;
        return dbs.dt;
    }

    public void insertGameInfoSoccer(bool isGoaley)
    {

        if (HttpContext.Current.Session["userDataSet"] == null) return;

        DBservices dbs = (DBservices)HttpContext.Current.Session["userDataSet"];

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
        else
        {
            dr["goals"] = goals;
            dr["shots"] = shots;
            dr["2_Min"] = twoMin;
            dr["7M_Goal"] = sevenM_Goal;
        }
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }
}

