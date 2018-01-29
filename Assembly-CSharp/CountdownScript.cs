using UnityEngine;

// Token: 0x02000076 RID: 118
public class CountdownScript : MonoBehaviour {

  // Token: 0x060001BD RID: 445 RVA: 0x000233A1 File Offset: 0x000217A1
  private void Update() {
    this.Sprite.fillAmount -= Time.deltaTime * 0.1f;
  }

  // Token: 0x04000607 RID: 1543
  public UISprite Sprite;
}