using UnityEngine;

// Token: 0x02000167 RID: 359
public class PromptBarScript : MonoBehaviour {

  // Token: 0x060006A5 RID: 1701 RVA: 0x00064AC0 File Offset: 0x00062EC0
  private void Awake() {
    base.transform.localPosition = new Vector3(base.transform.localPosition.x, -627f, base.transform.localPosition.z);
    this.ID = 0;
    while (this.ID < this.Label.Length) {
      this.Label[this.ID].text = string.Empty;
      this.ID++;
    }
  }

  // Token: 0x060006A6 RID: 1702 RVA: 0x00064B4C File Offset: 0x00062F4C
  private void Start() {
    this.UpdateButtons();
  }

  // Token: 0x060006A7 RID: 1703 RVA: 0x00064B54 File Offset: 0x00062F54
  private void Update() {
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show) {
      if (this.Panel.enabled) {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -628f, t), base.transform.localPosition.z);
        if (base.transform.localPosition.y < -627f) {
          base.transform.localPosition = new Vector3(base.transform.localPosition.x, -628f, base.transform.localPosition.z);
          if (this.Panel != null) {
            this.Panel.enabled = false;
          }
        }
      }
    } else {
      base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -528.5f, t), base.transform.localPosition.z);
    }
  }

  // Token: 0x060006A8 RID: 1704 RVA: 0x00064CB0 File Offset: 0x000630B0
  public void UpdateButtons() {
    if (this.Panel != null) {
      this.Panel.enabled = true;
    }
    this.ID = 0;
    while (this.ID < this.Label.Length) {
      this.Button[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
      this.ID++;
    }
  }

  // Token: 0x060006A9 RID: 1705 RVA: 0x00064D34 File Offset: 0x00063134
  public void ClearButtons() {
    this.ID = 0;
    while (this.ID < this.Label.Length) {
      this.Label[this.ID].text = string.Empty;
      this.Button[this.ID].enabled = false;
      this.ID++;
    }
  }

  // Token: 0x0400108F RID: 4239
  public UISprite[] Button;

  // Token: 0x04001090 RID: 4240
  public UILabel[] Label;

  // Token: 0x04001091 RID: 4241
  public UIPanel Panel;

  // Token: 0x04001092 RID: 4242
  public bool Show;

  // Token: 0x04001093 RID: 4243
  public int ID;
}