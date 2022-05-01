public static class Settings
{
    public static Setting<float> MasterVolume = new FloatSetting("Master Volume", 1.0f);
    public static Setting<float> MusicVolume = new FloatSetting("Music Volume", 1.0f);
    public static Setting<float> SfxVolume = new FloatSetting("Sfx Volume", 1.0f);

    public static Setting<float> TextDelay = new FloatSetting("Text Delay", 0.05f);
    public static Setting<float> TextSpeed = new FloatSetting("Text Speed", 0.5f);
}
