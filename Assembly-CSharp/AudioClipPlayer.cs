using UnityEngine;

// Token: 0x020001F0 RID: 496
public static class AudioClipPlayer {

  // Token: 0x060008D7 RID: 2263 RVA: 0x0009E1FC File Offset: 0x0009C5FC
  public static void Play(AudioClip clip, Vector3 position, float minDistance, float maxDistance, out GameObject clipOwner, float playerY) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
    float y = gameObject.transform.position.y;
    audioSource.volume = ((playerY >= y - 2f) ? 1f : 0f);
  }

  // Token: 0x060008D8 RID: 2264 RVA: 0x0009E2A8 File Offset: 0x0009C6A8
  public static void PlayAttached(AudioClip clip, Vector3 position, Transform attachment, float minDistance, float maxDistance, out GameObject clipOwner, float playerY) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    gameObject.transform.parent = attachment;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
    float y = gameObject.transform.position.y;
    audioSource.volume = ((playerY >= y - 2f) ? 1f : 0f);
  }

  // Token: 0x060008D9 RID: 2265 RVA: 0x0009E360 File Offset: 0x0009C760
  public static void PlayAttached(AudioClip clip, Transform attachment, float minDistance, float maxDistance) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.parent = attachment;
    gameObject.transform.localPosition = Vector3.zero;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
  }

  // Token: 0x060008DA RID: 2266 RVA: 0x0009E3E0 File Offset: 0x0009C7E0
  public static void Play(AudioClip clip, Vector3 position, float minDistance, float maxDistance, out GameObject clipOwner, out float clipLength) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    clipLength = clip.length;
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
  }

  // Token: 0x060008DB RID: 2267 RVA: 0x0009E45C File Offset: 0x0009C85C
  public static void Play(AudioClip clip, Vector3 position, float minDistance, float maxDistance, out GameObject clipOwner) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
  }

  // Token: 0x060008DC RID: 2268 RVA: 0x0009E4D0 File Offset: 0x0009C8D0
  public static void Play2D(AudioClip clip, Vector3 position) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
  }

  // Token: 0x060008DD RID: 2269 RVA: 0x0009E520 File Offset: 0x0009C920
  public static void Play2D(AudioClip clip, Vector3 position, float pitch) {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    audioSource.pitch = pitch;
  }
}