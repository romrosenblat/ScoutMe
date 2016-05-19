﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/// <summary>
/// Summary description for Athlete
/// </summary>
public class Athlete
{
    public Athlete(int _id, string _password, string _firstName, string _lastName, string _phone, string _eMail, int _sportID,
         DateTime _dob, decimal _hight, decimal _weight, string _city, int _agentNum, int _teamNum, bool _isGoaley, string _sex)
    {
        id = _id; password = _password; first_name = _firstName; last_name = _lastName; phone = _phone; eMail = _eMail;
        sportID = _sportID; dob = _dob; hight = _hight; weight = _weight; city = _city; agentNum = _agentNum; teamNum = _teamNum;
        isGoaley = _isGoaley; sex = _sex;
    }

    public Athlete() { }


    int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
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
    string agentName;
    public string AgentName
    {
        get { return agentName; }
        set { agentName = value; }
    }
    string teamName;
    public string TeamName
    {
        get { return teamName; }
        set { teamName = value; }
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
    int sportID;
    public int SportID
    {
        get { return sportID; }
        set { sportID = value; }
    }
    DateTime dob;
    public DateTime Dob
    {
        get { return dob; }
        set { dob = value; }
    }
    decimal hight;
    public decimal Hight
    {
        get { return hight; }
        set { hight = value; }
    }
    decimal weight;
    public decimal Weight
    {
        get { return weight; }
        set { weight = value; }
    }
    string city;
    public string City
    {
        get { return city; }
        set { city = value; }
    }
    int agentNum;
    public int AgenNum
    {
        get { return agentNum; }
        set { agentNum = value; }
    }
    int teamNum;
    public int TeamNum
    {
        get { return teamNum; }
        set { teamNum = value; }
    }
    bool isGoaley;
    public bool IsGoaley
    {
        get { return isGoaley; }
        set { isGoaley = value; }
    }
    string sex;
    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }

    public DataTable readAthletesDB()
    {
        // create a new DBServices Object
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Athlete");
        // save the dataset in a session object

        return dbs.dt;
    }
    public void insertAthlete()
    {

        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("bgroup33_prodConnectionString", "Athlete");

        string[] arrAgent = BreakNAme(agentName);
        string[] arrTeam = BreakNAme(teamName);
        agentNum = int.Parse(arrAgent[0]);
        teamNum = int.Parse(arrTeam[0]);
        DataRow dr = dbs.dt.NewRow();
        dr["password"] = password;
        dr["first_name"] = first_name;
        dr["last_name"] = last_name;
        dr["sportID"] = sportID;
        dr["date_of_birth"] = dob;
        dr["phone"] = phone;
        dr["eMail"] = eMail;
        dr["hight"] = hight;
        dr["weight"] = weight;
        dr["city"] = city;
        dr["agentNum"] = agentNum;
        dr["teamNum"] = teamNum;
        dr["isGoaley"] = isGoaley;
        dr["sex"] = sex;
        dbs.dt.Rows.Add(dr); // add the row to the table
        dbs.Update(); // update the database
    }

    public Athlete GetAthleteInfo(string email, string pass)
    {

        Athlete athlete = new Athlete();
        try
        {
            string where = "a.[eMail] ='" + email + "' and a.[password] = '" + pass + "' ";
            // create a new DBServices Object
            DBservices dbs = new DBservices();
            dbs = dbs.ReadFromDataBaseAuthentication(@"select a.athleteID,a.password,a.[first_name],a.[last_name],a.[sportID],a.[date_of_birth],a.[phone],a.[eMail],a.[hight],a.[weight],a.[city],b.first_name+' '+b.last_name as 'agentName'
        ,c.team_name as 'teamName',a.isGoaley,a.sex from Athlete as a INNER join [dbo].[Agent] as b on a.agentNum = b.agentNum left JOIN [dbo].[Teams] as c on a.teamNum = c.teamNum  where ", where);
            DataRow dr = dbs.dt.Rows[0];
            athlete.id = int.Parse(dr["athleteID"].ToString());
            athlete.first_name = dr["first_name"].ToString();
            athlete.last_name = dr["last_name"].ToString();
            athlete.sportID = int.Parse(dr["sportID"].ToString());
            athlete.dob = (DateTime)dr["date_of_birth"];
            athlete.phone = dr["phone"].ToString();
            athlete.eMail = dr["eMail"].ToString();
            athlete.hight = (decimal)(dr["hight"]);
            athlete.weight = (decimal)dr["weight"];
            athlete.city = dr["city"].ToString();
            athlete.agentName = dr["agentName"].ToString();
            athlete.teamName = dr["teamName"].ToString();
            athlete.isGoaley = (bool)dr["isGoaley"];
            athlete.sex = dr["sex"].ToString();
            athlete.password = dr["password"].ToString();
        }
        catch (Exception)
        {

            athlete.id = 0;
        }

        return athlete;
    }
    public string[] BreakNAme(string fullName)
    {
        string[] arr = fullName.Split(' ');

        return arr;
    }

}