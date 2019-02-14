using System;
using System.IO;

namespace CB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("1 2 3\n4 5 6\n7 8 9\n* 0 #\n");
            Console.WriteLine("Default valid phone number length : 7\n");
            Console.WriteLine(" Rook    :0 \n Bishop  :1 \n King    :2 \n Queen   :3 \n Knight  :4 \n");
            Console.WriteLine("Please choose a Chess Piece...");
            Configuration.KeyPad = new char[4, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' }, { '*', '0', '#' } };
            Configuration.ValidNumberLength = 7;
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                while (!reader.EndOfStream)
                {
                    bool isValid = int.TryParse(reader.ReadLine().Trim(), out int input);
                    if (!isValid)
                    {
                        Console.WriteLine("Please choose a valid chess piece from the options displayed above..");
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(ChessPiece), input))
                        {
                            Configuration config = new Configuration();
                            AbstractChessPiece dynamicChessPiece = config.ConstructChessPiece((ChessPiece)input);
                            //Console.WriteLine("Would you like to change the default length of phone numbers?");
                            //string yesNo = reader.ReadLine().Trim();
                            //if (yesNo == "Y" || yesNo == "y")
                            //{
                            //    Console.WriteLine("Please enter a new valid length");

                            //    bool validLength = int.TryParse(reader.ReadLine().Trim(), out int length);
                            //    if (validLength)
                            //    {
                            //        dynamicChessPiece.UseValidLength(length);
                            //    }
                            //}
                            Console.WriteLine("Valid number count: {0}", dynamicChessPiece.CountPossibleValidNumbers());
                        }
                        else
                        {
                            Console.WriteLine("Please choose a valid chess piece from the options displayed above..");
                        }
                    }
                }
            }
        }
    }

    public enum ChessPiece
    {
        Rook,
        Bishop,
        King,
        Queen,
        Knight,
        //Pawn,
    }

    public class Configuration
    {
        public AbstractChessPiece DynamicChessPiece { get; set; }
        public static char[,] KeyPad { get; set; }
        public static int ValidNumberLength { get; set; }
        public AbstractChessPiece ConstructChessPiece(ChessPiece piece)
        {
            switch (piece)
            {
                case ChessPiece.Rook:
                    DynamicChessPiece = new Rook(KeyPad, ValidNumberLength);
                    break;
                case ChessPiece.Bishop:
                    DynamicChessPiece = new Bishop(KeyPad, ValidNumberLength);
                    break;
                case ChessPiece.King:
                    DynamicChessPiece = new King(KeyPad, ValidNumberLength);
                    break;
                case ChessPiece.Queen:
                    DynamicChessPiece = new Queen(KeyPad, ValidNumberLength);
                    break;
                case ChessPiece.Knight:
                    DynamicChessPiece = new Knight(KeyPad, ValidNumberLength);
                    break;
                default:
                    break;
            }
            return DynamicChessPiece;

        }
    }

    public static class Extensions
    {
        public static AbstractChessPiece UseKeyPadLayout(this AbstractChessPiece chessPiece, char[,] input)
        {
            chessPiece.KeyPad = input;
            return chessPiece;
        }
        public static AbstractChessPiece UseValidLength(this AbstractChessPiece chessPiece, int input)
        {
            chessPiece.ValidNumberLength = input;
            return chessPiece;
        }
    }
}