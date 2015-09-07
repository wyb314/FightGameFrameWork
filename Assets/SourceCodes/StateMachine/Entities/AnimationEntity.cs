/* ==========================================================================
 * .NET版本  ： 4.0.30319.18408
 * 计算机名  ： WYB314
 * 创建者    ： wuyuanbing
 * 创建日期  ： 2015/8/9 14:20:56
========================================================================== */

using System.Collections.Generic;
using StateMachine.AnimationExtends;

namespace StateMachine.Entities
{
    public class AnimationEntity : MovingEntity
    {

        protected Animation2D m_pAnimation2D;

        public Animation2D animation2D 
        {
            get { return this.m_pAnimation2D; }
        }


        public virtual void CrossFade(int stateNameHash, float transitionDuration, int layer, float normalizedTime) 
        {
        }

        public virtual void CrossFade(string stateName, float transitionDuration, int layer, float normalizedTime) 
        {
        
        }

    }
}
