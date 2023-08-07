using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Analytics;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;

namespace VFSCloud
{
    public class Connection
    {
        private static Connection _instance = null;
        private Dictionary<string, string> _environmentList;

        // keep track of current environment
#if UNITY_EDITOR
        private static string _currentEnv = "development";
#else
    private static string _currentEnv = "production";
#endif

        private IAuthenticationService Auth => AuthenticationService.Instance;
        
        public static Connection Service
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Connection();
                }
                
                return _instance;
            }
        }

        public string RemoteID => _environmentList[_currentEnv];

        private Connection()
        {
            // TODO:
            _environmentList = new Dictionary<string, string>
            {
                { "demo", "83bf9896-c4d2-4526-80b2-4bdd949b171b" },
                { "development", "23f5879a-5dab-4eae-aed3-21267a2ee040" },
                { "production", "9c909e7c-8019-46a7-9ebe-153f36fe8cc0" }
            };
        }

        public async Task Authenticate(string theEnv = "development")
        {
            // go connect to the environment specified
            var options = new InitializationOptions().SetOption
            ("com.unity.services.core.environment-name",
                theEnv);

            _currentEnv = theEnv;
            
            // Let the developer know they are connected

            // initialize the login function
            await UnityServices.InitializeAsync(options); 

            // if it's not signed in, please sign in
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await Auth.SignInAnonymouslyAsync();
            }

            Debug.Log($"Player ID {Auth.PlayerId}");

            List<string> consentIdentifiers =
                await AnalyticsService.Instance.CheckForRequiredConsents();
            
            AnalyticsService.Instance.StartDataCollection();
        }
    }
}