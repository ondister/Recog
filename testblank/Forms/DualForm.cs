using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp;

namespace Recog.Forms
{



    public class DualForm
    {
        private PdfDocument s_document;
        private PdfPage _page;
        private XGraphics gfx;



        public void Create(string filename, int qcount, int cellsinq, List<string> cellslabels, int rowscount)
        {

            s_document = new PdfDocument();
            _page = new PdfPage();
            _page.Orientation = PageOrientation.Landscape;
            _page.Size = PageSize.A4;
            s_document.Pages.Add(_page);
            gfx = XGraphics.FromPdfPage(_page);

            DrawCutLine();


            PdfRectangle leftpage = new PdfRectangle(new XPoint(0, 0), new XPoint(_page.Width / 2, _page.Height));
            PdfRectangle rightpage = new PdfRectangle(new XPoint(_page.Width / 2, 0), new XPoint(_page.Width, _page.Height));

            //left part
            float leftcenter = (float)(_page.Width / 4) * 1f;
            DrawCenterMarker(7, leftcenter);
            DrawSideMarker(7, 10, 10);
            DrawSideMarker(7, XUnit.FromPoint(leftpage.Width).Millimeter-10, 10);
            DrawSideMarker(7, 10, XUnit.FromPoint(leftpage.Height).Millimeter - 10);
            DrawSideMarker(7, XUnit.FromPoint(leftpage.Width).Millimeter - 10, XUnit.FromPoint(leftpage.Height).Millimeter - 10);

            AddFields(leftpage);

            AddQuestions(qcount, cellsinq, cellslabels, rowscount, leftpage);

            //right part
            float rigthcenter = (float)(_page.Width / 4) * 3f;
            DrawCenterMarker(7, rigthcenter);
            DrawSideMarker(7, XUnit.FromPoint(rightpage.X1).Millimeter+10, XUnit.FromPoint(rightpage.Y1).Millimeter+10);
            DrawSideMarker(7, XUnit.FromPoint(rightpage.X2).Millimeter - 10, XUnit.FromPoint(rightpage.Y1).Millimeter + 10);
            DrawSideMarker(7, XUnit.FromPoint(rightpage.X1).Millimeter + 10, XUnit.FromPoint(rightpage.Y2).Millimeter - 10);
            DrawSideMarker(7, XUnit.FromPoint(rightpage.X2).Millimeter - 10, XUnit.FromPoint(rightpage.Y2).Millimeter - 10);

            AddFields(rightpage);
            AddQuestions(qcount, cellsinq, cellslabels, rowscount, rightpage);

           


            // Save the s_document...
            s_document.Save(filename);
            // ...and start a viewer
            Process.Start(filename);


        }

        private void DrawCutLine()
        {
            XPen pen = new XPen(XColors.Black, 0.2);
            pen.DashStyle = XDashStyle.Dot;
            //pen.LineCap = XLineCap.Round;
            //pen.LineJoin = XLineJoin.Bevel;
            XUnit midx = _page.Width / 2;
            XPoint[] points =
              new XPoint[] { new XPoint(midx, 0),
                  new XPoint(midx, _page.Height) };
            gfx.DrawLines(pen, points);
        }


        private void AddQuestions(int qcount, int cellsinq, List<string> cellslabels, int rowscnt,PdfRectangle rect)
        {

            int rowhight = 7;
            int rowscount = rowscnt;//Convert.ToInt32((_page.Height.Millimeter - 80d) / 7d);
            int colscount = qcount / rowscount;

            int mincolwidth = cellsinq * (4 + 3);

           // int colsinterval = Convert.ToInt32(((_page.Width.Millimeter - 40d) - (mincolwidth * colscount)) / colscount);

            int colsinterval = Convert.ToInt32(((XUnit.FromPoint(rect.X2-rect.X1).Millimeter - 40d) - (mincolwidth * colscount)) / colscount);

            colsinterval = colsinterval < 8 ? 8 : colsinterval;
            int colwidgth = cellsinq * (4 + 3) + colsinterval;

            int maxy = 0;
            int initx = 15 + (int)XUnit.FromPoint(rect.X1).Millimeter;
            int inity = 55;

            int x = initx;

            int number = 1;

            int rr = 0;
            int y = inity;
            for (int question = 0; question < qcount; question++)
            {
                if (rr != 0)
                {
                    DrawQuestion(number, cellsinq, x, y);
                }
                else
                {
                    DrawQuestion(number, cellsinq, x, y, cellslabels);
                }
                number++;
                rr++;
                y = y + rowhight;
                if (y > maxy) { maxy = y; }
                if (rr == rowscount)
                {
                    rr = 0;
                    x += colwidgth;
                    y = inity;
                }


            }

            this.DrawLine(0, (float)_page.Width.Millimeter, maxy);
            this.DrawLeftString("Добровольность тестирования и достоверность результатов подтверждаю:_______________", initx-10, maxy + 1, 60, 10);
        }


        private void DrawQuestion(int number, int cellscount, int fromleftmm, int fromtopmm, List<string> labels = null)
        {
            float cellsize = 3.5f;
            float offset = 3.5f;
            for (int cell = 0; cell < cellscount; cell++)
            {
                this.DrawRectangle(cellsize, fromleftmm + (cell * (offset + cellsize)), fromtopmm);
            }
            DrawLeftString(number.ToString(), fromleftmm - 8, fromtopmm - 1, 3, 8);

            if (labels != null)
            {
                if (labels.Count == cellscount)
                {
                    for (int cell = 0; cell < cellscount; cell++)
                    {
                        this.DrawLeftString(labels[cell], fromleftmm + (cell * (offset + cellsize) - 2), fromtopmm - cellsize - (int)cellsize / 2 - offset, 5, 10);
                    }
                }
            }

        }

        private void AddFields(PdfRectangle rect)
        {
            float offset = (float)XUnit.FromPoint(rect.X1).Millimeter;
            XPdfFontOptions o = new XPdfFontOptions(PdfFontEncoding.Unicode);
            XFont font = new XFont("Times New Roman", 14, XFontStyle.Regular, o);

            gfx.DrawString("Бланк фиксации результатов теста", font, XBrushes.Black,
              new XRect(rect.X1, rect.Y1+XUnit.FromMillimeter(17).Point, rect.X2-rect.X1, 5),
              XStringFormats.Center);


            this.DrawLeftString("Подразделение_______________", 10 + offset, 25, 60, 10); this.DrawLeftString("Ф.И.О._____________________________________", 70 + offset, 25, 90, 10); 
            this.DrawLeftString("Дата рождения_______________", 10 + offset, 30, 60, 10);
            this.DrawLeftString("Образование_________________", 10 + offset, 35, 30, 10); this.DrawLeftString("Дата тестирования__________________________", 70 + offset, 35, 30, 10);
            
            this.DrawLeftString("M", 10 + offset, 40, 5, 14); this.DrawRectangle(4, 17 + offset, 42); this.DrawLeftString("Ж", 20 + offset, 40, 5, 14); this.DrawRectangle(4, 27 + offset, 42); this.DrawLeftString("Пример заполнения бланка", 40 + offset, 40, 50, 10); this.DrawRectangle(4, 85 + offset, 42); this.DrawLeftString("Х", 83 + offset, 40, 5, 14);
            
            this.DrawLine(0, (int)_page.Width.Millimeter, 45);
        }

        private void DrawLine(float begxmm, float endxmm, float fromtopmm)
        {
            XPen pen = new XPen(XColors.Black, 1);
            pen.LineCap = XLineCap.Round;
            pen.LineJoin = XLineJoin.Bevel;
            XPoint[] points =
              new XPoint[] { new XPoint(XUnit.FromMillimeter(begxmm).Point, XUnit.FromMillimeter(fromtopmm).Point), new XPoint(XUnit.FromMillimeter(endxmm).Point, XUnit.FromMillimeter(fromtopmm).Point) };
            gfx.DrawLines(pen, points);
        }



        private void DrawRectangle(float sizemm, float mmfromleft, float mmfromtop)
        {
            XUnit _size = XUnit.FromMillimeter(sizemm);
            //  XGraphics gfx = XGraphics.FromPdfPage(_page);
            XPen pen = new XPen(XColors.Black, 1);
            XUnit _x = XUnit.FromMillimeter(mmfromleft);
            XUnit _y = XUnit.FromMillimeter(mmfromtop);
            _x.Point = _x.Point - (_size.Point / 2d);
            _y.Point = _y.Point - (_size.Point / 2d);

            gfx.DrawRectangle(pen, XBrushes.White, _x, _y, _size.Point, _size.Point);
        }


        private void DrawLeftString(string text, float fromleftmm, float fromtopmm, float widthmm, float fontsize)
        {
            XPdfFontOptions o = new XPdfFontOptions(PdfFontEncoding.Unicode);
            XFont font1 = new XFont("Times New Roman", fontsize, XFontStyle.Regular, o);
            gfx.DrawString(text, font1, XBrushes.Black,
                 new XRect(XUnit.FromMillimeter(fromleftmm).Point, XUnit.FromMillimeter(fromtopmm).Point, XUnit.FromMillimeter(widthmm).Point, 5),
                 XStringFormats.TopLeft);
        }


        private void DrawSideMarker(int size, double mmfromleft, double mmfromtop)
        {
            XUnit _size = XUnit.FromMillimeter(size);
            //  XGraphics gfx = XGraphics.FromPdfPage(_page);
            XPen pen = new XPen(XColors.Black, 2);
            XUnit _x = XUnit.FromMillimeter(mmfromleft);
            XUnit _y = XUnit.FromMillimeter(mmfromtop);
            _x.Point = _x.Point - (_size.Point / 2d);
            _y.Point = _y.Point - (_size.Point / 2d);

            gfx.DrawRectangle(pen, XBrushes.White, _x, _y, _size.Point, _size.Point);

            XPen intpen = new XPen(XColors.Black, 2);
            XUnit _intsize = new XUnit(_size.Point / 2d);
            XUnit _intx = XUnit.FromMillimeter(mmfromleft).Point - (_intsize.Point / 2d);
            XUnit _inty = XUnit.FromMillimeter(mmfromtop).Point - (_intsize.Point / 2d); ;
            gfx.DrawRectangle(pen, XBrushes.Black, _intx, _inty, _intsize.Point, _intsize.Point);
        }

        private void DrawCenterMarker(int size, float center)
        {
            XUnit _size = XUnit.FromMillimeter(size);
            XPen pen = new XPen(XColors.Black, 2);
            XUnit _x = XUnit.FromPoint(center);
            XUnit _y = XUnit.FromMillimeter(10);
            _x.Point = _x.Point - (_size.Point / 2d);
            _y.Point = _y.Point - (_size.Point / 2d);

            gfx.DrawRectangle(pen, XBrushes.Black, _x.Point, _y.Point, _size.Point, _size.Point);
        }
    }
}
