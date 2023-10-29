namespace FilesWithAPI.Services;

public interface IManageImage
{
	Task<string> Upload(IFormFile file);
	Task<(byte[], string, string)> Download(string fileName);
}
