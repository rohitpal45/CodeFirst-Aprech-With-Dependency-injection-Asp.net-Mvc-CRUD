using MenuMasterInterface.InterFaces;
using MenuMasterInterface.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMasterInterface.Repository
{
    public  class MenuConcrete: IMenu
    {
        private readonly DataAccessContext _context;
        private bool _disposed = false;
        public MenuConcrete(DataAccessContext context)
        {
            _context = context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        public List<MenuMaster> GetAllMenu()
        {
            try
            {
                return _context.MenuMaster.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MenuMaster GetMenuById(int? menuId)
        {
            try
            {
                return _context.MenuMaster.Find(menuId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? AddMenu(MenuMaster menuMaster)
        {
            try
            {
                int? result = -1;

                if (menuMaster != null)
                {
                    menuMaster.CreateDate = DateTime.Now;
                    _context.MenuMaster.Add(menuMaster);
                    _context.SaveChanges();
                    result = menuMaster.MenuId;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? UpdateMenu(MenuMaster menuMaster)
        {
            try
            {
                int? result = -1;

                if (menuMaster != null)
                {
                    menuMaster.CreateDate = DateTime.Now;
                    _context.Entry(menuMaster).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = menuMaster.MenuId;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMenu(int? menuId)
        {
            try
            {
                MenuMaster menuMaster = _context.MenuMaster.Find(menuId);
                if (menuMaster != null) _context.MenuMaster.Remove(menuMaster);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
