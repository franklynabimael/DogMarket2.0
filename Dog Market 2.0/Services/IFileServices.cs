using Dog_Market_2._0.ViewModels.Response;

namespace Dog_Market_2._0.Services;

public interface IFileServices
{
    Task<FileResponse> FileManage(IFormFile file);
}
