namespace tiendaweb_backend.Datos;

public class Comentario
{
    public string idComentario { get; set; }
    public string texto { get; set; }
    public string fecha { get; set; }
    
    public int idautor  { get; set; }
    public string idmateria { get; set; }
    
}