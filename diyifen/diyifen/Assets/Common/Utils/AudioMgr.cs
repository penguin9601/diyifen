using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour {
	static GameObject go;
	static AudioMgr adMgr;
	//音乐文件
	public AudioSource music;
	public AudioSource sound;

	//音乐开关记录
	private bool _musicEnable;

	//音效开关记录
	private bool _soundEnable;

	private const string MUSIC_KEY = "GAME_MUSIC";
	private const string SOUND_KEY = "GAME_SOUND";

	int musicVal ;
	int soundVal ;

	void Start()
	{
		go = this.gameObject;

		musicVal = PlayerPrefs.GetInt(MUSIC_KEY, 1);
		soundVal = PlayerPrefs.GetInt(SOUND_KEY, 1);
		_musicEnable = musicVal == 1;
		_soundEnable = soundVal == 1;
	}

	public static AudioMgr getInstance() {
		if (adMgr == null) {
			adMgr = go.GetComponent<AudioMgr> ();
		}
		return adMgr;
	}


	public void PlaySound(string soundName){
		if(!_soundEnable)
        {
			return;
        }
		Debug.Log("PlaySound:" + soundName);
		AudioClip clip = Resources.Load ("audio/" + soundName) as AudioClip;
        sound.PlayOneShot(clip);
	}

	public bool MusicEnable
	{
		set
		{
			music.volume = value ? 1 : 0;
			_musicEnable = value;
			PlayerPrefs.SetInt(MUSIC_KEY, value ? 1 : 0);
		}
		get { return _musicEnable; }
	}

	//音效开关设置
	public bool SoundEnable
	{
		set
		{
			sound.volume = value ? 1 : 0;
			_soundEnable = value;
			PlayerPrefs.SetInt(SOUND_KEY, value ? 1 : 0);
		}
		get { return _soundEnable; }
	}

}
