using System;
using System.Collections;
using System.Collections.Generic;

namespace ixts.Ausbildung.Zahlenfolgen
{
    public class Naturals:IEnumerator<int>
    {
        private int current = 0;
        private int stopper = 2147483646;//int wertebereich - 1


        object IEnumerator.Current
        {
            get { return current; }
        }

        public Boolean MoveNext()
        {
            if (current < stopper) 
            {
                current++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new Exception("Naturals isn't resetable");
        }

        int IEnumerator<int>.Current
        {
            get { return current; }
        }

        public void Dispose()
        {
        }
    }
}
