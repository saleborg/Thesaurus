using System.Collections.Generic;
using CodeTest;
using NUnit.Framework;



namespace Code.Tests;

public class WordTest
{

    [Test]
    public void TestGetAllSynonyms()
    {
        Word word = new Word();
        word.key = "run";

        var list1 = new List<string>() { "run", "walk", "crawl" };
        var list2 = new List<string>() { "swim", "walk", "fly" };

        word.synonymsWord.Add(list1);
        word.synonymsWord.Add(list2);

        IList<string> retunList = word.getAllSysnonyms();

        list1.AddRange(list2);

        Assert.AreEqual(retunList, list1);



    }

}