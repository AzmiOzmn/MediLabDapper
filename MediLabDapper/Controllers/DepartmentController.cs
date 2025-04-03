using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDeparatmentRepository _departmentRepository;

        public DepartmentController(IDeparatmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View(departments);
        }


        [HttpGet]
        public  IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            
            await _departmentRepository.CreateDepartmentAsycn(createDepartmentDto);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            return View(department);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentRepository.UpdateDepartmentAsycn(updateDepartmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartmentAsycn(id);
            return RedirectToAction("Index");
        }


    }
}
