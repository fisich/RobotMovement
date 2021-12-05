using System;
using System.Collections.Generic;
using System.Text;
using PerlinNoise2D;

namespace RobotMovement
{
    /// <summary>
    /// Генератор карты
    /// </summary>
    public abstract class MapGenerator2D
    {
        public abstract int [,] GenerateMap(int sizeX, int sizeY);
    }

    /// <summary>
    /// Генерация 2д сетки с использованием шума перлина
    /// </summary>
    public class PerlinMapGenerator2D : MapGenerator2D
    {
        /// <summary>
        /// Генерация карты
        /// </summary>
        /// <param name="sizeX">
        /// Ширина карты
        /// </param>
        /// <param name="sizeY">
        /// Длина карты
        /// </param>
        public override int[,] GenerateMap(int sizeX, int sizeY)
        {
            if (sizeX <= 0 || sizeY <= 0)
                throw new ArgumentException("Нулевой или отрицательный размер карты");
            int[,] matrix = new int[sizeX, sizeY];
            Random rand = new Random();
            float seed = rand.Next(1000, 10000);
            Perlin2D perlin = new Perlin2D(rand.Next(0,10000));
            seed = seed / 10000f;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (perlin.Noise((i + seed )* seed, ( j + seed )* seed, 4, 0.5f)  > -0.02f)
                        {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = 1;
                    }

                }
            }
            return matrix;
        }
    }

    /// <summary>
    /// Генерация 2д сетки при помощи Random
    /// </summary>
    public class RandomMapGenerator2D : MapGenerator2D
    {
        /// <summary>
        /// Генерация карты
        /// </summary>
        /// <param name="sizeX">
        /// Ширина карты
        /// </param>
        /// <param name="sizeY">
        /// Длина карты
        /// </param>
        public override int[,] GenerateMap(int sizeX, int sizeY)
        {
            if (sizeX <= 0 || sizeY <= 0)
                throw new ArgumentException("Нулевой или отрицательный размер карты");
            int[,] matrix = new int[sizeX, sizeY];
            Random rand = new Random();
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (rand.NextDouble() > 0.4f)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            return matrix;
        }
    }
}
