﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Recog.Interact
{
    public class RExcel:IDisposable
    {
  public const string UID = "Excel.Application";
        object oExcel = null;
        object WorkBooks, WorkBook, WorkSheets, WorkSheet, Range;

        //КОНСТРУКТОР КЛАССА
        public RExcel()
        {
            oExcel = Activator.CreateInstance(Type.GetTypeFromProgID(UID));
        }

        //ВИДИМОСТЬ EXCEL - СВОЙСТВО КЛАССА
        public bool Visible
        {
            set
            {
                if (value==false)
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                        null, oExcel, new object[] { false });

                else
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                        null, oExcel, new object[] { true });
            }
        }
                

        //ОТКРЫТЬ ДОКУМЕНТ
        public void OpenDocument(string name)
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, WorkBooks, new object[] { name, true });
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            // Range = WorkSheet.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,WorkSheet,new object[1] { "A1" });
        }
        

        // НОВЫЙ ДОКУМЕНТ
        public void NewDocument()
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, WorkBooks, null);
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
            
        }
        //ЗАКРЫТЬ ДОКУМЕНТ
        public void CloseDocument(bool save)
        {
            WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, WorkBook, new object[] { save});
        }
        //СОХРАНИТЬ ДОКУМЕНТ
        public void SaveDocument(string name)
        {
            if (File.Exists(name))
                WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null,
                    WorkBook, null);
            else
                WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null,
                    WorkBook, new object[] { name });
        }

        public string[] GetWorkSheetsnames()
        {
            int cnt = (int)WorkSheets.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, WorkSheets, null);
            string[] s= new string[cnt];

            for (int i = 1; i <= cnt; i++)
            {
              object  Sheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { i });
              string str = (string)Sheet.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, Sheet, null);
              s[i - 1] = str;
            }
                return s;
        }

        public void SetActiveSheet(string Name)
        {
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { Name });
        }

        public object GetCellValue(int Row, int Col)
        {
            if (Row > 0 & Col > 0)
            {
                object cell=WorkSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, WorkSheet, new object[] { Row, Col });
                return cell.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, cell, null);
            }
            else { return string.Empty; }
        }
        public void SetCellValue(int Row, int Col, object value)
        {
            if (Row > 0 & Col > 0)
            {
                object cell = WorkSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, WorkSheet, new object[] { Row, Col });
                cell.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, cell, new object[] { value});
            }
        }

        public int GetCurrRegRows(int FirstRow, int FirstCol)
        {
            if (FirstRow > 0 & FirstCol > 0)
            {
                object cell = WorkSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, WorkSheet, new object[] { FirstRow, FirstCol });
                object curreg = cell.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, cell, null);
                object rows = curreg.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, curreg, null);
                return (int)rows.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, rows, null);
            }
            else
            { return 0; }
        }

        public int GetCurrRegCols(int FirstRow, int FirstCol)
        {
            if (FirstRow > 0 & FirstCol > 0)
            {
                object cell = WorkSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, WorkSheet, new object[] { FirstRow, FirstCol });
                object curreg = cell.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, cell, null);
                object cols = curreg.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, curreg, null);
                return (int)cols.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, cols, null);
            }
            else
            { return 0; }
        }



        // ЗАПИСАТЬ ЗНАЧЕНИЕ В ЯЧЕЙКУ
        public void SetValue(string range, string value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            Range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range, new object[] { value });
        }

        //ОБЪЕДЕНИТЬ ЯЧЕЙКИ 
        // Alignment - ВЫРАВНИВАНИЕ В ОБЪЕДИНЕННЫХ ЯЧЕЙКАХ
        public void SetMerge(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, Range, new object[] { true });
            Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
        }

        //УСТАНОВИТЬ ОРИЕНТАЦИЮ СТРАНИЦЫ 
        //1 - КНИЖНЫЙ
        //2 - АЛЬБОМНЫЙ
        public void SetOrientation(int Orientation)
        {
            //Range.Interior.ColorIndex
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Orientation });
        }

        //УСТАНОВИТЬ ШИРИНУ СТОЛБЦОВ
        public void SetColumnWidth(string range, double Width)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Width };
            Range.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range, args);
        }
        
        //УСТАНОВИТЬ ВЫСОТУ СТРОК
        public void SetRowHeight(string range, double Height)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Height };
            Range.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, null, Range, args);
        }

        //УСТАНОВИТЬ ВИД РАМКИ ВОКРУГ ЯЧЕЙКИ
        public void SetBorderStyle(string range, int Style)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { 1 };
            object[] args1 = new object[] { 1 };
            object Borders = Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, Range, null);
            Borders = Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, Borders, args);
        } 

        //ЧТЕНИЕ ДАННЫХ ИЗ ВЫБРАННОЙ ЯЧЕЙКИ
        public string GetValue(string range)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,null, WorkSheet, new object[] { range });
            return Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null).ToString();
        }

        //УСТАНОВИТЬ ВЫРАВНИВАНИЕ В ЯЧЕЙКЕ ПО ВЕРТИКАЛИ
        public void SetVerticalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, Range, args);
        }

        //УСТАНОВИТЬ ВЫРАВНИВАНИЕ В ЯЧЕЙКЕ ПО ГОРИЗОНТАЛИ
        public void SetHorisontalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
        }


        public void Dispose()
        {
            oExcel.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, oExcel, null);
            GC.SuppressFinalize(this);      
        }
    }
}
