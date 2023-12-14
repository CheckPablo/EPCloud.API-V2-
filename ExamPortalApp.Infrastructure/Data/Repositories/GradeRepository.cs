using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Data.Migrations;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;

        public GradeRepository(IRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _user = accessor.GetLoggedInUser();
        }

        public async Task<Grade> AddAsync(Grade entity)
        {
            if (_user == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
            entity.CenterId = _user.CenterId;
            var gradeExists = await _repository.AnyAsync<Grade>(x => x.Code == entity.Code && x.CenterId==entity.CenterId);
            if (gradeExists)
            {
                throw new Exception(ErrorMessages.GradeEntryChecks.GradeExists);
            }
            return await _repository.AddAsync(entity, true);
        }

        public async Task<int> DeleteAsync(int id)
        {
            
            await _repository.DeleteAsync<Grade>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            if (_user == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
            var grades = await _repository.GetWhereAsync<Grade>(x => x.CenterId == _user.CenterId);
            return grades.OrderBy(x => x.Code);
            //return grades.Distinct().OrderBy(x => x.Code);
        }


        public async Task<IEnumerable<Grade>> GetAllByCenterIdAsync(int? id)
        {
            if (_user == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
            var grades = await _repository.GetWhereAsync<Grade>(x => x.CenterId == id);
            return grades.OrderBy(x => x.Code);
            //return grades.Distinct().OrderBy(x => x.Code);
        }

        //public Task<IEnumerable<Grade>> GetAllByCenterIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Grade> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync<Grade>(id);

            if (entity == null) throw new EntityNotFoundException<Grade>(id);

            return entity;
        }

        public async Task UpdateGradeAsync(Grade entity)
        {
            if (entity == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
            //var grade = await _repository.GetWhereAsync<Grade>(x => x.Id == entity.Id);
        }

        public async Task<Grade> UpdateAsync(Grade entity)
        {
            var gradeToUpdate = await _repository.GetByIdAsync<Grade>(entity.Id);

            if (gradeToUpdate == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                gradeToUpdate.Code = entity.Code;
                gradeToUpdate.Description = entity.Description;

                return await _repository.UpdateAsync(gradeToUpdate, true);
            }
        }

    
        //public Task<GradeDto> GetAllByCenterIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
