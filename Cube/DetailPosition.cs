namespace Cube.Cube
{
    /// <summary>
    ///  container for deatil position in cube
    /// </summary>
    public class DetailPosition
    {
        public DetailPosition(Detal _d, XYZ offset)
        {
            Detail = _d;
            Offset = offset;
        }

        public Detal Detail { get; private set; }

        public XYZ Offset { get; private set; }
    }
}
