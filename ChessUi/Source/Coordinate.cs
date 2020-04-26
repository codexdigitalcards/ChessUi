using System;

namespace ChessUi
{
    public class Coordinate
    {
        private int rank;
        private File file;
        public File File {
            get
            {
                return file;
            }
            set
            {
                if (value >= 0 && (int) value < BoardUi.BoardWidth)
                {
                    file = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("File", value, $"File must be between 0 and {BoardUi.BoardWidth - 1}");
                }
            }
        }
        public int Rank {
            get
            {
                return rank;
            }
            set
            {
                if (value >= 1 && value <= BoardUi.BoardHeight)
                {
                    rank = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rank", value, $"Rank must be between 1 and {BoardUi.BoardHeight}");
                }
            }
        }

        public Coordinate(int rank, int file)
        {
            Rank = rank;
            File = (File) file;
        }

        public Coordinate(int rank, File file)
        {
            Rank = rank;
            File = file;
        }

        public override bool Equals(object obj)
        {
            try
            {
                Coordinate other = (Coordinate) obj;
                return Rank == other.Rank && File == other.File;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return ((int) File) * 10 + rank;
        }

        public override string ToString()
        {
            return $"{FileToChar(File)}{rank}";
        }

        public static char FileToChar(File file)
        {
            switch (file)
            {
                case File.A:
                    return 'a';
                case File.B:
                    return 'b';
                case File.C:
                    return 'c';
                case File.D:
                    return 'd';
                case File.E:
                    return 'e';
                case File.F:
                    return 'f';
                case File.G:
                    return 'g';
                case File.H:
                    return 'h';
                default:
                    throw new ArgumentOutOfRangeException("file", file, "File must be a number between 0-7.");
            }
        }
    }

    public enum File
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7
    }
}
