using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Helpers;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Subscriptions;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Services;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private ISubscriptionService _subscriptionService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public SubscriptionController(ISubscriptionService subscriptionService, IMapper mapper, IOptions<AppSettings> appSettinga)
        {
            _mapper = mapper;
            _subscriptionService = subscriptionService;
            _appSettings = appSettinga.Value;
        }
        
        [HttpPost]
        public IActionResult AddNewsPaper([FromBody]SubSaveModel model)
        {
            var subscription = _mapper.Map<Subscription>(model);

            try
            {
                _subscriptionService.Create(subscription);
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
            var subscriptions = _subscriptionService.GetAll();
            var model = _mapper.Map<IList<SubscriptionModel>>(subscriptions);
            return Ok();
        }

        [HttpGet("{subid}")]
        public IActionResult GetById(int subid)
        {
            var subscription = _subscriptionService.GetById(subid);
            var model = _mapper.Map<SubscriptionModel>(subscription);
            return Ok(model);
        }

        [HttpPut("{subid}")]
        public IActionResult Update(int subid, [FromBody] SubSaveModel model)
        {
            var subscription = _mapper.Map<Subscription>(model);
            subscription.SubId = subid;

            try
            {
                _subscriptionService.Update(subscription);
                return Ok();
            }
            catch (AppException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpDelete("{subid}")]
        public IActionResult Delete(int subid)
        {
            _subscriptionService.Delete(subid);
            return Ok();
        }
    }
}