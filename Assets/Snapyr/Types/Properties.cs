using System.Collections.Generic;

namespace Snapyr.Types
{
    public class Properties : Dictionary<string, string>
    {
        public Properties Put(string key, string val)
        {
            Add(key, val); 
            return this;
        }
    }
}