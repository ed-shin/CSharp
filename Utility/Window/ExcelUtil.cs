using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace Utiltiy.Window
{
    /// <summary>
    /// MS Excel Utility
    /// (referece. com object library)
    /// </summary>
    public class ExcelUtil : IDisposable
    {
        private Microsoft.Office.Interop.Excel.Application _app;
        private Workbook _wb;
        private Worksheet _ws;

        public int UsedRows
        {
            get
            {
                if (_ws == null)
                    return -1;
                
                return this.UsedValue.GetLength(0);
            }
        }

        public int UsedColumns
        {
            get
            {
                if (_ws == null)
                    return -1;
                
                return this.UsedValue.GetLength(1);
            }
        }

        public object[,] UsedValue
        {
            get
            {
                if (_ws == null)
                    return null;

                return _ws.UsedRange.Value;
            }
        }

        public ExcelUtil()
        {
            _app = new Microsoft.Office.Interop.Excel.Application();
        }

        public bool Open(string path)
        {   
            try
            {
                if (_wb != null || _ws != null)
                    throw new AccessViolationException(); 

                _wb = _app.Workbooks.Open(path);
                _ws = _wb.ActiveSheet;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }

            return true;
        }

        public void Close()
        {
            ReleaseExcelObject(_ws);
            ReleaseExcelObject(_wb);
        }

        public static Image getImage(Range cell)
        {
            Image img = null;

            try
            {
                //cell.Value is image??
                foreach (Microsoft.Office.Interop.Excel.Shape shape in cell.Worksheet.Shapes)
                {
                    if (shape.Type == MsoShapeType.msoPicture)
                    {
                        double dErr = 0.5;
                        double shapeLeft = (double)shape.Left - dErr;
                        double shapeTop = (double)shape.Top - dErr;
                        double shapeRight = (double)shape.Width + shapeLeft + dErr;
                        double shapeBotton = (double)shape.Height + shapeTop + dErr;

                        if (shapeLeft >= cell.Left && shapeTop >= cell.Top && shapeRight <= cell.Left + cell.Width && shapeBotton <= cell.Top + cell.Height)
                        {
                            shape.ScaleWidth(5.0f, MsoTriState.msoTrue);    //for resolution
                            shape.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                            img = Clipboard.GetImage();
                            Clipboard.Clear();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return img;
        }

        public void Dispose()
        {
            _app.Quit();

            ReleaseExcelObject(_ws);
            ReleaseExcelObject(_wb);
            ReleaseExcelObject(_app);
        }

        public void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
