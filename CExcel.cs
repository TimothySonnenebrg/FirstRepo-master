using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace TJS.Utilities.Reporting
{
    public static class CExcel
    {
        public static void Export(string filename, string [,] data)
        {
            try
            {
                Application xlApp;
                Workbook xlWB;
                Worksheet xlWS;

                xlApp = new Application();
                xlWB = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
                xlWS = (Worksheet)xlWB.Sheets["Sheet1"];

                for (int iRow = 0; iRow < data.GetLength(0); iRow++)
                {
                    for (int iCol = 0; iCol < data.GetLength(1); iCol++)
                    {
                        xlWS.Cells[iRow + 1, iCol + 1] = data[iRow, iCol]; // puting value into cell
                    }
                }
                xlWS.Columns.AutoFit();
                xlWS.UsedRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                xlApp.DisplayAlerts = false;

                //Save xl file
                xlWS.SaveAs(filename);

                xlWB.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,
                                        filename.Substring(0, filename.Length - 5));

                xlWB.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWS);
                Marshal.ReleaseComObject(xlWB);
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
