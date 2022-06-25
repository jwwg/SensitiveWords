using Microsoft.AspNetCore.Mvc;

namespace SensitiveWords.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensitiveMessageController : ControllerBase
    {

        private readonly IWordMasker _wordMasker;

        public SensitiveMessageController(IWordMasker wordMasker)
        {
            _wordMasker = wordMasker;
        }


        /// <summary>
        /// Masks out all sensitive words in the provided message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost(Name = "PostSensitiveMessage")]
        public async Task<string> Post([FromBody] string message)
        {
            return await _wordMasker.Mask(message);
        }
    }
}