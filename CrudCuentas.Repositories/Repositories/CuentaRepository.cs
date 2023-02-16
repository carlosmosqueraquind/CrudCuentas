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
    public class CuentaRepository: ICuentaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CuentaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Cuenta cuenta)
        {
            int idCuentaCreated;
            try
            {
                _dbContext.Add(cuenta);
                await _dbContext.SaveChangesAsync();
                idCuentaCreated = cuenta.Id;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("CuentaRepository.Create(Cuenta cuenta) Exception: ", ex.Message));

            }

            return idCuentaCreated;
        }


        public async Task<int> Delete(int id)
        {
            int response;
            try
            {

                Cuenta cuenta = await _dbContext.Cuentas.FirstAsync(c => c.Id == id);


                _dbContext.Remove(cuenta);
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

        public async Task<List<Cuenta>> GetAll()
        {
            List<Cuenta> cuentas = null;

            try
            {
                cuentas = await _dbContext.Cuentas.ToListAsync();
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("CuentaRepository.GetAll(Cuenta cuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("CuentaRepository.GetAll(Cuenta cuenta) Exception: ", ex.Message));
            }


            return cuentas;
        }

        public async Task<Cuenta> GetById(int id)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                cuenta = await _dbContext.Cuentas.FirstOrDefaultAsync(cuenta => cuenta.Id == id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return cuenta;
        }


        public async Task<int> Update(Cuenta cuenta)
        {
            int response;
            try
            {
                var existingCuenta = _dbContext.Cuentas.Local.SingleOrDefault(c => c.Id == cuenta.Id);
                if (existingCuenta != null)
                {
                    _dbContext.Entry(existingCuenta).State = EntityState.Detached;

                    cuenta.FechaCreacion = existingCuenta.FechaCreacion;
                    cuenta.FechaModificacion = DateTime.Now;
                }

                _dbContext.Update(cuenta);
                await _dbContext.SaveChangesAsync();
                response = cuenta.Id;
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("CuentaRepository.Update(Cuenta cuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("CuentaRepository.Update(Cuenta cuenta) Exception: ", ex.Message));
            }

            return response;
        }

        public async Task<int> UpdateState(int id, int stateId)
        {
            int response;
            try
            {
                var existingCuenta = _dbContext.Cuentas.Local.SingleOrDefault(c => c.Id == id);
                if (existingCuenta != null)
                {
                    _dbContext.Entry(existingCuenta).State = EntityState.Detached;

                    existingCuenta.EstadoCuentaId = stateId;

                    existingCuenta.FechaModificacion = DateTime.Now;
                }

                _dbContext.Update(existingCuenta);
                await _dbContext.SaveChangesAsync();
                response = existingCuenta.Id;
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("CuentaRepository.UpdateState(Cuenta cuenta) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("CuentaRepository.UpdateState(Cuenta cuenta) Exception: ", ex.Message));
            }

            return response;
        }

       

        public async Task<int> ObtenerUltimoId()
        {
            int index;
            try
            {
                index = await _dbContext.Cuentas.MaxAsync(cuenta => cuenta.Id);
                
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("ObtenerUltimoId(int id)", ex.Message));
            }

            return index;
        }


       



    }
}
