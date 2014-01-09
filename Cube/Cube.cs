using System;
using System.Collections.Generic;
using System.Text;

namespace Cube.Cube
{
    public class Cube
    {
        /// <summary>
        /// cube size
        /// </summary>
        private int m_sideLength;

        /// <summary>
        /// total detail count(volume)
        /// </summary>
        private int m_totalCount;

        /// <summary>
        /// list of added details
        /// </summary>
        List<Detal> m_details;

        private int m_cubeVolume;

        public Cube(int sideLength)
        {
            m_sideLength = sideLength;
            m_totalCount = 0;
            m_cubeVolume = sideLength * sideLength * sideLength;
            m_details = new List<Detal>();
        }

        public bool AddDetail(string name, int color, byte[, ,] detailData)
        {
            Detal _d = new Detal(name, color, detailData);

            m_totalCount += _d.Count;

            if (m_totalCount > m_cubeVolume)
            {
                throw new Exception("to much details for this cube");
            }

            AddToDetailList(_d);

            return true;
        }

        private void AddToDetailList(Detal _d)
        {
            if (m_details.Count == 0)
            {
                m_details.Add(_d);
            }
            else
            {
                int index;

                for (index = 0; index < m_details.Count; index++)
                {
                    if (m_details[index].Count < _d.Count)
                    {
                        break;
                    }
                }

                m_details.Insert(index, _d);
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

            List<CubeSolveResult> results = new List<CubeSolveResult>();

            // add positions for first detail
            Detal _d = (Detal)m_details[0].Clone();
            List<Detal> rotatedDetails;
            List<CubeSolveResult> tempResults;

            results = GetPositionsForDetail(new CubeSolveResult(m_sideLength), _d);

            for (i = 1; i < m_details.Count; i++)
            {
                rotatedDetails = GetRotatedDetails(m_details[i]);
                tempResults = new List<CubeSolveResult>();

                foreach (Detal detalRotated in rotatedDetails)
                {
                    foreach (CubeSolveResult solve in results)
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
            List<CubeSolveResult> result = new List<CubeSolveResult>();
            CubeSolveResult temp;

            byte[, ,] detailModel = detail.GetModel();

            int x;
            int y;
            int z;

            for (x = 0; x <= m_sideLength - detailModel.GetLength(0); x++)
            {
                for (y = 0; y <= m_sideLength - detailModel.GetLength(1); y++ )
                {
                    for (z = 0; z <= m_sideLength - detailModel.GetLength(2); z++)
                    {
                        temp = (CubeSolveResult)currentSolve.Clone();

                        if (temp.AddDetail(new DetailPosition((Detal)detail.Clone(), new XYZ(x, y, z))))
                        {
                            result.Add(temp);
                        }
                    }
                }
            }

            return result;
        }

        private List<Detal> GetRotatedDetails(Detal _d)
        {
            Detal temp = (Detal)_d.Clone();
            List<Detal> result = new List<Detal>();
            List<byte[, ,]> result_models = new List<byte[, ,]>();
            byte[, ,] tempModel;

            bool left = true;
            int side;
            int direction;

            for (side = 0; side < 6; side++)
            {
                for (direction = 0; direction < 4 ; direction++)
                { 
                    // add
                    tempModel = temp.GetModel();
                    if (!DetailModelExists(result_models, tempModel))
                    {
                        result.Add((Detal)temp.Clone());
                        result_models.Add(tempModel);
                    }

                    /*if (direction == 3)
                    {
                        break;
                    }*/

                    // rotate
                    temp.Rotate(RotateDirection.RotationX, RotationAngle.Angle90);
                }

                /*if (side == 5)
                {
                    break;
                }*/

                // change side
                temp.Rotate(left ? RotateDirection.RotationY : RotateDirection.RotationZ, RotationAngle.Angle90 );
                left = !left;
            }
            return result;
        }

        private bool DetailModelExists(List<byte[, ,]> modelsList, byte[, ,] model)
        {
            bool result = false;

            foreach (byte[, ,] modelFromList in modelsList)
            {
                if (ModelsEqual(modelFromList, model))
                {
                    result = true;
                    break;
                }
            }

            return result;
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
                int y;
                int z;

                for (x = 0; (x < model1.GetLength(0)) && result; x++)
                {
                    for (y = 0; (y < model1.GetLength(1)) && result; y++)
                    {
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
