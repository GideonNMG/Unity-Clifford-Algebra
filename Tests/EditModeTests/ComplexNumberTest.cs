using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ComplexNumbers;

public class ComplexNumberTest
{
    public float a;
    public float b;

    // A Test behaves as an ordinary method
    [Test]
    public void ComplexNumberTestSimplePasses()
    {
        Assert.AreEqual(ComplexNumber.ImaginaryOne * ComplexNumber.ImaginaryOne, new ComplexNumber(-1,0));
        Assert.AreEqual(ComplexNumber._i * ComplexNumber._i, new ComplexNumber(-1, 0));
        Assert.AreEqual((ComplexNumber.ImaginaryOne * ComplexNumber.ImaginaryOne).real, -1);


        //Tests with random numbers:
        a = Random.Range(1, 10);
        b = Random.Range(1, 10);

        ComplexNumber z = new ComplexNumber(a, b);

        Assert.AreEqual(z + ComplexNumber.Conjugate(z), new ComplexNumber(2 * a, 0));

        Assert.AreEqual(z - ComplexNumber.Conjugate(z), new ComplexNumber(0, 2*b));

        Assert.AreEqual((z * ComplexNumber.Conjugate(z)).imaginary, 0);

        Assert.AreEqual((z * ComplexNumber.Conjugate(z)).real, ComplexNumber.SquareLength(z));



        //Tests with ComplexNumber.Arg and ComplexNumber.ArgDegrees.

        Assert.AreEqual(ComplexNumber.Arg(ComplexNumber._i), Mathf.PI / 2);

        Assert.AreEqual(ComplexNumber.Arg(- ComplexNumber._i), -Mathf.PI / 2);

        Assert.AreEqual(ComplexNumber.Arg(new ComplexNumber(-1,0)), Mathf.PI);

        Assert.AreEqual(ComplexNumber.ArgDegrees(ComplexNumber._i), 90f);



        //Tests with negation

        Assert.AreEqual(z - new ComplexNumber(0, b), new ComplexNumber(a,0));
        Assert.AreEqual((z - new ComplexNumber(0, b)).imaginary, 0);
        Assert.AreEqual(z - z, new ComplexNumber(0, 0));

    }

}
