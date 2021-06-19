using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entitites;
using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using MISA.QLTS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Infrastruture.Repositories
{
    /// <summary>
    /// Phòng ban API
    /// CreatedBy MTDUONG (17/06/2021)
    /// </summary>
    public class DepartmentController : MISAEntityController<Department>
    {
        IDepartmentRepository _deparmentRepository;
        IDepartmentService _deparmentService;

        public DepartmentController(IDepartmentService deparmentService, IDepartmentRepository deparmentRepository) : base(deparmentService, deparmentRepository)
        {
            _deparmentService = deparmentService;
            _deparmentRepository = deparmentRepository;
        }
    }
}
