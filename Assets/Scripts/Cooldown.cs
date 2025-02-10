using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages cooldowns for actions identified by a string.
/// </summary>
public static class Cooldown
{
    private static readonly Dictionary<string, CooldownData> cooldowns = new();

    /// <summary>
    /// Set a specific cooldown.
    /// </summary>
    /// <param abilityName="id">The unique identifier.</param>
    /// <param abilityName="duration">The cooldown duration in seconds.</param>
    public static void Set(string id, float duration)
    {
        if (string.IsNullOrEmpty(id))
        {
            Debug.LogWarning("Attempted to set cooldown with an invalid ID.");
            return;
        }

        if (!cooldowns.TryGetValue(id, out var cooldown))
            cooldowns[id] = new CooldownData(duration);
        else
            cooldown.CurrentTime = duration;
    }

    /// <summary>
    /// Activates a cooldown, marking its start time.
    /// </summary>
    /// <param abilityName="id">The unique identifier.</param>
    public static void Use(string id)
    {
        if (!cooldowns.TryGetValue(id, out var cooldown))
            throw new KeyNotFoundException($"Cooldown ID '{id}' not found.");

        cooldown.LastTime = Time.time;
    }

    /// <summary>
    /// Resets the cooldown, making the action immediately available.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    public static void Reset(string id)
    {
        if (!cooldowns.TryGetValue(id, out var cooldown))
            throw new KeyNotFoundException($"Cooldown ID '{id}' not found.");

        cooldown.LastTime = -cooldown.CurrentTime;
    }

    /// <summary>
    /// Checks if the cooldown is ready to be used again.
    /// </summary>
    /// <param abilityName="id">The unique identifier.</param>
    public static bool IsReady(string id)
    {
        return cooldowns.TryGetValue(id, out var cooldown) &&
               Time.time >= cooldown.CurrentTime + cooldown.LastTime;
    }

    /// <summary>
    /// Gets the remaining time before the cooldown expires.
    /// </summary>
    /// <param abilityName="id">The unique identifier.</param>
    public static float GetRemainingTime(string id)
    {
        if (!cooldowns.TryGetValue(id, out var cooldown))
            throw new KeyNotFoundException($"Cooldown ID '{id}' not found.");

        float remaining = (cooldown.CurrentTime + cooldown.LastTime) - Time.time;
        return Mathf.Max(remaining, 0);
    }

    /// <summary>
    /// Represents data from a cooldown.
    /// </summary>
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