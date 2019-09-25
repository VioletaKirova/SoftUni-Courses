using System.Collections.Generic;

namespace P05_GreedyTimes
{
    class Bag
    {
        private long bagCapacity;
        private Dictionary<string, Dictionary<string, long>> types;

        public Bag(long bagCapacity)
        {
            this.BagCapacity = bagCapacity;
            this.Types = new Dictionary<string, Dictionary<string, long>>();
        }

        public long BagCapacity
        {
            get { return bagCapacity; }
            set { bagCapacity = value; }
        }

        public Dictionary<string, Dictionary<string, long>> Types
        {
            get { return types; }
            set { types = value; }
        }
    }
}
