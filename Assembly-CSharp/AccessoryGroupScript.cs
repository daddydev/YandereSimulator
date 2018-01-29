using UnityEngine;

// Token: 0x0200002A RID: 42
public class AccessoryGroupScript : MonoBehaviour {

  // Token: 0x060000A0 RID: 160 RVA: 0x0000B834 File Offset: 0x00009C34
  public void SetPartsActive(bool active) {
    foreach (GameObject gameObject in this.Parts) {
      gameObject.SetActive(active);
    }
  }

  // Token: 0x0400016F RID: 367
  public GameObject[] Parts;
}