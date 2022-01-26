namespace ProductAPI.Controllers
{
    using AutoMapper;
    using ProductAPI.Data;
    using ProductAPI.Dtos;
    using ProductAPI.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.JsonPatch;

    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class SqlProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public readonly IMapper _mapper;

        public SqlProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var items = _repository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(items));
        }

        [HttpGet("{id}", Name = "GetSqlProductById")]
        public ActionResult<ProductReadDto> GetSqlProductById(int id)
        {
            var item = _repository.GetProduct(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductReadDto>(item));
        }

        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto product)
        {
            product.CreatedDateTime = DateTime.UtcNow;

            var productModel = _mapper.Map<SqlProduct>(product);

            _repository.CreateProduct(productModel);

            _repository.SaveChanges();

            var readDto = _mapper.Map<ProductReadDto>(productModel);

            return CreatedAtRoute(nameof(GetSqlProductById), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto product)
        {
            var modelToUpdate = _repository.GetProduct(id);

            if(modelToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(product, modelToUpdate);

            _repository.UpdateProduct(modelToUpdate);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchProduct(int id, JsonPatchDocument<ProductUpdateDto> patchDocument)
        {
            var productFromRepo = _repository.GetProduct(id);

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

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var modelToDelete = _repository.GetProduct(id);

            if(modelToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(modelToDelete);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
