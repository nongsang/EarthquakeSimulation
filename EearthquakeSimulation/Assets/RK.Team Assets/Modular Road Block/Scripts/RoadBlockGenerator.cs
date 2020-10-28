using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RK.Team
{

    public class RoadBlockGenerator : MonoBehaviour
    {
        public RoadBlockPart[] _blockParts = new RoadBlockPart[_partsCount];
        private const int _partsCount = 9;

        public bool _showDebugInspector = false;

        public void Repair()
        {
            foreach (var obj in _blockParts)
                obj._brokenToggle = false;
        }

        public void Fracture()
        {
            foreach (var obj in _blockParts)
                obj._brokenToggle = true;
        }

        public void RandomModules()
        {
            foreach (var obj in _blockParts)
                obj._brokenToggle = RandomBool();
        }

        public bool RandomBool(int truePercentage = 50)
        {
            return Random.Range(0, 100f) < truePercentage;
        }

        public void SetStayByPart(bool stay, RoadBLockPartsNames part)
        {
            var targetPart = _blockParts.First(t => t._partName == part);
            targetPart._brokenToggle = stay;
        }

    }

    [System.Serializable]
    public class RoadBlockPart
    {
        public GameObject _targetPart;
        public GameObject _unbrokenPrefab;
        public GameObject _brokenPrefab;
        public Transform _parent;

        public RoadBLockPartsNames _partName;
        private bool _broken;

        public bool _brokenToggle
        {
            get
            {
                return _broken;
            }
            set
            {
                SetBrokenStay(value);
            }
        }

        private void SetBrokenStay(bool newStay)
        {
            if (_broken == newStay)
                return;

            _broken = newStay;

            var localPos = _targetPart.transform.localPosition;
            var localRot = _targetPart.transform.localRotation;
            var localScale = _targetPart.transform.localScale;

            Object.DestroyImmediate(_targetPart);
            _targetPart = (GameObject)Object.Instantiate(_broken ? _brokenPrefab : _unbrokenPrefab, _parent);

            _targetPart.transform.localPosition = localPos;
            _targetPart.transform.localRotation = localRot;
            _targetPart.transform.localScale = localScale;

            _targetPart.name = _targetPart.name.Replace("(Clone)", "");
        }

    }

    public enum RoadBLockPartsNames
    {
        LeftUp,
        MiddleUp,
        RightUp,
        LeftDownFront,
        MiddleDownFront,
        RightDownFront,
        LeftDownBack,
        MiddleDownBack,
        RightDownBack
    }

}