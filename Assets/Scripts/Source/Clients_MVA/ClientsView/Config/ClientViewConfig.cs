using UnityEngine;

namespace Clients.View.Configs
{
    [CreateAssetMenu(fileName = nameof(ClientViewConfig), menuName = "Configs/View/" + nameof(ClientViewConfig), order = 0)]
    public class ClientViewConfig : ScriptableObject, IClientViewConfig
    {
        [SerializeField] private Sprite _body;
        [SerializeField] private Sprite _hair;
        [SerializeField] private Sprite _kit;
        [SerializeField] private Sprite _face;
        [SerializeField] private Color _hairColor;

        public Sprite Body => _body;
        public Sprite Hair => _hair;
        public Sprite Kit => _kit;
        public Sprite Face => _face;
        public Color HairColor => _hairColor;
    }
}