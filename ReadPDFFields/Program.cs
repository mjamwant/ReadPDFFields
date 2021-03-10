using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Collections.Generic;

namespace ReadPDFFields
{
    class Program
    {
        static void Main(string[] args)
        {

            PdfReader pdfReader = new PdfReader(@"C:\Users\michael.jamwant\Documents\Projects\ODBClaim_PDF\new\ODBclaimreversalform2020.pdf");

            string TempFilename = Path.GetTempFileName();

            AcroFields pdfFormFields = pdfReader.AcroFields;

            foreach (KeyValuePair<string, AcroFields.Item> kvp in pdfFormFields.Fields)
            {
                string exportPath = @"C:\Users\michael.jamwant\Documents\Projects\ODBClaim_PDF\New\claim.txt";
                string fieldName = kvp.Key.ToString();
                string fieldValue = pdfFormFields.GetField(kvp.Key.ToString());
                Console.WriteLine(fieldName + " " + fieldValue);
                File.AppendAllText(exportPath, fieldName + "/n");

            }

            pdfReader.Close();

        }
    }
  }


