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

        public async Task<ClientsEntity> GetById(int id)
        {
            return await contextSingleton.Clients.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<ClientsEntity>> GetByName(string name)
        {
            return await contextSingleton.Clients.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<ClientsEntity> Create(ClientsEntity obj)
        {
            var newEntity = await contextSingleton.Clients.AddAsync(obj);
            return newEntity.Entity;
        }

        public void Update(ClientsEntity obj)
        {
            contextSingleton.Clients.Update(obj);
        }

        public async Task SaveChanges()
        {
            await contextSingleton.SaveChangesAsync();
        }

        public async Task<bool> Exists(string name, string lastName, string CUIT)
        {
            return await contextSingleton.Clients.AnyAsync
                (x =>
                    x.Name == name &&
                    x.LastName == lastName &&
                    x.CUIT == CUIT
                );
        }
    }
}
