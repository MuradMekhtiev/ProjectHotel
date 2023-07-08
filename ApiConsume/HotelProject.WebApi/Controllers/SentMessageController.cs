using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentMessageController : ControllerBase
    {
        private readonly ISentMessageService _sentMessageService;

        public SentMessageController(ISentMessageService sentMessageService)
        {
            _sentMessageService = sentMessageService;
        }

        [HttpGet]
        public IActionResult SentMessageList()
        {
            var values = _sentMessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSentMessage(SentMessage sentMessage)
        {
            _sentMessageService.TInsert(sentMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSentMessage(int id)
        {
            var values = _sentMessageService.TGetByID(id);
            _sentMessageService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSentMessage(SentMessage sentMessage)
        {
            _sentMessageService.TUpdate(sentMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSentMessage(int id)
        {
            var value = _sentMessageService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("GetSentMessageCount")]
        public IActionResult GetSentMessageCount()
        {
            return Ok(_sentMessageService.TGetSentMessageCount());       
        }
    }
}
