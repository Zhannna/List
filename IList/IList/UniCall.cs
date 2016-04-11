using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class UniCall<T> : IList<T> where T:IComparable<T> 
    {
        private T[] innerArray;
        public UniCall()
    {
        innerArray =new T[0] ; 
    }


        public T this[int index]
        {
            get
            {
                return innerArray[index];
            }
            set
            {
                innerArray[index] = value;
            }
        }


        public int IndexOf(T obj)
        { 
            int index = 0 ;
            for (int i = 0; i < innerArray.Length; i++)
            {
                if (innerArray[i].CompareTo(obj) > 0 | innerArray[i].CompareTo(obj) < 0)
                {

                }
                else
                    index = i;
                    
            }
            return index;
        }

        public void Insert(int index, T item)
        { 
            int length = innerArray.Length + 1;
            T[] inAr = new T[length ];
            
            for (int i = 0; i <index; i++)
            {
                inAr[i] = innerArray[i];
            }
            inAr[index] = item;
            for (int i = index+1; i < inAr.Length; i++)
            {
                inAr[i] = innerArray[i-1]; 
            }
            innerArray = inAr;
        }


        public void RemoveAt(int index)
        {
            int length = innerArray.Length - 1;
            T[] inAr = new T[length];
            for (int i = 0; i < index; i++)
            {
                inAr[i] = innerArray[i];

            }
            for (int i = index; i < length; i++)
            {
                inAr[i] = innerArray[i + 1];
            }
            innerArray = inAr;

        }


        public int Count 
        {
            get { return innerArray.Length; }
        }

        public bool IsReadOnly
        {
            get
            { return false;}
        }

        public void Add(T item)
        {


            int length = innerArray.Length + 1;
            T[] inAr = new T[length];
            for (int i = 0; i < innerArray.Length; i++)
            {
                inAr[i] = innerArray[i];
            }
            inAr[length - 1] = item;

            innerArray = inAr;
        }

        public void Clear()
        {
            innerArray = new T[0];
        }


        public bool Contains(T item)
        {
            for (int i = 0; i < innerArray.Length; i++)
            {
                if (innerArray[i].CompareTo(item) == 0)
                    return true;

                
            }
            return false;

        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < innerArray.Length; i++)
            {
                array[i-arrayIndex] = innerArray[i];
            }

        }

        public bool Remove(T item)
        {
            int index = 0;
            for (int i = 0; i < innerArray.Length; i++)
            {
                if (innerArray[i].CompareTo(item) == 0)
                    index=i;


            }
            if (index != 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
            
        }



        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }




        public IEnumerator<T> GetEnumerator()
        {
            return new UniCallIEnumerator(this);
        }



        private class UniCallIEnumerator : IEnumerator<T>
        {
            #region IEnumerator members
            public void Dispose()
            {

            }

            private UniCall<T> bl;
            public UniCallIEnumerator(UniCall<T> bl)
            {
                this.bl = bl;
            }

            int index = -1;
            public T Current
            {
                get { return bl.innerArray[index]; }
            }
            public bool MoveNext()
            {
                index++;
                return index < bl.innerArray.Length;
            }
            public void Reset()
            {
                index = -1;
            }


            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }
            #endregion

        }

    }
}
