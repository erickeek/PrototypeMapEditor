using System;
using System.Collections.Generic;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class MetadataMap
    {
        public string FileName { get; set; }

        public IEnumerable<ObjectMap> ObjectsInMap { get; set; }
    }
}