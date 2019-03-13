using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using MatrixCalculation;




namespace MatrixClient
{
    public partial class _Default : Page
    {
        private const string baseUrl = "http://localhost:64329/api/Numbers/InitMatrix/";
        private const string baseDatasetUrl = "http://localhost:64329/api/Numbers/GetDataset/";
        private const string baseValidateUrl = "http://localhost:64329/api/Numbers/Validate/";
        private string HD5HashResult { get; set; }
        public int Size { get; set; }
        public string MatrixA { get; set; }
        public string MatrixB { get; set; }
        private const string Slash = "/";


        protected void Validate_Click(object sender, EventArgs e)
        {
           int size = 0;
            if (int.TryParse(txtSize.Text, out size))
            {
                var result = InitMatrix(size).Result;
                Size = int.Parse(result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                lblError.Text = "Could not parse size as valid Integer";
            }

            GetDataset();
            CalculateResult();
            var result2= ValidateHash().Result;
            lblResult.Text = result2.Content.ReadAsStringAsync().Result;
            Label1.Text = MatrixA;
            Label2.Text = MatrixB;
            Label3.Text = HD5HashResult;
        }
        public Task<HttpResponseMessage> InitMatrix(int size)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                return client.GetAsync(size.ToString());
            }
            catch
            {
                return null;
            }
        }

        public void GetDataset()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseDatasetUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            var parameters = "A" + Slash + "row" + Slash + 1;
            var result = client.GetAsync(parameters).Result;
            ParseMatrix(result.Content.ReadAsStringAsync().Result);

        }

        public void CalculateResult()
        {
            var calc = new Calculation(Size, MatrixA, MatrixB);
            HD5HashResult = calc.MatrixMultiplication();
        }

        public Task<HttpResponseMessage> ValidateHash()
        {
            try
            { 
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseValidateUrl);
                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var parameters = HD5HashResult;
                return client.GetAsync(parameters);

            }
            catch
            {
                return null;
            }
        }

        public void ParseMatrix(string data)
        {
            var values = data.Split('|');
            MatrixA = values[1].TrimEnd();
            MatrixB = values[2].TrimEnd();
        }
    }
}