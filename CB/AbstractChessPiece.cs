using System;
using System.Collections.Generic;
using System.Text;

namespace CB
{
    public abstract class AbstractChessPiece
    {
        public char[,] KeyPad { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public Dictionary<int, List<int>> Paths { get; set; }
        public int ValidNumberLength { get; set; }
        public AbstractChessPiece(char[,] keyPad,int validLength)
        {
            Paths = new Dictionary<int, List<int>>();
            KeyPad = keyPad;
            ValidNumberLength = validLength;
            int dictlen = 0;
            Rows= KeyPad.GetUpperBound(0);
            Cols= KeyPad.GetUpperBound(1);
            while (dictlen < 10)
            {
                Paths[dictlen] = new List<int>();
                dictlen++;
            }
        }

        public int CountPossibleValidNumbers()
        {
            this.ComputeValidPathMap();
            int resultCount = 0;
            for (int i = 2; i < Paths.Count; i++)
            {
                resultCount += GetCountRec(Paths[i], ValidNumberLength - 1);
            }
            return resultCount;

        }
        private int GetCountRec(List<int> nextDigitList, int totalDigits)
        {
            if (totalDigits <= 0) return 0;
            int totalCount = 0;
            for (int i = 0; i < nextDigitList.Count; i++)
            {
                totalCount += totalDigits == 1 ? nextDigitList.Count : GetCountRec(Paths[nextDigitList[i]], totalDigits - 1);
            }
            return totalCount;
        }
        public abstract void ComputeValidPathMap();
    }
}
