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
        public XYZ()
        { 
            // do nothing
            X = Y = Z = 0;
        }

        public XYZ(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
