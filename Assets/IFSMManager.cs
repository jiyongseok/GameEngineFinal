﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFSMManager
{
    void SetDeadState();
    void NotifyTargetKilled();
}
