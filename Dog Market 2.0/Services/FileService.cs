using Dog_Market_2._0.ViewModels.Response;
using System.Collections;
using System.Net.Http.Headers;

namespace Dog_Market_2._0.Services;

public class FileService: IFileServices
{
    private const long ImageFileSizeMb = 2; 
    private const long ImageFileSizeLimit = 1024 * 1024 * ImageFileSizeMb;
    private static readonly string[] ImageAllowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

    public async Task<FileResponse> FileManage(IFormFile file)
    {
        long FileSizeLimit; 
        string[] AllowedExtensions;
        FileSizeLimit = ImageFileSizeLimit;
        AllowedExtensions = ImageAllowedExtensions;

        if (file.Length > FileSizeLimit)
        {
            long fileSize = file.Length / 1024;
            long FileLarger = fileSize - FileSizeLimit / 1024;
            return new FileResponse
            {
                Message = $"The file size exceeds limit of {FileSizeLimit / 1024 / 1024}mb",
                isSuccesful = false
            };
        }

        var extension = Path.GetExtension(file.FileName);
        if (!((IList)AllowedExtensions).Contains(extension))
        {
            return new FileResponse
            {
                Message = $"Only  '{string.Join(", ", AllowedExtensions)}' are allowed.",
                isSuccesful = false
            };
        }
        if (file.Length > 0)
        {
            var folderName = Path.Combine("Resources");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
            if (name != null)
            {
                var fileName = name.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                    await file.CopyToAsync(stream).ConfigureAwait(false);
                return new FileResponse
                {
                    FileId = Guid.NewGuid(),
                    Message = "File Uploaded Successfully",
                    isSuccesful = true,
                    FileName= fileName,
                    FileUrl = fullPath,
                    FileSize = file.Length,
                    FileExtension = extension,
                    ContentType = file.ContentType,
                    FileContent = File.ReadAllBytes(fullPath),
                    FileLocation = folderName,
                };
            }
        }
        {
            return new FileResponse
            {
                Message = "The file is empty.",
                isSuccesful = false
            };
        }
    }

  
}
