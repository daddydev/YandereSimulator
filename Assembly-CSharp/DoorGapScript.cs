using UnityEngine;

// Token: 0x0200008D RID: 141
public class DoorGapScript : MonoBehaviour {

  // Token: 0x0600022F RID: 559 RVA: 0x0002EEC9 File Offset: 0x0002D2C9
  private void Start() {
    this.Papers[1].gameObject.SetActive(false);
  }

  // Token: 0x06000230 RID: 560 RVA: 0x0002EEE0 File Offset: 0x0002D2E0
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      if (this.Phase == 1) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Prompt.Yandere.Inventory.AnswerSheet = false;
        this.Papers[1].gameObject.SetActive(true);
        SchemeGlobals.SetSchemeStage(5, 3);
        this.Schemes.UpdateInstructions();
        base.GetComponent<AudioSource>().Play();
      } else {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Prompt.Yandere.Inventory.AnswerSheet = true;
        this.Prompt.Yandere.Inventory.DuplicateSheet = true;
        this.Papers[2].gameObject.SetActive(false);
        this.RummageSpot.Prompt.Label[0].text = "     Return Answer Sheet";
        this.RummageSpot.Prompt.enabled = true;
        SchemeGlobals.SetSchemeStage(5, 4);
        this.Schemes.UpdateInstructions();
      }
      this.Phase++;
    }
    if (this.Phase == 2) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 4f) {
        this.Prompt.Label[0].text = "     Pick Up Sheets";
        this.Prompt.enabled = true;
        this.Phase = 2;
      } else if (this.Timer > 3f) {
        Transform transform = this.Papers[2];
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, -0.166f, Time.deltaTime * 10f));
      } else if (this.Timer > 1f) {
        Transform transform2 = this.Papers[1];
        transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, 0.166f, Time.deltaTime * 10f));
      }
    }
  }

  // Token: 0x04000792 RID: 1938
  public RummageSpotScript RummageSpot;

  // Token: 0x04000793 RID: 1939
  public SchemesScript Schemes;

  // Token: 0x04000794 RID: 1940
  public PromptScript Prompt;

  // Token: 0x04000795 RID: 1941
  public Transform[] Papers;

  // Token: 0x04000796 RID: 1942
  public float Timer;

  // Token: 0x04000797 RID: 1943
  public int Phase = 1;
}