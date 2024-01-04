namespace EndPoint3.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
