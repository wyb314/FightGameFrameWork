using StateMachine.Core;
using StateMachine.Entities;
using Utils;

namespace StateMachine.States.BaseStates
{
    public class AnimationStateCanEarlyInterrupt<T> : AnimationPlayOnceCompletedState<T> where T : AnimationEntity
    {

        #region fields and properties

        protected float m_fCanInterruptThreshouldTime;

        #endregion


        #region instance methods

        public override void Enter(T entity)
        {
            this.m_fCanInterruptThreshouldTime = GetInterruptThreshouldTime();

            base.Enter(entity);
        }

        /// <summary>
        /// 得到可以打断该动画的临界时间
        /// </summary>
        public virtual float GetInterruptThreshouldTime ()
        {
            return 0;
        }

        #endregion

    }
}
