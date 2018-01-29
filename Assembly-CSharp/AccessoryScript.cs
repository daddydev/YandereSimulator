using UnityEngine;

// Token: 0x0200002B RID: 43
public class AccessoryScript : MonoBehaviour {

  // Token: 0x060000A2 RID: 162 RVA: 0x0000B870 File Offset: 0x00009C70
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.MyCollider.enabled = false;
      base.transform.parent = this.Target;
      base.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
      base.transform.localEulerAngles = Vector3.zero;
      base.enabled = false;
    }
  }

  // Token: 0x04000170 RID: 368
  public PromptScript Prompt;

  // Token: 0x04000171 RID: 369
  public Transform Target;

  // Token: 0x04000172 RID: 370
  public float X;

  // Token: 0x04000173 RID: 371
  public float Y;

  // Token: 0x04000174 RID: 372
  public float Z;
}