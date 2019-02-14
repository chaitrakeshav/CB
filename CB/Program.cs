using System;
using System.Collections.Generic;
using System.Text;

namespace CB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ValidNumber number = new ValidNumber();
            int phoneNumberLength = 7;
           int ct= number.CountValidNumbers(new char[4,3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' }, { '*', '0', '#' } }, ChessPiece.Queen,phoneNumberLength);
            //int ct = number.CountValidNumbers(new char[2, 1] { { '3'}, { '4' } }, ChessPiece.Rook,phoneNumberLength);
            Console.Write(ct);
            Console.ReadLine();
        }
    }
    public enum ChessPiece
    {
        Rook,
        Bishop,
        King,
        Queen,
        Knight,
        Pawn,
    }
    public class ValidNumber
    {
        public ChessPiece ChessPiece { get; set; }
        Dictionary<int, List<int>> Paths = new Dictionary<int, List<int>>();
        public int CountValidNumbers(char[,] keypad, ChessPiece piece,int validLength)
        {
            int dictlen = 0;
            int rows = keypad.GetUpperBound(0);
            int cols = keypad.GetUpperBound(1);
            while (dictlen < 10)
            {
                Paths[dictlen] = new List<int>();
                dictlen++;
            }
            switch (piece)
            {
                case ChessPiece.Rook:                                     
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            if (!int.TryParse(keypad[i, j].ToString(), out _))
                                continue;
                            List<int> curNeighbors = new List<int>();
                            int pairRowForward = i + 1;
                            int pairRowBackward = i - 1;
                            int pairColForward = j + 1;
                            int pairColBackward = j - 1;
                            while (pairRowForward <= rows || pairRowBackward >= 0 ||
                                pairColForward <= cols || pairColBackward >= 0)
                            {
                                if (pairColForward <= cols && Char.IsDigit(keypad[i, pairColForward]))
                                    curNeighbors.Add(keypad[i, pairColForward] - '0');
                                if ( pairColBackward >= 0 && Char.IsDigit(keypad[i, pairColBackward]))
                                    curNeighbors.Add(keypad[i, pairColBackward] - '0');
                                if (pairRowBackward >= 0  && Char.IsDigit(keypad[pairRowBackward, j]))
                                    curNeighbors.Add(keypad[pairRowBackward, j] - '0');
                                if (pairRowForward <=rows && Char.IsDigit(keypad[pairRowForward, j]))
                                    curNeighbors.Add(keypad[pairRowForward, j] - '0');

                                pairRowForward++;
                                pairRowBackward--;
                                pairColForward++;
                                pairColBackward--;
                            }
                            Paths[keypad[i,j]-'0'] = curNeighbors;
                        }
                    }
                    break;
                case ChessPiece.Bishop:
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            if (!int.TryParse(keypad[i, j].ToString(), out _))
                                continue;
                            List<int> curNeighbors = new List<int>();
                            int pairRowForward = i + 1;
                            int pairRowBackward = i - 1;
                            int pairColForward = j + 1;
                            int pairColBackward = j - 1;
                            while (pairRowForward <= rows || pairRowBackward >= 0 ||
                                pairColForward <= cols || pairColBackward >= 0)
                            {
                                if (pairColForward <= cols && pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColForward] - '0');
                                if (pairColBackward >= 0 && pairRowBackward >=0 && Char.IsDigit(keypad[pairRowBackward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColBackward] - '0');
                                if (pairRowBackward >= 0 && pairColForward <=cols && Char.IsDigit(keypad[pairRowBackward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColForward] - '0');
                                if (pairRowForward <= rows &&  pairColBackward>=0 &&Char.IsDigit(keypad[pairRowForward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColBackward] - '0');

                                pairRowForward++;
                                pairRowBackward--;
                                pairColForward++;
                                pairColBackward--;
                            }
                            Paths[keypad[i, j] - '0'] = curNeighbors;
                        }
                    }
                    break;
                case ChessPiece.Knight:
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            if (!int.TryParse(keypad[i, j].ToString(), out _))
                                continue;
                            List<int> curNeighbors = new List<int>();
                            int pairRowForward = i + 1;
                            int pairRowBackward = i - 1;
                            int pairColForward = j + 2;
                            int pairColBackward = j - 2;
                            while (pairRowForward <= rows || pairRowBackward >= 0 ||
                                pairColForward <= cols || pairColBackward >= 0)
                            {
                                if (pairColForward <= cols && pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColForward] - '0');
                                if (pairColBackward >= 0 && pairRowBackward >= 0 && Char.IsDigit(keypad[pairRowBackward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColBackward] - '0');
                                if (pairRowBackward >= 0 && pairColForward <= cols && Char.IsDigit(keypad[pairRowBackward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColForward] - '0');
                                if (pairRowForward <= rows && pairColBackward >= 0 && Char.IsDigit(keypad[pairRowForward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColBackward] - '0');

                                pairRowForward++;
                                pairRowBackward--;
                                pairColForward = pairColForward + 2;
                                pairColBackward = pairColBackward - 2;
                            }
                            Paths[keypad[i, j] - '0'] = curNeighbors;
                        }
                    }
                    break;
                case ChessPiece.King:
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            if (!int.TryParse(keypad[i, j].ToString(), out _))
                                continue;
                            List<int> curNeighbors = new List<int>();
                            int pairRowForward = i + 1;
                            int pairRowBackward = i - 1;
                            int pairColForward = j + 1;
                            int pairColBackward = j - 1;
                            if (pairRowForward <= rows || pairRowBackward >= 0 ||
                                pairColForward <= cols || pairColBackward >= 0)
                            {
                                if (pairColForward <= cols && Char.IsDigit(keypad[i, pairColForward]))
                                    curNeighbors.Add(keypad[i, pairColForward] - '0');
                                if (pairColBackward >= 0 && Char.IsDigit(keypad[i, pairColBackward]))
                                    curNeighbors.Add(keypad[i, pairColBackward] - '0');
                                if (pairRowBackward >= 0 && Char.IsDigit(keypad[pairRowBackward, j]))
                                    curNeighbors.Add(keypad[pairRowBackward, j] - '0');
                                if (pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, j]))
                                    curNeighbors.Add(keypad[pairRowForward, j] - '0');
                                if (pairColForward <= cols && pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColForward] - '0');
                                if (pairColBackward >= 0 && pairRowBackward >= 0 && Char.IsDigit(keypad[pairRowBackward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColBackward] - '0');
                                if (pairRowBackward >= 0 && pairColForward <= cols && Char.IsDigit(keypad[pairRowBackward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColForward] - '0');
                                if (pairRowForward <= rows && pairColBackward >= 0 && Char.IsDigit(keypad[pairRowForward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColBackward] - '0');

                            }
                            Paths[keypad[i, j] - '0'] = curNeighbors;
                        }
                    }
                    break;
                case ChessPiece.Queen:
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            if (!int.TryParse(keypad[i, j].ToString(), out _))
                                continue;
                            List<int> curNeighbors = new List<int>();
                            int pairRowForward = i + 1;
                            int pairRowBackward = i - 1;
                            int pairColForward = j + 1;
                            int pairColBackward = j - 1;
                            while (pairRowForward <= rows || pairRowBackward >= 0 ||
                                pairColForward <= cols || pairColBackward >= 0)
                            {
                                if (pairColForward <= cols && Char.IsDigit(keypad[i, pairColForward]))
                                    curNeighbors.Add(keypad[i, pairColForward] - '0');
                                if (pairColBackward >= 0 && Char.IsDigit(keypad[i, pairColBackward]))
                                    curNeighbors.Add(keypad[i, pairColBackward] - '0');
                                if (pairRowBackward >= 0 && Char.IsDigit(keypad[pairRowBackward, j]))
                                    curNeighbors.Add(keypad[pairRowBackward, j] - '0');
                                if (pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, j]))
                                    curNeighbors.Add(keypad[pairRowForward, j] - '0');
                                if (pairColForward <= cols && pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColForward] - '0');
                                if (pairColBackward >= 0 && pairRowBackward >= 0 && Char.IsDigit(keypad[pairRowBackward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColBackward] - '0');
                                if (pairRowBackward >= 0 && pairColForward <= cols && Char.IsDigit(keypad[pairRowBackward, pairColForward]))
                                    curNeighbors.Add(keypad[pairRowBackward, pairColForward] - '0');
                                if (pairRowForward <= rows && pairColBackward >= 0 && Char.IsDigit(keypad[pairRowForward, pairColBackward]))
                                    curNeighbors.Add(keypad[pairRowForward, pairColBackward] - '0');

                                pairRowForward++;
                                pairRowBackward--;
                                pairColForward++;
                                pairColBackward--;
                            }
                            Paths[keypad[i, j] - '0'] = curNeighbors;
                        }
                    }
                    break;
                case ChessPiece.Pawn:
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            if (!int.TryParse(keypad[i, j].ToString(), out _))
                                continue;
                            List<int> curNeighborsSideA = new List<int>();
                            List<int> curNeighborsSideB = new List<int>();
                            int pairRowForward = i + 1;
                            int pairRowBackward = i - 1;
                           
                            while (pairRowForward <= rows || pairRowBackward >= 0)
                            {
                                if (pairRowBackward >= 0 && Char.IsDigit(keypad[pairRowBackward, j]))
                                    curNeighborsSideA.Add(keypad[pairRowBackward, j] - '0');
                                if (pairRowForward <= rows && Char.IsDigit(keypad[pairRowForward, j]))
                                    curNeighborsSideB.Add(keypad[pairRowForward, j] - '0');
                            }
                            Paths[keypad[i, j] - '0'] = curNeighborsSideA;
                        }
                    }
                    break;
                default:
                    return 0;
            }
            int resultCount = 0;
            for (int i = 2; i < Paths.Count; i++)
            {
                resultCount += GetCountRec(Paths[i], validLength - 1);
            }
            return resultCount;            
        }

        public int GetCountRec(List<int> nextDigitList, int totalDigits)
        {
            if (totalDigits <= 0) return 0;
            int totalCount = 0;
            for (int i = 0; i < nextDigitList.Count; i++)
            {
                totalCount += totalDigits == 1 ? nextDigitList.Count : GetCountRec(Paths[nextDigitList[i]], totalDigits - 1);
            }
            return totalCount;
        }


    }

    public static class Extensions
    {
        public static ValidNumber UseChessPiece(this ValidNumber validNumber,ChessPiece chessPiece)
        {
            validNumber.ChessPiece = chessPiece;
            return validNumber;
        }
    }
}