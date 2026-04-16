using System.Media;

namespace WinFormsGame.Utilities
{
    public static class SoundEffectPlayer
    {
        public static void PlayHitSound()
        {
            // Заглушка для звука удара.
            // Чтобы использовать свой звук:
            // 1) Добавьте WAV-файл в Resources.resx (например, HitSound).
            // 2) Замените строку ниже на:
            //    new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.HitSound)).Play();
            SystemSounds.Beep.Play();
        }
    }
}
