using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.DataContext;
using CrudCuentas.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Repositories
{
    public class TipoTransaccionRepository: ITipoTransaccionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TipoTransaccionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(TipoTransaccion tipoTransaccion)
        {
            int idTipoTransaccionCreated;
            try
            {
                _dbContext.Add(tipoTransaccion);
                await _dbContext.SaveChangesAsync();
                idTipoTransaccionCreated = tipoTransaccion.Id;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TipoTransaccionRepository.Create(TipoTransaccion tipoTransaccion) Exception: ", ex.Message));

            }

            return idTipoTransaccionCreated;
        }


        public async Task<int> Delete(int id)
        {
            int response;
            try
            {

                TipoTransaccion tipoTransaccion = await _dbContext.TiposTransacciones.FirstAsync(c => c.Id == id);


                _dbContext.Remove(tipoTransaccion);
                response = await _dbContext.SaveChangesAsync();


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Delete() Exception: ", ex.Message));
            }
            return response;
        }

        public async Task<List<TipoTransaccion>> GetAll()
        {
            List<TipoTransaccion> tipoTransaccions = null;

            try
            {
                tipoTransaccions = await _dbContext.TiposTransacciones.ToListAsync();
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("TipoTransaccionRepository.GetAll(TipoTransaccion tipoTransaccion) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TipoTransaccionRepository.GetAll(TipoTransaccion tipoTransaccion) Exception: ", ex.Message));
            }


            return tipoTransaccions;
        }

        public async Task<TipoTransaccion> GetById(int id)
        {
            TipoTransaccion tipoTransaccion = new TipoTransaccion();
            try
            {
                tipoTransaccion = await _dbContext.TiposTransacciones.FirstOrDefaultAsync(tipoTransaccion => tipoTransaccion.Id == id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return tipoTransaccion;
        }

        public async Task<TipoTransaccion> GetByCode(string code)
        {
            TipoTransaccion tipoTransaccion = new TipoTransaccion();
            try
            {
                tipoTransaccion = await _dbContext.TiposTransacciones.FirstOrDefaultAsync(tipoTransaccion => tipoTransaccion.Iniciales == code);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return tipoTransaccion;
        }


        public async Task<int> Update(TipoTransaccion tipoTransaccion)
        {
            int response;
            try
            {
                var existingTipoTransaccion = _dbContext.TiposTransacciones.Local.SingleOrDefault(c => c.Id == tipoTransaccion.Id);
                if (existingTipoTransaccion != null)
                {
                    _dbContext.Entry(existingTipoTransaccion).State = EntityState.Detached;

                    
                }

                _dbContext.Update(tipoTransaccion);
                await _dbContext.SaveChangesAsync();
                response = tipoTransaccion.Id;
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("TipoTransaccionRepository.Update(TipoTransaccion tipoTransaccion) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TipoTransaccionRepository.Update(TipoTransaccion tipoTransaccion) Exception: ", ex.Message));
            }

            return response;
        }


    }
}
