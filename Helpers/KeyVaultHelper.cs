using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Configuration;
using System.Reflection;

namespace WebAPI.Helpers
{
    public static class KeyVaultHelper
    {
        public static void LoadSecrets()
        {
            var keyVaultUri = ConfigurationManager.AppSettings["KeyVaultUri"];
            if (string.IsNullOrWhiteSpace(keyVaultUri))
                throw new InvalidOperationException("KeyVaultUri is not configured in AppSettings.");

            var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

            var connectionString = client.GetSecret("EmployeeAppDB-ConnectionString").Value.Value;

            SetConnectionString("EmployeeDB", connectionString);
            SetConnectionString("EmployeeAppDB", connectionString);
        }

        private static void SetConnectionString(string name, string value)
        {
            var setting = ConfigurationManager.ConnectionStrings[name];
            if (setting == null) return;

            // ConfigurationManager connection strings are read-only at runtime;
            // reflection is required to override them before any code reads them.
            var readOnlyField = typeof(ConfigurationElement)
                .GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            readOnlyField?.SetValue(setting, false);
            setting.ConnectionString = value;
        }
    }
}
