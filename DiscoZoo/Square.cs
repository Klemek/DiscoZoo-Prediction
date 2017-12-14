using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DiscoZoo_Prediction
{
    /// <summary>
    /// Visual square with a color and a percentage
    /// </summary>
    public class Square
    {

        #region Variables

        private double percent = 0;
        private double max = 1;
        private SquareState squareState = SquareState.Unset;
        private TextBlock txt;
        private Rectangle rect;
        private IClickListener listener;

        #endregion

        #region Properties

        /// <summary>
        /// The position within the grid
        /// </summary>
        public Tuple<int, int> Position { get; private set; }

        /// <summary>
        /// Percentage shown
        /// </summary>
        public double Percent
        {
            get
            {
                return percent;
            }
            set
            {
                if(squareState == SquareState.Unset)
                {
                    percent = value;
                    UpdateText(String.Format("{0:P0}", percent));
                    if (percent <= 0)
                    {
                        Max = 1;
                    }
                        
                }
            }
        }

        /// <summary>
        /// The percent range (default 1) link to the color of the square
        /// </summary>
        public double Max
        {
            get
            {
                return max;
            }
            set
            {
                max = 1;
                if (squareState == SquareState.Unset)
                {
                    max = value;
                    rect.Fill = new SolidColorBrush(Utils.MixColors(percent / max, Constants.ColorRed,
                        Constants.ColorOrange, Constants.ColorGreen));
                }
            }
        }

        /// <summary>
        /// The state of the square, unset will show changing color and the percentage
        /// text and others will show a constant color
        /// </summary>
        public SquareState SquareState {
            get
            {
                return squareState;
            }
            set
            {
                squareState = value;
                txt.Text = "";
                switch (squareState)
                {
                    case SquareState.Unset:
                        Percent = percent; //update text and fill
                        break;
                    case SquareState.Blank:
                        rect.Fill = new SolidColorBrush(Constants.ColorBlank);
                        break;
                    case SquareState.Animal1:
                        rect.Fill = new SolidColorBrush(Constants.ColorAnimal1);
                        break;
                    case SquareState.Animal2:
                        rect.Fill = new SolidColorBrush(Constants.ColorAnimal2);
                        break;
                    case SquareState.Animal3:
                        rect.Fill = new SolidColorBrush(Constants.ColorAnimal3);
                        break;
                }
            }
        }

        #endregion

        public Square(Canvas canvas, Tuple<int, int> position, IClickListener listener)
        {
            Position = position;
            this.listener = listener;

            squareState = SquareState.Unset;

            rect = new Rectangle()
            {
                Width = Constants.SQ_SIZE,
                Height = Constants.SQ_SIZE,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = Constants.SQ_THICKNESS,
                Fill = new SolidColorBrush(Constants.ColorRed),
            };
            rect.MouseRightButtonDown += new MouseButtonEventHandler(Rect_MouseRightButtonDown);
            rect.MouseLeftButtonDown += new MouseButtonEventHandler(Rect_MouseLeftButtonDown);
            Canvas.SetBottom(rect, Constants.SQ_MARGIN + (4 - Position.Item2) * Constants.SQ_SIZE);
            Canvas.SetLeft(rect, Constants.SQ_MARGIN + position.Item1 * Constants.SQ_SIZE);
            canvas.Children.Add(rect);

            txt = new TextBlock()
            {
                FontSize = Constants.SQ_FONT,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            canvas.Children.Add(txt);
            txt.MouseRightButtonDown += new MouseButtonEventHandler(Rect_MouseRightButtonDown);
            txt.MouseLeftButtonDown += new MouseButtonEventHandler(Rect_MouseLeftButtonDown);

            Percent = 0;
        }

        #region Functions

        /// <summary>
        /// Update the percentage text and center it
        /// </summary>
        /// <param name="text"></param>
        private void UpdateText(string text)
        {
            txt.Text = text;
            Canvas.SetBottom(txt, Constants.SQ_MARGIN + (4 - Position.Item2 + 0.5d) * Constants.SQ_SIZE - txt.MeasureString().Height / 2d);
            Canvas.SetLeft(txt, Constants.SQ_MARGIN + (Position.Item1 + 0.5d) * Constants.SQ_SIZE - txt.MeasureString().Width / 2d);
        }

        #region Events

        private void Rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (listener != null)
                listener.OnClick(this, false);
        }

        private void Rect_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (listener != null)
                listener.OnClick(this, true);
        }

        #endregion

        #endregion



    }

    /// <summary>
    /// An interface listening a square click
    /// </summary>
    public interface IClickListener
    {
        void OnClick(Square sq, bool rightClick);
    }

    /// <summary>
    /// A square state
    /// </summary>
    public enum SquareState
    {
        Unset = -1,
        Blank = 0,
        Animal1 = 1,
        Animal2 = 2,
        Animal3 = 3
    }
}
