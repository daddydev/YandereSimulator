using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000C4 RID: 196
public class FunScript : MonoBehaviour {

  // Token: 0x060002EC RID: 748 RVA: 0x00037870 File Offset: 0x00035C70
  private void Start() {
    if (SceneManager.GetActiveScene().name == "MoreFunScene") {
      this.G = 0f;
      this.B = 0f;
      this.Label.color = new Color(this.R, this.G, this.B, 1f);
      this.Skip.SetActive(false);
    }
    this.Controls.SetActive(false);
    this.Label.text = this.Lines[this.ID];
    this.Label.gameObject.SetActive(false);
    this.Girl.color = new Color(this.R, this.G, this.B, 0f);
  }

  // Token: 0x060002ED RID: 749 RVA: 0x00037940 File Offset: 0x00035D40
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 3f) {
      if (!this.Typewriter.mActive) {
        this.Controls.SetActive(true);
      }
    } else if (this.Timer > 2f) {
      this.Label.gameObject.SetActive(true);
    } else if (this.Timer > 1f) {
      this.Girl.color = new Color(this.R, this.G, this.B, Mathf.MoveTowards(this.Girl.color.a, 1f, Time.deltaTime));
    }
    if (this.Controls.activeInHierarchy) {
      if (Input.GetButtonDown("B")) {
        if (this.Skip.activeInHierarchy) {
          this.ID = 19;
          this.Skip.SetActive(false);
          this.Girl.mainTexture = this.Portraits[this.ID];
          this.Typewriter.ResetToBeginning();
          this.Typewriter.mLabel.text = this.Lines[this.ID];
        }
      } else if (Input.GetButtonDown("A")) {
        if (this.ID < this.Lines.Length - 1) {
          if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length) {
            this.Typewriter.Finish();
          } else {
            this.ID++;
            if (this.ID == 19) {
              this.Skip.SetActive(false);
            }
            this.Girl.mainTexture = this.Portraits[this.ID];
            this.Typewriter.ResetToBeginning();
            this.Typewriter.mLabel.text = this.Lines[this.ID];
          }
        } else {
          Application.Quit();
        }
      }
    }
  }

  // Token: 0x0400094D RID: 2381
  public TypewriterEffect Typewriter;

  // Token: 0x0400094E RID: 2382
  public GameObject Controls;

  // Token: 0x0400094F RID: 2383
  public GameObject Skip;

  // Token: 0x04000950 RID: 2384
  public Texture[] Portraits;

  // Token: 0x04000951 RID: 2385
  public string[] Lines;

  // Token: 0x04000952 RID: 2386
  public UITexture Girl;

  // Token: 0x04000953 RID: 2387
  public UILabel Label;

  // Token: 0x04000954 RID: 2388
  public float OutroTimer;

  // Token: 0x04000955 RID: 2389
  public float Timer;

  // Token: 0x04000956 RID: 2390
  public int ID;

  // Token: 0x04000957 RID: 2391
  public float R = 1f;

  // Token: 0x04000958 RID: 2392
  public float G = 1f;

  // Token: 0x04000959 RID: 2393
  public float B = 1f;
}