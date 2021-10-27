using MRBLACK.Data;
using MRBLACK.Models.Database;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MRBLACK.Helper
{
    public static class GeneralHelper
    {
        private static Expression<Func<ServiceCategory, bool>> filter;
        private static List<ServiceCategory> Categories;
        public static string GetLoggedUserRole(string LoggedUserId, IdentitySetupContext _context)
        {
            var LoggedUserRole = "";
            if (LoggedUserId != null)
            {
                var roles = _context.UserRoles.Where(c => c.UserId == LoggedUserId);
                if (roles != null)
                {
                    LoggedUserRole = _context.Roles.Find(roles.First().RoleId).Name;
                }
            }
            return LoggedUserRole;
        }

        public static List<ServiceCategory> GetLastNodesInAllCategories(Repository<ServiceCategory> _Category)
        {
            filter = f => f.InverseParentCategory.Count() == 0;
            Categories = _Category.GetAll(filter, null, "InverseParentCategory").ToList();
            return Categories;
        }

        public static List<ServiceCategory> GetParentNodesInAllCategories(Repository<ServiceCategory> _Category)
        {
            filter  = f => f.ParentCategoryId == null;
            Categories = _Category.GetAll(filter, null).ToList();
            return Categories;
        }

        public static List<ServiceCategory> GetSpecificChildernCategories(Repository<ServiceCategory> _Category, int parentId, List<ServiceCategory> childernList)
        {
            var parent = _Category.GetFirstOrDefault(c => c.Id == parentId, "InverseParentCategory");
            if(parent.InverseParentCategory != null && parent.InverseParentCategory.Count() > 0)
            {
                foreach (var item in parent.InverseParentCategory)
                {
                    childernList.Add(item);
                    var child = _Category.GetFirstOrDefault(c => c.Id == item.Id, "InverseParentCategory");
                    if(child.InverseParentCategory != null && child.InverseParentCategory.Count() > 0)
                    {
                        GetSpecificChildernCategories(_Category, child.Id, childernList);
                    }
                }
            }
            
            return childernList;
        }
    }
}
