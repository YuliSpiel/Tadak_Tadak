using System;
using System.Collections.Generic;
using Utils;

namespace MiniGame
{
    public interface IPlayer
    {
        Dictionary<Define.PlayerAction, Action> GetActionMap();
    }
}