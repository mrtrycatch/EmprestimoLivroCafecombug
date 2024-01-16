namespace EmprestimoLivrosNovo.API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
    }
}
