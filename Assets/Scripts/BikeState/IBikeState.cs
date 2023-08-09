using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBikeState
{
    void Handle(BikeController controller); // 전통 적인 방식은 BikeController가 아니라 Context 오브젝트를 State에 전달한다.
}
