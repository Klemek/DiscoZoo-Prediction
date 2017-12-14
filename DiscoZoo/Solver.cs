using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoZoo_Prediction
{
    public static class Solver
    {
        /// <summary>
        /// Predict all possibilities as percentages and place animals when 100%
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="animals"></param>
        public static void Predict(Square[][] grid, params Animal[] animals)
        {
            if (grid != null)
            {
                Animal animal1 = animals.Length > 0 ? animals[0] : null;
                Animal animal2 = animals.Length > 1 ? animals[1] : null;
                Animal animal3 = animals.Length > 2 ? animals[2] : null;

                bool cont = true;

                int totalmatch = 0;
                while (cont)
                {
                    cont = false;
                    for (int x = 0; x < 5; x++)
                        for (int y = 0; y < 5; y++)
                            grid[x][y].Percent = 0d;

                    totalmatch = 0;

                    if (animal1 != null)
                    {
                        double[][] prediction;
                        int nmatch = GetOnePrediction(animal1, ExtractMap(grid, SquareState.Animal1), out prediction);
                        for (int x = 0; x < 5; x++)
                            for (int y = 0; y < 5; y++)
                                if (grid[x][y].SquareState == SquareState.Unset)
                                {
                                    grid[x][y].Percent += prediction[x][y] * nmatch;
                                    if (prediction[x][y] >= 1)
                                    {
                                        grid[x][y].SquareState = SquareState.Animal1;
                                        cont = true;
                                    }
                                }
                        totalmatch += nmatch;
                    }

                    if (animal2 != null)
                    {
                        double[][] prediction;
                        int nmatch = GetOnePrediction(animal2, ExtractMap(grid, SquareState.Animal2), out prediction);
                        for (int x = 0; x < 5; x++)
                            for (int y = 0; y < 5; y++)
                                if (grid[x][y].SquareState == SquareState.Unset)
                                {
                                    grid[x][y].Percent += prediction[x][y] * nmatch;
                                    if (prediction[x][y] >= 1)
                                    {
                                        grid[x][y].SquareState = SquareState.Animal2;
                                        cont = true;
                                    }
                                }
                        totalmatch += nmatch;
                    }

                    if (animal3 != null)
                    {
                        double[][] prediction;
                        int nmatch = GetOnePrediction(animal3, ExtractMap(grid, SquareState.Animal3), out prediction);
                        for (int x = 0; x < 5; x++)
                            for (int y = 0; y < 5; y++)
                                if (grid[x][y].SquareState == SquareState.Unset)
                                {
                                    grid[x][y].Percent += prediction[x][y] * nmatch;
                                    if (prediction[x][y] >= 1)
                                    {
                                        grid[x][y].SquareState = SquareState.Animal3;
                                        cont = true;
                                    }
                                }
                        totalmatch += nmatch;
                    }
                }

                double max = 0d;

                if(totalmatch > 0)
                    for (int x = 0; x < 5; x++)
                        for (int y = 0; y < 5; y++)
                            if (grid[x][y].SquareState == SquareState.Unset)
                            {
                                grid[x][y].Percent /= totalmatch;
                                if (grid[x][y].Percent > max)
                                    max = grid[x][y].Percent;
                            }

                if (max > 0)
                    for (int x = 0; x < 5; x++)
                        for (int y = 0; y < 5; y++)
                            grid[x][y].Max = max;


            }
        }

        /// <summary>
        /// Returns the matches for one animal on the grid as percentages
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="map"></param>
        /// <param name="predictMap"></param>
        /// <returns></returns>
        private static int GetOnePrediction(Animal animal, int[][] map, out double[][] predictMap)
        {
            int matchCount = map.Sum(x => x.Count(y => y == 1));

            int[][] addMap = Utils.CreateMap(map.Length, map[0].Length, 0);

            double nmatch = 0;

            for (int stx = 0; stx < map.Length - animal.Pattern.Length + 1; stx++)
                for (int sty = 0; sty < map[0].Length - animal.Pattern[0].Length + 1; sty++)
                {
                    int match = 0;
                    for (int dx = 0; dx < animal.Pattern.Length; dx++)
                        for (int dy = 0; dy < animal.Pattern[0].Length; dy++)
                            if (animal.Pattern[dx][dy] && match >= 0)
                            {
                                if (map[stx + dx][sty + dy] >= 0)
                                    match += map[stx + dx][sty + dy];
                                else
                                    match = -1;
                            }

                    if (match == matchCount) //valid
                    {
                        for (int dx = 0; dx < animal.Pattern.Length; dx++)
                            for (int dy = 0; dy < animal.Pattern[0].Length; dy++)
                                if (animal.Pattern[dx][dy])
                                    addMap[stx + dx][sty + dy]++;
                        nmatch++;
                    }

                }


            predictMap = Utils.CreateMap(map.Length, map[0].Length, 0d);

            if (nmatch > 0)
                for (int x = 0; x < map.Length; x++)
                    for (int y = 0; y < map[0].Length; y++)
                        if (addMap[x][y] > 0)
                            predictMap[x][y] = addMap[x][y] / nmatch;

            return (int)nmatch;
        }

        /// <summary>
        /// Extract the selected animal possibilities as -1 (cannot), 0 (can) and 1 (found)
        /// </summary>
        /// <param name="squareMap"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        private static int[][] ExtractMap(Square[][] squareMap, SquareState selected)
        {
            int[][] outMap = Utils.CreateMap(squareMap.Length, squareMap[0].Length, 0);

            for (int x = 0; x < squareMap.Length; x++)
                for (int y = 0; y < squareMap[0].Length; y++)
                    outMap[x][y] = squareMap[x][y].SquareState == selected ? 1 : squareMap[x][y].SquareState == SquareState.Unset ? 0 : -1;

            return outMap;
        }
    }
}
