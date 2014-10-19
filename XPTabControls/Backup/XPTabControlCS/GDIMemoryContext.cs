using System;
using System.Drawing;

namespace VSControls
{
    internal class GDIMemoryContext : IDisposable
    {
        private IntPtr fDC, fBitmap, fStockMonoBmp;

        private int fWidth, fHeight;
        
        public GDIMemoryContext(Graphics compatibleTo, int width, int height)
        {
            if (compatibleTo == null || width <= 0 || height <= 0) throw new ArgumentException("Arguments are unacceptable");
            IntPtr tmp = compatibleTo.GetHdc();
            bool failed = true;
            do
            {
                if ((fDC = NativeMethods.CreateCompatibleDC(tmp)) == IntPtr.Zero) break;
                if ((fBitmap = NativeMethods.CreateCompatibleBitmap(tmp, width, height)) == IntPtr.Zero)
                {
                    NativeMethods.DeleteDC(fDC); break;
                }
                fStockMonoBmp = NativeMethods.SelectObject(fDC, fBitmap);
                if (fStockMonoBmp == IntPtr.Zero)
                {
                    NativeMethods.DeleteObject(fBitmap);
                    NativeMethods.DeleteDC(fDC);
                }
                else failed = false;
            } while (false);
            compatibleTo.ReleaseHdc(tmp);
            if (failed) throw new SystemException("GDI error occured while creating context");
            this.fWidth = width; this.fHeight = height;
        }

        ~GDIMemoryContext()
        {
            DisposeInternal();
        }

        private bool notDisposed = true;

        private void DisposeInternal()
        {
            if (notDisposed)
            {
                NativeMethods.SelectObject(fDC, fStockMonoBmp);//return stock bitmap home
                NativeMethods.DeleteDC(fDC);//deletion of memory context
                fDC = fStockMonoBmp = IntPtr.Zero;
                NativeMethods.DeleteObject(fBitmap);//destruction of created bitmap
                fBitmap = IntPtr.Zero;
                notDisposed = false;
            }
        }
        
        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }

        public Graphics CreateGraphics()
        {
            return this.fDC != IntPtr.Zero ? Graphics.FromHdc(this.fDC) : null;
        }

        public void FlipVertical()
        {
            if (this.fDC != IntPtr.Zero)
                NativeMethods.StretchBlt(fDC, 0, fHeight - 1, fWidth, -fHeight, fDC, 0, 0, fWidth, fHeight, NativeMethods.SRCCOPY);
        }

        public int Width { get { return this.fWidth; } }
        public int Height { get { return this.fHeight; } }

        public uint GetPixel(int x, int y)
        {
            if (fDC != IntPtr.Zero) return NativeMethods.GetPixel(fDC, x, y);
            else throw new ObjectDisposedException(null, "GDI context seems to be disposed.");
        }

        public void SetPixel(int x, int y, uint value)
        {
            if (fDC != IntPtr.Zero) NativeMethods.SetPixel(fDC, x, y, value);
            else throw new ObjectDisposedException(null, "GDI context seems to be disposed.");
        }

        public void DrawContextClipped(Graphics drawTo, Rectangle drawRect)
        {
            do
            {
                if (drawTo == null || fDC == IntPtr.Zero) break;
                IntPtr tmpDC = drawTo.GetHdc();
                if (tmpDC == IntPtr.Zero) break;

                NativeMethods.BitBlt(tmpDC, drawRect.Left, drawRect.Top, drawRect.Width, drawRect.Height,
                    fDC, 0, 0, NativeMethods.SRCCOPY);

                drawTo.ReleaseHdc(tmpDC);
            } while (false);
        }
    }
}