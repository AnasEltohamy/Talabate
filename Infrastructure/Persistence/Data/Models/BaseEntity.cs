using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Models
{
    internal class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
