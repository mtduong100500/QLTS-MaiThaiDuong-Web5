﻿using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (isValid == true)
            {
                return _baseRepository.Insert(entity);
            }
            return null;
        }

        public int? Update(MISAEntity entity, Guid entityId)
        {
            return _baseRepository.Update(entity, entityId);
        }

        bool ValidateObject(MISAEntity entity)
        {
            // Xử lý validate chung
            var isValid = true;
            isValid = ValidateCustom(entity);
            return isValid;
        }

        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }

        public int? Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
