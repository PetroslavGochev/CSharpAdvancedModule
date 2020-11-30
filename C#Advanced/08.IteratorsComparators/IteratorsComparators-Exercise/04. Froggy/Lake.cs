using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        public Lake(int[] stone)
        {
            this.Stone = stone;
        }
        public int[] Stone { get; set; }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stone.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.Stone[i];
                }
            }
            for (int i = this.Stone.Length - 1; i >= 1; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.Stone[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
