using System;

namespace Utils
{
    public struct Vector2D : IEquatable<Vector2D>
    {

        #region fields and properties

        private float m_x;
        public float x
        {
            set
            {
                if (!float.IsNaN(value))
                {
                    this.m_x = value;
                }
                else
                {
                    throw new System.Exception("The value that you specific the m_x is NaN!");
                }
            }
            get
            {
                return this.m_x;
            }
        }


        private float m_y;
        public float y
        {
            set
            {
                if (!float.IsNaN(value))
                {
                    this.m_y = value;
                }
                else
                {
                    throw new System.Exception("The value that you specific the m_y is NaN!");
                }
            }
            get
            {
                return this.m_y;
            }
        }

        /// <summary>
        /// 返回一个零向量
        /// </summary>
        public static Vector2D Zero
        {
            get { return new Vector2D(); }
        }

        #endregion

        #region constructors

        public Vector2D(float x, float y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        #endregion

        #region instance methods

        /// <summary>
        /// 自身置0
        /// </summary>
        public void ZeroSelf() 
        {
            this.m_x = 0;
            this.m_y = 0;
        }

        /// <summary>
        /// 该向量是否可看作零向量
        /// </summary>
        /// <returns></returns>
        public bool isZero() 
        {
            return Math.Abs(m_x * m_x + m_y * m_y) < float.Epsilon;
        }
        
        /// <summary>
        /// 向量的长度
        /// </summary>
        /// <returns></returns>
        public float Length() 
        {
            return (float)Math.Sqrt(LengthSq());
        }

        /// <summary>
        /// 向量长度的平方
        /// </summary>
        /// <returns></returns>
        public float LengthSq() 
        {
            return m_x * m_x + m_y * m_y;
        }

        /// <summary>
        /// 规范化一个2D向量
        /// </summary>
        public void Normalize() 
        {
            float length = this.Length();

            if(length > float.Epsilon)
            {
                this.m_x /= length;
                this.m_y /= length;
            }
            else
            {
                throw new System.InvalidOperationException("The vector2d you want to normalize is zero vector!");
            }
        }

        

        /// <summary>
        /// 向量点乘
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float Dot(Vector2D v)
        {
            return m_x * v.m_x + m_y * v.m_y;
        }

        public enum RelativeRotationEnum 
        {
            clockwise = 1,//顺时针
            anticlockwise = -1,//逆时针
        }

        /// <summary>
        /// 给定的向量v是相对于当前向量的方向,左手系下
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public RelativeRotationEnum Sign(Vector2D v) 
        {
            if (m_y * v.m_x > m_x * v.m_y)//这里并不是一般意义上的逆时针，而是
                //为了同旋转矩阵统一起来，
            {
                return RelativeRotationEnum.anticlockwise; 
            }
            else 
            {
                return RelativeRotationEnum.clockwise;
            }
        }

        /// <summary>
        /// 返回一个当前向量的法向量
        /// </summary>
        /// <returns></returns>
        public Vector2D Perp() 
        {
            return new Vector2D(-m_y,m_x);
        }

        /// <summary>
        /// 规定当前向量的长度在max返回以内
        /// </summary>
        /// <param name="max"></param>
        public void Truncate(float max) 
        {
            if(this.Length() > max)
            {
                this.Normalize();

                this = this * max;
            }
        }

        /// <summary>
        /// 求两个向量的几何距离，暂时还不知道应用的方向
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float Distance(Vector2D v)
        {
            
            return (float)Math.Sqrt(DistanceSq(v));
        }

        public float DistanceSq(Vector2D v)
        {
            float ySeparation = m_y - v.m_y;
            float xSeparation = m_x - v.m_x;

            return ySeparation * ySeparation + xSeparation * xSeparation;
        }

        /// <summary>
        /// 给定一个方向单位向量v，求当前向量相对于此向量
        /// 的反射向量
        /// </summary>
        /// <param name="v"></param>
        public void Reflect(Vector2D v) 
        {
            this = 2.0f * this.Dot(v) * v.GetReverse();
        }

        /// <summary>
        /// 得到当前向量的反向向量
        /// </summary>
        /// <returns></returns>
        public Vector2D GetReverse() 
        {
            return new Vector2D(-m_x,-m_y);
        }

        #endregion

        #region operators

        public static bool operator == (Vector2D v0 , Vector2D v1)
        {
            return v0.m_x == v1.m_x && v0.m_y == v1.m_y;
        }

        public static bool operator !=(Vector2D v0, Vector2D v1)
        {
            return v0.m_x != v1.m_x || v0.m_y != v1.m_y;
        }

        public static Vector2D operator *(float lhs,Vector2D v0)
        {
            return new Vector2D(v0.m_x * lhs,v0.m_y * lhs);
        }

        public static Vector2D operator *(Vector2D v0,float lhs)
        {
            return new Vector2D(v0.m_x * lhs, v0.m_y * lhs);
        }

        public static Vector2D operator -(Vector2D v0, Vector2D v1) 
        {
            return new Vector2D(v0.m_x - v1.m_x , v0.m_y - v1.m_y);
        }

        public static Vector2D operator +(Vector2D v0, Vector2D v1) 
        {
            return new Vector2D(v0.m_x + v1.m_x,v0.m_y + v1.m_y);
        }

        public static Vector2D operator /(Vector2D v0,float val)
        {
            return new Vector2D(v0.m_x/val,v0.m_y/val);
        }

        public static Vector2D operator -(Vector2D v)
        {
            return new Vector2D(-v.m_x,-v.m_y);
        }

        #endregion

        #region static Methods

        /// <summary>
        /// 两点之间的连线（posFirst,posSecond）向量相对于向量facingFirst
        /// 的夹角是否在fov/2范围内，这可以用于计算怪物的视野
        /// </summary>
        /// <param name="posFirst"></param>
        /// <param name="facingFirst"></param>
        /// <param name="posSecond"></param>
        /// <param name="fov"></param>
        /// <returns></returns>
        public static bool isSecondInFOVOfFirst(Vector2D posFirst,Vector2D facingFirst,Vector2D posSecond,float fov) 
        {
            Vector2D toTarget = Vec2DNormalize(posSecond - posFirst);

            return facingFirst.Dot(toTarget) > Math.Cos(fov/2);
        }

        public static float Vec2DDistance(Vector2D v0, Vector2D v1)
        {
            return (float)Math.Sqrt(Vec2DDistanceSq(v0, v1));
        }


        public static float Vec2DDistanceSq(Vector2D v0, Vector2D v1)
        {
            float ySeparation = v1.m_y - v0.m_y;
            float xSeparation = v1.m_x - v0.m_x;

            return xSeparation * xSeparation + ySeparation * ySeparation;
        }

        public static float Vec2DLength(Vector2D v)
        {
            return (float)Math.Sqrt(Vec2DLengthSq(v));
        }

        public static float Vec2DLengthSq(Vector2D v)
        {
            return v.m_x * v.m_x + v.m_y * v.m_y;
        }

        /// <summary>
        /// 规范化给定的向量
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2D Vec2DNormalize(Vector2D v)
        {
            float length = v.Length();

            if (length > float.Epsilon)
            {
                v.m_x /= length;
                v.m_y /= length;
            }

            return v;
        }

        #endregion

        #region overrides

        public bool Equals(Vector2D other)
        {
            return (other.m_x == this.m_x && other.m_y == this.m_y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2D)
            {
                Vector2D temp = (Vector2D)obj;
                if (temp.x == this.m_x && temp.y == this.m_y)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return m_x.GetHashCode()^m_y.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.m_x.ToString("f4"), this.m_y.ToString("f4"));
        }

        #endregion
    }
}
