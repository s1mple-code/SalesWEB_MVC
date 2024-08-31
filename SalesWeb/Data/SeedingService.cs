using SalesWeb.Models;
using SalesWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Data
{
    public class SeedingService
    {

        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return; // BD já populadado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1999, 1, 1), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria", "mari@gmail.com", new DateTime(1950, 1, 1), 2000.0, d2);
            Seller s3 = new Seller(3, "Francisco", "fra@gmail.com", new DateTime(1980, 1, 1), 2500.0, d3);
            Seller s4 = new Seller(4, "Marcio", "ma@gmail.com", new DateTime(1980, 1, 1), 2500.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2024, 08, 31), 11000.0, SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2024, 08, 31), 12000.0, SalesStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2024, 08, 31), 13000.0, SalesStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2024, 08, 31), 15000.0, SalesStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecords.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        }

    }
}
