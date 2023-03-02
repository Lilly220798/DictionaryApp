using Microsoft.AspNetCore.Mvc;

namespace DictionaryApp.Controllers
{
        [Route("[controller]")]
        [ApiController]
        
    public class DictionaryController : ControllerBase
        {
        private MyDictionaries dictionaries = new MyDictionaries();

        [HttpGet("{word}/{language1}/{language2}")]
        public IActionResult GetTranslation(string word, string language1, string language2)
        {
            string translated = dictionaries.Translate(language1, language2, word); 
            if(translated == "") return BadRequest($"There is no translation available");
            
            return Ok($"{translated}");
        }
       
    }
    }



