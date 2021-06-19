using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.Core.Entitites.MISAttribute;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int? Insert(MISAEntity entity)
        {
            var isValid = ValidateObject(entity);
            if (!isValid)
            {
                return null;
            }
            else 
            {
                var properties = entity.GetType().GetProperties();
                var entityCode = "";

                foreach (var prop in properties)
                {
                    var propertiesCode = prop.GetCustomAttributes(typeof(MISAEntityCode), true);
                    if (propertiesCode.Length > 0)
                    {
                        entityCode = (string)prop.GetValue(entity);
                        var res = _baseRepository.CheckCodeExist(entityCode);
                        if (res == true)
                        {
                            return null;
                        }
                    }
                }
            }
            return _baseRepository.Insert(entity);
        }

        public int? Update(MISAEntity entity, Guid entityId)
        {
            var isValid = ValidateObject(entity);
            if (isValid == true)
            {
                return _baseRepository.Update(entity, entityId);
            }
            return null;
        }

        bool ValidateObject(MISAEntity entity)
        {
            // Xử lý validate chung
            // Kiểm tra tất cả các thuộc tính

            var properties = entity.GetType().GetProperties();
            foreach(var property in properties)
            {
                // Lấy ra property có gán attribute mà MISARequired (bắt buộc nhập)
                var propertyRequired = property.GetCustomAttributes(typeof(MISARequired), true);

                if(propertyRequired.Length > 0){
                    // Lấy ra value của property
                    var value = property.GetValue(entity);
                    var propertyName = property.Name;
                    if(value.ToString() == string.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }

        public int? Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
    }
}
