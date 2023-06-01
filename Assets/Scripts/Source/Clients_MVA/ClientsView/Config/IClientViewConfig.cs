using UnityEngine;

namespace Clients.View.Configs
{
    public interface IClientViewConfig
    {
        public Sprite Body { get; }
        public Sprite Hair { get; }
        public Sprite Kit { get; }
        public Sprite Face { get; }
        public Color HairColor { get; }
    }
}