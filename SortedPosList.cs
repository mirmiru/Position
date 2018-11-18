using System;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {
        List<Position> sortedPosList = new List<Position>();

        private bool shouldSave;

        private const string FILEPATH = "./positions.txt";


        public SortedPosList()
        {
            shouldSave = false;
        }

        // Checks if the desired file exists in the given directory.
        // If it doesn't, a text file is created there.
        // filePath - the path of the file
        public SortedPosList(string filePath)
        {
            shouldSave = true;

            try
            {
                Load(filePath);
            }
            catch
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
                {
                    Console.WriteLine("File created!");
                }
            }
        }

        // Returns the amount of positions in the list
        public int Count()
        {
            return sortedPosList.Count;
        }

        // Returns a string containing all positions, separated with commas
        public override string ToString()
        {
            return String.Join(",", sortedPosList);
        }

        // Adds a Position object to the list. Ensures that the 
        // positions in the list are sorted by Length, i.e. distance from origo.
        // Saves the list to the text file.
        public void Add(Position pos)
        {
            sortedPosList.Add(pos);

            for (int i = 0; i < Count(); i++)
            {
                for (int j = i + 1; j < Count(); j++)
                {
                    if (sortedPosList[i] > sortedPosList[j])
                    {
                        Position holder = sortedPosList[i];
                        sortedPosList[i] = sortedPosList[j];
                        sortedPosList[j] = holder;
                    }
                }
            }
            if (shouldSave)
            {
                Save();
            }
        }

        // Deletes any Position from the list that 
        // matches the provided Position.
        public bool Remove(Position position)
        {
            foreach (Position posInList in sortedPosList)
            {
                if (position.Equals(posInList))
                {
                    sortedPosList.Remove(posInList);
                    return true;
                }
            }
            return false;
        }

        // OVERLOADING OPERATORS

        // Returns a new sorted list containing all positions of the two provided lists 
        // sp1 - the first sorted list of Positions
        // sp2 - the second sorted list of Positions
        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList combinedList = new SortedPosList();

            for (int i = 0; i < sp1.Count(); i++) 
            {
                combinedList.Add(sp1[i]);
            }

            for (int i = 0; i < sp2.Count(); i++)
            {
                combinedList.Add(sp2[i]);
            }

            return combinedList;
        }

        // Returns a new sorted list containing all positions that aren't shared 
        // between the two provided lists
        // sp1 - the first sorted list of Positions
        // sp2 - the second sorted list of Positions
        public static SortedPosList operator -(SortedPosList list1, SortedPosList list2)
        {
            SortedPosList comboList = list1 + list2;
            SortedPosList result = list1.Clone();

            for (int i = 0; i + 1 < comboList.Count(); i++)
            {
                if (comboList[i].Equals(comboList[i + 1]))
                {
                    //Console.WriteLine($"Found same values: {comboList[i]} and {comboList[i + 1]}");
                    result.Remove(comboList[i]);
                }
                else
                {
                    // Console.WriteLine($"Not The same: {comboList[i]} and {comboList[i + 1]}");
                }
            }

            return result;
        }

        public Position this[int index]
        {
            // GET - Returns Position at given index
            get { return sortedPosList[index]; }
        }

        // Returns a deep clone of all positions in the list
        public SortedPosList Clone()
        {
            SortedPosList clonedList = new SortedPosList();

            foreach (Position pos in sortedPosList)
            {
                clonedList.Add(pos.Clone());
            }
            return clonedList;
        }

        // Returns a list containing all positions within the given circle
        // centerPos - center of the circle
        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList posWithinCircle = new SortedPosList();

            foreach (Position pos in sortedPosList)
            {
                if (Math.Pow(pos.X - centerPos.X, 2) + Math.Pow(pos.Y - centerPos.Y, 2) < Math.Pow(radius, 2))
                {
                    posWithinCircle.Add(pos);
                    //Console.WriteLine(pos);
                }
            }
            return posWithinCircle;
        }

        // FILE RELATED METHODS

        // Loads all Positions from the file "positions.txt" into the list.
        // This only occurs if the file exists.
        // filePath - the path of the file to load
        private void Load(string filePath)
        {
            string[] allLinesInFile = System.IO.File.ReadAllLines(filePath);

            for (int i = 0; i < allLinesInFile.Length; i++)
            {
                Position parsedPos = ConvertStringToPosition(allLinesInFile[i]);
                sortedPosList.Add(parsedPos);
            }
        }


        // Saves the list of Positions to the file "positions.txt".
        // Each Position is wrote on a new line in the file.
        private void Save()
        {
            //Console.WriteLine($"Saving to file.");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"positions.txt"))
                foreach (Position pos in sortedPosList)
                {
                    file.WriteLine($"({pos.X},{pos.Y})");
                }
        }

        // Returns a Position by parsing a string
        // posString - The string containing the Position
        public Position ConvertStringToPosition(string posString)
        {
            //Console.WriteLine(posString);
            string withoutLeftParanthesis = posString.Replace("(", string.Empty);
            string withoutLeftAndRightParanthesis = withoutLeftParanthesis.Replace(")", string.Empty);

            string[] twoCoords = withoutLeftAndRightParanthesis.Split(",");
            //Console.WriteLine($"X coordinate: {twoCoords[0]} Y coordinate: {twoCoords[1]}");

            int xCoord = int.Parse(twoCoords[0]);

            int yCoord = int.Parse(twoCoords[1]);

            return new Position(xCoord, yCoord);
        }

    }
}
