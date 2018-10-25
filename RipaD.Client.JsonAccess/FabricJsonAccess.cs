using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;
using RipaD.Core;
using System.Net.Http;

namespace RipaD.Client.JsonAccess
{
    public class FabricJsonAccess : IFabricJsonAccess
    {
        //public IBarDatabaseTenant Tenant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private DataService _dataService = new DataService();
        //private string _webApiUri = "http://localhost:51925/api/";
        //private string _webApiUri = "http://DESKTOP-OLP9HIG:51925/api/"; // IIS Express connection Local

        private string _webApiUri; // = "http://localhost:51926/api/"; //Kestrel Connection Local
        

        //private string _webApiUri = "http://alchemint.azurewebsites.net/api/";

        private string _apiKey = "";

        public FabricJsonAccess(HttpClient httpClient, string apiUrl, string apiKey)
        {
            _dataService = new DataService(httpClient);
            _apiKey = apiKey;
            _webApiUri = apiUrl;

        }

        public FabricJsonAccess(string apiUrl, string apiKey)
        {
            _dataService = new DataService();
            _apiKey = apiKey;
            _webApiUri = apiUrl;
        }

        private bool IsValidJson(dynamic json)
        {
            return (json != null); 
            // && (json != ""));
        }

        private string EntityFabricUri() => _webApiUri; // + "Fabric";

        public List<string> BuildFilterList(string propertyNames)
        {
            List<string> propertiesToFilterOn = new List<string>();
            string [] arrPropertyNames = propertyNames.Split(',');
            foreach (var prop in arrPropertyNames)
            {
                propertiesToFilterOn.Add(prop);
            }
            return propertiesToFilterOn;
        }
        public async Task<T> GetEntity<T> (T Entity, List<string> propertiesToFilterOn)
        {

            string entityTypeName = Entity.GetType().Name;

            object json = await _dataService.GetAsync <T> (
                EntityFabricUri(),
                _apiKey,
                Entity,
                propertiesToFilterOn
                );

            return (T) json;
        }


        //public async Task<List<T>> GetEntities <T> (object Entity, List<string> propertiesToFilterOn)
        //{

        //    string entityTypeName = Entity.GetType().Name;
        //    List<object> ret = new List<object>();
        //    object arr = await _dataService.GetAsync List<T>(
        //        EntityFabricUri(),
        //        _apiKey,
        //        Entity,
        //        propertiesToFilterOn,
        //        true
        //        );

        //    foreach(var jo in arr)
        //    {
        //        object o =  JsonConvert.DeserializeObject<object>(jo.ToString());

                
        //        //object entityTyped = (new EntityFactory"") .GetEmptyTypedObect(entityTypeName);
        //        //entityTyped = EntityHelper.CopyPropertiesFromDynamicObjectToTypedObject(jo, entityTyped);

        //        //ret.Add(entityTyped);
        //    }
        //    return ret;

        //}

        public async Task<T> CreateEntity <T> (T Entity)
        {
            string EntityType = Entity.GetType().Name;

            object json = await _dataService.PostAsync <T>(
                EntityFabricUri(),
                _apiKey,
                Entity
                );

            if (json != null)
            {
                //object entityTyped = EntityFactory.GetEmptyTypedObect(EntityType);
                //EntityFactory.CopyPropertiesFromDynamicObjectToTypedObject(json, entityTyped);
                //return entityTyped;

                json= (T) json;
            }
            return (T) json;
        }

        public async Task<object> DeleteEntity(object Entity)
        {

            string EntityType = Entity.GetType().Name;

            JObject json = await _dataService.DeleteAsync (
                EntityFabricUri(),
                _apiKey,
                Entity
                );

            if (json != null)
            {
                //object entityTyped = EntityFactory.GetEmptyTypedObect(EntityType);
                //EntityFactory.CopyPropertiesFromDynamicObjectToTypedObject(json, entityTyped);
                //return entityTyped;
                return json;
            }
            else
            {
                return null;
            }
        }

        public async Task<object> UpdateEntity(object Entity)
        {
            string EntityType = Entity.GetType().Name;

            JObject json = await _dataService.PutAsync(
                EntityFabricUri(),
                _apiKey,
                Entity
                );

            if (json != null)
            {
                //object entityTyped = EntityFactory.GetEmptyTypedObect(EntityType);
                //EntityFactory.CopyPropertiesFromDynamicObjectToTypedObject(json, entityTyped);
                //return entityTyped;
                return json;
            }
            else
            {
                return null;
            }
        }

        public async Task<T> GetEntityById<T>(T Entity)
        {
            return await GetEntity<T>(Entity, new List<string> { "Id" });
        }


        //private object GetEmptyTypedObect(string EntityType)
        //{
        //    object reflectedEntityObject = CreateInstance<object>(EntityType);
        //    return reflectedEntityObject;
        //}


        //private object CopyPropertiesFromDynamicObjectToTypedObject(dynamic DynamicObject, object TypedObject)
        //{
        //    var properties = TypedObject.GetType().GetProperties();
        //    foreach (var p in properties)
        //    {
        //        string pName = p.Name;
        //        object pValue = DynamicObject[pName].Value;
        //        p.SetValue(TypedObject, pValue);
        //    }
        //    return TypedObject;
        //}


        //private string GetApplicationRoot()
        //{
        //    var exePath = Path.GetDirectoryName(System.Reflection
        //                      .Assembly.GetExecutingAssembly().CodeBase);
        //    Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*"); //(?=\\+bin)
        //    var appRoot = appPathMatcher.Match(exePath).Value;
        //    return appRoot;
        //}
        //private I CreateInstance<I>(string EntityType) where I : class
        //{
        //    //string assemblyPath = Environment.CurrentDirectory + "\\BarClasses.dll";
        //    string assemblyPath = GetApplicationRoot() + "\\BarClasses.dll";

        //    assemblyPath  = this.GetType().Assembly.Location.Replace(this.GetType().Assembly.GetName().Name + ".dll", "") + "BarClasses.dll";

        //    Assembly assembly;
        //    assembly = Assembly.LoadFrom(assemblyPath);
        //    Type type = assembly.GetType($"Alchemint.Bar.{EntityType}");
        //    return Activator.CreateInstance(type) as I;
        //}

    }
}
