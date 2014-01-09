using System;
using System.Collections.Generic;
using System.Text;

namespace Cube.Cube
{
    public class CubeSolveResult : ICloneable
    {
        private List<DetailPosition> m_details;
        private byte[, ,] m_cube;
        private int m_size;

        private CubeSolveResult()
        {
        }

        public CubeSolveResult(int size)
        {
            m_details = new List<DetailPosition>();
            m_cube = new byte[size, size, size];

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    for (int z = 0; z < size; z++)
                        m_cube[x, y, z] = 0;

            m_size = size;
        }

        public bool AddDetail(DetailPosition dp)
        {
            bool result = false;

            int x;
            int y;
            int z;

            byte[, ,] detailModel = dp.Detail.GetModel();

            if (ValidRegions(dp))
            {
                result = true;

                for (x = 0; x < detailModel.GetLength(0); x++)
                {
                    for (y = 0; y < detailModel.GetLength(1); y++)
                    {
                        for (z = 0; z < detailModel.GetLength(2); z++)
                        {
                            if (detailModel[x, y, z] != 0)
                            {
                                if (m_cube[x + dp.Offset.X, y + dp.Offset.Y, z + dp.Offset.Z] != 0)
                                {
                                    result = false;
                                    break;
                                }
                            }
                        }
                        if (!result)
                        {
                            break;
                        }
                    }
                    if (!result)
                    {
                        break;
                    }

                }
            }

            if (result)
            { 
                // add detail
                m_details.Add(dp);
                //update cube
                for (x = 0; x < detailModel.GetLength(0); x++)
                {
                    for (y = 0; y < detailModel.GetLength(1); y++)
                    {
                        for (z = 0; z < detailModel.GetLength(2); z++)
                        {
                            if (detailModel[x, y, z] != 0)
                            {
                                m_cube[x + dp.Offset.X, y + dp.Offset.Y, z + dp.Offset.Z] = detailModel[x, y, z];
                            }
                        }
                    }
                }
            }

            return result;

        }

        public bool ValidRegions(DetailPosition dp)
        {
            bool result = false;
            // offset should be positive
            if ((dp.Offset.X >= 0) || (dp.Offset.Y >= 0) || (dp.Offset.Z >= 0))
            {
                byte[, ,] detailModel = dp.Detail.GetModel();

                if (detailModel != null)
                {
                    result = (detailModel.GetLength(0) + dp.Offset.X <= m_size)
                        && (detailModel.GetLength(1) + dp.Offset.Y <= m_size)
                        && (detailModel.GetLength(2) + dp.Offset.Z <= m_size);
                }
            }

            return result;
        }

        public byte[, ,] GetCube()
        {
            return m_cube;
        }

        public int GetDetailCount()
        {
            return m_details.Count;
        }

        public object Clone()
        {
            CubeSolveResult result = new CubeSolveResult();

            result.m_details = new List<DetailPosition>(m_details);
            result.m_size = m_size;
            result.m_cube = (byte[,,])m_cube.Clone();

            return result;
        }
    }
}
