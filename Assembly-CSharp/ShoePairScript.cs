using UnityEngine;

// Token: 0x020001B0 RID: 432
public class ShoePairScript : MonoBehaviour {

  // Token: 0x06000789 RID: 1929 RVA: 0x00071809 File Offset: 0x0006FC09
  private void Start() {
    this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
    if (ClassGlobals.LanguageGrade + ClassGlobals.LanguageBonus < 1) {
      this.Prompt.enabled = false;
    }
    this.Note.SetActive(false);
  }

  // Token: 0x0600078A RID: 1930 RVA: 0x0007184C File Offset: 0x0006FC4C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Police.Suicide = true;
      this.Note.SetActive(true);
    }
  }

  // Token: 0x04001325 RID: 4901
  public PoliceScript Police;

  // Token: 0x04001326 RID: 4902
  public PromptScript Prompt;

  // Token: 0x04001327 RID: 4903
  public GameObject Note;
}