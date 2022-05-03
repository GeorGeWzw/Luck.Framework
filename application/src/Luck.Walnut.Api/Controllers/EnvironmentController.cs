﻿using Luck.Framework.Utilities;
using Luck.Walnut.Application.Environments;
using Luck.Walnut.Dto.Environments;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers
{
    [Route("api/environment")]
    public class EnvironmentController :BaseController
    {

        private readonly IEnvironmentService _environmentService;

        public EnvironmentController(IEnvironmentService environmentService)
        {
            _environmentService = Check.NotNull(environmentService, nameof(environmentService));
            
        }


        [HttpGet]
        public Task<List<AppEnvironmentPageListOutputDto>> GetAppEnvironmentPage() =>_environmentService.GetAppEnvironmentPageAsync();

        [HttpGet("getselectedenvironmentlist")]
        public Task<IEnumerable<SelectedItem>> GetSelectedEnvironmentList()=>_environmentService.SelectedEnvironmentListAsync();

        [HttpPost]
        public Task AddEnvironment([FromBody] AppEnvironmentInputDto input) => _environmentService.AddAppEnvironmentAsync(input);


        [HttpPost("{environmentId}")]
   
        public Task AddAppConfiguration(string environmentId,[FromBody] AppConfigurationInput input) => _environmentService.AddAppConfigurationAsync(environmentId, input);



        [HttpPut("{environmentId}/{id}")]
        public Task UpdageAppConfiguration(string environmentId, string id, [FromBody] AppConfigurationInput input) => _environmentService.UpdateAppConfigurationAsync(environmentId, id, input);

        [HttpDelete("{id}")]
        public Task DeleteEnvironment(string id) => _environmentService.DeleteAppEnvironmentAsnyc(id);

        [HttpDelete("{environmentId}/{configurationId}")]
        public Task DeleteAppConfiguration(string environmentId, string configurationId) => _environmentService.DeleteAppConfigurationAsync
            (environmentId, configurationId);




    }
}
