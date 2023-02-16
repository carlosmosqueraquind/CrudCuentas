using CrudCuentas.DAL.DTOs;
using CrudCuentas.DAL.Models;
using CrudCuentas.Repositories.DataContext;
using CrudCuentas.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ClienteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Cliente cliente)
        {
            int idClienteCreated;
            try
            {
                _dbContext.Add(cliente);
                 await _dbContext.SaveChangesAsync();
                idClienteCreated = cliente.Id;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("ClienteRepository.Create(Cliente cliente) Exception: ", ex.Message));
                
            }

            return idClienteCreated;
        }


        public async Task<int> Delete(int id)
        {
            int response;
            try
            {

                Cliente cliente = await _dbContext.Clientes.FirstAsync(c => c.Id == id);
                

                _dbContext.Remove(cliente);
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

        public async Task<List<Cliente>> GetAll()
        {
            List<Cliente> clientes = null;

            try
            {
                clientes = await _dbContext.Clientes.ToListAsync();
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("ClienteRepository.GetAll(Cliente cliente) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("ClienteRepository.GetAll(Cliente cliente) Exception: ", ex.Message));
            }


            return clientes;
        }

        public async Task<Cliente> GetById(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                cliente = await _dbContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("GetById() Exception: ", ex.Message));
            }

            return cliente;
        }


        public async Task<int> Update(Cliente cliente)
        {
            int response;
            try
            {
                var existingCliente = _dbContext.Clientes.Local.SingleOrDefault(c => c.Id == cliente.Id);
                if (existingCliente != null)
                {
                    _dbContext.Entry(existingCliente).State = EntityState.Detached;

                    cliente.FechaCreacion = existingCliente.FechaCreacion;
                    cliente.FechaModificacion = DateTime.Now;
                }

                _dbContext.Update(cliente);
                await _dbContext.SaveChangesAsync();
                response = cliente.Id;
            }
            catch (SqlException ex)
            {

                throw new Exception(string.Concat("ClienteRepository.Update(Cliente cliente) Exception: ", ex.Message));
            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("ClienteRepository.Update(Cliente cliente) Exception: ", ex.Message));
            }

            return response;
        }


        //public async Task<List<Cliente>> GetClientesDetalle()
        //{
        //    var connectionString = _dbContext.Database.GetConnectionString();

        //    List<Cliente> clientesDetalle = new();


        //    using (SqlConnection _SqlConnection = new(connectionString))
        //    {
        //        try
        //        {
        //            try
        //            {
        //                await _SqlConnection.OpenAsync();

        //                SqlCommand _SqlCommand = new("dbo.SPGetDetalleClientes", _SqlConnection)
        //                {
        //                    CommandType = CommandType.StoredProcedure
        //                };

        //                //_SqlCommand.Parameters.AddWithValue("@id", id);

        //                using (SqlDataReader _SqlDataReader = await _SqlCommand.ExecuteReaderAsync())
        //                {
        //                    while (await _SqlDataReader.ReadAsync())
        //                    {
        //                        clientesDetalle.Add(new Cliente()
        //                        {
        //                            //Id = _SqlDataReader.GetInt32(0),
        //                            Id = _SqlDataReader.GetInt32(0),
        //                            NumeroIdentificacion = _SqlDataReader.GetInt32(1),
        //                            Nombre = _SqlDataReader.GetString(2),
        //                            Apellido = _SqlDataReader.GetString(3),
        //                            Correo = _SqlDataReader.GetString(4),
        //                            FechaNacimiento = _SqlDataReader.GetDecimal(5),
        //                            FechaCreacion = _SqlDataReader.GetString(6),
        //                            FechaModificacion = _SqlDataReader.GetString(7),

        //                            TipoDocumentoId = _SqlDataReader.GetInt32(9),
        //                        });

        //                        //objStudent.UserNotifications = JsonConvert.DeserializeObject<UserNotifications>(_SqlDataReader.GetString(10).Replace("idStudent", "StudentID").Replace("[", "").Replace("]", ""));
        //                        //objStudent.ProfileInterests = JsonConvert.DeserializeObject<ProfileInterests>(_SqlDataReader.GetString(9).Replace("idStudent", "StudentID").Replace("[", "").Replace("]", ""));
        //                    }
        //                }
        //            }
        //            catch (Exception exception)
        //            {
        //                throw new Exception(string.Concat("GetClientesDetalle() Exception: ", exception.Message));
        //            }
        //        }
        //        finally
        //        {
        //            await _SqlConnection.CloseAsync();
        //            await _SqlConnection.DisposeAsync();
        //        }
        //        return clientesDetalle;
        //    }

        //}



    }
}
