using DocumentFormat.OpenXml.Packaging;
using exchanges.Exchanges;
using exchanges.Extensions;
using Newtonsoft.Json;
using System.Data;

namespace exchanges.Services
{
    public class ExportService
    {
        public void GenerateJson(exchangeResult results)
        {
            var resultToJson = new Dictionary<string, Dictionary<string, List<exchangeData>>>();
            var exchangeDict = new Dictionary<string, List<exchangeData>>();

            foreach (var currency in results.currencies)
            {
                resultToJson.Add(currency.pairName, new Dictionary<string, List<exchangeData>>());

                var ordered = currency.exchanges.OrderBy(x => x.exchangeData.askPrice);

                foreach (var exchange in ordered)
                {
                    if (!resultToJson.ContainsKey(currency.pairName))
                    {
                        exchangeDict.Add(exchange.name, new List<exchangeData> { exchange.exchangeData });
                        resultToJson.Add(currency.pairName.RemoveSpecialCharacters(), exchangeDict);
                    }
                    else
                    {
                        var t = resultToJson.Where(x => x.Key == currency.pairName).First();
                        if (!resultToJson.Where(x => x.Key == currency.pairName).First().Value.ContainsKey(exchange.name))
                            resultToJson.Where(x => x.Key == currency.pairName).First().Value.Add(exchange.name, new List<exchangeData> { exchange.exchangeData });
                    }
                }
            }          

            string json = JsonConvert.SerializeObject(resultToJson);

            File.WriteAllText("resultJson.txt", json);
        }

        public void GenerateExcel(exchangeResult results)
        {
            var dataTable = new DataTable();
            var ds = new DataSet();

            DataColumn currencyColumn = dataTable.Columns.Add("[lastPtice, bidPrice, askPrice]", typeof(string));

            foreach (var exchange in results.currencies.SelectMany(x => x.exchanges))
            {
                if (!dataTable.Columns.Contains(exchange.name))
                {
                    dataTable.Columns.Add(exchange.name, typeof(string));
                }
            }

            foreach (var currency in results.currencies)
            {
                DataRow itemRow = dataTable.NewRow();
                itemRow[currencyColumn] = currency.pairName;

                foreach (DataColumn column in dataTable.Columns)
                {
                    string name = column.ColumnName;
                    if (name == "[lastPtice, bidPrice, askPrice]") continue;
                    exchange exchange = currency.exchanges.FirstOrDefault(x => x.name == name);

                    if (exchange == null)
                    {
                        itemRow[column] = "[-,-,-]";
                    }
                    else
                    {
                        itemRow[column] = $"[{exchange.exchangeData.lastPrice},{exchange.exchangeData.bidPrice},{exchange.exchangeData.askPrice}]";
                    }
                }

                dataTable.Rows.Add(itemRow);
            }

            ds.Tables.Add(dataTable);
            this.ExportDataSet(ds, "resultExcel.xlsx");
        }

        private void ExportDataSet(DataSet ds, string destination)
        {
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();

                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                foreach (System.Data.DataTable table in ds.Tables)
                {

                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetId = 1;
                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<String> columns = new List<string>();
                    foreach (System.Data.DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }


                    sheetData.AppendChild(headerRow);

                    foreach (System.Data.DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }

                }
            }
        }
    }
}
