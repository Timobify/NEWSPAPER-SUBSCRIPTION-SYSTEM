using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Helpers;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.NewsPapers;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Services;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsPaperController : ControllerBase
    {
        private INewsPaperService _newsPaperService;

        private IMapper _mapper;

        private readonly AppSettings _appSettings;

        public NewsPaperController(INewsPaperService newsPaperService,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _newsPaperService = newsPaperService;
            _appSettings = appSettings.Value;
        }
        [HttpPost]
        public IActionResult AddNewsPaper([FromBody]NewsPaperSaveModel model)
        {
            var newsPaper = _mapper.Map<NewsPaper>(model);

            try
            {
                _newsPaperService.Create(newsPaper);
                return Ok();
            }
            catch (AppException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var newsPaper = _newsPaperService.GetAll();
            var model = _mapper.Map<IList<NewsPaperSaveModel>>(newsPaper);
            return Ok();
        }
        
        [HttpGet("{newsid}")]
        public IActionResult GetById(int newsid)
        {
            var newsPaper = _newsPaperService.GetById(newsid);
            var model = _mapper.Map<NewsPaperModel>(newsPaper);
            return Ok(model);
        }
        
        [HttpPut("{newsid}")]
        public IActionResult Update(int newsid, [FromBody] NewsPaperSaveModel model)
        {
            var newsPaper = _mapper.Map<NewsPaper>(model);
            newsPaper.NewsId = newsid;

            try
            {
                _newsPaperService.Update(newsPaper);
                return Ok();
            }
            catch (AppException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }
        
        [HttpDelete("{newsid}")]
        public IActionResult Delete(int newsid)
        {
            _newsPaperService.Delete(newsid);
            return Ok();
        }
    }
}