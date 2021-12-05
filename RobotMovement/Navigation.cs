using RobotMovement;
using System;

namespace Navigation
{
    /// <summary>
    /// Направление куда смотрит робот
    /// </summary>
    [Flags]
    public enum Direction
    {
        None,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    /// <summary>
    /// Точка двумерного пространства
    /// </summary>
    public struct WorldPoint2D : ICloneable
    {
        /// <summary>
        /// Сводка:
        ///    Инициализирует новый экземпляр MapPoint класса с указанными координатами.
        /// </summary>
        /// <param name="x">
        /// Положение точки по горизонтали.
        /// </param>
        /// <param name="y">
        /// Положение точки по вертикали.
        /// </param>
        public WorldPoint2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Координата по горизонтали.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата по вертикали.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Задает новую координату точки на карте.
        /// </summary>
        /// <param name="x">
        /// Новая координата x
        /// </param>
        /// <param name="y">
        /// Новая координата y
        /// </param>
        public void SetPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        public object Clone()
        {
            return new WorldPoint2D(X, Y);
        }
    }

    public class PathNode1
    {
        // Координаты точки на карте.
        public WorldPoint2D Position { get; set; }
        // Длина пути от старта (G).
        public int PathCostFromStart { get; set; }
        // Точка, из которой пришли в эту точку.
        public PathNode1 CameFrom { get; set; }
        // Примерное расстояние до цели (H).
        public int HeuristicEstimatePathLength { get; set; }
        // Ожидаемое полное расстояние до цели (F).
        public int EstimateFullPathLength
        {
            get
            {
                return this.PathCostFromStart + this.HeuristicEstimatePathLength;
            }
        }
    }

    public struct PathNode
    {
        public int LeftDirectionCost;
        public int UpDirectionCost;
        public int DownDirectionCost;
        public int RightDirectionCost;
    }

    public class PathFinding
    {
        PathNode[,] field;

        public void StartSearch(int[,] matrix, Robot robot, WorldPoint2D robotPosition)
        {
            field = new PathNode[matrix.GetLength(0), matrix.GetLength(1)];
            WorldPoint2D upLeftRobotPoint = robot.GetUpLeftPointOfRobot(robotPosition);
            WorldPoint2D downRightRobotPoint = robot.GetDownRightPointOfRobot(robotPosition);
            for (int i = (int)upLeftRobotPoint.X; i <= downRightRobotPoint.X; i++)
            {
                for (int j = (int)upLeftRobotPoint.Y; j <= downRightRobotPoint.Y; j++)
                {
                    switch (robot.direction)
                    {
                        case Direction.UP:
                            field[i, j].UpDirectionCost = 0;
                            break;
                        case Direction.RIGHT:
                            field[i, j].RightDirectionCost = 0;
                            break;
                        case Direction.DOWN:
                            field[i, j].DownDirectionCost = 0;
                            break;
                        case Direction.LEFT:
                            field[i, j].LeftDirectionCost = 0;
                            break;
                    }

                }
            }
        }
    }
}
