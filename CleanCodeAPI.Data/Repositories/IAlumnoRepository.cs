using CleanCodeAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeAPI.Data.Repositories
{
    public interface IAlumnoRepository
    {
        Task<IEnumerable<Alumno>> GetAllAlumnos();
        Task<Alumno> GetDetails(int id);
        Task<bool> InsertAlumno(Alumno alumno);
        Task<bool> UpdateAlumno(Alumno alumno);
        Task<bool> DeleteAlumno(Alumno alumno);
    }
}
