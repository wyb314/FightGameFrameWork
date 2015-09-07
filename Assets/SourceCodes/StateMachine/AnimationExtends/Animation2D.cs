/* ==========================================================================
 * .NET版本  ： 4.0.30319.18408
 * 计算机名  ： WYB314
 * 创建者    ： wuyuanbing
 * 创建日期  ： 2015/8/9 14:35:48
========================================================================== */


using System.Collections.Generic;

namespace StateMachine.AnimationExtends
{
    public class Animation2D
    {

        private Dictionary<string,AnimationState2D> m_states;


        public  AnimationState2D this[string key]
        {
            get 
            {
                if(!this.m_states.ContainsKey(key))
                {
                    throw new KeyNotFoundException("The key that value is : "+key+" is not found in the m_states!");
                }

                return this.m_states[key];
            }
        }


    }
}
