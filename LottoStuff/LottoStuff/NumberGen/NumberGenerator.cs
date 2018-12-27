using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoStuff
{
    public class NumberGenerator
    {
        public List<List<int>> numberCollection;

        private int drawSize;
        private int drawPoolSize;
        private int highestStartPoint;
        public NumberGenerator(int drawSize, int drawPoolSize)
        {
            this.drawPoolSize = drawPoolSize;
            this.drawSize = drawSize;
            numberCollection = new List<List<int>>();
            highestStartPoint = drawPoolSize - drawSize + 1;
            generateList(new List<int>(), 0, 1, highestStartPoint);
        }

        public void generateList(List<int> defaultList, int listIndex, int startPoint, int endPoint)
        {
            int i = startPoint;
            int nextIndex = listIndex + 1;
            int nextEndpoint = endPoint + 1;
            while(i <= endPoint && listIndex < drawSize)
            {
                List<int> newList = defaultList.ToList();
                if (newList.Count - 1 < listIndex)
                {
                    newList.Add(i);
                }
                else
                {
                    newList[listIndex] = i;
                }
                if (listIndex == (drawSize - 1))
                {
                    numberCollection.Add(newList);
                }
                else
                {
                    generateList(newList, nextIndex, i+1, nextEndpoint);
                }
                i++;
            }
        }
    }
}
