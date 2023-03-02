using Microsoft.OpenApi.Any;
using System.Collections.Generic;

namespace DictionaryApp
{

    public class MyDictionaries
    {
        private EnFrDictionary enFrDictionary = new EnFrDictionary();
        private FrDeDictionary frDeDictionary = new FrDeDictionary();
        private DeRoDictionary deRoDictionary = new DeRoDictionary();
        private List<CustomDictionary> languages = new List<CustomDictionary>();

        public MyDictionaries()
        {
            languages.Add(enFrDictionary);
            languages.Add(frDeDictionary);
            languages.Add(deRoDictionary);
        }

        public string Translate(string languageFrom, string languageTo, string word)
        {
            if(languageFrom == languageTo) { 
                return word;
            }

            string translatedWord = string.Empty;
            string wordToTranslate = word;
            List<CustomDictionary> languages = TranslationPath(languageFrom, languageTo);

            foreach (var item in languages)
            {
                translatedWord = item.Translate(wordToTranslate);
                wordToTranslate = translatedWord;
            }

            return translatedWord;
        }

        private List<CustomDictionary> TranslationPath(string languageFrom, string languageTo)
        {
            string from = languageFrom;
            string to = languageTo;
            List<CustomDictionary> path = new List<CustomDictionary>();

            foreach (var item in languages)
            {

                if (item.getLanguages().languageFrom == from)
                {
                    if (item.getLanguages().languageTo == to)
                    {
                        path.Add(item);

                        return path;
                    }
                    else
                    {
                        from = item.getLanguages().languageTo;
                    }
                    path.Add(item);

                }
                else
                    continue;
            }
            return path;
        }
    }

    public class EnFrDictionary : CustomDictionary
    {
        public DictionaryLanguages Languages = new DictionaryLanguages("en", "fr");
        public Dictionary<string, string> Words { get; set; } = new Dictionary<string, string>
        {
            { "apple", "pomme" },
            { "banana", "banane" },
            { "cherry", "cerise" }
        };

        public override string Translate(string word)
        {
            string translatedWord = string.Empty;
            if (Words.TryGetValue(word, out string frenchWord))
            {
                translatedWord = frenchWord;
            }
            return translatedWord;
        }
        public override DictionaryLanguages getLanguages()
        {
            return Languages;
        }
    }

    public class FrDeDictionary : CustomDictionary
    {
        public DictionaryLanguages Languages = new DictionaryLanguages("fr", "de");
        public Dictionary<string, string> Words { get; set; } = new Dictionary<string, string>
        {
            { "pomme", "apfel" },
            { "banane", "banane" },
            { "cerise", "kirsche" }
        };

        public override string Translate(string word)
        {
            string translatedWord = string.Empty;
            if (Words.TryGetValue(word, out string germanWord))
            {
                translatedWord = germanWord;
            }
            return translatedWord;
        }
        public override DictionaryLanguages getLanguages()
        {
            return Languages;
        }
    }

    public class DeRoDictionary : CustomDictionary
    {
        public DictionaryLanguages Languages = new DictionaryLanguages("de", "ro");
        public Dictionary<string, string> Words { get; set; } = new Dictionary<string, string>
        {
            { "apfel", "mar" },
            { "banane", "banana" },
            { "kirsche", "cireasa" }
        };

        public override string Translate(string word)
        {
            string translatedWord = string.Empty;
            if (Words.TryGetValue(word, out string romanianWord))
            {
                translatedWord = romanianWord;
            }
            return translatedWord;
        }

        public override DictionaryLanguages getLanguages()
        {
            return Languages;
        }
    }

    public abstract class CustomDictionary
    {
        public abstract string Translate(string word);

        public abstract DictionaryLanguages getLanguages();

    }

    public class DictionaryLanguages 
    {
        public string languageTo;   
        public string languageFrom;
        public DictionaryLanguages( string languageFrom, string languageTo)
        {
            this.languageTo = languageTo;
            this.languageFrom = languageFrom;
        }


    }
 }

    



