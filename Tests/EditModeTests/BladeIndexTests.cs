using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ComplexNumbers;
using MatrixMath;
using Clifford.Algebra;


public class BladeIndexTests
{
    public int n;
    public int index;


    /*
     Example: n =1

    basis   grade 

      1       0    10

      1       1    11
     
   
   
example n = 2

basis   grade    (index)

1       0    100 (0)

2       1    110 101   (1,2)

1       2    111 (3)







    example n = 3

basis grade 

1       0    1000  (0)

3       1    1100  1010  1001   (1,2,3)

3       2    1110  1101  1011     (4,5,6)

1       3    1111 (7)




     example n = 4

            basis   grade 

            1       0    10000                                

            4       1    11000  10100 10010  10001 

            6       2    11100  11010 11001 10110 10101 10011
                          12     1 3   1  4   23    2  4   34

            4       3    11110  11101 11011 10111

            1       4    11111


*/



    [Test]
    public void BladeIndexBasisTest()
    {
    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(0,2)[0], 1 );
    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(0, 2)[1], 0);
    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(0, 2)[2], 0);
    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(1, 2)[0], 1);
    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(1, 2)[1], 1);
        //Debug.Log(BladeIndex.BasisFromIndex(1, 2)[0]);
        //Debug.Log(BladeIndex.BasisFromIndex(1, 2)[1]);
        //Debug.Log(BladeIndex.BasisFromIndex(1, 2)[2]);

    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(1, 2)[2], 0);

        Assert.AreEqual(Blade.GradeFromIndex(0, 3), 0);
        Assert.AreEqual(Blade.GradeFromIndex(1, 3), 1);
        Assert.AreEqual(Blade.GradeFromIndex(2, 3), 1);
        Assert.AreEqual(Blade.GradeFromIndex(3, 3), 1);
        Assert.AreEqual(Blade.GradeFromIndex(4, 3), 2);
        Assert.AreEqual(Blade.GradeFromIndex(5, 3), 2);
        Assert.AreEqual(Blade.GradeFromIndex(6, 3), 2);
        Assert.AreEqual(Blade.GradeFromIndex(7, 3), 3);



        Assert.AreEqual(Blade.GradeFromIndex(0, 4), 0);
        Assert.AreEqual(Blade.GradeFromIndex(1, 4), 1);
        Assert.AreEqual(Blade.GradeFromIndex(2, 4), 1);
        Assert.AreEqual(Blade.GradeFromIndex(3, 4), 1);
        Assert.AreEqual(Blade.GradeFromIndex(4, 4), 1);
        Assert.AreEqual(Blade.GradeFromIndex(5, 4), 2);
        Assert.AreEqual(Blade.GradeFromIndex(6, 4), 2);
        Assert.AreEqual(Blade.GradeFromIndex(7, 4), 2);
        Assert.AreEqual(Blade.GradeFromIndex(8, 4), 2);
        Assert.AreEqual(Blade.GradeFromIndex(9, 4), 2);
        Assert.AreEqual(Blade.GradeFromIndex(10, 4), 2);
        Assert.AreEqual(Blade.GradeFromIndex(11, 4), 3);
        Assert.AreEqual(Blade.GradeFromIndex(12, 4), 3);
        Assert.AreEqual(Blade.GradeFromIndex(13, 4), 3);
        Assert.AreEqual(Blade.GradeFromIndex(14, 4), 3);
        Assert.AreEqual(Blade.GradeFromIndex(15, 4), 4);



        //Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(0, 3)[0], 1);

        //Debug.Log(BladeIndex.BasisFromIndex(0, 3)[0]);
        //Debug.Log(BladeIndex.BasisFromIndex(0, 3)[1]);
        //Debug.Log(BladeIndex.BasisFromIndex(0, 3)[2]);
        //Debug.Log(BladeIndex.BasisFromIndex(0, 3)[3]);

        //Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(1, 3)[0], 1);
        //for(int i =1; i<n; i++)
        //{
        //    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(1, 3)[i], 1);

        //}
        //Debug.Log(BladeIndex.BasisFromIndex(1, 3)[0]);
        //Debug.Log(BladeIndex.BasisFromIndex(1, 3)[1]);
        //Debug.Log(BladeIndex.BasisFromIndex(1, 3)[2]);
        //Debug.Log(BladeIndex.BasisFromIndex(1, 3)[3]);
        Assert.AreEqual(BladeIndex.BasisFromIndex(1, 3)[1], 1);
        //Debug.Log(BladeIndex.BasisFromIndex(2, 3)[0]);
        //Debug.Log(BladeIndex.BasisFromIndex(2, 3)[1]);
        //Debug.Log(BladeIndex.BasisFromIndex(2, 3)[2]);
        //Debug.Log(BladeIndex.BasisFromIndex(2, 3)[3]);

        //Debug.Log(BladeIndex.BasisFromIndex(3, 3)[0]);
        //Debug.Log(BladeIndex.BasisFromIndex(3, 3)[1]);
        //Debug.Log(BladeIndex.BasisFromIndex(3, 3)[2]);
        //Debug.Log(BladeIndex.BasisFromIndex(3, 3)[3]);

        //Debug.Log(BladeIndex.BasisString(BladeIndex.BasisFromIndex(3, 3)));

        Debug.Log(BladeIndex.BasisString(BladeIndex.BasisFromIndex(4, 3)));
        Assert.AreEqual(BladeIndex.IndexFromBasis("1110"), 4);
        Assert.AreEqual(BladeIndex.IndexFromBasis("1101"), 5);
        Assert.AreEqual(BladeIndex.IndexFromBasis("1011"), 6);
        Assert.AreEqual(BladeIndex.IndexFromBasis("1111"), 7);

        //Assert.AreEqual(BladeIndex.BasisFromIndex(1, 3)[1], 1);

        Assert.AreEqual(BladeIndex.IndexFromBasis("10000"), 0);
        Assert.AreEqual(BladeIndex.BasisFromIndex(1, 4)[1], 1);
        Assert.AreEqual(BladeIndex.BasisFromIndex(2, 4)[2], 1);

        //11010

        //Assert.AreEqual(Blade.GradeFromIndex(6,4), 2);

        //Debug.Log(BladeIndex.BasisString(BladeIndex.BasisFromIndex(5, 4)));

        //Debug.Log(BladeIndex.BasisFromIndex(6, 4)[0]);
        //Debug.Log(BladeIndex.BasisFromIndex(6, 4)[1]);
        //Debug.Log(BladeIndex.BasisFromIndex(6, 4)[2]);
        //Debug.Log(BladeIndex.BasisFromIndex(6, 4)[3]);
        //Debug.Log(BladeIndex.BasisFromIndex(6, 4)[4]);
        //Debug.Log(BladeIndex.BasisString(BladeIndex.BasisFromIndex(6, 4)));


        //Debug.Log("0 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(0, 4)));
        //Debug.Log("1 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(1, 4)));
        //Debug.Log("2 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(2, 4)));
        //Debug.Log("3 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(3, 4)));
        //Debug.Log("4 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(4, 4)));
        //Debug.Log("5 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(5, 4)));
        //Debug.Log("6:" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(6, 4)));
        //Debug.Log("7 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(7, 4)));
        //Debug.Log("8 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(8, 4)));
        //Debug.Log("9 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(9, 4)));
        //Debug.Log("10 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(10, 4)));
        //Debug.Log("11 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(11, 4)));
        //Debug.Log("12 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(12, 4)));
        //Debug.Log("13 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(13, 4)));
        //Debug.Log("14 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(14, 4)));
        //Debug.Log("15 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(15, 4)));


        Debug.Log("0 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(0, 5)));
        Debug.Log("1 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(1, 5)));
        Debug.Log("2 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(2, 5)));
        Debug.Log("3 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(3, 5)));
        Debug.Log("4 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(4, 5)));
        Debug.Log("5 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(5, 5)));
        Debug.Log("6:" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(6, 5)));
        Debug.Log("7 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(7, 5)));
        Debug.Log("8 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(8, 5)));
        Debug.Log("9 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(9, 5)));
        Debug.Log("10 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(10, 5)));
        Debug.Log("11 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(11, 5)));
        Debug.Log("12 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(12, 5)));
        Debug.Log("13 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(13, 5)));
        Debug.Log("14 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(14, 5)));
        Debug.Log("15 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(15, 5)));


        Debug.Log("16 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(16, 5)));
        Debug.Log("17 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(17, 5)));
        Debug.Log("18 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(18, 5)));
        Debug.Log("19 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(19, 5)));
        Debug.Log("20 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(20, 5)));
        Debug.Log("21 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(21, 5)));
        Debug.Log("22:" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(22, 5)));
        Debug.Log("23 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(23, 5)));
        Debug.Log("24 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(24, 5)));
        Debug.Log("25 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(25, 5)));
        Debug.Log("26 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(26, 5)));
        Debug.Log("27 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(27, 5)));
        Debug.Log("28 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(28, 5)));
        Debug.Log("29 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(29, 5)));
        Debug.Log("30 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(30, 5)));
        Debug.Log("31 :" + BladeIndex.BasisString(BladeIndex.BasisFromIndex(31, 5)));

        Assert.AreEqual(BladeIndex.IndexFromBasis("11010"), 6);

        //110101

        Assert.AreEqual(BladeIndex.IndexFromBasis("110101"), 20);
        //for (int i = 1; i < n-1; i++)
        //{
        //    Assert.AreEqual(Clifford.Algebra.BladeIndex.BasisFromIndex(1, 3)[i +1], 0);

        //}


    }



}
