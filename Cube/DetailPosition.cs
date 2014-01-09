using System;
using System.Collections.Generic;
using System.Text;

namespace Cube.Cube
{
    /// <summary>
    ///  container for deatil position in cube
    /// </summary>
    public class DetailPosition
    {
        private Detal m_detail;
        private XYZ m_offset;

        public DetailPosition(Detal _d, XYZ offset)
        {
            m_detail = _d;
            m_offset = offset;
        }

        public Detal Detail { get { return m_detail; } }

        public XYZ Offset { get { return m_offset; } }
    }
}
