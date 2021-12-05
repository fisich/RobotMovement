using Navigation;
using System;
using System.Linq;

namespace RobotMovement
{
    class MapObserver
    {
        Map map;

        public MapObserver(Map map)
        {
            if (map == null)
                throw new NullReferenceException("Null map object");
            this.map = map;
        }

        /// <summary>
        /// Функция, отвещающая за проверку, может ли робот быть повернут вправо
        /// </summary>
        /// <param name="current"></param>
        /// <param name="currentPosition"></param>
        /// <param name="next"></param>
        /// <param name="nextPosition"></param>
        /// <returns></returns>
        public bool IsObstacleBetweenRobotPositions(Robot current, WorldPoint2D currentPosition, Robot next, WorldPoint2D nextPosition)
        {
            if (current.direction == Direction.None)
                throw new Exception("Попытка поворота робота без направления");
            if (new[] { Direction.LEFT, Direction.RIGHT }.Contains(current.direction))
            {
                WorldPoint2D downRightPointCurrent = current.GetDownRightPointOfRobot(currentPosition);
                WorldPoint2D downRightPointNext = next.GetDownRightPointOfRobot(nextPosition);

                if (downRightPointCurrent.Y < downRightPointNext.Y)
                    downRightPointCurrent.Y++;
                else if (downRightPointCurrent.Y < downRightPointNext.Y)
                    downRightPointCurrent.Y--;

                if (downRightPointNext.X < downRightPointCurrent.X)
                    downRightPointNext.X++;
                else if (downRightPointNext.X > downRightPointCurrent.X)
                    downRightPointNext.X--;

                if (!IsAreaBetweenPointsEmpty(downRightPointCurrent, downRightPointNext))
                {
                    return true;
                }
                WorldPoint2D upLeftPointCurrent = current.GetUpLeftPointOfRobot(currentPosition);
                WorldPoint2D upLeftPointNext = next.GetUpLeftPointOfRobot(nextPosition);

                if (upLeftPointCurrent.Y < upLeftPointNext.Y)
                    downRightPointCurrent.Y--;
                else
                    downRightPointCurrent.Y++;

                if (upLeftPointNext.X > upLeftPointCurrent.X)
                    upLeftPointNext.X--;
                else if (upLeftPointNext.X < upLeftPointCurrent.X)
                    upLeftPointNext.X++;

                if (!IsAreaBetweenPointsEmpty(upLeftPointCurrent, upLeftPointNext))
                {
                    return true;
                }
                return false;
            }
            else
            {
                WorldPoint2D upRightPointCurrent = current.GetUpRightPointOfRobot(currentPosition);
                WorldPoint2D upRightPointNext = next.GetUpRightPointOfRobot(nextPosition);

                if (upRightPointCurrent.X < upRightPointNext.X)
                    upRightPointCurrent.X++;
                else if (upRightPointCurrent.X > upRightPointNext.X)
                    upRightPointCurrent.X--;

                if (upRightPointNext.Y > upRightPointCurrent.Y)
                    upRightPointNext.Y--;
                else if (upRightPointNext.Y < upRightPointCurrent.Y)
                    upRightPointNext.Y++;

                if (!IsAreaBetweenPointsEmpty(upRightPointCurrent, upRightPointNext))
                {
                    return true;
                }
                WorldPoint2D downLeftPointCurrent = current.GetDownLeftPointOfRobot(currentPosition);
                WorldPoint2D downLeftPointNext = next.GetDownLeftPointOfRobot(nextPosition);

                if (downLeftPointCurrent.X > downLeftPointNext.X)
                    downLeftPointCurrent.X--;
                else if (downLeftPointCurrent.X < downLeftPointNext.X)
                    downLeftPointCurrent.X++;

                if (downLeftPointNext.Y < downLeftPointCurrent.Y)
                    downLeftPointNext.Y++;
                else if (downLeftPointNext.Y > downLeftPointCurrent.Y)
                    downLeftPointNext.Y--;

                if (!IsAreaBetweenPointsEmpty(downLeftPointCurrent, downLeftPointNext))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Проверяет, свободна ли заданная область на карте
        /// </summary>
        /// <param name="start">
        /// Верхняя левая граница области
        /// </param>
        /// <param name="end">
        /// Нижняя правая граница области
        /// </param>
        /// <returns>
        /// Вовзращает true, если область свободна
        /// </returns>
        public bool IsAreaBetweenPointsEmpty(WorldPoint2D start, WorldPoint2D end)
        {
            WorldPoint2D min = new WorldPoint2D(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
            WorldPoint2D max = new WorldPoint2D(Math.Max(start.X, end.X), Math.Max(start.Y, end.Y));
            if (min.X < 0 || max.X >= map.sizeX || min.Y < 0 || max.Y >= map.sizeY)
                return false;
            for (int i = (int)min.X; i <= (int)max.X; i++)
            {
                for (int j = (int)min.Y; j <= (int)max.Y; j++)
                {
                    if (map.generatedMatrix[i, j] == 1)
                        return false;
                }
            }
            return true;
        }
    }
}
