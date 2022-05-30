using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL:IRatingDL
    {
        Hub_JerusalemContext data;

        public RatingDL(Hub_JerusalemContext data)
        {
            this.data = data;
        }
        public async Task post(Rating rating)
        {
            await data.Ratings.AddAsync(rating);
            await data.SaveChangesAsync();
        }
    }
}
