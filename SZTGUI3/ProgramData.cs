using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SZTGUI3
{
    [Serializable]
    internal class ProgramData
    {
        public List<KeyValuePair<string, List<KeyValuePair<string, bool>>>> Questions { get; set; }
    }
}
