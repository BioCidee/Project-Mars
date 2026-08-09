using UnityEngine;

namespace Toolbox
{
    public static class LayerCheck {
        public static bool CheckIfLayer(LayerMask _gameObjectLayer, GameObject _layerToCheck) {
            if ((_gameObjectLayer.value & (1 << _layerToCheck.layer)) != 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
