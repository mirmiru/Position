using System;

namespace Labb2
{
    public class Position
    {
        private int _x;

        private int _y;

        public int X 
        { 
            get 
            {
                return _x;
            }
            set 
            {
                if (value >= 0)
                {
                    _x = value;
                } 
                else 
                {
                    _x = 0;
                }
            }
        }

        public int Y 
        {
            get 
            {
                return _y;
            }
            set
            {
                if (value >= 0)
                {
                    _y = value;
                } 
                else 
                {
                    _y = 0;
                }
            }
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position p)
        {
            return (p.X == X) && (p.Y == Y);
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public double Length()
        {
            double distanceFromOrigo = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return distanceFromOrigo;
        }

        // OVERLOADING OPERATORS
        public static double operator %(Position p1, Position p2)
        {
            double distance =
                Math.Sqrt(
                    Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)
                );
            // Om vi vill avrunda till 2 decimaler
            // return Math.Round(distance, 2);
            return distance;
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
            {
                return p1.X > p2.X;
            }

            return p1.Length() > p2.Length();
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
            {
                return p2.X > p1.X;
            }

            return p2.Length() > p1.Length();
        }

        public static Position operator +(Position p1, Position p2)
        {
            int sumOfPositionsX = p1.X + p2.X;
            int sumOfPositionsY = p1.Y + p2.Y;

            return new Position(sumOfPositionsX, sumOfPositionsY);
        }

        public static Position operator -(Position p1, Position p2)
        {
            int differenceOfPositionsX = Math.Abs(p1.X - p2.X);
            int differenceOfPositionsY = Math.Abs(p1.Y - p2.Y);

            return new Position(differenceOfPositionsX, differenceOfPositionsY);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
