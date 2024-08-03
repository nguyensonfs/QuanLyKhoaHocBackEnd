using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.RoleRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _roleService.GetAllRoles(pageSize,pageNumber));
        }

        [HttpPost]
        public async Task<IActionResult> Create( Request_CreateRole request)
        {
            return Ok(await _roleService.CreateRole(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Request_UpdateRole request)
        {
            return Ok(await _roleService.UpdateRole(id,request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            return Ok(await _roleService.DeleteRole(id));
        }
    }
}
