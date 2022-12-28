using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongoApi.Interface;

namespace WebMongoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileDeviceController : Controller
    {
        private readonly IMobileStore _context;
        public MobileDeviceController(IMobileStore context)
        {
            _context = context;
        }

        [HttpGet]
        public void Get()
        {
            _context.GetAllMobileDevices();
        }
    }
}
