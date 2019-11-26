using System.Collections;
using UnityEngine;
using UnityEditor;
using Types;

public class EnemyDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rogueSectionTexture;
    Texture2D warriorSectionTexture;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect warriorSection;
    Rect rogueSection;

    GUISkin skin;

    static MageData mageData;
    static WarriorData warriorData;
    static RogueData rogueData;

    public static MageData MageInfo { get { return mageData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }
    public static RogueData RogueInfo { get { return rogueData; } }


    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        //EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        //window.minSize = new Vector2(600, 300);
        //window.Show();

        EnemyDesignerWindow window = CreateInstance(typeof(EnemyDesignerWindow)) as EnemyDesignerWindow;
        window.minSize = new Vector2(700, 300);
        window.ShowUtility();
    }

    /// <summary>
    /// Similar to Start() or Awake()
    /// </summary>
    private void OnEnable()
    {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("guiStyles/EnemyDesignerSkin");
    }

    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));

    }

    /// <summary>
    /// Initialize Texture2D values
    /// </summary>
    private void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("icons/mageBG");
        rogueSectionTexture = Resources.Load<Texture2D>("icons/rogueBG");
        warriorSectionTexture = Resources.Load<Texture2D>("icons/warriorBG");

    }

    /// <summary>
    /// Similar to Update function,
    /// Not called once per frame. Called 1 or more times per interaction.
    /// </summary>
    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRogueSettings();
    }

    /// <summary>
    /// Define Rect values and paints textures based on Rects
    /// </summary>
    private void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 70;

        mageSection.x = 0;
        mageSection.y = 70;
        mageSection.width = Screen.width / 3f;
        mageSection.height = Screen.height - 70;

        rogueSection.x = Screen.width / 3f;
        rogueSection.y = 70;
        rogueSection.width = Screen.width / 3f;
        rogueSection.height = Screen.height - 70;

        warriorSection.x = (Screen.width / 3f)*2;
        warriorSection.y = 70;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.height - 70;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);

    }

    /// <summary>
    /// Draw contents of header
    /// </summary>
    private void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Designer", skin.GetStyle("Header1"));

        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of Mage area
    /// </summary>
    private void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection, skin.GetStyle("GeneralPadding"));

        GUILayout.Label("Mage", skin.GetStyle("TypeHeader"));

        GUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
        GUILayout.Label("Damage", skin.GetStyle("LabelField"));
        mageData.dmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
        GUILayout.Label("Weapon", skin.GetStyle("LabelField"));
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {

            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();

    }

    /// <summary>
    /// Draw contents of Warrior area
    /// </summary>
    private void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection, skin.GetStyle("GeneralPadding"));

        GUILayout.Label("Warrior", skin.GetStyle("TypeHeader"));

        GUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
        GUILayout.Label("Class", skin.GetStyle("LabelField"));
        warriorData.classType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
        GUILayout.Label("Weapon", skin.GetStyle("LabelField"));
        warriorData.wpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {

            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        GUILayout.EndArea();

    }

    /// <summary>
    /// Draw contents of Rogue area
    /// </summary>
    private void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection, skin.GetStyle("GeneralPadding"));

        GUILayout.Label("Rogue", skin.GetStyle("TypeHeader"));

        GUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
        GUILayout.Label("Strategy", skin.GetStyle("LabelField"));
        rogueData.strategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.strategyType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
        GUILayout.Label("Weapon", skin.GetStyle("LabelField"));
        rogueData.wpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.wpnType);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40))) {

            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }

        GUILayout.EndArea();

    }

    public class GeneralSettings : EditorWindow
    {
        GUISkin skin;
        Rect settingsBackground;
        Texture2D mageSectionTexture;
        Texture2D rogueSectionTexture;
        Texture2D warriorSectionTexture;

        public enum SettingsType
        {
            MAGE,
            WARRIOR,
            ROGUE
        }

        static SettingsType dataSetting;
        static GeneralSettings window;

        public static void OpenWindow(SettingsType setting)
        {
            dataSetting = setting;

            window = CreateInstance(typeof(GeneralSettings)) as GeneralSettings;
            window.minSize = new Vector2(300, 300);
            window.ShowUtility();
        }

        private void initTextures ()
        {
            mageSectionTexture = Resources.Load<Texture2D>("icons/mageBG");
            rogueSectionTexture = Resources.Load<Texture2D>("icons/rogueBG");
            warriorSectionTexture = Resources.Load<Texture2D>("icons/warriorBG");
        }

        private void OnEnable()
        {
            skin = Resources.Load<GUISkin>("guiStyles/EnemyDesignerSkin");

            settingsBackground.x = 0;
            settingsBackground.y = 0;
            settingsBackground.width = Screen.width;
            settingsBackground.height = Screen.height;

            initTextures();
        }

        private void OnGUI()
        {
            switch (dataSetting)
            {
                case SettingsType.MAGE:
                    GUI.DrawTexture(settingsBackground, mageSectionTexture);
                    DrawSettings(MageInfo);
                    break;
                case SettingsType.ROGUE:
                    GUI.DrawTexture(settingsBackground, rogueSectionTexture);
                    DrawSettings(RogueInfo);
                    break;
                case SettingsType.WARRIOR:
                    GUI.DrawTexture(settingsBackground, warriorSectionTexture);
                    DrawSettings(WarriorInfo);
                    break;
            }
        }

        void DrawSettings (CharacterData charData)
        {

            EditorGUILayout.BeginVertical(skin.GetStyle("GeneralPadding"));
            EditorGUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
            GUILayout.Label("Prefab");
            charData.prefab = (GameObject)EditorGUILayout.ObjectField(charData.prefab, typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
            GUILayout.Label("Max Health");
            charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
            GUILayout.Label("Max Energy");
            charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
            GUILayout.Label("Power");
            charData.power = EditorGUILayout.Slider(charData.power, 0, 100);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
            GUILayout.Label("% Critical Chance");
            charData.critChance = EditorGUILayout.Slider(charData.critChance, 0, charData.power);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(skin.GetStyle("HorizontalLayout"));
            GUILayout.Label("Name");
            charData.name = EditorGUILayout.TextField(charData.name);
            EditorGUILayout.EndHorizontal();

            if (charData.prefab == null)
            {
                EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created", MessageType.Warning);
            }
            else if (charData.name == null || charData.name.Length < 1)
            {
                EditorGUILayout.HelpBox("This enemy needs a [Name] before it can be created", MessageType.Warning);
            }
            else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
            {
                SaveCharacterData();
                window.Close();
            }

            EditorGUILayout.EndVertical();

        }

        void SaveCharacterData()
        {

            string prefabPath; //path to the base prefab
            string newPrefabPath = "Assets/prefabs/characters/";
            string dataPath = "Assets/resources/characterData/data/";

            switch (dataSetting)
            {
                case SettingsType.MAGE:

                    //create the .asset file
                    dataPath += "mage/" + EnemyDesignerWindow.MageInfo.name + ".asset";
                    AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                    newPrefabPath += "mage/" + EnemyDesignerWindow.MageInfo.name + ".prefab";
                    //get the prefab path
                    prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.prefab);
                    AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                    if (!magePrefab.GetComponent<Mage>())
                    {
                        magePrefab.AddComponent(typeof(Mage));
                    }
                    magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.MageInfo;
                    break;

                case SettingsType.ROGUE:

                    dataPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".asset";
                    AssetDatabase.CreateAsset(EnemyDesignerWindow.RogueInfo, dataPath);

                    newPrefabPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".prefab";

                    //get the prefab path
                    prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RogueInfo.prefab);
                    AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                    if (!roguePrefab.GetComponent<Rogue>())
                    {
                        roguePrefab.AddComponent(typeof(Rogue));
                    }
                    roguePrefab.GetComponent<Rogue>().rogueData = EnemyDesignerWindow.RogueInfo;

                    break;

                case SettingsType.WARRIOR:

                    dataPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".asset";
                    AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                    newPrefabPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".prefab";

                    //get the prefab path
                    prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.prefab);
                    AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                    if (!warriorPrefab.GetComponent<Warrior>())
                    {
                        warriorPrefab.AddComponent(typeof(Warrior));
                    }
                    warriorPrefab.GetComponent<Warrior>().warriorData = EnemyDesignerWindow.WarriorInfo;
                    break;
            }
        }

    }

}
