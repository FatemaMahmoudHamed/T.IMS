using IMS.Core.Entities;
using IMS.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;

namespace IMS.Infrastructure
{
    public class SeedData
    {
        private static DateTime now = DateTime.Now;

        private static bool IsDevelopment { get; set; } = true;

        /// <summary>
        /// Initialize the database.
        /// </summary>
        /// <param name="db">The database context.</param>
        /// <param name="isDevelopment">Determine if this is the development environment.</param>
        public static void Initialize(CommandDbContext db, bool isDevelopment)
        {

            if (db is null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            IsDevelopment = isDevelopment;
            db.Customers.AddRange(CreatCustomers());
            db.Incidents.AddRange(CreatIncidents());
            db.SaveChanges();

        }

        private static Customer[] CreatCustomers()
        {
            var customers = new List<Customer>();

            if (IsDevelopment)
            {
                var devCustomers = new[]
                {
                    new Customer
                    {
                        Name="Fatema",
                        Email="Fatmamahmoud.h@gmail.com",
                        Address="address",
                        Phone="01007983756"
                    }

                };

                customers.AddRange(devCustomers);
            }
            return customers.ToArray();
        }
        private static Incident[] CreatIncidents()
        {
            var incidents = new List<Incident>();

            if (IsDevelopment)
            {
                var devIncidents = new[]
                {
                    new Incident
                    {
                        CreatedOn = now,
                        Customer=new Customer{Name="User 1",Email="user1@gmail.com",Address="address",Phone="01007983756"},
                        Details="This is the incident",
                        read=false
                    }

                };

                incidents.AddRange(devIncidents);
            }

            return incidents.ToArray();
        }
    }
}
