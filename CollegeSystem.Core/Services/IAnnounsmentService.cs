using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface IAnnounsmentService
    {
        Task<Announsment> AddAnnounsmentAsync(AnnounsmentRequest announunsment);
        Task<List<Announsment>> GetAllAnnounsmentAsync();
        Task<Announsment> GetAnnounsmentByIdAsync(int id);

    }
}
