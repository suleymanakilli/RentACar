using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public string CVV { get; set; }
    }
}
