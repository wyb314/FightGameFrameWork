/* ==========================================================================
 * .NET版本  ： 4.0.30319.18408
 * 计算机名  ： WYB314
 * 创建者    ： wuyuanbing
 * 创建日期  ： 2015/8/9 13:57:41
========================================================================== */
using Utils;

namespace StateMachine.Entities
{
    public class MovingEntity : BaseGameEntity
    {
        #region fields and properties

        ///由于主角位置在Unity里面要考虑碰撞，则暂时不参加入此类型

        /// <summary>
        /// 智能体朝向
        /// </summary>
        protected Vector2D m_Heading;

        public Vector2D Heading 
        {
            set { this.m_Heading = value; }
            get { return this.m_Heading; }
        }

        /// <summary>
        /// 智能体质量
        /// </summary>
        protected float m_dMass;

        public float Mass 
        {
            set { this.m_dMass = value; }
            get { return this.m_dMass; }
        }

        /// <summary>
        /// 智能体最大速度
        /// </summary>
        protected float m_fMaxSpeed;
        public float MaxSpeed 
        {
            set { this.m_fMaxSpeed = value; }
            get { return this.m_fMaxSpeed; }
        }


        /// <summary>
        /// 智能体被施加的力的最大大小
        /// </summary>
        protected float m_fMaxForce = 4f;
        public float MaxForce
        {
            set { this.m_fMaxForce = value; }
            get { return this.m_fMaxForce; }
        }


        /// <summary>
        /// 智能体可以旋转的最大速率，单位是弧度每秒
        /// </summary>
        protected float m_fMaxTurnRate;
        public float MaxTurnRate
        {
            set { this.m_fMaxTurnRate = value; }
            get { return this.m_fMaxTurnRate; }
        }

        //暂时不纳入操控行为

        #endregion
        

    }
}
