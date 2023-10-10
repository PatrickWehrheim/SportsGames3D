using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private MenuController _menuController;
    public MenuController MenuController { get { return _menuController; } private set { _menuController = value; } }

    [SerializeField] private OptionsData _optionsData;

    private AudioSource _audioSource;

    public static MenuManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            MenuController = new MenuController();
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            _audioSource = Instance._audioSource;
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UpdateMusicVolume(_optionsData.Volume);
    }

    /// <summary>
    /// Change the volume of the music to theh given value
    /// </summary>
    /// <param name="value">Value to set the volume</param>
    public void UpdateMusicVolume(int value)
    {
        _audioSource.volume = value * 0.01f;
    }

    /// <summary>
    /// En-/Disable music
    /// </summary>
    /// <param name="isMusicOn">Plays music if true</param>
    public void ToggleMusic(bool isMusicOn)
    {
        if (isMusicOn)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
