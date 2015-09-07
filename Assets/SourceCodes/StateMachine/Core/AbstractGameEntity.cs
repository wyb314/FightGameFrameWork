using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace StateMachine.Core
{
    public class AbstractGameEntity
    {

        private int m_ID;

        public int ID 
        {
            get 
            {
                return this.m_ID;
            }
        }

        /// <summary>
        /// 实体的类型
        /// </summary>
        private int m_EntityType;
        public int EntityType 
        {
            get { return this.m_EntityType; }

            set { this.m_EntityType = value; }
        }


        private bool m_bTag;
        public bool TagFlag //是否被标记
        {
            get { return this.m_bTag; }
        }


        public static int NextID = 0;
        private int NextValidID
        {
            get 
            {
                return NextID++;
            }
        
        }

        //protected Vector2D m_vPos;

        //public Vector2D pos
        //{
        //    set 
        //    {
        //        this.m_vPos = value;
        //    }
        //    get 
        //    {
        //        return this.m_vPos;
        //    }
        //}

        //protected Vector2D m_vScale;

        //public Vector2D Scale 
        //{
        //    set 
        //    {
        //        this.m_fBoundingRadius *= Math.Max(value.x, value.y) / Math.Max(this.m_vScale.x, this.m_vScale.y);
        //        this.m_vScale = value;
        //    }
        //    get 
        //    {
        //        return this.m_vScale;
        //    }
        //}

        /// <summary>
        /// 实体包围半径
        /// </summary>
        protected float m_fBoundingRadius;

        public float BRadius 
        {
            set 
            {
                this.m_fBoundingRadius = value;
            }
            get 
            {
                return this.m_fBoundingRadius;
            }
        }


        public AbstractGameEntity() 
        {
            this.m_ID = NextValidID;

            this.m_fBoundingRadius = 0;

            //this.m_vPos = new Vector2D();

            //this.m_vScale = new Vector2D(1,1);

            this.m_EntityType = 1;

            this.m_bTag = false;
        }


        public AbstractGameEntity(int entity_type,float r) 
        {
            this.m_EntityType = entity_type;
            //this.m_vPos = pos;
            this.m_fBoundingRadius = r;
            this.m_bTag = false;
            this.m_ID = NextValidID;
            //this.m_vScale = new Vector2D(1,1);
        }

        public AbstractGameEntity(int entity_type,int ForceID) 
        {
            this.m_ID = ForceID;

            this.m_fBoundingRadius = 0;

            //this.m_vScale = new Vector2D(1,1);

            this.m_EntityType = entity_type;

            this.m_bTag = false;
        
        }


        public virtual void Update(float time_elapsed) 
        {
        
        }

        public virtual bool HandMessage(Telegram msg) 
        {
            return false;
        }


        public void Tag() 
        {
            this.m_bTag = true;
        }

        public void UnTag() 
        {
            this.m_bTag = false;
        }
    }
}
