﻿public class AudioStateMessage {

    public float? EffectsVolume { get; set; }
    public float? MusicVolume { get; set; }

    public AudioStateMessage(float? effectsVolume, float? musicVolume)
    {
        EffectsVolume = effectsVolume;
        MusicVolume = musicVolume;
    }
}
