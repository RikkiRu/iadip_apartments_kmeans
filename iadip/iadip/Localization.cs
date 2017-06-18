using System;
using System.Collections.Generic;
using System.IO;

namespace iadip
{
    public class Localization
    {
        private static Localization instance;
        public static Localization Instance { get { return instance; } }

        private Dictionary<string, string> keys;

        private Localization()
        {
            keys = new Dictionary<string, string>();

            if (!File.Exists("Localization.txt"))
                throw new Exception("Не найден Localization.txt");

            string[] content = File.ReadAllLines("Localization.txt");
            foreach (var l in content)
            {
                if (string.IsNullOrEmpty(l))
                    continue;

                string[] s = l.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length != 2)
                    throw new Exception("Ошибка в локализации. Строка: " + l);

                if (keys.ContainsKey(s[0]))
                    throw new Exception("Повтор ключа локализации: " + s[0]);

                keys.Add(s[0], s[1]);
            }
        }

        public static void Init()
        {
            if (instance != null)
                throw new Exception("Localization already inited");

            instance = new Localization();
        }

        public List<int> GetLoadedParams()
        {
            List<int> loaded = new List<int>();

            foreach (var i in keys)
            {
                if (i.Key.StartsWith("paramname."))
                {
                    string[] n = i.Key.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    loaded.Add(int.Parse(n[1]));
                }
            }

            return loaded;
        }

        public string ClusterDataParamName(int index)
        {
            return Get("paramname." + index);
        }

        public string Get(string key)
        {
            if (!keys.ContainsKey(key))
                throw new Exception("Localization key not found: " + key);

            return keys[key];
        }
    }
}
