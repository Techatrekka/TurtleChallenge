using ConsoleApp1;
using System;
using System.Text;

static void Main(string[] args)
{
    string gameSettings = File.ReadAllText(args[0] +".txt");
    string moves = File.ReadAllText(args[1] + ".txt");
    string[] playsGameSetting = gameSettings.Split('\n');
    string mines, startEnd;
    //Game Loop
    for (int i = 0; i < playsGameSetting.Length; i++) {
        mines = playsGameSetting[i].Split('-')[0];
        startEnd = playsGameSetting[i].Split('-')[1];
        Board game = new Board(mines, startEnd);
        string[] actions = moves.Split("\r\n")[i].Split(',');
        for(int j = 0; j < actions.Length; j++)
        {
             if (actions[j].Equals("m")) 
            {
                if (game.isValidMove() == null)
                {
                    Console.WriteLine("Sequence " + i + " Hit a mine");
                    break;
                }
                else if (game.isValidMove() == true)
                {
                    game.moveTurtle();
                }
                //else {
                //    Console.WriteLine("Ran into a wall");
                //}
            } 
            else if (actions[j].Equals("r"))
            {
                game.rotateTurtle();
            }
            if (game.arrivedAtGoal())
            {
                Console.WriteLine("Sequence " + i + ": Success");
                break;
            } else if (j == actions.Length - 1)
            {
                Console.WriteLine("Sequence " + i + ": Still in Danger!");
            }
            
        }
    }
}

Main(args);