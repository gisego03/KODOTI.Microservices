using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Persistence.Database.Configurations
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entity)
        {
            entity.HasIndex(x => x.ClientId);
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);

            var clients = new List<Client>();
            for (int i = 1; i <= 10; i++)
            {
                var client = new Client()
                {
                    ClientId = i,
                    Name = $"Client {i}"
                };
                clients.Add(client);
            }

            entity.HasData(clients);
        }
    }
}
