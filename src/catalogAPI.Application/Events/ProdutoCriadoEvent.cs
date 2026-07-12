using catalogAPI.Domain.EventsConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace catalogAPI.Application.Events
{
    [MessageTopic("TOPIC_TARGET_PRODUTO_CRIADO")]
    public class ProdutoCriadoEvent : IntegrationEvent
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("CategoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
    }
}
