using Api.NoSql.Domains;
using Api.NoSql.Interfaces;
using MongoDB.Driver;
using NyousNoSQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.NoSql.Repositories
{
    public class EventoRepository : IEventosRepository
    { 
        private readonly IMongoCollection<EventoDomain> _eventos;

        public EventoRepository(INyousDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _eventos = database.GetCollection<EventoDomain>(settings.EventosCollectionName);
        }
        public void Adicionar(EventoDomain evento)
        {
            try
            {
                _eventos.InsertOne(evento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(string id, EventoDomain evento)
        {
            try
            {
                _eventos.ReplaceOne(evento => evento.Id == id, evento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<EventoDomain> Listar()
        {
            try
            {
                return _eventos.AsQueryable<EventoDomain>().ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(string id)
        {
            try
            {
                _eventos.DeleteOne(c => c.Id == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        EventoDomain IEventosRepository.BuscarPorId(string id)
        {
            try
            {
                return _eventos.Find(e => e.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
