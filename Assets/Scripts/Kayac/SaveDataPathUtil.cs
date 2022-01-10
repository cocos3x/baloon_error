using UnityEngine;

namespace Kayac
{
    public static class SaveDataPathUtil
    {
        // Methods
        public static string MakeFullPath(string relativePath)
        {
            return System.IO.Path.Combine(path1:  UnityEngine.Application.persistentDataPath, path2:  relativePath);
        }
        public static string GetFolderPath()
        {
            return UnityEngine.Application.persistentDataPath;
        }
    
    }

}
