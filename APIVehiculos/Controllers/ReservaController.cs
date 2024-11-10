using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/reservas")]

public class ReservaController : ControllerBase
{
    private readonly IReservaService _reservaServices;

    public ReservaController(IReservaService reservaService)
    {
        _reservaServices = reservaService;

    }

    [HttpGet]

    public ActionResult<List<Reserva>> GetAllReservas()
    {
        return Ok(_reservaServices.GetAllReservas());
    }

    [HttpGet("{id}/reserva")]
    [Authorize(Roles = "admin")]

    public ActionResult<List<Reserva>> GetReservasByUserId(int id)
    {
        var a = _reservaServices.GetReservasByUserId(id);
        return Ok(a);

    }

    [HttpGet("{id}")]
    public ActionResult<Reserva> GetReservaById(int id)
    {
        Reserva? r = _reservaServices.GetReservaById(id);

        if (r == null)
        {
            return NotFound("Reserva no encontrada");
        }

        return Ok(r);
    }

    [HttpPost]
    public ActionResult<Reserva> CreateReserva(ReservaDTO r)
    {
        Reserva _r = _reservaServices.CreateReserva(r);

        return CreatedAtAction(nameof(GetReservaById), new { id = _r.Id }, _r);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteReserva(int id)
    {
        var r = _reservaServices.GetReservaById(id);

        if (r == null) { return NotFound("Reserva no encontrada"); }

        _reservaServices.DeleteReserva(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Reserva> UpdateReserva(int id, Reserva updatedReserva)
    {

        if (id != updatedReserva.Id)
        {
            return BadRequest("El ID de la reserva en la URL no coincide con el ID de la reserva en el cuerpo de la solicitud.");
        }
        var reserva = _reservaServices.UpdateReserva(id, updatedReserva);

        if (reserva is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetReservaById), new { id = reserva.Id }, reserva);
    }

}