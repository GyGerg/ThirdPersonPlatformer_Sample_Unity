using System;
using Cinemachine;
using DefaultNamespace;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player { get; private set; }

    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private CinemachineVirtualCamera victoryCamera;

    [SerializeField] private VictoryScreen victoryPrefab;
    [SerializeField] private GameOverScreen gameOverPrefab;

    private ReactiveProperty<int> _score; 
    public IReadOnlyReactiveProperty<int> Score => _score;
    private void Awake()
    {
        Instance = this;
        _score = new ReactiveProperty<int>(0);
        victoryCamera.enabled = false;
        // one of the worst quick-hacks of mankind incoming
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
        Application.targetFrameRate = 60;
    }

    public void KillEnemy(EnemyController obj)
    {
        MessageBroker.Default.Publish(new PointsGained(obj.PointValue));
        _score.Value += obj.PointValue;
        Destroy(obj.gameObject);
    }

    public void KillPlayer()
    {
        if (GameOverScreen.Instance != null)
        {
            Destroy(GameOverScreen.Instance.gameObject);
            GameOverScreen.Instance = null;
        }
        (GameOverScreen.Instance = Instantiate(gameOverPrefab, GameObject.FindWithTag("GameUI").transform)).Show(true);
        Destroy(player.gameObject);
        FindObjectOfType<FollowPlayer>().player = null;
        FindObjectOfType<MouseLook>().enabled = false;
    }

    public void Victory()
    {
        playerCamera.enabled = false;
        victoryCamera.enabled = true;
        if (VictoryScreen.Instance != null)
        {
            Destroy(VictoryScreen.Instance.gameObject);
            VictoryScreen.Instance = null;
        }

        (VictoryScreen.Instance = Instantiate(victoryPrefab, GameObject.FindWithTag("GameUI").transform)).Show(true);
        player.gameObject.SetActive(false);
        FindObjectOfType<FollowPlayer>().enabled = false;
        GameUiScreen.Instance.Show(false);
    }
}