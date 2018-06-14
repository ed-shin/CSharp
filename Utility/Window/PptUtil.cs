using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace Utiltiy.Window
{
    public class PptUtil
    {
        private Microsoft.Office.Interop.PowerPoint.Application _app;
        private Presentation _presentation;
        private Slides _slides;

        public int SlideCount
        {
            get
            {
                if (_presentation == null)
                    return -1;

                return _slides.Count;
            }
        }

        public PptUtil()
        {
            _app = new Microsoft.Office.Interop.PowerPoint.Application();
        }

        public void OpenNew(bool visible = false)
        {
            _presentation = visible ?
                _app.Presentations.Add(MsoTriState.msoTrue):
                _app.Presentations.Add(MsoTriState.msoFalse);

            _slides = _presentation.Slides;
        }

        public void OpenExists(string path, bool readOnly = false, bool visible = false)
        {
            MsoTriState readOnlyState = readOnly ? MsoTriState.msoTrue : MsoTriState.msoFalse;
            MsoTriState visibleState = visible ? MsoTriState.msoTrue : MsoTriState.msoFalse;

            _presentation = _app.Presentations.Open(path, readOnlyState, MsoTriState.msoTrue, visibleState);
        }

        public void CopySlide(int idx)
        {
            _slides[idx].Copy();
        }

        public void PasteSlide(int idx, Slide pasteSlide)
        {
            _slides.Paste(idx).Design = pasteSlide.Design;
        }

        public void AddBlankSlide()
        {
            CustomLayout customLayout = _presentation.SlideMaster.CustomLayouts[PpSlideLayout.ppLayoutText];
            Slide slide = _slides.AddSlide(_slides.Count + 1, customLayout);

            int cnt = slide.Shapes.Count;
            for (int i = 0; i < cnt; i++)
            {
                slide.Shapes[1].Delete();
            }
        }

        public void SetTableText(int slideIdx, int row, int col, string text, int tableShapeIdx)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Microsoft.Office.Interop.PowerPoint.Shape shape = _slides[slideIdx].Shapes[tableShapeIdx];

            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.Text = text;
            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Name = "Verdana";
            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Size = 8;
        }

        public void SetTableHyperLink(int slideIdx, int row, int col, string text, string address, int tableShapeIdx)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Microsoft.Office.Interop.PowerPoint.Shape shape = _slides[slideIdx].Shapes[tableShapeIdx];

            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.Text = text;
            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Name = "Verdana";
            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Size = 8;
            shape.Table.Cell(row, col).Shape.TextFrame.TextRange.ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address = address;
        }

        public void SetTableImage(int slideIdx, int row, int col, Image img, int tableShapeIdx)
        {
            if (img == null)
                return;

            Microsoft.Office.Interop.PowerPoint.Shapes shapes = _slides[slideIdx].Shapes;
            Microsoft.Office.Interop.PowerPoint.Shape shape = shapes[tableShapeIdx];

            string tempPath = @"temp.jpg";
            if (File.Exists(tempPath))
                File.Delete(tempPath);

            img.Save(tempPath, ImageFormat.Jpeg);

            int margin = 5;
            Microsoft.Office.Interop.PowerPoint.Shape tableShape = shape.Table.Cell(row, col).Shape;
            shapes.AddPicture(tempPath, MsoTriState.msoFalse, MsoTriState.msoTrue, tableShape.Left + margin, tableShape.Top + margin, tableShape.Width - margin, tableShape.Height - margin);
        }


        public void SetTableIndex(int slideIdx, int tableShapeIdx)
        {
            Microsoft.Office.Interop.PowerPoint.Shape oShape = _slides[slideIdx].Shapes[tableShapeIdx];

            for (int iRow = 1; iRow <= oShape.Table.Rows.Count; iRow++)
            {
                for (int iColumn = 1; iColumn <= oShape.Table.Columns.Count; iColumn++)
                {
                    oShape.Table.Cell(iRow, iColumn).Shape.TextFrame.TextRange.Text = Convert.ToString(iRow) + "/" + Convert.ToString(iColumn);
                    oShape.Table.Cell(iRow, iColumn).Shape.TextFrame.TextRange.Font.Name = "Verdana";
                    oShape.Table.Cell(iRow, iColumn).Shape.TextFrame.TextRange.Font.Size = 8;
                }
            }
        }


        public void Save(string path)
        {
            _presentation.SaveAs(path, PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
        }

        public void Dispose()
        {
            _presentation.Close();
            _app.Quit();
        }
    }
}
