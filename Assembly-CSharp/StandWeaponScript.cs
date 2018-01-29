using UnityEngine;

// Token: 0x020001C1 RID: 449
public class StandWeaponScript : MonoBehaviour {

  // Token: 0x060007CC RID: 1996 RVA: 0x0007783C File Offset: 0x00075C3C
  private void Update() {
    if (this.Prompt.enabled) {
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.MoveToStand();
      }
    } else {
      base.transform.Rotate(Vector3.forward * (Time.deltaTime * this.RotationSpeed));
      base.transform.Rotate(Vector3.right * (Time.deltaTime * this.RotationSpeed));
      base.transform.Rotate(Vector3.up * (Time.deltaTime * this.RotationSpeed));
    }
  }

  // Token: 0x060007CD RID: 1997 RVA: 0x000778E4 File Offset: 0x00075CE4
  private void MoveToStand() {
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Prompt.MyCollider.enabled = false;
    this.Stand.Weapons++;
    base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
    base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
  }

  // Token: 0x04001401 RID: 5121
  public PromptScript Prompt;

  // Token: 0x04001402 RID: 5122
  public StandScript Stand;

  // Token: 0x04001403 RID: 5123
  public float RotationSpeed;
}