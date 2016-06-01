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
        //
        // TODO: Add constructor logic here
        //
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

