using CollegeSystem.Core;
using CollegeSystem.Core.Models.DB;
using CollegeSystem.Core.Models.Request;
using CollegeSystem.Core.Services;

namespace CollegeSystem.API.Services
{
    public class AnnounsmentService : IAnnounsmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AnnounsmentService> _logger;
        private readonly IEmailService _emailService;

        public AnnounsmentService(IUnitOfWork unitOfWork, ILogger<AnnounsmentService> logger, IEmailService emailService) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<Announsment> AddAnnounsmentAsync(AnnounsmentRequest announunsment)
        {
            var logSignature = "<< AnnounsmentService --- AddAnnounsmentAsync>>"; ;

            try
            {
                var newAnnounsent = new Announsment { Date = announunsment.Date, Description = announunsment.Description, Title = announunsment.Title };

                _logger.LogInformation($"{logSignature} starting adding new announsment");

                var result =  await _unitOfWork.Announsment.AddAsync(newAnnounsent);

                if (result == null) 
                {
                    _logger.LogError($"{logSignature} failed while adding new announsment");
                    return null;
                }

                await _unitOfWork.SaveAsync();

                await _emailService.PodcastAnnounsmentAsync(newAnnounsent);

                _logger.LogInformation($"{logSignature} finished adding new announsment");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while adding announsment : {ex.Message}");
                return null;
            }
        }

        public async Task<List<Announsment>> GetAllAnnounsmentAsync()
        {
            var logSignature = "<< AnnounsmentService --- GetAllAnnounsmentAsync>>"; ;

            try
            {

                _logger.LogInformation($"{logSignature} starting getting announsments");

                var result = await _unitOfWork.Announsment.GetAllAsync();

                if (result == null)
                {
                    _logger.LogError($"{logSignature} failed while getting announsments");
                    return null;
                }

                _logger.LogInformation($"{logSignature} finished Getting announsments");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while getting announsments : {ex.Message}");
                return null;
            }
        }

        public async Task<Announsment> GetAnnounsmentByIdAsync(int id)
        {
            var logSignature = "<< AnnounsmentService --- GetAnnounsmentByIdAsync>>"; ;

            try
            {

                _logger.LogInformation($"{logSignature} starting getting announsment");

                var result = await _unitOfWork.Announsment.GetByIdAsync(id);

                if (result == null)
                {
                    _logger.LogError($"{logSignature} failed while getting announsment id : {id}");
                    return null;
                }

                _logger.LogInformation($"{logSignature} finished Getting announsment");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{logSignature} something went wrong while getting announsment : {ex.Message}");
                return null;
            };
        }
    }
}
