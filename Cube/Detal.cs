using System;
using System.Collections.Generic;
using System.Text;

namespace Cube.Cube
{
    /// <summary>
    /// Represent small detail
    /// </summary>
    public class Detal : ICloneable
    {
        const int _AxisX = 1;
        const int _AxisY = 2;
        const int _AxisZ = 3;

        /// <summary>
        ///  working model
        /// </summary>
        private byte[,,]    m_model;
        private XYZ m_axisDirection;

        private string m_name;
        private int m_color;
        private int m_count;

        private Detal()
        { }

        public Detal(string name, int color, byte[,,] model)
        {
            XYZ start = new XYZ();
            XYZ end = new XYZ();

            if (color == 0)
            {
                color = 1;
            }

            bool point_founded;

            m_name = name;
            m_color = color;

            int x = 0;
            int y = 0;
            int z = 0;

            m_axisDirection = new XYZ();
            m_axisDirection.X = _AxisX;
            m_axisDirection.Y = _AxisY;
            m_axisDirection.Z = _AxisZ;

            // search start
            for (x = 0, point_founded = false; x < model.GetLength(_AxisX - 1); x++)
            {
                for (y = 0; y < model.GetLength(_AxisY - 1); y++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            point_founded = true;
                            break;
                        }
                    }
                    if (point_founded)
                    {
                        break;
                    }
                }
                if (point_founded)
                {
                    break;
                }
            }

            if (!point_founded)
            {
                throw new Exception("invalid data");
            }

            start.X = x;

            // try to find end
            for (x = model.GetLength(_AxisX - 1) - 1, point_founded = false; x > start.X; x--)
            {
                for (y = 0; y < model.GetLength(_AxisY - 1); y++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            point_founded = true;
                            break;
                        }
                    }
                    if (point_founded)
                    {
                        break;
                    }
                }
                if (point_founded)
                {
                    break;
                }
            }

            end.X = x;

            // have x
            // try to find start y
            for (y = 0, point_founded = false; y < model.GetLength(_AxisY - 1); y++)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            point_founded = true;
                            break;
                        }
                    }
                    if (point_founded)
                    {
                        break;
                    }
                }
                if (point_founded)
                {
                    break;
                }
            }

            start.Y = y;

            // ok. try to find end y
            for (y = model.GetLength(_AxisY - 1) - 1, point_founded = false; y > start.Y; y--)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            point_founded = true;
                            break;
                        }
                    }
                    if (point_founded)
                    {
                        break;
                    }
                }
                if (point_founded)
                {
                    break;
                }
            }

            end.Y = y;

            // lets finally find Z
            for (z = 0, point_founded = false; z < model.GetLength(_AxisZ - 1); z++)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (y = start.Y; y <= end.Y; y++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            point_founded = true;
                            break;
                        }
                    }
                    if (point_founded)
                    {
                        break;
                    }
                }
                if (point_founded)
                {
                    break;
                }
            }

            start.Z = z;

            for (z = model.GetLength(_AxisZ - 1) - 1, point_founded = false; z > start.Z; z--)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (y = start.Y; y <= end.Y; y++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            point_founded = true;
                            break;
                        }
                    }
                    if (point_founded)
                    {
                        break;
                    }
                }
                if (point_founded)
                {
                    break;
                }
            }

            end.Z = z;

            m_count = 0;
            m_model = new byte[end.X - start.X + 1, end.Y - start.Y + 1, end.Z - start.Z + 1];
            for (x = 0; x < end.X - start.X + 1; x++)
            {
                for (y = 0; y < end.Y - start.Y + 1; y++)
                {
                    for (z = 0; z < end.Z - start.Z + 1; z++)
                    { 
                        //m_model[x, y, z] = model[x + start.X, y + start.Y, z + start.Z];
                        //if (m_model[x, y, z] != 0)
                        if (model[x + start.X, y + start.Y, z + start.Z] != 0)
                        {
                            m_model[x, y, z] = (byte)color;
                            m_count++;
                        }
                        else
                        {
                            m_model[x, y, z] = 0;
                        }
                    }
                }
            }
        }

        #region Rotation

        public bool Rotate(RotateDirection direction, RotationAngle angle)
        {
            int axis_x = m_axisDirection.X;
            int axis_y = m_axisDirection.Y;
            int axis_z = m_axisDirection.Z;
            switch (direction)
            {
                case RotateDirection.RotationX:
                    Rotate(ref axis_y, ref axis_z, angle);
                    break;
                case RotateDirection.RotationY:
                    Rotate(ref axis_z, ref axis_x, angle);
                    break;
                case RotateDirection.RotationZ:
                    Rotate(ref axis_x, ref axis_y, angle);
                    break;
            }

            m_axisDirection.X = axis_x;
            m_axisDirection.Y = axis_y;
            m_axisDirection.Z = axis_z;

            return true;
        }

        private bool Rotate(ref int firstAxis, ref int secondAxis, RotationAngle angle)
        {
            int temp;
            switch (angle)
            {
                case RotationAngle.Angle90:
                    temp = secondAxis;
                    secondAxis = -firstAxis;
                    firstAxis = temp;
                    break;
                case RotationAngle.Angle180:
                    firstAxis = -firstAxis;
                    secondAxis = -secondAxis;
                    break;
                case RotationAngle.Angle270:
                    temp = secondAxis;
                    secondAxis = firstAxis;
                    firstAxis = -temp;
                    break;
            }

            return true;
        }

        #endregion

        #region Model

        public byte[, ,] GetModel()
        {
            int maxX;
            int maxY;
            int maxZ;

            int x;
            int y;
            int z;

            byte[, ,] result;

            maxX = m_model.GetLength(Math.Abs(m_axisDirection.X) - 1);
            maxY = m_model.GetLength(Math.Abs(m_axisDirection.Y) - 1);
            maxZ = m_model.GetLength(Math.Abs(m_axisDirection.Z) - 1);

            result = new byte[maxX, maxY, maxZ];

            switch (Math.Abs(m_axisDirection.X))
            {
                case _AxisX:
                    switch (Math.Abs(m_axisDirection.Y))
                    {
                        case _AxisY:
                            // x-x, y-y, z-z
                            if (Math.Abs(m_axisDirection.Z) != _AxisZ)
                            {
                                throw new Exception("something wrong");
                            }

                            for (x = 0; x < maxX; x++)
                            {
                                for (y = 0; y < maxY; y++)
                                {
                                    for (z = 0; z < maxZ; z++)
                                    {
                                        result[x,y,z] = m_model[
                                            (m_axisDirection.X > 0 ? x : maxX - x - 1),
                                            (m_axisDirection.Y > 0 ? y : maxY - y - 1),
                                            (m_axisDirection.Z > 0 ? z : maxZ - z - 1)
                                            ];
                                    }
                                }
                            }

                            break;
                        case _AxisZ:
                            // x-x, y-z, z-y
                            if (Math.Abs(m_axisDirection.Z) != _AxisY)
                            {
                                throw new Exception("something wrong");
                            }

                            for (x = 0; x < maxX; x++)
                            {
                                for (y = 0; y < maxY; y++)
                                {
                                    for (z = 0; z < maxZ; z++)
                                    {
                                        result[x, y, z] = m_model[
                                            (m_axisDirection.X > 0 ? x : maxX - x - 1),
                                            (m_axisDirection.Z > 0 ? z : maxZ - z - 1),
                                            (m_axisDirection.Y > 0 ? y : maxY - y - 1)
                                            ];
                                    }
                                }
                            }
                            break;
                        default:
                            throw new Exception("Something wrong");
                    }
                    break;
                case _AxisY:
                    switch (Math.Abs(m_axisDirection.Y))
                    {
                        case _AxisX:
                            // x-y, y-x, z-z
                            if (Math.Abs(m_axisDirection.Z) != _AxisZ)
                            {
                                throw new Exception("something wrong");
                            }

                            for (x = 0; x < maxX; x++)
                            {
                                for (y = 0; y < maxY; y++)
                                {
                                    for (z = 0; z < maxZ; z++)
                                    {
                                        result[x, y, z] = m_model[
                                            (m_axisDirection.Y > 0 ? y : maxY - y - 1),
                                            (m_axisDirection.X > 0 ? x : maxX - x - 1),
                                            (m_axisDirection.Z > 0 ? z : maxZ - z - 1)
                                            ];
                                    }
                                }
                            }

                            break;
                        case _AxisZ:
                            // x-y, y-z, z-x
                            if (Math.Abs(m_axisDirection.Z) != _AxisX)
                            {
                                throw new Exception("something wrong");
                            }

                            for (x = 0; x < maxX; x++)
                            {
                                for (y = 0; y < maxY; y++)
                                {
                                    for (z = 0; z < maxZ; z++)
                                    {
                                        result[x, y, z] = m_model[
                                            (m_axisDirection.Z > 0 ? z : maxZ - z - 1),
                                            (m_axisDirection.X > 0 ? x : maxX - x - 1),
                                            (m_axisDirection.Y > 0 ? y : maxY - y - 1)
                                            ];
                                    }
                                }
                            }
                            break;
                        default:
                            throw new Exception("Something wrong");
                    }
                    break;
                case _AxisZ:
                    switch (Math.Abs(m_axisDirection.Y))
                    {
                        case _AxisY:
                            // x-z, y-y, z-x
                            if (Math.Abs(m_axisDirection.Z) != _AxisX)
                            {
                                throw new Exception("something wrong");
                            }

                            for (x = 0; x < maxX; x++)
                            {
                                for (y = 0; y < maxY; y++)
                                {
                                    for (z = 0; z < maxZ; z++)
                                    {
                                        result[x, y, z] = m_model[
                                            (m_axisDirection.Z > 0 ? z : maxZ - z - 1),
                                            (m_axisDirection.Y > 0 ? y : maxY - y - 1),
                                            (m_axisDirection.X > 0 ? x : maxX - x - 1)
                                            ];
                                    }
                                }
                            }

                            break;
                        case _AxisX:
                            // x-z, y-x, z-y
                            if (Math.Abs(m_axisDirection.Z) != _AxisY)
                            {
                                throw new Exception("something wrong");
                            }

                            for (x = 0; x < maxX; x++)
                            {
                                for (y = 0; y < maxY; y++)
                                {
                                    for (z = 0; z < maxZ; z++)
                                    {
                                        result[x, y, z] = m_model[
                                            (m_axisDirection.Y > 0 ? y : maxY - y - 1),
                                            (m_axisDirection.Z > 0 ? z : maxZ - z - 1),
                                            (m_axisDirection.X > 0 ? x : maxX - x - 1)
                                            ];
                                    }
                                }
                            }

                            break;
                        default:
                            throw new Exception("Something wrong");
                    }
                    break;
                default:
                    throw new Exception("something wrong");
            }

            return result;
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            private set
            {
                m_name = value;
            }
        }

        public int Color
        {
            get
            {
                return m_color;
            }
            private set
            {
                m_color = value;
            }
        }

        public int Count {
            get
            {
                return m_count;
            }
            private set
            {
                m_count = value;
            }
        }

        #endregion

        #region Clone

        public object Clone()
        {
            Detal result = new Detal();

            result.m_name = m_name;
            result.m_color = m_color;
            result.m_count = m_count;

            result.m_axisDirection = new XYZ(m_axisDirection.X, m_axisDirection.Y, m_axisDirection.Z);

            result.m_model = (byte[,,])m_model.Clone();

            return result;
        }

        #endregion
    }
}