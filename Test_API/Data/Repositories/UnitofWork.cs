using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepo<Country> _countries;

        private IGenericRepo<Hotel> _hotels;

        public UnitofWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepo<Country> countries => _countries ??= new GenericRepo<Country>(_context);
        public IGenericRepo<Hotel> hotels => _hotels ??= new GenericRepo<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
