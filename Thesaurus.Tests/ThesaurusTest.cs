using System.Collections.Generic;
using CodeTest;
using NUnit.Framework;
using System;


namespace Code.Tests;

public class Tests
{

    IThesaurus thesaurus = new Thesaurus();
    [SetUp]
    public void Setup()
    {
        thesaurus = new Thesaurus();
    }

    [Test]
    public void TestGetWords()
    {

        Assert.NotNull(thesaurus.GetWords());
    }

    [Test]
    public void TestAddSynonymsEmptyList()
    {
        var words = new List<string>();
        thesaurus.AddSynonyms(words);
    }

    [Test]
    public void TestAddSynonymsList()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
    }

    [Test]
    public void TestGetSynonyms_withOneSetOfWords()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        IEnumerable<string> synonyms = thesaurus.GetSynonyms("run");
        var returnSynonyms = new List<string>() { "run", "walk", "crawl" };
        Assert.AreEqual(returnSynonyms, synonyms);
    }

    [Test]
    public void TestGetSynonyms_withOneSetOfWordsButNotFirstWord()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        IEnumerable<string> synonyms = thesaurus.GetSynonyms("crawl");
        var returnSynonyms = new List<string>() { "run", "walk", "crawl" };
        Assert.AreEqual(returnSynonyms, synonyms);
    }

    [Test]
    public void TestGetSynonyms_ForWordMeainingDiffrentThings()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        words = new List<string>() { "run", "jump", "sprint" };
        thesaurus.AddSynonyms(words);
        IEnumerable<string> synonyms = thesaurus.GetSynonyms("run");
        var returnSynonyms = new List<string>() { "run", "walk", "crawl", "run", "jump", "sprint" };
        Assert.AreEqual(returnSynonyms, synonyms);
    }


    [Test]
    public void TestGetSynonyms_withThreeSetOfWords()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        words = new List<string>() { "drive", "fly", "dig" };
        thesaurus.AddSynonyms(words);
        IEnumerable<string> synonyms = thesaurus.GetSynonyms("run");
        var returnSynonyms = new List<string>() { "run", "walk", "crawl" };
        Assert.AreEqual(returnSynonyms, synonyms);
        synonyms = thesaurus.GetSynonyms("drive");
        returnSynonyms = new List<string>() { "drive", "fly", "dig" };

        synonyms = thesaurus.GetSynonyms("fly");
        returnSynonyms = new List<string>() { "drive", "fly", "dig" };
    }

    [Test]
    public void TestGetSynonyms_whereWordDontExsist()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        IEnumerable<string> synonyms = thesaurus.GetSynonyms("fly");

        var returnSynonyms = new List<string>() { };

        Assert.AreEqual(returnSynonyms, synonyms);


    }


    [Test]
    public void TestAddSynonymsListAndGetWordsBack()
    {
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        var returnWords = thesaurus.GetWords();
        Assert.AreEqual(words, returnWords, "Words sent in and return words not the same");
    }


    [Test]
    public void TestAddSynonymsx2ListAndGetWordsBack()
    {
        var totalList = new List<string> { "run", "walk", "crawl", "drive", "fly", "dig" };
        var words = new List<string>() { "run", "walk", "crawl" };
        thesaurus.AddSynonyms(words);
        words = new List<string>() { "drive", "fly", "dig" };
        thesaurus.AddSynonyms(words);
        var returnWords = thesaurus.GetWords();
        Assert.AreEqual(totalList, returnWords, "Words sent in and return words not the same");

    }


}