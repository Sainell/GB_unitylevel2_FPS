using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Geekbrains.editor
{
    public class Window : EditorWindow
    {

        public GameObject ObjectInstantiate;
        //public List<GameObject> _gameObjList = new List<GameObject>();
        private GameObject[] _gameObjList;

        string _nameObject = "Hello World";
        bool _nameRandom;
        bool groupEnabled;
        bool _randomColor = true;
        int _countObject = 1;
        float _radius = 10;
        char _randChar;
        string _randomTempName;
        System.Random rand = new System.Random();
        Color[] _colors = new Color[]
        {
Color.green, Color.black, Color.blue, Color.clear, Color.cyan,
Color.red, Color.yellow, Color.white,
Color.red
        };
        [MenuItem("Geekbrains/Тестовое меню 2,Вызов окна")]
        public static void ShowWindow()
        {
            
            GetWindow(typeof(Window));
        }
        void OnGUI()
        {
           
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate =
            EditorGUILayout.ObjectField("Объект который хотим вставить",
            ObjectInstantiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            _nameRandom = EditorGUILayout.Toggle("Random name",_nameRandom);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
            _randomColor = EditorGUILayout.Toggle("Случайный цвет",
            _randomColor);
            _countObject = EditorGUILayout.IntSlider("Количество объектов",
            _countObject, 1, 100);
            _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10,
            50);
            EditorGUILayout.EndToggleGroup();
            if (GUILayout.Button("Создать объекты"))
            {

            if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < _countObject; i++) // Расставляемвыбранный объект по окружности
            {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0,
                        Mathf.Sin(angle)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos,
                        Quaternion.identity) as GameObject;
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        if (temp.GetComponent<Renderer>() && _randomColor)
                        {
                            temp.GetComponent<Renderer>().material.color =
                            _colors[Random.Range(0, _colors.Length - 1)];
                            // Unity предупреждает о возможной утечке памяти и предлагает использовать sharedMaterial
                        }
                        if(_nameRandom)
                        {
                            

                            for (int j = 0; j < 5; j++)
                           {
                                _randChar = (char)rand.Next(0x0410, 0x44F);
                                _randomTempName += _randChar.ToString();
                           }
                            temp.name = _randomTempName;
                        }
                        _randomTempName = null;
                    }
                }
            }
            if (GUILayout.Button("Очистить объекты со сцены"))
            {
                _gameObjList = FindObjectsOfType(typeof(GameObject)) as GameObject[];
                foreach(GameObject gameObject in _gameObjList)
                {
                    DestroyImmediate (gameObject);
                    Debug.Log("Объекты очищены");
                }

            }
        }
    }
}

    

