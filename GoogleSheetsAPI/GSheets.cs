using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;

namespace GoogleSheetsAPI
{
    public partial class GSheets
    {
        public string SpreadsheetId;

        protected private SheetsService _sheetsService;

        private readonly string[] _scopes = { SheetsService.Scope.Spreadsheets };

        public GSheets(string secretFilePath, string applicationName)
        {
            GoogleCredential credential;

            using (var stream = new FileStream(secretFilePath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
            }

            _sheetsService = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName,
            });
        }
    }
}