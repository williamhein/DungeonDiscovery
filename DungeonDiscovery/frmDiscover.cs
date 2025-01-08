using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonDiscovery
{
    public partial class frmDiscover : Form
    {
        bool isCreate = true;

        bool somethingOpenedCreate = false;
        bool somethingOpenedDiscover = false;

        LockBitmap workingOutputCreate;
        Bitmap outputCreate;
        Bitmap bgImageCreate;

        LockBitmap workingOutputDiscover;
        LockBitmap workingBackgroundDiscover;
        Bitmap outputDiscover;
        Bitmap bgImageDiscover;

        PictureBox ptbOverlayDiscover = new PictureBox();
        LockBitmap workingOverlayDiscover;
        Bitmap overlayDiscover;

        bool[,] doorsDiscover;
        bool[,] roomsDiscover;
        bool[,] discoveredDiscover;
        bool[,] clickableDoorsDiscover;


        public frmDiscover()
        {
            InitializeComponent();
        }

        private void btnSaveCreate_Click(object sender, EventArgs e)
        {
            if (!somethingOpenedCreate || sfdSaveCreate.ShowDialog() == DialogResult.Cancel) return;
            Bitmap temp = new Bitmap(outputCreate);
            LockBitmap lockTemp = new LockBitmap(temp);

            lockTemp.LockBits();
            for (int i = 0; i < temp.Width; i++)
                for (int j = 0; j < temp.Height; j++)
                {
                    Color c = lockTemp.GetPixel(i, j);
                    if (c.A != 0) lockTemp.SetPixel(i, j, Color.FromArgb(255, c.R, c.G, c.B));
                }

            lockTemp.UnlockBits();
            temp.Save(sfdSaveCreate.FileName, ImageFormat.Png);
        }
        private void btnOpenCreate_Click(object sender, EventArgs e)
        {
            if (ofdOpenCreate.ShowDialog() == DialogResult.Cancel || ofdOpenPNGCreate.ShowDialog() == DialogResult.Cancel) return;

            somethingOpenedCreate = true;

            bgImageCreate = new Bitmap(ofdOpenPNGCreate.FileName);

            outputCreate = new Bitmap(ofdOpenCreate.FileName);

            if (bgImageCreate.Size != outputCreate.Size)
            {
                MessageBox.Show("File error: size mismatch. Please select the DDF and associated PNG.");
                return;
            }

            workingOutputCreate = new LockBitmap(outputCreate);

            workingOutputCreate.LockBits();
            for (int i = 0; i < outputCreate.Width; i++)
                for (int j = 0; j < outputCreate.Height; j++)
                {
                    Color c = workingOutputCreate.GetPixel(i, j);
                    if (c.A != 0) workingOutputCreate.SetPixel(i, j, Color.FromArgb(127, c.R, c.G, c.B));
                }

            workingOutputCreate.UnlockBits();

            ptbCreate.BackgroundImage = bgImageCreate;
            ptbCreate.Image = outputCreate;
        }
        private void BtnNewCreate_Click(object sender, EventArgs e)
        {
            if (ofdNewCreate.ShowDialog() == DialogResult.Cancel) return;

            somethingOpenedCreate = true;

            bgImageCreate = new Bitmap(ofdNewCreate.FileName);

            outputCreate = new Bitmap(bgImageCreate.Width,bgImageCreate.Height);
            workingOutputCreate = new LockBitmap(outputCreate);

            ptbCreate.BackgroundImage = bgImageCreate;
            ptbCreate.Image = outputCreate;

        }

        Point downCreate, upCreate;
        private void MouseDownCreate(object sender, EventArgs e)
        {
            if (!somethingOpenedCreate) return;

            Point p = ptbCreate.PointToClient(Cursor.Position);
            int x = bgImageCreate.Width * p.X / ptbCreate.Width;
            int y = bgImageCreate.Height * p.Y / ptbCreate.Height;

            downCreate = new Point(x,y);

            if (rdbStrokeCreate.Checked)
            {
                tmrStrokeCreate.Enabled = true;
                TmrStrokeCreate_Tick(tmrStrokeCreate, e);
            }
        }

        private void MouseUpCreate(object sender, EventArgs e)
        {
            if (!somethingOpenedCreate) return;

            Point p = ptbCreate.PointToClient(Cursor.Position);
            int x = bgImageCreate.Width * p.X / ptbCreate.Width;
            int y = bgImageCreate.Height * p.Y / ptbCreate.Height;

            upCreate = new Point(x, y);

            Color c;

            if (rdbRoomCreate.Checked) c = Color.FromArgb(127, 0, 255, 0);
            else if (rdbDoorCreate.Checked) c = Color.FromArgb(127, 255, 0, 0);
            else if (rdbStartCreate.Checked) c = Color.FromArgb(127, 0, 0, 255);
            else if (rdbEraseCreate.Checked) c = Color.FromArgb(0, 0, 0, 0);
            else c = Color.FromArgb(0, 0, 0, 0);

            Point first = new Point(Math.Max(0,Math.Min(downCreate.X, upCreate.X)), Math.Max(0,Math.Min(downCreate.Y, upCreate.Y)));
            Point last = new Point(Math.Min(outputCreate.Width-1,Math.Max(downCreate.X, upCreate.X)), Math.Min(outputCreate.Height - 1, Math.Max(downCreate.Y, upCreate.Y)));

            workingOutputCreate.LockBits();

            if (rdbRectCreate.Checked)
                for (int i = first.X; i <= last.X; i++)
                    for (int j = first.Y; j <= last.Y; j++)
                        workingOutputCreate.SetPixel(i, j, c);

            workingOutputCreate.UnlockBits();

            tmrStrokeCreate.Enabled = false;
            ptbCreate.Refresh();
        }


        private void TmrStrokeCreate_Tick(object sender, EventArgs e)
        {
            Color c;

            if (rdbRoomCreate.Checked) c = Color.FromArgb(127, 0, 255, 0);
            else if (rdbDoorCreate.Checked) c = Color.FromArgb(127, 255, 0, 0);
            else if (rdbStartCreate.Checked) c = Color.FromArgb(127, 0, 0, 255);
            else if (rdbEraseCreate.Checked) c = Color.FromArgb(0, 0, 0, 0);
            else c = Color.FromArgb(0, 0, 0, 0);

            Point p = ptbCreate.PointToClient(Cursor.Position);
            int x = bgImageCreate.Width * p.X / ptbCreate.Width;
            int y = bgImageCreate.Height * p.Y / ptbCreate.Height;

            float rad = (float)nudDialCreate.Value / 2;

            //workingOutputCreate.LockBits();
            SolidBrush brush = new SolidBrush(c);
            Graphics g = Graphics.FromImage(outputCreate);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            g.FillEllipse(brush, x-rad, y-rad, (float)nudDialCreate.Value, (float)nudDialCreate.Value);

            Pen pen = new Pen(brush, (float)nudDialCreate.Value);
            g.DrawLine(pen,new Point(downCreate.X,downCreate.Y),new Point(x,y));

            ptbCreate.Refresh();
            downCreate = new Point(x, y);
        }

        private void MouseClickDiscover(object sender, EventArgs e) 
        {
            if (!somethingOpenedDiscover) return;

            Point p = ptbDiscover.PointToClient(Cursor.Position);
            int x = bgImageDiscover.Width * p.X / ptbDiscover.Width;
            int y = bgImageDiscover.Height * p.Y / ptbDiscover.Height;

            Console.WriteLine(clickableDoorsDiscover[x, y]);

            if (clickableDoorsDiscover[x,y]) FloodFill(new Point(x,y));
        }

        Random rand = new Random();
        private void LoadDiscover()
        {
            //assign colored spaces to arrays for doors and rooms, and unclear bitmap fog for start
            if (ofdOpenDiscover.ShowDialog() == DialogResult.Cancel || ofdOpenPNGDiscover.ShowDialog() == DialogResult.Cancel) return;

            somethingOpenedDiscover = true;

            bgImageDiscover = new Bitmap(ofdOpenPNGDiscover.FileName);

            outputDiscover = new Bitmap(ofdOpenDiscover.FileName);

            if (bgImageDiscover.Size != outputDiscover.Size)
            {
                MessageBox.Show("File error: size mismatch. Please select the DDF and associated PNG.");
                return;
            }

            doorsDiscover = new bool[bgImageDiscover.Width, bgImageDiscover.Height];
            roomsDiscover = new bool[bgImageDiscover.Width, bgImageDiscover.Height];
            discoveredDiscover = new bool[bgImageDiscover.Width, bgImageDiscover.Height];
            clickableDoorsDiscover = new bool[bgImageDiscover.Width, bgImageDiscover.Height];

            workingOutputDiscover = new LockBitmap(outputDiscover);
            workingBackgroundDiscover = new LockBitmap(bgImageDiscover);

            workingBackgroundDiscover.LockBits();
            workingOutputDiscover.LockBits();
            for (int i = 0; i < outputDiscover.Width; i++)
                for (int j = 0; j < outputDiscover.Height; j++)
                {
                    int r1 = rand.Next(170, 235);
                    Color c = workingOutputDiscover.GetPixel(i, j);
                    if (c.R != 0 && workingBackgroundDiscover.GetPixel(i, j).A != 0) doorsDiscover[i, j] = true;
                    if (c.G != 0 && workingBackgroundDiscover.GetPixel(i, j).A != 0) roomsDiscover[i, j] = true;
                    if (c.B != 0 && workingBackgroundDiscover.GetPixel(i, j).A != 0)
                    {
                        workingOutputDiscover.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                        discoveredDiscover[i, j] = true;
                    }
                    else workingOutputDiscover.SetPixel(i, j, Color.FromArgb(255, r1, r1, r1));
                }
            workingOutputDiscover.UnlockBits();
            workingBackgroundDiscover.UnlockBits();

            for (int i = 0; i < discoveredDiscover.GetLength(0); i++)
                for (int j = 0; j < discoveredDiscover.GetLength(1); j++)
                    if (discoveredDiscover[i, j] && (doorsDiscover[i + 1, j] || doorsDiscover[i - 1, j] || doorsDiscover[i, j + 1] || doorsDiscover[i, j - 1]))
                    {
                        FloodFill(new Point(i + 1, j), 2);
                        FloodFill(new Point(i - 1, j), 2);
                        FloodFill(new Point(i, j + 1), 2);
                        FloodFill(new Point(i, j - 1), 2);
                    }

            ptbDiscover.BackgroundImage = bgImageDiscover;
            ptbDiscover.Image = outputDiscover;

            ptbOverlayDiscover = new PictureBox();
            ptbOverlayDiscover.BackColor = Color.Transparent;
            ptbOverlayDiscover.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbDiscover.Controls.Add(ptbOverlayDiscover);
            ptbOverlayDiscover.Visible = true;
            ptbOverlayDiscover.Location = new Point(0,0);
            ptbOverlayDiscover.Width = ptbDiscover.Width * 2;
            ptbOverlayDiscover.Height = ptbDiscover.Height;
            ptbOverlayDiscover.Click += MouseClickDiscover;

            overlayDiscover = new Bitmap(outputDiscover.Width*2,outputDiscover.Height);
            workingOverlayDiscover = new LockBitmap(overlayDiscover);

            workingOverlayDiscover.LockBits();
            for (int i = 0; i < overlayDiscover.Width; i++)
                for (int j = 0; j < overlayDiscover.Height; j++)
                {
                    int r0 = rand.Next(50,100);
                    int r1 = rand.Next(140, 240);
                    workingOverlayDiscover.SetPixel(i, j, Color.FromArgb(r0, r1, r1, r1));
                }
            workingOverlayDiscover.UnlockBits();

            ptbOverlayDiscover.Image = overlayDiscover;
            ptbOverlayDiscover.BringToFront();
            ptbOverlayDiscover.Refresh();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            tmrAnimationDiscover.Enabled = true;
        }
        private void tmrAnimationDiscover_Tick(object sender, EventArgs e)
        {
            ptbOverlayDiscover.Invalidate();
            int x = ptbOverlayDiscover.Location.X - Math.Max(ptbOverlayDiscover.Width / 8000,1);
            if (x < -overlayDiscover.Width / 2)
                ptbOverlayDiscover.Location = new Point(0, ptbOverlayDiscover.Location.Y);
            else
                ptbOverlayDiscover.Location = new Point(x, ptbOverlayDiscover.Location.Y);

            workingOverlayDiscover.LockBits();
            /*for (int i = 0; i < overlayDiscover.Width; i++)
                for (int j = 0; j < overlayDiscover.Height; j++)
                {
                    int r0 = rand.Next(0, 100);
                    if (r0 < 5)
                    {
                        int r1 = rand.Next(100, 135);
                        workingOverlayDiscover.SetPixel(i, j, Color.FromArgb(50, r1, r1, r1));
                    }
                }*/
            workingOverlayDiscover.UnlockBits();

            ptbDiscover.Update();
        }
        private void FloodFill(Point pt, int clearDoor = 0)
        {
            workingBackgroundDiscover.LockBits();
            workingOutputDiscover.LockBits();
            FloodFillNoLock(pt,clearDoor);
            workingOutputDiscover.UnlockBits();
            workingBackgroundDiscover.UnlockBits();
            ptbDiscover.Refresh();
        }
        private void FloodFillNoLock(Point pt, int clearDoor = 0)
        {
            if (discoveredDiscover[pt.X, pt.Y] && !clickableDoorsDiscover[pt.X, pt.Y]) return;
            Color replacementColor = Color.FromArgb(0, 0, 0, 0);
            LockBitmap bmp = workingOutputDiscover;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(pt);

            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();
                if (a.X < bmp.Width && a.X > 0 &&
                        a.Y < bmp.Height && a.Y > 0)//make sure we stay within bounds
                {

                    if (clearDoor == 0 && doorsDiscover[a.X,a.Y])
                    {
                        if (workingBackgroundDiscover.GetPixel(a.X,a.Y).A != 0)bmp.SetPixel(a.X, a.Y, replacementColor);
                        discoveredDiscover[a.X, a.Y] = true;
                        doorsDiscover[a.X, a.Y] = false;
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                    else if (clearDoor == 0 && clickableDoorsDiscover[a.X, a.Y])
                    {
                        if (workingBackgroundDiscover.GetPixel(a.X, a.Y).A != 0) bmp.SetPixel(a.X, a.Y, replacementColor);
                        discoveredDiscover[a.X, a.Y] = true;
                        clickableDoorsDiscover[a.X, a.Y] = false;
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                    else if (clearDoor == 0 && roomsDiscover[a.X, a.Y])
                    {
                        FloodFillNoLock(new Point(a.X, a.Y), 1);
                    }
                    else if (clearDoor == 1 && (doorsDiscover[a.X, a.Y] || roomsDiscover[a.X,a.Y]))
                    {
                        if (workingBackgroundDiscover.GetPixel(a.X, a.Y).A != 0) bmp.SetPixel(a.X, a.Y, replacementColor);
                        if (roomsDiscover[a.X, a.Y])
                        {
                            discoveredDiscover[a.X, a.Y] = true;
                            roomsDiscover[a.X, a.Y] = false;
                            pixels.Push(new Point(a.X - 1, a.Y));
                            pixels.Push(new Point(a.X + 1, a.Y));
                            pixels.Push(new Point(a.X, a.Y - 1));
                            pixels.Push(new Point(a.X, a.Y + 1));
                        }
                        else if (doorsDiscover[a.X, a.Y])
                        {
                            //discoveredDiscover[a.X, a.Y] = true;
                            //doorsDiscover[a.X, a.Y] = false;
                            //clickableDoorsDiscover[a.X, a.Y] = true;
                            FloodFillNoLock(new Point(a.X, a.Y), 2);
                        }
                    }
                    else if (clearDoor == 2 && (doorsDiscover[a.X, a.Y]) )
                    {
                        if (workingBackgroundDiscover.GetPixel(a.X, a.Y).A != 0) bmp.SetPixel(a.X, a.Y, replacementColor);
                        discoveredDiscover[a.X, a.Y] = true;
                        doorsDiscover[a.X, a.Y] = false;
                        clickableDoorsDiscover[a.X, a.Y] = true;
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                }
            }
        }

        private void btnOpenDiscover_Click(object sender, EventArgs e)
        {
            LoadDiscover();
        }

        private void FrmDiscover_Load(object sender, EventArgs e)
        {
            ptbCreate.MouseDown += MouseDownCreate;
            ptbCreate.MouseUp += MouseUpCreate;
            ptbDiscover.Click += MouseClickDiscover;
            this.Resize += FormResize;
            this.KeyPress += Escape;
            FormResize(sender, e);
        }
        private void Escape(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                isCreate = !isCreate;
                FormResize(sender,e);
            }
            if (e.KeyChar == (char)Keys.D1)
            {
                if (this.FormBorderStyle != FormBorderStyle.None) this.FormBorderStyle = FormBorderStyle.None;
                else this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void ofdOpenPNGCreate_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void FormResize(object sender, EventArgs e)
        {
            if (isCreate)
            {
                pnlDiscover.Visible = false;
                pnlCreate.Visible = true;
                pnlCreate.Dock = DockStyle.Fill;

                pnlControlsCreate.Location = new Point(0, 0);
                pnlControlsCreate.Width = pnlCreate.Width;
                pnlControlsCreate.Height = pnlCreate.Height * 9 / 100;

                ptbCreate.Location = new Point(0, pnlCreate.Height * 10 / 100);
                ptbCreate.Width = pnlCreate.Width;
                ptbCreate.Height = pnlCreate.Height * 90 / 100;
            }
            else
            {
                pnlCreate.Visible = false;
                pnlDiscover.Visible = true;
                pnlDiscover.Dock = DockStyle.Fill;

                btnOpenDiscover.Width = pnlDiscover.Width * 10 / 100;
                btnOpenDiscover.Height = pnlDiscover.Height * 4 / 100;
                btnOpenDiscover.Location = new Point(pnlDiscover.Width / 2 - btnOpenDiscover.Width / 2, pnlDiscover.Height / 200);

                ptbDiscover.Location = new Point(0, pnlDiscover.Height * 5 / 100);
                ptbDiscover.Width = pnlDiscover.Width;
                ptbDiscover.Height = pnlDiscover.Height * 95 / 100;

                ptbOverlayDiscover.Width = ptbDiscover.Width * 2;
                ptbOverlayDiscover.Height = ptbDiscover.Height;
            }
        }
    }
    public class LockBitmap
    {
        Bitmap source = null;
        IntPtr Iptr = IntPtr.Zero;
        BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LockBitmap(Bitmap source)
        {
            this.source = source;
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                // Get width and height of bitmap
                Width = source.Width;
                Height = source.Height;

                // get total locked pixels count
                int PixelCount = Width * Height;

                // Create rectangle to lock
                Rectangle rect = new Rectangle(0, 0, Width, Height);

                // get source bitmap pixel format size
                Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }

                // Lock bitmap and return bitmap data
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite,
                                             source.PixelFormat);

                // create byte array to copy pixel values
                int step = Depth / 8;
                Pixels = new byte[PixelCount * step];
                Iptr = bitmapData.Scan0;

                // Copy data from pointer to array
                Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits()
        {
            try
            {
                // Copy data from byte array to pointer
                Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

                // Unlock bitmap data
                source.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                byte a = Pixels[i + 3]; // a
                clr = Color.FromArgb(a, r, g, b);
            }
            if (Depth == 24) // For 24 bpp get Red, Green and Blue
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                clr = Color.FromArgb(r, g, b);
            }
            if (Depth == 8)
            // For 8 bpp get color value (Red, Green and Blue values are the same)
            {
                byte c = Pixels[i];
                clr = Color.FromArgb(c, c, c);
            }
            return clr;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            }
            if (Depth == 24) // For 24 bpp set Red, Green and Blue
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            }
            if (Depth == 8)
            // For 8 bpp set color value (Red, Green and Blue values are the same)
            {
                Pixels[i] = color.B;
            }
        }
    }
}
