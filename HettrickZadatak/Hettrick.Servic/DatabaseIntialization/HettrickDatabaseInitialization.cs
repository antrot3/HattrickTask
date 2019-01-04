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
                new SportCategory {CategoryName = "Basket-ball",Active1=true,Active2=true, ActiveX=true,Active12=true,Active1x=true,Active2x=true },
                new SportCategory {CategoryName = "Soccer",Active1=true,Active2=true, ActiveX=true,Active12=true,Active1x=true,Active2x=true },
                new SportCategory {CategoryName = "Tenis",Active1=true,Active2=true, ActiveX=false,Active12=false,Active1x=false,Active2x=false },
               
            };
            sportCategorys.ForEach(s => context.SportCategorys.Add(s));
            var profile = new Profile { Name = "Ante Rota", AccountBallance = 500.00 };
            context.Profiles.Add(profile);
            context.SaveChanges();

            var sportGames = new List<SportGame>
            {
                new SportGame{ Team1="Zadar",Team2="Petrol Olimpija", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=1.7,Value2=2.25 ,ValueX=1.50,Value12=1,Value1X=1.50,Value2X=1.92,TopOffer=false, TopOfferFactor=1, GameTime=DateTime.Now},
                new SportGame{ Team1="Partizan",Team2="Mornar", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=1.25,Value2=4.0 ,ValueX=17,Value12=1,Value1X=1.16,Value2X=3.24,TopOffer=true, TopOfferFactor=1.3,GameTime=DateTime.Now},
                new SportGame{ Team1="Mega Bemax",Team2="Cedevita", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=2.50,Value2=1.55 ,ValueX=15.00,Value12=1,Value1X=2.14,Value2X=1.40,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Budućnost",Team2="Igokea", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=2,Value2=1.4 ,ValueX=22,Value12=1.1,Value1X=1.2,Value2X=1.3,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Clevland",Team2="Utah", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=1.7,Value2=2.25 ,ValueX=1.50,Value12=1,Value1X=1.50,Value2X=1.92,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Miami",Team2="Washington", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=1.25,Value2=4.0 ,ValueX=17,Value12=1,Value1X=1.16,Value2X=3.24,TopOffer=true, TopOfferFactor=1.3,GameTime=DateTime.Now},
                new SportGame{ Team1="Boston",Team2="Dallas", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=2.50,Value2=1.55 ,ValueX=15.00,Value12=1,Value1X=2.14,Value2X=1.40,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Minnesota",Team2="Orlando", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Basket-ball").First().Id,Value1=2,Value2=1.4 ,ValueX=22,Value12=1.1,Value1X=1.2,Value2X=1.3,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},

                new SportGame{ Team1="Klahn B",Team2="Mmoh M", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=1.80,Value2=1.90 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Robert S",Team2="Cuevas P.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=2.40,Value2=1.50 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Marterer M.",Team2="Masur D", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=1.40,Value2=2.70 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=true, TopOfferFactor=1.6,GameTime=DateTime.Now},
                new SportGame{ Team1="Tearbey F.",Team2="Fabbiano T.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=5.80,Value2=1.10 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Tamos Vinolas A.",Team2="Humber U.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=2.40,Value2=1.50 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Rai A",Team2="Norrie C.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=9.00,Value2=1.03 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Zaballos H.",Team2="Djere L.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=2.40,Value2=1.50 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=true, TopOfferFactor=1.6,GameTime=DateTime.Now},
                new SportGame{ Team1="Mcdonald M.",Team2="Lee D.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Tenis").First().Id,Value1=1.35,Value2=2.90 ,ValueX=1,Value12=1,Value1X=1,Value2X=1,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},

                new SportGame{ Team1="Roma",Team2="Porto", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=2.10,Value2=3.60 ,ValueX=3.40,Value12=1.33,Value1X=1.30,Value2X=1.75,TopOffer=true, TopOfferFactor=1.8,GameTime=DateTime.Now},
                new SportGame{ Team1="Man.Utd",Team2="Paris SG", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=3.20,Value2=2.20 ,ValueX=3.5,Value12=1.30,Value1X=1.67,Value2X=1.35,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Tottenham",Team2="Borussia D.", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=2.1,Value2=3.50 ,ValueX=3.50,Value12=1.31,Value1X=1.31,Value2X=1.75,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Ajax",Team2="Real Madrid", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=3.90,Value2=1.95 ,ValueX=3.60,Value12=1.30,Value1X=1.87,Value2X=1.36,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Liverpool",Team2="Bayern", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=1.7,Value2=2.25 ,ValueX=1.50,Value12=1,Value1X=1.50,Value2X=1.92,TopOffer=true, TopOfferFactor=1.8,GameTime=DateTime.Now},
                new SportGame{ Team1="Lyon",Team2="Barcelona", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=1.25,Value2=4.0 ,ValueX=3,Value12=1,Value1X=1.16,Value2X=3.24,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Atl.Madrid",Team2="Juventus", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=2.50,Value2=1.55 ,ValueX=2.40,Value12=1,Value1X=2.14,Value2X=1.40,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now},
                new SportGame{ Team1="Schalke 04",Team2="Man.City", CategoryId=context.SportCategorys.Where(x=>x.CategoryName=="Soccer").First().Id,Value1=2,Value2=1.4 ,ValueX=2.2,Value12=1.1,Value1X=1.2,Value2X=1.3,TopOffer=false, TopOfferFactor=1,GameTime=DateTime.Now}

            };
            sportGames.ForEach(g => context.SportGames.Add(g));
            context.SaveChanges();

        }
    }
}
