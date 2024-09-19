using WebAppWayni.Models;

namespace WebAppWayni.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioAsync(Guid id);
        Task<bool> GetExisteDNIAsync(string dni,Guid? id);
        Task<bool> PostUsuarioAsync(Usuario usuario);
        Task<bool> PutUsuarioAsync(Guid id, Usuario usuario);
        Task<bool> DeleteUsuarioAsync(Guid id);
    }
}
