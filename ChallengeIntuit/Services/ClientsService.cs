using Data.Entities;
using Data.Repository;

namespace ChallengeIntuit.Services
{
    public class ClientsService
    {
        private readonly ClientsRepository _repository;

        public ClientsService(ClientsRepository repository)
        {
            _repository = repository;
        }

        public async List<ClientsEntity> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
