using Microsoft.Win32;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MyQrApp
{
    public partial class MainWindow : Window
    {
        // Global variable to hold the generated QR code bitmap
        // FIX: Added '?' to make the field nullable.
        // This tells the compiler we know it will be null initially.
        private Bitmap? qrCodeBitmap;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string data = txtData.Text;
            if (string.IsNullOrWhiteSpace(data))
            {
                // Custom Message Box (instead of alert)
                MessageBox.Show("Please enter some text or URL in the data box first.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Generate QR Code
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                
                // Get the bitmap
                qrCodeBitmap = qrCode.GetGraphic(20); // 20 pixels per module

                // Convert Bitmap (System.Drawing) to BitmapSource (WPF)
                imgQrCode.Source = ConvertBitmapToBitmapSource(qrCodeBitmap);

                // Hide placeholder text and show the Save button
                tbPlaceholder.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the QR code: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (qrCodeBitmap == null)
            {
                MessageBox.Show("Please generate a QR code first.", "No QR Code", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Open a "Save File" dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp";
            saveFileDialog.Title = "Save QR Code As";
            saveFileDialog.FileName = "my-qr-code.png"; // Default file name

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Save the bitmap to the chosen file path and format
                    string filePath = saveFileDialog.FileName;
                    ImageFormat format = ImageFormat.Png; // Default to PNG

                    string ext = Path.GetExtension(filePath).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg")
                    {
                        format = ImageFormat.Jpeg;
                    }
                    else if (ext == ".bmp")
                    {
                        format = ImageFormat.Bmp;
                    }

                    qrCodeBitmap.Save(filePath, format);
                    MessageBox.Show("QR Code saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Helper function to convert System.Drawing.Bitmap to WPF's BitmapSource
        private BitmapSource ConvertBitmapToBitmapSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Important for performance in WPF
                return bitmapImage;
            }
        }
    }
}

