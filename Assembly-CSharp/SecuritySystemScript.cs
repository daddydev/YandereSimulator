using UnityEngine;

// Token: 0x020001AB RID: 427
public class SecuritySystemScript : MonoBehaviour {

  // Token: 0x06000777 RID: 1911 RVA: 0x0007058C File Offset: 0x0006E98C
  private void Start() {
    if (!SchoolGlobals.HighSecurity) {
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000778 RID: 1912 RVA: 0x000705A4 File Offset: 0x0006E9A4
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      for (int i = 0; i < this.Cameras.Length; i++) {
        this.Cameras[i].transform.parent.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
        this.Cameras[i].gameObject.SetActive(false);
      }
      for (int i = 0; i < this.Detectors.Length; i++) {
        this.Detectors[i].MyCollider.enabled = false;
        this.Detectors[i].enabled = false;
      }
      base.GetComponent<AudioSource>().Play();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Evidence = false;
      base.enabled = false;
    }
  }

  // Token: 0x040012EB RID: 4843
  public PromptScript Prompt;

  // Token: 0x040012EC RID: 4844
  public bool Evidence;

  // Token: 0x040012ED RID: 4845
  public bool Masked;

  // Token: 0x040012EE RID: 4846
  public SecurityCameraScript[] Cameras;

  // Token: 0x040012EF RID: 4847
  public MetalDetectorScript[] Detectors;
}