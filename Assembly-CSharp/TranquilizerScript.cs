using UnityEngine;

// Token: 0x020001E7 RID: 487
public class TranquilizerScript : MonoBehaviour {

  // Token: 0x060008BD RID: 2237 RVA: 0x0009DB04 File Offset: 0x0009BF04
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Inventory.Tranquilizer = true;
      this.Yandere.TheftTimer = 1f;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x040019E3 RID: 6627
  public YandereScript Yandere;

  // Token: 0x040019E4 RID: 6628
  public PromptScript Prompt;
}