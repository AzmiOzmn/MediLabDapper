using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmentRepositories
{
    public interface IDeparatmentRepository
    {
        Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentsAsync();
        Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id);

        Task CreateDepartmentAsycn(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsycn(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsycn(int id);

    }
}
