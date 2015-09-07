/* ==========================================================================
 * .NET版本  ： 4.0.30319.18408
 * 计算机名  ： WYB314
 * 创建者    ： wuyuanbing
 * 创建日期  ： 2015/8/9 14:38:24
========================================================================== */


using System.Collections.Generic;

namespace StateMachine.AnimationExtends
{
    public class AnimationState2D
    {

        #region instance fields and properties

        private Animation2DClip m_clip;



        #endregion


        #region constructors


        #endregion


        #region instance methods

        public float GetClipLength() 
        {
            return this.m_clip.length;
        }

        #endregion


    }
}
