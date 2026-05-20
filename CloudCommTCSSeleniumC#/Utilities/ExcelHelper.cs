using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudCommTCSSeleniumC_.Utilities
{
    public  class ExcelHelper
    {

        public static IEnumerable<object[]> GetLoginData()
        {
            string projectPath =
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.FullName;

            string filePath =
                Path.Combine(projectPath,
                "TestDataDir",
                "TestData.xlsx");

            using var workbook = new XLWorkbook(filePath);

            var worksheet = workbook.Worksheet(1);

            int rowCount = worksheet.LastRowUsed().RowNumber();

            for (int row = 2; row <= rowCount; row++)
            {
                string username =
                    worksheet.Cell(row, 1).GetString();

                string password =
                    worksheet.Cell(row, 2).GetString();

                yield return new object[]
                {
                    username,
                    password
                };
            }
        }
    }
}
