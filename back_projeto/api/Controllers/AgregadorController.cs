// namespace api.Controllers
// {
//     public class AgregadorController
//     {
//         [ApiController]
// [Route("api/aggregation")]
// public class AggregationController : ControllerBase
// {
//     private readonly IVolunteeringService _volunteeringService;
//     private readonly IResponsibilityService _responsibilityService;
//     private readonly IBenefitService _benefitService;

//     public AggregationController(
//         IVolunteeringService volunteeringService,
//         IResponsibilityService responsibilityService,
//         IBenefitService benefitService)
//     {
//         _volunteeringService = volunteeringService;
//         _responsibilityService = responsibilityService;
//         _benefitService = benefitService;
//     }

//     [HttpGet("card/{volunteeringId}")]
//     public IActionResult GetCard(int volunteeringId)
//     {
//         var volunteering = _volunteeringService.GetVolunteeringById(volunteeringId);
//         var responsibilities = _responsibilityService.GetResponsibilitiesForVolunteering(volunteeringId);
//         var benefits = _benefitService.GetBenefitsForVolunteering(volunteeringId);

//         // Combine the data as needed to build the "CARD"
//         var cardData = new
//         {
//             Volunteering = volunteering,
//             Responsibilities = responsibilities,
//             Benefits = benefits
//         };

//         return Ok(cardData);
//     }
// }

//     }
// }

// [HttpDelete("card/{volunteeringId}")]
// public IActionResult DeleteCard(int volunteeringId)
// {
//     // Verifique se o voluntariado existe
//     var volunteering = _volunteeringService.GetVolunteeringById(volunteeringId);
//     if (volunteering == null)
//     {
//         return NotFound("Volunteering not found");
//     }

//     // Recupere as responsabilidades e benefícios relacionados ao voluntariado
//     var responsibilities = _responsibilityService.GetResponsibilitiesForVolunteering(volunteeringId);
//     var benefits = _benefitService.GetBenefitsForVolunteering(volunteeringId);

//     // Execute a exclusão em cascata
//     _volunteeringService.DeleteVolunteering(volunteering);
//     foreach (var responsibility in responsibilities)
//     {
//         _responsibilityService.DeleteResponsibility(responsibility);
//     }
//     foreach (var benefit in benefits)
//     {
//         _benefitService.DeleteBenefit(benefit);
//     }

//     return Ok("Volunteering, responsibilities, and benefits deleted");
// }
