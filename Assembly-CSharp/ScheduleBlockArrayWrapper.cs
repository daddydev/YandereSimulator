using System;

// Token: 0x020001EE RID: 494
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock> {

  // Token: 0x060008D3 RID: 2259 RVA: 0x0009E1D6 File Offset: 0x0009C5D6
  public ScheduleBlockArrayWrapper(int size) : base(size) {
  }

  // Token: 0x060008D4 RID: 2260 RVA: 0x0009E1DF File Offset: 0x0009C5DF
  public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements) {
  }
}