using UnityEngine;
using Utils;

namespace StateMachine.AnimationExtends
{
    public class Animation2DClip : ScriptableObject
    {

        #region constant fields

        /// <summary>
        /// 动画帧率
        /// </summary>
        public const int FRAME_RATE = 30;

        #endregion


        #region instance fields and properties
        
        /// <summary>
        /// 动画片段Bip01关键帧数据
        /// </summary>
        private KeyFrame2D[] m_frameDatas;


        public KeyFrame2D[] frameDatas
        {
            set 
            {
                this.m_frameDatas = value;

                this.m_frameCount = this.m_frameDatas.Length;
            }

            get 
            {
                return this.m_frameDatas;
            }
        }

        /// <summary>
        /// 动画数据的关键帧个数
        /// </summary>
        private int m_frameCount = 0;

        public int frameCount 
        {
            get { return this.m_frameCount; }
        }

        /// <summary>
        /// 该动画时间长
        /// </summary>
        public float length 
        {
            get 
            {
                return this.m_frameDatas[this.m_frameCount - 1].time;
            }
        }

        /// <summary>
        /// 最后一帧数据
        /// </summary>
        public KeyFrame2D lastFrameData 
        {
            get 
            {
                return this.m_frameDatas[this.m_frameCount - 1];
            }
        }

        #endregion


        #region instance methods


        private struct KeyFrame2DCache
        {
            public int lowerFrame;

            public float beginTime;

            public float endTime;

        }

        private KeyFrame2DCache mTrackValueCache;

        /// <summary>
        /// 插值帧数据
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public KeyFrame2D Interpolate(float time) 
        {
            int lowerFrame = 0;

            if (time >= this.mTrackValueCache.beginTime && time < this.mTrackValueCache.endTime)
            {
                lowerFrame = this.mTrackValueCache.lowerFrame;

                float ratio = (time - this.mTrackValueCache.beginTime) / (this.mTrackValueCache.endTime - this.mTrackValueCache.beginTime);

                return this.LinearInterpolate(lowerFrame, lowerFrame + 1, ratio,time);
            }
            else
            {
                int nCount = this.m_frameCount;
                int temp = 0;

                while (nCount > 0)
                {
                    temp = nCount >> 1;

                    if (time > this.m_frameDatas[lowerFrame + temp].time)
                    {
                        lowerFrame += temp + 1;

                        nCount -= temp + 1;

                    }
                    else
                    {
                        nCount = temp;
                    }
                }

                if (lowerFrame != 0)
                {
                    lowerFrame -= 1;
                }

                if (lowerFrame == this.m_frameCount - 1)
                {
                    lowerFrame -= 1;
                }


                this.mTrackValueCache.lowerFrame = lowerFrame;
                
                float beginTime =  this.m_frameDatas[lowerFrame].time;
                this.mTrackValueCache.beginTime =beginTime;

                float endTime = this.m_frameDatas[lowerFrame + 1].time;
                this.mTrackValueCache.endTime = endTime;

                float ratio = (time - beginTime)/(endTime - beginTime);

                return this.LinearInterpolate(lowerFrame,lowerFrame + 1,ratio ,time);

            }
        }


        public KeyFrame2D LinearInterpolate(int startIdx , int endIdx , float ratio , float time)
        {
            KeyFrame2D startFrame = this.m_frameDatas[startIdx];

            KeyFrame2D endFrame = this.m_frameDatas[endIdx];

            float posX = startFrame.posX + (endFrame.posX - startFrame.posX) * ratio;
            float posZ = startFrame.posZ + (endFrame.posZ - startFrame.posZ) * ratio;

            float rotY = startFrame.rotY + MathUtils.DeltaAngle(startFrame.rotY, endFrame.rotY);

            return new KeyFrame2D(time,posX,posZ,rotY);
        }




        #endregion


    }
}
