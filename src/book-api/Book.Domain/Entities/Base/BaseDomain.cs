using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.Entities.Base
{
    public class BaseDomain
    {
        //public int Id { get; set; }
        public Guid Id { get; set; } = new Guid();

    }
}
