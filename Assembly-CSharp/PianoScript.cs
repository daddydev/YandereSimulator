using UnityEngine;

// Token: 0x02000157 RID: 343
public class PianoScript : MonoBehaviour {

  // Token: 0x06000658 RID: 1624 RVA: 0x0005B5BC File Offset: 0x000599BC
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f) {
      this.Prompt.Circle[0].fillAmount = 0f;
      this.Notes[this.ID].Play();
      this.ID++;
      if (this.ID == this.Notes.Length) {
        this.ID = 0;
      }
    }
  }

  // Token: 0x04000F54 RID: 3924
  public PromptScript Prompt;

  // Token: 0x04000F55 RID: 3925
  public AudioSource[] Notes;

  // Token: 0x04000F56 RID: 3926
  public int ID;
}