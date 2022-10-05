//using System;
//using System.Security.Cryptography;

//namespace ScheduPayBlockchainFramework 
//{
//    public class ServiceBlock : IBlock, IComparable<ServiceBlock>, IEquatable<ServiceBlock>
//    {
//        public string DateTimestamp { get; set; }
//        public string LastHash { get; set; }
//        private string _hash;
//        public string Hash 
//        { 
//            get
//            {
//                if(_hash == null)
//                {
//                    int outHash;
//                    var result = Int32.TryParse(LastHash, out outHash);
//                    HashAlgorithm sha = SHA256.Create();
//                    double valueToHash = (double.Parse(DateTimestamp) + (result == true ? outHash : 0));
//                    byte[] convertyLongToByte = BitConverter.GetBytes(valueToHash);
//                    byte[] hash = sha.ComputeHash(convertyLongToByte);
//                    long convertByteArrayToLong = BitConverter.ToInt32(hash, 0);

//                    _hash = convertByteArrayToLong.ToString();
//                }
//                return _hash;
//            }
            
//        }
//        public ServiceDetails ServiceDetails { get; set; }

//        public ServiceBlock()
//        {
//        }

//        public ServiceBlock(string dateTimestamp, string lastHash, string hash)
//        {
//            DateTimestamp = dateTimestamp;
//            LastHash = lastHash;
//            //Hash = hash;
//        }

//        public ServiceBlock(string dateTimestamp, string lastHash, ServiceDetails serviceDetails)
//        {
//            DateTimestamp = dateTimestamp;
//            LastHash = lastHash;
//            ServiceDetails = serviceDetails;
//        }

//        public ServiceBlock(string dateTimestamp, string lastHash, string hash, ServiceDetails serviceDetails)
//        {
//            DateTimestamp = dateTimestamp;
//            LastHash = lastHash;
//            //Hash = hash;
//            ServiceDetails = serviceDetails;
//        }

//        public int CompareTo(ServiceBlock other)
//        {
//            if(other == null) return 1;

//            //var testing = ParseDateTimestamp(DateTimestamp).CompareTo(ParseDateTimestamp(other.DateTimestamp));
//            return double.Parse(DateTimestamp).CompareTo(double.Parse(other.DateTimestamp));
//        }


//        public static bool operator > (ServiceBlock serviceBlock, string dateTimestamp2)
//        {
//            return Int64.Parse(serviceBlock.DateTimestamp).CompareTo(Int64.Parse(dateTimestamp2)) > 0;
//        }
//        public static bool operator < (ServiceBlock serviceBlock, string dateTimestamp2)
//        {
//            return Int64.Parse(serviceBlock.DateTimestamp).CompareTo(Int64.Parse(dateTimestamp2)) < 0;
//        }

//        public static bool operator >= (ServiceBlock serviceBlock, string dateTimestamp2)
//        {
//            return Int64.Parse(serviceBlock.DateTimestamp).CompareTo(Int64.Parse(dateTimestamp2)) >= 0;
//        }
//        public static bool operator <= (ServiceBlock serviceBlock, string dateTimestamp2)
//        {
//            return Int64.Parse(serviceBlock.DateTimestamp).CompareTo(Int64.Parse(dateTimestamp2)) <= 0;
//        }

//        public bool Equals(ServiceBlock other)
//        {
//            if(other == null) return false;

//            if(this.DateTimestamp == other.DateTimestamp)
//                return true;
//            else
//                return false;
//        }

//        public override bool Equals(object obj)
//        {
//            if(obj == null) return false;

//            ServiceBlock serviceBlock = obj as ServiceBlock;

//            if(serviceBlock == null) 
//                return false;
//            else
//                return Equals(serviceBlock);
//        }

//        public override int GetHashCode()
//        {
//            return Int32.Parse(this.Hash);
//        }

//        public static bool operator == (ServiceBlock serviceBlock, ServiceBlock serviceBlock2)
//        {
//            if((object)serviceBlock == null || ((object)serviceBlock2) == null)
//            {
//                return Object.Equals(serviceBlock, serviceBlock2);
//            }
            
//            return serviceBlock.Equals(serviceBlock2);
//        }

//        public static bool operator != (ServiceBlock serviceBlock, ServiceBlock serviceBlock2)
//        {
//            if((object)serviceBlock == null || ((object)serviceBlock2) == null)
//            {
//                return ! Object.Equals(serviceBlock, serviceBlock2);
//            }
            
//            return ! (serviceBlock.Equals(serviceBlock2));
//        }
//    }
//}
