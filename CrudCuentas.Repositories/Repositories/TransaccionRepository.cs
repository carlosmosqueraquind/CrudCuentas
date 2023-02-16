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
    public class TransaccionRepository: ITransaccionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TransaccionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Transaccion transaccion)
        {
            int idTransaccionCreated;

            try
            {
                
                _dbContext.Add(transaccion);
                await _dbContext.SaveChangesAsync();
                idTransaccionCreated = transaccion.Id;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TransaccionRepository.Create(Transaccion transaccion) Exception: ", ex.Message));

            }

            return idTransaccionCreated;
        }


        //public async Task<int> Delete(int id)
        //{
        //    int response;
        //    try
        //    {

        //        Transaccion transaccion = await _dbContext.Transacciones.FirstAsync(c => c.Id == id);


        //        _dbContext.Remove(transaccion);
        //        response = await _dbContext.SaveChangesAsync();


        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Concat("Delete() Exception: ", ex.Message));
        //    }
        //    return response;
        //}

        public async Task<List<Transaccion>> GetAll()
        {
            List<Transaccion> transaccions = null;

            try
            {
                transaccions = await _dbContext.Transacciones.ToListAsync();
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("TransaccionRepository.GetAll(Transaccion transaccion) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("TransaccionRepository.GetAll(Transaccion transaccion) Exception: ", ex.Message));
            }


            return transaccions;
        }

        public async Task<Transaccion> GetById(int id)
        {
            Transaccion transaccion = new Transaccion();
            try
            {
                transaccion = await _dbContext.Transacciones.FirstOrDefaultAsync(transaccion => transaccion.Id == id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return transaccion;
        }


        //public async Task<int> Update(Transaccion transaccion)
        //{
        //    int response;
        //    try
        //    {
        //        var existingTransaccion = _dbContext.Transacciones.Local.SingleOrDefault(c => c.Id == transaccion.Id);
        //        if (existingTransaccion != null)
        //        {
        //            _dbContext.Entry(existingTransaccion).State = EntityState.Detached;

        //            transaccion.FechaCreacion = existingTransaccion.FechaCreacion;
        //            transaccion.FechaModificacion = DateTime.Now;
        //        }

        //        _dbContext.Update(transaccion);
        //        await _dbContext.SaveChangesAsync();
        //        response = transaccion.Id;
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw new Exception(string.Concat("TransaccionRepository.Update(Transaccion transaccion) Exception: ", ex.Message));
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(string.Concat("TransaccionRepository.Update(Transaccion transaccion) Exception: ", ex.Message));
        //    }

        //    return response;
        //}


        
    }
}
