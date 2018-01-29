using UnityEngine;

// Token: 0x0200012E RID: 302
public class MatchboxScript : MonoBehaviour {

  // Token: 0x060005B9 RID: 1465 RVA: 0x0004F345 File Offset: 0x0004D745
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
  }

  // Token: 0x060005BA RID: 1466 RVA: 0x0004F35C File Offset: 0x0004D75C
  private void Update() {
    if (!this.Prompt.PauseScreen.Show) {
      if (this.Yandere.PickUp == this.PickUp) {
        if (this.Prompt.HideButton[0]) {
          this.Yandere.Arc.SetActive(true);
          this.Prompt.HideButton[0] = false;
          this.Prompt.HideButton[3] = true;
        }
        if (this.Prompt.Circle[0].fillAmount == 0f) {
          this.Prompt.Circle[0].fillAmount = 1f;
          if (!this.Yandere.Flicking) {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Match, base.transform.position, Quaternion.identity);
            gameObject.transform.parent = this.Yandere.ItemParent;
            gameObject.transform.localPosition = new Vector3(0.0159f, 0.0043f, 0.0152f);
            gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            this.Yandere.Match = gameObject;
            this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_flickingMatch_00");
            this.Yandere.YandereVision = false;
            this.Yandere.Arc.SetActive(false);
            this.Yandere.Flicking = true;
            this.Yandere.CanMove = false;
            this.Prompt.Hide();
            this.Prompt.enabled = false;
          }
        }
      } else if (!this.Prompt.HideButton[0]) {
        this.Yandere.Arc.SetActive(false);
        this.Prompt.HideButton[0] = true;
        this.Prompt.HideButton[3] = false;
      }
    }
  }

  // Token: 0x04000DB7 RID: 3511
  public YandereScript Yandere;

  // Token: 0x04000DB8 RID: 3512
  public PromptScript Prompt;

  // Token: 0x04000DB9 RID: 3513
  public PickUpScript PickUp;

  // Token: 0x04000DBA RID: 3514
  public GameObject Match;
}