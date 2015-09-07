using System;
using System.Collections.Generic;

namespace StateMachine.Core
{
    public class State<T>
    {
        /// <summary>
        /// 持有该状态的实体对象
        /// </summary>
        public T Target;

        /// <summary>
        /// 进入该状态时调用，该状态会在实体进入该状态时调用1次
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Enter(T entity) { }

        /// <summary>
        /// 处在该状态下，实体会在每个循自动环调用一次该方法
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Execute(T entity) {}

        /// <summary>
        /// 退出该状态时调用
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Exit(T entity) { }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="telegram"></param>
        /// <returns></returns>
        public virtual bool OnMessage(T entity , Telegram telegram){return false;}
    }
}
