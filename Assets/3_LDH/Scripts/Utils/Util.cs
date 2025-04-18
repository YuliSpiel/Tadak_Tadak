using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
        /// <param name="path">Resources를 기준으로 한 상대 경로</param>
        /// <param name="position">새로운 오브젝트의 위치</param>
        /// <param name="parent">새로운 오브젝트의 부모 Transform</param>
        /// <returns></returns>
        public static GameObject Instatiate(string path,  Vector3 position, Transform parent=null )
        {
            GameObject prefab = Load<GameObject>(path);
            if (prefab == null)
            {
                Debug.Log($"Fail to load prefab : {path}");
                return null;
            }

            return Object.Instantiate(prefab, position, Quaternion.identity, parent);
        
        }

        
        /// <summary>
        /// UI Image Fade Effect Coroutine
        /// </summary>
        public static IEnumerator Fade(Image target, float  start, float end, float fadeTime = 1, float delay = 0, UnityAction action = null)
        {
            yield return new WaitForSeconds(delay);

            if (target == null) yield break;
            
            //시작 알파 값으로 설정
            Color color = target.color;
            color.a = start;
            target.color = color;
            
            float percent = 0;
            while (percent < 1)
            {
                percent += Time.deltaTime / fadeTime;
                color = target.color;
                color.a = Mathf.Lerp(start, end, percent);
                target.color = color;

                yield return null;
            }

            color.a = end;
            target.color = color;
            
            action?.Invoke();
            ;
        }
        
        
        
    }
}