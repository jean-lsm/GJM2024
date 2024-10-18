using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[Serializable] public class Health 
    {
        public float HealthMax;
        public float HealthTotal;
        public void ChangeHealth(int Value)
        {
            HealthTotal += Value;
            if(HealthTotal > HealthMax) HealthTotal = HealthMax;
            if(HealthTotal < 0) HealthTotal = 0;
        }
        
        public async void _ChangeHealthOverTime(float Ratio, float AwaitTime)
        {            
            for (float i = 0; i < AwaitTime; i++)
            {
                HealthTotal += Ratio;
                if(HealthTotal > HealthMax) HealthTotal = HealthMax;
                if(HealthTotal < 0) HealthTotal = 0;
                await Task.Delay(1000);
            }
        }        
    }
