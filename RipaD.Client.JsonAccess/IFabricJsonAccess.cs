using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RipaD.Client.JsonAccess
{
    public interface IFabricJsonAccess
    {

        Task<T> GetEntity <T> (T Entity, List<string> propertiesToFilterOn);
        //Task<List<object>> GetEntities(object Entity, List<string> propertiesToFilterOn);
        //Task<object> CreateEntity(object Entity);

        Task<T> CreateEntity <T>(T Entity);

        Task<object> DeleteEntity(object Entity);
        Task<object> UpdateEntity(object Entity);

        Task<T> GetEntityById<T>(T Entity);
    }

}
