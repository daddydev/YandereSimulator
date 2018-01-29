using UnityEngine;

// Token: 0x020000BC RID: 188
public class FallCheckerScript : MonoBehaviour {

  // Token: 0x060002D5 RID: 725 RVA: 0x000361EC File Offset: 0x000345EC
  private void OnTriggerEnter(Collider other) {
    if (this.Ragdoll == null && other.gameObject.layer == 11) {
      this.Ragdoll = other.transform.root.gameObject.GetComponent<RagdollScript>();
      this.Ragdoll.Prompt.Hide();
      this.Ragdoll.Prompt.enabled = false;
      this.Ragdoll.Prompt.MyCollider.enabled = false;
      this.Ragdoll.BloodPoolSpawner.enabled = false;
      this.Ragdoll.HideCollider = this.MyCollider;
      this.Ragdoll.Police.HiddenCorpses++;
      this.Ragdoll.Hidden = true;
      this.Dumpster.Corpse = this.Ragdoll.gameObject;
      this.Dumpster.Victim = this.Ragdoll.Student;
    }
  }

  // Token: 0x060002D6 RID: 726 RVA: 0x000362E0 File Offset: 0x000346E0
  private void Update() {
    if (this.Ragdoll != null) {
      if (this.Ragdoll.Prompt.transform.localPosition.y > -10.5f) {
        this.Ragdoll.Prompt.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
        this.Ragdoll.AllColliders[2].transform.localEulerAngles = Vector3.zero;
        this.Ragdoll.AllColliders[7].transform.localEulerAngles = new Vector3(0f, 0f, -80f);
        this.Ragdoll.Prompt.transform.position = new Vector3(this.Dumpster.transform.position.x, this.Ragdoll.Prompt.transform.position.y, this.Dumpster.transform.position.z);
      } else {
        base.GetComponent<AudioSource>().Play();
        this.Ragdoll = null;
      }
    }
  }

  // Token: 0x04000905 RID: 2309
  public DumpsterLidScript Dumpster;

  // Token: 0x04000906 RID: 2310
  public RagdollScript Ragdoll;

  // Token: 0x04000907 RID: 2311
  public Collider MyCollider;
}