using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Helpers;
using Demo.PL.ViewModels;
using Demon.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            IEnumerable<Employee> employees;
            if(SearchValue == null)
            {
                 employees = await _unitOfWork.EmployeeRepository.GetAll();
               
            }
            else
            {
                 employees = _unitOfWork.EmployeeRepository.SearchEmployeeByName(SearchValue);
    
            }
            var MappedEmployee = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployee);
        }
            

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments =_unitOfWork.DepartmentRepository.GetAll().Result;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            if (ModelState.IsValid)
            {
             employeeViewModel.ImageName= DocumentSettings.UploadFile(employeeViewModel.Image, "Images");
               var MappedEmployee= _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
              await  _unitOfWork.EmployeeRepository.Add(MappedEmployee);
              await  _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            /*var departments = _departmentRepository.GetAll();*/
            return View(employeeViewModel);

        }

        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id is null)
            {
                return BadRequest();
            }

            var employee =await _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee is null)
            {
                return NotFound();
            }
            var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(ViewName, MappedEmployee);


        }

        public async Task<IActionResult> Edit(int? id)
        {

            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll().Result;

            return await Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeeViewModel)
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            if (id != employeeViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employeeViewModel.ImageName = DocumentSettings.UploadFile(employeeViewModel.Image, "Images");
                    var MappedEmployee= _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                    _unitOfWork.EmployeeRepository.Update(MappedEmployee);
                   await _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employeeViewModel);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel.Id != id)
            {
                return BadRequest();
            }
            try
            {
                var MappedEmployee=_mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                _unitOfWork.EmployeeRepository.Delete(MappedEmployee);
              int result=await  _unitOfWork.Complete();
                if(result>0)
                {
                    DocumentSettings.Delete(employeeViewModel.ImageName, "Images");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employeeViewModel);
            }
        }
    }
}
