using System;
using System.Collections.Generic;

namespace Utils
{
    public class Matrix3x3
    {

        private struct Matrix3x3Data
        {
            #region 基础属性
            /// <summary>
            /// 3x3矩阵的9个元素
            /// </summary>
            public float _11, _12, _13, _21, _22, _23, _31, _32, _33;

            #endregion

            public Matrix3x3Data(float _11,
                float _12,
                float _13,
                float _21,
                float _22,
                float _23,
                float _31,
                float _32,
                float _33)
            {
                this._11 = _11;
                this._12 = _12;
                this._13 = _13;
                this._21 = _21;
                this._22 = _22;
                this._23 = _23;
                this._31 = _31;
                this._32 = _32;
                this._33 = _33;
            }
        }

        private Matrix3x3Data m_Data;

        private void MatrixMultiply(Matrix3x3Data mIn) 
        {
            Matrix3x3Data data = new Matrix3x3Data();

            data._11 = this.m_Data._11 * mIn._11 +
                this.m_Data._12 * mIn._21 +
                this.m_Data._13 * mIn._31;
            data._12 = this.m_Data._11 * mIn._12 +
                this.m_Data._12 * mIn._22 +
                this.m_Data._13 * mIn._32;
            data._13 = this.m_Data._11 * mIn._13 +
                this.m_Data._12 * mIn._23 +
                this.m_Data._13 * mIn._33;
            data._21 = this.m_Data._21 * mIn._11 +
                this.m_Data._22 * mIn._21 +
                this.m_Data._23 * mIn._31;
            data._22 = this.m_Data._21 * mIn._12 +
                this.m_Data._22 * mIn._22 +
                this.m_Data._23 * mIn._32;
            data._23 = this.m_Data._21 * mIn._13 +
                this.m_Data._22 * mIn._23 +
                this.m_Data._23 * mIn._33;
            data._31 = this.m_Data._31 * mIn._11 +
                this.m_Data._32 * mIn._21 +
                this.m_Data._33 * mIn._31;
            data._32 = this.m_Data._31 * mIn._12 +
                this.m_Data._32 * mIn._22 +
                this.m_Data._33 * mIn._32;
            data._33 = this.m_Data._31 * mIn._13 +
                this.m_Data._32 * mIn._23 +
                this.m_Data._33 * mIn._33;

            this.m_Data = data;
        }
        
        public Matrix3x3() 
        {
            this.Identity();
        }

        public void Identity() 
        {
            this.m_Data = new Matrix3x3Data(1,0,0,0,1,0,0,0,1);
        }


        public void Translate(float x , float y) 
        {
            Matrix3x3Data mat = new Matrix3x3Data(1,0,0,0,1,0,x,y,1);

            MatrixMultiply(mat);
        }

        /// <summary>
        /// 构造缩放矩阵
        /// </summary>
        /// <param name="xScale"></param>
        /// <param name="yScale"></param>
        public void Scale(float xScale , float yScale) 
        {
            Matrix3x3Data _data =new Matrix3x3Data(
                xScale,
                0,
                0,
                0,
                yScale,
                0,
                0,
                0,
                1);

            MatrixMultiply(_data);

        }

        /// <summary>
        /// 构造旋转矩阵，注意：
        /// 此矩阵类为行向量矩阵
        /// </summary>
        /// <param name="rotation">旋转的角度，
        /// 有正负之分，在此矩阵中，逆时针旋转的角度为正，
        /// 顺时针则相反
        /// </param>
        public void Rotate(float rotation)
        {
            float sin = (float)Math.Sin(rotation);
            float cos = (float)Math.Cos(rotation);

            Matrix3x3Data _data = new Matrix3x3Data(
                cos,sin,0,
                -sin,cos,0,
                0,0,1);
            MatrixMultiply(_data);
        }

        /// <summary>
        /// create a rotation matrix from a fwd and side
        /// 2D vector
        /// </summary>
        /// <param name="fwd"></param>
        /// <param name="side"></param>
        public void Rotate(Vector2D fwd , Vector2D side) 
        {
            Matrix3x3Data _data = new Matrix3x3Data(
                fwd.x,fwd.y,0,
                side.x,side.y,0,
                0,0,1);
            MatrixMultiply(_data);
        }

        /// <summary>
        /// 此矩阵用的是行向量
        /// </summary>
        /// <param name="points">点集</param>
        public void TransformVector2Ds(List<Vector2D> points) 
        {
            for (int i = 0; i < points.Count; i++)
            {
                Vector2D point = points[i];
                TransformVector2D(ref point);
                //float x = point.x * this.m_Data._11 +
                //    point.y * this.m_Data._21 +
                //    this.m_Data._31;

                //float y = point.x * this.m_Data._12 +
                //    point.y * this.m_Data._22 +
                //    this.m_Data._32;

                //points[i] = new Vector2D(x,y);
            }
        }

        public void TransformVector2D(ref Vector2D point) 
        {
            float x = point.x * this.m_Data._11 +
                point.y * this.m_Data._21 +
                this.m_Data._31;

            float y = point.x * this.m_Data._12 +
                point.y * this.m_Data._22 +
                this.m_Data._32;

            point.x = x;
            point.y = y;
        }

    }

}