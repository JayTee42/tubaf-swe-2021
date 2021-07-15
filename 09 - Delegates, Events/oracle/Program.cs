using System;

delegate void OracleFunc(string teams);

static class Oracle
{
    private static readonly Random _rand = new Random(42);

    private static void ParseTeams(string teams, out string team1, out string team2)
    {
        // Split the team names at "-":
        var teamList = teams.Split('-');

        if (teamList.Length != 2)
        {
            throw new ArgumentException("Expected team string with two teams (sep. by -)");
        }

        team1 = teamList[0].Trim();
        team2 = teamList[1].Trim();

        if ((team1.Length < 1) || (team2.Length < 1))
        {
            throw new ArgumentException("At least one team name is empty");
        }
    }

    public static void PredictResult(string teams)
    {
        ParseTeams(teams, out var team1, out var team2);
        Console.WriteLine($"Predicted result for { team1 } vs. { team2 }: { _rand.Next(10) } : { _rand.Next(10) }");
    }

    public static void PredictExtraTime(string teams)
    {
        ParseTeams(teams, out var team1, out var team2);

        Console.Write($"Predicted match time for { team1 } vs. { team2 }: ");

        switch (_rand.Next(3))
        {
        case 0: Console.WriteLine("90 minutes"); break;
        case 1: Console.WriteLine("90 minutes + 30 minutes extra time"); break;
        case 2: Console.WriteLine("90 minutes + 30 minutes extra time + penalty shoot-out"); break;
        }
    }

    public static void PredictRedCards(string teams)
    {
        ParseTeams(teams, out var team1, out var team2);
        Console.WriteLine($"Predicted red cards for { team1 } vs. { team2 }: { _rand.Next(3) } : { _rand.Next(3) }");
    }
}

class Program
{
    static OracleFunc BuildOracle(bool predictExtraTime, bool predictRedCards)
    {
        OracleFunc oracle = Oracle.PredictResult;

        if (predictExtraTime)
        {
            oracle += Oracle.PredictExtraTime;
        }

        if (predictRedCards)
        {
            oracle += Oracle.PredictRedCards;
        }

        return oracle;
    }

    static void Main(string[] args)
    {
        var oracle = BuildOracle(false, true);

        try
        {
            oracle("Germany - Engalnd");
            oracle("Italy - Spain");
            oracle("Denmark - Ireland");
            oracle("Swiss - France");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Bad input format: { ex.Message }");
        }
    }
}
