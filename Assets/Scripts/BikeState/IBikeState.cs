using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBikeState
{
    void Handle(BikeController controller); // ���� ���� ����� BikeController�� �ƴ϶� Context ������Ʈ�� State�� �����Ѵ�.
}
