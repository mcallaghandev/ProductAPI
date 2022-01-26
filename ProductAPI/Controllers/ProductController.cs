namespace ProductAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using ProductAPI.Data;
    using ProductAPI.Dtos;
    using ProductAPI.Models;

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAsyncProductRepository _repository;

        public readonly IMapper _mapper;

        public ProductController(IAsyncProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var items = _repository.GetAllProducts().Result;

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(items));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(string id)
        {
            var item = _repository.GetProduct(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductReadDto>(item.Result));
        }

        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto product)
        {
            product.CreatedDateTime = DateTime.UtcNow;

            var productModel = _mapper.Map<Product>(product);

            _repository.CreateProduct(productModel);

            var readDto = _mapper.Map<ProductReadDto>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(string id, ProductUpdateDto product)
        {
            var modelToUpdate = _repository.GetProduct(id).Result;

            if (modelToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(product, modelToUpdate);

            _repository.UpdateProduct(modelToUpdate);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchProduct(string id, JsonPatchDocument<ProductUpdateDto> patchDocument)
        {
            var productFromRepo = _repository.GetProduct(id).Result;

            if (productFromRepo == null)
            {
                return NotFound();
            }

            var productToPatch = _mapper.Map<ProductUpdateDto>(productFromRepo);

            patchDocument.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(productToPatch, productFromRepo);

            _repository.UpdateProduct(productFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(string id)
        {
            var modelToDelete = _repository.GetProduct(id).Result;

            if (modelToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(modelToDelete);

            return NoContent();
        }
    }
}
