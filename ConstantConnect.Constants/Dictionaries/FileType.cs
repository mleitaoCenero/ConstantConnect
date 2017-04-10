using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Constants.Dictionaries
{
    public static class FileType
    {
        static Dictionary<int, string> _dict = new Dictionary<int, string>
        {
            {1,"Control Code"},
            {2,"Configuration Code"},
            {3,"EDID Document"},
            {4,"IP Scheme Document"},
            {5,"Other"},
            {6,"Show Solutions"},
            {100000000,"Drawings"},
            {100000001,"BOM"},
            {100000002,"Vendor Quotes"},
            {100000003,"SOW_Proposals"},
            {100000004,"Site Surveys"},
            {100000005,"Client Order Documents"},
            {100000006,"Close-Out Documents"},
            {100000007,"Sales Change Order"},
            {100000008,"Constant Connect Code"},
            {100000009,"Move to Project"},
            {100000010,"Compiled Code"},
            {100000011,"Touch Panel Submittals"},
            {100000012,"Subcontractor Documents"}
        };

        public static string GetFileType(int i)
        {
            string result;
            if (_dict.TryGetValue(i, out result))
                return result;
            return "";
        }
    }
}
