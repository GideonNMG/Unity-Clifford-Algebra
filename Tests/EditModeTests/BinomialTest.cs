using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ComplexNumbers;

public class BinomialTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BinomialTestSimplePasses()
    {
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(1,1), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(1, 0), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(2, 2), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(3, 3), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(4, 0), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(4, 1), 4);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(4, 2), 6);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(4, 3), 4);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(4, 4), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(5, 0), 1);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(5, 1), 5);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(5, 2), 10);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(5, 3), 10);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(5, 4), 5);
        Assert.AreEqual(StaticFunctions.BinomialCoefficient(5, 5), 1);

    }

}
