using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KalendColors
{
    [CreateAssetMenu(menuName = "Kalend/Color Object")]
    public class ColorObject : ScriptableObject
    {
        public string colorName = "color name";

        public Color color;

        public bool useHex;

        public string hexCode = "000000";

        private int _maxHCLength = 6;

        public Kolor4 kolor4;

        private bool _kolorSet;


#if UNITY_EDITOR
    

        private void OnValidate()
        {
            if (colorName == "color name" || colorName == "")
            {

                colorName = this.name;
            }
             
            if (useHex)
            {
                if (hexCode.Length < 6)
                {
                    Debug.LogWarning("Input needs a string with a length of at least 6");

                    useHex = false;
                }
                

                if (hexCode.Length > _maxHCLength)
                {

                    hexCode = hexCode.Substring(0, _maxHCLength);
                }


                color = ColorsFromHex.ColorFromHex(hexCode);

           


            }

            else
            {
                hexCode = ColorUtility.ToHtmlStringRGBA(color);

            }


            SetKolor4();


        }



#endif

    

       public void OnEnable()
       {


            if (!_kolorSet)
            {
                SetKolor4();
                PrintKolor();

            }
        

       }


        public void SetKolor4()
        {

            kolor4 = new Kolor4(color.r, color.g, color.b, color.a);

            _kolorSet = true;

            PrintKolor();

        }

        public void PrintKolor()
        {

            Debug.Log(colorName + "<color=red> Kolor4 r = </color>" + kolor4.r);
            Debug.Log(colorName + "<color=green> Kolor4 g = </color>" + kolor4.g);
            Debug.Log(colorName + "<color=blue> Kolor4 b = </color>" + kolor4.b);

        }


    }


 }



