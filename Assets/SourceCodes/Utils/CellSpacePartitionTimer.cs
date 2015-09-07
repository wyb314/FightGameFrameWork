/* ==========================================================================
 * .NET版本  ： 4.0.30319.18408
 * 计算机名  ： WYB314
 * 创建者    ： wuyuanbing
 * 创建日期  ： 2015/8/9 1:20:58
========================================================================== */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Timer
    {
        private System.Action<System.Object> m_handler;

        public Action<System.Object> Handler { get { return this.m_handler; } }


        private System.Object m_arg;

        private float m_launchTime;

        public float LaunchTime
        {
            get { return this.m_launchTime; }
        }

        public Timer(float lanunchTime, Action<System.Object> action)
        {
            this.m_launchTime = lanunchTime;
            this.m_handler = action;
        }

        public Timer(float lanunchTime, Action<System.Object> action, System.Object arg)
            : this(lanunchTime, action)
        {
            this.m_arg = arg;
        }

        public void Launch()
        {
            this.m_handler(this.m_arg);
        }

    }


    public class TimersCell
    {
        public List<Timer> timers = new List<Timer>();


        public void AddTimer(System.Action<System.Object> handler, float lanunchTime, System.Object arg = null)
        {
            this.timers.Add(new Timer(lanunchTime, handler, arg));

            //排序
            this.timers.Sort(CompareByTimeStamp);
        }

        public void RemoveTimer(Timer timer)
        {
            this.timers.Remove(timer);
        }

        public void Clear() { this.timers.Clear(); }


        public int CompareByTimeStamp(Timer timer0 , Timer timer1) 
        {
            if (timer0.LaunchTime > timer1.LaunchTime) 
            {
                return 1; 
            }
            else if(timer0.LaunchTime < timer1.LaunchTime)
            {
                return -1;
            }
            
            return 0;
        }

    }


    public class CellSpacePartitionTimer : Singleton<CellSpacePartitionTimer>
    {
        private const int cellCount = 1000;

        private const float lengthPerCell = 1f / (float)cellCount;//定时器精度

        public List<TimersCell> m_Cells;


        private CellSpacePartitionTimer()
        {
            if (this.m_Cells == null)
            {
                this.m_Cells = new List<TimersCell>(cellCount);

                for (int i = 0; i < cellCount; i++)
                {
                    TimersCell cell = new TimersCell();

                    this.m_Cells.Add(cell);
                }
            }

            this.m_lastLaunchTime = Time.time;
        }

        private float m_lastLaunchTime = 0;

        public void LaunchTimer()
        {
            PositionFlag flag = this.GetLaunchPosition(this.m_lastLaunchTime, Time.time);

            List<int> idxs = new List<int>();

            if (flag.all)
            {
                for (int i = 0; i < cellCount; i++)
                {
                    idxs.Add(i);
                }
            }
            else
            {
                if (!flag.isReverse)
                {
                    for (int i = flag.strIdx; i <= flag.endIdx; i++)
                    {
                        idxs.Add(i);
                    }
                }
                else
                {
                    for (int i = 0; i <= flag.endIdx; i++)
                    {
                        idxs.Add(i);
                    }

                    for (int i = flag.strIdx; i < cellCount; i++)
                    {
                        idxs.Add(i);
                    }
                }

            }

            if (idxs.Count > 0)
            {
                int idxCount = idxs.Count;

                for (int i = 0; i < idxCount; i++)
                {
                    int curIdx = idxs[i];

                    TimersCell cell = this.m_Cells[curIdx];

                    List<Timer> willRemoveList = new List<Timer>();

                    int _Count = cell.timers.Count;

                    if (cell.timers != null && _Count > 0)
                    {
                        for (int j = 0; j < _Count; j++)
                        {
                            Timer curTimer = cell.timers[j];

                            if (curTimer.LaunchTime <= Time.time)
                            {
                                curTimer.Launch();

                                willRemoveList.Add(curTimer);
                            }
                        }
                    }

                    _Count = willRemoveList.Count;
                    if (_Count > 0)
                    {
                        for (int j = 0; j < _Count; j++)
                        {
                            Timer willRemoveTimer = willRemoveList[j];
                            cell.RemoveTimer(willRemoveTimer);
                        }
                    }
                }
            }

            this.m_lastLaunchTime = Time.time;

        }


        public struct PositionFlag
        {
            public int strIdx;

            public int endIdx;

            public bool all;

            public bool isReverse;

            public PositionFlag(int strIdx, int endIdx, bool all, bool isReverse)
            {
                this.strIdx = strIdx;
                this.endIdx = endIdx;
                this.all = false;
                this.isReverse = isReverse;
            }
        }

        public PositionFlag GetLaunchPosition(float fromTime, float toTime)
        {
            PositionFlag flag = new PositionFlag();

            float deltaTime = toTime - fromTime;

            if (deltaTime >= 1f)
            {
                flag.all = true;
            }
            else
            {
                int strIdx = GetIndexByTime(fromTime);//

                int endIdx = GetIndexByTime(toTime);

                if (endIdx < cellCount - 1)
                {
                    endIdx++;
                }

                if (strIdx < 0)
                {
                    strIdx = 0;
                }

                if (strIdx >= endIdx)
                {
                    flag.isReverse = true;
                }

                flag.strIdx = strIdx;

                flag.endIdx = endIdx;
            }

            return flag;
        }


        public void Clear()
        {
            for (int i = 0; i < cellCount; i++)
            {
                this.m_Cells[i].Clear();
            }
        }

        public void AddTimer(System.Action<System.Object> handler, float elapsedSecond, System.Object arg = null)
        {
            if (elapsedSecond < float.Epsilon) { handler(arg); return; }
            if (elapsedSecond > 0)
            {
                float launchTime = Time.time + elapsedSecond;

                int index = GetIndexByTime(launchTime);

                this.m_Cells[index].AddTimer(handler, launchTime, arg);
            }
        }


        private int GetIndexByTime(float launchTime)
        {
            float value = launchTime - (int)launchTime;

            int index = 0;

            index = (int)(value * cellCount);

            if (index >= cellCount)//此Index在通常情况下不会达到cellCount
            {
                index = cellCount - 1;
            }
            return index;
        }

    }
}
