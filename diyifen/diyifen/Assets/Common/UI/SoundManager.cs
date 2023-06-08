using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public class SoundManager
	{
        private static SoundManager _ins = null;

        private const string MUSIC_KEY = "GAME_MUSIC";
        private const string SOUND_KEY = "GAME_SOUND";

        //音乐开关记录
        private bool _musicEnable;

        //音效开关记录
		private bool _soundEnable;

        private SoundManager()
        {
            int musicVal = PlayerPrefs.GetInt(MUSIC_KEY, 1);
            int soundVal = PlayerPrefs.GetInt(SOUND_KEY, 1);

            _musicEnable = musicVal == 1;
            _soundEnable = soundVal == 1;
        }

        //获得单例
        public static SoundManager Instance
        {
            get{
                if (_ins == null)
                {
                    _ins = new SoundManager();
                }
                return _ins;
            }
        }

        //音乐开关设置
        public bool MusicEnable
        {
            set {
                _musicEnable = value;
                PlayerPrefs.SetInt(MUSIC_KEY, value ? 1 : 0);
            }
            get { return _musicEnable; }
        }

        //音效开关设置
        public bool SoundEnable
        {
            set{
                _soundEnable = value;
                PlayerPrefs.SetInt(SOUND_KEY, value ? 1 : 0);
            }
            get{ return _soundEnable; }
        }
	}
}

