using Demo.DAL.Entities;
using Demon.BLL.Interfaces;
using Demon.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var departments= await _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            /*var departments = _departmentRepository.GetAll();*/
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
              await  _unitOfWork.DepartmentRepository.Add(department);
               int result= await _unitOfWork.Complete();
             
                return RedirectToAction(nameof(Index));
            }
            /*var departments = _departmentRepository.GetAll();*/
            return View(department);

        }

        public async Task<IActionResult> Details(int? id,string ViewName= "Details")
        {
           if(id is null)
            {
                return BadRequest();
            }

            var department = await _unitOfWork.DepartmentRepository.Get(id.Value);
            if(department is null)
            {
                return NotFound();
            }
            return View(ViewName,department);


        }

        public async Task<IActionResult> Edit(int? id)
        {

            //if (id is null)
            //{
            //    return BadRequest();
            //}
            //var department=_departmentRepository.Get(id.Value);
            //if(department is null)
            //{
            //    return NotFound();
            //}
            return await Details(id,"Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id ,Department department)
        {
            if(id != department.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                   await _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                }
                
            }
            
         
            
            return View(department);

        }
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            return await Details(id,"Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute]int id,Department department)
        {
            if(department.Id != id)
            {
                return BadRequest();
            }
            try
            {
                _unitOfWork.DepartmentRepository.Delete(department);
              await  _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(department);
            }
        }

    }
}
