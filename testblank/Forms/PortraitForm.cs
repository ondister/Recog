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
    public class PortraitForm
    {
        private PdfDocument s_document;
        private PdfPage _page;
        private XGraphics gfx;



        public void Create(string filename, int qcount, int cellsinq, List<string> cellslabels,int rowscount)
        {

            s_document = new PdfDocument();
          
            _page = new PdfPage();
            _page.Orientation = PageOrientation.Portrait;
            _page.Size = PageSize.A4;
            s_document.Pages.Add(_page);
            gfx = XGraphics.FromPdfPage(_page);



            DrawCenterMarker(7);

            DrawSideMarker(7, 10, 10);
            DrawSideMarker(7, 10, 285);
            DrawSideMarker(7, 200, 10);
            DrawSideMarker(7, 200, 285);

            AddFields();

           
            AddQuestions(qcount,cellsinq,cellslabels,rowscount);


            // Save the s_document...
            s_document.Save(filename);
            // ...and start a viewer
            Process.Start(filename);


        }


        private void AddQuestions(int qcount, int cellsinq, List<string> cellslabels,int rowscnt)
        {
            
            int rowhight = 7;
            int rowscount = rowscnt;//Convert.ToInt32((_page.Height.Millimeter - 80d) / 7d);
            int colscount = qcount / rowscount;

            int mincolwidth = cellsinq * (4 + 3);

            int colsinterval = Convert.ToInt32(((_page.Width.Millimeter - 40d)-(mincolwidth * colscount))/colscount);
            colsinterval = colsinterval < 8 ? 8 : colsinterval;
            int colwidgth = cellsinq * (4 + 3) + colsinterval;

            int maxy = 0;
            int initx = 15;
            int inity = 50;

            int x = initx;
           
            int number = 1;
    
            int rr = 0;
            int y = inity;
            for (int question = 0; question < qcount; question++)
            {
               if(rr != 0)
               {
                   DrawQuestion(number, cellsinq, x, y);
               }
               else
               {
                   DrawQuestion(number, cellsinq, x, y,cellslabels);
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
            this.DrawLeftString("Добровольность тестирования и достоверность результатов подтверждаю:_______________", 25,maxy+3, 60, 10);
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
                        this.DrawLeftString(labels[cell], fromleftmm + (cell * (offset + cellsize) -2), fromtopmm - cellsize - (int)cellsize / 2 - offset, 5, 10);
                    }
                }
            }

        }

        private void AddFields()
        {

            XPdfFontOptions o = new XPdfFontOptions(PdfFontEncoding.Unicode);
            XFont font = new XFont("Times New Roman", 14, XFontStyle.Regular, o);

            gfx.DrawString("Бланк фиксации результатов теста", font, XBrushes.Black,
              new XRect(0, XUnit.FromMillimeter(17).Point, _page.Width, 5),
              XStringFormats.Center);
            this.DrawLeftString("Подразделение_______________", 10, 25, 60, 10); this.DrawLeftString("Ф.И.О._____________________________________", 70, 25, 90, 10); this.DrawLeftString("Образование_________________", 150, 25, 30, 10);
            this.DrawLeftString("Дата рождения_______________", 10, 30, 60, 10); this.DrawLeftString("Дата тестирования_____________", 150, 30, 30, 10);
            this.DrawLeftString("M", 10, 35, 5, 14); this.DrawRectangle(4, 17, 38); this.DrawLeftString("Ж", 20, 35, 5, 14); this.DrawRectangle(4, 27, 38); this.DrawLeftString("Пример заполнения бланка", 40, 36, 50, 10); this.DrawRectangle(4, 85, 38); this.DrawLeftString("Х", 83, 35, 5, 14);

            this.DrawLine(0, (int)_page.Width.Millimeter, 41);
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


        private void DrawSideMarker(int size, int mmfromleft, int mmfromtop)
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

        private void DrawCenterMarker(int size)
        {
            XUnit _size = XUnit.FromMillimeter(size);
            //  XGraphics gfx = XGraphics.FromPdfPage(_page);
            XPen pen = new XPen(XColors.Black, 2);
            XUnit _x = XUnit.FromPoint(_page.Width.Point / 2d);
            XUnit _y = XUnit.FromMillimeter(10);
            _x.Point = _x.Point - (_size.Point / 2d);
            _y.Point = _y.Point - (_size.Point / 2d);

            gfx.DrawRectangle(pen, XBrushes.Black, _x.Point, _y.Point, _size.Point, _size.Point);
        }
    }
}
