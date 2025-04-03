using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmentRepositories
{
    public class DepartmentRepository : IDeparatmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDepartmentAsycn(CreateDepartmentDto createDepartmentDto)
        {
            string query = "INSERT INTO Departments (DepartmentName, Description) VALUES (@DepartmentName, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("DepartmentName", createDepartmentDto.DepartmentName);
            parameters.Add("Description", createDepartmentDto.Description);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDepartmentAsycn(int id)
        {
            string query = "DELETE FROM Departments WHERE DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("DepartmentId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentsAsync()
        {
            string query = "SELECT * FROM Departments";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultDepartmentDto>(query);
           
        }

        public async Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id)
        {
            string query = "SELECT * FROM Departments WHERE DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("DepartmentId", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetDepartmentByIdDto>(query, parameters);
        }

        public async Task UpdateDepartmentAsycn(UpdateDepartmentDto updateDepartmentDto)
        {
            string query = "UPDATE Departments SET DepartmentName = @DepartmentName, Description = @Description WHERE DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters(updateDepartmentDto);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);


        }
    }
}
