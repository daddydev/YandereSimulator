using UnityEngine;

// Token: 0x020000F2 RID: 242
public class HideColliderScript : MonoBehaviour {

  // Token: 0x060004D6 RID: 1238 RVA: 0x000401FC File Offset: 0x0003E5FC
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 11) {
      GameObject gameObject = other.gameObject.transform.root.gameObject;
      if (!gameObject.GetComponent<StudentScript>().Alive) {
        this.Corpse = gameObject.GetComponent<RagdollScript>();
        if (!this.Corpse.Hidden) {
          this.Corpse.HideCollider = this.MyCollider;
          this.Corpse.Police.HiddenCorpses++;
          this.Corpse.Hidden = true;
        }
      }
    }
  }

  // Token: 0x04000AEA RID: 2794
  public RagdollScript Corpse;

  // Token: 0x04000AEB RID: 2795
  public Collider MyCollider;
}