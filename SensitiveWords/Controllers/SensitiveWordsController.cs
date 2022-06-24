using Microsoft.AspNetCore.Mvc;

namespace SensitiveWords.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensitiveWordsController : ControllerBase
    {

        private readonly IWordMasker _wordMasker;

        public SensitiveWordsController(IWordMasker wordMasker)
        {
            _wordMasker = wordMasker;
        }



        [HttpPost(Name = "Post")]
        public async Task<string> Post(string message)
        {
            return await _wordMasker.Mask(message);
        }
    }
}