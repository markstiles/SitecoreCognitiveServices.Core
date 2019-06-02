using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis.Connector {
    public interface IContactRelationUpdateActivity : IActivity {
        /// <summary>
        /// add|remove
        /// 
        /// </summary>
        string Action { get; set; }
    }
}
