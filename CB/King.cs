﻿using System.Collections.Generic;

namespace CB
{
    public class King : AbstractChessPiece
    {
        public King(char[,] keyPad, int validLength) : base(keyPad, validLength) { }

        /// <summary>
        /// Computes a map of all possible next (neighbor) digits for a given digit
        /// </summary>
        public override void ComputeValidPathMap()
        {
            for (int i = 0; i <= Rows; i++)
            {
                for (int j = 0; j <= Cols; j++)
                {
                    if (!int.TryParse(KeyPad[i, j].ToString(), out _))
                    {
                        continue;
                    }

                    List<int> curNeighbors = new List<int>();
                    int pairRowForward = i + 1;
                    int pairRowBackward = i - 1;
                    int pairColForward = j + 1;
                    int pairColBackward = j - 1;
                     
                    // Notice the if loop to restrict the movement to just one square for the King

                    if (pairRowForward <= Rows || pairRowBackward >= 0 ||
                        pairColForward <= Cols || pairColBackward >= 0)
                    {
                        if (pairColForward <= Cols && char.IsDigit(KeyPad[i, pairColForward]))
                        {
                            curNeighbors.Add(KeyPad[i, pairColForward] - '0');
                        }

                        if (pairColBackward >= 0 && char.IsDigit(KeyPad[i, pairColBackward]))
                        {
                            curNeighbors.Add(KeyPad[i, pairColBackward] - '0');
                        }

                        if (pairRowBackward >= 0 && char.IsDigit(KeyPad[pairRowBackward, j]))
                        {
                            curNeighbors.Add(KeyPad[pairRowBackward, j] - '0');
                        }

                        if (pairRowForward <= Rows && char.IsDigit(KeyPad[pairRowForward, j]))
                        {
                            curNeighbors.Add(KeyPad[pairRowForward, j] - '0');
                        }

                        if (pairColForward <= Cols && pairRowForward <= Rows && char.IsDigit(KeyPad[pairRowForward, pairColForward]))
                        {
                            curNeighbors.Add(KeyPad[pairRowForward, pairColForward] - '0');
                        }

                        if (pairColBackward >= 0 && pairRowBackward >= 0 && char.IsDigit(KeyPad[pairRowBackward, pairColBackward]))
                        {
                            curNeighbors.Add(KeyPad[pairRowBackward, pairColBackward] - '0');
                        }

                        if (pairRowBackward >= 0 && pairColForward <= Cols && char.IsDigit(KeyPad[pairRowBackward, pairColForward]))
                        {
                            curNeighbors.Add(KeyPad[pairRowBackward, pairColForward] - '0');
                        }

                        if (pairRowForward <= Rows && pairColBackward >= 0 && char.IsDigit(KeyPad[pairRowForward, pairColBackward]))
                        {
                            curNeighbors.Add(KeyPad[pairRowForward, pairColBackward] - '0');
                        }
                    }
                    Paths[KeyPad[i, j] - '0'] = curNeighbors;
                }
            }
        }
    }
}
