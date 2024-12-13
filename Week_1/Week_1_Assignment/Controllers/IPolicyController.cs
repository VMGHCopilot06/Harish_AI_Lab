using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPolicyController
{
    Task<ActionResult<IEnumerable<Policy>>> GetPolicies([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10);
    Task<ActionResult<Policy>> GetPolicy(int id);
    Task<IActionResult> PutPolicy(int id, Policy policy);
    Task<ActionResult<Policy>> PostPolicy(Policy policy);
    Task<IActionResult> DeletePolicy(int id);
}
