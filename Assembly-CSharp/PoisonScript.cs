using UnityEngine;

// Token: 0x0200015D RID: 349
public class PoisonScript : MonoBehaviour {

  // Token: 0x0600066F RID: 1647 RVA: 0x0005CDB1 File Offset: 0x0005B1B1
  public void Start() {
    base.gameObject.SetActive(ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryBonus >= 1);
  }

  // Token: 0x06000670 RID: 1648 RVA: 0x0005CDCF File Offset: 0x0005B1CF
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.PossessPoison = true;
      UnityEngine.Object.Destroy(base.gameObject);
      UnityEngine.Object.Destroy(this.Bottle);
    }
  }

  // Token: 0x04000F9D RID: 3997
  public YandereScript Yandere;

  // Token: 0x04000F9E RID: 3998
  public PromptScript Prompt;

  // Token: 0x04000F9F RID: 3999
  public GameObject Bottle;
}