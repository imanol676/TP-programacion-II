using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/vehiculos")]
public class vehiculoController : ControllerBase
{
    private readonly IVehiculoService _vehiculoService;

    public vehiculoController(IVehiculoService vehiculoService)
    {
        _vehiculoService = vehiculoService;
    }

    [HttpGet]
    public ActionResult<List<Vehiculo>> GetAllVehiculos()
    {
        return Ok(_vehiculoService.GetAllVehiculos());
    }

    [HttpGet("{id}/vehiculo")]

    public ActionResult<List<Vehiculo>> GetVehiculoById(int id)
    {
        var a = _vehiculoService.GetVehiculoById(id);
        return Ok(a);

    }

    [HttpPost]
    public ActionResult<Vehiculo> CreateVehiculo(VehiculoDTO v)
    {
        Vehiculo _v = _vehiculoService.CreateVehiculo(v);

        return CreatedAtAction(nameof(GetVehiculoById), new { id = _v.Id }, _v);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteVehiculo(int id)
    {
        var v = _vehiculoService.GetVehiculoById(id);

        if (v == null) { return NotFound("Vehiculo no encontrado"); }

        _vehiculoService.DeleteVehiculo(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Vehiculo> UpdateReserva(int id, Vehiculo updatedVehiculo)
    {
        // Asegurarse de que el ID del autor en la solicitud coincida con el ID del parámetro
        if (id != updatedVehiculo.Id)
        {
            return BadRequest("El ID del vehiculo en la URL no coincide con el ID del vehiculo en el cuerpo de la solicitud.");
        }
        var vehiculo = _vehiculoService.UpdateVehiculo(id, updatedVehiculo);

        if (vehiculo is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetVehiculoById), new { id = vehiculo.Id }, vehiculo);
    }


}