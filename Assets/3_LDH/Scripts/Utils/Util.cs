using System.IO;
using UnityEngine;

namespace Utils
{
    public class Util
    {
        //Resoucre 폴더 아래의 리소스를 로드하는 메소드
        public static T Load<T>(string path) where T : Object
        {
            //확장자를 포함한 경로일 경우 확장자를 제거해준다.
            path = Path.Combine(Path.GetDirectoryName(path) ?? string.Empty, Path.GetFileNameWithoutExtension(path));

            T resource = Resources.Load<T>(path);
            if (resource == null)
            {
                Debug.Log($"Failed to load resource : {path}");
            }

            return resource;

        }


        /// <summary>
        /// Resource/Prefab 경로 아래의 프리랩을 load하여 인스턴스 생성한다.
        /// </summary>
        /// <param name="path">Resources/Prefab를 기준으로 한 상대 경로</param>
        /// <param name="position">새로운 오브젝트의 위치</param>
        /// <param name="parent">새로운 오브젝트의 부모 Transform</param>
        /// <returns></returns>
        public static GameObject Instatiate(string path,  Vector3 position, Transform parent=null )
        {
            GameObject prefab = Load<GameObject>($"Prefabs/{path}");
            if (prefab == null)
            {
                Debug.Log($"Fail to load prefab : {path}");
                return null;
            }

            return Object.Instantiate(prefab, position, Quaternion.identity, parent);
        }
    }
}