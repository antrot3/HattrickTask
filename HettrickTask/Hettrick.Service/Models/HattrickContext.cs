using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;

 namespace Hattrick.Service.Models
{
    public interface IHattrickContext
    {
        IDbSet<Profile> Profiles { get; set; }
        IDbSet<SportCategory> SportCategorys { get; set; }
        IDbSet<SportGame> SportGames { get; set; }
        IDbSet<Ticket> Tickets { get; set; }
        IDbSet<TicketToGame> TicketToGames { get; set; }
        IDbSet<Transactions> Transactions { get; set; }
    }
     public class HattrickContext:DbContext,IHattrickContext
    {
        public HattrickContext():base("name=HattricContextConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new Hattrick.Service.DatabaseIntialization.HattrickDatabaseInitialization());
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
