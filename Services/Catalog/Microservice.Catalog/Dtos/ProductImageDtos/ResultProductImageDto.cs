using Microservice.Catalog.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Microservice.Catalog.Dtos.ProductImageDtos
{
    public class ResultProductImageDto
    {
        public string ProductImageID { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string ProductId { get; set; }
    }
}
