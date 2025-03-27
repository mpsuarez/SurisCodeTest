using Microsoft.EntityFrameworkCore;
using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories
{
    public class ReserveRepository : GenericRepository<Reserve>
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public ReserveRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Reserve>> GetAllReservesforListAsync()
        {
            return await _unitOfWork.Context.Reserve
                .Include(x => x.ServiceWorkingTime)
                .Include(x => x.ServiceWorkingTime.WorkingTime)
                .Include(x => x.ServiceWorkingTime.Service)
                .ToListAsync();
        }

    }
}
