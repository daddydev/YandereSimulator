using UnityEngine;

// Token: 0x020001B6 RID: 438
public class SithBeamScript : MonoBehaviour {

  // Token: 0x060007A8 RID: 1960 RVA: 0x00075C84 File Offset: 0x00074084
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (component != null && component.StudentID > 1) {
        UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        component.Health -= this.Damage;
        component.HealthBar.transform.parent.gameObject.SetActive(true);
        component.HealthBar.transform.localScale = new Vector3(component.Health / 100f, 1f, 1f);
        if (component.Health <= 0f) {
          component.DeathType = DeathType.EasterEgg;
          component.HealthBar.transform.parent.gameObject.SetActive(false);
          component.BecomeRagdoll();
          Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
          rigidbody.isKinematic = false;
        } else {
          component.CharacterAnimation[component.SithReactAnim].time = 0f;
          component.CharacterAnimation.Play(component.SithReactAnim);
          component.Pathfinding.canSearch = false;
          component.Pathfinding.canMove = false;
          component.HitReacting = true;
          component.Routine = false;
          component.Fleeing = false;
        }
      }
    }
  }

  // Token: 0x040013AE RID: 5038
  public GameObject BloodEffect;

  // Token: 0x040013AF RID: 5039
  public Collider MyCollider;

  // Token: 0x040013B0 RID: 5040
  public float Damage = 10f;
}