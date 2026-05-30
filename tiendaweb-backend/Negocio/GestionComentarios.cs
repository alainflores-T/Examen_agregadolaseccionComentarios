using Microsoft.AspNetCore.Authentication.Cookies;
using tiendaweb_backend.Datos;

namespace tiendaweb_backend.Negocio;

public class GestionComentarios
{
    public static List<Comentario> ListaComentarios { get; set; } = new List<Comentario>
    {
        new(){idComentario = "012" , texto = "Pesima Materia"
            ,fecha = "30/05/2026",idautor = 1 , idmateria = "Calculo I"},
        new(){idComentario = "020" , texto = "Me cae bien el profe"
            ,fecha = "21/06/2026",idautor = 2 , idmateria = "Calculo II"}
    };
    // public static List<Tarea> Tareas { get; set; }= new List<Tarea>()
    // {
    //     new(){IdTarea = "1",Titulo = "Practico #3",Descripcion = "Hacer el practico #3 de calculo 1",Fecha = "01-06-2026", PesoTarea = 5},
    //     new(){IdTarea = "2",Titulo = "Ensayo Novela",Descripcion = "Hacer un ensayo sobre mi novela favorita",Fecha = "04-06-2026", PesoTarea = 3},
    //     new(){IdTarea = "3",Titulo = "Investigacion antropologia",Descripcion = "Hacer la investigavionde los 13 objetivos",Fecha = "07-06-2026", PesoTarea = 5},
    //     new(){IdTarea = "4",Titulo = "Practica de fisica",Descripcion = "Realizar la practica de fisica",Fecha = "18-06-2026", PesoTarea = 8}
    // };
    public static List<Materia> Materias { get; set; } = new List<Materia> {
        new() { NombreMateria = "Calculo I", PesoMateria = 4 },
        new() { NombreMateria = "Escritura Academica", PesoMateria = 5 },
        new() { NombreMateria = "Intro a Programacion", PesoMateria = 6 },
        new() { NombreMateria = "Fisica I", PesoMateria = 3 }
    };

    public static List<Usuario> Listasdeusuarios { get; set; } = new List<Usuario>()
    {
        new() { Id = 1, nombre = "Alain", email = "prueba", contrasena = "prueba123" },
        new() { Id = 2, nombre = "Christian", email = "prueba2", contrasena = "prueba123" }
    };
    
    public List<Comentario> ListarComentarios()
    {
        return ListaComentarios;
    }

    public List<Comentario> ListarComentariosporIDuser(int iduser)
    {
        List<Comentario> filtrados = new List<Comentario>();

        foreach (var VARIABLE in ListaComentarios)
        {
            if (VARIABLE.idautor == iduser)
            {
                filtrados.Add(VARIABLE);
            }
        }
        
        return filtrados;
    }

    public List<Comentario> ListarComentariosporIdentidad(string nombre)
    {
        List<Comentario> filtrados = new List<Comentario>();

        foreach (var VARIABLE in ListaComentarios)
        {
            if (VARIABLE.idmateria.ToLower() == nombre.ToLower())
            {
                filtrados.Add(VARIABLE);
            }
        }
        
        return filtrados;
    }

    public bool ValidarIdentidadMateria(string nombremateria)
    {
        foreach (var VARIABLE in Materias)
        {
            if (VARIABLE.NombreMateria.ToLower() == nombremateria.ToLower())
            {
                return true;
            }
        }
        return false;
    }
    public bool ValidarComentarios(string comentario)
    {
        var verificar = comentario.DefaultIfEmpty();
        if(verificar==null)
        {
            return false;
        }

        return true;
    }

    public void  ActualizarComentario(string idcomentario, string actualizado)
    {
        
        if(!ValidarComentarios(actualizado)) return;
        int index = ListaComentarios.FindIndex(x=> x.idComentario.ToLower() == idcomentario.ToLower());
        
        ListaComentarios[index] = new()
        {
            idComentario = ListaComentarios[index].idComentario,
            texto = actualizado,
            idmateria = ListaComentarios[index].idmateria,
            idautor = ListaComentarios[index].idautor
        };
    }

    public void  EliminarComentario(string idcomentario)
    {
        int index = -1;
        
        for (int i = 0; i < ListaComentarios.Count; i++)
        {
            if (ListaComentarios[i].idComentario.ToLower() == idcomentario.ToLower())
            {
                index = i;
                break;
            }
        }
if(index==-1) return;
    ListaComentarios.RemoveAt(index);
        
        
    }

    public void CrearComentario(Comentario comentario)
    {
        if(!ValidarComentarios(comentario.texto)) return;
        if(!ValidarIdentidadMateria(comentario.idmateria) ) return;
        
        ListaComentarios.Add(comentario);
    }
}