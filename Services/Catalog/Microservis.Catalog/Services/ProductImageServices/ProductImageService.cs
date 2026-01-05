using AutoMapper;
using Microservis.Catalog.Dtos.ProductImageDtos;
using Microservis.Catalog.Dtos.ProductImageDtos;
using Microservis.Catalog.Entities;
using Microservis.Catalog.Services.ProductImageServices;
using Microservis.Catalog.Settings;
using MongoDB.Driver;

namespace Microservis.Catalog.Services.ProductImageServices
{
   
        public class ProductImageService : IProductImageService
        {
            private readonly IMongoCollection<ProductImage> _ProductImageCollection;
            private readonly IMapper _mapper;

            public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
            {
                var mongoClient = new MongoClient(_databaseSettings.ConnectionString);
                var mongoDatabase = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
                _ProductImageCollection = mongoDatabase.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
                _mapper = mapper;
            }
           

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var ProductImage = _mapper.Map<ProductImage>(createProductImageDto);
            await _ProductImageCollection.InsertOneAsync(ProductImage);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(c => c.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
