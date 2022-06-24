using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensitiveWords.Model;

namespace SensitiveWords.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordManagementController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WordManagementController(DatabaseContext context)
        {
             _context = context;
        }

        /// <summary>
        /// Returns a list of all sensitive words.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _context.BadWords.Select(x => x.Word);
        }

        /// <summary>
        /// Adds a word to list of sensitive words. Returns an error if the word already exists.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpPost(Name = "PostWord")]
        public async Task<IActionResult> Post(string? word)
        {
            if (string.IsNullOrEmpty(word)) 
                return BadRequest();

            try
            {
                _context.BadWords.Add(new SensitiveWord(word));
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException)
            {
                return new ConflictResult();
            }
        }

        /// <summary>
        /// Delete a sensitive word from the list
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string? word)
        {
            if (string.IsNullOrEmpty(word))
                return BadRequest();

            var badWord = _context.BadWords.FirstOrDefault(x => x.Word == word);
            if (badWord == null)
                return NotFound();
            _context.BadWords.Remove(badWord);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}