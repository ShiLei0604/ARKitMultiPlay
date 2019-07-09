using UniRx;
using UnityEngine;
using UnityEngine.XR.iOS;

public class AnchorObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    GameObject placedObj;

    void Start()
    {
        UnityARSessionNativeInterface.ARUserAnchorAddedAsObservable()
            .Subscribe(Spawn)
            .AddTo(this);
    }

    void Spawn(ARUserAnchor userAnchor)
    {
        var position = UnityARMatrixOps.GetPosition(userAnchor.transform);
        var rotation = UnityARMatrixOps.GetRotation(userAnchor.transform);

        if(placedObj){
            placedObj.transform.position = position;
            Debug.Log("オブジェクト移動");

        }else{
            Debug.Log("初回配置");
            placedObj = Instantiate(prefab, position, rotation);
            
        }
       
    }
}
