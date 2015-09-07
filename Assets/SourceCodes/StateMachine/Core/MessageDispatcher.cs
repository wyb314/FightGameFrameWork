using System;
using System.Collections.Generic;

namespace StateMachine.Core
{
    public sealed class MessageDispatcher 
    {

        private MessageDispatcher m_Instance;
        public MessageDispatcher Instance
        {
            get 
            {
                if(this.m_Instance == null)
                {
                    this.m_Instance = new MessageDispatcher();
                }
                return this.m_Instance;
            }
        }

        private Queue<Telegram> PriorityQ;

        private void Discharge() 
        {
            
        }


        public void DispatchDelayedMessages()
        {
        
        }

    }
}
