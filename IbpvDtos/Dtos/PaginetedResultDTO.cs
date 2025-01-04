using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvDtos
{
    //com um generico para poder usar em varios contextos de paginação
    public class PaginetedResultDTO<T>
    {
         public required List<T> items { get; set; }
         public int pages {get; set;}
    }
}