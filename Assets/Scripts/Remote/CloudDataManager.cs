using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using UnityEditor.MemoryProfiler;

namespace VFSCloud
{
    public class CloudDataManager : MonoBehaviour
    {
        [HideInInspector]
        public CloudDataManager Instance;

        private RemoteConfigService Remote => RemoteConfigService.Instance;

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
        
        // Start is called before the first frame update
        public async Task Start()
        {
            await Connection.Service.Authenticate();

            FetchConfigData();
        }

        private void FetchConfigData()
        {
            Remote.SetEnvironmentID(Connection.Service.RemoteID);

            Remote.FetchConfigs(new userAttributes(), new appAttributes());

            // Check that scene has not been unloaded.
            if (this == null)
            {
                return;
            }
            
            ApplyRemoteConfigs(Remote.appConfig);
        }

        /*private void FetchConfig<T>(RuntimeConfig theAppConfig, string remoteKey)
        {
            var theJSON = theAppConfig.GetJson(remoteKey);
            T theData = JsonUtility.FromJson<T>(theJSON);

            List < T > list = FindRemoteObjects< T >();
            
            foreach (T item in list)
            {
                item.LoadConfigs(theData);
            }
        }*/

        private void ApplyRemoteConfigs(RuntimeConfig theAppConfig)
        {
            var thePlayerDataJSON = theAppConfig.GetJson("Player");
            PlayerData thePlayerData = JsonUtility.FromJson<PlayerData>(thePlayerDataJSON);

            List < IRemotePlayer > list = FindRemoteObjects< IRemotePlayer >();
            
            foreach (IRemotePlayer item in list)
            {
                item.LoadConfigs(thePlayerData);
            }
            
            var thePlatformDataJSON = theAppConfig.GetJson("Platforms");
            PlatformData thePlatformData = JsonUtility.FromJson<PlatformData>(thePlatformDataJSON);

            List < IRemotePlatforms> platformList = FindRemoteObjects< IRemotePlatforms >();
            
            foreach (IRemotePlatforms item in platformList)
            {
                item.LoadConfigs(thePlatformData);
            }
        }

        private List<T> FindRemoteObjects<T>()
        {
            IEnumerable<T> list;
            
            list = FindObjectsOfType<MonoBehaviour>().OfType<T>();

            return new List<T>(list);
        }

        public struct userAttributes{}
        
        public struct appAttributes{}
    }
}
