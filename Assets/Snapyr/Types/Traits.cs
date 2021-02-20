using System.Collections.Generic;

namespace Snapyr.Types
{
    public class Traits : Dictionary<string, object>
    {
        public Traits Put(string key, object val)
        {
            Add(key, val); 
            return this;
        }
    }
}