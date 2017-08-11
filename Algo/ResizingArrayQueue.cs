using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class ResizingArrayQueue<T> : Queue<T>
    {
        private T[] a;
        private int capacity;
        private int head = 0;
        private int tail = 0;
        private int count = 0;

        public ResizingArrayQueue(int capacity)
        {
            a = new T[capacity];
            this.capacity = capacity;
        }


        public override T Dequeue()
        {
            if (count > 0 && count == capacity / 4)
            {
                //capacity /= 2;
                Resize(capacity / 2);
            }
            count--;
            return a[head++ % capacity];
        }

        private void Resize(int max)
        {
            T[] temp = new T[max];
            for (int i = head; i < tail; i++)
            {
                temp[i - head] = a[i % capacity];
            }
            capacity = max;
            tail = tail - head;
            head = 0;
            a = temp;
        }

        public override void Enqueue(T item)
        {
            if (count == capacity)
            {
                //capacity *= 2;
                Resize(capacity * 2);
            }

            a[tail++ % capacity] = item;
            count++;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override bool IsEmpty()
        {
            return count == 0;
        }

        public override int Size()
        {
            return count;
        }
    }
}
