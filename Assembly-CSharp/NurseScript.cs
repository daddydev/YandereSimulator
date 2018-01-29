using UnityEngine;

// Token: 0x02000143 RID: 323
public class NurseScript : MonoBehaviour {

  // Token: 0x06000605 RID: 1541 RVA: 0x00055078 File Offset: 0x00053478
  private void Awake() {
    Animation component = this.Character.GetComponent<Animation>();
    component["f02_noBlink_00"].layer = 1;
    component.Blend("f02_noBlink_00");
  }

  // Token: 0x06000606 RID: 1542 RVA: 0x000550B0 File Offset: 0x000534B0
  private void LateUpdate() {
    this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
  }

  // Token: 0x04000E78 RID: 3704
  public GameObject Character;

  // Token: 0x04000E79 RID: 3705
  public Transform SkirtCenter;
}