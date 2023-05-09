using Data.Entities;
using Data.Exceptions;
using Data.Repository;
using Data.Repository.Clients;

namespace ChallengeIntuit.Services
{
    public class ClientsService
    {
        private readonly ClientsRepository _repository;

        public ClientsService(ClientsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClientsEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ClientsEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<ClientsEntity>> GetByName(string name)
        {
            return await _repository.GetByName(name);
        }

        public async Task<ClientsEntity> Create(
            string name,
            string lastName,
            DateTime birthDate,
            string CUIT,
            string address,
            string phoneNumber,
            string mail)
        {
            if (await this.Exists(name, lastName, CUIT))
                throw new ClientAlreadyExistsException();

            var newObj = new ClientsEntity()
            {
                Name = name,
                LastName = lastName,
                BirthDate = birthDate,
                CUIT = CUIT,
                Address = address,
                PhoneNumber = phoneNumber,
                Mail = mail
            };

            newObj = await _repository.Create(newObj);

            await _repository.SaveChanges();

            return newObj;
        }

        private async Task<bool> Exists(string name, string lastName, string CUIT)
        {
            return await _repository.Exists(name, lastName, CUIT);
        }
    }
}
