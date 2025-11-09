using Microsoft.AspNetCore.Mvc;

namespace Project.Wild.Pony.Api;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    
    private static readonly List<PaymentDto> _payments = new()
    {
        new PaymentDto { Id = 1, Amount = 100, Status = "Paid" },
        new PaymentDto { Id = 2, Amount = 50,  Status = "Pending" }
    };

    // GET /api/payments
    [HttpGet]
    public IActionResult GetAll() => Ok(_payments);

    // GET /api/payments/{id}
    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        var p = _payments.FirstOrDefault(x => x.Id == id);
        return p is null ? NotFound() : Ok(p);
    }

    // POST /api/payments
    [HttpPost]
    public IActionResult Create([FromBody] CreatePaymentDto dto)
    {
        if (dto is null) return BadRequest();

        var nextId = _payments.Count == 0 ? 1 : _payments.Max(x => x.Id) + 1;
        var payment = new PaymentDto
        {
            Id = nextId,
            Amount = dto.Amount,
            Status = dto.Status ?? "Pending"
        };
        _payments.Add(payment);
        return CreatedAtAction(nameof(GetOne), new { id = payment.Id }, payment);
    }

    // PUT /api/payments/{id}
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdatePaymentDto dto)
    {
        var p = _payments.FirstOrDefault(x => x.Id == id);
        if (p is null) return NotFound();

        if (dto.Amount.HasValue) p.Amount = dto.Amount.Value;
        if (!string.IsNullOrWhiteSpace(dto.Status)) p.Status = dto.Status;

        return Ok(p);
    }

    // DELETE /api/payments/{id}
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var p = _payments.FirstOrDefault(x => x.Id == id);
        if (p is null) return NotFound();

        _payments.Remove(p);
        return NoContent();
    }

    // DTOs
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }

    public class UpdatePaymentDto
    {
        public decimal? Amount { get; set; }
        public string? Status { get; set; }
    }
}
