using MISA.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructures
{
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        /// <summary>
        /// Hàm kiểm tra mã tài sản đã tồn tại hay chưa
        /// </summary>
        /// <param name="assetCode">Mã tài sản cần check</param>
        /// <returns>true: đã tồn tại, false: ko tồn tại</returns>
        /// CreatedBy: MTDUONG(16/06/2021)
        bool CheckAssetCodeExist(string assetCode);
    }
}
