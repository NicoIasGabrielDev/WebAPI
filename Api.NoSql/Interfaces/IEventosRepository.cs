using Api.NoSql.Domains;
using System.Collections.Generic;

namespace Api.NoSql.Interfaces
{
    public interface IEventosRepository
    {
        List<EventoDomain> Listar();
        EventoDomain BuscarPorId(string id);
        void Adicionar(EventoDomain evento);
        void Atualizar(string id, EventoDomain evento);
        void Remover(string id);
    }
}
