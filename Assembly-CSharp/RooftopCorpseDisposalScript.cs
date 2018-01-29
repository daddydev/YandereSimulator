using UnityEngine;

// Token: 0x02000186 RID: 390
public class RooftopCorpseDisposalScript : MonoBehaviour {

  // Token: 0x06000706 RID: 1798 RVA: 0x0006BF0A File Offset: 0x0006A30A
  private void Start() {
    if (SchoolGlobals.RoofFence) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x06000707 RID: 1799 RVA: 0x0006BF24 File Offset: 0x0006A324
  private void Update() {
    if (this.MyCollider.bounds.Contains(this.Yandere.transform.position)) {
      if (this.Yandere.Ragdoll != null) {
        if (!this.Yandere.Dropping) {
          this.Prompt.enabled = true;
          this.Prompt.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1.66666f, this.Yandere.transform.position.z);
          if (this.Prompt.Circle[0].fillAmount == 0f) {
            this.DropSpot.position = new Vector3(this.DropSpot.position.x, this.DropSpot.position.y, this.Yandere.transform.position.z);
            this.Yandere.Character.GetComponent<Animation>().CrossFade((!this.Yandere.Carrying) ? "f02_dragIdle_00" : "f02_carryIdleA_00");
            this.Yandere.DropSpot = this.DropSpot;
            this.Yandere.Dropping = true;
            this.Yandere.CanMove = false;
            this.Prompt.Hide();
            this.Prompt.enabled = false;
          }
        }
      } else {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }

  // Token: 0x040011E0 RID: 4576
  public YandereScript Yandere;

  // Token: 0x040011E1 RID: 4577
  public PromptScript Prompt;

  // Token: 0x040011E2 RID: 4578
  public Collider MyCollider;

  // Token: 0x040011E3 RID: 4579
  public Transform DropSpot;
}