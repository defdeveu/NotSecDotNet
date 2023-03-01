namespace NotSecDotNet.Dto
{
    public class ChangePasswordDto

    {
        public String user { get; set; }
        public String oldPassword { get; set; }

        public String newPassword { get; set; }
    }
}
