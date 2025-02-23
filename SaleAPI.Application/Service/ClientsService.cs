using SaleAPI.Application.DTO;
using SaleAPI.Application.Interfaces;
using SaleAPI.Domain.Entities;
using SaleAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.Service
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientsRepository.GetAllAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _clientsRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ClientsDTO clientDTO)
        {
            var client = new Client
            {
                Name = clientDTO.Name
            };

            await _clientsRepository.AddAsync(client);
        }

        public async Task UpdateAsync(ClientsDTO clientDTO)
        {
            var client = new Client
            {
                Name = clientDTO.Name
            };
            await _clientsRepository.UpdateAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientsRepository.DeleteAsync(id);
        }
    }
}
