using System;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public class LibraryListing : Query<Library.Filterable, Library.Orderable, Library>
    {
        public LibraryListing(Func<string, Task<Listing<Library>>> client): base(client)
        {
        }
    }
}