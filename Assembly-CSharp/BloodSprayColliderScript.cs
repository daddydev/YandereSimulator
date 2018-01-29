using UnityEngine;

// Token: 0x02000043 RID: 67
public class BloodSprayColliderScript : MonoBehaviour {

  // Token: 0x060000F9 RID: 249 RVA: 0x0001191C File Offset: 0x0000FD1C
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 13) {
      YandereScript component = other.gameObject.GetComponent<YandereScript>();
      if (component != null) {
        component.Bloodiness = 100f;
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
  }
}