﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MRBLACK.Areas.Identity.Data;
using MRBLACK.Data;
using MRBLACK.Helper;
using MRBLACK.Models.ViewModels;

namespace MRBLACK.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class RoleController : Controller
    {
        private readonly IdentitySetupContext _context;
        private readonly int PageSize;
        public RoleController(IdentitySetupContext context)
        {
            _context = context;
            PageSize = 5;
        }


        #region CRUD OPERTIONS

        #region Get Roles
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetPagedListItems("", pageNumber).Result);
        }
        #endregion


        #region Create Role
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("EditCreate", new IdentitySetupRole());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentitySetupRole model)
        {
            if (ModelState.IsValid)
            {
                model.CanBeEditedOrDeleted = true;
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Create);
            return PartialView("EditCreate", model);
        }
        #endregion

        #region Edit Role
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.ActionName = nameof(Edit);
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Roles.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View("EditCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentitySetupRole model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = _context.Roles.Find(model.Id);
                    obj.Name = model.Name;
                    obj.ArName = model.ArName;
                    obj.CanBeEditedOrDeleted = true;
                    _context.Update(obj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Roles.Any(e => e.Id == model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = nameof(Edit);
            return View("EditCreate", model);
        }
        #endregion

        #region Delete Role
        public IActionResult Delete(string id)
        {
            ConfirmDeleteVM model = new ConfirmDeleteVM()
            {
                ControllerName = "Role",
                ActionName = nameof(Delete),
                Title = "حذف من شاشة الادوار",
                PkFieldStrVal = id,
                PkFieldIntVal = null
            };
            return View("_DeleteView", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ConfirmDeleteVM model)
        {
            var obj = await _context.Roles.FindAsync(model.PkFieldStrVal);
            obj.IsDeleted = true;
            obj.CanBeEditedOrDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #endregion


        #region PAGINATION METHODS
        public async Task<PagedList<IdentitySetupRole>> GetPagedListItems(string searchStr, int pageNumber)
        {
            var model = _context.Roles.Where(i => i.MembershipId == null &&
                i.IsDeleted == false);
            if (searchStr != "" && searchStr != null)
            {
                searchStr = searchStr.ToLower();
                model = model.Where(c => c.Name.ToLower().Contains(searchStr) || c.ArName.Contains(searchStr));
            }
            return await PagedList<IdentitySetupRole>.CreateAsync(model, pageNumber, PageSize);
        }

        public IActionResult GetItems(string searchStr, int pageNumber = 1)
        {
            return PartialView("_TableList", GetPagedListItems(searchStr, pageNumber).Result.ToList());
        }


        public IActionResult GetPagination(string searchStr, int pageNumber = 1)
        {
            var model = PagedList<IdentitySetupRole>.GetPaginationObject(GetPagedListItems(searchStr, pageNumber).Result);
            model.GetItemsUrl = "/Role/GetItems";
            model.GetPaginationUrl = "/Role/GetPagination";
            return PartialView("_Pagination", model);
        }

        #endregion

    }
}