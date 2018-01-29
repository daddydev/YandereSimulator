using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000236 RID: 566
public class YanvaniaTryAgainScript : MonoBehaviour {

  // Token: 0x060009F7 RID: 2551 RVA: 0x000B64FC File Offset: 0x000B48FC
  private void Start() {
    base.transform.localScale = Vector3.zero;
  }

  // Token: 0x060009F8 RID: 2552 RVA: 0x000B6510 File Offset: 0x000B4910
  private void Update() {
    if (!this.FadeOut) {
      if (base.transform.localScale.x > 0.9f) {
        if (this.InputManager.TappedLeft) {
          this.Selected = 1;
        }
        if (this.InputManager.TappedRight) {
          this.Selected = 2;
        }
        if (this.Selected == 1) {
          this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
          this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, -1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
        } else {
          this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, 100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
          this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, 1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
        }
        if (Input.GetButtonDown("A")) {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
          gameObject.transform.parent = this.Highlight;
          gameObject.transform.localPosition = Vector3.zero;
          this.FadeOut = true;
        }
      }
    } else {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if (this.Darkness.color.a >= 1f) {
        if (this.Selected == 1) {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
          SceneManager.LoadScene("YanvaniaTitleScene");
        }
      }
    }
  }

  // Token: 0x04001E19 RID: 7705
  public InputManagerScript InputManager;

  // Token: 0x04001E1A RID: 7706
  public GameObject ButtonEffect;

  // Token: 0x04001E1B RID: 7707
  public Transform Highlight;

  // Token: 0x04001E1C RID: 7708
  public UISprite Darkness;

  // Token: 0x04001E1D RID: 7709
  public bool FadeOut;

  // Token: 0x04001E1E RID: 7710
  public int Selected = 1;
}