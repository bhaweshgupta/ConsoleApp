/*
 * Created by SharpDevelop.
 * User: 765454
 * Date: 3/26/2019
 * Time: 1:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;           
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace patching
{
	class Program
	{
		public static SortedSet<string> sett = new SortedSet<string>();
			public static void getExcelFile()
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\765454\Desktop\sheetlocal.xlsx");
            Excel.Workbook xlWorkbook2 = xlApp.Workbooks.Open(@"C:\Users\765454\Desktop\sheetMaster.xlsx");
            Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
            Excel._Worksheet xlWorksheet2 = (Excel._Worksheet)xlWorkbook2.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
			Excel.Range xlRange2 = xlWorksheet2.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int rowCount2=xlRange2.Rows.Count;
            int colCount = xlRange.Columns.Count;
            int colCount2=xlRange2.Columns.Count;
            for (int i = 2; i <= rowCount; i++)
            {
   				 object _xVal;
    				_xVal= ((Excel.Range)xlWorksheet.Cells[i, 1]).Value2;
    				if(xlWorksheet.Cells[i, 1]!=null&&_xVal!=null)
    				{
    					for (int ii = 2; ii <= rowCount2; ii++)
    					{
    						object _xVal2;

    						_xVal2= ((Excel.Range)xlWorksheet.Cells[ii, 1]).Value2;
    						if (xlRange.Cells[ii, 1] != null&&_xVal2!=null&&_xVal.ToString()==_xVal2.ToString())
    							sett.Add(_xVal.ToString());
    					}
    		
    				}
            }
            

  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlRange2);
            Marshal.ReleaseComObject(xlWorksheet);
             Marshal.ReleaseComObject(xlWorksheet2);
            xlWorkbook.Close();
            xlWorkbook2.Close();
            Marshal.ReleaseComObject(xlWorkbook);
			Marshal.ReleaseComObject(xlWorkbook2);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
			public static void Main(string[] args)
		  {
				getExcelFile();
				foreach(var v in sett)
				{
					Console.WriteLine(v);
				}
				Console.ReadLine();
			}
	}
}