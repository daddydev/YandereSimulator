using UnityEngine;

// Token: 0x02000109 RID: 265
public class HomeZoomScript : MonoBehaviour {

  // Token: 0x0600052F RID: 1327 RVA: 0x00047EDC File Offset: 0x000462DC
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (Input.GetKeyDown(KeyCode.Z)) {
      if (!this.Zoom) {
        this.Zoom = true;
        component.Play();
      } else {
        this.Zoom = false;
      }
    }
    if (this.Zoom) {
      base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, 1.5f, Time.deltaTime * 0.0333333351f), base.transform.localPosition.z);
      this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-1.5f, 1.5f, 1f), Time.deltaTime * 0.0333333351f);
      component.volume += Time.deltaTime * 0.01f;
    } else {
      base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, 1f, Time.deltaTime * 10f), base.transform.localPosition.z);
      this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-2.271312f, 2f, 3.5f), Time.deltaTime * 10f);
      component.volume = 0f;
    }
  }

  // Token: 0x04000C41 RID: 3137
  public Transform YandereDestination;

  // Token: 0x04000C42 RID: 3138
  public bool Zoom;
}