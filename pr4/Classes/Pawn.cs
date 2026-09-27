using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace pr4.Classes
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Select = false;
        public bool Black = false;
        public Grid Figure { get; set; }

        public Pawn(int x, int y, bool black)
        {
            X = x;
            Y = y;
            Black = black;
        }

        public void SelectFigure (object sender, MouseButtonEventArgs e)
        {
            bool atack = false;
            Pawn SelectPawn = MainWindow.mainWindow.Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {

                if (this.Black && this.Y - 1 == SelectPawn.Y && (this.X - 1 == SelectPawn.X || this.X == SelectPawn.X || this.X + 1 == SelectPawn.X) ||
                    !this.Black && this.Y + 1 == SelectPawn.Y && (this.X - 1 == SelectPawn.X || this.X == SelectPawn.X || this.X + 1 == SelectPawn.X))
                {

                    MainWindow.mainWindow.gameBoard.Children.Remove(this.Figure);
                    Grid.SetColumn(SelectPawn.Figure, this.X);
                    Grid.SetRow(SelectPawn.Figure, this.Y);
  
                    SelectPawn.X = this.X;
                    SelectPawn.Y = this.Y;
   
                    SelectPawn.SelectFigure(null, null);
               
                    atack = true;
                }
                if (!atack)
                {
                    // Вызываем метод снятия выделения со всех пешек которые находятся на доске
                    MainWindow.mainWindow.OnSelect(this);
                    // Если мы уже были выделены
                    if (this.Select)
                    {
                        // В зависимости от нашего цвета Белого/Чёрного, отображаем иконку
                        if (this.Black)
                            this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (black).png")));
                        else
                            this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn.png")));

                        // Запоминаем что пешка более не является выделенной
                        this.Select = false;
                    }
                    else
                    {
                        // Если же пешка не выделена, изменяем иконку на выделенную
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (select).png")));
                        // Запоминаем что пешка является выделенной
                        this.Select = true;
                    }
                }
            }
        }
        /// <summary> Метод перемещения пешки
        public void Transform(int X, int Y)
        {
            // Начнём с того что мешка может перемещатися только прямо
            // Если координата по X не совпадает с нашей координатой, то
            if (X != this.X)
            {
                // Снимаем выделение пешки
                SelectFigure(null, null);
                // Заканчиваем выполнение метода
                return;
            }

            // Проверяем координату по Y
            // Если пешка является чёрной, и если клетка на которой она стоит 1, и пользователь хочет переместить нашу фигуру на 2 клетки или на 1 клетку
            if (!Black && ((this.Y == 1 && this.Y + 2 == Y) || this.Y + 1 == Y) ||
                // Если пешка является белой, и если клетка на которой она стоит 1,
                // и пользователь хочет переместить нашу фигуру на 2 клетки или на 1 клетку
                Black && ((this.Y == 6 && this.Y - 2 == Y) || this.Y - 1 == Y))
            {
                // Изменяем положение фигуры на доске по X и Y
                Grid.SetColumn(this.Figure, X);
                Grid.SetRow(this.Figure, Y);
                // Запоминаем координаты на которые переместили пешку
                this.X = X;
                this.Y = Y;
            }
            // Снимаем выделение с пешки
            SelectFigure(null, null);
        }


    }
}
