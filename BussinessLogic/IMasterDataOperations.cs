﻿using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
  public  interface IMasterDataOperations
    {
        Task MasterDataAdd(MasterData data);

        Task MasterDataDelete(MasterData entity);
        IEnumerable<MasterData> GetAllMasterData();
        Task MasterDataEdit(MasterData entity);
        MasterData MasterDataGetById(int Id);
    }
}
