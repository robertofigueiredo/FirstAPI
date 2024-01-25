using Awesomedevevents.API.Entities;

namespace Awesomedevevents.API.Persistence
{
    public class UsuarioDbContext
    {
        public List<UsuarioEntitie> DevEvents {get;set;}
        public UsuarioDbContext()
        {
            DevEvents = new List<UsuarioEntitie>();
        }
    }
}
