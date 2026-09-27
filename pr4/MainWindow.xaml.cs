using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private Dictionary<string, string> imgBlack  = new Dictionary<string, string> ();
        private Dictionary<string, string> imgWhite = new Dictionary<string, string>();

        public static MainWindow mainWindow;
        public List <Classes.Pawn>Pawns = new List <Classes.Pawn> ();
        public int badgfb = 10;
        public MainWindow()
        {
            InitializeComponent();
            MainWindow.mainWindow = this;
            //белых спавн
            Pawns.Add(new Classes.Pawn(0, 1, false)); 
            Pawns.Add(new Classes.Pawn(1, 1, false));
            Pawns.Add(new Classes.Pawn(2, 1, false));
            Pawns.Add(new Classes.Pawn(3, 1, false));
            Pawns.Add(new Classes.Pawn(4, 1, false));
            Pawns.Add(new Classes.Pawn(5, 1, false));
            Pawns.Add(new Classes.Pawn(6, 1, false));
            Pawns.Add(new Classes.Pawn(7, 1, false));
            //черных спавн
            Pawns.Add(new Classes.Pawn(0, 6, false));
            Pawns.Add(new Classes.Pawn(1, 6, false));
            Pawns.Add(new Classes.Pawn(2, 6, false));
            Pawns.Add(new Classes.Pawn(3, 6, false));
            Pawns.Add(new Classes.Pawn(4, 6, false));
            Pawns.Add(new Classes.Pawn(5, 6, false));
            Pawns.Add(new Classes.Pawn(6, 6, false));
            Pawns.Add(new Classes.Pawn(7, 6, false));

           
            imgBlack.Add("Pawn", "Images\\Figure\\Black\\pawn.png");
            imgBlack.Add("rool", "Images\\Figure\\Black\\rool.png");
            imgBlack.Add("queen", "Images\\Figure\\Black\\queen.png");
            imgBlack.Add("king", "Images\\Figure\\Black\\king.png");
            imgBlack.Add("horse", "Images\\Figure\\Black\\horse.png");
            imgBlack.Add("elephant", "Images\\Figure\\Black\\elephant.png");

            imgWhite.Add("Pawn", "Images\\Figure\\White\\pawn.png");
            imgWhite.Add("rool", "Images\\Figure\\White\\rool.png");
            imgWhite.Add("queen", "Images\\Figure\\White\\queen.png");
            imgWhite.Add("king", "Images\\Figure\\White\\king.png");
            imgWhite.Add("horse", "Images\\Figure\\White\\horse.png");
            imgWhite.Add("elephant", "Images\\Figure\\White\\elephant.png");

        }

        public void CreateFigure()
        {
            foreach(Classes.Pawn Pawn in Pawns)
            {
                //создание элементов грид с размерами тайла
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                //в зависимости от цвета пешуки указываем ей изображение 
                if(Pawn.Black)
                {
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(imgBlack["Pawn"])));
                }
                else
                {
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(imgWhite["Pawn"])));
                }
            }
        }
        public void OnSelect(Classes.Pawn SelectPawn)
        {
            foreach(Classes.Pawn Pawn in Pawns)
            {
                if (Pawn != SelectPawn)
                {
                    if (Pawn.Select)
                    {
                        Pawn.SelectFigure(null, null);
                    }
                }
            }
        }

        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid; ;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);
            Classes.Pawn SelectPawn = Pawns.Find(x=> x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }

        }
    }
}
