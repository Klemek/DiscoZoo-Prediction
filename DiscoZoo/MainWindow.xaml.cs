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

namespace DiscoZoo_Prediction
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClickListener
    {

        private Square[][] grid;

        public MainWindow()
        {
            InitializeComponent();

            InitCanvas();
            FillComboBoxes();

            Title = Constants.WINDOW_TITLE;

        }

        #region Functions

        /// <summary>
        /// Initialize the grid and canvas
        /// </summary>
        private void CreateGrid()
        {
            grid = Utils.CreateMap<Square>(5, 5, null);

            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                    grid[x][y] = new Square(canvas, new Tuple<int, int>(x, y), this);

        }

        private void InitCanvas()
        {
            canvas.Children.Clear();

            canvas.Width = Constants.SQ_SIZE * 5 + Constants.SQ_MARGIN * 2;
            canvas.Height = Constants.SQ_SIZE * 5 + Constants.SQ_MARGIN * 2;

            Rectangle rectBorder = new Rectangle()
            {
                Width = Constants.SQ_SIZE * 5 + 2 * Constants.SQ_THICKNESS,
                Height = Constants.SQ_SIZE * 5 + 2 * Constants.SQ_THICKNESS,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = Constants.SQ_THICKNESS * 2,

            };
            Canvas.SetBottom(rectBorder, Constants.SQ_MARGIN - Constants.SQ_THICKNESS);
            Canvas.SetLeft(rectBorder, Constants.SQ_MARGIN - Constants.SQ_THICKNESS);
            canvas.Children.Add(rectBorder);
        }

        /// <summary>
        /// Fill the main comboboxes
        /// </summary>
        private void FillComboBoxes()
        {
            cmbBiome.Items.Clear();
            foreach (Biome b in Enum.GetValues(typeof(Biome)))
                cmbBiome.Items.Add(b.ToString().Replace("_", " "));
            cmbBiome.SelectedIndex = 0;

            cmbAnimal1Border.BorderBrush = new SolidColorBrush(Constants.ColorAnimal1);
            cmbAnimal2Border.BorderBrush = new SolidColorBrush(Constants.ColorAnimal2);
            cmbAnimal3Border.BorderBrush = new SolidColorBrush(Constants.ColorAnimal3);

            cmbSelection.Items.Clear();
            cmbSelection.Items.Add("Blank");
            cmbSelection.SelectedIndex = 0;
        }

        /// <summary>
        /// Do the math
        /// </summary>
        private void Predict()
        {
            Solver.Predict(grid,
                cmbAnimal1.SelectedValue as Animal,
                cmbAnimal2.SelectedValue as Animal,
                cmbAnimal3.SelectedValue as Animal);

        }

        #region Events

        /// <summary>
        /// One square was clicked
        /// </summary>
        /// <param name="sq"></param>
        /// <param name="rightClick"></param>
        public void OnClick(Square sq, bool rightClick)
        {
            if (rightClick)
                sq.SquareState = SquareState.Unset;
            else
                sq.SquareState = (SquareState)cmbSelection.SelectedIndex;

            Predict();
        }

        private void cmbBiome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Biome selected = Enum.GetValues(typeof(Biome)).Cast<Biome>().First(x => x.ToString().Replace("_", " ") == cmbBiome.SelectedValue.ToString());

            cmbAnimal1.Items.Clear();
            cmbAnimal2.Items.Clear();
            cmbAnimal3.Items.Clear();

            cmbAnimal1.Items.Add("None");
            cmbAnimal2.Items.Add("None");
            cmbAnimal3.Items.Add("None");

            cmbAnimal1.SelectedIndex = 0;
            cmbAnimal2.SelectedIndex = 0;
            cmbAnimal3.SelectedIndex = 0;

            foreach (Animal animal in Constants.All.Where(x => x.Biome == selected))
            {
                cmbAnimal1.Items.Add(animal);
                cmbAnimal2.Items.Add(animal);
                cmbAnimal3.Items.Add(animal);
            }

            CreateGrid();
        }

        private void cmbAnimal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Predict();
            int index = cmbSelection.SelectedIndex;

            Animal animal1 = cmbAnimal1.SelectedValue as Animal;
            Animal animal2 = cmbAnimal2.SelectedValue as Animal;
            Animal animal3 = cmbAnimal3.SelectedValue as Animal;

            cmbSelection.Items.Clear();
            cmbSelection.Items.Add("Blank");

            if (animal1 != null || animal2 != null || animal3 != null)
                cmbSelection.Items.Add(animal1 == null ? "None" : animal1.ToString());
            else if (index == 1)
                index = 0;

            if (animal2 != null || animal3 != null)
                cmbSelection.Items.Add(animal2 == null ? "None" : animal2.ToString());
            else if (index == 2)
                index = 0;

            if (animal3 != null)
                cmbSelection.Items.Add(animal3.ToString());
            else if (index == 3)
                index = 0;

            cmbSelection.SelectedIndex = index;
        }

        private void cmbSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbSelection.SelectedIndex)
            {
                case 0:
                    cmbSelectionBorder.BorderBrush = new SolidColorBrush(Constants.ColorBlank);
                    break;
                case 1:
                    cmbSelectionBorder.BorderBrush = new SolidColorBrush(Constants.ColorAnimal1);
                    break;
                case 2:
                    cmbSelectionBorder.BorderBrush = new SolidColorBrush(Constants.ColorAnimal2);
                    break;
                case 3:
                    cmbSelectionBorder.BorderBrush = new SolidColorBrush(Constants.ColorAnimal3);
                    break;
            }
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            CreateGrid();
            Predict();
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                cmbSelection.SelectedIndex = cmbSelection.SelectedIndex == cmbSelection.Items.Count - 1 ? 0 : cmbSelection.SelectedIndex + 1;
            else
                cmbSelection.SelectedIndex = cmbSelection.SelectedIndex == 0 ? cmbSelection.Items.Count - 1 : cmbSelection.SelectedIndex - 1;
        }

        #endregion

        #endregion
    }


}
