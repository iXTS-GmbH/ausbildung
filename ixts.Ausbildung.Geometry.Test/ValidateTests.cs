using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    //[TestFixture]
    //class ValidateTests
    //{


    //    [TestCase("202040203040", false)]
    //    [TestCase("20/20;40/20;30/40;",true)]
    //    public void CheckPointStringFormatTest(string pointstring, Boolean expected)
    //    {
    //        var actual = ValidateFormat.CheckPointStringFormat(pointstring);
    //        Assert.AreEqual(expected,actual);

    //    }

    //    [TestCaseSource("CheckPointCountTestSource")]
    //    public void CheckPointCountTest(String type, Boolean expected)
    //    {
    //        var points = new [] {new Point(20,20),new Point(40,20),new Point(30,40)};
    //        var actual = ValidateFormat.CheckPointCount(points, type);
    //        Assert.AreEqual(expected,actual);
    //    }

    //    public static readonly object[] CheckPointCountTestSource =
    //        {
    //            new object[]{"Triangle",true},
    //            new object[]{"Quadliteral",false}
    //        };

    //    [TestCase(true,"1234")]//Zahl
    //    [TestCase(false,"12CD")]//Zahl und Buchstabe(Groß)
    //    [TestCase(false,"12cd")]//Zahl und Buchstabe(Klein)
    //    [TestCase(false,"ABCD")]//Buchstaben(Groß)
    //    [TestCase(false,"abcd")]//Buchstaben(Klein)
    //    public void LetterCheckTest(Boolean expected, string teststring)
    //    {
    //        var actual = ValidateFormat.LetterCheck(teststring);
    //        Assert.AreEqual(expected,actual);
    //    }
    //}
}
