

namespace StateMachine.Core
{
    public struct Telegram
    {

        public int Sender;


        public int Receiver;


        public int MsgType;


        public float DispatchTime;


        public System.Object ExtraInfo;


        public Telegram(float time,
                        int sender,
                        int receiver,
                        int msg_type,
                        System.Object info) 
        {
            this.DispatchTime = time;

            this.Sender = sender;

            this.Receiver = receiver;

            this.MsgType = msg_type;

            this.ExtraInfo = info;
        }

        /// <summary>
        /// 消息之间的最小间隔
        /// </summary>
        public const float SmallestDelay = 0.25f;

        //public static bool operator ==(Telegram t1 , Telegram t2)
        //{
        //    return (Math.Abs(t1.DispatchTime - t2.DispatchTime) < SmallestDelay) &&
        //        (t1.Sender == t2.Sender)&&
        //        (t1.Receiver == t2.Receiver)&&
        //        (t1.MsgType == t2.MsgType);
        //}

        //public static bool operator !=(Telegram t1, Telegram t2)
        //{
        //    return (Math.Abs(t1.DispatchTime - t2.DispatchTime) >= SmallestDelay) ||
        //        (t1.Sender != t2.Sender) ||
        //        (t1.Receiver != t2.Receiver) ||
        //        (t1.MsgType != t2.MsgType);
        //}

        public static bool operator <(Telegram t1 , Telegram t2)
        {
            if (t1.DispatchTime == t2.DispatchTime)
            {
                return false;
            }
            else
            {
                return t1.DispatchTime < t2.DispatchTime;
            }
        }

        public static bool operator >(Telegram t1, Telegram t2)
        {
            if (t1.DispatchTime == t2.DispatchTime)
            {
                return false;
            }
            else
            {
                return t1.DispatchTime > t2.DispatchTime;
            }
        }

    }
}
