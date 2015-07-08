using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.RtfWriter;
using System.Diagnostics;
using System.Threading;

namespace Recog.DocPrinter
{
    delegate void ShowFormDelegate();

    public abstract class RtfPrinter
    {
        #region docformating

        protected RtfDocument doc = null;
        private string _filename;
        protected void CreateDoc(string FileName)
        {
            doc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.English);
            doc.Margins[Direction.Top] = 30;
            doc.Margins[Direction.Bottom] = 30;
            doc.Margins[Direction.Left] = 50;
            doc.Margins[Direction.Right] = 30;
            _filename = FileName;
        }
        protected void SaveDoc()
        {
            _filename = ApplicationInfo.GetDirectory() + @"\Docs\" + _filename;
            doc.save(_filename);
        }
        protected void OpenDoc(bool WaitForExit=false)
        {
            var p = new Process { StartInfo = { FileName = _filename } };
            p.Start();
            if (WaitForExit == true)
            {
                try
                {
                    p.WaitForExit();
                }
                catch
                {
                    throw new Exception("Закройте все текстовые документы перед началом потокового сканирования");
                }
            }
        }
        protected void TypeParagraph(int fontsize, Align align, string text,bool isBold=false)
        {
            if (doc != null)
            {
                FontDescriptor times = doc.createFont("Arial");
                RtfCharFormat fmt;
                RtfParagraph par;

                par = doc.addParagraph();
                par.Alignment = align;
                fmt = par.addCharFormat();
                fmt.Font = times;
                fmt.FontSize = fontsize;
                if (isBold == true) { fmt.FontStyle.addStyle(FontStyleFlag.Bold); }
                par.setText(text);
            }
        }
        protected void TypeCellParagraph(RtfTableCell cell, int fontsize, Align align, string text)
        {
            if (doc != null)
            {
                FontDescriptor times = doc.createFont("Times New Roman");
                RtfCharFormat fmt;
                RtfParagraph par;

                par = cell.addParagraph();
                par.Alignment = align;
                fmt = par.addCharFormat();
                fmt.Font = times;
                fmt.FontSize = fontsize;
                par.setText(text);
            }
        }

        #endregion

        #region splashform
        private PrintForm _form;
        private Thread formprocessing;

       protected void SplashShow()
        {
           
            formprocessing = new Thread(ShowForm);
            formprocessing.Start();
        }
       private void ShowForm()
       {
           _form = new PrintForm();
           _form.ShowDialog();
       }
       
       protected void SplashHide()
        {
            formprocessing.Abort();
        }
        #endregion
    }
}
