using System.Diagnostics;
using System.Net.Http;
using MonkeyCache.LiteDB;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TimeTracker.Apps.ViewModels;
using TimeTracker.Dtos;
using TimeTracker.Dtos.Accounts;
using TimeTracker.Dtos.Authentications;
using TimeTracker.Dtos.Authentications.Credentials;
using TimeTracker.Dtos.Projects;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Storm.Mvvm.Services;
using TimeTracker.Apps.Pages;

namespace TimeTracker.Apps.Services
{
    public class TimeTrackerServices

    {
       
        HttpClient client = new HttpClient();
       
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
        public static string TokenType { get; set; }
        Token token = new Token();
        
        LoginResponse loginResponse = new LoginResponse();

        List<ProjectItem> projectItems = new List<ProjectItem>();
        public int ExpiresIn { get; set; }
        public JObject listPro { get; set; }

        public async Task Insription(CreateUserRequest createUserRequest)
        {
            
            
           

           var json = JsonConvert.SerializeObject(createUserRequest);
      
           var  content = new StringContent(json, Encoding.UTF8, "application/json");
            
           

            var response = await client.PostAsync(Urls.HOST +"/"+ Urls.CREATE_USER, content);
            
            var test = await response.Content.ReadAsStringAsync();
          

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(test);
            }
            else {
                 Debug.WriteLine(test);
            }






        }

        public async void AddProjetAsync(AddProjectRequest addProjectRequest)
            
        {
            Barrel.ApplicationId = "cacheIdLogin";
            LoginResponse loginResponse = Barrel.Current.Get<LoginResponse>(key: "GestionLogin");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
            


            var json = JsonConvert.SerializeObject(addProjectRequest);
        
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(Urls.HOST + "/" + Urls.ADD_PROJECT , content);
            
            var bodyresponse = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(bodyresponse);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(bodyresponse);
                ItemsProjetAsync();

            }
        }
        public async Task Connexion(LoginWithCredentialsRequest loginWithCredentialsRequest)
        {
           
           var json = JsonConvert.SerializeObject(loginWithCredentialsRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Urls.HOST + "/" + Urls.LOGIN, content);
            var bodyresponse = await response.Content.ReadAsStringAsync();
            JObject json2 = JsonConvert.DeserializeObject<JObject>(bodyresponse);
            Debug.WriteLine(bodyresponse);
            loginResponse.AccessToken = (string)json2["data"]["access_token"];
            loginResponse.RefreshToken = (string)json2["data"]["refresh_token"];
            loginResponse.TokenType= (string)json2["data"]["token_type"];
            loginResponse.ExpiresIn = (int)json2["data"]["expires_in"];


            

            if (response.IsSuccessStatusCode)

            {
                Barrel.ApplicationId = "cacheIdlogin";
                Barrel.Upgrade = true;
                Barrel.Current.Add(key: "GestionLogin",data:loginResponse,expireIn:System.TimeSpan.FromHours(2));
               


            }
          
            else
            {
                Debug.WriteLine(bodyresponse);
               
            }
        }

        public async void ItemsProjetAsync()
        {
            Barrel.ApplicationId = "cacheIdLogin";
            LoginResponse loginResponse = Barrel.Current.Get<LoginResponse>(key: "GestionLogin");

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
            var response = await client.GetAsync(Urls.HOST + "/" + Urls.LIST_PROJECTS);
            var bodyresponse = await response.Content.ReadAsStringAsync();
            JObject json2 = JsonConvert.DeserializeObject<JObject>(bodyresponse);
            Debug.WriteLine(bodyresponse);
            Debug.WriteLine(json2["data"][0]);

            foreach (var x in json2["data"])
            {
                ProjectItem projectItem = new ProjectItem();
                Debug.WriteLine(x);
                projectItem.fill(x);
                projectItems.Add(projectItem);
            }

            /*projectItem.Name=(string)json2["data"]["name"];
             projectItem.Description = (string)json2["data"]["description"];
             projectItem.TotalSeconds = (long)json2["data"]["total_seconds"];
             projectItem.Id = (long)json2["data"]["id"];*/

            Barrel.ApplicationId = "cacheIdlogin";
            Barrel.Upgrade = true;
            Barrel.Current.Add(key: "GestionList", data: projectItems, expireIn: System.TimeSpan.FromHours(2));

            INavigationService navigationService = DependencyService.Get<INavigationService>();
            _ = navigationService.PushAsync<Projetpage>(new Dictionary<string, object>()
            {
                ["Listfinal"] = projectItems,

            });



        }
        
    }
}
