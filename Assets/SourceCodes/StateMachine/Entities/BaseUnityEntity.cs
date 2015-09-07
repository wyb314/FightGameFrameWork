/* ==========================================================================
 * .NET版本  ： 4.0.30319.18408
 * 计算机名  ： WYB314
 * 创建者    ： wuyuanbing
 * 创建日期  ： 2015/8/9 1:10:52
========================================================================== */

using UnityEngine;

namespace StateMachine.Entities
{

    public class BaseUnityEntity : AnimationEntity
    {
        #region fields and properties

        /// <summary>
        /// 实体Transform
        /// </summary>
        protected Transform m_pTran;

        public Transform tran
        {
            get { return this.m_pTran; }
        }

        /// <summary>
        /// 实体Animator组件
        /// </summary>
        protected Animator m_pAnimator;

        public Animator animator
        {
            get { return this.m_pAnimator; }
        }

        /// <summary>
        /// 实体角色控制器
        /// </summary>
        protected CharacterController m_cr;

        public CharacterController cr 
        {
            get { return this.m_cr; }
        }

        #endregion

    }
}
