using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotInput
{
    public class Axis
    {
        public string Id { get; private set; }
        public float Value;

        public Axis(string Id)
        {
            this.Id = Id;
            this.Value = 0;
        }

        public Axis(string Id, float Value)
        {
            this.Id = Id;
            this.Value = Value;
        }
    }
}
