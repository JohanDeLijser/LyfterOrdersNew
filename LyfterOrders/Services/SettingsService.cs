using System;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using LyfterOrders.Models;

namespace LyfterOrders.Services
{
    public static class SettingsService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SettingsData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Setting>();
        }

        public static async Task SaveSetting(string key, string value)
        {
            await Init();

            var setting = new Setting
            {
                Key = key,
                Value = value
            };

            var existingSetting = await SettingsService.GetSetting(key);

            if (existingSetting != null)
            {
                existingSetting.Value = value;

                setting = existingSetting;
            }

            await db.InsertOrReplaceAsync(setting);
        }

        public static async Task<Setting> GetSetting(string key)
        {
            await Init();

            try {
                return await db.Table<Setting>().Where(s => s.Key == key).FirstAsync();
            } catch
            {
                return null;
            }
        }
    }
}
