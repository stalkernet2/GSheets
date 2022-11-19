using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSheetsAPI
{
    public partial class GSheets
    {
        public IList<IList<object>> ReadEntries(string range)
        {
            var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();

            return response.Values;
        }

        public void CreateEntry(string range, List<object> objectList)
        {
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>> { objectList };

            var appendRequest = _sheetsService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;

            var appendResponce = appendRequest.Execute();
        }

        public void UpdateEntry(string range, List<object> objectList)
        {
            var valueRange = new ValueRange();

            valueRange.Values = new List<IList<object>> { objectList };

            var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var updateResponce = updateRequest.Execute();
        }

        public void DeleteEntry(string range)
        {
            var requestBody = new ClearValuesRequest();

            var deleteRequest = _sheetsService.Spreadsheets.Values.Clear(requestBody, SpreadsheetId, range);
            var deleteResponce = deleteRequest.Execute();
        }
    }
}
