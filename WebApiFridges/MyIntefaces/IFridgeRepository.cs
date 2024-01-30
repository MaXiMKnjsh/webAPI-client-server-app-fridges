using System.Collections;
using WebApiFridges.Models;
using WebApiFridges.MyResponceClasses;

namespace WebApiFridges.MyIntefaces
{
    public interface IFridgeRepository   {
        IEnumerable<ResponceFridges> GetFridgesList();
    }
}
