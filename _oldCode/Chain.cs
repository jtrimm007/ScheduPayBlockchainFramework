//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace ScheduPayBlockchainFramework
//{
//    public class Node<T>
//    {
//        public T Item { get; set; }
//        public Node<T> Next { get; set; }
//    }
//    public class Chain : IEquatable<Chain>
//    {
//        #region Fields & Properties
//        public GenesisBlock Genesis 
//        {
//            get 
//            {
//                return Head.Item as GenesisBlock;
//            }
            
//        }
//        public Node<IBlock> Head { get; set; }  

//        public ServiceBlock this[int index]
//        {
//            get { return this[index]; }
//            set { this[index] = value; }
//        }


//        public int this[string hash] => BinarySearch(hash);
//        #endregion

//        #region Constructors 
//        public Chain(IBlock genesisBlock)
//        {
//            var node = new Node<IBlock>()
//            {
//                Item = genesisBlock,
//                Next = null
//            };

//            Head = node;
//        }

//        public Chain(string jsonString)
//        {

//        }

//        public Chain()
//        {
//        }
//        #endregion
        
//        public void AddRange(List<ServiceBlock> blocks)
//        {
//            for (int i = 0; i < blocks.Count; i++)
//            {
//                if (Genesis == null)
//                    return;
//                if(i == 0)
//                    blocks[0].LastHash = Genesis.Hash;

//                this.Add(blocks[i]);
//            }
//        }
//        public void Add(IBlock item)
//        {
//            var node = new Node<IBlock>()
//            {
//                Item = item,
//                Next = null
//            };

//            if(Head != null)
//            {
//                Node<IBlock> current = Head;

//                while(current.Next != null)
//                {
//                    current = current.Next;
//                }

//                current.Next = node;    
//            }
//            else
//            {
//                Head = node;
//            }
//        }
//        public long Count()
//        {
//            long counter = 0;
//            if(Genesis != null)
//            {
//                counter++;
//                var current = Head;

//                while(current.Next != null)
//                {
//                    counter++;
//                    current = current.Next;
//                }
//            }
//            return counter;
//        }

//        private int BinarySearch(string hash)
//        {
//            int minNum = 0;
//            int maxNum = (int)this.Count() - 1;

//            while(minNum <= maxNum)
//            {
//                int mid = (minNum + maxNum) / 2;
//                IBlock[] array = this.ToArray();

//                array = QuickSort(array, 0, array.Length - 1);

//                if(Int32.Parse(hash) == array[mid].GetHashCode())
//                {
//                    return ++mid;
//                }
//                else if(Int32.Parse(hash) < array[mid].GetHashCode())
//                {
//                    maxNum = mid - 1;
//                }
//                else
//                {
//                    minNum = mid + 1;
//                }
//            }
//            return -1;
//        }

//        /// <summary>
//        /// Quick Sorting based on the hash code.
//        /// </summary>
//        /// <param name="array">The array.</param>
//        /// <param name="left">The left.</param>
//        /// <param name="right">The right.</param>
//        /// <returns></returns>
//        public IBlock[] QuickSort(IBlock[] array, int left, int right)
//        {
//            if(left < right)
//            {
//                int pivot = Partition(array, left, right); 

//                if(pivot > 1)
//                {
//                    QuickSort(array, left, pivot -1);
//                }
//                if(pivot + 1 < right)
//                {
//                    QuickSort(array, pivot + 1, right);
//                }
//            }

//            return array;
//        }

//        private int Partition(IBlock[] array, int left, int right)
//        {
//            var pivot = array[left].GetHashCode();

//            while (true)
//            {
//                while(array[left].GetHashCode() < pivot)
//                {
//                    left++;
//                }

//                while(array[right].GetHashCode() > pivot)
//                {
//                    right--;
//                }

//                if(left < right)
//                {
//                    if (array[left].GetHashCode() == array[right].GetHashCode()) return right;

//                    IBlock temp = array[left];
//                    array[left] = array[right];
//                    array[right] = temp;
//                }
//                else
//                {
//                    return right;
//                }
//            }
//        }

//        public override string ToString()
//        {
//            List<object> chain = null;
//            if (Head != null)
//            {
//                chain = new List<object>();
//                chain.Add(Head.Item as GenesisBlock);
//                //string genesisJson = JsonConvert.SerializeObject(Head.Item, Formatting.Indented);
//               // var genesisJson = JsonSerializer.Serialize(Head.Item);
//                var node = Head.Next;

//                while (node.Next != null)
//                {
//                    //var json = JsonSerializer.Serialize(node.Item);
//                    chain.Add(node.Item as ServiceBlock);
//                    node = node.Next;
//                } 

//                // Serialize the last item
//                //var lastItemJson = JsonSerializer.Serialize(node.Item);
//                chain.Add(node.Item as ServiceBlock);

                
//            }

//            return chain == null ? "" : JsonConvert.SerializeObject(chain).ToString();
//        }

//        public Chain ToChain(string jsonString)
//        {
//            List<object> backToJson = JsonConvert.DeserializeObject<List<object>>(jsonString);


//            var genesisString = backToJson[0].ToString();

//            var genesisBlock = JsonConvert.DeserializeObject<GenesisBlock>(genesisString);

//            // create a new Node<T> to store the blocks in
//            Node<IBlock> nodes = new Node<IBlock>
//            {
//                Item = genesisBlock,
//                Next = null
//            };

//            // put the genBlock in the Head as the Item
//            Head = nodes;

//            int sizeOfList = backToJson.Count;

//            // put the Head in a holder
//            var node = Head;

//            for (var a = 1; a < sizeOfList; a++)
//            {
//                string serviceBlockString = backToJson[a].ToString();

//                ServiceBlock block = JsonConvert.DeserializeObject<ServiceBlock>(serviceBlockString);
//                node.Next = new Node<IBlock>
//                {
//                    Item = block,
//                    Next = null
//                };

//                // move to the next node
//                node = node.Next;
//            }

//            return this;
//        }

//        public IBlock[] ToArray()
//        {
//            var array = new IBlock[this.Count()];

//            if(Head != null)
//            {
//                array[0] = Head.Item as GenesisBlock;
//                int counter = 1;

//                var node = Head.Next;

//                while(node.Next != null)
//                {
//                    counter++;
//                    array[counter] = (IBlock)node.Next;
//                    node = node.Next;
//                }

//                // Add the last node
//                array[counter] = node.Item as ServiceBlock;

//            }
//            return array;
//        }

//        public bool Equals(Chain other)
//        {
//            if (other == null) return false;

//            var itemOne = this.Head.Item as GenesisBlock;
//            var itemTwo = other.Head.Item as GenesisBlock;

//            if (itemOne.CreationTimestamp != itemTwo.CreationTimestamp && itemOne.Hash != itemTwo.Hash)
//                return false;
//            else
//                return true;
//        }

//        public override bool Equals(object obj)
//        {
//            if (obj == null) return false;

//            Chain chain = obj as Chain;

//            if (chain == null)
//                return false;
//            else
//                return Equals(chain);
//        }
//    }
//}
