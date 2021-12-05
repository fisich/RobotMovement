using System;
using System.Linq;
using System.Windows.Forms;
using Navigation;

namespace RobotMovement
{

    /// <summary>
    /// Класс робота
    /// </summary>
    public class Robot : IDisposable
    {
        /// <summary>
        /// Размер робота по оси X
        /// </summary>
        public int sizeX { get; private set; }

        /// <summary>
        /// Размер робота по оси Y
        /// </summary>
        public int sizeY { get; private set; }

        /// <summary>
        /// Является ли робот широким
        /// </summary>
        public bool IsWideRobot { get; private set; }

        /// Track whether Dispose has been called.
        private bool disposed = false;

        /// <summary>
        /// Направление робота
        /// </summary>
        public Direction direction = Direction.None;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="sizeX">
        /// Ширина робота
        /// </param>
        /// <param name="sizeY">
        /// Длина робота
        /// </param>
        /// <param name="direction">
        /// Направление движения робота, требуется для определения,
        /// является ли робот широким
        /// </param>
        public Robot(int sizeX, int sizeY, Direction direction)
        {
            SetRobot(sizeX, sizeY, direction);
        }

        /// <summary>
        /// Инициализирует класс на основе уже существующего объекта
        /// </summary>
        /// <param name="referenceRobot">
        /// Объект-оригинал, который будет скопирован
        /// </param>
        public Robot(Robot referenceRobot)
        {
            this.sizeX = referenceRobot.sizeX;
            this.sizeY = referenceRobot.sizeY;
            this.direction = referenceRobot.direction;
            this.IsWideRobot = referenceRobot.IsWideRobot;
        }

        /// <summary>
        /// Функция, которая задает новый размер робота
        /// и определяет ширину на основе направления движения
        /// </summary>
        /// <param name="sizeX">
        /// Ширина робота
        /// </param>
        /// <param name="sizeY">
        /// Длина робота
        /// </param>
        /// <param name="direction">
        /// Направление движения робота, требуется для определения,
        /// является ли робот широким
        /// </param>
        public void SetRobot(int sizeX, int sizeY, Direction direction)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.direction = direction;
            if (new[] { Direction.UP, Direction.DOWN }.Contains(direction))
            {
                IsWideRobot = sizeX > sizeY;
            }
            else
            {
                IsWideRobot = sizeY > sizeX;
            }
        }

        /// <summary>
        /// Меняет ширину и длину робота местами
        /// </summary>
        public void FlipSizes()
        {
            int temp = sizeX;
            sizeX = sizeY;
            sizeY = temp;
        }

        /// <summary></summary>
        /// <param name="robotPosition">
        /// Положение, относительно которого будет расчитана точка
        /// </param>
        /// <returns>
        /// Координата верхней левой точки робота
        /// </returns>
        public WorldPoint2D GetUpLeftPointOfRobot(WorldPoint2D robotPosition)
        {
            return new WorldPoint2D(robotPosition.X - ((sizeX - 1.0f) * 0.5f),
                robotPosition.Y - ((sizeY - 1.0f) * 0.5f));
        }

        /// <summary></summary>
        /// <param name="robotPosition">
        /// Положение, относительно которого будет расчитана точка
        /// </param>
        /// <returns>
        /// Координата нижней правой точки робота
        /// </returns>
        public WorldPoint2D GetDownRightPointOfRobot(WorldPoint2D robotPosition)
        {
            return new WorldPoint2D(robotPosition.X + ((sizeX - 1.0f) * 0.5f),
                robotPosition.Y + ((sizeY - 1.0f) * 0.5f));
        }

        /// <summary></summary>
        /// <param name="robotPosition">
        /// Положение, относительно которого будет расчитана точка
        /// </param>
        /// <returns>
        /// Координата верхней правой точки робота
        /// </returns>
        public WorldPoint2D GetUpRightPointOfRobot(WorldPoint2D robotPosition)
        {
            return new WorldPoint2D(robotPosition.X + ((sizeX - 1.0f) * 0.5f),
                robotPosition.Y - ((sizeY - 1.0f) * 0.5f));
        }

        /// <summary></summary>
        /// <param name="robotPosition">
        /// Положение, относительно которого будет расчитана точка
        /// </param>
        /// <returns>
        /// Координата нижней левой точки робота
        /// </returns>
        public WorldPoint2D GetDownLeftPointOfRobot(WorldPoint2D robotPosition)
        {
            return new WorldPoint2D(robotPosition.X - ((sizeX - 1.0f) * 0.5f),
                robotPosition.Y + ((sizeY - 1.0f) * 0.5f));
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // Note disposing has been done.
                disposed = true;
            }
        }
        ~Robot()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(disposing: false) is optimal in terms of
            // readability and maintainability.
            Dispose(disposing: false);
        }

    }
}
