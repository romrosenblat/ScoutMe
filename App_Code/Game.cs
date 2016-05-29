using System;

/// <summary>
/// Summary description for GameSoccer
/// </summary>
public class Game
{
    protected int gameId;
    protected int athleteID;
    protected int sportId;
    protected DateTime date;
    protected DateTime minutes;
    protected int redCard;
    protected int yellowCard;
    protected string description;

    public int GameId { get { return gameId; } set { gameId = value; } }
    public int AthleteID { get { return athleteID; } set { athleteID = value; } }
    public int SportId { get { return sportId; } set { sportId = value; } }
    public DateTime Date { get { return date; } set { date = value; } }
    public DateTime Minutes { get { return minutes; } set { minutes = value; } }
    public int RedCard { get { return redCard; } set { redCard = value; } }
    public int YellowCard { get { return yellowCard; } set { yellowCard = value; } }
    public string Description { get { return description; } set { description = value; } }


    public Game()
    {
        GameId = gameId;
        AthleteID = athleteID;
        SportId = sportId;
        Date = date;
        Minutes = minutes;
        RedCard = redCard;
        YellowCard = yellowCard;
        Description = description;
    }

    /// <summary>
    /// inserts this game and retuns the game id
    /// </summary>
    /// <returns>game id</returns>
    public int InsertNewGame()
    {
        //insert into games table
        //return the id of the new game
        return new Random().Next(1, 100);
    }
}