using Data.Entities;
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
    }
}
