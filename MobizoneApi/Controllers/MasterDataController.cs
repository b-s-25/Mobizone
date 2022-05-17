﻿using APILayer.Controllers;
using BusinesLogic;
using BusinesLogic.Interface;
using BussinessLogic;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobizoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataOperations _masterdataoperation;
        private readonly ILogger<MasterDataController> _logger;
        private readonly ProductDbContext _Context;
        public MasterDataController(IMasterDataOperations masterdataoperation, ProductDbContext Context)
        {
            _Context = Context;
            _masterdataoperation = masterdataoperation;
        }
        [HttpGet("GetMasterData")]
        public IEnumerable<MasterData> GetMasterData()
        {
               var masterdata = _masterdataoperation.GetAllMasterData();

                return masterdata;
        
        }
        [HttpPost]
        public HttpResponseMessage MasterDataPost([FromBody] MasterData masterData)
        {
            try
            {
                _masterdataoperation.MasterDataAdd(masterData);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Post", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }
        [HttpPut]
        public HttpResponseMessage MasterDataPut([FromBody] MasterData masterData)
        {
            try
            {
                _masterdataoperation.MasterDataEdit(masterData);
               
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Put", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }
        [HttpDelete]
        public HttpResponseMessage MasterDataDelete(int Id)
        {
            try
            {
                MasterData masterData = new MasterData();
                masterData = _masterdataoperation.MasterDataGetById(Id);

                _masterdataoperation.MasterDataDelete(masterData);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Put", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }
    }
}
