using UnityEngine;

// Token: 0x0200020F RID: 527
public class VendingMachineScript : MonoBehaviour {

  // Token: 0x06000932 RID: 2354 RVA: 0x0009F078 File Offset: 0x0009D478
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Can, this.CanSpawn.position, Quaternion.identity);
      gameObject.transform.eulerAngles = new Vector3(90f, 90f, gameObject.transform.eulerAngles.z);
      gameObject.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.9f, 1.1f);
    }
  }

  // Token: 0x04001A20 RID: 6688
  public PromptScript Prompt;

  // Token: 0x04001A21 RID: 6689
  public Transform CanSpawn;

  // Token: 0x04001A22 RID: 6690
  public GameObject Can;
}