using UnityEngine;

// Token: 0x02000155 RID: 341
public class PhonePromptBarScript : MonoBehaviour {

  // Token: 0x0600063E RID: 1598 RVA: 0x00059CB4 File Offset: 0x000580B4
  private void Start() {
    base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
    this.Panel.enabled = false;
  }

  // Token: 0x0600063F RID: 1599 RVA: 0x00059D08 File Offset: 0x00058108
  private void Update() {
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show) {
      if (this.Panel.enabled) {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 631f, t), base.transform.localPosition.z);
        if (base.transform.localPosition.y < 630f) {
          base.transform.localPosition = new Vector3(base.transform.localPosition.x, 631f, base.transform.localPosition.z);
          this.Panel.enabled = false;
        }
      }
    } else {
      base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 530f, t), base.transform.localPosition.z);
    }
  }

  // Token: 0x04000F32 RID: 3890
  public UIPanel Panel;

  // Token: 0x04000F33 RID: 3891
  public bool Show;
}