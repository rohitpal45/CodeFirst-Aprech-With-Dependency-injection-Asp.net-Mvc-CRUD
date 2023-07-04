using MenuMasterInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMasterInterface.InterFaces
{
    public interface IMenu:IDisposable
    {
        List<MenuMaster> GetAllMenu(); //Get All Record 
      //  List<MenuMaster> GetAllActiveMenu(); 
        MenuMaster GetMenuById(int? menuId); //gte Single Record 
        int? AddMenu(MenuMaster menuMaster); // Insert Menu 
        int? UpdateMenu(MenuMaster menuMaster); //Update Memu 
        void DeleteMenu(int? menuId); // Delete MEnu
    }
}
