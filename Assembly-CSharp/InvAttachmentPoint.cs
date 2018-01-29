using UnityEngine;

// Token: 0x0200000C RID: 12
[AddComponentMenu("NGUI/Examples/Item Attachment Point")]
public class InvAttachmentPoint : MonoBehaviour {

  // Token: 0x06000040 RID: 64 RVA: 0x000096F8 File Offset: 0x00007AF8
  public GameObject Attach(GameObject prefab) {
    if (this.mPrefab != prefab) {
      this.mPrefab = prefab;
      if (this.mChild != null) {
        UnityEngine.Object.Destroy(this.mChild);
      }
      if (this.mPrefab != null) {
        Transform transform = base.transform;
        this.mChild = UnityEngine.Object.Instantiate<GameObject>(this.mPrefab, transform.position, transform.rotation);
        Transform transform2 = this.mChild.transform;
        transform2.parent = transform;
        transform2.localPosition = Vector3.zero;
        transform2.localRotation = Quaternion.identity;
        transform2.localScale = Vector3.one;
      }
    }
    return this.mChild;
  }

  // Token: 0x040000E6 RID: 230
  public InvBaseItem.Slot slot;

  // Token: 0x040000E7 RID: 231
  private GameObject mPrefab;

  // Token: 0x040000E8 RID: 232
  private GameObject mChild;
}