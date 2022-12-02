using SIslas.ToDo.App.Domain.IDomains;
using SIslas.ToDo.App.Model;
using SIslas.ToDo.App.Repository.IRepositories;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Domain.Domains
{
    public class MetaDomain : IMetaDomain
    {
        private readonly IMetaRepository metaRepository;
        private readonly IGenericRepository<Meta> genericRepository;

        public MetaDomain(
            IMetaRepository metaRepository,
            IGenericRepository<Meta> genericRepository)
        {
            this.metaRepository = metaRepository;
            this.genericRepository = genericRepository;
        }

        public Response<bool> Add(Meta data)
        {
            var response = new Response<bool>();
            data.Nombre = data.Nombre.TrimStart().TrimEnd();
            try
            {
                var blnExiste = metaRepository.FindByNombre(data.Nombre);
                if (!blnExiste)
                {
                    data.FechaCreacion = DateTime.Now;
                    genericRepository.Add(data);
                    response.Success = true;
                }
                else
                {
                    response.Message = "Ya existe una meta con el mismo nombre";
                    response.Success = false;
                }

                    
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<Response<List<Meta>>> GetAll()
        {
            var response = new Response<List<Meta>>();
            try
            {
                response.Data = await metaRepository.GetAll();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public Response<bool> Remove(int IdMeta)
        {
            var response = new Response<bool>();
            try
            {
                var data = metaRepository.GetById(IdMeta);
                genericRepository.Remove(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public Response<bool> Update(Meta data)
        {
            var response = new Response<bool>();
            data.Nombre = data.Nombre.TrimStart().TrimEnd();
            try
            {
                var blnExiste = metaRepository.FindByNombre(data.Nombre);
                if (!blnExiste)
                {
                    genericRepository.Update(data);
                    response.Success = true;
                }
                else
                {
                    response.Message = "Ya existe una meta con el mismo nombre";
                    response.Success = false;
                }

                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
