using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ExamPortalApp.Infrastructure.Extensions
{
    public static class SystemSpeechExtension
    {
        const int PDefaultRate = 3;
        const int PErrorRate = 4;
        public static void Speak(this string text2speak)
        {
            text2speak.Speak(PDefaultRate);
        }
        public static void Speak(this string text2speak, int rate)
        {
            var voice = new SpeechSynthesizer();
            voice.SetOutputToDefaultAudioDevice();
            voice.Rate = rate;
            voice.Speak(text2speak);
        }
        public static void SpeakError(this string text2speak)
        {
        #if(DEBUG)
        $ "Error {text2speak} while debugging!".Speak(PErrorRate);
#endif
        }
    }
}
