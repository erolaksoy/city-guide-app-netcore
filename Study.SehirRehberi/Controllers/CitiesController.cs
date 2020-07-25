using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.Dto.Concrete.CityDtos;
using Study.SehirRehberi.Entitiy.Concrete;

namespace Study.SehirRehberi.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]

    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        public CitiesController(ICityService cityService, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CityListDto>>(await _cityService.GetListAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(_mapper.Map<CityDetailDto>(await _cityService.GetCityWithPhotosById(id)));

        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityAddDto cityAddDto)
        {
            await _cityService.InsertAsync(_mapper.Map<City>(cityAddDto));
            return Created("", cityAddDto);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPhotosByCityId(int id)
        {
            return Ok(await _photoService.GetPhotosByCityId(id));
        }


    }
}
