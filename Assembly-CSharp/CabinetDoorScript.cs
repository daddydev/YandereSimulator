using UnityEngine;

// Token: 0x02000055 RID: 85
public class CabinetDoorScript : MonoBehaviour {

  // Token: 0x06000135 RID: 309 RVA: 0x00013FE4 File Offset: 0x000123E4
  private void Update() {
    if (this.Locked) {
      this.Prompt.Circle[0].fillAmount = 1f;
    } else {
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Yandere.TheftTimer = 1f;
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Open = !this.Open;
        this.UpdateLabel();
      }
      base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, (!this.Open) ? 0f : 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
    }
  }

  // Token: 0x06000136 RID: 310 RVA: 0x000140E8 File Offset: 0x000124E8
  private void UpdateLabel() {
    if (this.Open) {
      this.Prompt.Label[0].text = "     Close";
    } else {
      this.Prompt.Label[0].text = "     Open";
    }
  }

  // Token: 0x040003CE RID: 974
  public PromptScript Prompt;

  // Token: 0x040003CF RID: 975
  public bool Locked;

  // Token: 0x040003D0 RID: 976
  public bool Open;
}