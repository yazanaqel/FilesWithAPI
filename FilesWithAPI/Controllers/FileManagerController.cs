using FilesWithAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilesWithAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class FileManagerController : ControllerBase
{
	private readonly IManageImage manageImage;

	public FileManagerController(IManageImage manageImage)
	{
		this.manageImage = manageImage;
	}

	[HttpPost("upload")]
	public async Task<IActionResult> Upload(IFormFile file)
	{
		var result = await manageImage.Upload(file);

		return Ok(result);
	}

	[HttpGet("download")]
	public async Task<IActionResult> Download(string fileName)
	{
		var result = await manageImage.Download(fileName);

		return File(result.Item1, result.Item2, result.Item3);
	}
}
