using UnityEngine;

public class TextureController : MonoBehaviour {

    // Variables

    private bool hasParent;
    private GameObject parent;
    
    void Start() {
        if (CheckHasParent()) {
            GetParent();
            SetTexture();
        }

        removeObject(hasParent);
    }

    void Update() {
        CheckHasParent();
        removeObject(hasParent);
    }

    private bool CheckHasParent() {
        if (transform.parent != null) {
            hasParent = true;
            return true;
        } else {
            hasParent = false;
            return false;
        }
    }

    private void GetParent() {
        parent = transform.parent.gameObject;
    }

    private void SetTexture() {
        //var parentController = parent.GetComponent<EnemyCtrl>();
        //if (parentController.type == EnemyCtrl.ENEMY_TYPE.SCRATCHER) {

        //    }
    }

    private void removeObject(bool hasParent) {
        if (!hasParent)
            GameObject.Destroy(gameObject);
    }
}
