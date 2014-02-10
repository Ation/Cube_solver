using System;

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

        private Detal()
        { }

        public Detal(string name, int color, byte[,,] model)
        {
            var start = new XYZ();
            var end = new XYZ();

            if (color == 0)
            {
                color = 1;
            }

            bool pointFounded;

            Name = name;
            Color = color;

            int x = 0;
            int y = 0;
            int z = 0;

            m_axisDirection = new XYZ();
            m_axisDirection.X = _AxisX;
            m_axisDirection.Y = _AxisY;
            m_axisDirection.Z = _AxisZ;

            // search start
            for (x = 0, pointFounded = false; x < model.GetLength(_AxisX - 1); x++)
            {
                for (y = 0; y < model.GetLength(_AxisY - 1); y++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            pointFounded = true;
                            break;
                        }
                    }
                    if (pointFounded)
                    {
                        break;
                    }
                }
                if (pointFounded)
                {
                    break;
                }
            }

            if (!pointFounded)
            {
                throw new Exception("invalid data");
            }

            start.X = x;

            // try to find end
            for (x = model.GetLength(_AxisX - 1) - 1, pointFounded = false; x > start.X; x--)
            {
                for (y = 0; y < model.GetLength(_AxisY - 1); y++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            pointFounded = true;
                            break;
                        }
                    }
                    if (pointFounded)
                    {
                        break;
                    }
                }
                if (pointFounded)
                {
                    break;
                }
            }

            end.X = x;

            // have x
            // try to find start y
            for (y = 0, pointFounded = false; y < model.GetLength(_AxisY - 1); y++)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            pointFounded = true;
                            break;
                        }
                    }
                    if (pointFounded)
                    {
                        break;
                    }
                }
                if (pointFounded)
                {
                    break;
                }
            }

            start.Y = y;

            // ok. try to find end y
            for (y = model.GetLength(_AxisY - 1) - 1, pointFounded = false; y > start.Y; y--)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (z = 0; z < model.GetLength(_AxisZ - 1); z++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            pointFounded = true;
                            break;
                        }
                    }
                    if (pointFounded)
                    {
                        break;
                    }
                }
                if (pointFounded)
                {
                    break;
                }
            }

            end.Y = y;

            // lets finally find Z
            for (z = 0, pointFounded = false; z < model.GetLength(_AxisZ - 1); z++)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (y = start.Y; y <= end.Y; y++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            pointFounded = true;
                            break;
                        }
                    }
                    if (pointFounded)
                    {
                        break;
                    }
                }
                if (pointFounded)
                {
                    break;
                }
            }

            start.Z = z;

            for (z = model.GetLength(_AxisZ - 1) - 1, pointFounded = false; z > start.Z; z--)
            {
                for (x = start.X; x <= end.X; x++)
                {
                    for (y = start.Y; y <= end.Y; y++)
                    {
                        if (model[x, y, z] != 0)
                        {
                            pointFounded = true;
                            break;
                        }
                    }
                    if (pointFounded)
                    {
                        break;
                    }
                }
                if (pointFounded)
                {
                    break;
                }
            }

            end.Z = z;

            Count = 0;
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
                            Count++;
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
            int axisX = m_axisDirection.X;
            int axisY = m_axisDirection.Y;
            int axisZ = m_axisDirection.Z;
            switch (direction)
            {
                case RotateDirection.RotationX:
                    Rotate(ref axisY, ref axisZ, angle);
                    break;
                case RotateDirection.RotationY:
                    Rotate(ref axisZ, ref axisX, angle);
                    break;
                case RotateDirection.RotationZ:
                    Rotate(ref axisX, ref axisY, angle);
                    break;
            }

            m_axisDirection.X = axisX;
            m_axisDirection.Y = axisY;
            m_axisDirection.Z = axisZ;

            return true;
        }

        private void Rotate(ref int firstAxis, ref int secondAxis, RotationAngle angle)
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

        public string Name { get; private set; }

        public int Color { get; private set; }

        public int Count { get; private set; }

        #endregion

        #region Clone

        public object Clone()
        {
            var result = new Detal();

            result.Name = Name;
            result.Color = Color;
            result.Count = Count;

            result.m_axisDirection = new XYZ(m_axisDirection.X, m_axisDirection.Y, m_axisDirection.Z);

            result.m_model = (byte[,,])m_model.Clone();

            return result;
        }

        #endregion
    }
}