using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000062 RID: 98
public class ChoiceScript : MonoBehaviour {

  // Token: 0x0600015C RID: 348 RVA: 0x00016771 File Offset: 0x00014B71
  private void Start() {
    this.Darkness.color = new Color(1f, 1f, 1f, 1f);
  }

  // Token: 0x0600015D RID: 349 RVA: 0x00016798 File Offset: 0x00014B98
  private void Update() {
    this.Highlight.transform.localPosition = Vector3.Lerp(this.Highlight.transform.localPosition, new Vector3((float)(-360 + 720 * this.Selected), this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z), Time.deltaTime * 10f);
    if (this.Phase == 0) {
      this.Darkness.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 2f));
      if (this.Darkness.color.a == 0f) {
        this.Phase++;
      }
    } else if (this.Phase == 1) {
      if (this.InputManager.TappedLeft) {
        this.Darkness.color = new Color(1f, 1f, 1f, 0f);
        this.Selected = 0;
      } else if (this.InputManager.TappedRight) {
        this.Darkness.color = new Color(0f, 0f, 0f, 0f);
        this.Selected = 1;
      }
      if (Input.GetButtonDown("A")) {
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 2f));
      if (this.Darkness.color.a == 1f) {
        GameGlobals.LoveSick = (this.Selected == 1);
        SceneManager.LoadScene("TitleScene");
      }
    }
  }

  // Token: 0x04000435 RID: 1077
  public InputManagerScript InputManager;

  // Token: 0x04000436 RID: 1078
  public PromptBarScript PromptBar;

  // Token: 0x04000437 RID: 1079
  public Transform Highlight;

  // Token: 0x04000438 RID: 1080
  public UISprite Darkness;

  // Token: 0x04000439 RID: 1081
  public int Selected;

  // Token: 0x0400043A RID: 1082
  public int Phase;
}