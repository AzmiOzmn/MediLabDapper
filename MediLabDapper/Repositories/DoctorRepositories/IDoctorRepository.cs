using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<ResultDoctorDto>>GetResultDoctorsAsycn();
        Task<IEnumerable<ResultDoctorWithDepartmentDto>>GetDoctorWithDepartmentAsycn();
        Task<GetDoctorByIdDto> GetDoctorByIdAsycn(int id);
        Task CreateDoctorAsync(CreateDoctorDto createDoctorDto);
        Task UpdateDoctorAsync(UpdateDoctorDto createDoctorDto);
        Task DeleteDoctorAsync(int id);
    }
}
