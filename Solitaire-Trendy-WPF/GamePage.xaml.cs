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
using System.Xml.Linq;
using Solitaire_Trendy_LIB;

namespace Solitaire_Trendy_WPF
{
    /// <summary>
    /// Logica di interazione per GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public Match _match;
        public GamePage()
        {
            InitializeComponent();
            btnCarta.Visibility = Visibility.Hidden;
            _match = new Match();

            UpdateListboxColumnsCard();
            UpdateBaseCardImage();

        }

        public void UpdateBaseCardImage()
        {
            Card lastCardBase;

            if (_match.BaseCards[0].Count > 0)
            {
                lastCardBase = _match.BaseCards[0][_match.BaseCards[0].Count - 1];
                btnBase0.Background = new ImageBrush(lastCardBase.ImageCard);
            }

            if (_match.BaseCards[1].Count > 0)
            {
                lastCardBase = _match.BaseCards[1][_match.BaseCards[1].Count - 1];
                btnBase1.Background = new ImageBrush(lastCardBase.ImageCard);
            }

            if (_match.BaseCards[2].Count > 0)
            {
                lastCardBase = _match.BaseCards[2][_match.BaseCards[2].Count - 1];
                btnBase2.Background = new ImageBrush(lastCardBase.ImageCard);
            }
            
            if (_match.BaseCards[3].Count > 0)
            {
                lastCardBase = _match.BaseCards[3][_match.BaseCards[3].Count - 1];
                btnBase3.Background = new ImageBrush(lastCardBase.ImageCard);
            }
            UpdateBtnCard();
            Win();
            UpdateDrowBtn();

        }

        public void UpdateDrowBtn()
        {
            if (_match.Deck.Count == 0 && _match.DrawnCards.Count == 0)
            {
                btnDrawCardOfDeck.Visibility = Visibility.Collapsed;
                lblDrawCardsTitle.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateListboxColumnsCard()
        {
            lbxImageCulomn0.ItemsSource = null;
            lbxImageCulomn0.ItemsSource = _match.ColumnsCards[0];
            if (lbxImageCulomn0.Items.Count - 1 > 0) lbxImageCulomn0.ScrollIntoView(lbxImageCulomn0.Items[lbxImageCulomn0.Items.Count - 1]);
            

            lbxImageCulomn1.ItemsSource = null;
            lbxImageCulomn1.ItemsSource = _match.ColumnsCards[1];
            if (lbxImageCulomn1.Items.Count - 1 > 0)  lbxImageCulomn1.ScrollIntoView(lbxImageCulomn1.Items[lbxImageCulomn1.Items.Count - 1]);

            lbxImageCulomn2.ItemsSource = null;
            lbxImageCulomn2.ItemsSource = _match.ColumnsCards[2];
            if (lbxImageCulomn2.Items.Count - 1 > 0)  lbxImageCulomn2.ScrollIntoView(lbxImageCulomn2.Items[lbxImageCulomn2.Items.Count - 1]);

            lbxImageCulomn3.ItemsSource = null;
            lbxImageCulomn3.ItemsSource = _match.ColumnsCards[3];
            if (lbxImageCulomn3.Items.Count - 1 > 0)  lbxImageCulomn3.ScrollIntoView(lbxImageCulomn3.Items[lbxImageCulomn3.Items.Count - 1]);

            lbxImageCulomn4.ItemsSource = null;
            lbxImageCulomn4.ItemsSource = _match.ColumnsCards[4];
            if (lbxImageCulomn4.Items.Count - 1 > 0)  lbxImageCulomn4.ScrollIntoView(lbxImageCulomn4.Items[lbxImageCulomn4.Items.Count - 1]);
        }

        public void UpdateBtnCard()
        {
            if (_match.DrawnCards.Count > 0)
            {
                Card lastDrawnCard = _match.LastDrawnCard;
                btnCarta.Background = new ImageBrush(lastDrawnCard.ImageCard);
            }
            if (_match.DrawnCards.Count == 0)
            {
                btnCarta.Visibility = Visibility.Collapsed;
            }
            UpdateDrowBtn();
        }

        private void btnDrawDeckCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateDrowBtn();
                bool isAddedToBase = _match.DrawCard();
                btnCarta.Visibility = Visibility.Visible;

                UpdateBaseCardImage();
                UpdateBtnCard();

                while (isAddedToBase)
                {
                    isAddedToBase = false;
                    if (_match.DrawnCards.Count > 0)
                    {
                        Card lastDrawnCard = _match.LastDrawnCard;
                        if (_match.IsInsertableCardOnBase(lastDrawnCard))
                        {
                            isAddedToBase = true;
                            _match.AddCardToBase(lastDrawnCard);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            if(_match.DrawnCards.Count == 0) btnCarta.Visibility = Visibility.Collapsed;
        }

        public void DeselectListBoxs()
        {
            lbxImageCulomn0.SelectedItem = null;
            lbxImageCulomn1.SelectedItem = null;
            lbxImageCulomn2.SelectedItem = null;
            lbxImageCulomn3.SelectedItem = null;
            lbxImageCulomn4.SelectedItem = null;
        }

        private void btnColumn0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxExeption.Text = "";
                if (lbxImageCulomn1.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(1, 0, (Card)lbxImageCulomn1.SelectedItem);
                    lbxImageCulomn1.SelectedItem = null;
                }
                else if (lbxImageCulomn2.SelectedItem != null)
                {   
                    _match.MoveCardsToColumnX(2, 0, (Card)lbxImageCulomn2.SelectedItem);
                    lbxImageCulomn2.SelectedItem = null;
                }
                else if (lbxImageCulomn3.SelectedItem != null)
                {   
                    _match.MoveCardsToColumnX(3, 0, (Card)lbxImageCulomn3.SelectedItem);
                    lbxImageCulomn3.SelectedItem = null;
                }
                else if (lbxImageCulomn4.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(4, 0, (Card)lbxImageCulomn4.SelectedItem);
                    lbxImageCulomn4.SelectedItem = null;
                }
                else
                {
                    _match.MoveLastDrawnCardsToColumnX(0);
                }
                lbxImageCulomn0.ItemsSource = null;
                lbxImageCulomn0.ItemsSource = _match.ColumnsCards[0];
            }
            catch (Exception ex)
            {
                DeselectListBoxs();
                lbxExeption.Text = ex.Message;
            }
            UpdateBtnCard();
            UpdateListboxColumnsCard();
        }

        private void btnColumn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxExeption.Text = "";
                if (lbxImageCulomn0.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(0, 1, (Card)lbxImageCulomn0.SelectedItem);
                    lbxImageCulomn0.SelectedItem = null;
                }
                else if (lbxImageCulomn2.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(2, 1, (Card)lbxImageCulomn2.SelectedItem);
                    lbxImageCulomn2.SelectedItem = null;
                }
                else if (lbxImageCulomn3.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(3, 1, (Card)lbxImageCulomn3.SelectedItem);
                    lbxImageCulomn3.SelectedItem = null;
                }
                else if (lbxImageCulomn4.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(4, 1, (Card)lbxImageCulomn4.SelectedItem);
                    lbxImageCulomn4.SelectedItem = null;
                }
                else
                {
                    _match.MoveLastDrawnCardsToColumnX(1);
                }
                lbxImageCulomn1.ItemsSource = null;
                lbxImageCulomn1.ItemsSource = _match.ColumnsCards[1];
            }
            catch (Exception ex)
            {
                DeselectListBoxs();
                lbxExeption.Text = ex.Message;
            }
            UpdateBtnCard();
            UpdateListboxColumnsCard();
        }

        private void btnColumn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxExeption.Text = "";
                if (lbxImageCulomn1.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(1, 2, (Card)lbxImageCulomn1.SelectedItem);
                    lbxImageCulomn1.SelectedItem = null;
                }
                else if (lbxImageCulomn0.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(0, 2, (Card)lbxImageCulomn0.SelectedItem);
                    lbxImageCulomn2.SelectedItem = null;
                }
                else if (lbxImageCulomn3.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(3, 2, (Card)lbxImageCulomn3.SelectedItem);
                    lbxImageCulomn3.SelectedItem = null;
                }
                else if (lbxImageCulomn4.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(4, 2, (Card)lbxImageCulomn4.SelectedItem);
                    lbxImageCulomn4.SelectedItem = null;
                }
                else
                {
                    _match.MoveLastDrawnCardsToColumnX(2);
                }
                lbxImageCulomn2.ItemsSource = null;
                lbxImageCulomn2.ItemsSource = _match.ColumnsCards[2];
            }
            catch (Exception ex)
            {
                DeselectListBoxs();
                lbxExeption.Text = ex.Message;
            }
            UpdateBtnCard();
            UpdateListboxColumnsCard();
        }

        private void btnColumn3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxExeption.Text = "";
                if (lbxImageCulomn1.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(1, 3, (Card)lbxImageCulomn1.SelectedItem);
                    lbxImageCulomn1.SelectedItem = null;
                }
                else if (lbxImageCulomn2.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(2, 3, (Card)lbxImageCulomn2.SelectedItem);
                    lbxImageCulomn2.SelectedItem = null;
                }
                else if (lbxImageCulomn0.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(0, 3, (Card)lbxImageCulomn0.SelectedItem);
                    lbxImageCulomn3.SelectedItem = null;
                }
                else if (lbxImageCulomn4.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(4, 3, (Card)lbxImageCulomn4.SelectedItem);
                    lbxImageCulomn4.SelectedItem = null;
                }
                else
                {
                    _match.MoveLastDrawnCardsToColumnX(3);
                }
                lbxImageCulomn3.ItemsSource = null;
                lbxImageCulomn3.ItemsSource = _match.ColumnsCards[3];
            }
            catch (Exception ex)
            {
                DeselectListBoxs();
                lbxExeption.Text = ex.Message;
            }
            UpdateBtnCard();
            UpdateListboxColumnsCard();
        }

        private void btnColumn4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxExeption.Text = "";
                if (lbxImageCulomn1.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(1, 4, (Card)lbxImageCulomn1.SelectedItem);
                    lbxImageCulomn1.SelectedItem = null;
                }
                else if (lbxImageCulomn2.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(2, 4, (Card)lbxImageCulomn2.SelectedItem);
                    lbxImageCulomn2.SelectedItem = null;
                }
                else if (lbxImageCulomn3.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(3, 4, (Card)lbxImageCulomn3.SelectedItem);
                    lbxImageCulomn3.SelectedItem = null;
                }
                else if (lbxImageCulomn0.SelectedItem != null)
                {
                    _match.MoveCardsToColumnX(0, 4, (Card)lbxImageCulomn0.SelectedItem);
                    lbxImageCulomn0.SelectedItem = null;
                }
                else
                {
                    _match.MoveLastDrawnCardsToColumnX(4);
                }
                lbxImageCulomn4.ItemsSource = null;
                lbxImageCulomn4.ItemsSource = _match.ColumnsCards[4];
            }
            catch (Exception ex)
            {
                DeselectListBoxs();
                lbxExeption.Text = ex.Message;
            }
            UpdateBtnCard();
            UpdateListboxColumnsCard();
        }
        private void lbxLostFocusColumn0(object sender, RoutedEventArgs e)
        {
            if( !(btnColumn1.IsMouseOver || btnColumn2.IsMouseOver || btnColumn3.IsMouseOver || btnColumn4.IsMouseOver ||
                btnBase0.IsMouseOver  || btnBase1.IsMouseOver || btnBase2.IsMouseOver || btnBase3.IsMouseOver ))
            {
                lbxImageCulomn0.SelectedItem = null;
            }
             
        }

        private void lbxLostFocusColumn1(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn0.IsMouseOver || btnColumn2.IsMouseOver || btnColumn3.IsMouseOver || btnColumn4.IsMouseOver ||
                btnBase1.IsMouseOver || btnBase2.IsMouseOver || btnBase3.IsMouseOver ))
            {
                lbxImageCulomn1.SelectedItem = null;
            }

        }

        private void lbxLostFocusColumn2(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn1.IsMouseOver || btnColumn0.IsMouseOver || btnColumn3.IsMouseOver || btnColumn4.IsMouseOver ||
                btnBase0.IsMouseOver || btnBase1.IsMouseOver || btnBase2.IsMouseOver || btnBase3.IsMouseOver ))
            {
                lbxImageCulomn2.SelectedItem = null;
            }
        }

        private void lbxLostFocusColumn3(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn1.IsMouseOver || btnColumn2.IsMouseOver || btnColumn0.IsMouseOver || btnColumn4.IsMouseOver ||
                btnBase0.IsMouseOver || btnBase1.IsMouseOver || btnBase2.IsMouseOver || btnBase3.IsMouseOver ))
            {
                lbxImageCulomn3.SelectedItem = null;
            }
        }

        private void lbxLostFocusColumn4(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn1.IsMouseOver || btnColumn2.IsMouseOver || btnColumn3.IsMouseOver || btnColumn0.IsMouseOver ||
                btnBase0.IsMouseOver || btnBase1.IsMouseOver || btnBase2.IsMouseOver || btnBase3.IsMouseOver ))
            {
                lbxImageCulomn4.SelectedItem = null;
            }
        }

        private void btnBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxExeption.Text = "";
                Card insertabelCard;
                if (lbxImageCulomn0.SelectedItem != null)
                {
                    insertabelCard = lbxImageCulomn0.SelectedItem as Card;
                    _match.MoveColumnCardToBase(insertabelCard, 0);

                    lbxImageCulomn0.ItemsSource = null;
                    lbxImageCulomn0.ItemsSource = _match.ColumnsCards[0];
                }
                else if (lbxImageCulomn1.SelectedItem != null)
                {
                    insertabelCard = lbxImageCulomn1.SelectedItem as Card;
                    _match.MoveColumnCardToBase(insertabelCard, 1);

                    lbxImageCulomn1.ItemsSource = null;
                    lbxImageCulomn1.ItemsSource = _match.ColumnsCards[1];
                }
                else if (lbxImageCulomn2.SelectedItem != null)
                {
                    insertabelCard = lbxImageCulomn2.SelectedItem as Card;
                    _match.MoveColumnCardToBase(insertabelCard, 2);

                    lbxImageCulomn2.ItemsSource = null;
                    lbxImageCulomn2.ItemsSource = _match.ColumnsCards[2];
                }
                else if (lbxImageCulomn3.SelectedItem != null)
                {
                    insertabelCard = lbxImageCulomn3.SelectedItem as Card;
                    _match.MoveColumnCardToBase(insertabelCard, 3);

                    lbxImageCulomn3.ItemsSource = null;
                    lbxImageCulomn3.ItemsSource = _match.ColumnsCards[3];
                }
                else if (lbxImageCulomn4.SelectedItem != null)
                {
                    insertabelCard = lbxImageCulomn4.SelectedItem as Card;
                    _match.MoveColumnCardToBase(insertabelCard, 4);

                    lbxImageCulomn4.ItemsSource = null;
                    lbxImageCulomn4.ItemsSource = _match.ColumnsCards[4];
                }
                else
                {
                    insertabelCard = _match.LastDrawnCard;
                    _match.AddCardToBase(insertabelCard);
                }

            }
            catch (Exception ex)
            {
                lbxExeption.Text = ex.Message;
            }
            UpdateBaseCardImage();
            UpdateListboxColumnsCard();
        }

        public void Win()
        {
            if (_match.IsWin())
            {
                FinalPage finalPage = new FinalPage();
                ((MainWindow)Application.Current.MainWindow).ChangePage(finalPage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GamePage page = new GamePage();
            ((MainWindow)Application.Current.MainWindow).ChangePage(page);
        }
    }
}
