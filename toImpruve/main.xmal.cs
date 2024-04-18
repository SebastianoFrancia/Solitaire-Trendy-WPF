private bool isDragging;
    private Point offset;

    public MainWindow()
    {
		InitializeComponent();
    }

    private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        isDragging = true;
        offset = e.GetPosition(card);
        card.CaptureMouse();
    }

    private void Card_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            Point currentPosition = e.GetPosition(canvas);
            double newX = currentPosition.X - offset.X;
            double newY = currentPosition.Y - offset.Y;

            Canvas.SetLeft(card, newX);
            Canvas.SetTop(card, newY);
        }
    }

    private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        isDragging = false;
        card.ReleaseMouseCapture();
    }
    
	private void DropArea_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.StringFormat))
        {
            string dataString = e.Data.GetData(DataFormats.StringFormat) as string;
            if (!string.IsNullOrEmpty(dataString))
            {
                // Effettua le operazioni necessarie al rilascio della carta sull'area di destinazione
                MessageBox.Show("Carta rilasciata nell'area di destinazione: " + dataString);
            }
        }
    }
}