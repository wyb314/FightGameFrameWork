using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public sealed class MathUtils
    {

        #region static const fields



        #endregion



        #region static methods

        public static float DeltaAngle(float current, float target)
        {
            float num = Repeat(target - current, 360f);
            if (num > 180f)
            {
                num -= 360f;
            }
            return num;
        }


        public static float Repeat(float t, float length)
        {
            return (t - (Floor(t / length) * length));
        }

        public static float Floor(float f)
        {
            return (float)Math.Floor((double)f);
        }

        #endregion






    }
}
