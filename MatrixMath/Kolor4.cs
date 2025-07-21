using UnityEngine;

namespace KalendColor
{
    public struct Kolor4
    {
        [Range(0,1)]
        public float r;

        [Range(0, 1)]
        public float g;

        [Range(0, 1)]
        public float b;

        [Range(0, 1)]
        public float a;


        public float h;

        public float s;

        public float v;


        public float[] kolor;

        public float[] hsv;


        public Kolor4(float r, float g, float b, float a)
        {    
      
            this.r = r;

            this.g = g;

            this.b = b;

            this.a = a;

            Color.RGBToHSV(new Color(r, g, b, a), out h, out s, out v);

            this.kolor = new float[4] { r, g, b, a};

            this.hsv = new float[3] { h, s, v };

        }


        public Kolor4(float r, float g, float b)
        {

            this.r = r;

            this.g = g;

            this.b = b;

            this.a = 1f;

            Color.RGBToHSV(new Color(r, g, b, a), out h, out s, out v);

            this.kolor = new float[4] { r, g, b, a };

            this.hsv = new float[3] { h, s, v };

        }


        public Kolor4(Vector4 V)
        {

            this.r = V.x;

            this.g = V.y;

            this.b = V.z;

            this.a = V.w;

            Color.RGBToHSV(new Color(r, g, b, a), out h, out s, out v);

            this.kolor = new float[4] { r, g, b, a };

            this.hsv = new float[3] { h, s, v };

        }


        public Kolor4(Vector3 V)
        {

            this.r = V.x;

            this.g = V.y;

            this.b = V.z;

            this.a = 1f;

            Color.RGBToHSV(new Color(r, g, b, a), out h, out s, out v);

            this.kolor = new float[4] { r, g, b, a };

            this.hsv = new float[3] { h, s, v };

        }



        public Kolor4(float[] A)
        {
            int n = A.Length;

           
            this.r = A[0];

            this.g = A[1];

            this.b = A[2];

            if (n > 3)
            {

                this.a = A[3];
            }

            else
            {

                this.a = 1f;
            }

            Color.RGBToHSV(new Color(r, g, b, a), out h, out s, out v);

            this.kolor = new float[4] { r, g, b, a };

            this.hsv = new float[3] { h, s, v };

        }



        public Kolor4(float[] A, bool isHSV)
        {
            int n = A.Length;

            

            if(n==4 && isHSV)
            {

                this.h = A[0];

                this.s = A[1];

                this.v = A[2];

                this.hsv = A;

                Color color = Color.HSVToRGB(A[0], A[1], A[2]);

                this.r = color.r;

                this.g = color.g;

                this.b = color.b;

                this.a = 1;

                this.kolor = new float[4] { r, g, b, 1f };

           

            }

            else
            {
                this.r = A[0];

                this.g = A[1];

                this.b = A[2];

                if (n > 3)
                {

                    this.a = A[3];
                }

                else
                {

                    this.a = 1f;
                }

                Color.RGBToHSV(new Color(r, g, b, a), out h, out s, out v);

                this.kolor = new float[4] { r, g, b, a };

                this.hsv = new float[3] { h, s, v };

            }


        }



        public static Kolor4 Kolor4From32(Color32 c)
        {
            float[] k = new float[4];

            k[0] = Mathf.Clamp01((float)(c.r / 255f));

            k[1] = Mathf.Clamp01((float)(c.g / 255f));

            k[2] = Mathf.Clamp01((float)(c.b / 255f));

            k[3] = Mathf.Clamp01((float)(c.a / 255f));

            Kolor4 result = new Kolor4(k[0], k[1], k[2], k[3]);

            return result;

        }


        public static Kolor4 Kolor4FromColor(Color c)
        {
            float[] k = new float[4];

            k[0] = Mathf.Clamp01((float)(c.r ));

            k[1] = Mathf.Clamp01((float)(c.g ));

            k[2] = Mathf.Clamp01((float)(c.b ));

            k[3] = Mathf.Clamp01((float)(c.a ));

            Kolor4 result = new Kolor4(k[0], k[1], k[2], k[3]);

            return result;

        }


        public static Kolor4 Kolor4FromHSV(float H, float S, float V)
        {

            Color color = Color.HSVToRGB(H, S, V);

            

            float r = color.r;

            float g = color.g;

            float b = color.b;

            float a = color.a;

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }



        public static Color32 Kolor32(Kolor4 k)
        {
            int r = Mathf.FloorToInt(k.kolor[0] * 255f);

            int g = Mathf.FloorToInt(k.kolor[1] * 255f);

            int b = Mathf.FloorToInt(k.kolor[2] * 255f);

            int a = Mathf.FloorToInt(k.kolor[3] * 255f);

            Color32 result = new Color32((byte)r, (byte)g, (byte)b, (byte)a);

            return result;
        }


        public static Color Kolor(Kolor4 k)
        {
            Color result = new Color(k.kolor[0], k.kolor[1], k.kolor[2], k.kolor[3]);

            return result;

        }

   

        public static float[] ClampedArray4(float x, float y, float z, float w)
        {

            float[] result = new float[4];

            result[0] = Mathf.Clamp01(x);

            result[1] = Mathf.Clamp01(y);

            result[2] = Mathf.Clamp01(z);

            result[3] = Mathf.Clamp01(w);

            return result;
        }


        public static Kolor4 ClampedKolor4(float r, float g, float b, float a)
        {

            r = Mathf.Clamp01(r);

            g = Mathf.Clamp01(g);

            b = Mathf.Clamp01(b);

            a = Mathf.Clamp01(a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;
        }

        public static Kolor4 ClampedKolor4(float r, float g, float b)
        {

            r = Mathf.Clamp01(r);

            g = Mathf.Clamp01(g);

            b = Mathf.Clamp01(b);


            Kolor4 result = new Kolor4(r, g, b, 1);

            return result;
        }

        public static Kolor4 KolorFromVector4(Vector4 v)
        {
            float r = Mathf.Clamp01(v.x);
            float g = Mathf.Clamp01(v.y);
            float b = Mathf.Clamp01(v.z);
            float a = Mathf.Clamp01(v.w);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }

        public static Kolor4 KolorFromVector3(Vector3 v)
        {
            float r = Mathf.Clamp01(v.x);
            float g = Mathf.Clamp01(v.y);
            float b = Mathf.Clamp01(v.z);
          

            Kolor4 result = new Kolor4(r, g, b, 1f);

            return result;

        }


        public static Kolor4 Kolor4Addition(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Clamp01(x.r + y.r);
            float g = Mathf.Clamp01(x.g + y.g);
            float b = Mathf.Clamp01(x.b + y.b);
            float a = Mathf.Clamp01(x.a + y.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }

        public static Kolor4 Kolor4Addition(Kolor4 k, float f)
        {
            float r = Mathf.Clamp01(k.r + f);
            float g = Mathf.Clamp01(k.g + f);
            float b = Mathf.Clamp01(k.b + f);
            float a = Mathf.Clamp01(k.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 KolorAddInt(Kolor4 k, int i)
        {
            int j = Mathf.Clamp(i, 0, 255);

            float x = (float)j / 255f;

            float r = Mathf.Clamp01(k.r + x);
            float g = Mathf.Clamp01(k.g + x);
            float b = Mathf.Clamp01(k.b + x);
            float a = Mathf.Clamp01(k.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }



        public static Kolor4 Kolor4AddExp(Kolor4 k, float f)
        {

            float x = 1 - Mathf.Exp(-1 * Mathf.Abs(f));

            float r = Mathf.Clamp01(k.r + x);
            float g = Mathf.Clamp01(k.g + x);
            float b = Mathf.Clamp01(k.b + x);
            float a = Mathf.Clamp01(k.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }



        public static Kolor4 Kolor4Subtraction(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Clamp01(x.r - y.r);
            float g = Mathf.Clamp01(x.g - y.g);
            float b = Mathf.Clamp01(x.b - y.b);
            float a = Mathf.Min(x.a, y.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 Kolor4Mult(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Clamp01(x.r * y.r);
            float g = Mathf.Clamp01(x.g * y.g);
            float b = Mathf.Clamp01(x.b * y.b);
            float a = Mathf.Clamp01(x.a * y.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 Kolor4Mult(Kolor4 k, float f)
        {

            f = Mathf.Clamp01(f);

            float r = Mathf.Clamp01(f * k.r);
            float g = Mathf.Clamp01(f * k.g);
            float b = Mathf.Clamp01(f * k.b);
            float a = k.a;

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 Kolor4AlphaMult(Kolor4 k, float f)
        {

            f = Mathf.Clamp01(f);

            float a = Mathf.Clamp01(f* k.a);

            Kolor4 result = new Kolor4(k.r, k.g, k.b, a);

            return result;

        }


        public static Kolor4 Kolor4Min(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Min(x.r, y.r);
            float g = Mathf.Min(x.g, y.g);
            float b = Mathf.Min(x.b, y.b);
            float a = Mathf.Min(x.a, y.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 Kolor4Max(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Max(x.r, y.r);
            float g = Mathf.Max(x.g, y.g);
            float b = Mathf.Max(x.b, y.b);
            float a = Mathf.Max(x.a, y.a);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 Kolor4Pow(Kolor4 x, Kolor4 y)
        {

            float[] p = new float[4];

            float[] q = new float[4];

            p[0] = Mathf.Max(y.r, Mathf.Epsilon);

            p[1] = Mathf.Max(y.g, Mathf.Epsilon);

            p[2] = Mathf.Max(y.b, Mathf.Epsilon);

            p[3] = Mathf.Max(y.a, Mathf.Epsilon);


            q[0] = SmallExp(x.r, p[0], 2 * Mathf.Epsilon);

            q[1] = SmallExp(x.g, p[1], 2 * Mathf.Epsilon);

            q[2] = SmallExp(x.b, p[2], 2 * Mathf.Epsilon);

            q[3] = SmallExp(x.a, p[3], 2 * Mathf.Epsilon);


            float r = Mathf.Clamp01(q[0]);
            float g = Mathf.Clamp01(q[1]);
            float b = Mathf.Clamp01(q[2]);
            float a = Mathf.Clamp01(q[3]);

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static float SmallExp(float f, float g, float min)
        {
            float result;

            if (g < min)
            {
                result = 1f;
                
            }

            else
            {
                result = Mathf.Pow(f, g);

            }

            return result;
        }


        public static Kolor4 Kolor4AAv(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Clamp01((x.r + y.r)/2f);
            float g = Mathf.Clamp01((x.g + y.g)/2f);
            float b = Mathf.Clamp01((x.b + y.b)/2f);
            float a = Mathf.Clamp01((x.a + y.a))/2f;

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        public static Kolor4 KolorGAv(Kolor4 x, Kolor4 y)
        {
            float r = Mathf.Clamp01(Mathf.Sqrt(x.r * y.r));
            float g = Mathf.Clamp01(Mathf.Sqrt(x.g * y.g));
            float b = Mathf.Clamp01(Mathf.Sqrt(x.b * y.b));
            float a = Mathf.Clamp01(Mathf.Sqrt(x.a * y.a));

            Kolor4 result = new Kolor4(r, g, b, a);

            return result;

        }


        //Operator Overloads:
        public static Kolor4 operator +(Kolor4 operand) => operand;

       
        public static Kolor4 operator +(Kolor4 first, Kolor4 second)
        {
            Kolor4 result = Kolor4Addition(first, second);

            return result;

        }



        public static Kolor4 operator -(Kolor4 first, Kolor4 second)
        {

            Kolor4 result = Kolor4Subtraction(first, second);

            return result;
        }


        public static Kolor4 operator *(Kolor4 first, Kolor4 second)
        {
            Kolor4 result = Kolor4Mult(first, second);

            return result;

        }

        public static Kolor4 operator *(Kolor4 k, float x)
        {
            Kolor4 result = Kolor4Mult(k, x);

            return result;

        }


        public static Kolor4 operator *( float x, Kolor4 k)
        {
            Kolor4 result = Kolor4Mult(k, x);

            return result;

        }



        //Equality Override:
        public override bool Equals(object color)
        {
            if (color == null)
            {
                return false;
            }

            var z = (Kolor4)color;
            return (r == z.r && g == z.g && b == z.b && a == z.a);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public static bool Kolor4Equality(Kolor4 k1, Kolor4 k2)
        {
            if (k1.r == k2.r && k1.g == k2.g && k1.b ==k2.b && k1.a ==k2.a)
            {

                return true;
            }

            else
            {

                return false;
            }

        }


        public static bool operator ==(Kolor4 first, Kolor4 second)
        {
            return Kolor4Equality(first, second);

        }

        public static bool operator !=(Kolor4 first, Kolor4 second)
        {
            return !Kolor4Equality(first, second);


        }

    }


}

