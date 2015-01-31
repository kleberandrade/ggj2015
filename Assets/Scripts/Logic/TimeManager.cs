using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Tempo de jogo
/// </summary>
[AddComponentMenu("Scripts/Game/TimeManager")]
public class TimeManager : MonoBehaviour
{
    #region Delegates and Events
    public delegate void TimeHandler();
    public static event TimeHandler OnStartTime;
    public static event TimeHandler OnResumeTime;
    public static event TimeHandler OnPauseTime;
    public static event TimeHandler OnTimeOver;
    #endregion

    #region Fields
    /// <summary>
    /// Tempo máximo inicial
    /// </summary>
    public float maxTimeInSeconds = 3600;

    /// <summary>
    /// Carrega o tempo e o continua até o fim
    /// </summary>
    public bool timeContinue = true;

    /// <summary>
    /// Referência para o tempo inicial do jogo5
    /// </summary>
    private float startTime = 0.0f;

    /// <summary>
    /// Referência para o tempo atual
    /// </summary>
    private float endTime = 0.0f;

    /// <summary>
    /// Flag que indica se o relógio esta paralizado
    /// </summary>
    private bool paused = false;

    /// <summary>
    /// Flag que indica se o relógio esta parado
    /// </summary>
    private bool stopped = true;
    #endregion

    /// <summary>
    /// Referêcia para a UI
    /// </summary>
    public Text timeText;

    /// <summary>
    /// Método que inicial
    /// </summary>
    void Start()
    {
        if (timeContinue)
        {
            // Procura se existe tempo restante
            if (PlayerPrefs.HasKey("TimeInSeconds"))
                maxTimeInSeconds = PlayerPrefs.GetInt("TimeInSeconds");
        }
        
        // Pega o tempo inicial
        startTime = Time.time;
    }

    /// <summary>
    /// Atualiz o tempo se ele não estive parado
    /// </summary>
    void Update()
    {
        if (!stopped)
        {
            endTime = Time.time;
            if (TotalSeconds == 0)
                StopTime();
        }
    }

    /// <summary>
    /// Salva-se a tempo quando o script é desativado
    /// </summary>
    void OnDisable()
    {
        if (TotalSeconds > 0)
            SaveTime();
    }

    /// <summary>
    /// Salva o tempo restante
    /// </summary>
    void SaveTime()
    {
        PlayerPrefs.SetInt("TimeInSeconds", TotalSeconds);
        PlayerPrefs.Save();
    }

    #region Methods
    /// <summary>
    /// Inicia o tempo
    /// </summary>
    public void StartTime()
    {
        stopped = false;
        startTime = Time.time;
        if (OnStartTime != null)
            OnStartTime();
    }

    /// <summary>
    /// Reinicia o tempo
    /// </summary>
    public void ResumeTime()
    {
        paused = false;
        Time.timeScale = 1.0f;
        if (OnResumeTime != null)
            OnResumeTime();
    }

    /// <summary>
    /// Paraliza o tempo
    /// </summary>
    public void PauseTime()
    {
        paused = true;
        Time.timeScale = 0.0f;
        if (OnPauseTime != null)
            OnPauseTime();
    }

    /// <summary>
    /// Para o tempo
    /// </summary>
    public void StopTime()
    {
        stopped = true;

        if (OnTimeOver != null)
            OnTimeOver();
    }
    #endregion

    /// <summary>
    /// Retorna o total de tempo em segundos
    /// </summary>
    public int TotalSeconds
    {
        get
        {
            return Mathf.CeilToInt(Mathf.Clamp(maxTimeInSeconds - (endTime - startTime), 0.0f, maxTimeInSeconds));
        }
    }

    /// <summary>
    /// Verifica se o tempo esta paralizado
    /// </summary>
    public bool IsPaused
    {
        get
        {
            return this.paused;
        }
    }

    /// <summary>
    /// Verifica se o tempo esta parado
    /// </summary>
    public bool IsStopped
    {
        get
        {
            return this.stopped;
        }
    }
}
