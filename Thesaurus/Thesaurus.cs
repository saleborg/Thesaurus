using System.Collections;
using System.Collections.Generic;
namespace CodeTest;

public class Thesaurus : IThesaurus
{

    Dictionary<string, Word> thesaurus = new Dictionary<string, Word>();


    void IThesaurus.AddSynonyms(IEnumerable<string> synonyms)
    {
        if (synonyms != null && synonyms.Any())
        {
            foreach (string synonym in synonyms)
            {

                var synonymList = synonyms.ToList();
                if (thesaurus.ContainsKey(synonym))
                {
                    Word w = thesaurus[synonym];
                    w.synonymsWord.Add(synonymList);
                }
                else
                {
                    Word word = new Word()
                    {
                        key = synonym,

                    };
                    word.synonymsWord.Add(synonymList);
                    thesaurus.Add(word.key, word);
                }
            }
        }
    }

    IEnumerable<string> IThesaurus.GetSynonyms(string word)
    {

        if (thesaurus.ContainsKey(word))
        {
            Word returnsynonyms = thesaurus[word];

            return returnsynonyms.getAllSysnonyms();
        }
        return Enumerable.Empty<string>();

    }


    IEnumerable<string> IThesaurus.GetWords()
    {
        List<Word> listOfList = thesaurus.Values.ToList();
        var totalList = new List<string>();
        listOfList.ForEach(x => totalList.AddRange(x.getAllSysnonyms()));

        return totalList.Distinct().ToList();
    }
}
