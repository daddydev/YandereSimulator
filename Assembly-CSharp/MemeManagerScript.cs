using UnityEngine;

// Token: 0x0200012F RID: 303
public class MemeManagerScript : MonoBehaviour {

  // Token: 0x060005BC RID: 1468 RVA: 0x0004F568 File Offset: 0x0004D968
  private void Start() {
    if (GameGlobals.LoveSick) {
      foreach (GameObject gameObject in this.Memes) {
        gameObject.SetActive(false);
      }
    }
  }

  // Token: 0x04000DBB RID: 3515
  [SerializeField]
  private GameObject[] Memes;
}