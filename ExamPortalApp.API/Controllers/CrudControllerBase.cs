using AutoMapper;
using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    public abstract class CrudControllerBase<T, T1> : ControllerBase where T : class
    {
        protected readonly IMapper _mapper;

        protected CrudControllerBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract Task<ActionResult<T>> Delete(int id);
        public abstract Task<ActionResult<IEnumerable<T>>> Get();
        public abstract Task<ActionResult<T>> Get(int id);
        public abstract Task<ActionResult<T>> Post(T1 entity);
        public abstract Task<ActionResult<T>> Put(int id, T1 entity);
    }
}