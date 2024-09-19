using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiWayni.Models;

namespace WebApiWayni.Services
{
    public class UsuariosService: IUsuariosService
    {
        private readonly WayniContext context;

        public UsuariosService(WayniContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Usuario> Get()
        {
            return context.Usuario.OrderBy(y => y.Nombre);
        }

        public Usuario? Get(Guid id)
        {
            return context.Usuario.Find(id);
        }

        public bool GetExisteDNI(string dni,Guid? id)
        {
            if(id == null)
            {
                return context.Usuario.Any(u => u.DNI == dni);
            }
            else
            {
                return context.Usuario.Any(u => u.DNI == dni && u.Id != id);
            }
        }

        public async Task Save(Usuario usuario)
        {
            try
            {
                context.Add(usuario);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                throw;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SqlException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public async Task Update(Guid id, Usuario usuario)
        {
            try
            {
                var usuarioActual = context.Usuario.Find(id);

                if (usuarioActual != null)
                {
                    usuarioActual.Nombre = usuario.Nombre;
                    usuarioActual.Apellido = usuario.Apellido;
                    usuarioActual.DNI = usuario.DNI;

                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                throw;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SqlException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
            
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var usuarioActual = context.Usuario.Find(id);

                if (usuarioActual != null)
                {
                    context.Remove(usuarioActual);
                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                throw;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SqlException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
    }

    public interface IUsuariosService
    {
        IEnumerable<Usuario> Get();
        Usuario? Get(Guid id);

        bool GetExisteDNI(string dni,Guid? id);
        Task Save(Usuario usuario);

        Task Update(Guid id, Usuario usuario);

        Task Delete(Guid id);
    }
}
