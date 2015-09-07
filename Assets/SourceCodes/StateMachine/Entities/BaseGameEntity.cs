using StateMachine.Core;

namespace StateMachine.Entities
{
    public abstract class BaseGameEntity
    {

        #region fields and properties

        /// <summary>
        /// 实体ID
        /// </summary>
        protected int m_pID;

        public int ID 
        {
            set { this.m_pID = value; }
            get { return this.m_pID; }
        }

        /// <summary>
        /// 实体类型
        /// </summary>
        protected int m_EntityType;

        public int EntityType 
        {
            set { this.m_EntityType = value; }
            get { return this.m_EntityType; }
        }


        #endregion


        public virtual void Update(float time_elapsed) 
        {
        
        }

        public virtual bool HandMessage(Telegram msg)
        {
            return false;
        }

    }
}


