using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DoctorDtos;
using System.Data;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public class DoctorRepository(DapperContext _context) : IDoctorRepository
    {
        
        private readonly IDbConnection _db = _context.CreateConnection();


        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            string query = "INSERT INTO Doctors (NameSurname, ImageUrl, Description,DepartmentId) VALUES (@NameSurname, @ImageUrl, @Description, @DepartmentId)";
            var parameters = new DynamicParameters(createDoctorDto);  
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            string query = "DELETE FROM Doctors WHERE DoctorId = @DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("DoctorId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<GetDoctorByIdDto> GetDoctorByIdAsycn(int id)
        {
            string query = "SELECT * FROM Doctors WHERE DoctorId = @DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("DoctorId", id);
            return await _db.QueryFirstOrDefaultAsync<GetDoctorByIdDto>(query, parameters);
        }

        public Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetDoctorWithDepartmentAsycn()
        {
             string query = "SELECT d.DoctorId, d.NameSurname, d.ImageUrl, d.Description, dep.DepartmentName FROM Doctors d INNER JOIN Departments dep ON d.DepartmentId = dep.DepartmentId";
             return _db.QueryAsync<ResultDoctorWithDepartmentDto>(query);

        }

        public async Task<IEnumerable<ResultDoctorDto>> GetResultDoctorsAsycn()
        {
            string query = "SELECT * FROM Doctors";
            return await _db.QueryAsync<ResultDoctorDto>(query);
        }

        public Task UpdateDoctorAsync(UpdateDoctorDto createDoctorDto)
        {
            string query = "UPDATE Doctors SET NameSurname = @NameSurname, ImageUrl = @ImageUrl, Description = @Description, DepartmentId = @DepartmentId WHERE DoctorId = @DoctorId";
            var parameters = new DynamicParameters(createDoctorDto);
            return _db.ExecuteAsync(query, parameters);

        }
    }
}
