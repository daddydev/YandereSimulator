using UnityEngine;

// Token: 0x02000222 RID: 546
public class YandereShoeLockerScript : MonoBehaviour {

  // Token: 0x060009BA RID: 2490 RVA: 0x000B2218 File Offset: 0x000B0618
  private void Update() {
    if (this.Yandere.Schoolwear == 1 && !this.Yandere.ClubAttire) {
      if (this.Label == 2) {
        this.Prompt.Label[0].text = "     Change Shoes";
        this.Label = 1;
      }
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Yandere.Casual = !this.Yandere.Casual;
        this.Yandere.ChangeSchoolwear();
        this.Yandere.CanMove = true;
      }
    } else {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (this.Label == 1) {
        this.Prompt.Label[0].text = "     Not Available";
        this.Label = 2;
      }
    }
  }

  // Token: 0x04001D7A RID: 7546
  public YandereScript Yandere;

  // Token: 0x04001D7B RID: 7547
  public PromptScript Prompt;

  // Token: 0x04001D7C RID: 7548
  public int Label = 1;
}