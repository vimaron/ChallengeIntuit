using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClientsRepository
    {
        protected readonly ApplicationDbContext _context;

        public ClientsRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ClientsEntity>> GetAll()
        {
            return await _context.GetAll();
        }
    }
}
