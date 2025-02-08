using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cooldown
{
    private static Dictionary<string, CooldownData> cooldowns;

    static Cooldown()
    {
        cooldowns = new();
    }

    public static void SetCooldown(string id, float duration)
    {
        if (!cooldowns.ContainsKey(id))
            cooldowns[id] = new(duration);
        else
            cooldowns[id].CurrentTime = duration;
    }

    public static void Use(string id)
    {
        if (!cooldowns.ContainsKey(id))
            throw new KeyNotFoundException($"The key '{id}' does not exist.");

        cooldowns[id].LastTime = Time.time;
    }

    public static bool IsReady(string id)
    {
        if (!cooldowns.ContainsKey(id))
            throw new KeyNotFoundException($"The key '{id}' does not exist.");

        var cooldown = cooldowns[id];

        return Time.time >= cooldown.CurrentTime + cooldown.LastTime;
    }

    public static float GetRemainingTime(string id)
    {
        if (!cooldowns.ContainsKey(id))
            throw new KeyNotFoundException($"The key '{id}' does not exist.");

        var cooldown = cooldowns[id];
        float remaining = (cooldown.CurrentTime + cooldown.LastTime) - Time.time;

        return Mathf.Max(remaining, 0);
    }

    private class CooldownData
    {
        public float CurrentTime { get; set; }

        public float LastTime { get; set; }

        public CooldownData(float currentTime)
        {
            CurrentTime = currentTime;
            LastTime = -currentTime;
        }
    }
}