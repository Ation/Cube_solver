using System;
using System.Collections.Generic;
using System.Linq;

namespace Cube.Cube
{
    public class Cube
    {
        /// <summary>
        /// cube size
        /// </summary>
        private readonly int m_sideLength;

        /// <summary>
        /// total detail count(volume)
        /// </summary>
        private int m_totalCount;

        /// <summary>
        /// list of added details
        /// </summary>
        readonly List<Detal> m_details;

        private readonly int m_cubeVolume;

        public Cube(int sideLength)
        {
            m_sideLength = sideLength;
            m_totalCount = 0;
            m_cubeVolume = sideLength * sideLength * sideLength;
            m_details = new List<Detal>();
        }

        public bool AddDetail(string name, int color, byte[, ,] detailData)
        {
            var d = new Detal(name, color, detailData);

            m_totalCount += d.Count;

            if (m_totalCount > m_cubeVolume)
            {
                throw new Exception("to much details for this cube");
            }

            AddToDetailList(d);

            return true;
        }

        private void AddToDetailList(Detal d)
        {
            if (m_details.Count == 0)
            {
                m_details.Add(d);
            }
            else
            {
                int index;

                for (index = 0; index < m_details.Count; index++)
                {
                    if (m_details[index].Count < d.Count)
                    {
                        break;
                    }
                }

                m_details.Insert(index, d);
            }
        }

        /// <summary>
        /// try to find position for added details
        /// </summary>
        /// <returns>solutions number returned</returns>
        /// NOTE: first detail should not be rotated
        /// NOTE: first detail should be moved if it's possible
        public List<CubeSolveResult> Solve()
        {
            int i;

            if (m_totalCount != m_cubeVolume)
            {
                throw new Exception("Could not solve - not enough data");
            }

            // add positions for first detail
            var d = (Detal)m_details[0].Clone();

            var results = GetPositionsForDetail(new CubeSolveResult(m_sideLength), d);

            for (i = 1; i < m_details.Count; i++)
            {
                var rotatedDetails = GetRotatedDetails(m_details[i]);
                var tempResults = new List<CubeSolveResult>();

                foreach (var detalRotated in rotatedDetails)
                {
                    foreach (var solve in results)
                    {
                        tempResults.AddRange(GetPositionsForDetail(solve, detalRotated));
                    }
                }

                results = tempResults;
            }

            return results;
        }

        private List<CubeSolveResult> GetPositionsForDetail(CubeSolveResult currentSolve, Detal detail)
        {
            var result = new List<CubeSolveResult>();

            byte[, ,] detailModel = detail.GetModel();

            int x;

            for (x = 0; x <= m_sideLength - detailModel.GetLength(0); x++)
            {
                int y;
                for (y = 0; y <= m_sideLength - detailModel.GetLength(1); y++ )
                {
                    int z;
                    for (z = 0; z <= m_sideLength - detailModel.GetLength(2); z++)
                    {
                        var temp = (CubeSolveResult)currentSolve.Clone();

                        if (temp.AddDetail(new DetailPosition((Detal)detail.Clone(), new XYZ(x, y, z))))
                        {
                            result.Add(temp);
                        }
                    }
                }
            }

            return result;
        }

        private IEnumerable<Detal> GetRotatedDetails(ICloneable d)
        {
            var temp = (Detal)d.Clone();
            var result = new List<Detal>();
            var resultModels = new List<byte[, ,]>();

            bool left = true;
            int side;

            for (side = 0; side < 6; side++)
            {
                int direction;
                for (direction = 0; direction < 4 ; direction++)
                { 
                    // add
                    byte[, ,] tempModel = temp.GetModel();
                    if (!DetailModelExists(resultModels, tempModel))
                    {
                        result.Add((Detal)temp.Clone());
                        resultModels.Add(tempModel);
                    }

                    // rotate
                    temp.Rotate(RotateDirection.RotationX, RotationAngle.Angle90);
                }

                // change side
                temp.Rotate(left ? RotateDirection.RotationY : RotateDirection.RotationZ, RotationAngle.Angle90 );
                left = !left;
            }
            return result;
        }

        private bool DetailModelExists(IEnumerable<byte[,,]> modelsList, byte[, ,] model)
        {
            return modelsList.Any(modelFromList => ModelsEqual(modelFromList, model));
        }

        private bool ModelsEqual(byte[, ,] model1, byte[, ,] model2)
        {
            bool result = false;

            if ((model1.GetLength(0) == model2.GetLength(0))
                && (model1.GetLength(1) == model2.GetLength(1))
                && (model1.GetLength(2) == model2.GetLength(2)))
            {
                result = true;

                int x;

                for (x = 0; (x < model1.GetLength(0)) && result; x++)
                {
                    int y;
                    for (y = 0; (y < model1.GetLength(1)) && result; y++)
                    {
                        int z;
                        for (z = 0; (z < model1.GetLength(2)); z++)
                        {
                            if (model1[x, y, z] != model2[x, y, z])
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
