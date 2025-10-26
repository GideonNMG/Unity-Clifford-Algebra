using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ComplexNumbers;

public class FactorialTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void FactorialTestSimplePasses()
    {
        Assert.AreEqual(StaticFunctions.Factorial(0), 1);
        Assert.AreEqual(StaticFunctions.Factorial(1), 1);
        Assert.AreEqual(StaticFunctions.Factorial(2), 2);
        Assert.AreEqual(StaticFunctions.Factorial(3), 6);
        Assert.AreEqual(StaticFunctions.Factorial(4), 24);
    }

   
}
