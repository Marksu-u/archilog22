using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiLibrary.Models
{
    public class ParamsPagination
    {
        private const int _maxItemPerPage = 5;
        private int itemsPerPage;

        public int Page { get; set; } = 1;
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxItemPerPage ? _maxItemPerPage : value;    
        }
    }
}
