namespace PlantCare.Application.Plants.Interfaces;

public interface IUploadedFile
{
    string FileName { get; }  
    string ContentType { get; }  
    Stream OpenReadStream();
}