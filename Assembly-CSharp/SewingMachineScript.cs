using UnityEngine;

// Token: 0x020001AE RID: 430
public class SewingMachineScript : MonoBehaviour {

  // Token: 0x06000784 RID: 1924 RVA: 0x000713DE File Offset: 0x0006F7DE
  private void Start() {
    if (TaskGlobals.GetTaskStatus(7) > 2) {
      base.enabled = false;
    }
  }

  // Token: 0x06000785 RID: 1925 RVA: 0x000713F4 File Offset: 0x0006F7F4
  private void Update() {
    if (TaskGlobals.GetTaskStatus(7) == 1) {
      if (this.Yandere.PickUp != null) {
        if (this.Yandere.PickUp.Clothing && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Clean && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Type == 1 && this.Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>().Type == 1) {
          this.Prompt.enabled = true;
        }
      } else {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_sewing_00");
      this.Yandere.MyController.radius = 0.1f;
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Yandere.CanMove = false;
      this.Chair.enabled = false;
      this.Sewing = true;
      base.GetComponent<AudioSource>().Play();
      this.Uniform = this.Yandere.PickUp;
      this.Yandere.EmptyHands();
      this.Uniform.transform.parent = this.Yandere.RightHand;
      this.Uniform.transform.localPosition = new Vector3(0f, 0f, 0.09f);
      this.Uniform.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
      this.Uniform.MyRigidbody.useGravity = false;
      this.Uniform.MyCollider.enabled = false;
    }
    if (this.Sewing) {
      this.Timer += Time.deltaTime;
      if (this.Timer < 5f) {
        this.targetRotation = Quaternion.LookRotation(base.transform.parent.transform.parent.position - this.Yandere.transform.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.Yandere.MoveTowardsTarget(this.Chair.transform.position);
      } else if (!this.MoveAway) {
        this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
        this.Yandere.Inventory.ModifiedUniform = true;
        this.StudentManager.Students[7].TaskPhase = 5;
        TaskGlobals.SetTaskStatus(7, 2);
        UnityEngine.Object.Destroy(this.Uniform.gameObject);
        this.MoveAway = true;
      } else {
        this.Yandere.MoveTowardsTarget(this.Chair.gameObject.transform.position + new Vector3(-0.5f, 0f, 0f));
        if (this.Timer > 6f) {
          this.Yandere.MyController.radius = 0.2f;
          this.Yandere.CanMove = true;
          this.Chair.enabled = true;
          base.enabled = false;
          this.Sewing = false;
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
    }
  }

  // Token: 0x0400131B RID: 4891
  public StudentManagerScript StudentManager;

  // Token: 0x0400131C RID: 4892
  public YandereScript Yandere;

  // Token: 0x0400131D RID: 4893
  public PromptScript Prompt;

  // Token: 0x0400131E RID: 4894
  public Quaternion targetRotation;

  // Token: 0x0400131F RID: 4895
  public PickUpScript Uniform;

  // Token: 0x04001320 RID: 4896
  public Collider Chair;

  // Token: 0x04001321 RID: 4897
  public bool MoveAway;

  // Token: 0x04001322 RID: 4898
  public bool Sewing;

  // Token: 0x04001323 RID: 4899
  public float Timer;
}