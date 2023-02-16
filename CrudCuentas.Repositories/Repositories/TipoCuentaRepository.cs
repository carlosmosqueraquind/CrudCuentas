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
    public class TipoCuentaRepository: ITipoCuentaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TipoCuentaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(TipoCuenta tipoCuenta)
        {
            int idTipoCuentaCreated;
            try
            {
                _dbContext.Add(tipoCuenta);
                await _dbContext.SaveChangesAsync();
                idTipoCuentaCreated = tipoCuenta.Id;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TipoCuentaRepository.Create(TipoCuenta tipoCuenta) Exception: ", ex.Message));

            }

            return idTipoCuentaCreated;
        }


        public async Task<int> Delete(int id)
        {
            int response;
            try
            {

                TipoCuenta tipoCuenta = await _dbContext.TiposCuentas.FirstAsync(c => c.Id == id);


                _dbContext.Remove(tipoCuenta);
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

        public async Task<List<TipoCuenta>> GetAll()
        {
            List<TipoCuenta> tipoCuentas = null;

            try
            {
                tipoCuentas = await _dbContext.TiposCuentas.ToListAsync();
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("TipoCuentaRepository.GetAll(TipoCuenta tipoCuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TipoCuentaRepository.GetAll(TipoCuenta tipoCuenta) Exception: ", ex.Message));
            }


            return tipoCuentas;
        }

        public async Task<TipoCuenta> GetById(int id)
        {
            TipoCuenta tipoCuenta = new TipoCuenta();
            try
            {
                tipoCuenta = await _dbContext.TiposCuentas.FirstOrDefaultAsync(tipoCuenta => tipoCuenta.Id == id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return tipoCuenta;
        }


        public async Task<int> Update(TipoCuenta tipoCuenta)
        {
            int response;
            try
            {
                var existingTipoCuenta = _dbContext.TiposCuentas.Local.SingleOrDefault(c => c.Id == tipoCuenta.Id);
                if (existingTipoCuenta != null)
                {
                    _dbContext.Entry(existingTipoCuenta).State = EntityState.Detached;

                    //tipoCuenta.FechaCreacion = existingTipoCuenta.FechaCreacion;
                    //tipoCuenta.FechaModificacion = DateTime.Now;
                }

                _dbContext.Update(tipoCuenta);
                await _dbContext.SaveChangesAsync();
                response = tipoCuenta.Id;
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("TipoCuentaRepository.Update(TipoCuenta tipoCuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TipoCuentaRepository.Update(TipoCuenta tipoCuenta) Exception: ", ex.Message));
            }

            return response;
        }


        
    }
}
