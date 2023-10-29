namespace FilesWithAPI.Services;

using FilesWithAPI.Helper;
using Microsoft.AspNetCore.StaticFiles;
public class ManageImage : IManageImage
{
	public async Task<string> Upload(IFormFile file)
	{
		string fileName = string.Empty;

		try
		{
			FileInfo fileInfo = new FileInfo(file.FileName);

			fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

			var getFilePath = Common.GetFilePath(fileName);

			using (var fileStream = new FileStream(getFilePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}
			return fileName;

		}
		catch(Exception ex)
		{
			throw ex;
		}
	}

	public async Task<(byte[], string, string)> Download(string fileName)
	{
		try
		{
			var getFilePath = Common.GetFilePath(fileName);

			var provider = new FileExtensionContentTypeProvider();

			if (!provider.TryGetContentType(getFilePath, out var contentType))
			{
				contentType = "application/octet-stream";
			}

			var readAllBytesAsync = await File.ReadAllBytesAsync(getFilePath);

			return (readAllBytesAsync, contentType, Path.GetFileName(getFilePath));
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}


}
