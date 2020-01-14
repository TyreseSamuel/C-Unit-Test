using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        //Static reference to the identity matrix
        public static Matrix4 Identity = new Matrix4();
        //Each value stored in the Matrix4
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        //Creates a Matrix4 equal to the identity matrix
        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        //Creates a Matrix4 with the specified values
        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }

        //Creates a copy of the specified Matrix4
        public Matrix4(Matrix4 matrix4)
        {
            m11 = matrix4.m11; m12 = matrix4.m12; m13 = matrix4.m13; m14 = matrix4.m14;
            m5 = matrix4.m5; m6 = matrix4.m6; m7 = matrix4.m7; m8 = matrix4.m8;
            m9 = matrix4.m9; m10 = matrix4.m10; m11 = matrix4.m11; m12 = matrix4.m12;
            m13 = matrix4.m13; m14 = matrix4.m14; m15 = matrix4.m15; m16 = matrix4.m16;
        }

        //Creates a Matrix4 with the specified values
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }

        //Creates a copy of the specified Matrix4
        public void Set(Matrix4 matrix4)
        {
            m11 = matrix4.m11; m12 = matrix4.m12; m13 = matrix4.m13; m14 = matrix4.m14;
            m5 = matrix4.m5; m6 = matrix4.m6; m7 = matrix4.m7; m8 = matrix4.m8;
            m9 = matrix4.m9; m10 = matrix4.m10; m11 = matrix4.m11; m12 = matrix4.m12;
            m13 = matrix4.m13; m14 = matrix4.m14; m15 = matrix4.m15; m16 = matrix4.m16;
        }

        //Set this Matrix4 to a scale matrix with the specified values
        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0; m14 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        //Set this Matrix4 to a scale matrix with the specified values
        public void SetScaled(Vector4 v)
        {
            m11 = v.x; m12 = 0; m13 = 0; m14 = 0;
            m5 = 0; m6 = v.y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = v.z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        //Scale this Matrix4 by the specified values
        public void Scale(float x, float y, float z)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        //Scale this Matrix4 by the specified Vector3's values
        public void Scale(Vector4 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(v);
            Set(this * m);
        }

        //Set this Matrix4 to a rotate matrix with the specified values
        public void SetRotateX(double radians)
        {
            Set(1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
                0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        //Rotate this Matrix4 with the specified values
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);
            Set(this * m);
        }

        //Set this Matrix4 to a rotate matrix with the specified values
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        //Rotate this Matrix4 with the specified values
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);
            Set(this * m);
        }

        //Set this Matrix4 to a rotate matrix with the specified values
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

        //Rotate this Matrix4 with the specified values
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);
            Set(this * m);
        }

        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            Set(z * y * x);
        }

        public void SetTranslation(float x, float y, float z)
        {
            m14 = x; m8 = y; m12 = z; m16 = 1;
        }

        public void Translate(float x, float y, float z)
        {
            m14 += x; m8 += y; m12 += z;
        }

        //Matrix4 * Matrix4
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m5 + lhs.m13 * rhs.m9 + lhs.m14 * rhs.m13,
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m6 + lhs.m13 * rhs.m10 + lhs.m14 * rhs.m14,
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m7 + lhs.m13 * rhs.m11 + lhs.m14 * rhs.m15,
                lhs.m11 * rhs.m14 + lhs.m12 * rhs.m8 + lhs.m13 * rhs.m12 + lhs.m14 * rhs.m16,

                lhs.m5 * rhs.m11 + lhs.m6 * rhs.m5 + lhs.m7 * rhs.m9 + lhs.m8 * rhs.m13,
                lhs.m5 * rhs.m12 + lhs.m6 * rhs.m6 + lhs.m7 * rhs.m10 + lhs.m8 * rhs.m14,
                lhs.m5 * rhs.m13 + lhs.m6 * rhs.m7 + lhs.m7 * rhs.m11 + lhs.m8 * rhs.m15,
                lhs.m5 * rhs.m14 + lhs.m6 * rhs.m8 + lhs.m7 * rhs.m12 + lhs.m8 * rhs.m16,

                lhs.m9 * rhs.m11 + lhs.m10 * rhs.m5 + lhs.m11 * rhs.m9 + lhs.m12 * rhs.m13,
                lhs.m9 * rhs.m12 + lhs.m10 * rhs.m6 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m14,
                lhs.m9 * rhs.m13 + lhs.m10 * rhs.m7 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m15,
                lhs.m9 * rhs.m14 + lhs.m12 * rhs.m7 + lhs.m12 * rhs.m11 + lhs.m12 * rhs.m16,

                lhs.m13 * rhs.m11 + lhs.m14 * rhs.m5 + lhs.m15 * rhs.m9 + lhs.m16 * rhs.m13,
                lhs.m13 * rhs.m12 + lhs.m14 * rhs.m6 + lhs.m15 * rhs.m10 + lhs.m16 * rhs.m14,
                lhs.m13 * rhs.m13 + lhs.m14 * rhs.m7 + lhs.m15 * rhs.m11 + lhs.m16 * rhs.m15,
                lhs.m13 * rhs.m14 + lhs.m16 * rhs.m7 + lhs.m16 * rhs.m11 + lhs.m16 * rhs.m16);
        }

        //Matrix4 * Vector4
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                lhs.m11 * rhs.x + lhs.m12 * rhs.y + lhs.m13 * rhs.z + lhs.m14 * rhs.w,
                lhs.m5 * rhs.x + lhs.m6 * rhs.y + lhs.m7 * rhs.z + lhs.m8 * rhs.w,
                lhs.m9 * rhs.x + lhs.m10 * rhs.y + lhs.m11 * rhs.z + lhs.m8 * rhs.w,
                lhs.m13 * rhs.x + lhs.m14 * rhs.y + lhs.m15 * rhs.z + lhs.m16 * rhs.w);
        }
    }
}
