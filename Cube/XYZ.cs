using System;
using System.Collections.Generic;
using System.Text;

// -----> x
//
// |
// |
// |
// \/  Y

// \
//  \
//   \
//    \
//    _\| Z

namespace Cube.Cube
{
    /// <summary>
    ///  storage for coordinates
    /// </summary>
    public class XYZ
    {
        private int m_x;
        private int m_y;
        private int m_z;

        public XYZ()
        { 
            // do nothing
            X = Y = Z = 0;
        }

        public XYZ(int x, int y, int z)
        {
            m_x = x;
            m_y = y;
            m_z = z;
        }

        public int X { get { return m_x; } set { m_x = value; } }
        public int Y { get { return m_y; } set { m_y = value; } }
        public int Z { get { return m_z; } set { m_z = value; } }
    }
}
