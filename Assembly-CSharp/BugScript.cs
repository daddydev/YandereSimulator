using UnityEngine;

// Token: 0x02000053 RID: 83
public class BugScript : MonoBehaviour {

  // Token: 0x06000130 RID: 304 RVA: 0x00013DB2 File Offset: 0x000121B2
  private void Start() {
    this.MyRenderer.enabled = false;
  }

  // Token: 0x06000131 RID: 305 RVA: 0x00013DC0 File Offset: 0x000121C0
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.MyAudio.clip = this.Praise[UnityEngine.Random.Range(0, this.Praise.Length)];
      this.MyAudio.Play();
      this.MyRenderer.enabled = true;
      PlayerGlobals.PantyShots += 5;
      base.enabled = false;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
  }

  // Token: 0x040003C7 RID: 967
  public PromptScript Prompt;

  // Token: 0x040003C8 RID: 968
  public Renderer MyRenderer;

  // Token: 0x040003C9 RID: 969
  public AudioSource MyAudio;

  // Token: 0x040003CA RID: 970
  public AudioClip[] Praise;
}