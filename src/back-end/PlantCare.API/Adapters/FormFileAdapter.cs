using PlantCare.Application.Plants.Interfaces;

namespace PlantCare.API.Adapters;

public class FormFileAdapter : IUploadedFile
{
    private readonly IFormFile _file;

    public FormFileAdapter(IFormFile file)
    {
        _file = file;
    }
    
    public string FileName => _file.FileName;
    public string ContentType => _file.ContentType;
    public Stream OpenReadStream() => _file.OpenReadStream();
}