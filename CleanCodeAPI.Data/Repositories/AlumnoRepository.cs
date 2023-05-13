using CleanCodeAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeAPI.Data.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public AlumnoRepository(MySQLConfiguration connectionString)
        {

            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteAlumno(Alumno alumno)
        {
            var db = dbConnection();

            var sql = "@DELETE FROM Alumno WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new {id = alumno.id});

            return result > 0;
        }

        public async Task<IEnumerable<Alumno>> GetAllAlumnos()
        {
            var db = dbConnection();
            var sql = @"SELECT *" +
                "FROM Alumno ";

            return await db.QueryAsync<Alumno>(sql, new { });
        }

        public async Task<Alumno> GetDetails(int id)
        {

            var db = dbConnection();
            var sql = @"SELECT *
                        FROM ALUMNO
                        WHERE ID = @id";

            return await db.QueryFirstOrDefaultAsync<Alumno>(sql, new { Id = id});
        }

        public async Task<bool> InsertAlumno(Alumno alumno)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Alumno (nombre, apellido, direccion)" +
                "VALUES (@nombre, @apellido, @direccion)" +
                "WHERE id = @id ";

            var result = await db.ExecuteAsync(sql, new { alumno.nombre, alumno.apellido, alumno.direccion});

            return result > 0;
        }

        public async Task<bool> UpdateAlumno(Alumno alumno)
        {
            var db = dbConnection();
            var sql = @" UPDATE Alumno 
                SET (nombre = @nombre, 
                    apellido = @apellido, 
                    direccion = @direccion)" +
                "WHERE id = @id ";

            var result = await db.ExecuteAsync(sql, new {alumno.nombre, alumno.apellido, alumno.direccion, alumno.id});

            return result > 0;
        }
    }
}
