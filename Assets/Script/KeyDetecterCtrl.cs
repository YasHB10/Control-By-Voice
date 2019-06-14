using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class KeyDetecterCtrl : MonoBehaviour {
    public Text []CubeNames;
    public Text ConcurrentValue;
    public Colorchanger[] cubes;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Accion> keyWords;
    private delegate void Accion();
    private ConfidenceLevel confidenceLevel;
    
    // Use this for initialization
	void Start () {
        confidenceLevel = ConfidenceLevel.Low;
        keyWords = new Dictionary<string, Accion>();

        ConcurrentValue.text = "";
        /*
         keyWords.Add("uno", cubes[1].ChangeColor);
        keyWords.Add("dos", cubes[2].ChangeColor);
        keyWords.Add("tres", cubes[3].ChangeColor);
        keyWords.Add("cuatro", cubes[4].ChangeColor);
        keyWords.Add("cinco", cubes[5].ChangeColor);
        keyWords.Add("seis", cubes[6].ChangeColor);
        keyWords.Add("siete", cubes[7].ChangeColor);
        keyWords.Add("ocho", cubes[8].ChangeColor);
        keyWords.Add("nueve", cubes[9].ChangeColor);
        keyWords.Add("cero", cubes[0].ChangeColor);
        keyWords.Add("ok", RestoreColorCubes);
        keyWords.Add("todos", ChangeColorCubes);
         */
        keyWords.Add("katze", cubes[1].ChangeColor);
        keyWords.Add("Bier", cubes[2].ChangeColor);
        keyWords.Add("ragazza", cubes[3].ChangeColor);
        keyWords.Add("giorno", cubes[4].ChangeColor);
        keyWords.Add("hola", cubes[5].ChangeColor);
        keyWords.Add("bien", cubes[6].ChangeColor);
        keyWords.Add("go", cubes[7].ChangeColor);
        keyWords.Add("jump", cubes[8].ChangeColor);
        keyWords.Add("merci", cubes[9].ChangeColor);
        keyWords.Add("ciel", cubes[0].ChangeColor);
        keyWords.Add("ok", RestoreColorCubes);
        keyWords.Add("todo", ChangeColorCubes);

        /*
            keyWords.Add("one", cubes[1].ChangeColor);
        keyWords.Add("two", cubes[2].ChangeColor);
        keyWords.Add("three", cubes[3].ChangeColor);
        keyWords.Add("four", cubes[4].ChangeColor);
        keyWords.Add("five", cubes[5].ChangeColor);
        keyWords.Add("six", cubes[6].ChangeColor);
        keyWords.Add("seven", cubes[7].ChangeColor);
        keyWords.Add("eight", cubes[8].ChangeColor);
        keyWords.Add("nine", cubes[9].ChangeColor);
        keyWords.Add("zero", cubes[0].ChangeColor);
        keyWords.Add("ten", RestoreColorCubes);         
         */

        keywordRecognizer = new KeywordRecognizer(keyWords.Keys.ToArray(), confidenceLevel);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args) {
        Debug.Log("Palabra: " + args.text);
        ConcurrentValue.text = args.text;
        keyWords[args.text].Invoke();
    }


    void RestoreColorCubes() {
        foreach (Colorchanger aux in cubes) {
            aux.RestoreColor();
        }
    }

    void ChangeColorCubes()
    {
        foreach (Colorchanger aux in cubes)
        {
            aux.ChangeColor();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
