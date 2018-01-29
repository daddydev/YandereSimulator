using UnityEngine;

// Token: 0x02000152 RID: 338
public class PhoneCharmScript : MonoBehaviour {

  // Token: 0x06000635 RID: 1589 RVA: 0x00058D68 File Offset: 0x00057168
  private void Update() {
    base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
  }
}