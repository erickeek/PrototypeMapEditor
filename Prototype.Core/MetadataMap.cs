using System;
using System.Collections.Generic;

namespace Prototype.Core
{
    [Serializable]
    public class MetadataMap
    {
        public string FileName { get; set; }

        public IEnumerable<ObjectMap> ObjectsInMap { get; set; }
    }
}