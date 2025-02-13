using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class CardResetInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddCardStack(EStackType.Reset)
                .AddViewPath("CardReset")
                .AddWorldPosition(new Vector3(-5.65f, -2f, 0f));
        }
    }
}