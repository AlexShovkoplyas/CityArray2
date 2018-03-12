using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityArrayDAL.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int PersonId { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }

        public virtual Review Review { get; set; }
        public virtual Person Person { get; set; }
    }
}
