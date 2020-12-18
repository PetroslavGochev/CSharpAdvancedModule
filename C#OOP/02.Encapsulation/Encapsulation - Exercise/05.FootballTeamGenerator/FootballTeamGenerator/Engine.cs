using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    class Engine
    {
        public void Run()
        {
            string input = string.Empty;
            List<Team> teams = new List<Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var data = input.Split(";");
                    string teamName = data[1];
                    if (data[0] == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    if (data[0] == "Add")
                    {
                        var playerName = data[2];
                        if (!teams.Any(x => x.TeamName == teamName))
                        {
                            throw new ArgumentException(String.Format(Validator.TeamNotExist, teamName));
                        }
                        string[] stats = new string[]
                        {
                        data[3],
                        data[4],
                        data[5],
                        data[6],
                        data[7]
                        };
                        Stats statsOfPlayer = new Stats(stats);
                        Player player = new Player(playerName, statsOfPlayer);
                        Team team = teams.FirstOrDefault(x => x.TeamName == teamName);
                        team.Add(player);
                    }
                    if (data[0] == "Remove")
                    {
                        Team team = teams.FirstOrDefault(x => x.TeamName == teamName);
                        var playerName = data[2];
                        team.Remove(playerName);
                    }
                    if (data[0] == "Rating")
                    {
                        if (!teams.Any(x => x.TeamName == teamName))
                        {
                            throw new ArgumentException(String.Format(Validator.TeamNotExist,teamName));
                        }
                        foreach (var team in teams)
                        {
                            if(team.TeamName == teamName)
                            {
                                Console.WriteLine(team);
                            }
                            
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
