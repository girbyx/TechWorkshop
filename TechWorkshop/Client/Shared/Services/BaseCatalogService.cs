﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace TechWorkshop.Client.Shared.Services
{
    public class BaseCatalogService<TViewModel> : IBaseCatalogService<TViewModel> where TViewModel : class
    {
        protected const long MaxFileSize = 10240000; // 10 mb

        protected string ControllerName;
        protected string DetailControllerName;

        protected readonly HttpClient HttpClient;
        protected readonly NavigationManager NavigationManager;

        public BaseCatalogService(HttpClient httpClient, NavigationManager navigationManager)
        {
            HttpClient = httpClient;
            NavigationManager = navigationManager;
            ControllerName = "";
            DetailControllerName = "";
        }

        public async Task<string> GetCurrentUserName()
        {
            return await HttpClient.GetStringAsync("api/Account/GetCurrentUserName");
        }

        public async Task<IEnumerable<TViewModel>> GetList()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<TViewModel>>($"api/{ControllerName}");
        }

        public async Task<IEnumerable<TViewModel>> GetHistory(Guid id)
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<TViewModel>>($"api/{DetailControllerName}/GetHistory?id={id}");
        }

        public async Task<TViewModel> Get(Guid id)
        {
            return await HttpClient.GetFromJsonAsync<TViewModel>($"api/{DetailControllerName}?id={id}");
        }

        public async Task<TViewModel> GetEmpty()
        {
            return await HttpClient.GetFromJsonAsync<TViewModel>($"api/{DetailControllerName}/GetEmpty");
        }

        public async Task<Guid> Add(TViewModel record)
        {
            var response = await HttpClient.PostAsJsonAsync($"api/{ControllerName}", record);
            var stringResult = await response.Content.ReadAsStringAsync();
            var id = new Guid(stringResult.Replace("\"", ""));
            return id;
        }

        public async Task AddFiles(Guid id, IBrowserFile[] files)
        {
            var form = new MultipartFormDataContent
            {
                {new StringContent(id.ToString()), "id"}
            };

            for (var i = 0; i < files.Length; i++)
            {
                var buffer = new byte[files[i].Size];
                await files[i].OpenReadStream(MaxFileSize).ReadAsync(buffer);
                // [0]: file, [1]: fileName, [2]: fileExtension
                var stringContent = $"{Convert.ToBase64String(buffer)}||{files[i].Name.Split('.').First()}||{files[i].Name.Split('.').Last()}";
                form.Add(new StringContent(stringContent), $"files[{i}]");
            }

            await HttpClient.PostAsync($"api/{ControllerName}/PostFiles", form);
        }

        public async Task Delete(Guid id)
        {
            await HttpClient.DeleteAsync($"api/{ControllerName}?id={id}");
        }

        public async Task DeleteAttachment(Guid id)
        {
            await HttpClient.DeleteAsync($"api/Attachment?id={id}");
        }

        public async Task Archive(Guid id)
        {
            await HttpClient.DeleteAsync($"api/{ControllerName}/Archive?id={id}");
        }

        public async Task<Guid> Update(TViewModel record)
        {
            var response = await HttpClient.PutAsJsonAsync($"api/{ControllerName}", record);
            var stringResult = await response.Content.ReadAsStringAsync();
            var id = new Guid(stringResult.Replace("\"", ""));
            return id;
        }

        public async Task Return()
        {
            NavigationManager.NavigateTo($"{ControllerName.ToLower()}/list");
        }
    }
}