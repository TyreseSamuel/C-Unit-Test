using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {
        //Static reference to the identity matrix
        public static Matrix3 Identity = new Matrix3();
        //Each value stored in the Matrix3
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        //Creates a Matrix3 equal to the identity matrix
        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }

        //Creates a Matrix3 with the specified values
        public Matrix3(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3;
            this.m4 = m4; this.m5 = m5; this.m6 = m6;
            this.m7 = m7; this.m8 = m8; this.m9 = m9;
        }

        //Creates a copy of the specified Matrix3
        public Matrix3(Matrix3 matrix3)
        {
            m1 = matrix3.m1; m2 = matrix3.m2; m3 = matrix3.m3;
            m4 = matrix3.m4; m5 = matrix3.m5; m6 = matrix3.m6;
            m7 = matrix3.m7; m8 = matrix3.m8; m9 = matrix3.m9;
        }

        public override string ToString()
        {
            return
                "{[" + m1 + ", " + m2 + ", " + m3 + "]," +
                "[" + m4 + ", " + m5 + ", " + m6 + "]," +
                "[" + m7 + ", " + m8 + ", " + m9 + "]}";
        }

        //Sets this Matrix3 to the specified values
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3;
            this.m4 = m4; this.m5 = m5; this.m6 = m6;
            this.m7 = m7; this.m8 = m8; this.m9 = m9;
        }

        //Sets this Matrix3 to the values of the specified Matrix3
        public void Set(Matrix3 matrix3)
        {
            m1 = matrix3.m1; m2 = matrix3.m2; m3 = matrix3.m3;
            m4 = matrix3.m4; m5 = matrix3.m5; m6 = matrix3.m6;
            m7 = matrix3.m7; m8 = matrix3.m8; m9 = matrix3.m9;
        }

        //Returns the transpose of the Matrix3
        public Matrix3 GetTransposed()
        {
            return new Matrix3(m1, m4, m7, m2, m5, m8, m3, m6, m9);
        }

        //Set this Matrix3 to a scale matrix with the specified values
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }

        //Set this Matrix3 to a scale matrix with the specified Vector3's values
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = v.z;
        }

        //Scale this Matrix3 by the specified values
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        //Scale this Matrix3 by the specified Vector3's values
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v);
            Set(this * m);
        }

        //Set this Matrix3 to a rotate matrix with the specified values
        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians),
                0, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }

        //Rotate this Matrix3 with the specified values
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }

        //Set this Matrix3 to a rotate matrix with the specified values
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians),
                0, 1, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians));
        }

        //Rotate this Matrix3 with the specified values
        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }

        //Set this Matrix3 to a rotate matrix with the specified values
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }

        //Rotate this Matrix3 with the specified values
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }

        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            Set(z * y * x);
        }

        public void SetTranslation(float x, float y, float z)
        {
            m3 = x; m6 = y; m9 = z;
        }

        public void Translate(float x, float y, float z)
        {
            m3 += x; m6 += y; m9 += z;
        }

        //Matrix3 * Matrix3
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                lhs.m1 * rhs.m1 + lhs.m2 * rhs.m4 + lhs.m3 * rhs.m7,
                lhs.m1 * rhs.m2 + lhs.m2 * rhs.m5 + lhs.m3 * rhs.m8,
                lhs.m1 * rhs.m3 + lhs.m2 * rhs.m6 + lhs.m3 * rhs.m9,

                lhs.m4 * rhs.m1 + lhs.m5 * rhs.m4 + lhs.m6 * rhs.m7,
                lhs.m4 * rhs.m2 + lhs.m5 * rhs.m5 + lhs.m6 * rhs.m8,
                lhs.m4 * rhs.m3 + lhs.m5 * rhs.m6 + lhs.m6 * rhs.m9,

                lhs.m7 * rhs.m1 + lhs.m8 * rhs.m4 + lhs.m9 * rhs.m7,
                lhs.m7 * rhs.m2 + lhs.m8 * rhs.m5 + lhs.m9 * rhs.m8,
                lhs.m7 * rhs.m3 + lhs.m8 * rhs.m6 + lhs.m9 * rhs.m9);
        }

        //Matrix3 * Vector3
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.m1 * rhs.x + lhs.m2 * rhs.y + lhs.m3 * rhs.z,
                lhs.m4 * rhs.x + lhs.m5 * rhs.y + lhs.m6 * rhs.z,
                lhs.m7 * rhs.x + lhs.m8 * rhs.y + lhs.m9 * rhs.z);
        }
    }
}
