using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class TransmissionTypeService : BaseService , ITransmissionTypeService
    {
        public TransmissionTypeService(ICarRentalDbContext context): base(context)
        {

        }
        public Response Add(TransmissionType transmissionType)
        {
            var checkResponse = CheckToAddOrUpdate(transmissionType);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            Context.TransmissionType.Add(transmissionType);
            Context.SaveChanges();

            return Response.Success("Şanzıman türü başarıyla kaydedildi.");
        }

        private Response CheckToAddOrUpdate(TransmissionType transmissionType)
        {
            var sameNumberOfRecords = (from b in Context.TransmissionType
                                       where b.Name == transmissionType.Name && b.Id != transmissionType.Id
                                       select b
                                       ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{transmissionType.Name} Şanzıman türü sistemde zaten kayıtlıdır");
            }
            return Response.Success();
        }

        public Response Delete(int id)
        {
            var transmissionTypeToDelete = GetById(id);
            Context.TransmissionType.Remove(transmissionTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Şanzıman türü başarıyla silindi");
        }

        public List<TransmissionType> Get(TransmissionTypeFilter filter)
        {
            var items = (from v in Context.TransmissionType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public TransmissionType GetById(int id)
        {
            return Context.TransmissionType.Where(v => v.Id == id).SingleOrDefault();
        }

        public Response Update(TransmissionType transmissionType)
        {
            var checkResponse = CheckToAddOrUpdate(transmissionType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var colorTypeToUpdate = GetById(transmissionType.Id);
            colorTypeToUpdate.Name = transmissionType.Name;
            Context.SaveChanges();

            return Response.Success("Şanzıman türü başarıyla güncellendi");
        }
    }
}
