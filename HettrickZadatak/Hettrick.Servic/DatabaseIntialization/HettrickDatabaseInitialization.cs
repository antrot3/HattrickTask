using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models;
using Hettrick.Servic.Models.Entities;

namespace Hettrick.Servic.DatabaseIntialization
{
    public class HettrickDatabaseInitialization : CreateDatabaseIfNotExists<Hettrick.Servic.Models.HettrickContext>
    {
        protected override void Seed(HettrickContext context)
        {
            var sportCategorys = new List<SportCategory>
            {
                new SportCategory {KategoryName = "Basket ball",Active1=true,Active2=true, ActiveX=true,Active12=true,Active1x=true,Active2x=true },
                new SportCategory {KategoryName = "Soccer",Active1=true,Active2=true, ActiveX=true,Active12=true,Active1x=true,Active2x=true },
                new SportCategory {KategoryName = "Tenis",Active1=true,Active2=true, ActiveX=false,Active12=false,Active1x=false,Active2x=false },
               
            };
            sportCategorys.ForEach(s => context.SportCategorys.Add(s));

            var profile = new Profile { Name = "Ante Rota", AccountBallance = 500.00 };


            context.Profiles.Add(profile);
            context.SaveChanges();
        }
    }
}
