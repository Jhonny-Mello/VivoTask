
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.Data;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
using DataTable = System.Data.DataTable;



namespace Vivo_Task.Shared_Static_Class.Converters
{
    public static class Converters
    {
        public static List<string> ConvertStringToStringList(string input)
        {
            var enumList = new List<string>();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Contains(";"))
                {
                    // Multiple values separated by semicolon
                    var enumValues = input.Split(';').Select(x => x.Trim());

                    foreach (var value in enumValues)
                    {
                        enumList.Add(value);
                    }
                }
                else
                {
                    enumList.Add(input);
                }
            }

            return enumList;
        }
        public static string RemoveNonNumericCharacters(string input) => new string(input.ToCharArray().Where(c => char.IsDigit(c)).ToArray());
        public static List<TEnum> ConvertStringToEnumList<TEnum>(string input) where TEnum : struct
        {
            var enumList = new List<TEnum>();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Contains(";"))
                {
                    // Multiple values separated by semicolon
                    var enumValues = input.Split(';').Select(x => x.Trim());

                    foreach (var value in enumValues)
                    {
                        if (Enum.TryParse(typeof(TEnum), value, out var categoriaValue) && categoriaValue is TEnum)
                        {
                            enumList.Add((TEnum)categoriaValue);
                        }
                        else
                        {
                            // Handle the case where parsing fails or provide a default value
                        }
                    }
                }
                else
                {
                    // Single value without semicolon
                    if (Enum.TryParse(typeof(TEnum), input.Trim(), out var categoriaValue) && categoriaValue is TEnum)
                    {
                        enumList.Add((TEnum)categoriaValue);
                    }
                    else
                    {
                        // Handle the case where parsing fails or provide a default value
                    }
                }
            }

            return enumList;
        }
        public static IEnumerable<Cargos> GetCargosFromStringList(string cargo)
        {
            var delimiter = new[] { ';' };
            var cargosArray = cargo.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(x => (Cargos)int.Parse(x))
                                   .ToList();

            return cargosArray;
        }
        public static IEnumerable<Canal> GetCanaisFromCargos(string cargo)
        {
            var cargosList = GetCargosFromStringList(cargo);
            var canaisArray = cargosList.Select(x => DePara.CanalCargoEnum(x)).ToList();

            return canaisArray;
        }
        /** 
         * FileDataModel item -> arquivo,
         * int numbercolumns -> número de colunas,
         * int numberrows -> número de linhas,
         * string excelmodel -> nome de saída do excel,
         * out DataTable displayDataTable -> Retorna o DataTable
         * **/
        //public static void ExcelToDataTable(FileDataModel item, int numbercolumns, int numberrows, string excelmodel, out DataTable displayDataTable)
        //{
        //    string folderPath = "";
        //    string outputPath = "";

        //    displayDataTable = new DataTable();

        //    foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
        //    {
        //        process.Kill();
        //    }

        //    folderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                
        //    if (File.Exists(Path.Combine(folderPath, "NewModelQuestion.xls")))
        //    {
        //        outputPath = Path.Combine(folderPath, "NewModelQuestion.xls");
        //        File.Delete(outputPath);
        //    }
        //    else
        //    {
        //        outputPath = Path.Combine(folderPath, "NewModelQuestion.xls");
        //    }

        //    var actualfile = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "files", $"{excelmodel}.xlsx");
        //    if (File.Exists(actualfile))
        //    {
        //        File.Delete(actualfile);
        //    }
        //    File.WriteAllBytesAsync(outputPath, SharedConverter.ConvertFile(item.Bytes));

        //    displayDataTable = new DataTable();

        //    foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
        //    {
        //        process.Kill();
        //    }


        //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    excelApp.Visible = false;

        //    Workbook excelWorkbook = excelApp.Workbooks.Open(outputPath);
        //    Worksheet excelWorksheet = (Worksheet)excelWorkbook.Sheets[1]; // Or use excelWorkbook.ActiveSheet

        //    // Add header Columns to the DataTable
        //    for (int col = 1; col <= numbercolumns; col++) // Assuming there are 14 columns
        //    {
        //        var column = ((Microsoft.Office.Interop.Excel.Range)excelWorksheet.Cells[1, col]).Value?.ToString() ?? "-";
        //        if (column != "-")
        //        {
        //            displayDataTable.Columns.Add(column);
        //        }
        //    }

        //    // Populate the DataTable
        //    for (int row = 2; row <= numberrows; row++) // Assuming you want to read up to row 100
        //    {
        //        List<string> excelRow = new List<string>();

        //        for (int col = 1; col <= displayDataTable.Columns.Count; col++) // Assuming there are 14 columns
        //        {
        //            excelRow.Add(((Microsoft.Office.Interop.Excel.Range)excelWorksheet.Cells[row, col]).Value?.ToString() ?? "");
        //        }

        //        if (excelRow.Any(x => !string.IsNullOrEmpty(x)))
        //        {
        //            displayDataTable.Rows.Add(excelRow.ToArray());
        //        }
        //    }

        //    excelWorkbook.Close(false);
        //    excelApp.Quit();

        //}
    }
}
