using Data.Entities;
using Data.Repository.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        protected static ApplicationDbContext _context;

        public static ApplicationDbContext contextSingleton
        {
            get
            {
                if(_context == null)
                {
                    _context = new ApplicationDbContext();
                }
                return _context;
            }
        }

        public async Task<List<ClientsEntity>> GetAll()
        {
            return await contextSingleton.Clients.ToListAsync();
        }

    }
}
