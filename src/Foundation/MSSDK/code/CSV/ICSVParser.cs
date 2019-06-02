﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.CSV {
    public interface ICSVParser
    {
        List<List<string>> ParseCSV(string csv);
    }
}