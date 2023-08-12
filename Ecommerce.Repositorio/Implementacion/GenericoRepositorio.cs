using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositorio.Implementacion
{
    public class GenericoRepositorio<Tmodelo> : IGenericoRepositorio<Tmodelo> where Tmodelo : class
    {
        private readonly DbecomerceContext _dbContext;
        public GenericoRepositorio(DbecomerceContext dbContext )
        {
            _dbContext = dbContext;
        }
        public IQueryable<Tmodelo> Consultar(Expression<Func<Tmodelo, bool>>? filtro = null)
        {
            IQueryable<Tmodelo> consulta = (filtro == null) ? _dbContext.Set<Tmodelo>() : _dbContext.Set<Tmodelo>().Where(filtro);
            return consulta;
        }

        public async Task<Tmodelo> Crear(Tmodelo modelo)
        {
            try
            {
                _dbContext.Set<Tmodelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Editar(Tmodelo modelo)
        {
            try
            {
                _dbContext.Set<Tmodelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(Tmodelo modelo)
        {
            try
            {
                _dbContext.Set<Tmodelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
