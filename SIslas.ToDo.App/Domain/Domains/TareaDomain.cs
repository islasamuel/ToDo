using SIslas.ToDo.App.Domain.IDomains;
using SIslas.ToDo.App.Model;
using SIslas.ToDo.App.Repository.IRepositories;
using SIslas.ToDo.App.Repository.Repositories;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Domain.Domains
{
    public class TareaDomain : ITareaDomain
    {
        private readonly ITareaRepository tareaRepository;
        private readonly IMetaRepository metaRepository;
        private readonly IGenericRepository<Tarea> genericRepository;

        public TareaDomain(
            ITareaRepository tareaRepository,
            IGenericRepository<Tarea> genericRepository,
            IMetaRepository metaRepository)
        {
            this.tareaRepository = tareaRepository;
            this.genericRepository = genericRepository;
            this.metaRepository = metaRepository;
        }

        public async Task<Response<bool>> Add(Tarea data)
        {
            var response = new Response<bool>();
            data.Nombre = data.Nombre.TrimStart().TrimEnd();
            data.FechaCreacion = DateTime.Now;
            try
            {
                var blnExiste = tareaRepository.FindByNombre(data.Nombre, data.IdMeta);
                if (!blnExiste)
                {
                    genericRepository.Add(data);
                    await metaRepository.ChangeTarea(data.IdMeta);
                    response.Success = true;
                }
                else
                {
                    response.Message = "Ya existe una tarea con el mismo nombre";
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

        public async Task<Response<List<Tarea>>> GetAllByIdMeta(int IdMeta)
        {
            var response = new Response<List<Tarea>>();
            try
            {
                response.Data = await tareaRepository.GetAllByIdMeta(IdMeta);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<Response<bool>> Remove(int IdTarea)
        {
            var response = new Response<bool>();
            try
            {
                var data = tareaRepository.GetById(IdTarea);
                genericRepository.Remove(data);
                await metaRepository.ChangeTarea(data.IdMeta);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public Response<bool> Update(Tarea data)
        {
            var response = new Response<bool>();
            data.Nombre = data.Nombre.TrimStart().TrimEnd();
            try
            {
                var blnExiste = tareaRepository.FindByNombre(data.Nombre, data.IdMeta);
                if (!blnExiste)
                {
                    genericRepository.Update(data);
                    response.Success = true;
                }
                else
                {
                    response.Message = "Ya existe una tarea con el mismo nombre";
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

        public Response<bool> SetImportante(Tarea data)
        {
            var response = new Response<bool>();
            try
            {
                genericRepository.Update(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<Response<bool>> CompletarTarea(int IdTarea)
        {
            var response = new Response<bool>();
            try
            {
                var data = tareaRepository.GetById(IdTarea);
                data.IdEstatusTarea = 2;
                genericRepository.Update(data);
                await metaRepository.ChangePorcentaje(data.IdMeta);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public Response<Tarea> GetById(int IdTarea)
        {
            var response = new Response<Tarea>();
            try
            {
                response.Data = tareaRepository.GetById(IdTarea);
                response.Success = true;
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
