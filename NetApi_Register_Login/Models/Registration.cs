namespace NetApi_Register_Login.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int IsActive { get; set; }
    }
}
