using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.Dto.Concrete.PhotoDtos;
using Study.SehirRehberi.Entitiy.Concrete;
using Study.SehirRehberi.WebApi.StringInfo.CloudinaryInfo;

namespace Study.SehirRehberi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;
        private readonly Cloudinary _cloudinary;
        public PhotosController(IPhotoService photoService, IMapper mapper, ICityService cityService)
        {
            _cityService = cityService;
            _photoService = photoService;
            _mapper = mapper;


            Account cloduniaryAccount = new Account()
            {
                ApiKey = CloudinaryInfo.ApiKey,
                ApiSecret = CloudinaryInfo.ApiSecret,
                Cloud = CloudinaryInfo.CloudName
            };

            _cloudinary = new Cloudinary(cloduniaryAccount);
        }


        [HttpPost("{id}/[action]")]
        public async Task<IActionResult> AddPhotoForCity(int id, [FromBody] PhotoAddDto photoAddDto)
        {
            var currentCity = await _cityService.GetByIdAsync(id);
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (ModelState.IsValid)
            {
                if (currentCity == null) return BadRequest("Invalid City");
                //if (currentCity.UserId != currentUserId) return Unauthorized();

                if (photoAddDto.File != null)
                {
                    var file = photoAddDto.File;
                    var uploadResult = new ImageUploadResult();
                    using (var stream = file.OpenReadStream())
                    {
                        var imageUploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.FileName, stream),

                        };
                        uploadResult = _cloudinary.Upload(imageUploadParams);
                    }

                    photoAddDto.PublicId = uploadResult.PublicId;
                    photoAddDto.Url = uploadResult.Url.ToString();
                }

                await _photoService.InsertAsync(new Photo
                {
                    CityId = currentCity.Id,
                    IsMain = true,
                    Description = photoAddDto.Description,
                    PublicId = photoAddDto.PublicId,
                    Url = photoAddDto.Url

                });
                return Created("", photoAddDto);
            }
            return Unauthorized("error area");

        }
    }
}
