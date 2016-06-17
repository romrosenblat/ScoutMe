using System;
using System.Collections.Generic;
using System.Data;
/// <summary>
/// Summary description for Videos
/// </summary>
public class Videos
{
    public Videos()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int athleteId;
    public int AthleteId
    {
        get { return athleteId; }
        set { athleteId = value; }
    }
    DateTime date;
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
    int videoNumber;
    public int VideoNumber
    {
        get { return videoNumber; }
        set { videoNumber = value; }
    }
    string videoURL;
    public string VideoURL
    {
        get { return videoURL; }
        set { videoURL = value; }
    }
    string descripition;
    public string Descripition
    {
        get { return descripition; }
        set { descripition = value; }
    }
    public DataTable readVideosDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Videos");
        // save the dataset in a session object

        return dbs.dt;
    }
    public void insertVideo()
    {

        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Videos");

        DataRow dr = dbs.dt.NewRow();
        dr["athleteId"] = athleteId;
        dr["URL"] = videoURL;
        dr["description"] = descripition;
        dr["date"] = date;
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database

        Feed feed = new Feed();
        feed.InsertToFeed_video(athleteId,videoURL,descripition);

    }

    public List<Videos> GetAthleteVideos(int athleteID)
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBaseAuthentication(@"select a.[URL],a.description from Videos as a INNER JOIN Athlete as b on a.athleteId=b.athleteID where a.athleteId =", athleteID.ToString());
        List<Videos> videoList = new List<Videos>();
        foreach (DataRow dr in dbs.dt.Rows)
        {
            Videos vid = new Videos();
            vid.videoURL = dr["URL"].ToString();
            vid.descripition = dr["description"].ToString();
            videoList.Add(vid);
        }
        return videoList;
    }
}

