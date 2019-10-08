using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoSingleton<GameObjectPool>
{
    Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>>();

    private GameObjectPool() { }


    public GameObject CreateObject(string key,GameObject go,Vector3 position,Quaternion quaternion) {

        //GameObject gotemp = 
        GameObject gotemp = FindUsable(key);
        if (gotemp != null)
        {
            gotemp.transform.position = position;
            gotemp.transform.rotation = quaternion;
            gotemp.SetActive(true);
        }
        else {
            gotemp = Instantiate(go, position, quaternion);
            Add(key, gotemp);
        }
        gotemp.transform.parent = transform;



        return gotemp;
    }

    private GameObject FindUsable(string key) {

        if (cache.ContainsKey(key)) {
            return cache[key].Find(delegate(GameObject obj) {
                //寻找物体中未激活的
                return !obj.activeSelf;
	        });
        }
        return null;
    }

    private void Add(string key,GameObject temp) {
        if (!cache.ContainsKey(key)) {
            cache.Add(key, new List<GameObject>());
        }
        cache[key].Add(temp);
    }

    private void Clear(string key) {
        if (cache.ContainsKey(key)) {

            for (int i = 0; i < cache[key].Count; i++) {
                GameObject obj = cache[key][i];
                Destroy(obj);
            }
            cache.Remove(key);
        }

    }

    private void ClearAll() {

        foreach (string key in cache.Keys) {
            Clear(key);
        }
    }

    public void CollectObject(GameObject go) {

        go.SetActive(false);
    }

    public void CollectObject(GameObject go, float delay) {
        StartCoroutine(CollectDelay(go,delay));

    }

    private IEnumerator CollectDelay(GameObject go, float delay) {
        yield return new WaitForSeconds(delay);
        CollectObject(go);

    }

    
}
