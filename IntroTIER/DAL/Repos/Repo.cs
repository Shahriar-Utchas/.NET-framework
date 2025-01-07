using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repo
    {
        protected UMSContext db = new UMSContext();
        public Repo()
        {
            db = new UMSContext();
        }

    }
}
