using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    public interface IUnitofWork:IDisposable
    {
        IGenericRepo<Country> countries { get; }
        IGenericRepo<Hotel> hotels { get; }
        Task Save();
    }
}
