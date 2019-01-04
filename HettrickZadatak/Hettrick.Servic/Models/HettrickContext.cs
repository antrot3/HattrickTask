using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;

 namespace Hettrick.Servic.Models
{
    public interface IHettrickContext
    {
        IDbSet<Profile> Profiles { get; set; }
        IDbSet<SportCategory> SportCategorys { get; set; }
        IDbSet<SportGame> SportGames { get; set; }
        IDbSet<Ticket> Tickets { get; set; }
        IDbSet<TicketToGame> TicketToGames { get; set; }
        IDbSet<Transactions> Transactions { get; set; }
    }
     public class HettrickContext:DbContext,IHettrickContext
    {
        public HettrickContext():base("name=HettricContextConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new Hettrick.Servic.DatabaseIntialization.HettrickDatabaseInitialization());
            Database.Initialize(true);
        }


        public IDbSet<Profile> Profiles { get; set; }
        public IDbSet<SportCategory> SportCategorys { get; set; }
        public IDbSet<SportGame> SportGames { get; set; }
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<TicketToGame> TicketToGames { get; set; }
        public IDbSet<Transactions> Transactions { get; set; }
    }
}
