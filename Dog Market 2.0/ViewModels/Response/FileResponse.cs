namespace Dog_Market_2._0.ViewModels.Response;

public class FileResponse
{
    public Guid FileId { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileContent { get; set; }
    public string FileExtension { get; set; }
    public string FileLocation { get; set; }
    public string FileUrl { get; set; }
    public long FileSize { get; set; }
    public bool isSuccesful { get; set; }
    public string Message { get; set; }
}
