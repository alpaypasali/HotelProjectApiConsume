using HotelProject.EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Absract
{
    public interface IStaffService:IGenericService<Staff>
    {
        int TGetStaffCount();
        List<Staff> TLast4Staff();
    }
}
