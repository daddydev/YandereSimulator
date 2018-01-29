using UnityEngine;

// Token: 0x02000068 RID: 104
public class ClothingScript : MonoBehaviour {

  // Token: 0x06000177 RID: 375 RVA: 0x00019032 File Offset: 0x00017432
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
  }

  // Token: 0x06000178 RID: 376 RVA: 0x0001904C File Offset: 0x0001744C
  private void Update() {
    if (this.CanPickUp) {
      if (this.Yandere.Bloodiness == 0f) {
        this.CanPickUp = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (this.Yandere.Bloodiness > 0f) {
      this.CanPickUp = true;
      this.Prompt.enabled = true;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Yandere.Bloodiness = 0f;
      UnityEngine.Object.Instantiate<GameObject>(this.FoldedUniform, base.transform.position + Vector3.up, Quaternion.identity);
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x0400048B RID: 1163
  public YandereScript Yandere;

  // Token: 0x0400048C RID: 1164
  public PromptScript Prompt;

  // Token: 0x0400048D RID: 1165
  public GameObject FoldedUniform;

  // Token: 0x0400048E RID: 1166
  public bool CanPickUp;
}