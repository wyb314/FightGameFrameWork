using StateMachine.Core;
using StateMachine.Entities;
using Utils;

namespace StateMachine.States.BaseStates
{
    public class AnimationPlayOnceCompletedState<T> : AnimatedState<T> where T : AnimationEntity
    {

        protected float m_animationScale = 0.99f;


        public override void Enter(T entity)
        {
            this.ProcessStatePlayOnceCompleted();

        }

        /// <summary>
        /// 处理当前状态播放完成
        /// </summary>
        private void ProcessStatePlayOnceCompleted() 
        {
            if (!string.IsNullOrEmpty(this.m_aniName))
            {
                CellSpacePartitionTimer.Instance.AddTimer(StateOverTime, CalculateAnimationStopTime());
            }
            else 
            {
                //抛出异常
            }
        }

        private float CalculateAnimationStopTime() 
        {
            return this.Target.animation2D[this.m_aniName].GetClipLength() * this.m_animationScale;
        }


        /// <summary>
        /// 该状态已超时
        /// </summary>
        /// <param name="arg"></param>
        private void StateOverTime(System.Object arg) 
        {
            if (!this.m_exit)//该状态没在播放完该动画之前切换到其他状态
            {
                OnAnimationPlayCompleted(arg);
            }
        }

        /// <summary>
        /// 该状态完成时回调
        /// </summary>
        /// <param name="arg"></param>
        public virtual void OnAnimationPlayCompleted(System.Object arg) { }



    }
}
