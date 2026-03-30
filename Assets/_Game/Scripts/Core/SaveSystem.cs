using System.IO;
using UnityEngine;
using HappyLittleGravekeeper.Progression;

namespace HappyLittleGravekeeper.Core
{
    public static class SaveSystem
    {
        private const string SaveFileName = "progression.json";

        private static string SavePath => Path.Combine(Application.persistentDataPath, SaveFileName);

        public static void Save(PlayerProgression data)
        {
            // TODO: Handle IOException gracefully
            string json = JsonUtility.ToJson(data, prettyPrint: true);
            File.WriteAllText(SavePath, json);
        }

        public static PlayerProgression Load()
        {
            if (!File.Exists(SavePath))
                return null;

            // TODO: Handle malformed JSON gracefully
            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<PlayerProgression>(json);
        }
    }
}
