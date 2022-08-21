using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
    public class TableStructure
    {
        public string COLUMN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string IS_NULLABLE { get; set; }
        public string CHARACTER_MAXIMUM_LENGTH { get; set; }
        public string NUMERIC_PRECISION { get; set; }
        public string NUMERIC_SCALE { get; set; }
    }
}
