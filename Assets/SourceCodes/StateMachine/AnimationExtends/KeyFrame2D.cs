

namespace StateMachine.AnimationExtends
{
    [System.Serializable]
    public struct KeyFrame2D
    {

        #region instance fields

        public float time;

        public float posX;

        public float posZ;

        public float rotY;


        #endregion

        #region constructors

        public KeyFrame2D(float time , float posX, float posZ, float yRot) 
        {
            this.time = time;

            this.posX = posX;
            this.posZ = posZ;

            this.rotY = yRot;
        }

        #endregion


        #region operators

        /// <summary>
        /// 重载加法操作符，可能在旋转上面没什么用处
        /// </summary>
        /// <param name="key0"></param>
        /// <param name="key1"></param>
        /// <returns></returns>
        public static KeyFrame2D operator +(KeyFrame2D key0 , KeyFrame2D key1)
        {
            return new KeyFrame2D(
                                            key0.posX+key1.posX,
                                            key0.posZ + key1.posZ,
                                            key0.rotY + key1.rotY
                                            ,0);

        }

        /// <summary>
        /// 由key1到key0之差，包括旋转差
        /// </summary>
        /// <param name="key0"></param>
        /// <param name="key1"></param>
        /// <returns></returns>
        public static KeyFrame2D operator -(KeyFrame2D key0, KeyFrame2D key1)
        {
            return new KeyFrame2D(
                                            key0.posX - key1.posZ,
                                            key0.posZ - key1.posZ,
                                            Utils.MathUtils.DeltaAngle(key0.rotY,key1.rotY)
                                            ,0);
        }




        #endregion


    }
}
