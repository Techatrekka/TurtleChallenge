using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board
    {
        private string[,] board;
        private int TurtleX;
        private int TurtleY;
        private int GoalX;
        private int GoalY;

        public Board(string mines, string startEnd) {
            board = new string[4,5];
            this.GoalX = Int32.Parse(startEnd.Split('/')[1].Split(',')[0]);
            this.GoalY = Int32.Parse(startEnd.Split('/')[1].Split(',')[1]);
            this.TurtleX = Int32.Parse(startEnd.Split('/')[0].Split(',')[0]);
            this.TurtleY = Int32.Parse(startEnd.Split('/')[0].Split(',')[1]);
            board[TurtleX, TurtleY] = "Turtle,North";
            for (int i = 0; i < mines.Split(',').Length; i++)
            {
                int x = Int32.Parse(mines.Split(',')[i].Split('#')[0])-1;
                int y = Int32.Parse(mines.Split(',')[i].Split('#')[1])-1;
                board[x, y] = "Mine";
            }
            //Console.WriteLine(getBoard());
        }

        public bool arrivedAtGoal() {
            if (TurtleX == GoalX && TurtleY == GoalY)
            {
                return true;
            }
            return false;
        }

        public void rotateTurtle() {
            string direction = board[TurtleX, TurtleY].Split(",")[1];
            if (direction == "North")
            {
                board[TurtleX,TurtleY] = board[TurtleX, TurtleY].Split(",")[0] + ",West";
            }
            else if (direction == "South")
            {
                board[TurtleX, TurtleY] = board[TurtleX, TurtleY].Split(",")[0] + ",East";
            }
            else if (direction == "East")
            {
                board[TurtleX, TurtleY] = board[TurtleX, TurtleY].Split(",")[0] + ",North";
            }
            else if (direction == "West") 
            {
                board[TurtleX, TurtleY] = board[TurtleX, TurtleY].Split(",")[0] + ",South";
            }
        }

        public void moveTurtle() {
            string direction = board[TurtleX, TurtleY].Split(",")[1];
            string turtle = board[TurtleX, TurtleY];
            board[TurtleX, TurtleY] = null;
            if (direction == "North")
            {
                board[TurtleX, TurtleY - 1] = turtle;
                TurtleY--;
            }
            else if (direction == "South")
            {
                board[TurtleX, TurtleY+1] = turtle;
                TurtleY++;
            }
            else if (direction == "East")
            {
                board[TurtleX-1, TurtleY] = turtle;
                TurtleX--;
            }
            else if (direction == "West")
            {
                board[TurtleX+1, TurtleY] = turtle;
                TurtleX++;
            }
        }

        public bool? isValidMove() 
        {
            string direction = board[TurtleX, TurtleY].Split(",")[1];
            if (direction == "South" || direction == "North")
            {
                if ((TurtleY - 1 < 0 && direction == "North") || (TurtleY + 1 > 4 && direction == "South"))
                {
                    return false;
                }
                else if (direction == "South")
                {
                    if (board[TurtleX, TurtleY + 1] == "Mine")
                    {
                        return null;
                    }
                }
                else if (direction == "North")
                {
                    if (board[TurtleX, TurtleY - 1] == "Mine")
                    {
                        return null;
                    }
                }
            }
            else if (direction == "East" || direction == "West")
            {
                if ((TurtleX - 1 < 0 && direction == "East") || (TurtleX + 1 > 3 && direction == "West"))
                {
                    return false;
                }
                else if (direction == "East") {
                    if (board[TurtleX - 1, TurtleY] == "Mine")
                    {
                        return null;
                    }
                } 
                else if (direction == "West") {
                    if (board[TurtleX + 1, TurtleY] == "Mine")
                    {
                        return null;
                    }
                }
            }
            return true;
        }

        public string getBoard()
        {
            string x = "";
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    x += board[i, j] + " .";
                }
                x += '\n';
            }
            return x;
        }
    }
}
