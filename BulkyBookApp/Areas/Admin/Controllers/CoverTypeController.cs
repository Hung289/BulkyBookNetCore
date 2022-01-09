using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(coverType);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created Successfully!!!";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }

            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);

            if(coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(coverType);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type updated Successfully!!!";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverDataFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (coverDataFromDb == null)
            {
                return NotFound();
            }
            return View(coverDataFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var coverDataFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (coverDataFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(coverDataFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted Successfully!!!";
            return RedirectToAction("Index");
        }
    }
}
