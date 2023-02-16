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
    public class EstadoCuentaRepository: IEstadoCuentaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EstadoCuentaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(EstadoCuenta estadoCuenta)
        {
            int idEstadoCuentaCreated;
            try
            {
                _dbContext.Add(estadoCuenta);
                await _dbContext.SaveChangesAsync();
                idEstadoCuentaCreated = estadoCuenta.Id;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("EstadoCuentaRepository.Create(EstadoCuenta estadoCuenta) Exception: ", ex.Message));

            }

            return idEstadoCuentaCreated;
        }


        public async Task<int> Delete(int id)
        {
            int response;
            try
            {

                EstadoCuenta estadoCuenta = await _dbContext.EstadosCuentas.FirstAsync(c => c.Id == id);


                _dbContext.Remove(estadoCuenta);
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

        public async Task<List<EstadoCuenta>> GetAll()
        {
            List<EstadoCuenta> estadoCuentas = null;

            try
            {
                estadoCuentas = await _dbContext.EstadosCuentas.ToListAsync();
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("EstadoCuentaRepository.GetAll(EstadoCuenta estadoCuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("EstadoCuentaRepository.GetAll(EstadoCuenta estadoCuenta) Exception: ", ex.Message));
            }


            return estadoCuentas;
        }

        public async Task<EstadoCuenta> GetById(int id)
        {
            EstadoCuenta estadoCuenta = new EstadoCuenta();
            try
            {
                estadoCuenta = await _dbContext.EstadosCuentas.FirstOrDefaultAsync(estadoCuenta => estadoCuenta.Id == id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return estadoCuenta;
        }


        public async Task<int> Update(EstadoCuenta estadoCuenta)
        {
            int response;
            try
            {
                var existingEstadoCuenta = _dbContext.EstadosCuentas.Local.SingleOrDefault(c => c.Id == estadoCuenta.Id);
                if (existingEstadoCuenta != null)
                {
                    _dbContext.Entry(existingEstadoCuenta).State = EntityState.Detached;

                    //estadoCuenta.FechaCreacion = existingEstadoCuenta.FechaCreacion;
                    //estadoCuenta.FechaModificacion = DateTime.Now;
                }

                _dbContext.Update(estadoCuenta);
                await _dbContext.SaveChangesAsync();
                response = estadoCuenta.Id;
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("EstadoCuentaRepository.Update(EstadoCuenta estadoCuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("EstadoCuentaRepository.Update(EstadoCuenta estadoCuenta) Exception: ", ex.Message));
            }

            return response;
        }

    }
}
