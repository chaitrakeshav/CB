using System.Collections.Generic;

namespace CB
{
    public class Rook : AbstractChessPiece
    {
        public Rook(char[,] keyPad,int validLength) : base(keyPad,validLength) { }

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
                    while (pairRowForward <= Rows || pairRowBackward >= 0 ||
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

                        pairRowForward++;
                        pairRowBackward--;
                        pairColForward++;
                        pairColBackward--;
                    }
                    Paths[KeyPad[i, j] - '0'] = curNeighbors;
                }
            }
        }
    }
}
