using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG14Connect
{
    public class FG14v3
    {
        public struct Prozessdaten
        {
            public TimeSpan ZeitGesammt;
            public TimeSpan ZeitMontage;
            public int MaxKraft_Vorweiten;
            public int MaxKraft_Einschub;
            public int V_Einschub;
            public int V_Vorweiten;
            public int Einschubtiefe;
            public int Vorweittiefe;
            public int Rohrlänge;
            public string Leitungsname;
        }

        public struct Systemdaten
        {
            public DateTime timestamp;
            public String User;
            public int ID;
            public String Text;
            public String ToolNr;

        }
    }
}
