
namespace StateMachine.Core
{
    public class StateMachine<T>
    {
        /// <summary>
        /// 实体持有的状态机实例 
        /// </summary>
        private T m_pOwner;

        /// <summary>
        /// 实体当前状态
        /// </summary>
        private State<T> m_pCurrentState;

        public State<T> CurrentState 
        {
            set { this.m_pCurrentState = value; }
            get { return this.m_pCurrentState; }
        }

        /// <summary>
        /// 实体上一次状态
        /// </summary>
        private State<T> m_pPreviousState;

        public State<T> PreviousState 
        {
            set { this.m_pPreviousState = value; }
            get { return this.m_pPreviousState; }
        }

        /// <summary>
        /// 实体全局状态
        /// </summary>
        private State<T> m_pGlobalState;

        public State<T> GlobalState 
        {
            set { this.m_pGlobalState = value; }
            get { return this.m_pGlobalState; }
        }


        public StateMachine(T owner) 
        {
            this.m_pOwner = owner;

            this.m_pCurrentState = null;

            this.m_pPreviousState = null;

            this.m_pGlobalState = null;
        }


        public void SetCurrentState(State<T> s) 
        {
            this.m_pCurrentState = s;

            this.m_pCurrentState.Target = this.m_pOwner;

            this.m_pCurrentState.Enter(this.m_pOwner);
        }


        public void SetGlobalState(State<T> s) 
        {
            this.m_pGlobalState = s;

            this.m_pGlobalState.Target = this.m_pOwner;

            this.m_pGlobalState.Enter(this.m_pOwner);
        }

        public void SetPreviousState(State<T> s) 
        {
            this.m_pPreviousState = s;
        }


        public void Update() 
        {
            if(this.m_pGlobalState != null)
            {
                this.m_pGlobalState.Execute(this.m_pOwner);
            }

            if(this.m_pCurrentState != null)
            {
                this.m_pCurrentState.Execute(this.m_pOwner);
            }
        }

        public bool HandleMessage(Telegram msg) 
        {
            if (this.m_pGlobalState != null && this.m_pGlobalState.OnMessage(this.m_pOwner, msg))
            {
                return true;
            }

            if(this.m_pCurrentState != null && this.m_pCurrentState.OnMessage(this.m_pOwner,msg))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 变换状态用
        /// </summary>
        /// <param name="pNewState"></param>
        public void ChangeState(State<T> pNewState)
        {
            this.m_pPreviousState = this.m_pCurrentState;

            this.m_pCurrentState.Exit(this.m_pOwner);

            this.m_pCurrentState = pNewState;

            this.m_pCurrentState.Target = this.m_pOwner;

            this.m_pCurrentState.Enter(this.m_pOwner);

        }

        /// <summary>
        /// 状态翻转用
        /// </summary>
        public void RevertToPreviousState() 
        {
            ChangeState(this.m_pPreviousState);
        }

    }
}


