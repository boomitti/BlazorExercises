using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace File_Upload.Services
{
	public interface IFileUpload
	{
		Task UploadFile(IBrowserFile browserFile);
	}
	public class FileUpload : IFileUpload
	{
		private IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<FileUpload> _logger;

		public FileUpload(IWebHostEnvironment webHostEnvironment, ILogger<FileUpload> logger)
		{
			_webHostEnvironment = webHostEnvironment;
			_logger = logger;
		}
		public async Task UploadFile(IBrowserFile browserFile)
		{
			if (browserFile is not null)
			{
				try
				{
					var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", browserFile.Name);

					using (var stream = browserFile.OpenReadStream())
					{
						var fileStream = File.Create(uploadPath);
						await stream.CopyToAsync(fileStream);
						fileStream.Close();
					}

				} catch (Exception ex)
				{
					_logger.LogError(ex.ToString());	
				}
			}
		}
	}
}
