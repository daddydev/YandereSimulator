using UnityEngine;

// Token: 0x02000045 RID: 69
public class BlowtorchScript : MonoBehaviour {

  // Token: 0x060000FD RID: 253 RVA: 0x000119B1 File Offset: 0x0000FDB1
  private void Start() {
    this.Flame.localScale = Vector3.zero;
    base.enabled = false;
  }

  // Token: 0x060000FE RID: 254 RVA: 0x000119CC File Offset: 0x0000FDCC
  private void Update() {
    this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
    float num = UnityEngine.Random.Range(0.9f, 1f);
    this.Flame.localScale = new Vector3(num, num, num);
    if (this.Timer == 5f) {
      this.Flame.localScale = Vector3.zero;
      this.Yandere.Cauterizing = false;
      this.Yandere.CanMove = true;
      base.enabled = false;
      base.GetComponent<AudioSource>().Stop();
      this.Timer = 0f;
    }
  }

  // Token: 0x0400034E RID: 846
  public YandereScript Yandere;

  // Token: 0x0400034F RID: 847
  public RagdollScript Corpse;

  // Token: 0x04000350 RID: 848
  public PickUpScript PickUp;

  // Token: 0x04000351 RID: 849
  public PromptScript Prompt;

  // Token: 0x04000352 RID: 850
  public Transform Flame;

  // Token: 0x04000353 RID: 851
  public float Timer;
}