using UnityEngine;

// Token: 0x0200018B RID: 395
public class SafeScript : MonoBehaviour {

  // Token: 0x06000714 RID: 1812 RVA: 0x0006C543 File Offset: 0x0006A943
  private void Start() {
    this.ContentsPrompt.MyCollider.enabled = false;
    this.SafePrompt.enabled = false;
  }

  // Token: 0x06000715 RID: 1813 RVA: 0x0006C564 File Offset: 0x0006A964
  private void Update() {
    if (this.Key.activeInHierarchy && this.KeyPrompt.Circle[0].fillAmount == 0f) {
      this.KeyPrompt.Yandere.Inventory.SafeKey = true;
      this.SafePrompt.enabled = true;
      this.Key.SetActive(false);
    }
    if (this.SafePrompt.Circle[0].fillAmount == 0f) {
      this.KeyPrompt.Yandere.Inventory.SafeKey = false;
      this.ContentsPrompt.MyCollider.enabled = true;
      this.Open = true;
      this.SafePrompt.Hide();
      this.SafePrompt.enabled = false;
    }
    if (this.ContentsPrompt.Circle[0].fillAmount == 0f) {
      this.MissionMode.DocumentsStolen = true;
      base.enabled = false;
      this.ContentsPrompt.Hide();
      this.ContentsPrompt.enabled = false;
      this.ContentsPrompt.gameObject.SetActive(false);
    }
    if (this.Open) {
      this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
      this.Door.localEulerAngles = new Vector3(this.Door.localEulerAngles.x, this.Rotation, this.Door.localEulerAngles.z);
      if (this.Rotation < 1f) {
        this.Open = false;
      }
    }
  }

  // Token: 0x040011F5 RID: 4597
  public MissionModeScript MissionMode;

  // Token: 0x040011F6 RID: 4598
  public PromptScript ContentsPrompt;

  // Token: 0x040011F7 RID: 4599
  public PromptScript SafePrompt;

  // Token: 0x040011F8 RID: 4600
  public PromptScript KeyPrompt;

  // Token: 0x040011F9 RID: 4601
  public Transform Door;

  // Token: 0x040011FA RID: 4602
  public GameObject Key;

  // Token: 0x040011FB RID: 4603
  public float Rotation;

  // Token: 0x040011FC RID: 4604
  public bool Open;
}