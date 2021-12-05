using Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RobotMovement
{
    /// <summary>
    /// Осуществляет функционал управления картой
    /// и перемешением робота по полю
    /// </summary>
    class Map
    {
        /// <summary>
        /// Ширина карты
        /// </summary>
        public int sizeX { get; private set; }
        /// <summary>
        /// Длина карты
        /// </summary>
        public int sizeY {get; private set;}

        /// <summary>
        /// Двумерная бинарная сетка, на которую
        /// наносится робот и точка назначения
        /// </summary>
        int[,] matrix;

        /// <summary>
        /// Сгенерированная двумерная бинарная сетка
        /// </summary>
        public int[,] generatedMatrix { get; private set; }

        public Robot robot { get; private set; }

        /// <summary>
        /// Местоположение робота
        /// </summary>
        public WorldPoint2D robotPosition { get; private set; }
        MapObserver mapObserver;

        /// <summary>
        /// Добавление к смещению центра робота при повороте
        /// </summary>
        private float centerAligmentPerRotation;

        public Map(int sizeX, int sizeY, MapGenerator2D generator)
        {
            SetMap(sizeX, sizeY, generator);
            mapObserver = new MapObserver(this);
        }

        /// <summary>
        /// Изменение размера карты
        /// </summary>
        /// <param name="sizeX">
        /// Новая ширина карты
        /// </param>
        /// <param name="sizeY">
        /// Новая длина карты
        /// </param>
        /// <param name="generator">
        /// Генератор 2д карты
        /// </param>
        public void SetMap(int sizeX, int sizeY, MapGenerator2D generator)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            generatedMatrix = generator.GenerateMap(sizeX, sizeY);
            RefreshMap();
        }

        public int[,] GetMap()
        {
            return matrix;
        }

        /// <summary>
        /// Обновление карты, удаляет все пользовательские метки
        /// </summary>
        private void RefreshMap()
        {
            if (matrix == null)
                matrix = new int[sizeX, sizeY];
            else
                Array.Clear(matrix, 0, matrix.Length);
            matrix = (int[,])generatedMatrix.Clone();
        }

        /// <summary>
        /// Пересчитывает положение робота
        /// </summary>
        private void RecalculateRobotOnMap()
        {
            RefreshMap();
            WorldPoint2D topLeft = robot.GetUpLeftPointOfRobot(robotPosition);
            WorldPoint2D buttomRight = robot.GetDownRightPointOfRobot(robotPosition);
            for (int i = (int)topLeft.X; i <= (int)buttomRight.X; i++)
            {
                for (int j = (int)topLeft.Y; j <= (int)buttomRight.Y; j++)
                {
                    matrix[i, j] = 2;
                }
            }
        }

        /// <summary>
        /// Ставит робота на карту в соответствии с заданными координатами и направлением
        /// </summary>
        /// <param name="start">
        /// Верхняя левая граница робота
        /// </param>
        /// <param name="end">
        /// Нижняя правая граница робота
        /// </param>
        /// <param name="dir">
        /// Направление робота
        /// </param>
        public void SpawnRobot(WorldPoint2D start, WorldPoint2D end, Direction dir)
        {
            if (!mapObserver.IsAreaBetweenPointsEmpty(start, end))
            {
                RefreshMap();
                MessageBox.Show("Невозможно поставить робота в этом месте");
                return;
            }

            int robotX = (int)Math.Abs(start.X - end.X) + 1;
            int robotY = (int)Math.Abs(start.Y - end.Y) + 1;

            if (robot == null)
            {
                robot = new Robot(robotX, robotY, dir);
            }
            else
            {
                robot.SetRobot(robotX, robotY, dir);
            }
            robotPosition = new WorldPoint2D((start.X + end.X) * 0.5f, (start.Y + end.Y) * 0.5f);

            if (robotX == robotY)
            {
                centerAligmentPerRotation = 0f;
            }
            else if (robotPosition.X % 1 == robotPosition.Y % 1)
            {
                centerAligmentPerRotation = 1f;
            }
            else
            {
                centerAligmentPerRotation = 0.5f;
            }
            RecalculateRobotOnMap();
        }

        /// <summary>
        /// Двигает робота на 1 клетку вперед
        /// </summary>
        public void MoveRobot()
        {
            if (robot == null)
                return;
            WorldPoint2D nextRobotPosiition = (WorldPoint2D)robotPosition.Clone();
            switch (robot.direction)
            {
                case Direction.UP:
                    nextRobotPosiition.Y--;
                    break;
                case Direction.DOWN:
                    nextRobotPosiition.Y++;
                    break;
                case Direction.LEFT:
                    nextRobotPosiition.X--;
                    break;
                case Direction.RIGHT:
                    nextRobotPosiition.X++;
                    break;
                default:
                    return;
            }
            if (!mapObserver.IsAreaBetweenPointsEmpty(robot.GetUpLeftPointOfRobot(nextRobotPosiition),
                robot.GetDownRightPointOfRobot(nextRobotPosiition)))
            {
                MessageBox.Show("Робот не может пойти в эту сторону ");
                return;
            }
            robotPosition = nextRobotPosiition;
            RecalculateRobotOnMap();
        }

        /// <summary>
        /// Осуществляет поворот заданного робота вправо
        /// </summary>
        /// <param name="robotToRotate">
        /// Робот, который будет повернут
        /// </param>
        /// <returns>
        /// Новая координата центра после поворота
        /// </returns>
        public WorldPoint2D RotateRobotRight(Robot robotToRotate)
        {
            WorldPoint2D positionAfterRotation = (WorldPoint2D) robotPosition.Clone();
            switch (robotToRotate.direction)
            {
                case Direction.UP:
                    positionAfterRotation.X += centerAligmentPerRotation;
                    positionAfterRotation.Y += centerAligmentPerRotation;
                    robotToRotate.direction = Direction.RIGHT;
                    break;
                case Direction.DOWN:
                    positionAfterRotation.X -= centerAligmentPerRotation;
                    positionAfterRotation.Y -= centerAligmentPerRotation;
                    robotToRotate.direction = Direction.LEFT;
                    break;
                case Direction.LEFT:
                    positionAfterRotation.X += centerAligmentPerRotation;
                    positionAfterRotation.Y -= centerAligmentPerRotation;
                    robotToRotate.direction = Direction.UP;
                    break;
                case Direction.RIGHT:
                    positionAfterRotation.X -= centerAligmentPerRotation;
                    positionAfterRotation.Y += centerAligmentPerRotation;
                    robotToRotate.direction = Direction.DOWN;
                    break;
                default:
                    return positionAfterRotation;
            }
            robotToRotate.FlipSizes();
            return positionAfterRotation;
        }

        /// <summary>
        /// Осуществляет поворот заданного робота влево
        /// </summary>
        /// <param name="robotToRotate">
        /// Робот, который будет повернут
        /// </param>
        /// <returns>
        /// Новая координата центра после поворота
        /// </returns>
        public WorldPoint2D RotateRobotLeft(Robot robotToRotate)
        {
            WorldPoint2D positionAfterRotation = (WorldPoint2D)robotPosition.Clone();
            switch (robotToRotate.direction)
            {
                case Direction.UP:
                    positionAfterRotation.X -= centerAligmentPerRotation;
                    positionAfterRotation.Y += centerAligmentPerRotation;
                    robotToRotate.direction = Direction.LEFT;
                    break;
                case Direction.DOWN:
                    positionAfterRotation.X += centerAligmentPerRotation;
                    positionAfterRotation.Y -= centerAligmentPerRotation;
                    robotToRotate.direction = Direction.RIGHT;
                    break;
                case Direction.LEFT:
                    positionAfterRotation.X += centerAligmentPerRotation;
                    positionAfterRotation.Y += centerAligmentPerRotation;
                    robotToRotate.direction = Direction.DOWN;
                    break;
                case Direction.RIGHT:
                    positionAfterRotation.X -= centerAligmentPerRotation;
                    positionAfterRotation.Y -= centerAligmentPerRotation;
                    robotToRotate.direction = Direction.UP;
                    break;
                default:
                    return positionAfterRotation;
            }
            robotToRotate.FlipSizes();
            return positionAfterRotation;
        }

        /// <summary>
        /// Функция, отвещающая за поворот робота по карте
        /// </summary>
        /// <param name="rotateRight">
        /// Параметр поворота, true - вправо, false - поворот влево
        /// </param>
        public void RotateRobot(bool rotateRight)
        {
            bool error = false;
            if (robot == null)
                return;
            Robot nextRobot = new Robot(robot);
            WorldPoint2D nextRobotPosition;
            if (rotateRight)
                nextRobotPosition = RotateRobotRight(nextRobot);
            else
                nextRobotPosition = RotateRobotLeft(nextRobot);
            if (!mapObserver.IsAreaBetweenPointsEmpty(nextRobot.GetUpLeftPointOfRobot(nextRobotPosition),
                nextRobot.GetDownRightPointOfRobot(nextRobotPosition)))
            {
                MessageBox.Show("Робот не может повернуться в эту сторону 1 ");
                return;
            }
            // Широкие роботы смещаются иначе, но зоны, необходимые для поворота
            // такие же как при повороте длинного робота при повороте на 90 градусов
            // Если робот поворачивает влево и он длинный, то также требуется поворот на 90 градусов
            // эти манипуляции влияют только на определение препятствий при повороте робота
            if (robot.IsWideRobot == rotateRight)
            {
                Direction temp = robot.direction;
                robot.direction = nextRobot.direction;
                nextRobot.direction = temp;
            }
            if (mapObserver.IsObstacleBetweenRobotPositions(robot, robotPosition, nextRobot, nextRobotPosition))
            {
                MessageBox.Show("Робот не может повернуться в эту сторону 2");
                error = true;
            }
            if (robot.IsWideRobot == rotateRight)
            {
                Direction temp = robot.direction;
                robot.direction = nextRobot.direction;
                nextRobot.direction = temp;
            }
            nextRobot.Dispose();
            if (error)
                return;
            if (rotateRight)
                robotPosition = RotateRobotRight(robot);
            else
                robotPosition = RotateRobotLeft(robot);
            RecalculateRobotOnMap();
        }
    }
}
