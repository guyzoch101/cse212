/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId)) {
                players[playerId] += points; // if playerId already in players -> add the points for that player
            }
            else {
                players[playerId] = points; // create new key if not in players
            }
        }

        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        // did not convert the map into an array -> but still returns a sorted array with top scorers
        // var topPlayers = new string[10];

        // for (int i = 0; i < 10; i++) {
        //     int maxPoints = players.Values.Max(); // max points located
        //     var maxPointsPair = players.First(kvp => kvp.Value == maxPoints); // retrieve the pair where the max points is
        //     topPlayers[i] = maxPointsPair.ToString(); // add the pair into the topPlayers array
        //     players[maxPointsPair.Key] = 0; // erase the top scorer and find the next highest scorer until i > 9
        // }

        // Console.WriteLine(string.Join(", ", topPlayers));

        var topPlayers = players.ToArray();
        Array.Sort(topPlayers, (p1, p2) => p2.Value - p1.Value);

        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(topPlayers[i]);
        }
    }
}