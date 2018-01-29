using System;

// Token: 0x020000AF RID: 175
[Serializable]
public class ScheduleBlock {

  // Token: 0x060002AB RID: 683 RVA: 0x00034EBC File Offset: 0x000332BC
  public ScheduleBlock(float time, string destination, string action) {
    this.time = time;
    this.destination = destination;
    this.action = action;
  }

  // Token: 0x040008BA RID: 2234
  public float time;

  // Token: 0x040008BB RID: 2235
  public string destination;

  // Token: 0x040008BC RID: 2236
  public string action;
}