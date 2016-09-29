// Daniel Richards
// CIS 237
// 9/29/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        private char[,] maze;
        int xStart;
        int yStart;
        bool mazeSolved;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            // Tell the program the maze is not yet completed
            mazeSolved = false;

            // Print base maze and begin recursive call to solve maze
            PrintMaze();
            mazeTraversal(xStart, yStart);

            // Message signifying the maze is solved
            Console.WriteLine("Maze Solved." +
                Environment.NewLine);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int xSpot, int ySpot)
        {
            // Mark the current location in the maze and print maze again, showing the new location
            maze[xSpot, ySpot] = 'X';
            PrintMaze();
            // Check if program has reached the edge of the maze
            if (xSpot != 0 && xSpot != 11 && ySpot != 0 && ySpot != 11 && !mazeSolved)
            {
                // Check to see if maze can move right then call mazeTraversal, indicating to go right
                if (maze[xSpot, (ySpot + 1)] == '.')
                {
                    mazeTraversal(xSpot, ySpot + 1);
                }
                // Check to see if maze can move down then call mazeTraversal, indicating to go down
                if (maze[(xSpot + 1), ySpot] == '.' && !mazeSolved)
                {
                    mazeTraversal(xSpot + 1, ySpot);
                }
                // Check to see if maze can move left then call mazeTraversal, indicating to go left
                if (maze[xSpot, (ySpot - 1)] == '.' && !mazeSolved)
                {
                    mazeTraversal(xSpot, ySpot - 1);
                }
                // Check to see if maze can move up then call mazeTraversal, indicating to go up
                if (maze[(xSpot - 1), ySpot] == '.' && !mazeSolved)
                {
                    mazeTraversal(xSpot - 1, ySpot);
                }
                // If maze is not solved and there is no open space for the maze to move to (i.e. dead end), 
                // replace the current spot in the maze with a 0. This does not happen when the maze has been solved,
                // so that the correct path through the maze is not replaced with 0s
                if (!mazeSolved)
                    MazeBack(xSpot, ySpot);
            }
            else
            {
                // If program has reached the edge of the array, it has solved the maze
                mazeSolved = true;
            }
        }

        /// <summary>
        /// Replaces the current spot in the maze with a 0, indicating a dead end path
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MazeBack(int x, int y)
        {
            maze[x, y] = '0';
            // Print maze again, showing the backtrack to the current path
            PrintMaze();
        }

        // Prints maze to screen
        private void PrintMaze()
        {
            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
