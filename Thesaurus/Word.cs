namespace CodeTest;

using System.Linq;
public class Word
{
    public string key { get; set; }
    public List<IList<string>> synonymsWord { get; set; }

    public Word()
    {
        synonymsWord = new List<IList<string>>();
    }
    public IList<string> getAllSysnonyms()
    {
        var completeList = new List<string>();

        synonymsWord.ForEach(x => completeList.AddRange(x));

        return completeList;
    }

}