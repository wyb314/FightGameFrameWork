using StateMachine.Core;
using StateMachine.Entities;
using StateMachine.AnimationExtends;

namespace StateMachine.States.BaseStates
{
    public class AnimatedState<T> : State<T> where T : AnimationEntity
    {

        protected ISyncer syncer;


        public string m_aniName = string.Empty;



        public override void Execute(T entity)
        {
            //动画同步
            if(this.syncer != null)
            {
                this.syncer.Sync();
            }

        }


        /// <summary>
        /// 状态是否退出
        /// </summary>
        protected bool m_exit = false;

        public override void Exit(T entity)
        {
            this.m_exit = true;
        }


    }
}
