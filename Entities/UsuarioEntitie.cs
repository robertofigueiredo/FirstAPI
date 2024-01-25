namespace Awesomedevevents.API.Entities
{
    public class UsuarioEntitie
    {
        public UsuarioEntitie()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data_Inicial { get; set; }
        public DateTime Data_Final { get; set; }
        public bool IsDeleted{ get; set; }
        public void Update(UsuarioEntitie Dados)
        {
            Titulo = Dados.Titulo;
            Descricao = Dados.Titulo;  
            Data_Inicial = Dados.Data_Inicial;
            Data_Final = Dados.Data_Final;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
