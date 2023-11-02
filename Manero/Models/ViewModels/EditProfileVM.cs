namespace Manero.Models.ViewModels
{
    public class EditProfileVM
    {
        public IFormFile? UploadProfileImage { get; set; }
        public int Id { get; set; }
        public string? FileName { get; set; }
        public byte[]? ImageData { get; set; }
    }
}
