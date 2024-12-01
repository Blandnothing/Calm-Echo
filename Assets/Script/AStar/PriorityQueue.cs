using System;
using System.Collections.Generic;



    public class PriorityQueue<T> where T : IComparable<T>
    {
        public int NowLength { get; private set; }
        public int MaxLength { get; private set; }
        public T Top => heap[0];
        public bool IsEmpty => NowLength == 0;
        public bool IsFull => NowLength >= MaxLength - 1;
        private readonly Dictionary<T, int> nodeIdxTable; // 记录结点在数组中的位置，方便查找
        private readonly bool isReverse;
        private readonly T[] heap;

        public PriorityQueue(int maxLength, bool isReverse = false)
        {
            NowLength = 0;
            MaxLength = maxLength;
            heap = new T[MaxLength + 1];
            nodeIdxTable = new Dictionary<T, int>();
            this.isReverse = isReverse;
        }
        public T this[int index]
        {
            get => heap[index];
        }
        public void PushHeap(T value)
        {
            if (NowLength < MaxLength)
            {
                if (nodeIdxTable.ContainsKey(value))
                    nodeIdxTable[value] = NowLength;
                else
                    nodeIdxTable.Add(value, NowLength);
                heap[NowLength] = value;
                Swim(NowLength);
                ++NowLength;
            }
        }
        public void PopHeap()
        {
            if (NowLength > 0)
            {
                nodeIdxTable[heap[0]] = -1; 
                heap[0] = heap[--NowLength];
                nodeIdxTable[heap[0]] = 0;
                Sink(0);
            }
        }
        public bool Contains(T value)
        {
            return nodeIdxTable.ContainsKey(value) && nodeIdxTable[value] != -1;
        }
        public T Find(T value)
        {
            if (Contains(value))
                return heap[nodeIdxTable[value]];
            return default;
        }
        public void Clear()
        {
            nodeIdxTable.Clear();
            NowLength = 0;
        }
        private void SwapValue(T a, T b)
        {
            var aIdx = nodeIdxTable[a];
            var bIdx = nodeIdxTable[b];
            heap[aIdx] = b;
            heap[bIdx] = a;
            nodeIdxTable[a] = bIdx;
            nodeIdxTable[b] = aIdx;
        }

        private void Swim(int index)
        {
            int father;
            while (index > 0)
            {
                father = (index - 1) >> 1;
                if (IsBetter(heap[index], heap[father]))
                {
                    SwapValue(heap[father], heap[index]);
                    index = father;
                }
                else return;
            }
        }

        private void Sink(int index)
        {
            int largest, left = (index << 1) + 1;
            while (left < NowLength)
            {
                largest = left + 1 < NowLength && IsBetter(heap[left + 1], heap[left]) ? left + 1 : left;
                if (IsBetter(heap[index], heap[largest]))
                    largest = index;
                if (largest == index) return;
                SwapValue(heap[largest], heap[index]);
                index = largest;
                left = (index << 1) + 1;
            }
        }
        private bool IsBetter(T v1, T v2)
        {
            return isReverse ? (v2.CompareTo(v1) < 0 ): (v1.CompareTo(v2) < 0);
        }
    }
