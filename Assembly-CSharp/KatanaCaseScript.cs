using UnityEngine;

// Token: 0x0200011D RID: 285
public class KatanaCaseScript : MonoBehaviour {

  // Token: 0x06000586 RID: 1414 RVA: 0x0004C115 File Offset: 0x0004A515
  private void Start() {
    this.CasePrompt.enabled = false;
  }

  // Token: 0x06000587 RID: 1415 RVA: 0x0004C124 File Offset: 0x0004A524
  private void Update() {
    if (this.Key.activeInHierarchy && this.KeyPrompt.Circle[0].fillAmount == 0f) {
      this.KeyPrompt.Yandere.Inventory.CaseKey = true;
      this.CasePrompt.enabled = true;
      this.Key.SetActive(false);
    }
    if (this.CasePrompt.Circle[0].fillAmount == 0f) {
      this.KeyPrompt.Yandere.Inventory.CaseKey = false;
      this.Open = true;
      this.CasePrompt.Hide();
      this.CasePrompt.enabled = false;
    }
    if (this.Open) {
      this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
      this.Door.eulerAngles = new Vector3(this.Door.eulerAngles.x, this.Door.eulerAngles.y, this.Rotation);
      if (this.Rotation < -179.9f) {
        base.enabled = false;
      }
    }
  }

  // Token: 0x04000D27 RID: 3367
  public PromptScript CasePrompt;

  // Token: 0x04000D28 RID: 3368
  public PromptScript KeyPrompt;

  // Token: 0x04000D29 RID: 3369
  public Transform Door;

  // Token: 0x04000D2A RID: 3370
  public GameObject Key;

  // Token: 0x04000D2B RID: 3371
  public float Rotation;

  // Token: 0x04000D2C RID: 3372
  public bool Open;
}