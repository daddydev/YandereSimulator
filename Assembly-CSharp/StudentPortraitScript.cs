using UnityEngine;

// Token: 0x020001C9 RID: 457
public class StudentPortraitScript : MonoBehaviour {

  // Token: 0x0600080D RID: 2061 RVA: 0x0007D955 File Offset: 0x0007BD55
  private void Start() {
    this.DeathShadow.SetActive(false);
    this.PrisonBars.SetActive(false);
    this.Panties.SetActive(false);
    this.Friend.SetActive(false);
  }

  // Token: 0x0400150B RID: 5387
  public GameObject DeathShadow;

  // Token: 0x0400150C RID: 5388
  public GameObject PrisonBars;

  // Token: 0x0400150D RID: 5389
  public GameObject Panties;

  // Token: 0x0400150E RID: 5390
  public GameObject Friend;

  // Token: 0x0400150F RID: 5391
  public UITexture Portrait;
}