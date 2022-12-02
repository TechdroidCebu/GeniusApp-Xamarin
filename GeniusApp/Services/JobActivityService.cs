using GeniusApp.Models;
using Newtonsoft.Json;
using System.Linq;
//using System.Net.Http.Json;
using GeniusApp.ViewModels;
using SQLite;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeniusApp.Services
{
public class JobActivityService
{

    HttpClient httpClient;
    public JobActivityService()
    {
        this.httpClient = new HttpClient();
    }

    List<JobActivityModel> jobActivityList;

    public async Task<List<JobActivityModel>> GetJobActivities()
    {
        if (jobActivityList?.Count > 0)
            return jobActivityList;

        // Online
        var response = await httpClient.GetAsync("https://genius-api.aboitizpower.com/api/FixedAsset/GetJobActivity");
        if (response.IsSuccessStatusCode)
        {
            var json = "";
            string content = await response.Content.ReadAsStringAsync();
            if (content.Contains('['))
            {
                json = content;
            }
            else
            {
                json = "[" + content + "]";
            }

            jobActivityList = JsonConvert.DeserializeObject<List<JobActivityModel>>(json);          


        }
        // Offline
        /*using var stream = await FileSystem.OpenAppPackageFileAsync("Mackydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        MackyList = JsonSerializer.Deserialize<List<Macky>>(contents);
        */
        return  jobActivityList;
    }


}

}

