using UnityEngine;

// Token: 0x020000E6 RID: 230
public class GloveScript : MonoBehaviour {

  // Token: 0x060004AE RID: 1198 RVA: 0x0003CCF0 File Offset: 0x0003B0F0
  private void Start() {
    YandereScript component = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    Physics.IgnoreCollision(component.GetComponent<Collider>(), this.MyCollider);
    if (base.transform.position.y > 1000f) {
      base.transform.position = new Vector3(12f, 0f, 28f);
    }
  }

  // Token: 0x060004AF RID: 1199 RVA: 0x0003CD5C File Offset: 0x0003B15C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      base.transform.parent = this.Prompt.Yandere.transform;
      base.transform.localPosition = new Vector3(0f, 1f, 0.25f);
      this.Prompt.Yandere.Gloves = this;
      this.Prompt.Yandere.WearGloves();
      base.gameObject.SetActive(false);
    }
    this.Prompt.HideButton[0] = (this.Prompt.Yandere.Schoolwear != 1 || this.Prompt.Yandere.ClubAttire);
  }

  // Token: 0x04000A4A RID: 2634
  public PromptScript Prompt;

  // Token: 0x04000A4B RID: 2635
  public PickUpScript PickUp;

  // Token: 0x04000A4C RID: 2636
  public Collider MyCollider;

  // Token: 0x04000A4D RID: 2637
  public Projector Blood;
}