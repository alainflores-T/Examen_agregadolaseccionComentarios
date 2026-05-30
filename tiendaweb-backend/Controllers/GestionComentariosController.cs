using Microsoft.AspNetCore.Mvc;
using tiendaweb_backend.Datos;
using tiendaweb_backend.Negocio;

namespace tiendaweb_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class GestionComentariosController : Controller
{
    private GestionComentarios _comentarios;

    public GestionComentariosController()
    {
        _comentarios = new GestionComentarios();
    }

    [HttpGet("ListaComentarios")]
    public IEnumerable<Comentario> ListaComentarios()
    {
        return _comentarios.ListarComentarios();
    }

    [HttpPost("ListarComentariosMaterias")]
    public IEnumerable<Comentario> ListarComentariosMaterias(string idmateria)
    {
        return _comentarios.ListarComentariosporIdentidad(idmateria);
    }

    [HttpGet("ListaComentariosIduser")]
    public IEnumerable<Comentario> ListaComentariosIduser(int iduser)
    {
        return _comentarios.ListarComentariosporIDuser(iduser);
    }

    [HttpPut("ActualizarComentario")]
    public void ActualizarComentario(string idcomen ,string comentario)
    {
        _comentarios.ActualizarComentario(idcomen, comentario);
    }

    [HttpDelete("EliminarComentario")]
    public void EliminarComentario(string idcomen)
    {
        _comentarios.EliminarComentario(idcomen);
    }


    [HttpPost("CrearComentario")]

    public void CrearComentario( [FromBody] Comentario comentario)
    {
        _comentarios.CrearComentario(comentario);
        
    }
}